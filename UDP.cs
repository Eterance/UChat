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

namespace UChat
{
    /// <summary> 
    /// 进行局域网 UDP 信息发送与监听。通信均在 50050 端口进行。
    /// </summary> 
    /// <returns></returns> 
    public class UDP
    {
        /// <summary>
        /// 向目的 IP 发送本机上线信息。
        /// </summary>
        /// <param name="iPAddress">目标主机的 IP 地址，当填写 IPAddress.Broadcast 时即为广播。</param>
        /// <param name="replyStatus">广播状态字：请使用 ReplyStatus 枚举类型。</param>
        /// <param name="onlineStatus">在线状态字：请使用 OnlineStatus 结构体。</param>
        public void OnlineMessageSend(IPAddress iPAddress, ReplyStatus replyStatus, string onlineStatus)
        {
            /// 上线状态信息由以下部分组成：
            /// 【本机活动的IP地址】 + 【分隔符“英文逗号 , ”】 + 【上下线状态字 UP 或 DP 】 + 【本用户17位UID】+ 【广播状态字】 + 【本用户名】
            string re = "";
            if (replyStatus == ReplyStatus.NeedReply)
            {
                re = "1";
            }
            else
            {
                re = "0";
            }
            string carrier = HostInfo.IPv4Address.ToString() + onlineStatus.ToString() + CommonFoundations.HostUID + re + CommonFoundations.HostName;
            UDPMessageSender(iPAddress, carrier);
        }
        /// <summary>
        /// 在 50050 端口向目的 IP 发送UDP信息。
        /// </summary>
        /// <param name="iPAddress">目标主机的 IP 地址，当填写 IPAddress.Broadcast 时即为广播。</param>
        /// <param name="carrier">需要发送的信息</param>
        public void UDPMessageSender(IPAddress iPAddress, string carrier)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint iep1 = new IPEndPoint(iPAddress, 50050);
            IPEndPoint iepHost = new IPEndPoint(HostInfo.IPv4Address, 50050);
            byte[] data = Encoding.UTF8.GetBytes(carrier);
            socket.Bind(iepHost);                                                                                                                                               //需要绑定一块活动的网卡，不然无法发送信息
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
            socket.SendTo(data, iep1);
            socket.Shutdown(SocketShutdown.Send);//发送完数据后关闭socket
            socket.Close();
        }

        /// <summary> 
        /// 监听UDP广播与信息。
        /// </summary> 
        /// <returns></returns> 
        public void UDPMessageListener()
        {
            IPEndPoint ipEP1 = new IPEndPoint(IPAddress.Any, 50050);   //IPAddress.any即为所有活动主机
            UdpClient udpReceive = new UdpClient(ipEP1);
            while (true)
            {
                try
                {
                    byte[] bytRecv = udpReceive.Receive(ref ipEP1);
                    string message = Encoding.UTF8.GetString(bytRecv, 0, bytRecv.Length);
                    MessageProcessor(message);//交由处理方法
                }
                catch
                {
                    break;
                }
            }
        }

        /// <summary>
        /// 对收到的 UDP 信息作进一步归档处理。涉及跨线程。
        /// </summary>
        /// <param name="carrier"></param>
        public void MessageProcessor(string message)
        {
            if (message.Substring(0,2) == "FR" || message.Substring(0, 2) == "FA")//这些开头代表是文件传输请求
            {
                FileTransfer.RequestProcessor(message);//交由其他方法处理
            }
            else//属于上下线信息
            {
                ///对收到的广播信息进行分解
                ///广播信息由以下部分组成：
                /// 【IP地址】 + 【分隔符“英文逗号 , ”】 + 【上下线状态字 UP 或 DP 】 + 【17位UID】+ 【广播状态字】 + 【用户名】
                /// 广播状态字：1代表是广播需要回复，0代表不是广播（是回复）
                string IP = message.Substring(0, message.IndexOf(',')); //远程主机的IP
                if (IP != HostInfo.IPv4Address.ToString())//不是本机发出的
                {
                    string status = message.Substring(message.IndexOf(',') + 1, message.IndexOf('P') - message.IndexOf(','));   //远程主机的上下线状态字
                    string UID = message.Substring(message.IndexOf('P') + 1, 17);   //远程主机的UID
                    string replyStatus = message.Substring(message.IndexOf('P') + 18, 1);   //远程主机的广播状态字
                    string name = message.Substring(message.IndexOf('P') + 19);   //远程主机的用户名

                    //如果对方是上线主机，且需要回复，需要应答广播消息
                    if (status == "UP" && replyStatus == "1")
                    {
                        OnlineMessageSend(IPAddress.Parse(IP), ReplyStatus.NoReplyRequired, OnlineStatus.Online);//目标主机为广播的源主机
                    }

                    FormMain.formMain.UpdateLANTable(UID, name, IP, status);//由收到的广播更新LAN表
                }
            }
        }
    }
}
