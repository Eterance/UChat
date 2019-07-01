namespace UChat
{
    partial class FormLogin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.labelTitle = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerStart = new System.Windows.Forms.Timer(this.components);
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.labelTips = new System.Windows.Forms.Label();
            this.buttonSignIn = new System.Windows.Forms.Button();
            this.labelUID = new System.Windows.Forms.Label();
            this.buttonWhat = new System.Windows.Forms.Button();
            this.buttonChange = new System.Windows.Forms.Button();
            this.timerTips = new System.Windows.Forms.Timer(this.components);
            this.labelBar = new System.Windows.Forms.Label();
            this.labelYourUID = new System.Windows.Forms.Label();
            this.labelCongratulation = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.labelPWError = new System.Windows.Forms.Label();
            this.buttonSwitchUID = new System.Windows.Forms.Button();
            this.buttonSeePW = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelBackGround = new System.Windows.Forms.Label();
            this.labelBG = new System.Windows.Forms.Label();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("微软雅黑 Light", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(171, 410);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(939, 92);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "UChat";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LabelTitle_MouseDown);
            // 
            // timer1
            // 
            this.timer1.Interval = 5;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // timerStart
            // 
            this.timerStart.Enabled = true;
            this.timerStart.Interval = 1750;
            this.timerStart.Tick += new System.EventHandler(this.TimerStart_Tick);
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxUserName.ForeColor = System.Drawing.Color.DarkGray;
            this.textBoxUserName.Location = new System.Drawing.Point(432, 342);
            this.textBoxUserName.MaxLength = 16;
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(410, 29);
            this.textBoxUserName.TabIndex = 4;
            this.textBoxUserName.Text = "用户名";
            this.textBoxUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxUserName.Visible = false;
            this.textBoxUserName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBoxUserName_MouseClick);
            this.textBoxUserName.Leave += new System.EventHandler(this.TextBoxUserName_Leave);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxPassword.ForeColor = System.Drawing.Color.DarkGray;
            this.textBoxPassword.Location = new System.Drawing.Point(432, 393);
            this.textBoxPassword.MaxLength = 16;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(410, 29);
            this.textBoxPassword.TabIndex = 5;
            this.textBoxPassword.Text = "密码";
            this.textBoxPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPassword.Visible = false;
            this.textBoxPassword.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBoxPassword_MouseClick);
            this.textBoxPassword.TextChanged += new System.EventHandler(this.TextBoxPassword_TextChanged);
            this.textBoxPassword.Leave += new System.EventHandler(this.TextBoxPassword_Leave);
            // 
            // buttonCreate
            // 
            this.buttonCreate.BackColor = System.Drawing.Color.Transparent;
            this.buttonCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCreate.FlatAppearance.BorderSize = 0;
            this.buttonCreate.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonCreate.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.buttonCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreate.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCreate.ForeColor = System.Drawing.Color.White;
            this.buttonCreate.Location = new System.Drawing.Point(1111, 633);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(168, 86);
            this.buttonCreate.TabIndex = 6;
            this.buttonCreate.Text = "创建账户  ▶";
            this.buttonCreate.UseVisualStyleBackColor = false;
            this.buttonCreate.Visible = false;
            this.buttonCreate.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // labelTips
            // 
            this.labelTips.BackColor = System.Drawing.Color.Transparent;
            this.labelTips.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTips.ForeColor = System.Drawing.Color.White;
            this.labelTips.Location = new System.Drawing.Point(418, 554);
            this.labelTips.Name = "labelTips";
            this.labelTips.Size = new System.Drawing.Size(434, 165);
            this.labelTips.TabIndex = 7;
            this.labelTips.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTips.Visible = false;
            this.labelTips.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LabelTips_MouseDown);
            // 
            // buttonSignIn
            // 
            this.buttonSignIn.BackColor = System.Drawing.Color.Transparent;
            this.buttonSignIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSignIn.FlatAppearance.BorderSize = 0;
            this.buttonSignIn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonSignIn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.buttonSignIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSignIn.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSignIn.ForeColor = System.Drawing.Color.White;
            this.buttonSignIn.Location = new System.Drawing.Point(1111, 633);
            this.buttonSignIn.Name = "buttonSignIn";
            this.buttonSignIn.Size = new System.Drawing.Size(168, 86);
            this.buttonSignIn.TabIndex = 9;
            this.buttonSignIn.Text = "登录账户  ▶";
            this.buttonSignIn.UseVisualStyleBackColor = false;
            this.buttonSignIn.Visible = false;
            this.buttonSignIn.Click += new System.EventHandler(this.ButtonSignIn_Click);
            // 
            // labelUID
            // 
            this.labelUID.BackColor = System.Drawing.Color.Transparent;
            this.labelUID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelUID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelUID.ForeColor = System.Drawing.Color.White;
            this.labelUID.Location = new System.Drawing.Point(432, 442);
            this.labelUID.Name = "labelUID";
            this.labelUID.Size = new System.Drawing.Size(410, 29);
            this.labelUID.TabIndex = 10;
            this.labelUID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelUID.Visible = false;
            this.labelUID.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LabelUID_MouseDown);
            // 
            // buttonWhat
            // 
            this.buttonWhat.BackColor = System.Drawing.Color.Transparent;
            this.buttonWhat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonWhat.FlatAppearance.BorderSize = 0;
            this.buttonWhat.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonWhat.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.buttonWhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonWhat.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonWhat.ForeColor = System.Drawing.Color.White;
            this.buttonWhat.Location = new System.Drawing.Point(432, 480);
            this.buttonWhat.Name = "buttonWhat";
            this.buttonWhat.Size = new System.Drawing.Size(205, 29);
            this.buttonWhat.TabIndex = 11;
            this.buttonWhat.Text = "什么是UID？";
            this.buttonWhat.UseVisualStyleBackColor = false;
            this.buttonWhat.Visible = false;
            this.buttonWhat.Click += new System.EventHandler(this.ButtonWhat_Click);
            // 
            // buttonChange
            // 
            this.buttonChange.BackColor = System.Drawing.Color.Transparent;
            this.buttonChange.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonChange.FlatAppearance.BorderSize = 0;
            this.buttonChange.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonChange.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.buttonChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChange.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonChange.ForeColor = System.Drawing.Color.White;
            this.buttonChange.Location = new System.Drawing.Point(637, 480);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(205, 29);
            this.buttonChange.TabIndex = 12;
            this.buttonChange.Text = "换一个UID";
            this.buttonChange.UseVisualStyleBackColor = false;
            this.buttonChange.Visible = false;
            this.buttonChange.Click += new System.EventHandler(this.ButtonChange_Click);
            // 
            // timerTips
            // 
            this.timerTips.Interval = 5000;
            this.timerTips.Tick += new System.EventHandler(this.TimerTips_Tick);
            // 
            // labelBar
            // 
            this.labelBar.BackColor = System.Drawing.Color.Transparent;
            this.labelBar.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelBar.ForeColor = System.Drawing.Color.White;
            this.labelBar.Location = new System.Drawing.Point(3, 1);
            this.labelBar.Name = "labelBar";
            this.labelBar.Size = new System.Drawing.Size(254, 25);
            this.labelBar.TabIndex = 14;
            this.labelBar.Text = "UChat";
            this.labelBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LabelBar_MouseDown);
            // 
            // labelYourUID
            // 
            this.labelYourUID.BackColor = System.Drawing.Color.Transparent;
            this.labelYourUID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelYourUID.ForeColor = System.Drawing.Color.White;
            this.labelYourUID.Location = new System.Drawing.Point(433, 443);
            this.labelYourUID.Name = "labelYourUID";
            this.labelYourUID.Size = new System.Drawing.Size(89, 27);
            this.labelYourUID.TabIndex = 16;
            this.labelYourUID.Text = "你的UID：";
            this.labelYourUID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelYourUID.Visible = false;
            // 
            // labelCongratulation
            // 
            this.labelCongratulation.BackColor = System.Drawing.Color.Transparent;
            this.labelCongratulation.Font = new System.Drawing.Font("微软雅黑", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCongratulation.ForeColor = System.Drawing.Color.White;
            this.labelCongratulation.Location = new System.Drawing.Point(103, 342);
            this.labelCongratulation.Name = "labelCongratulation";
            this.labelCongratulation.Size = new System.Drawing.Size(1135, 261);
            this.labelCongratulation.TabIndex = 17;
            this.labelCongratulation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelCongratulation.Visible = false;
            // 
            // timer2
            // 
            this.timer2.Interval = 3000;
            this.timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // labelPWError
            // 
            this.labelPWError.BackColor = System.Drawing.Color.Transparent;
            this.labelPWError.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPWError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labelPWError.Location = new System.Drawing.Point(585, 450);
            this.labelPWError.Name = "labelPWError";
            this.labelPWError.Size = new System.Drawing.Size(112, 27);
            this.labelPWError.TabIndex = 19;
            this.labelPWError.Text = "密码不正确。";
            this.labelPWError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelPWError.Visible = false;
            // 
            // buttonSwitchUID
            // 
            this.buttonSwitchUID.BackColor = System.Drawing.Color.Transparent;
            this.buttonSwitchUID.BackgroundImage = global::UChat.Properties.Resources.qiehuan1;
            this.buttonSwitchUID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSwitchUID.FlatAppearance.BorderSize = 0;
            this.buttonSwitchUID.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonSwitchUID.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.buttonSwitchUID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSwitchUID.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSwitchUID.ForeColor = System.Drawing.Color.White;
            this.buttonSwitchUID.Location = new System.Drawing.Point(617, 656);
            this.buttonSwitchUID.Name = "buttonSwitchUID";
            this.buttonSwitchUID.Size = new System.Drawing.Size(40, 40);
            this.buttonSwitchUID.TabIndex = 18;
            this.buttonSwitchUID.UseVisualStyleBackColor = false;
            this.buttonSwitchUID.Visible = false;
            this.buttonSwitchUID.Click += new System.EventHandler(this.ButtonSwitchUID_Click);
            // 
            // buttonSeePW
            // 
            this.buttonSeePW.BackColor = System.Drawing.Color.White;
            this.buttonSeePW.BackgroundImage = global::UChat.Properties.Resources.xianshimima__3_;
            this.buttonSeePW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSeePW.FlatAppearance.BorderSize = 0;
            this.buttonSeePW.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonSeePW.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.buttonSeePW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSeePW.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSeePW.ForeColor = System.Drawing.Color.White;
            this.buttonSeePW.Location = new System.Drawing.Point(811, 394);
            this.buttonSeePW.Name = "buttonSeePW";
            this.buttonSeePW.Size = new System.Drawing.Size(31, 27);
            this.buttonSeePW.TabIndex = 8;
            this.buttonSeePW.UseVisualStyleBackColor = false;
            this.buttonSeePW.Visible = false;
            this.buttonSeePW.Click += new System.EventHandler(this.ButtonSeePW_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Transparent;
            this.buttonExit.BackgroundImage = global::UChat.Properties.Resources.guanbi3;
            this.buttonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.buttonExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonExit.ForeColor = System.Drawing.Color.White;
            this.buttonExit.Location = new System.Drawing.Point(1234, 0);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(45, 30);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::UChat.Properties.Resources.Chat__1_;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(540, 162);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(194, 186);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseDown);
            // 
            // labelBackGround
            // 
            this.labelBackGround.Image = global::UChat.Properties.Resources._6bead974b64d66c66cee3e536d001ee8;
            this.labelBackGround.Location = new System.Drawing.Point(1, 1);
            this.labelBackGround.Name = "labelBackGround";
            this.labelBackGround.Size = new System.Drawing.Size(1278, 718);
            this.labelBackGround.TabIndex = 0;
            this.labelBackGround.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Label1_MouseDown);
            // 
            // labelBG
            // 
            this.labelBG.Image = global::UChat.Properties.Resources._6bead974b64d66c66cee3e536d001ee81;
            this.labelBG.Location = new System.Drawing.Point(1, 1);
            this.labelBG.Name = "labelBG";
            this.labelBG.Size = new System.Drawing.Size(1278, 718);
            this.labelBG.TabIndex = 15;
            this.labelBG.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LabelBG_MouseDown);
            // 
            // timer3
            // 
            this.timer3.Interval = 2000;
            this.timer3.Tick += new System.EventHandler(this.Timer3_Tick);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.labelPWError);
            this.Controls.Add(this.buttonSwitchUID);
            this.Controls.Add(this.buttonSignIn);
            this.Controls.Add(this.labelYourUID);
            this.Controls.Add(this.labelBar);
            this.Controls.Add(this.buttonChange);
            this.Controls.Add(this.buttonWhat);
            this.Controls.Add(this.labelUID);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.buttonSeePW);
            this.Controls.Add(this.labelTips);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelCongratulation);
            this.Controls.Add(this.labelBackGround);
            this.Controls.Add(this.labelBG);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UChat";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelBackGround;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timerStart;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Label labelTips;
        private System.Windows.Forms.Button buttonSeePW;
        private System.Windows.Forms.Button buttonSignIn;
        private System.Windows.Forms.Label labelUID;
        private System.Windows.Forms.Button buttonWhat;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Timer timerTips;
        private System.Windows.Forms.Label labelBar;
        private System.Windows.Forms.Label labelBG;
        private System.Windows.Forms.Label labelYourUID;
        private System.Windows.Forms.Label labelCongratulation;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button buttonSwitchUID;
        private System.Windows.Forms.Label labelPWError;
        private System.Windows.Forms.Timer timer3;
    }
}

