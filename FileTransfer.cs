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
    /// 文件传输。
    /// </summary>
    public static class FileTransfer
    {
        /// <summary>
        /// 发起文件传输请求，等待对面确认。
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fileSize"></param>
        public static void FileTransferRequestSender(string fileName, long fileSize)
        {
            /// 文件传输请求信息由以下部分组成：
            /// 【文件传输请求字 FR】+【本用户17位UID】+【12位文件大小（不足左边补0）】+【文件名】
            string carrier = "FR" +  CommonFoundations.HostUID + fileSize.ToString().PadLeft(12, '0') + fileName;
            IPAddress iPAddress = IPAddress.Parse(CommonFoundations.FileTransferTempData.FRDestinationIP);
            UDP uDP = new UDP();
            uDP.UDPMessageSender(iPAddress, carrier);
        }

        /// <summary>
        /// 发送文件传输请求回复。
        /// </summary>
        /// <param name="AcceptStatus">文件传输请求确认：使用 AcceptStatus 结构体。</param>
        public static void FileTransferAnswerSender(string AcceptStatus)
        {
            /// 文件传输请求信息由以下部分组成：
            /// 【文件传输请求字 FR】+【接受状态字】
            string carrier = "FA" + AcceptStatus;
            //MessageBox.Show(carrier);
            //MessageBox.Show(carrier);
            IPAddress iPAddress = IPAddress.Parse(CommonFoundations.FileTransferTempData.FRSourceIP);
            UDP uDP = new UDP();
            uDP.UDPMessageSender(iPAddress, carrier);
        }

        /// <summary>
        /// 处理接收到的文件传输请求。涉及跨线程。
        /// </summary>
        /// <param name="message"></param>
        public static void RequestProcessor(string message)
        {
            if (message.Substring(0, 2) == "FR")//代表是文件传输请求
            {
                if (CommonFoundations.FileTransferTempData.FlieTransferAcceptLock == true)//本机锁开，自动拒绝
                {
                    FileTransferAnswerSender(AcceptStatus.RefuseByLock);
                }
                else
                {
                    CommonFoundations.FileTransferTempData.FlieTransferAcceptLock = true;//开启文件锁
                    string uid = message.Substring(2, 17);
                    string fileSize = message.Substring(19, 12);
                    string fileName = message.Substring(31);
                    FormMain.formMain.ShowFileTransferConfirm(uid, fileName, fileSize);
                }
            }
            if (message.Substring(0, 2) == "FA")//代表是文件传输回复
            {
                switch (message.Substring(2))
                {
                    case "Accept"://接受文件
                        FormMain.formMain.TimerPercent();
                        FormMain.formMain.backgroundWorkerFileSender.RunWorkerAsync();
                        //FormMain.formMain.StartFileSend();
                        break;
                    case "RefuseByUser"://对方拒绝
                        FormMain.formMain.RefuseRemind();
                        break;
                    case "RefuseByLock"://自动拒绝
                        FormMain.formMain.BusyRemind();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
