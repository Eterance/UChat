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
        /// 这是一个声明的 formmain 对象，在本窗口的构造函数中已经将它与本窗口联系在一起。
        /// </summary>
        public static FormMain formMain;
        /// <summary>
        /// formmain 的构造函数。
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            formMain = this;//把这两个东西联系起来。
            ThreadsList = new List<Thread>(); //初始化线程列表


            //启用双缓冲，减少窗口控件闪烁
            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
        }

        /*TCPFileTransfer.FileReceiver fileReceiver = new TCPFileTransfer.FileReceiver();
        TCPFileTransfer.FileSender fileSender = new TCPFileTransfer.FileSender();*/
        TCPFileTransfer.TaskCompletionStatus FTRResult;

        private string RecePath = "";
        /// <summary> 
        /// 一个集合了本程序所有线程的队列，便于程序关闭时结束所有线程。
        /// </summary> 
        /// <returns></returns> 
        private List<Thread> ThreadsList;
        /// <summary>
        /// 一个保存局域网活动主机的表格。表头为 UID - Name - IP。
        /// </summary>
        public static DataTable LANtable = new DataTable();
        /// <summary>
        /// 初始化 LAN 表。
        /// </summary>
        private void InitLANTable()
        {
            LANtable.Columns.Add("UID", typeof(string));
            LANtable.Columns.Add("Name", typeof(string));
            LANtable.Columns.Add("IP", typeof(string));
            //LANtable.Columns.Add("IsFriend", typeof(bool));
            //设置主键
            DataColumn[] primaryColumns = new DataColumn[1];
            primaryColumns[0] = LANtable.Columns["UID"];
            LANtable.PrimaryKey = primaryColumns;
            //为 LANtable 绑定事件，当发生改变时更新好友列表
            LANtable.RowDeleted += new DataRowChangeEventHandler(LANtableRowChanged);
            LANtable.RowChanged += new DataRowChangeEventHandler(LANtableRowChanged);
        }
        /// <summary>
        /// 修改 LAN 表。
        /// </summary>
        public void UpdateLANTable(string uid, string name, string ip, string status)
        {
            if (status == "UP")//状态字是上线
            {
                if (IsUIDExist(uid) == false)//表里没有这条佬，加进去
                {
                    DataRow dataRow = LANtable.NewRow();
                    dataRow["UID"] = uid;
                    dataRow["Name"] = name;
                    dataRow["IP"] = ip;
                    LANtable.Rows.Add(dataRow);
                }
            }
            else//下线
            {
                //删掉下线那只佬
                DeleteUID(uid);
                LockInput(uid);
            }
        }
        /// <summary>
        /// 遍历查找指定 UID 是否存在。
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        private bool IsUIDExist(string uid)
        {
            foreach (DataRow dataRow in LANtable.Rows)
            {
                if (dataRow[0].ToString() == uid)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 遍历查找指定 UID 的对应 IP。
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public string UIDtoIP(string uid)
        {
            foreach (DataRow dataRow in LANtable.Rows)
            {
                if (dataRow[0].ToString() == uid)
                {
                    return dataRow[2].ToString();//返回IP
                }
            }
            return "";
        }

        /// <summary>
        /// 删除指定 UID 所在的表格行。
        /// </summary>
        /// <param name="uid"></param>
        private void DeleteUID(string uid)
        {
            int count = LANtable.Rows.Count;
            for (int i = count - 1; i >= 0; i--)//使用倒序检索并删除
            {
                if (LANtable.Rows[i][0].ToString() == uid)
                {
                    LANtable.Rows.RemoveAt(i);
                    break;
                }
            }
        }
        /// <summary>
        /// 检测下线的人是不是正在聊天的人。如果是，锁定输入。
        /// </summary>
        /// <param name="uid"></param>
        private void LockInput(string uid)
        {
            if (uid == CommonFoundations.RemoteUID)
            {
                ForbidInput(true);
                CommonFoundations.RemoteIP = "";
                CommonFoundations.RemoteName = "";
                CommonFoundations.RemoteUID = "";
            }
        }
        /// <summary>
        /// 当 LANTable 被更改后，需要调用此事件处理以更新局域网列表。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void LANtableRowChanged(object sender, DataRowChangeEventArgs e)
        {
            formMain.UpdateLANList();
        }

        /// <summary>
        /// 根据 LANtable 的内容更新局域网列表。支持跨线程。
        /// </summary>
        private void UpdateLANList()
        {
            if (panelEmpty.InvokeRequired == false)
            {
                ClearFriendList();
                int count = LANtable.Rows.Count;
                if (count == 0)//表格数为0，就是没人上线
                {
                    panelEmpty.Visible = true;//显示空图标
                }
                else//有人上线
                {
                    panelEmpty.Visible = false;
                    panels = new Panel[count];
                    for (int i = 0; i < count; i++)
                    {
                        CreatePanels(ref panels[i], LANtable.Rows[i][0].ToString(), LANtable.Rows[i][1].ToString(), i);//重新生成列表
                        SetDouble(panels[i]);//设置双缓冲
                    }
                }
            }
            else
            {
                Action dG_NoParaAndNoReturn = new Action(UpdateLANList);
                panelEmpty.Invoke(dG_NoParaAndNoReturn);
            }
        }

        /// <summary>
        /// 清空局域网列表。支持跨线程。
        /// </summary>
        /// <param name="panel"></param>
        private void ClearFriendList()
        {
            if (formMain.panelEmpty.InvokeRequired == false)
            {
                //panelFriendsBar 清空前需要解绑 panelEmpty，不然会一起清掉
                panelEmpty.Parent = this;
                panelLANBar.Controls.Clear();
                panelEmpty.Parent = panelLANBar;
            }
            else
            {
                Action dG_NoParaAndNoReturn = new Action(ClearFriendList);
                panelEmpty.Invoke(dG_NoParaAndNoReturn);
            }
        }
        /// <summary>
        /// 点击任务栏实现最小化与还原。
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_MINIMIZEBOX = 0x00020000;
                CreateParams cp = base.CreateParams;
                cp.Style = cp.Style | WS_MINIMIZEBOX;   // 允许最小化操作                  
                return cp;
            }
        }
        
        /// <summary>
        /// 为每个控件提供双缓冲，防止画面撕裂和闪烁。
        /// </summary>
        /// <param name="cc"></param>
        public static void SetDouble(Control cc)
        {
            cc.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(cc, true, null);
        }

        // public static Color defaultColor = Color.Transparent;
        public static Color enterColor = Color.FromArgb(100, 100, 100);//好友列表鼠标进入的颜色
        public static Color downColor = Color.FromArgb(65, 65, 65);//好友列表鼠标按下的颜色
        /// <summary>
        /// 其中每个 panel 的名字应该以 panel + UID 作为命名。
        /// </summary>
        public static Panel[] panels;
        

        /// <summary>
        /// 为窗口的所有控件实现双缓冲。
        /// </summary>
        private void ControlsDoubleBuffered()
        {
            SetDouble(this);
            #region
            SetDouble(buttonDetail);
            SetDouble(buttonMenu);
            SetDouble(buttonLAN);
            SetDouble(buttonSetting);
            SetDouble(buttonExit2);
            SetDouble(buttonMin);
            SetDouble(buttonFiles);
            SetDouble(buttonSendM);
            SetDouble(buttonScrollToTheBottom);
            SetDouble(buttonSelectFile);
            SetDouble(buttonRefuse);
            SetDouble(buttonAcceptFTR);
            SetDouble(buttonCancelFTR);
            SetDouble(buttonConfirmChange);
            SetDouble(buttonCancelChange);
            SetDouble(buttonChangeName);
            SetDouble(buttonChangePW);
            SetDouble(buttonClearData);
            SetDouble(buttonCancelChangePW);
            SetDouble(buttonSavePW);
            SetDouble(buttonEnableQSI);

            SetDouble(labelEmptyText);
            SetDouble(label4);
            SetDouble(label5);
            SetDouble(label3);
            SetDouble(label6);
            SetDouble(labelAlert);
            SetDouble(labelForbid);
            SetDouble(labelNameIndicator);
            SetDouble(label6);
            SetDouble(labelWaiting);
            SetDouble(labelPercent);
            SetDouble(label8);
            SetDouble(label9);
            SetDouble(label10);
            SetDouble(label12);
            SetDouble(label11);
            SetDouble(label13);
            SetDouble(label14);
            SetDouble(label15);
            SetDouble(label16);
            SetDouble(label17);
            SetDouble(label18);
            SetDouble(label19);
            SetDouble(label20);
            SetDouble(labelError);
            SetDouble(label21);
            SetDouble(label22);
            SetDouble(labelSpeed);
            SetDouble(labelProgress);

            SetDouble(panel2);
            SetDouble(panelLANBar);
            SetDouble(panelSideBar);
            SetDouble(panelTips);
            SetDouble(panelConfirm);
            SetDouble(panelPercent);
            SetDouble(panelSetting);
            SetDouble(panelChangeName);
            SetDouble(panelInfo);
            SetDouble(panelLANBarTitle);
            SetDouble(panelChangePW);

            SetDouble(pictureBoxTips);
            SetDouble(pictureBoxEmptyIcon);

            SetDouble(progressBar1);

            SetDouble(richTextBoxChat);

            SetDouble(textBoxUID);
            SetDouble(textBoxIP);
            SetDouble(textBoxName);
            SetDouble(textBoxInput);
            SetDouble(textBoxChangeName);
            SetDouble(textBoxInfoUID);
            SetDouble(textBoxInfoIP);
            SetDouble(textBoxInfoName);
            SetDouble(textBoxNewPW);
            SetDouble(textBoxOldPW);
            SetDouble(textBoxNewPWRepeat);
            #endregion
        }

        //无边框拖动
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        //————————End——————————

        private void FormMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        /// <summary>
        /// 文件传输线程
        /// </summary>
        public Thread TCPFileSendThread;

        private void FormMain_Load(object sender, EventArgs e)
        {
            ///UDP监听线程
            UDP uDP = new UDP();
            Thread UDPListenThread = new Thread(uDP.UDPMessageListener);//UDP监听线程
            //UDPListenThread.IsBackground = true;
            ThreadsList.Add(UDPListenThread); //将新建的线程加入到线程队列中，以便在窗体结束时关闭所有的线程
            UDPListenThread.Start();
            //TCP消息监听线程
            TCP tCP = new TCP();
            Thread TCPMessageListenThread = new Thread(tCP.TCPMessageListener);
            /*{
                IsBackground = true
            };//TCP监听线程*/
            ThreadsList.Add(TCPMessageListenThread); //将新建的线程加入到线程队列中，以便在窗体结束时关闭所有的线程
            TCPMessageListenThread.Start();

            InitLANTable();//初始化局域网表格

            uDP.OnlineMessageSend(IPAddress.Broadcast, ReplyStatus.NeedReply, OnlineStatus.Online);//上线广播
            IamYourFather();
            ControlsDoubleBuffered();
            MouseDownDragMove();

            buttonSendM.Enabled = false;
            textBoxInfoUID.Text = CommonFoundations.HostUID;
            textBoxInfoIP.Text = HostInfo.IPv4Address.ToString();
            textBoxInfoName.Text = CommonFoundations.HostName;
            panelLANBar.BringToFront();
            panelLANBarTitle.BringToFront();
            panelSideBar.BringToFront();

            if (File.Exists(CommonFoundations.QuickSignIn_Path) == true)//快捷登录文件存在
            {
                buttonEnableQSI.BackColor = CommonFoundations.MainBlue;
            }
            else
            {
                buttonEnableQSI.BackColor = CommonFoundations.DarkBlue;
            }
        }

        /// <summary> 
        /// 你们的爸爸是我！(～o￣3￣)～（大雾）
        /// </summary> 
        /// <returns></returns> 
        private void IamYourFather()
        {
            //panel1.Parent = labelSideBarBG;
            //buttonMenuExpand.Parent = buttonMenu;
        }

       
        /// <summary>
        /// 暂时缓存当前聊天对象的信息，同时在个人信息框显示对面的个人信息
        /// </summary>
        private void SaveTemp(string uid)
        {
            foreach (DataRow dataRow in LANtable.Rows)
            {
                if (dataRow[0].ToString() == uid)
                {
                    CommonFoundations.RemoteUID = uid;
                    CommonFoundations.RemoteName = dataRow[1].ToString();
                    CommonFoundations.RemoteIP = dataRow[2].ToString();

                    formMain.textBoxUID.Text = uid;
                    formMain.textBoxName.Text = dataRow[1].ToString();
                    formMain.textBoxIP.Text = dataRow[2].ToString();
                    break;
                }
            }
        }

        /// <summary>
        /// 处理本机发送的消息。
        /// </summary>
        private void HandleMyMessage(string message)
        {
            //向聊天框中追加文本，并记录文本的起始位置
            int countBefore = richTextBoxChat.TextLength;
            richTextBoxChat.AppendText("我     " + DateTime.Now.ToLocalTime().ToString() + "\n");
            richTextBoxChat.AppendText(message + "\n");
            richTextBoxChat.AppendText("\n");
            int countAfter = richTextBoxChat.TextLength;

            //更改文本的颜色和右对齐
            richTextBoxChat.Select(countBefore, countAfter - countBefore);
            richTextBoxChat.SelectionAlignment = HorizontalAlignment.Right;
            richTextBoxChat.SelectionColor = CommonFoundations.MyTextColor;
            richTextBoxChat.Select(0, 0);
            ScrollToTheBottom();//滚到底部

            ///TCP发送聊天信息格式：我方17位UID + 要发送的消息
            string carrier = CommonFoundations.HostUID + message;
            TCP tCP = new TCP();
            tCP.TCPMessageSender(CommonFoundations.RemoteIP, carrier, 50012);//将消息通过TCP发送到对方

            richTextBoxChat.SaveFile(CommonFoundations.history_Path_Slash + CommonFoundations.RemoteUID + "/" + "history.uch");//保存聊天文件
        }
        /// <summary>
        /// 代理HandleYouMessage()。
        /// </summary>
        /// <param name="status"></param>
        private delegate void DG_HandleYouMessage(string message);
        /// <summary>
        /// 处理正在聊天的对面发送的消息。支持跨线程调用。
        /// </summary>
        public void HandleYouMessage(string message)
        {
            if (formMain.richTextBoxChat.InvokeRequired == false)//判断和窗口主线程是否是同一线程，是就正常用，否则需要代理
            {
                //向聊天框中追加文本，并记录文本的起始位置
                int countBefore = richTextBoxChat.TextLength;
                richTextBoxChat.AppendText(CommonFoundations.RemoteName + "     " + DateTime.Now.ToLocalTime().ToString() + "\n");
                richTextBoxChat.AppendText(message + "\n");
                richTextBoxChat.AppendText("\n");
                int countAfter = richTextBoxChat.TextLength;

                richTextBoxChat.Select(countBefore, countAfter - countBefore);
                richTextBoxChat.SelectionAlignment = HorizontalAlignment.Left;
                richTextBoxChat.SelectionColor = CommonFoundations.YourTextColor;
                richTextBoxChat.Select(0, 0);

                richTextBoxChat.SelectionStart = richTextBoxChat.TextLength; ;
                richTextBoxChat.ScrollToCaret();
                richTextBoxChat.Select(0, 0);
                ScrollToTheBottom();

                richTextBoxChat.SaveFile(CommonFoundations.history_Path_Slash + CommonFoundations.RemoteUID + "/" + "history.uch");//保存聊天文件
            }
            else//跨线程调用窗口控件需要invoke
            {
                DG_HandleYouMessage dG_HandleYouMessage = new DG_HandleYouMessage(HandleYouMessage);
                formMain.richTextBoxChat.Invoke(dG_HandleYouMessage, message);
            }
        }
        /// <summary>
        /// 向聊天框追加未读消息。
        /// </summary>
        /// <param name="date"></param>
        /// <param name="message"></param>
        private void AddUnreadMessage(string date, string message)
        {
            //向聊天框中追加文本，并记录文本的起始位置
            int countBefore = richTextBoxChat.TextLength;
            richTextBoxChat.AppendText(CommonFoundations.RemoteName + "     " + date + "\n");
            richTextBoxChat.AppendText(message + "\n");
            richTextBoxChat.AppendText("\n");
            int countAfter = richTextBoxChat.TextLength;

            richTextBoxChat.Select(countBefore, countAfter - countBefore);
            richTextBoxChat.SelectionAlignment = HorizontalAlignment.Left;
            richTextBoxChat.SelectionColor = CommonFoundations.YourTextColor;
            richTextBoxChat.Select(0, 0);

            richTextBoxChat.SelectionStart = richTextBoxChat.TextLength; ;
            richTextBoxChat.ScrollToCaret();
            richTextBoxChat.Select(0, 0);
            ScrollToTheBottom();

            richTextBoxChat.SaveFile(CommonFoundations.history_Path_Slash + CommonFoundations.RemoteUID + "/" + "history.uch");//保存聊天文件
        }

        /// <summary>
        /// 把聊天框滚到底部。
        /// </summary>
        private void ScrollToTheBottom()
        {
            richTextBoxChat.SelectionStart = richTextBoxChat.TextLength;
            richTextBoxChat.ScrollToCaret();
        }

        /// <summary>
        /// 加载聊天历史记录。
        /// </summary>
        private void LoadHistory()
        {
            string chatHistoryFilePath = CommonFoundations.history_Path_Slash + CommonFoundations.RemoteUID + "/" + "history.uch";
            if (File.Exists(chatHistoryFilePath) == true)//检查有没有历史记录，有就直接加载
            {
                richTextBoxChat.LoadFile(chatHistoryFilePath);
                ScrollToTheBottom();
            }
            else
            {
                Directory.CreateDirectory(CommonFoundations.history_Path_Slash + CommonFoundations.RemoteUID);
            }
        }

        /// <summary>
        /// 读取未读消息。
        /// </summary>
        /// <param name="message"></param>
        public void ReadUnread(string uid)
        {
            //定义那个人的未读消息文件路径
            string xmlFilePath = CommonFoundations.history_Path_Slash + uid + "/unread.xml";
            if (File.Exists(xmlFilePath) == true)//文件存在，直接打开，不存在就不管
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(xmlFilePath);//读取xml为表格
                int count = dataSet.Tables[0].Rows.Count;//获得未读消息总条数
                for (int i = 0; i < count; i++)
                {
                    AddUnreadMessage(dataSet.Tables[0].Rows[i][0].ToString(), dataSet.Tables[0].Rows[i][1].ToString());//逐条添加未读消息到框里
                }
                File.Delete(xmlFilePath);//卸磨杀驴，删掉未读消息文件
            }
        }

        /// <summary>
        /// 把未读消息写入某人的xml中。
        /// </summary>
        /// <param name="message"></param>
        public void WriteUnread(string uid, string message)
        {
            Directory.CreateDirectory(CommonFoundations.history_Path_Slash + uid);
            //定义那个人的未读消息文件路径
            string xmlFilePath = CommonFoundations.history_Path_Slash + uid + "/unread.xml";
            XmlDocument doc = new XmlDocument();
            XmlElement root;

            ///未读消息结构：
            ///<history>
            ///     <subHistory>
            ///             <time></time>
            ///             <message></message>
            ///      </subHistory>    
            ///      <subHistory>
            ///             <time></time>
            ///             <message></message>
            ///      </subHistory>  
            ///</history>

            if (File.Exists(xmlFilePath) == true)//文件存在，直接打开
            {
                doc.Load(xmlFilePath);
                root = doc.DocumentElement;//获得文件的根节点
            }
            else//不存在，新建一个
            {
                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);//创建第一行
                doc.AppendChild(dec);
                root = doc.CreateElement("history");//创建根节点
                doc.AppendChild(root);
            }

            XmlElement subHistory = doc.CreateElement("subHistory");//给根节点Books创建子节点            
            root.AppendChild(subHistory);//将book添加到根节点

            //给Book1添加子节点
            //时间
            XmlElement time = doc.CreateElement("time");
            time.InnerText = DateTime.Now.ToLocalTime().ToString();
            subHistory.AppendChild(time);
            //内容
            XmlElement text = doc.CreateElement("message");
            text.InnerText = message;
            subHistory.AppendChild(text);

            //todo：文件路径不存在
            doc.Save(xmlFilePath); //保存
            SwitchLabelUnreadVisble(uid, true);//提示未读消息
        }
        /// <summary>
        /// 改变未读消息提示是否可见。
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="visible">是否可见？</param>
        private void SwitchLabelUnreadVisble(string uid, bool visible)
        {
            foreach (Panel panel in panels)
            {
                if (panel.Name == "panel" + uid)//找到需要的panel
                {
                    foreach (Control control in panel.Controls)//找未读消息提示条
                    {
                        if (control.Name == "labelUnread")
                        {
                            control.Visible = visible;//显示它
                            break;
                        }
                    }
                    break;
                }
            }
        }

        private delegate void DG_ForbidInput(bool isForbid);
        /// <summary>
        /// 当正在聊天的对象突然下线时，调用此方法拒绝用户继续输入，以防触发 tcp 异常。支持跨线程。
        /// </summary>
        /// <param name="isForbid">true 为禁用。</param>
        private void ForbidInput(bool isForbid)
        {
            if (panelTips.InvokeRequired == false)
            {
                if (isForbid == true)
                {
                    pictureBoxTips.BackgroundImage = Properties.Resources.下线;
                    labelNameIndicator.Text = "";
                    panelTips.BringToFront();
                    labelForbid.Visible = true;
                    buttonSendM.Enabled = false;
                    //隐藏文件传输和详细信息按钮
                    formMain.buttonFiles.Visible = false;
                    formMain.buttonDetail.Visible = false;
                    //关闭文件传输界面，返回局域网界面
                    ResetSendFileBarUI(false);
                    panelLANBar.BringToFront();
                    panelLANBarTitle.BringToFront();
                    panelSideBar.BringToFront();
                    buttonLAN.BackColor = CommonFoundations.MainBlue;
                    buttonFiles.BackColor = Color.Transparent;
                }
                else
                {
                    panelTips.SendToBack();
                    buttonSendM.Enabled = true;
                }
            }
            else
            {
                DG_ForbidInput dG_ForbidInput = new DG_ForbidInput(ForbidInput);
                panelTips.Invoke(dG_ForbidInput, isForbid);
            }
        }
        /// <summary>
        /// 获取文件的大小。会根据大小自动添加合适的单位。
        /// </summary>
        /// <param name="filePath">文件的路径</param>
        /// <returns></returns>
        private string FileSize(string filePath)
        {
            double b = 1, kb = 1024 * b, mb = 1024 * kb, gb = 1024 * mb;//这里非常不严谨地用了小b
            FileInfo fileInfo = new FileInfo(filePath);
            double size = 0;
            string size2 = "";
            size = fileInfo.Length;
            if (size > 1 && size <= 0.9 * kb)//小于900b单位为b
            {
                size2 = size.ToString("#0.00") + " B";
            }
            if (size > 0.9 * kb && size <= 0.9 * mb)//小于900kb单位为kb
            {
                size /= kb;
                size2 = size.ToString("#0.00") + " KB";
            }
            if (size > 0.9 * mb && size <= 0.9 * gb)//小于900mb单位为mb
            {
                size /= mb;
                size2 = size.ToString("#0.00") + " MB";
            }
            else//大于900mb均为GB
            {
                size /= gb;
                size2 = size.ToString("#0.00") + " GB";
            }
            return size2;
        }

        /// <summary>
        /// 获取文件的大小。会根据大小自动添加合适的单位。
        /// </summary>
        /// <param name="fileLength">文件的长度（以字节为单位）</param>
        /// <returns></returns>
        public string FileSize(long fileLength)
        {
            double b = 1, kb = 1000 * b, mb = 1000 * kb, gb = 1000 * mb;//这里非常不严谨地用了小b
            double size = fileLength;
            string size2 = "";
            if (size > 1 && size <= 0.9 * kb)//小于900b单位为b
            {
                size2 = size.ToString("#0.00") + " B";
                return size2;
            }
            if (size > 0.9 * kb && size <= 0.9 * mb)//小于900kb单位为kb
            {
                size /= kb;
                size2 = size.ToString("#0.00") + " KB";
                return size2;
            }
            if (size > 0.9 * mb && size <= 0.9 * gb)//小于900mb单位为mb
            {
                size /= mb;
                size2 = size.ToString("#0.00") + " MB";
                return size2;
            }
            else//大于900mb均为GB
            {
                size /= gb;
                size2 = size.ToString("#0.00") + " GB";
                return size2;
            }
        }


        /// <summary>
        /// 显示是否接受文件传输请求界面。支持跨线程。
        /// </summary>
        public void ShowFileTransferConfirm(string uid, string fileName, string fileSize)
        {
            if (labelWaiting.InvokeRequired == false)
            {
                ClickFileButton();
                timerFTTimeout.Enabled = true;
                timerFTTimeout.Start();//超时计时器开始计时

                string name = "";
                //缓存文件信息
                CommonFoundations.FileTransferTempData.FileFullName = fileName;
                CommonFoundations.FileTransferTempData.FileLengthBytes = long.Parse(fileSize);

                for (int i = 0; i < LANtable.Rows.Count; i++)//在局域网在线表寻找 uid 对应的 name 和 ip
                {
                    if (LANtable.Rows[i][0].ToString() == uid)
                    {
                        name = LANtable.Rows[i][1].ToString();
                        CommonFoundations.FileTransferTempData.FRSourceIP = LANtable.Rows[i][2].ToString();//缓存对面IP
                        break;
                    }
                }
                string filesize2 = FileSize(long.Parse(fileSize));
                this.BackColor = Color.FromArgb(255, 128, 0);
                labelWaiting.Text = name + "想要发送\r\n\r\n" + fileName + "\r\n文件大小：" + filesize2 + "\r\n\r\n你想接受这个文件吗？";
                labelWaiting.Visible = true;
                panelConfirm.Visible = true;
                buttonSelectFile.Visible = false;
                labelTarget.Visible = false;
                label6.Visible = false;
            }
            else
            {
                Action<string,string,string> dG_ShowFileTransferConfirm = new Action<string, string, string>(ShowFileTransferConfirm);
                labelWaiting.Invoke(dG_ShowFileTransferConfirm, uid, fileName, fileSize);
            }
        }

        /// <summary>
        /// 刷新文件传输界面至初始状态。
        /// </summary>
        /// <param name="isBringToFront">若为 true ，更新时把界面置顶。</param>
        private void ResetSendFileBarUI(bool isBringToFront)
        {
            if (label6.InvokeRequired == false)
            {
                progressBar1.Value = 0;

                label6.Visible = true;
                labelTarget.Visible = true;
                buttonSelectFile.Visible = true;

                labelWaiting.Visible = false;
                panelConfirm.Visible = false;
                buttonRefuse.Text = "拒绝(180)";
                panelPercent.Visible = false;
                if (isBringToFront == true)
                {
                    panelFileBar.BringToFront();
                    panelSideBar.BringToFront();
                    buttonFiles.BackColor = CommonFoundations.MainBlue;
                    buttonLAN.BackColor = Color.Transparent;
                }
                else
                {
                    /*
                    panelFileBar.SendToBack();
                    //还原到局域网列表
                    panelLANBar.BringToFront();
                    panelSideBar.BringToFront();
                    buttonLAN.BackColor = CommonFoundations.MainBlue;
                    buttonFiles.BackColor = Color.Transparent;*/
                }
                labelTarget.Text = CommonFoundations.RemoteName;
            }
            else
            {
                Action<bool> dG_OneParaAndNoReturn = new Action<bool>(ResetSendFileBarUI);
                label6.Invoke(dG_OneParaAndNoReturn);
            }
        }

        /// <summary>
        /// 提示文件传输的对方占线，导致无法传输。支持跨线程。
        /// </summary>
        public void BusyRemind()
        {
            if (labelWaiting.InvokeRequired == false)
            {
                /*
                panelNoticeYellow.Visible = true;
                panelNoticeYellow.BringToFront();
                labelNoticeYellow.Text = "对方正处于另一个文件传输进程，请稍后重试。";*/
                NotificationSystem notificationSystem = new NotificationSystem();
                notificationSystem.PushNotification("错误", "对方正处于另一个文件传输进程，请稍后重试。", NotificationSystem.PresetColors.WarningRed);
                CommonFoundations.FileTransferTempData.ResetFTRTempData();
                ResetSendFileBarUI(true);
                this.BackColor = Color.FromArgb(0, 125, 236);
            }
            else
            {
                Action dG_NoParaAndNoReturn = new Action(BusyRemind);
                labelWaiting.Invoke(dG_NoParaAndNoReturn);
            }
        }

        /// <summary>
        /// 提示文件传输的对方拒主动绝，导致无法传输。支持跨线程。
        /// </summary>
        public void RefuseRemind()
        {
            if (labelWaiting.InvokeRequired == false)
            {
                /*
                panelNoticeYellow.Visible = true;
                panelNoticeYellow.BringToFront();
                labelNoticeYellow.Text = "对方拒绝了你的文件传输请求。";*/
                NotificationSystem notificationSystem = new NotificationSystem();
                notificationSystem.PushNotification("注意", "对方拒绝了你的文件传输请求。", NotificationSystem.PresetColors.AttentionYellow);
                CommonFoundations.FileTransferTempData.ResetFTRTempData();
                ResetSendFileBarUI(false);
                this.BackColor = Color.FromArgb(0, 125, 236);
            }
            else
            {
                Action dG_NoParaAndNoReturn = new Action(RefuseRemind);
                labelWaiting.Invoke(dG_NoParaAndNoReturn);
            }
        }

        private void ClickFileButton()
        {
            if (CommonFoundations.FileTransferTempData.FlieTransferAcceptLock == false)//文件锁没开，更新ui
            {
                ResetSendFileBarUI(true);
            }
            else
            {
                //todo
            }
            panelFileBar.BringToFront();
            panelSideBar.BringToFront();
            buttonFiles.BackColor = CommonFoundations.MainBlue;
            buttonLAN.BackColor = Color.Transparent;
            buttonSetting.BackColor = Color.Transparent;
        }

        /// <summary>
        /// 退出程序。
        /// </summary>
        private void ExitProgram()
        {
            if (CommonFoundations.FileTransferTempData.FlieTransferAcceptLock == true)//文件传输时，不允许退出
            {
                /*panelNoticeRed.BringToFront();
                panelNoticeRed.Visible = true;
                labelNoticeRed.Text = "在文件传输时无法退出程序。若仍要退出，请取消文件传输任务后再尝试退出程序。";*/
                NotificationSystem notificationSystem = new NotificationSystem();
                notificationSystem.PushNotification("警告", "在文件传输时无法退出程序。若仍要退出，请取消文件传输任务后再尝试退出程序。", NotificationSystem.PresetColors.WarningRed);
            }
            else
            {
                UDP uDP = new UDP();
                uDP.OnlineMessageSend(IPAddress.Broadcast, ReplyStatus.NoReplyRequired, OnlineStatus.Offline);
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// 提示用户文件传输完成，并完成收尾工作。
        /// </summary>
        private void FTROverProcessor()
        {
            if (panelLANBar.InvokeRequired == false)
            {
                timerPercent.Stop();
                timerPercent.Enabled = false;

                /*panelNoticeBlue.Visible = true;
                panelNoticeBlue.BringToFront();*/
                //做清理工作
                CommonFoundations.FileTransferTempData.ResetFTRTempData();
                ResetSendFileBarUI(false);
                if (buttonFiles.Visible == false)
                {
                    panelLANBar.BringToFront();
                    panelLANBarTitle.BringToFront();
                    panelSideBar.BringToFront();
                    buttonFiles.BackColor = CommonFoundations.MainBlue;
                    buttonLAN.BackColor = Color.Transparent;
                }
            }
            else
            {
                Action action = new Action(FTROverProcessor);
                panelLANBar.Invoke(action);
            }
        }

        /// <summary>
        /// 把秒数转换为格式化的字符串。自动加上时间单位。
        /// </summary>
        /// <param name="sec">总秒数</param>
        /// <returns></returns>
        private string SecToString(long sec)
        {
            if (sec<=60)//小于1分钟
            {
                return sec.ToString() + " 秒";
            }
            else
            {
                long min = sec / 60;
                long sec2 = sec % 60;
                return min.ToString() + " 分钟 " + sec2.ToString() + " 秒";
            }
        }

        /// <summary>
        /// 使鼠标在控件上按下鼠标能拖动窗体的方法。
        /// </summary>
        #region
        private void MouseDownDragMove()
        {
            label9.MouseDown += new MouseEventHandler(Controls_MouseDown);
            label10.MouseDown += new MouseEventHandler(Controls_MouseDown);
            label11.MouseDown += new MouseEventHandler(Controls_MouseDown);
            label12.MouseDown += new MouseEventHandler(Controls_MouseDown);
            label13.MouseDown += new MouseEventHandler(Controls_MouseDown);
            label8.MouseDown += new MouseEventHandler(Controls_MouseDown);
            label14.MouseDown += new MouseEventHandler(Controls_MouseDown);
            label15.MouseDown += new MouseEventHandler(Controls_MouseDown);
            panelInfo.MouseDown += new MouseEventHandler(Controls_MouseDown);
            panelChangeName.MouseDown += new MouseEventHandler(Controls_MouseDown);
            panelLANBar.MouseDown += new MouseEventHandler(Controls_MouseDown);
            panelFileBar.MouseDown += new MouseEventHandler(Controls_MouseDown);
            panelSetting.MouseDown += new MouseEventHandler(Controls_MouseDown);
            panelLANBarTitle.MouseDown += new MouseEventHandler(Controls_MouseDown);
            pictureBoxEmptyIcon.MouseDown += new MouseEventHandler(Controls_MouseDown);
            labelEmptyText.MouseDown += new MouseEventHandler(Controls_MouseDown);
            panelEmpty.MouseDown += new MouseEventHandler(Controls_MouseDown);
            label16.MouseDown += new MouseEventHandler(Controls_MouseDown);
            labelWaiting.MouseDown += new MouseEventHandler(Controls_MouseDown);
            panelPercent.MouseDown += new MouseEventHandler(Controls_MouseDown);
            labelPercent.MouseDown += new MouseEventHandler(Controls_MouseDown);
            progressBar1.MouseDown += new MouseEventHandler(Controls_MouseDown);
            panelChangePW.MouseDown += new MouseEventHandler(Controls_MouseDown);
            labelError.MouseDown += new MouseEventHandler(Controls_MouseDown);
            label20.MouseDown += new MouseEventHandler(Controls_MouseDown);
            label19.MouseDown += new MouseEventHandler(Controls_MouseDown);
            label18.MouseDown += new MouseEventHandler(Controls_MouseDown);
            label21.MouseDown += new MouseEventHandler(Controls_MouseDown);
            label22.MouseDown += new MouseEventHandler(Controls_MouseDown);
        }
        #endregion

        //===========================================================================================================
        //                                                                                                                                                                                                              ========================
        //以下是控件的事件处理方法。                                                                                                                                                                    ========================
        //                                                                                                                                                                                                              ========================
        //===========================================================================================================

        /// <summary>
        /// Panel 组 Click 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panels_Click(object sender, EventArgs e)
        {
            if (formMain.buttonFiles.Visible == false)//显示文件传输按钮和个人信息按钮
            {
                formMain.buttonFiles.Visible = true;
                formMain.buttonDetail.Visible = true;
            }
            Panel panel = (Panel)(sender);//获取触发本消息处理的 panel 控件
            foreach (Panel panel1 in panels)
            {
                //panel1.
                //如果找到 panels 组中的某个 panel 名字等于上面 sender 的 panel 名字，那就是它触发了事件
                if (panel1.Name == panel.Name)//找到目标 panel
                {
                    foreach (Control control in panel1.Controls)            //遍历所有控件，直到找到所需要的子控件
                    {
                        if (control.Name == "labelStatus")//把选中条子改成蓝色
                        {
                            control.BackColor = CommonFoundations.MainBlue;
                        }
                        if (control.Name == "labelName")//把名字显示到聊天窗口上去
                        {
                            labelNameIndicator.Text = control.Text;
                        }
                    }
                    ForbidInput(false);//允许输入
                    //缓存对面的个人信息
                    SaveTemp(panel1.Name.Substring(5, 17));
                    //加载聊天历史
                    LoadHistory();
                    //关掉未读消息提示
                    SwitchLabelUnreadVisble(CommonFoundations.RemoteUID, false);
                    //加载未读消息
                    ReadUnread(CommonFoundations.RemoteUID);
                }
                else//找到的不是目标
                {
                    foreach (Control control in panel1.Controls)            //遍历所有控件，直到找到所需要的子控件
                    {
                        if (control.Name == "labelStatus")
                        {
                            control.BackColor = Color.Transparent;           //把它的条子改成透明
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Panel 组 MouseEnter 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panels_MouseEnter(object sender, EventArgs e)
        {
            Panel panel = (Panel)(sender);//获取触发本消息处理的 panel 控件
            foreach (Panel panel1 in panels)
            {
                //如果找到 panels 组中的某个 panel 名字等于上面 sender 的 panel 名字，那就是它触发了事件
                if (panel1.Name == panel.Name)
                {
                    panel1.BackColor = Color.Gray;
                    break;
                }
            }
        }

        /// <summary>
        /// Panel 组 MouseLeave 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panels_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = (Panel)(sender);//获取触发本消息处理的 panel 控件
            foreach (Panel panel1 in panels)
            {
                if (panel1.Name == panel.Name)
                {
                    panel1.BackColor = CommonFoundations.DarkBlue;
                    /*foreach (Control control in panel1)
                    {

                    }
                    break;*/
                }
            }
        }

        private void Labels_MouseEnter(object sender, EventArgs e)
        {
            Label label = (Label)(sender);//获取触发本消息处理的 label 控件
            foreach (Panel panel1 in panels)
            {//遍历 panels, 寻找促发该事件的 label 的父 panel。
                if (panel1.Controls.Contains(label) == true)
                {
                    panel1.BackColor = Color.Gray;
                    break;
                }
            }
        }

        private void Labels_MouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)(sender);//获取触发本消息处理的 label 控件
            foreach (Panel panel1 in panels)
            {
                if (panel1.Controls.Contains(label) == true)
                {
                    panel1.BackColor = CommonFoundations.DarkBlue;
                    break;
                }
            }
        }
        private void Labels_Click(object sender, EventArgs e)
        {
            Label label = (Label)(sender);//获取触发本消息处理的 label 控件
            foreach (Panel panel1 in panels)
            {
                if (panel1.Controls.Contains(label) == true)
                {
                    Panels_Click(panel1, e);
                    break;
                }
            }
        }

        private void ButtonScrollToTheBottom_Click(object sender, EventArgs e)
        {
            ScrollToTheBottom();
        }

        private void ButtonSendM_Click(object sender, EventArgs e)
        {
            if (textBoxInput.Text == "")//输入框为空不允许输入
            {
                labelAlert.Visible = true;
            }
            else
            {
                HandleMyMessage(textBoxInput.Text);
                textBoxInput.Text = "";//清空输入框
            }
        }

        private void TextBoxInput_TextChanged(object sender, EventArgs e)
        {
            labelAlert.Visible = false;
        }

        private void ButtonExit2_Click(object sender, EventArgs e)
        {
            ExitProgram();
        }

        private void LabelNameIndicator_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (panelSideBar.Width == 300)
            {
                timer1.Stop();
                timer1.Enabled = false;
            }
            else
            {
                panelSideBar.Width += 50;
            }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (panelSideBar.Width == 50)
            {
                timer2.Stop();
                timer2.Enabled = false;
            }
            else
            {
                panelSideBar.Width -= 50;
            }
        }

        private void ButtonMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ButtonLAN_Click(object sender, EventArgs e)
        {
            panelLANBar.BringToFront();
            panelLANBarTitle.BringToFront();
            panelSideBar.BringToFront();
            buttonLAN.BackColor = CommonFoundations.MainBlue;
            buttonFiles.BackColor = Color.Transparent;
            buttonSetting.BackColor = Color.Transparent;
            //UpdateLANList();
        }

        private void ButtonFiles_Click(object sender, EventArgs e)
        {
            ClickFileButton();
        }

        private void ButtonDetail_Click(object sender, EventArgs e)
        {
            if (buttonDetail.BackColor == Color.Transparent)
            {
                buttonDetail.BackColor = CommonFoundations.DarkBlue;
                panelDetail.Visible = true;
                if (panelSideBar.Width == 50)
                {
                    timer1.Enabled = true;
                    timer1.Start();
                }
            }
            else
            {
                buttonDetail.BackColor = Color.Transparent;
                panelDetail.Visible = false;
                if (panelSideBar.Width == 300)
                {
                    timer2.Enabled = true;
                    timer2.Start();
                }
            }
        }
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            ExitProgram();
        }

        private void Label2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = CommonFoundations.DarkBlue;
        }

        private void Panel2_MouseEnter(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Gray;
        }

        private void Button4_Click(object sender, EventArgs e)//收缩/扩展边栏
        {
            if (panelSideBar.Width == 50)
            {
                timer1.Enabled = true;
                timer1.Start();
                //panelSideBar.Width = 200;
                //panelSideBar.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                timer2.Enabled = true;
                timer2.Start();
            }
        }

        private void PanelSideBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void PanelTips_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void LabelForbid_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void ButtonSelectFile_Click(object sender, EventArgs e)
        {
            CommonFoundations.FileTransferTempData.FlieTransferAcceptLock = true;//开启锁
            this.BackColor = Color.FromArgb(255, 128, 0);
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//该值确定是否可以选择多个文件
            dialog.Title = "请选择要传输的文件";
            dialog.Filter = "所有文件(*.*)|*.*";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            dialog.DereferenceLinks = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = dialog.FileName;
                string file = dialog.SafeFileName;

                CommonFoundations.FileTransferTempData.FRSourcePath = dialog.FileName;                
                CommonFoundations.FileTransferTempData.FRDestinationIP = CommonFoundations.RemoteIP;
                CommonFoundations.FileTransferTempData.FileFullName = file;

                FileInfo fileInfo = new FileInfo(filePath);
                CommonFoundations.FileTransferTempData.FileLengthBytes = fileInfo.Length;
                //MessageBox.Show(fileInfo.Length.ToString());
                FileTransfer.FileTransferRequestSender(file, fileInfo.Length);
                string fileBytes = FileSize(fileInfo.Length);
                CommonFoundations.FileTransferTempData.FileLengthBytes = fileInfo.Length;

                buttonSelectFile.Visible = false;//取消按钮显示
                labelWaiting.Text = "你将要传输：\r\n\r\n" + file + "\r\n文件大小：" + fileBytes + "\r\n\r\n正在等待对方确认接收文件...";
                labelWaiting.Visible = true;
            }
            else
            {
                CommonFoundations.FileTransferTempData.FlieTransferAcceptLock = false;//关闭锁
                this.BackColor = Color.FromArgb(0, 125, 236);
            }
        }

        private void PanelFileBar_Paint(object sender, PaintEventArgs e)
        {
            Control _Control = (Control)sender;
            ShowScrollBar(_Control.Handle, 0, 0);
        }

        //去掉panel水平条子-------------------------------------------------------------------
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int ShowScrollBar(IntPtr hWnd, int bar, int show);
        //-------------------------------------------------------------------------------------

        private void PanelLANBar_Paint(object sender, PaintEventArgs e)
        {
            Control _Control = (Control)sender;
            ShowScrollBar(_Control.Handle, 0, 0);
        }

        private void ButtonRefuse_Click(object sender, EventArgs e)
        {
            timerFTTimeout.Stop();//超时计时器停止计时
            timerFTTimeout.Enabled = false;
            FileTransfer.FileTransferAnswerSender(AcceptStatus.RefuseByUser,CommonFoundations.FileTransferTempData.FRSourceIP);
            CommonFoundations.FileTransferTempData.ResetFTRTempData();
            ResetSendFileBarUI(false);
            panelFileBar.SendToBack();
            panelLANBar.BringToFront();
            panelLANBarTitle.BringToFront();
            panelSideBar.BringToFront();
            buttonLAN.BackColor = CommonFoundations.MainBlue;
            buttonFiles.BackColor = Color.Transparent;
            this.BackColor = Color.FromArgb(0,125,236);
        }

        private void ButtonAcceptFTR_Click(object sender, EventArgs e)
        {
            timerFTTimeout.Stop();//超时计时器停止计时
            timerFTTimeout.Enabled = false;
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                RootFolder = Environment.SpecialFolder.Desktop,//起始文件夹设为桌面
                Description = "选择文件要保存的位置",
                ShowNewFolderButton = true
            };
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)//用户点了确认
            {
                //folderBrowserDialog.ShowDialog();
                CommonFoundations.FileTransferTempData.FRDestinationFolder = folderBrowserDialog.SelectedPath;//获取用户选定的保存文件夹
                //MessageBox.Show(CommonFoundations.FileTransferTempData.FRDestinationFolder);
                FileTransfer.FileTransferAnswerSender(AcceptStatus.Accept,CommonFoundations.FileTransferTempData.FRSourceIP);//向对方确认接收文件
                panelConfirm.Visible = false;
                panelPercent.Visible = true;
                panelPercent.BringToFront();
                labelWaiting.Text = "正在接受文件\r\n\r\n" + CommonFoundations.FileTransferTempData.FileFullName;
                timerPercent.Enabled = true;
                timerPercent.Start();
                backgroundWorkerFileReceiver.RunWorkerAsync();//开启后台线程，等待 TCP 接受文件
            }
        }

        private void TimerFTTimeout_Tick(object sender, EventArgs e)
        {
            if (CommonFoundations.FileTransferTempData.FTRTimeOut != 0)
            {
                buttonRefuse.Text = "拒绝(" + CommonFoundations.FileTransferTempData.FTRTimeOut.ToString() + ")";
                CommonFoundations.FileTransferTempData.FTRTimeOut -= 1;
            }
            else
            {
                timerFTTimeout.Stop();//超时计时器停止计时
                timerFTTimeout.Enabled = false;
                FileTransfer.FileTransferAnswerSender(AcceptStatus.RefuseByUser,CommonFoundations.FileTransferTempData.FRSourceIP);
                CommonFoundations.FileTransferTempData.ResetFTRTempData();
                this.BackColor = CommonFoundations.MainBlue;
                ResetSendFileBarUI(true);
            }
        }
        private void BackgroundWorkerFileReceiver_DoWork(object sender, DoWorkEventArgs e)
        {
            delayFactor = 0;
            TCPFileTransfer.FileReceiver fileReceiver = new TCPFileTransfer.FileReceiver();
            fileReceiver.SetParameters(
                CommonFoundations.FileTransferTempData.FRDestinationFolder + "/" + CommonFoundations.FileTransferTempData.FileFullName,
                CommonFoundations.FileTransferTempData.FileLengthBytes,
                CommonFoundations.FileTransferTempData.FRSourceIP);
            FTRResult = fileReceiver.Start(ref CommonFoundations.FileTransferTempData.FTRPercentage2);
        }

        private void BackgroundWorkerFileSender_DoWork(object sender, DoWorkEventArgs e)
        {
            delayFactor = 0;
            TCPFileTransfer.FileSender fileSender = new TCPFileTransfer.FileSender();
            fileSender.SetParameters(
                CommonFoundations.FileTransferTempData.FRSourcePath,
                CommonFoundations.FileTransferTempData.FileLengthBytes,
                CommonFoundations.FileTransferTempData.FRDestinationIP);
            FTRResult =  fileSender.Start(ref CommonFoundations.FileTransferTempData.FTRPercentage2);
        }

        public void TimerPercent()
        {
            if (panelPercent.InvokeRequired == false)
            {
                panelPercent.Visible = true;
                panelPercent.BringToFront();
                labelWaiting.Text = "正在发送文件\r\n\r\n" + CommonFoundations.FileTransferTempData.FileFullName;
                timerPercent.Enabled = true;
                timerPercent.Start();
            }
            else
            {
                Action dG_NoParaAndNoReturn = new Action(TimerPercent);
                panelPercent.Invoke(dG_NoParaAndNoReturn);
            }
        }


        private void BackgroundWorkerFileReceiver_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (panelTips.InvokeRequired == false)
            {
                if (FTRResult == TCPFileTransfer.TaskCompletionStatus.OppositeCancel)
                {
                    /*panelNoticeRed.BringToFront();
                    panelNoticeRed.Visible = true;
                    labelNoticeRed.Text = "文件传输被对方取消。";*/
                    NotificationSystem notificationSystem = new NotificationSystem();
                    notificationSystem.PushNotification("注意", "文件传输已被对方取消。", NotificationSystem.PresetColors.AttentionYellow);
                    ResetSendFileBarUI(false);
                    CommonFoundations.FileTransferTempData.ResetFTRTempData();
                }
                else
                {
                    if (FTRResult == TCPFileTransfer.TaskCompletionStatus.HostCancel)
                    {
                        /*labelNoticeYellow.BringToFront();
                        labelNoticeYellow.Visible = true;
                        labelNoticeYellow.Text = "文件传输已经取消。";*/
                        NotificationSystem notificationSystem = new NotificationSystem();
                        notificationSystem.PushNotification("提醒", "文件传输已被取消。", NotificationSystem.PresetColors.TipsBlue);
                        ResetSendFileBarUI(false);
                        CommonFoundations.FileTransferTempData.ResetFTRTempData();
                    }
                    else
                    {
                        NotificationSystem notificationSystem = new NotificationSystem();
                        //MessageBox.Show(CommonFoundations.FileTransferTempData.FRDestinationFolder + @"\" + CommonFoundations.FileTransferTempData.FileFullName);
                        notificationSystem.PushNotification("完成", "文件传输已完成。", NotificationSystem.PresetColors.OKGreen, CommonFoundations.FileTransferTempData.FRDestinationFolder + @"\" + CommonFoundations.FileTransferTempData.FileFullName);
                        //RecePath = CommonFoundations.FileTransferTempData.FRSourcePath;
                        FTROverProcessor();
                    }
                   
                }
                this.BackColor = Color.FromArgb(0, 125, 236);
            }
            else
            {
                Action<object, RunWorkerCompletedEventArgs> dG_BackgroundWorker_RunWorkerCompleted = new Action<object, RunWorkerCompletedEventArgs>(BackgroundWorkerFileReceiver_RunWorkerCompleted);
                panelTips.Invoke(dG_BackgroundWorker_RunWorkerCompleted, sender, e);
            }
        }

        private void BackgroundWorkerFileSender_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (panelTips.InvokeRequired == false)
            {
                if (FTRResult == TCPFileTransfer.TaskCompletionStatus.OppositeCancel)
                {
                    /*panelNoticeRed.BringToFront();
                    panelNoticeRed.Visible = true;
                    labelNoticeRed.Text = "文件传输被对方取消。";*/
                    NotificationSystem notificationSystem = new NotificationSystem();
                    notificationSystem.PushNotification("注意", "文件传输已被对方取消。", NotificationSystem.PresetColors.AttentionYellow);
                    ResetSendFileBarUI(false);
                    CommonFoundations.FileTransferTempData.ResetFTRTempData();
                }
                else
                {
                    if (FTRResult == TCPFileTransfer.TaskCompletionStatus.HostCancel)
                    {
                        /*labelNoticeYellow.BringToFront();
                        labelNoticeYellow.Visible = true;
                        labelNoticeYellow.Text = "文件传输已经取消。";*/
                        NotificationSystem notificationSystem = new NotificationSystem();
                        notificationSystem.PushNotification("提醒", "文件传输已被取消。", NotificationSystem.PresetColors.TipsBlue);
                        ResetSendFileBarUI(false);
                        CommonFoundations.FileTransferTempData.ResetFTRTempData();
                    }
                    else
                    {
                        NotificationSystem notificationSystem = new NotificationSystem();
                        notificationSystem.PushNotification("完成", "文件传输已完成。", NotificationSystem.PresetColors.OKGreen, CommonFoundations.FileTransferTempData.FRSourcePath);
                        //RecePath = CommonFoundations.FileTransferTempData.FRSourcePath;
                        FTROverProcessor();
                    }                    
                }
                this.BackColor = Color.FromArgb(0, 125, 236);
            }
            else
            {
                Action<object, RunWorkerCompletedEventArgs> dG_BackgroundWorker_RunWorkerCompleted = new Action<object, RunWorkerCompletedEventArgs>(BackgroundWorkerFileSender_RunWorkerCompleted);
                panelTips.Invoke(dG_BackgroundWorker_RunWorkerCompleted, sender, e);
            }
        }

        int delayFactor = 0;//时延系数，把 timer 延时
        private void TimerPercent_Tick(object sender, EventArgs e)
        {
            long currentBytes = CommonFoundations.FileTransferTempData.CurrentBlocks * 14000;//当前已经传输的字节数
            string cb = formMain.FileSize(currentBytes);
            long totalBytes = CommonFoundations.FileTransferTempData.TotalBlocks * 14000;//总字节数
            string tb = formMain.FileSize(totalBytes);
            if (delayFactor == 10)
            {
                long sentBytesPerSec = (CommonFoundations.FileTransferTempData.CurrentBlocks - CommonFoundations.FileTransferTempData.PassBlocks) * 14000 * 2;//过去一段时间里发送的速度
                string sb = formMain.FileSize(sentBytesPerSec);
                formMain.labelSpeed.Text = sb + "/s";
                long remainSec = 0;
                try//捕捉除于 0 错误
                {
                    remainSec = ((totalBytes - currentBytes) / sentBytesPerSec) + 1;//剩余时间
                }
                catch 
                {
                }
                formMain.labelRemainTime.Text = "剩余时间约 " + formMain.SecToString(remainSec);
                CommonFoundations.FileTransferTempData.PassBlocks = CommonFoundations.FileTransferTempData.CurrentBlocks;
                delayFactor = 0;
            }
            else
            {
                delayFactor++;
            }
            formMain.progressBar1.Value = CommonFoundations.FileTransferTempData.FTRPercentage2;
            formMain.labelPercent.Text = CommonFoundations.FileTransferTempData.FTRPercentage2.ToString() + "%";
            formMain.labelProgress.Text = cb + " / " + tb;
        }

        private void ButtonCancelFTR_Click(object sender, EventArgs e)
        {
            CommonFoundations.FileTransferTempData.CancelFTR = true;
            try
            {
                /*fileReceiver.Abort();
                fileSender.Abort();*/
                if (buttonFiles.Visible == false)
                {
                    ResetSendFileBarUI(false);
                    panelLANBar.BringToFront();
                    panelLANBarTitle.BringToFront();
                    panelSideBar.BringToFront();
                    buttonLAN.BackColor = CommonFoundations.MainBlue;
                    buttonFiles.BackColor = Color.Transparent;
                }
                else
                {
                    ResetSendFileBarUI(true);
                }
            }
            catch (NullReferenceException ed)
            {
                MessageBox.Show(ed.ToString());
            }
            catch (Exception ed)
            {
                MessageBox.Show(ed.ToString());
            }
        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
            //使用命令行打开资源管理器并定位到文件。
            Process p = new Process();
            p.StartInfo.FileName = "explorer.exe";
            p.StartInfo.Arguments = "/e,/select," + RecePath;//参数 -e 此命令使用默认视图启动 Windows 资源管理器，并把焦点定位在 RecePath。
            p.Start();
        }

        private void ButtonSetting_Click(object sender, EventArgs e)
        {
            panelSetting.BringToFront();
            panelSideBar.BringToFront();
            buttonSetting.BackColor = CommonFoundations.MainBlue;
            buttonLAN.BackColor = Color.Transparent;
            buttonFiles.BackColor = Color.Transparent;
        }

        private void ButtonChangeName_Click(object sender, EventArgs e)
        {
            panelChangeName.Visible = true;
            panelChangeName.BringToFront();
            textBoxChangeName.Text = "";
        }

        private void ButtonConfirmChange_Click(object sender, EventArgs e)
        {
            ///更改保存在xml里面的用户名。
            panelChangeName.Visible = false;

            DataSet userDataTable = new DataSet();
            userDataTable.ReadXml(CommonFoundations.HostUsers_FilePath);//读取本地用户xml存档为表格
            DataRow dataRow = userDataTable.Tables[0].NewRow();
            dataRow["UID"] = userDataTable.Tables[0].Rows[0][2];
            dataRow["password"] = userDataTable.Tables[0].Rows[0][1];
            dataRow["name"] = textBoxChangeName.Text;
            userDataTable.Tables[0].Rows.RemoveAt(0);
            userDataTable.Tables[0].Rows.Add(dataRow);
            userDataTable.WriteXml(CommonFoundations.HostUsers_FilePath);

            NotificationSystem notificationSystem = new NotificationSystem();
            notificationSystem.PushNotification("提醒", "更改用户名成功。新的用户名 " + textBoxChangeName.Text + " 将在重启本程序后生效。", NotificationSystem.PresetColors.TipsBlue);
        }

        private void ButtonCancelChange_Click(object sender, EventArgs e)
        {
            panelChangeName.Visible = false;
        }

        /// <summary>
        /// 拖动窗口方法。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Controls_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void TextBoxChangeName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxChangeName.Text =="")//为空
            {
                buttonConfirmChange.Enabled = false;
            }
            else
            {
                buttonConfirmChange.Enabled = true;
            }
        }

        private void ButtonChangePW_Click(object sender, EventArgs e)
        {
            panelChangePW.Visible = true;
            panelChangePW.BringToFront();
            textBoxOldPW.Text = "";
            textBoxNewPW.Text = "";
            textBoxNewPWRepeat.Text = "";
        }

        private void ButtonCancelChangePW_Click(object sender, EventArgs e)
        {
            panelChangePW.Visible = false;
        }

        private void ButtonSavePW_Click(object sender, EventArgs e)
        {
            DataSet userDataSet = new DataSet();
            userDataSet.ReadXml(CommonFoundations.HostUsers_FilePath);//读取本地用户xml存档为表格
            string oldOne = userDataSet.Tables[0].Rows[0][1].ToString();

            if (textBoxOldPW.Text == oldOne && textBoxNewPW.Text == textBoxNewPWRepeat.Text && textBoxNewPW.Text != "")//旧密码正确，新密码都正确且不为空
            {
                DataRow dataRow = userDataSet.Tables[0].NewRow();
                dataRow["UID"] = userDataSet.Tables[0].Rows[0][2];
                dataRow["password"] = textBoxNewPW.Text;
                dataRow["name"] = userDataSet.Tables[0].Rows[0][0];
                userDataSet.Tables[0].Rows.RemoveAt(0);
                userDataSet.Tables[0].Rows.Add(dataRow);
                userDataSet.WriteXml(CommonFoundations.HostUsers_FilePath);

                labelError.Visible = false;
                panelChangePW.Visible = false;
                NotificationSystem notificationSystem = new NotificationSystem();
                notificationSystem.PushNotification("提醒","更改密码成功。 ", NotificationSystem.PresetColors.TipsBlue);
            }
            else
            {
                labelError.Visible = true;
            }
        }

        private void ButtonEnableQSI_Click(object sender, EventArgs e)
        {
            if (buttonEnableQSI.BackColor == CommonFoundations.DarkBlue)//快捷登录启动
            {
                buttonEnableQSI.BackColor = CommonFoundations.MainBlue;
                //File.Create(CommonFoundations.QuickSignIn_Path);
                FileStream fileStream = new FileStream(CommonFoundations.QuickSignIn_Path, FileMode.Create);
                fileStream.Close();

            }
            else
            {
                buttonEnableQSI.BackColor = CommonFoundations.DarkBlue;
                File.Delete(CommonFoundations.QuickSignIn_Path);
            }
        }

        private void ButtonClearData_Click(object sender, EventArgs e)
        {
            if (CommonFoundations.FileTransferTempData.FlieTransferAcceptLock == true)//文件传输时不允许清空数据
            {
                NotificationSystem notificationSystem = new NotificationSystem();
                notificationSystem.PushNotification("错误", "文件传输时无法清空用户数据。请结束文件传输后再次尝试。", NotificationSystem.PresetColors.WarningRed);
            }
            else
            {
                FormClearData formClearData = new FormClearData();
                formClearData.ShowDialog();
            }
        }

        private void TextBoxNewPWRepeat_TextChanged(object sender, EventArgs e)
        {

        }

        private void LabelError_Click(object sender, EventArgs e)
        {

        }

        private void Label20_Click(object sender, EventArgs e)
        {

        }
    }
    
}
