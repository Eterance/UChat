﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Management;
using System.Threading;
using System.Windows;
using System.Timers;
using System.Diagnostics;
using SpecialEnumeration;

namespace UChat
{
    /// <summary>
    /// 文件传输。
    /// </summary>
    public class TCPFileTransfer
    {
         /// <summary>
         /// 表示文件传输任务完成结果。
         /// </summary>
        public enum TaskCompletionStatus
        {
            /// <summary>
            /// 已经被启动了
            /// </summary>
            AlreadyRun,
            /// <summary>
            /// 发送成功
            /// </summary>
            Success,
            /// <summary>
            /// 被我方取消
            /// </summary>
            HostCancel,
            /// <summary>
            /// 被对方取消
            /// </summary>
            OppositeCancel,
            /// <summary>
            /// 未知错误
            /// </summary>
            Error
        }

        /// <summary>
        /// 在端口 50024 上发送文件。
        /// </summary>
        public class FileSender
        {
            
            /// <summary>
            /// 在端口 50024 上发送文件。
            /// </summary>
            /// <param name="filePath">文件的路径</param>
            /// <param name="fileByte">文件字节数</param>
            /// <param name="receiverIP">接收者的 IP</param>
            public FileSender(string filePath, long fileByte, string receiverIP)//构造函数
            {
                RemoteIP = receiverIP;
                FilePath = filePath;
                FileByte = fileByte;
            }

            /// <summary>
            /// 是否已经启动
            /// </summary>
            bool isAlreadyStart = false;
            /// <summary>
            /// 数据片缓存
            /// </summary>
            byte[] fragmentBuffer = new byte[1400];
            /// <summary>
            /// 发送的文件路径。
            /// </summary>
            string FilePath { get; set; }
            long FileByte { get; set; }
            string RemoteIP { get; set; }
            /// <summary>
            /// 指示对方是否结束。
            /// </summary>
            bool CancelByOpposite = false;
            /// <summary>
            /// 指示我方是否结束。
            /// </summary>
            bool CancelByHost = false;
            /// <summary>
            /// 已经发送的百分比。范围是 0~100。
            /// </summary>
            public int Percentage { get; private set; } = 0;

            Thread thread;

            TcpListener signalListener = new TcpListener(IPAddress.Any, 50023);//监听控制信息

            /// <summary>
            /// 监听取消控制信息。
            /// </summary>
            private void ListenCancelSignal()
            {
                TCP tCP = new TCP();
                string message = tCP.TCPMessageListener(50020);
                if (message == "CANCEL")//对面发来的取消请求
                {
                    CancelByOpposite = true;
                }
            }

