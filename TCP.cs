#define debug
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
using SpecialEnumeration;

//fsutil file createnew null.txt 5278350000
namespace UChat
{ /// <summary> 
  /// 进行局域网 TCP 通信。信息发送在 50012 端口进行，文件传输在 50024 端口进行。
  /// </summary> 
  /// <returns></returns> 
    public class TCP
    {
        /// <summary>
        /// 发送聊天消息。
        /// </summary>
        /// <param name="ip">目标主机 IP</param>
        /// <param name="message">要发送的消息。应该以本机 UID 打头方便对面识别。</param>
        /// <param name="port">50012 端口。</param>
        public void TCPMessageSender(string ip, string message, int port)
        {
            try
            {
                TcpClient client = new TcpClient(ip, port);//初始化一个对象，并连接到目标主机（因此不需要 connect 方法）
                ///NetworkStream 是面向连接，基于 TCP/IP 的网络流，在 UDP 使用中虽然不会报错但是会异常
                NetworkStream sendStream = client.GetStream();
                byte[] sendBytes = Encoding.UTF8.GetBytes(message);
                using (client)
                {
                    using (sendStream)
                    {
                        sendStream.Write(sendBytes, 0, sendBytes.Length);
                        sendStream.Flush();
                        sendStream.Close();//关闭网络流  
                    }
                }
                //client.Close();//关闭客户端
            }
            catch
            {
            }
        }

        /// <summary>
        /// 监听在 50012 端口的 TCP 信息发送。这是一个可以在后台线程上循环复用的方法。
        /// </summary>
        public void TCPMessageListener()
        {
            TcpListener tcpListener = new TcpListener(HostInfo.IPv4Address, 50012);//本机ip 
            tcpListener.Start();

            while (true)
            {
                try
                {
                    TcpClient newClient = tcpListener.AcceptTcpClient();
                    string message = "";
                    using (newClient)
                    {
                        byte[] buffer = new byte[newClient.ReceiveBufferSize];//缓冲字节数组
                        NetworkStream clientStream = newClient.GetStream();
                        using (clientStream)
                        {
                            clientStream.Read(buffer, 0, buffer.Length);
                            message = Encoding.UTF8.GetString(buffer).Trim('\0');//收到的信息
                            clientStream.Close();
                        }
                        newClient.Close();
                    }
                    MessageProcessor(message);//将信息载体交给下一级方法分割处理
                }
                catch
                {
                }
            }
        }

        /// <summary>
        ///  监听端口的 TCP 信息发送。一次性使用。
        /// </summary>
        /// <param name="port">监听的端口号</param>
        /// <returns></returns>
        public string TCPMessageListener(int port)
        {
            TcpListener tcpListener = new TcpListener(HostInfo.IPv4Address, port);//本机ip 
            tcpListener.Start();
            
            string message = "";
            try
            {
                TcpClient newClient = tcpListener.AcceptTcpClient();

                using (newClient)
                {
                    byte[] buffer = new byte[newClient.ReceiveBufferSize];//缓冲字节数组
                    NetworkStream clientStream = newClient.GetStream();
                    using (clientStream)
                    {
                        clientStream.Read(buffer, 0, buffer.Length);
                        message = Encoding.UTF8.GetString(buffer).Trim('\0');//收到的信息
                        clientStream.Close();
                    }
                    newClient.Close();
                }
            }
            catch (Exception e)
            {
                return "Error!\r\n" + e.ToString();
            }
            finally
            {
                tcpListener.Stop();
            }
            //MessageBox.Show(message);
            return message;            
        }

        /// <summary>
        /// 对收到的 TCP 信息作进一步归档处理。
        /// </summary>
        /// <param name="carrier"></param>
        private static void MessageProcessor(string carrier)
        {
            if (carrier.Substring(0,2) == "FR")//首部有文件传输请求
            {

            }
            else//首部没有 FR(File transfer Request) , 这是一个正常的聊天消息
            {
                string remoteUID = carrier.Substring(0, 17);
                string message = carrier.Substring(17);
                if (remoteUID == CommonFoundations.RemoteUID)//收到的消息是正在聊天的对面发的，直接搞到聊天框
                {
                    FormMain.formMain.HandleYouMessage(message);
                }
                else//不是正在聊天的人发的，归档为未读消息
                {
                    FormMain.formMain.WriteUnread(remoteUID, message);
                }
            }
        }
    }
}
