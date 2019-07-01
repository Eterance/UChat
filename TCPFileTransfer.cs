using System;
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
    public partial class TCPFileTransfer
    {
        /// <summary>
        /// 表示文件传输任务完成结果。
        /// </summary>
        #region
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
        #endregion

        /// <summary>
        /// 在端口 50024 上发送文件。
        /// </summary>
        public class FileSender
        {
             /// <summary>
             /// 在端口 50024 上发送文件。
             /// </summary>
            public FileSender()//构造函数
            {
            }
            /// <summary>
            /// 在端口 50024 上发送文件。
            /// </summary>
            /// <param name="filePath">文件的路径</param>
            /// <param name="fileByte">文件字节数</param>
            /// <param name="receiverIP">接收者的 IP</param>
            public FileSender(string filePath, long fileByte, string receiverIP)//构造函数
            {
                SetParameters(filePath, fileByte, receiverIP);
            }

            /// <summary>
            /// 设置必要的参数。
            /// </summary>
            /// <param name="filePath">文件保存的路径</param>
            /// <param name="fileByte">文件字节数</param>
            /// <param name="receiverIP">文件接受者的 IP</param>
            public void SetParameters(string filePath, long fileByte, string receiverIP)
            {
                FilePath = filePath;
                FileByte = fileByte;
                RemoteIP = receiverIP;
            }

            /// <summary>
            /// 是否已经启动
            /// </summary>
            bool isAlreadyStart = false;
            /// <summary>
            /// 数据片缓存
            /// </summary>
            byte[] fragmentBuffer = new byte[14000];
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
            /// <summary>
            /// 监听控制信息
            /// </summary>
            TcpListener signalListener = new TcpListener(IPAddress.Any, 50023);
            
            /// <summary>
            /// 处理收到的取消控制消息。
            /// </summary>
            /// <param name="iar"></param>
            public void DoAcceptTcpClient(IAsyncResult iar)
            {
                //还原原始的TcpListner对象
                TcpListener listener = (TcpListener)iar.AsyncState;
                string message = "";
                try
                {
                    //完成连接的动作，并返回新的TcpClient
                    TcpClient client = listener.EndAcceptTcpClient(iar);

                    using (client)
                    {
                        byte[] buffer = new byte[client.ReceiveBufferSize];//缓冲字节数组
                        NetworkStream clientStream = client.GetStream();
                        using (clientStream)
                        {
                            clientStream.Read(buffer, 0, buffer.Length);
                            message = Encoding.UTF8.GetString(buffer).Trim('\0');//收到的信息
                            clientStream.Close();
                        }
                        client.Close();
                        if (message == "CANCEL")//对面发来的取消请求
                        {
                            //MessageBox.Show("Copy That");
                            CancelByOpposite = true;
                        }
                    }
                }
                catch //(Exception e)
                {
                    //MessageBox.Show(e.ToString());
                }
                finally
                {
                    listener.Stop();
                }
            }

            /// <summary>
            /// 开始发送文件。返回一个 TaskCompletionStatus 值，指示是文件传输结果。
            /// </summary>
            /// <param name="percentage">将文件传输任务进度以 0-100 的数字传递出来到这个数。</param>
            /// <returns>返回一个值，指示完成文件传输的结果。</returns>
            public TaskCompletionStatus Start(ref int percentage)
            {
                if (isAlreadyStart == false)//没有启动
                {
                    isAlreadyStart = true;
                    TCP tCP = new TCP();

                    TcpListener cancelSignalListener = new TcpListener(IPAddress.Any, 50020);
                    cancelSignalListener.Start();
                    //异步接受连接请求
                    cancelSignalListener.BeginAcceptTcpClient(new AsyncCallback(DoAcceptTcpClient), cancelSignalListener);

                    int fragmentBufferLength = fragmentBuffer.Length;
                    long totalindex = FileByte / fragmentBufferLength;//文件的总块数
                    CommonFoundations.FileTransferTempData.TotalBlocks = totalindex;
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
                                            CommonFoundations.FileTransferTempData.CurrentBlocks = index;
                                            BlockConfirmationReceive(ref signalStream, signalClient.ReceiveBufferSize);  //这是一个阻塞方法，只有收到确认后才继续传下一个数据片
                                            index++;
                                            Percentage = (int)(((double)index / totalindex) * 100);//计算传输百分比
                                            percentage = Percentage;

                                            //中断传输
                                            #region
                                            if (CommonFoundations.FileTransferTempData.CancelFTR == true)
                                            {
                                                //MessageBox.Show("CancelFTR == true");
                                                CancelByHost = true;
                                            }
                                            if (CancelByHost == true || CancelByOpposite == true)
                                            {
                                                //MessageBox.Show("IN CHOOSE");
                                                if (CancelByHost == true)//自己结束的
                                                {
                                                    //MessageBox.Show("CancelByHost == true");
                                                    tCP.TCPMessageSender(RemoteIP, "CANCEL", 50020);//发送取消消息监听
                                                    return TaskCompletionStatus.HostCancel;
                                                }
                                                if (CancelByOpposite == true)//对面结束的，表明已经收到了 取消消息
                                                {
                                                    //MessageBox.Show("CancelByOpposite == true");
                                                    return TaskCompletionStatus.OppositeCancel;
                                                }
                                            }
                                            #endregion
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //catch
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
                        cancelSignalListener.Stop();//结束取消控制信息监听器
                        signalStream.Dispose();
                        signalStream.Close();
                        signalClient.Close();
                        client.Close();//关闭客户端
                        signalListener.Stop();
                    }
                    isAlreadyStart = false;
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
            /// 如果收到对方发送的"已经处理好之前发送的 2M 块"信息，返回给上一层。在 50023 端口通讯。
            /// </summary>
            /// <returns></returns>
            private bool BlockConfirmationReceive(ref NetworkStream signalStream, int receiveBufferSize)
            {
                while (true)
                {
                    /*if (signalStream.DataAvailable == false)
                    {
                        continue;
                    }*/
                    try
                    {
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
                        else
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
    }
}