            /// <summary>
            /// 开始发送文件。返回一个 TaskCompletionStatus 值，指示是文件传输结果。
            /// </summary>
            /// <param name="percentage">将文件传输任务进度以 0-100 的数字传递出来到这个数。</param
            /// <returns>返回一个 bool 值，指示是否完成文件传输。false 表示遭到用户中断。</returns>
            public TaskCompletionStatus Start(ref int percentage)
            {
                if (isAlreadyStart == false)//没有启动
                {
                    isAlreadyStart = true;
                    TCP tCP = new TCP();
                    thread = new Thread(ListenCancelSignal);
                    thread.Start();//启动取消信息监听线程。

                    int fragmentBufferLength = fragmentBuffer.Length;
                    long totalindex = FileByte / fragmentBufferLength;//文件的总块数
                    long index = 0;
                    //int max = 0;

                    signalListener.Start();//开始监听控制信息；
                    TcpClient signalClient = signalListener.AcceptTcpClient();//接收到控制信号连接请求，即允许建立文件传输连接
                    NetworkStream signalStream = signalClient.GetStream();
                    Thread.Sleep(50);//等待一点时间，让对面建立监听

                    TcpClient client = new TcpClient(RemoteIP, 50024);//初始化一个对象，并连接到目标主机（因此不需要 connect 方法）
                    client.NoDelay = true;//禁用 Nagle 算法，使数据包立即发出
                    try
                    {
                        FileStream fStream = File.OpenRead(FilePath);//打开文件流
                        NetworkStream sendStream = client.GetStream();
                        BufferedStream bufferedStream = new BufferedStream(sendStream);//建立缓冲流
                        using (fStream)
                        {
                            using (client)
                            {
                                using (sendStream)
                                {
                                    using (bufferedStream)
                                    {
                                        while ((fragmentBufferLength = fStream.Read(fragmentBuffer, 0, fragmentBufferLength)) > 0)//blockBufferLength为0时，即文件流到达结尾
                                        {
                                            sendStream.Write(fragmentBuffer, 0, fragmentBufferLength);
                                            sendStream.Flush();
                                            BlockServed(ref signalStream, signalClient.ReceiveBufferSize);  //这是一个阻塞方法，只有收到确认后才继续传下一个数据片
                                            index++;
                                            Percentage = (int)(((double)index / totalindex) * 100);//计算传输百分比
                                            //CommonFoundations.FileTransferTempData.FTRPercentage2 = PercentageSent;
                                            percentage = Percentage;

                                            if (CommonFoundations.FileTransferTempData.CancelFTR == true)
                                            {
                                                CancelByHost = true;
                                            }
                                            if (CancelByHost == true || CancelByOpposite == true)
                                            {
                                                if (CancelByHost == true)//自己结束的
                                                {                                                    
                                                    tCP.TCPMessageSender("127.0.0.1", "no", 50020);//连接本机以关掉 取消消息监听
                                                    tCP.TCPMessageSender(RemoteIP, "CANCEL", 50020);//发送取消消息监听
                                                    return TaskCompletionStatus.HostCancel;
                                                }
                                                if (CancelByOpposite == true)//对面结束的，表明已经收到了 取消消息，不用再发
                                                {
                                                    tCP.TCPMessageSender("127.0.0.1", "no", 50020);//连接本机以关掉 取消消息监听
                                                    return TaskCompletionStatus.OppositeCancel;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    #region
                    catch (ArgumentNullException e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                    catch (ArgumentException e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                    catch (NotSupportedException e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                    catch (FileNotFoundException e)///File.OpenRead
                    {
                        MessageBox.Show(e.ToString());
                    }
                    catch (IOException e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                    catch (ObjectDisposedException e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                    catch (InvalidOperationException e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                    catch (SocketException e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("未知错误！\r\n" + e.ToString());
                    }
                    #endregion
                    finally//收尾工作
                    {
                        signalStream.Dispose();
                        signalStream.Close();
                        signalClient.Close();
                        client.Close();//关闭客户端
                        signalListener.Stop();
                    }
                    tCP.TCPMessageSender("127.0.0.1", "no", 50020);//连接本机以关掉 取消消息监听
                    isAlreadyStart = false;
                    return TaskCompletionStatus.Success;
                }
                else
                {
                    return TaskCompletionStatus.AlreadyRun;
                }
            }

            /// <summary>
            /// 停止发送文件。
            /// </summary>
            public void Abort()
            {
                if (isAlreadyStart == true)//在运行
                {
                    CancelByHost = true;
                    isAlreadyStart = false;
                }
                else
                {
                }
            }

            /// <summary>
            /// 如果收到对方发送的"已经处理好之前发送的 2M 块"信息，返回给上一层。在 50023 端口通讯。
            /// </summary>
            /// <returns></returns>
            private bool BlockServed(ref NetworkStream signalStream, int receiveBufferSize)
            {

                while (true)
                {
                    if (signalStream.DataAvailable == false)
                    {
                        continue;
                    }
                    try
                    {
                        //TcpClient tcpClient = signalListener.AcceptTcpClient();
                        string message = "";
                        byte[] buffer = new byte[receiveBufferSize];//缓冲字节数组
                        signalStream.Read(buffer, 0, buffer.Length);
                        message = Encoding.UTF8.GetString(buffer).Trim('\0');//收到的信息
                        if (message == "OK")
                        {
                            return false;
                        }
                        if (message == "OVER")
                        {
                            return true;
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }


        /// <summary>
        /// 在端口 50024 上接受文件。
        /// </summary>
        public class FileReceiver
        {
            /// <summary>
            /// 在端口 50024 上接受文件。
            /// </summary>
            /// <param name="filePath">文件保存的路径</param>
            /// <param name="fileByte">文件字节数</param>
            /// <param name="senderIP">文件发送者的 IP</param>
            public FileReceiver(string filePath, long fileByte, string senderIP)//构造函数
            {
                FilePath = filePath;
                FileByte = fileByte;
                RemoteIP = senderIP;
            }

           
            /// <summary>
            /// 是否已经启动
            /// </summary>
            bool isAlreadyStart = false;
            /// <summary>
            /// 数据片缓存
            /// </summary>
            byte[] fragmentBuffer = new byte[1400];
            /// <summary>
            /// 数据块缓存
            /// </summary>
            byte[] blockBuffer = new byte[100 * 1400];
            /// <summary>
            /// 接收的文件路径。
            /// </summary>
            string FilePath { get; set; }
            long FileByte { get; set; }
            string RemoteIP { get; set; }
            /// <summary>
            /// 指示对方是否结束。
            /// </summary>
            bool CancelByOpposite = false;
            /// <summary>
            /// 指示我方是否结束。
            /// </summary>
            bool CancelByHost = false;
            /// <summary>
            /// 已经发送的百分比。范围是 0~100。
            /// </summary>
            public int Percentage { get; private set; } = 0;

            Thread thread;


            /// <summary>
            /// 监听取消控制信息。
            /// </summary>
            private void ListenCancelSignal()
            {
                TCP tCP = new TCP();
                string message = tCP.TCPMessageListener(50020);
                if (message == "CANCEL")//对面发来的取消请求
                {
                    CancelByOpposite = true;
                }
            }

            /// <summary>
            /// 开始接收文件。返回一个 TaskCompletionStatus 值，指示是文件传输结果。
            /// </summary>
            /// <param name="percentage">将文件传输任务进度以 0-100 的数字传递出来到这个数。</param
            /// <returns>返回一个 bool 值，指示是否完成文件传输。false 表示遭到用户中断。</returns>
            public TaskCompletionStatus Start(ref int percentage)
            {
                if (isAlreadyStart == false)
                {
                    isAlreadyStart = true;
                    TCP tCP = new TCP();
                    thread = new Thread(ListenCancelSignal);
                    thread.Start();//启动取消信息监听线程。

                    int fragmentBufferLength = fragmentBuffer.Length;
                    int blockBufferBufferLength = blockBuffer.Length;
                    int blockElementsNums = 0;//指示 blockBuffer 中有多少个字节
                    long totalindex = FileByte / fragmentBufferLength;//文件的总片数
                    long index = 0;//接受数据片的序号

                    Thread.Sleep(50);//等待对面建立控制信号监听
                    TcpClient signalClient = new TcpClient(RemoteIP, 50023);//请求连接控制消息
                    signalClient.NoDelay = true;//禁用 Nagle 算法，使数据包立即发出
                    NetworkStream signalStream = signalClient.GetStream();

                    TcpListener tcpListener = new TcpListener(IPAddress.Any, 50024);//本机所有ip 
                    try
                    {
                        FileStream fStream = new FileStream(FilePath, FileMode.Create);
                        tcpListener.Start();
                        TcpClient newClient = tcpListener.AcceptTcpClient();
                        NetworkStream clientStream = newClient.GetStream();
                        BufferedStream bufferedStream = new BufferedStream(clientStream);//建立缓冲流
                        using (fStream)
                        {
                            using (newClient)
                            {
                                using (clientStream)
                                {
                                    using (bufferedStream)
                                    {
                                        if (clientStream.CanRead)
                                        {
                                            while (index <= totalindex)   //判断传入长度（整个文件的长度等于每次传入的次数加上一开始多读取的字符串的长度）  
                                            {
                                                if (index == totalindex)//最后一次循环
                                                {
                                                    int mod = (int)(FileByte % fragmentBufferLength);//最后一次传输有多少字节
                                                    if (mod == 0)//文件总字节长度是 数据片 的整数倍，即本次传输没有任何有效字节
                                                    {
                                                        fragmentBufferLength = 0;
                                                        break;//放弃本次的无效数据，退出循环
                                                    }
                                                    else//不是整数倍
                                                    {
                                                        fragmentBufferLength = mod;
                                                    }
                                                }
                                                bufferedStream.Read(fragmentBuffer, 0, fragmentBufferLength);
                                                Buffer.BlockCopy(fragmentBuffer, 0, blockBuffer, blockElementsNums, fragmentBufferLength);//把数据片中的数据追加到数据块缓存中
                                                index++;
                                                blockElementsNums += fragmentBufferLength;
                                                Percentage = (int)(((double)index / totalindex) * 100);//计算传输百分比
                                                                                                       //CommonFoundations.FileTransferTempData.FTRPercentage2 = Percentage;
                                                percentage = Percentage;

                                                if (blockElementsNums == blockBuffer.Length)//缓存块满，需要写入到文件
                                                {
                                                    fStream.Write(blockBuffer, 0, blockBufferBufferLength);
                                                    blockElementsNums = 0;
                                                }
                                                BlockSaved(ref signalStream, "OK");//发送消息让对方传输下一个块
                                            }
                                            if (blockElementsNums != 0)//缓存块里有东西，需要最后一次写入
                                            {
                                                fStream.Write(blockBuffer, 0, blockElementsNums);
                                            }
                                            if (CommonFoundations.FileTransferTempData.CancelFTR == true)
                                            {
                                                CancelByHost = true;
                                            }
                                            if (CancelByHost == true || CancelByOpposite == true)//任意一方发出了取消请求
                                            {
                                                if (CancelByHost == true)//自己结束的
                                                {
                                                    tCP.TCPMessageSender("127.0.0.1", "no", 50020);//连接本机以关掉 取消消息监听
                                                    tCP.TCPMessageSender(RemoteIP, "CANCEL", 50020);//发送取消消息监听
                                                    return TaskCompletionStatus.HostCancel;
                                                }
                                                if (CancelByOpposite == true)//对面结束的，表明已经收到了 取消消息，不用再发
                                                {
                                                    tCP.TCPMessageSender("127.0.0.1", "no", 50020);//连接本机以关掉 取消消息监听
                                                    return TaskCompletionStatus.OppositeCancel;
                                                }
                                                File.Delete(FilePath);//删除未完成的文件
                                            }
                                            //BlockSaved(ref signalStream, "OVER");//发送消息让对方结束传输
                                        }
                                    }
                                }
                                signalStream.Dispose();
                                newClient.Close();
                                signalClient.Close();
                            }
                        }
                    }
                    #region
                    catch (ArgumentNullException e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                    catch (ArgumentException e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                    catch (NotSupportedException e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                    catch (FileNotFoundException e)///File.OpenRead
                    {
                        MessageBox.Show(e.ToString());
                    }
                    catch (IOException e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                    catch (ObjectDisposedException e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                    catch (InvalidOperationException e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                    catch (SocketException e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("未知错误！\r\n" + e.ToString());
                    }
                    finally
                    {
                        tcpListener.Stop();//结束监听器
                    }
                    #endregion
                    return TaskCompletionStatus.Success;//完美结束
                }
                else
                {
                    return TaskCompletionStatus.AlreadyRun;
                }
            }
            
            /// <summary>
             /// 停止发送文件。
             /// </summary>
            public void Abort()
            {
                if (isAlreadyStart == true)//在运行
                {
                    CancelByHost = true;
                    isAlreadyStart = false;
                }
                else
                {
                }
            }

            /// <summary>
            /// 发送控制信号。
            /// </summary>
            private void BlockSaved(ref NetworkStream sendStream, string message)
            {
                try
                {
                    byte[] sendBytes = Encoding.UTF8.GetBytes(message);
                    sendStream.Write(sendBytes, 0, sendBytes.Length);
                    sendStream.Flush();
                    //sendStream.Close();//关闭网络流  
                    //MessageBox.Show("ok");
                    //client.Close();//关闭客户端
                }
                catch
                {
                }
            }
        }
    }
}
