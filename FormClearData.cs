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
    public partial class FormClearData : Form
    {
        public FormClearData()
        {
            InitializeComponent();
        }

        private void ButtonCancelChangePW_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonSavePW_Click(object sender, EventArgs e)
        {
            DataSet userDataSet = new DataSet();
            userDataSet.ReadXml(CommonFoundations.HostUsers_FilePath);//读取本地用户xml存档为表格
            string pW = userDataSet.Tables[0].Rows[0][1].ToString();

            if (textBoxNewPW.Text == pW)//密码正确
            {
                panel1.BringToFront();
                Directory.Delete(CommonFoundations.Directory_Path, true);
                timer1.Enabled = true;
                timer1.Start();
            }
            else
            {
                labelError.Visible = true;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            UDP uDP = new UDP();
            uDP.OnlineMessageSend(IPAddress.Broadcast, ReplyStatus.NoReplyRequired, OnlineStatus.Offline);
            System.Environment.Exit(0);
        }
    }
}
