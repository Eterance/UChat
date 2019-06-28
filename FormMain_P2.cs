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
    public partial class FormMain : Form
    {

        /// <summary>
        /// 主窗口的通知系统。
        /// </summary>
        public static class NotificationSystem
        {
            /// <summary>
            /// 推送红色（警告）通知。
            /// </summary>
            /// <param name="message">通知内容</param>
            /// <param name="topic">通知标题 </param>
            public static void RedPush(string message, string topic = "警告")
            {
                if (formMain.panelNoticeRed.InvokeRequired == false)
                {
                    Panel panel = new Panel();
                }
                else
                {
                    Action<string, string> action = new Action<string, string>(RedPush);
                    formMain.panelNoticeRed.Invoke(action);
                }
            }
        }
    }
}
