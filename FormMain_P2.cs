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
        /// 主窗口的通知推送系统。
        /// </summary>
        public class NotificationSystem
        {
            public NotificationSystem()
            {
                //ReceivePath = FilePath;
            }
            /// <summary>
            /// 预设的背景颜色。
            /// </summary>
            public struct PresetColors
            {
                /// <summary>
                /// 警告，红色
                /// </summary>
                readonly public static Color WarningRed = Color.FromArgb(101, 27, 1);
                /// <summary>
                /// 注意，黄色
                /// </summary>
                readonly public static Color AttentionYellow= Color.FromArgb(102, 75, 0);
                /// <summary>
                /// 提示，蓝色
                /// </summary>
                readonly public static Color TipsBlue = Color.FromArgb(0, 43, 77);
                /// <summary>
                /// 标记，紫色
                /// </summary>
                readonly public static Color MarkPurple = Color.FromArgb(56,34,93);
                /// <summary>
                /// 通过，紫色
                /// </summary>
                readonly public static Color OKGreen = Color.FromArgb(8,83,8);
                /// <summary>
                /// 鼠标进入的颜色
                /// </summary>
                readonly internal static Color MouseOverBackColor = Color.FromArgb(100,100,100);
                /// <summary>
                /// 鼠标按下的颜色
                /// </summary>
                readonly internal static Color MouseDownBackColor = Color.FromArgb(90,90,90);
            }
            /// <summary>
            /// 文件的路径。
            /// </summary>
            string filePathMain = "";
            /// <summary>
            /// 通知背景坐标
            /// </summary>
            Point backPanelLocation = new Point(825, 50);
            /// <summary>
            /// 通知大小
            /// </summary>
            Size backPanelSize = new Size(450, 100);

            Point labelTopicLocation = new Point(10,7);
            Size labelTopicSize = new Size(156, 21);

            Point labelMessageLocation = new Point(10, 42);
            Size labelMessageSize = new Size(425, 45);

            Point ButtonCloseLocation = new Point(409, 0);
            Size ButtonCloseSize = new Size(41, 23);

            Point ButtonOpenLocation = new Point(240, 40);
            Size ButtonOpenSize = new Size(203, 40);

            readonly Font font = new Font("微软雅黑", 12);

            /// <summary>
            /// 推送通知。
            /// </summary>
            /// <param name="message">通知内容</param>
            /// <param name="topic">通知标题 </param>
            /// <param name="backColor">通知的背景颜色。可以使用预设好的背景颜色类 NotificationSystem.PresetColors 。</param>
            /// <param name="filePath">可选参数。指示是否显示“打开文件夹”按钮，以及该文件夹的路径。若无此需求请不要提供该参数，保留默认。</param>
            public void PushNotification(string topic, string message, Color backColor, string filePath = "null")
            {
                if (formMain.panelEmpty.InvokeRequired == false)
                {
                    Panel notiPanel = new Panel();//新建panel
                    formMain.Controls.Add(notiPanel);//往窗口添加控件
                    notiPanel.Location = backPanelLocation;//标定坐标
                    notiPanel.Size = backPanelSize; //标定大小
                    notiPanel.BackColor = backColor;
                    SetDouble(notiPanel);
                    notiPanel.Visible = true;
                    CreateSubLabel(ref notiPanel, topic, backColor, labelTopicLocation, labelTopicSize);//标题
                    CreateSubLabel(ref notiPanel, message, backColor, labelMessageLocation, labelMessageSize);//内容
                    CreateSubButton(ref notiPanel, "", backColor, ButtonCloseLocation, ButtonCloseSize);//关闭按钮
                    if (filePath != "null")
                    {
                        filePathMain = filePath;
                        CreateSubButton(ref notiPanel, "打开文件夹", backColor, ButtonOpenLocation, ButtonOpenSize, 1);//打开文件夹
                    }
                    notiPanel.BringToFront();
                }
                else
                {
                    Action<string, string, Color, string> action = new Action<string, string, Color, string>(PushNotification);
                    formMain.panelEmpty.Invoke(action,message,topic,backColor,filePath);
                }
            }

            private delegate void Dg(ref Panel panel, string content, Color backColor, Point location, Size size);
            /// <summary>
            /// 往通知 panel 添加 label。
            /// </summary>
            /// <param name="panel">通知 panel</param>
            /// <param name="content">label 内容</param>
            /// <param name="backColor">label 背景颜色</param>
            /// <param name="location">label 位置</param>
            /// <param name="size">label 大小</param>
            private void CreateSubLabel(ref Panel panel, string content, Color backColor, Point location, Size size)
            {
                Label label = new Label()
                {
                    AutoSize = false,
                    BorderStyle = BorderStyle.None,
                    BackColor = backColor,
                    ForeColor = Color.White,
                    Font = font,
                    Text = content,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Location = location,
                    Size = size,
                    Visible = true
                };
                SetDouble(label);
                panel.Controls.Add(label);
                label.BringToFront();
            }

            /// <summary>
            /// 往通知 panel 添加 button。
            /// </summary>
            /// <param name="panel">通知 panel</param>
            /// <param name="content">label 内容</param>
            /// <param name="backColor">label 背景颜色</param>
            /// <param name="location">label 位置</param>
            /// <param name="size">label 大小</param>
            /// <param name="borderSize">边框大小，默认为 0</param>
            private void CreateSubButton(ref Panel panel, string content, Color backColor, Point location, Size size, int borderSize= 0)
            {
                Button button = new Button()
                {//属性设置
                    AutoSize = false,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = backColor,
                    ForeColor = Color.White,
                    Font = font,
                    Text = content,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Location = location,
                    Size = size,
                    Visible = true
                };
                FlatButtonAppearance flatButtonAppearance = button.FlatAppearance;
                flatButtonAppearance.BorderColor = Color.Gray;
                flatButtonAppearance.MouseDownBackColor = PresetColors.MouseDownBackColor;
                flatButtonAppearance.MouseOverBackColor = PresetColors.MouseOverBackColor;
                flatButtonAppearance.BorderSize = borderSize;
                if (borderSize == 0)//边框值为0，这是一个关闭按钮
                {
                    button.BackgroundImage = Properties.Resources.guanbi3;
                    button.BackgroundImageLayout = ImageLayout.Zoom;
                    button.Click += new EventHandler(Button_Click);//绑定点击事件
                }
                SetDouble(button);
                panel.Controls.Add(button);
                button.BringToFront();
            }

            /// <summary>
            /// 通知关闭按钮的行为。
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void CloseNoti_Click(object sender, EventArgs e)
            {
                Button button = (Button)(sender);//获取触发本消息处理的 Button 控件
                foreach (Panel panel1 in formMain.Controls)
                {
                    if (panel1.Controls.Contains(button) == true)
                    {
                        formMain.Controls.Remove(panel1);//移除该通知控件 
                        break;
                    }
                }
            }

            private void Button_Click(object sender, EventArgs e)
            {
                //使用命令行打开资源管理器并定位到文件。
                Process p = new Process();
                p.StartInfo.FileName = "explorer.exe";
                p.StartInfo.Arguments = "/e,/select," + filePathMain;//参数 -e 此命令使用默认视图启动 Windows 资源管理器，并把焦点定位在 RecePath。
                p.Start();
            }
        }

        /// <summary>
        /// 往好友列表里动态添加 panel。
        /// </summary>
        /// <param name="panel">panel 数组的成员</param>
        /// <param name="name"></param>
        /// <param name="uid"></param>
        /// <param name="index">该 panel 的序号（从 0 开始），用于标定坐标</param>
        public static void CreatePanels(ref Panel panel, string uid, string name, int index)
        {
            Panel panel2 = new Panel();
            panel = panel2;
            //panels[i].Name = "panels" + i.ToString();
            formMain.panelLANBar.Controls.Add(panel);
            panel.Location = new Point(0, index * 100);//标定坐标
            panel.Size = new Size(367, 100); //标定大小
            panel.BackColor = CommonFoundations.DarkBlue;
            panel.BringToFront();
            panel.Name = "panel" + uid;//把UID作为 panel 唯一名字
            //添加其它子控件
            formMain.AddInfoLabels(ref panel, name);
            //动态绑定消息处理
            panel.MouseEnter += new EventHandler(formMain.Panels_MouseEnter);
            panel.MouseLeave += new EventHandler(formMain.Panels_MouseLeave);
            panel.Click += new EventHandler(formMain.Panels_Click);
        }

        /// <summary>
        /// 为好友列表的单个 panel 添加信息元素。
        /// </summary>
        /// <param name="panel"></param>
        public void AddInfoLabels(ref Panel panel, string name)
        {
            Label labelStatus = new Label();                        //聊天中指示条
            labelStatus.Name = "labelStatus";
            panel.Controls.Add(labelStatus);
            labelStatus.AutoSize = false;
            labelStatus.Location = new Point(1, 0);
            labelStatus.Size = new Size(6, 100);
            labelStatus.BorderStyle = BorderStyle.None;
            if (panel.Name.Substring(5, 17) == CommonFoundations.RemoteUID)//如果父 panel 是缓存的 UID，意味着这是正在聊天的佬
            {
                labelStatus.BackColor = CommonFoundations.MainBlue;
            }
            else
            {
                labelStatus.BackColor = Color.Transparent;
            }
            labelStatus.Text = null;
            SetDouble(labelStatus);

            Label labelName = new Label();                                   //用户名
            labelName.Name = "labelName";
            panel.Controls.Add(labelName);
            labelName.AutoSize = false;
            labelName.Location = new Point(11, 20);
            labelName.Size = new Size(323, 29);
            labelName.BorderStyle = BorderStyle.None;
            labelName.BackColor = Color.Transparent;
            labelName.ForeColor = Color.White;
            labelName.Text = name;
            labelName.Font = new Font("微软雅黑", 14);
            labelName.MouseEnter += new EventHandler(formMain.Labels_MouseEnter);//动态绑定消息处理
            labelName.MouseLeave += new EventHandler(formMain.Labels_MouseLeave);
            labelName.Click += new EventHandler(formMain.Labels_Click);
            SetDouble(labelName);

            Label labelUnread = new Label();                                   //未读消息，默认不可见
            labelUnread.Name = "labelUnread";
            panel.Controls.Add(labelUnread);
            labelUnread.AutoSize = false;
            labelUnread.Location = new Point(16, 57);
            labelUnread.Size = new Size(128, 29);
            labelUnread.BorderStyle = BorderStyle.None;
            labelUnread.BackColor = Color.Transparent;
            labelUnread.ForeColor = Color.DarkOrange;
            labelUnread.Text = " ◉ 未读消息 ";
            labelUnread.Visible = false;
            labelUnread.Font = new Font("微软雅黑", 12, FontStyle.Bold);
            labelUnread.MouseEnter += new EventHandler(formMain.Labels_MouseEnter);//动态绑定消息处理
            labelUnread.MouseLeave += new EventHandler(formMain.Labels_MouseLeave);
            labelUnread.Click += new EventHandler(formMain.Labels_Click);
            SetDouble(labelUnread);

            /*Label labelIP = new Label();                                   //IP
            labelIP.Name = "labelIP";
            panel.Controls.Add(labelIP);
            labelIP.AutoSize = false;
            labelIP.Location = new Point(189, 62);
            labelIP.Size = new Size(138, 19);
            labelIP.BorderStyle = BorderStyle.None;
            labelIP.BackColor = Color.Transparent;
            labelIP.ForeColor = Color.DarkGray;
            labelIP.TextAlign = ContentAlignment.MiddleRight;//文字右对齐
            labelIP.Text = "192.167.123." + i.ToString();
            labelIP.Font = new Font("微软雅黑", 12);
            labelIP.MouseEnter += new EventHandler(formMain.Labels_MouseEnter);//动态绑定消息处理
            labelIP.MouseLeave += new EventHandler(formMain.Labels_MouseLeave);
            labelIP.Click += new EventHandler(formMain.Labels_Click);
            SetDouble(labelIP);*/

            //return labelUID.Text;
        }
    }
}
