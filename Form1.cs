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

namespace UChat
{
    public partial class FormLogin : Form
    {

        protected override CreateParams CreateParams
        { 
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        System.Timers.Timer Timer = new System.Timers.Timer();
        //static int pictureboxY = 160;
        public FormLogin()
        {
            InitializeComponent();

            //启用双缓冲，减少窗口控件闪烁
            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
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


        private void Label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        /// <summary> 
        /// 你们的爸爸是我！(～o￣3￣)～（大雾）
        /// </summary> 
        /// <returns></returns> 
        private void IamYourFather()
        {
            pictureBox1.Parent = labelBackGround;
            labelTitle.Parent = labelBackGround;
            buttonExit.Parent = labelBackGround;
            buttonCreate.Parent = labelBackGround;
            labelTips.Parent = labelBackGround;
            //buttonSeePW.Parent = labelBackGround;
            buttonSignIn.Parent = labelBackGround;
            labelUID.Parent = labelBackGround;
            buttonChange.Parent = labelBackGround;
            buttonWhat.Parent = labelBackGround;
            labelBar.Parent = labelBackGround;
            labelYourUID.Parent = labelBackGround;
            labelCongratulation.Parent = labelBackGround;
            labelPWError.Parent = labelBackGround;
            buttonSwitchUID.Parent = labelBackGround;
        }


        /// <summary> 
        /// 你们的爸爸真的是我！(○｀ 3′○)（大雾）
        /// </summary> 
        /// <returns></returns> 
        private void IamYourFather2()
        {
            pictureBox1.Parent = labelBG;
            labelTitle.Parent = labelBG;
            buttonExit.Parent = labelBG;
            buttonCreate.Parent = labelBG;
            labelTips.Parent = labelBG;
            //buttonSeePW.Parent = labelBG;
            buttonSignIn.Parent = labelBG;
            labelUID.Parent = labelBG;
            buttonChange.Parent = labelBG;
            buttonWhat.Parent = labelBG;
            labelBar.Parent = labelBG;
            labelYourUID.Parent = labelBG;
            labelCongratulation.Parent = labelBG;
            labelPWError.Parent = labelBG;
            buttonSwitchUID.Parent = labelBG;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.BringToFront();
            labelTitle.BringToFront();
            IamYourFather();
            labelTips.Text = "你在这台电脑上还没有任何账户。\r\n现在就创建一个！";
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void LabelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


        /// <summary> 
        /// 动画结束后开始显示控件。
        /// </summary> 
        /// <returns></returns> 
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Top >= 90)//上移图片
            {
                pictureBox1.Top -= 3;
                pictureBox1.Refresh();
            }
            else
            {
                timer1.Stop();
                timer1.Enabled = false;
                //buttonExit2.Visible = true;
                labelBackGround.Visible = false;
                IamYourFather2();
                Opacity = 0.99;//调整窗口透明度
                if (CommonFoundations.fileExist == false)//不存在存在文件就创建新账户
                {
                    //AcceptButton = buttonCreate;
                    labelBar.Text = "UChat  创建账户向导";
                    labelTitle.Visible = false;
                    textBoxUserName.Visible = true;
                    textBoxPassword.Visible = true;
                    buttonCreate.Visible = true;
                    labelTips.Visible = true;
                    labelUID.Visible = true;
                    labelUID.Text = UIDMaker();
                    buttonChange.Visible = true;
                    buttonWhat.Visible = true;
                    labelYourUID.Visible = true;
                    labelYourUID.BringToFront();
                }
                else                                         //存在文件就直接登录
                {
                    //AcceptButton = buttonSignIn;
                    labelBar.Text = "UChat  登录账户";
                    DataSet userDataSet = new DataSet();
                    userDataSet.ReadXml(CommonFoundations.hostUsers_FilePath);//读取本地用户xml存档为表格
                    labelTitle.Top -= 120;
                    textBoxPassword.Top += 10;
                    buttonSeePW.Top += 10;
                    //labelUID.Top += 215;
                    labelTitle.Visible = true;
                    labelTitle.Font = new Font(labelTitle.Font.FontFamily, 36, labelTitle.Font.Style);//改小字体
                    labelTitle.Text = userDataSet.Tables[0].Rows[0][0].ToString();//显示用户名
                    //labelUID.Text =  "UID："+ userDataSet.Tables[0].Rows[0][2].ToString();//显示UID
                    textBoxPassword.Visible = true;
                    //labelUID.BorderStyle = BorderStyle.None;
                    //labelUID.Visible = true;
                    buttonSignIn.Visible = true;
                    buttonSwitchUID.Visible = true;
                }
            }
        }

        private void TimerStart_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
            timerStart.Stop();
            timerStart.Enabled = false;
        }

