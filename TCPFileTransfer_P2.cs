using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace UChat
{
    public partial class TCPFileTransfer
    {
        /// <summary>
        /// 在端口 50024 上接受文件。
        /// </summary>
        public class FileReceiver
        {
            /// <summary>
            /// 在端口 50024 上接受文件。
            /// </summary>
            public FileReceiver()//构造函数
            {
            }

            /// <summary>
            /// 在端口 50024 上接受文件。
            /// </summary>
            /// <param name="filePath">文件保存的路径</param>
            /// <param name="fileByte">文件字节数</param>
            /// <param name="senderIP">文件发送者的 IP</param>
            public FileReceiver(string filePath, long fileByte, string senderIP)//构造函数
            {
                SetParameters(filePath, fileByte, senderIP);
            }

            /// <summary>
            /// 设置必要的参数。
            /// </summary>
            /// <param name="filePath">文件保存的路径</param>
            /// <param name="fileByte">文件字节数</param>
            /// <param name="senderIP">文件发送者的 IP</param>
            public void SetParameters(string filePath, long fileByte, string senderIP)
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
            byte[] fragmentBuffer = new byte[14000];
            /// <summary>
            /// 数据块缓存
            /// </summary>
            byte[] blockBuffer = new byte[100 * 14000];
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
                            CancelByOpposite = true;
                        }
                    }
                }
                catch //(Exception e)
                {
                }
                finally
                {
                    listener.Stop();
                }
            }

            /// <summary>
            /// 开始接收文件。返回一个 TaskCompletionStatus 值，指示是文件传输结果。
            /// </summary>
            /// <param name="percentage">将文件传输任务进度以 0-100 的数字传递出来到这个数。</param>
            /// <returns>返回一个值，指示完成文件传输的结果。</returns>
            public TaskCompletionStatus Start(ref int percentage)
            {
                if (isAlreadyStart == false)
                {
                    isAlreadyStart = true;
                    TCP tCP = new TCP();

                    //建立中断信号监听
                    TcpListener cancelSignalListener = new TcpListener(IPAddress.Any, 50020);
                    cancelSignalListener.Start();
                    //异步接受连接请求
                    cancelSignalListener.BeginAcceptTcpClient(new AsyncCallback(DoAcceptTcpClient), cancelSignalListener);

                    int fragmentBufferLength = fragmentBuffer.Length;
                    int blockBufferBufferLength = blockBuffer.Length;
                    int blockElementsNums = 0;//指示 blockBuffer 中有多少个字节
                    long totalindex = FileByte / fragmentBufferLength;//文件的总片数
                    CommonFoundations.FileTransferTempData.TotalBlocks = totalindex;
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
                                            percentage = Percentage;

                                            if (blockElementsNums == blockBuffer.Length)//缓存块满，需要写入到文件
                                            {
                                                fStream.Write(blockBuffer, 0, blockBufferBufferLength);
                                                blockElementsNums = 0;
                                            }

                                            //中断传输
                                            #region
                                            if (CommonFoundations.FileTransferTempData.CancelFTR == true)
                                            {
                                                CancelByHost = true;
                                            }
                                            //任意一方发出了取消请求
                                            if (CancelByHost == true || CancelByOpposite == true)
                                            {
                                                if (CancelByHost == true)//自己结束的
                                                {
                                                    tCP.TCPMessageSender(RemoteIP, "CANCEL", 50020);//发送取消消息监听
                                                    BlockConfirm(ref signalStream, "OK");//发送消息，让对面解除因为监听 Block 确认造成的阻塞

                                                    fStream.Flush();
                                                    fStream.Dispose();
                                                    fStream.Close();
                                                    File.Delete(FilePath);//删除未完成的文件
                                                    return TaskCompletionStatus.HostCancel;
                                                }
                                                if (CancelByOpposite == true)//对面结束的，表明已经收到了 取消消息，不用再发
                                                {

                                                    fStream.Flush();
                                                    fStream.Dispose();
                                                    fStream.Close();
                                                    File.Delete(FilePath);//删除未完成的文件
                                                    return TaskCompletionStatus.OppositeCancel;
                                                }
                                            }
                                            #endregion

                                            BlockConfirm(ref signalStream, "OK");//发送消息让对方传输下一个块
                                            CommonFoundations.FileTransferTempData.CurrentBlocks = index;
                                        }

                                        if (blockElementsNums != 0)//缓存块里有东西，需要最后一次写入
                                        {
                                            fStream.Write(blockBuffer, 0, blockElementsNums);
                                        }
                                        //BlockSaved(ref signalStream, "OVER");//发送消息让对方结束传输
                                    }

                                }
                            }
                        }
                        newClient.Close();
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
                        signalClient.Close();
                        tcpListener.Stop();//结束监听器
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
            /// 发送控制信号。
            /// </summary>
            private void BlockConfirm(ref NetworkStream sendStream, string message)
            {
                try
                {
                    byte[] sendBytes = Encoding.UTF8.GetBytes(message);
                    sendStream.Write(sendBytes, 0, sendBytes.Length);
                    sendStream.Flush();
                }
                catch
                {
                }
            }
        }
    }
}
