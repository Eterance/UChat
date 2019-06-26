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
    /// CommonFoundations，存放全局变量的地方。
    /// </summary>
    public static class CommonFoundations
    {
        public static string xml_FilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/UChat/Contact.xml";
        public static string hostUsers_FilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/UChat/HostUsers.xml";
        public static string directory_Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/UChat";
        public static string history_Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/UChat/History";
        /// <summary>
        /// 带多一个斜杠的聊天历史记录路径。
        /// </summary>
        public static string history_Path_Slash = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/UChat/History/";

        public static string HostName = "";
        public static string HostUID = "";

        /// <summary>
        /// 正在聊天的UID。
        /// </summary>
        public static string RemoteUID = "";
        /// <summary>
        /// 正在聊天的名字。
        /// </summary>
        public static string RemoteName = "";
        /// <summary>
        /// 正在聊天的IP。
        /// </summary>
        public static string RemoteIP = "";

        public static bool fileExist = false;
        public static Color MainBlue = Color.FromArgb(0, 125, 236);
        public static Color MainBlack = Color.FromArgb(25, 25, 25);
        public static Color DarkBlue = Color.FromArgb(26, 33, 42);
        public static Color LightGray = Color.FromArgb(81, 83, 85);
        public static Color YourTextColor = MainBlue;
        public static Color MyTextColor = Color.White;


        /// <summary>
        /// 文件传输的缓存变量。
        /// </summary>
        public struct FileTransferTempData
        {
            /// <summary>
            /// 一键重设缓存数据。
            /// </summary>
            public static void ResetFTRTempData()
            {
                FRSourcePath = "";
                FRSourceIP = "";
                FRDestinationFolder = "";
                FRDestinationIP = "";
                FileFullName = "";
                FlieTransferAcceptLock = false;
                FileLengthBytes = 0;
                FTRTimeOut = 179;
                FTRPercentage = 0;
                FTRPercentage2 = 0;
                CancelFTR = false;
            }
            /// <summary>
            /// 发起文件传输请求的文件路径。包括路径，文件名，扩展名。
            /// </summary>
            public static string FRSourcePath = "";
            /// <summary>
            /// 发起文件传输请求的源 IP。
            /// </summary>
            public static string FRSourceIP = "";
            /// <summary>
            /// 文件传输请求的目的文件夹。
            /// </summary>
            public static string FRDestinationFolder = "";
            /// <summary>
            /// 文件传输请求的目的 IP。
            /// </summary>
            public static string FRDestinationIP = "";
            /// <summary>
            /// 文件传输锁，确保同一时刻只能存在一个文件传输进程。当这个值为 true 时，将自动拒绝后续一切文件传输请求。
            /// </summary>
            public static bool FlieTransferAcceptLock = false;
            /// <summary>
            /// 对面想要传输的文件全名，包括扩展名，不是路径。
            /// </summary>
            public static string FileFullName = "";
            /// <summary>
            /// 对面想要传输的文件长度。
            /// </summary>
            public static long FileLengthBytes = 0;
            /// <summary>
            /// 文件传输请求超时计数器。
            /// </summary>
            public static int FTRTimeOut = 179;
            /// <summary>
            /// 文件传输任务的百分比。这是一个小于 1 的浮点数，用于进度条时需要乘以 100.
            /// </summary>
            public static double FTRPercentage = 0;
            /// <summary>
            /// 文件传输任务的百分比。
            /// </summary>
            public static int FTRPercentage2 = 0;
            /// <summary>
            /// 指示是否要中断文件传输进程。
            /// </summary>
            public static bool CancelFTR = false;
        }
    }
}