        private void TextBoxUserName_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBoxUserName.Text == "用户名")
            {
                textBoxUserName.Text = "";
                textBoxUserName.ForeColor = Color.Black;
            }
        }

        private void TextBoxPassword_MouseClick(object sender, MouseEventArgs e)
        {
            //buttonSeePW.Parent = labelBG;
            buttonSeePW.BringToFront();
            buttonSeePW.Visible = true;
            if (textBoxPassword.Text == "密码")
            {
                textBoxPassword.Text = "";
                textBoxPassword.ForeColor = Color.Black;
                textBoxPassword.UseSystemPasswordChar = true;
            }
        }

        private void ButtonSeePW_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.UseSystemPasswordChar == true)
            {
                textBoxPassword.UseSystemPasswordChar = false;
                buttonSeePW.BackColor = SystemColors.Highlight;
            }
            else
            {
                textBoxPassword.UseSystemPasswordChar = true;
                buttonSeePW.BackColor = Color.White;
            }
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "密码" || textBoxPassword.Text == " " || textBoxUserName.Text == "用户名" || textBoxUserName.Text == "")
            {
                labelTips.Text = "请输入合适的用户名与密码。";
                labelTips.ForeColor = Color.Coral;
                timerTips.Interval = 4000;
                timerTips.Enabled = true;
                timerTips.Start();
            }
            else
            {
                CreateHostFiles(textBoxUserName.Text, textBoxPassword.Text, labelUID.Text);
                buttonCreate.Visible = false;
                buttonChange.Visible = false;
                buttonWhat.Visible = false;
                buttonSeePW.Visible = false;
                textBoxPassword.Visible = false;
                textBoxUserName.Visible = false;
                labelYourUID.Visible = false;
                labelUID.Visible = false;
                labelTips.Visible = false;

                labelCongratulation.Visible = true;
                labelCongratulation.Text = textBoxUserName.Text + "，\r\n这是你的新账户。";
                timer2.Enabled = true;
                timer2.Start();

                CommonFoundations.HostName = textBoxUserName.Text;
                CommonFoundations.HostUID = labelUID.Text;

            }
        }

        /// <summary> 
        /// 创建本地用户存档。
        /// </summary> 
        /// <returns></returns> 
        private void CreateHostFiles(string name, string password,string UID)
        {
            string userXml = "<Users><User><name>"+ name +"</name><password>"+ password + "</password><UID>" + UID+ "</UID></User></Users>";
            Directory.CreateDirectory(CommonFoundations.directory_Path);
            Directory.CreateDirectory(CommonFoundations.history_Path);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(userXml);//把字符串转为xml
            doc.Save(CommonFoundations.hostUsers_FilePath);//保存xml为本地文件
        }

        private void LabelTips_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            
        }


        /// <summary> 
        /// 用当前时间创建一个UID。
        /// </summary> 
        /// <returns></returns> 
        private static string UIDMaker()
        {
            char zero = '0';
            string UID = DateTime.Now.Year.ToString() + DateTime.Now.DayOfYear.ToString().PadLeft(3,zero) + DateTime.Now.Hour.ToString().PadLeft(2, zero) + DateTime.Now.Minute.ToString().PadLeft(2, zero) + DateTime.Now.Second.ToString().PadLeft(2, zero) + DateTime.Now.Millisecond.ToString().PadLeft(4, zero);
            return UID;
        }

        private void ButtonChange_Click(object sender, EventArgs e)
        {
            labelUID.Text = UIDMaker();
            labelTips.ForeColor = Color.White;
            labelTips.Text = "UID更换成功。";
            timerTips.Interval = 1500;
            timerTips.Enabled = true;
            timerTips.Start();
        }

        private void ButtonWhat_Click(object sender, EventArgs e)
        {
            labelTips.ForeColor = Color.White;
            labelTips.Text = "UID用来识别你的独一无二的账户。它是用当前系统时间生成的，创建账户后无法更改。";
            timerTips.Interval = 5000;
            timerTips.Enabled = true;
            timerTips.Start();
        }

        private void TimerTips_Tick(object sender, EventArgs e)
        {
            labelTips.ForeColor = Color.White;
            labelTips.Text = "你在这台电脑上还没有任何账户。\r\n现在就创建一个！";
            timerTips.Stop();
            timerTips.Enabled = false;
        }

        private void LabelUID_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void ButtonExit2_Click(object sender, EventArgs e)
        {
        }

        private void LabelBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


        private void LabelBG_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void TextBoxUserName_Leave(object sender, EventArgs e)
        {
            if (textBoxUserName.Text == "")
            {
                textBoxUserName.Text = "用户名";
                textBoxUserName.ForeColor = Color.DarkGray;
            }
        }

        private void TextBoxPassword_Leave(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "")
            {
                textBoxPassword.UseSystemPasswordChar = false;
                textBoxPassword.Text = "密码";
                textBoxPassword.ForeColor = Color.DarkGray;
                textBoxPassword.UseSystemPasswordChar = false;
                buttonSeePW.Visible = false;
            }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            labelCongratulation.Text = "请尽情使用吧！";
            timer2.Stop();
            timer2.Enabled = false;
            timer3.Enabled = true;
            timer3.Start();
        }

        private void TextBoxPassword_TextChanged(object sender, EventArgs e)
        {
            labelPWError.Visible = false;
            if (textBoxPassword.Text == "")
            {
                buttonSeePW.Visible = false;
            }
            else
            {
                if (buttonSeePW.Visible == false)
                {
                    buttonSeePW.Visible = true;
                }
                else
                {
                    buttonSeePW.Visible = false;
                }
            }
        }

        private void ButtonSwitchUID_Click(object sender, EventArgs e)
        {
            DataSet userDataSet = new DataSet();
            userDataSet.ReadXml(CommonFoundations.hostUsers_FilePath);//读取本地用户xml存档为表格
            if (labelTitle.Text == userDataSet.Tables[0].Rows[0][0].ToString())
            {
                labelTitle.Text = userDataSet.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                labelTitle.Text = userDataSet.Tables[0].Rows[0][0].ToString();
            }
        }

        private void ButtonSignIn_Click(object sender, EventArgs e)
        {
            DataSet userDataSet = new DataSet();
            userDataSet.ReadXml(CommonFoundations.hostUsers_FilePath);//读取本地用户xml存档为表格
            if (textBoxPassword.Text == userDataSet.Tables[0].Rows[0][1].ToString()) //密码正确，允许登录
            {
                CommonFoundations.HostName = userDataSet.Tables[0].Rows[0][0].ToString();
                CommonFoundations.HostUID = userDataSet.Tables[0].Rows[0][2].ToString();
                FormMain formMain = new FormMain();
                formMain.Show();
                Close();
            }
            else
            {
                labelPWError.Visible = true;
            }
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            timer3.Stop();
            timer3.Enabled = false;
            FormMain formMain = new FormMain();
            formMain.Show();
            Close();
        }
    }
}
