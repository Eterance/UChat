namespace UChat
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.labelChatBoxBG = new System.Windows.Forms.Label();
            this.panelSideBar = new System.Windows.Forms.Panel();
            this.labelSideBarBorder = new System.Windows.Forms.Label();
            this.buttonDetail = new System.Windows.Forms.Button();
            this.buttonFiles = new System.Windows.Forms.Button();
            this.buttonMenu = new System.Windows.Forms.Button();
            this.buttonSetting = new System.Windows.Forms.Button();
            this.buttonExit2 = new System.Windows.Forms.Button();
            this.buttonLAN = new System.Windows.Forms.Button();
            this.panelDetail = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxUID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.richTextBoxChat = new System.Windows.Forms.RichTextBox();
            this.labelNameIndicator = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.buttonMin = new System.Windows.Forms.Button();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonScrollToTheBottom = new System.Windows.Forms.Button();
            this.labelChatBorder = new System.Windows.Forms.Label();
            this.panelFileBar = new System.Windows.Forms.Panel();
            this.panelPercent = new System.Windows.Forms.Panel();
            this.buttonCancelFTR = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelPercent = new System.Windows.Forms.Label();
            this.panelConfirm = new System.Windows.Forms.Panel();
            this.buttonRefuse = new System.Windows.Forms.Button();
            this.buttonAcceptFTR = new System.Windows.Forms.Button();
            this.labelWating = new System.Windows.Forms.Label();
            this.buttonSelectFile = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.labelTarget = new System.Windows.Forms.Label();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.labelAlert = new System.Windows.Forms.Label();
            this.labelForbid = new System.Windows.Forms.Label();
            this.panelTips = new System.Windows.Forms.Panel();
            this.pictureBoxTips = new System.Windows.Forms.PictureBox();
            this.backgroundWorkerFileReceiver = new System.ComponentModel.BackgroundWorker();
            this.timerFTTimeout = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorkerFileSender = new System.ComponentModel.BackgroundWorker();
            this.buttonSendM = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.panelLANBar = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelEmpty = new System.Windows.Forms.Panel();
            this.pictureBoxEmptyIcon = new System.Windows.Forms.PictureBox();
            this.labelEmptyText = new System.Windows.Forms.Label();
            this.timerPercent = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panelSetting = new System.Windows.Forms.Panel();
            this.panelChangeName = new System.Windows.Forms.Panel();
            this.textBoxChangeName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonCancelChange = new System.Windows.Forms.Button();
            this.buttonConfirmChange = new System.Windows.Forms.Button();
            this.panelSideBar.SuspendLayout();
            this.panelDetail.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelFileBar.SuspendLayout();
            this.panelPercent.SuspendLayout();
            this.panelConfirm.SuspendLayout();
            this.panelTips.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTips)).BeginInit();
            this.panelLANBar.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelEmpty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmptyIcon)).BeginInit();
            this.panelSetting.SuspendLayout();
            this.panelChangeName.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelChatBoxBG
            // 
            this.labelChatBoxBG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.labelChatBoxBG.Location = new System.Drawing.Point(418, 1);
            this.labelChatBoxBG.Name = "labelChatBoxBG";
            this.labelChatBoxBG.Size = new System.Drawing.Size(861, 718);
            this.labelChatBoxBG.TabIndex = 5;
            this.labelChatBoxBG.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Label2_MouseDown);
            // 
            // panelSideBar
            // 
            this.panelSideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(68)))), ((int)(((byte)(81)))));
            this.panelSideBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSideBar.Controls.Add(this.labelSideBarBorder);
            this.panelSideBar.Controls.Add(this.buttonDetail);
            this.panelSideBar.Controls.Add(this.buttonFiles);
            this.panelSideBar.Controls.Add(this.buttonMenu);
            this.panelSideBar.Controls.Add(this.buttonSetting);
            this.panelSideBar.Controls.Add(this.buttonExit2);
            this.panelSideBar.Controls.Add(this.buttonLAN);
            this.panelSideBar.Controls.Add(this.panelDetail);
            this.panelSideBar.Location = new System.Drawing.Point(1, 1);
            this.panelSideBar.Name = "panelSideBar";
            this.panelSideBar.Size = new System.Drawing.Size(50, 718);
            this.panelSideBar.TabIndex = 7;
            this.panelSideBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelSideBar_MouseDown);
            // 
            // labelSideBarBorder
            // 
            this.labelSideBarBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(125)))), ((int)(((byte)(236)))));
            this.labelSideBarBorder.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSideBarBorder.ForeColor = System.Drawing.Color.DarkGray;
            this.labelSideBarBorder.Location = new System.Drawing.Point(299, 0);
            this.labelSideBarBorder.Name = "labelSideBarBorder";
            this.labelSideBarBorder.Size = new System.Drawing.Size(1, 718);
            this.labelSideBarBorder.TabIndex = 15;
            this.labelSideBarBorder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonDetail
            // 
            this.buttonDetail.BackColor = System.Drawing.Color.Transparent;
            this.buttonDetail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonDetail.FlatAppearance.BorderSize = 0;
            this.buttonDetail.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.buttonDetail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.buttonDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDetail.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonDetail.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonDetail.Image = global::UChat.Properties.Resources.个人信息;
            this.buttonDetail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDetail.Location = new System.Drawing.Point(-1, 150);
            this.buttonDetail.Name = "buttonDetail";
            this.buttonDetail.Size = new System.Drawing.Size(302, 50);
            this.buttonDetail.TabIndex = 11;
            this.buttonDetail.Text = "  对方的个人信息";
            this.buttonDetail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDetail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.buttonDetail, "对方的个人信息");
            this.buttonDetail.UseVisualStyleBackColor = false;
            this.buttonDetail.Visible = false;
            this.buttonDetail.Click += new System.EventHandler(this.ButtonDetail_Click);
            // 
            // buttonFiles
            // 
            this.buttonFiles.BackColor = System.Drawing.Color.Transparent;
            this.buttonFiles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonFiles.FlatAppearance.BorderSize = 0;
            this.buttonFiles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.buttonFiles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.buttonFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFiles.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonFiles.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonFiles.Image = global::UChat.Properties.Resources.传输文件2;
            this.buttonFiles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFiles.Location = new System.Drawing.Point(-1, 100);
            this.buttonFiles.Name = "buttonFiles";
            this.buttonFiles.Size = new System.Drawing.Size(302, 50);
            this.buttonFiles.TabIndex = 9;
            this.buttonFiles.Text = "  文件传输";
            this.buttonFiles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFiles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.buttonFiles, "文件传输");
            this.buttonFiles.UseVisualStyleBackColor = false;
            this.buttonFiles.Visible = false;
            this.buttonFiles.Click += new System.EventHandler(this.ButtonFiles_Click);
            // 
            // buttonMenu
            // 
            this.buttonMenu.BackColor = System.Drawing.Color.Transparent;
            this.buttonMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonMenu.FlatAppearance.BorderSize = 0;
            this.buttonMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.buttonMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.buttonMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMenu.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonMenu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonMenu.Image = ((System.Drawing.Image)(resources.GetObject("buttonMenu.Image")));
            this.buttonMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMenu.Location = new System.Drawing.Point(-1, 0);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(302, 50);
            this.buttonMenu.TabIndex = 3;
            this.buttonMenu.Text = "  UChat";
            this.buttonMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonMenu.UseVisualStyleBackColor = false;
            this.buttonMenu.Click += new System.EventHandler(this.Button4_Click);
            // 
            // buttonSetting
            // 
            this.buttonSetting.BackColor = System.Drawing.Color.Transparent;
            this.buttonSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSetting.FlatAppearance.BorderSize = 0;
            this.buttonSetting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.buttonSetting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.buttonSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSetting.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSetting.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSetting.Image = global::UChat.Properties.Resources.设置2;
            this.buttonSetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSetting.Location = new System.Drawing.Point(-1, 618);
            this.buttonSetting.Name = "buttonSetting";
            this.buttonSetting.Size = new System.Drawing.Size(302, 50);
            this.buttonSetting.TabIndex = 8;
            this.buttonSetting.Text = "  设置";
            this.buttonSetting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.buttonSetting, "设置");
            this.buttonSetting.UseVisualStyleBackColor = false;
            this.buttonSetting.Click += new System.EventHandler(this.ButtonSetting_Click);
            // 
            // buttonExit2
            // 
            this.buttonExit2.BackColor = System.Drawing.Color.Transparent;
            this.buttonExit2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonExit2.FlatAppearance.BorderSize = 0;
            this.buttonExit2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.buttonExit2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.buttonExit2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonExit2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonExit2.Image = global::UChat.Properties.Resources.退出1;
            this.buttonExit2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonExit2.Location = new System.Drawing.Point(-1, 668);
            this.buttonExit2.Name = "buttonExit2";
            this.buttonExit2.Size = new System.Drawing.Size(302, 50);
            this.buttonExit2.TabIndex = 2;
            this.buttonExit2.Text = "  退出";
            this.buttonExit2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonExit2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.buttonExit2, "退出");
            this.buttonExit2.UseVisualStyleBackColor = false;
            this.buttonExit2.Click += new System.EventHandler(this.ButtonExit2_Click);
            // 
            // buttonLAN
            // 
            this.buttonLAN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(125)))), ((int)(((byte)(236)))));
            this.buttonLAN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonLAN.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.buttonLAN.FlatAppearance.BorderSize = 0;
            this.buttonLAN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.buttonLAN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.buttonLAN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLAN.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonLAN.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonLAN.Image = global::UChat.Properties.Resources.局域网2;
            this.buttonLAN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLAN.Location = new System.Drawing.Point(-1, 50);
            this.buttonLAN.Name = "buttonLAN";
            this.buttonLAN.Size = new System.Drawing.Size(302, 50);
            this.buttonLAN.TabIndex = 1;
            this.buttonLAN.Text = "  局域网";
            this.buttonLAN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLAN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.buttonLAN, "局域网");
            this.buttonLAN.UseVisualStyleBackColor = false;
            this.buttonLAN.Click += new System.EventHandler(this.ButtonLAN_Click);
            // 
            // panelDetail
            // 
            this.panelDetail.Controls.Add(this.label5);
            this.panelDetail.Controls.Add(this.label4);
            this.panelDetail.Controls.Add(this.textBoxUID);
            this.panelDetail.Controls.Add(this.label3);
            this.panelDetail.Controls.Add(this.textBoxIP);
            this.panelDetail.Controls.Add(this.textBoxName);
            this.panelDetail.Location = new System.Drawing.Point(50, 200);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Size = new System.Drawing.Size(247, 98);
            this.panelDetail.TabIndex = 12;
            this.panelDetail.Visible = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.DarkGray;
            this.label5.Location = new System.Drawing.Point(-4, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 24);
            this.label5.TabIndex = 15;
            this.label5.Text = "用户名";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.DarkGray;
            this.label4.Location = new System.Drawing.Point(-4, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 24);
            this.label4.TabIndex = 14;
            this.label4.Text = "U  I  D";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxUID
            // 
            this.textBoxUID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(68)))), ((int)(((byte)(81)))));
            this.textBoxUID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUID.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxUID.ForeColor = System.Drawing.Color.Gray;
            this.textBoxUID.Location = new System.Drawing.Point(59, 4);
            this.textBoxUID.Multiline = true;
            this.textBoxUID.Name = "textBoxUID";
            this.textBoxUID.ReadOnly = true;
            this.textBoxUID.Size = new System.Drawing.Size(147, 24);
            this.textBoxUID.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.DarkGray;
            this.label3.Location = new System.Drawing.Point(-4, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 24);
            this.label3.TabIndex = 12;
            this.label3.Text = "IP地址";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxIP
            // 
            this.textBoxIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(68)))), ((int)(((byte)(81)))));
            this.textBoxIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxIP.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxIP.ForeColor = System.Drawing.Color.Gray;
            this.textBoxIP.Location = new System.Drawing.Point(59, 28);
            this.textBoxIP.Multiline = true;
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.ReadOnly = true;
            this.textBoxIP.Size = new System.Drawing.Size(147, 24);
            this.textBoxIP.TabIndex = 11;
            // 
            // textBoxName
            // 
            this.textBoxName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(68)))), ((int)(((byte)(81)))));
            this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxName.ForeColor = System.Drawing.Color.Gray;
            this.textBoxName.Location = new System.Drawing.Point(59, 52);
            this.textBoxName.Multiline = true;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(185, 44);
            this.textBoxName.TabIndex = 10;
            // 
            // richTextBoxChat
            // 
            this.richTextBoxChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.richTextBoxChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxChat.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBoxChat.ForeColor = System.Drawing.Color.White;
            this.richTextBoxChat.HideSelection = false;
            this.richTextBoxChat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.richTextBoxChat.Location = new System.Drawing.Point(10, 10);
            this.richTextBoxChat.Name = "richTextBoxChat";
            this.richTextBoxChat.ReadOnly = true;
            this.richTextBoxChat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.richTextBoxChat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxChat.Size = new System.Drawing.Size(840, 399);
            this.richTextBoxChat.TabIndex = 11;
            this.richTextBoxChat.Text = "";
            // 
            // labelNameIndicator
            // 
            this.labelNameIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.labelNameIndicator.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.labelNameIndicator.ForeColor = System.Drawing.Color.White;
            this.labelNameIndicator.Location = new System.Drawing.Point(433, 13);
            this.labelNameIndicator.Name = "labelNameIndicator";
            this.labelNameIndicator.Size = new System.Drawing.Size(323, 29);
            this.labelNameIndicator.TabIndex = 12;
            this.labelNameIndicator.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LabelNameIndicator_MouseDown);
            // 
            // timer1
            // 
            this.timer1.Interval = 3;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 3;
            this.timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // buttonMin
            // 
            this.buttonMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.buttonMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonMin.FlatAppearance.BorderSize = 0;
            this.buttonMin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(125)))), ((int)(((byte)(236)))));
            this.buttonMin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.buttonMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMin.Font = new System.Drawing.Font("华文细黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonMin.ForeColor = System.Drawing.Color.White;
            this.buttonMin.Location = new System.Drawing.Point(1189, 1);
            this.buttonMin.Name = "buttonMin";
            this.buttonMin.Size = new System.Drawing.Size(45, 30);
            this.buttonMin.TabIndex = 16;
            this.buttonMin.Text = "__";
            this.buttonMin.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonMin.UseVisualStyleBackColor = false;
            this.buttonMin.Click += new System.EventHandler(this.ButtonMin_Click);
            // 
            // textBoxInput
            // 
            this.textBoxInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.textBoxInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxInput.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxInput.ForeColor = System.Drawing.Color.White;
            this.textBoxInput.Location = new System.Drawing.Point(429, 486);
            this.textBoxInput.Multiline = true;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(839, 189);
            this.textBoxInput.TabIndex = 17;
            this.textBoxInput.TextChanged += new System.EventHandler(this.TextBoxInput_TextChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panel3.Controls.Add(this.buttonScrollToTheBottom);
            this.panel3.Controls.Add(this.richTextBoxChat);
            this.panel3.Location = new System.Drawing.Point(429, 51);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(850, 429);
            this.panel3.TabIndex = 20;
            // 
            // buttonScrollToTheBottom
            // 
            this.buttonScrollToTheBottom.BackColor = System.Drawing.Color.Transparent;
            this.buttonScrollToTheBottom.FlatAppearance.BorderSize = 0;
            this.buttonScrollToTheBottom.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(125)))), ((int)(((byte)(236)))));
            this.buttonScrollToTheBottom.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.buttonScrollToTheBottom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonScrollToTheBottom.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonScrollToTheBottom.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonScrollToTheBottom.Location = new System.Drawing.Point(385, 405);
            this.buttonScrollToTheBottom.Name = "buttonScrollToTheBottom";
            this.buttonScrollToTheBottom.Size = new System.Drawing.Size(122, 24);
            this.buttonScrollToTheBottom.TabIndex = 16;
            this.buttonScrollToTheBottom.Text = "滚动到底部";
            this.buttonScrollToTheBottom.UseVisualStyleBackColor = false;
            this.buttonScrollToTheBottom.Click += new System.EventHandler(this.ButtonScrollToTheBottom_Click);
            // 
            // labelChatBorder
            // 
            this.labelChatBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(83)))), ((int)(((byte)(85)))));
            this.labelChatBorder.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.labelChatBorder.ForeColor = System.Drawing.Color.DarkOrange;
            this.labelChatBorder.Location = new System.Drawing.Point(418, 479);
            this.labelChatBorder.Name = "labelChatBorder";
            this.labelChatBorder.Size = new System.Drawing.Size(861, 1);
            this.labelChatBorder.TabIndex = 3;
            // 
            // panelFileBar
            // 
            this.panelFileBar.AutoScroll = true;
            this.panelFileBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(33)))), ((int)(((byte)(42)))));
            this.panelFileBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelFileBar.Controls.Add(this.panelPercent);
            this.panelFileBar.Controls.Add(this.panelConfirm);
            this.panelFileBar.Controls.Add(this.labelWating);
            this.panelFileBar.Controls.Add(this.buttonSelectFile);
            this.panelFileBar.Controls.Add(this.label6);
            this.panelFileBar.Controls.Add(this.labelTarget);
            this.panelFileBar.Location = new System.Drawing.Point(51, 1);
            this.panelFileBar.Name = "panelFileBar";
            this.panelFileBar.Size = new System.Drawing.Size(367, 718);
            this.panelFileBar.TabIndex = 7;
            this.panelFileBar.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelFileBar_Paint);
            // 
            // panelPercent
            // 
            this.panelPercent.Controls.Add(this.buttonCancelFTR);
            this.panelPercent.Controls.Add(this.progressBar1);
            this.panelPercent.Controls.Add(this.labelPercent);
            this.panelPercent.Location = new System.Drawing.Point(22, 455);
            this.panelPercent.Name = "panelPercent";
            this.panelPercent.Size = new System.Drawing.Size(314, 252);
            this.panelPercent.TabIndex = 30;
            this.panelPercent.Visible = false;
            // 
            // buttonCancelFTR
            // 
            this.buttonCancelFTR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.buttonCancelFTR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCancelFTR.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.buttonCancelFTR.FlatAppearance.BorderSize = 0;
            this.buttonCancelFTR.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.buttonCancelFTR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.buttonCancelFTR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelFTR.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCancelFTR.ForeColor = System.Drawing.Color.White;
            this.buttonCancelFTR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancelFTR.Location = new System.Drawing.Point(0, 195);
            this.buttonCancelFTR.Name = "buttonCancelFTR";
            this.buttonCancelFTR.Size = new System.Drawing.Size(314, 50);
            this.buttonCancelFTR.TabIndex = 31;
            this.buttonCancelFTR.Text = "取消文件传输";
            this.buttonCancelFTR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCancelFTR.UseVisualStyleBackColor = false;
            this.buttonCancelFTR.Click += new System.EventHandler(this.ButtonCancelFTR_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(314, 8);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 28;
            // 
            // labelPercent
            // 
            this.labelPercent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(33)))), ((int)(((byte)(42)))));
            this.labelPercent.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.labelPercent.ForeColor = System.Drawing.Color.White;
            this.labelPercent.Location = new System.Drawing.Point(0, 9);
            this.labelPercent.Name = "labelPercent";
            this.labelPercent.Size = new System.Drawing.Size(314, 38);
            this.labelPercent.TabIndex = 27;
            this.labelPercent.Text = "0%";
            this.labelPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelConfirm
            // 
            this.panelConfirm.Controls.Add(this.buttonRefuse);
            this.panelConfirm.Controls.Add(this.buttonAcceptFTR);
            this.panelConfirm.Location = new System.Drawing.Point(3, 650);
            this.panelConfirm.Name = "panelConfirm";
            this.panelConfirm.Size = new System.Drawing.Size(358, 52);
            this.panelConfirm.TabIndex = 28;
            this.panelConfirm.Visible = false;
            // 
            // buttonRefuse
            // 
            this.buttonRefuse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.buttonRefuse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonRefuse.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.buttonRefuse.FlatAppearance.BorderSize = 0;
            this.buttonRefuse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.buttonRefuse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.buttonRefuse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefuse.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonRefuse.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonRefuse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRefuse.Location = new System.Drawing.Point(19, 0);
            this.buttonRefuse.Name = "buttonRefuse";
            this.buttonRefuse.Size = new System.Drawing.Size(140, 50);
            this.buttonRefuse.TabIndex = 28;
            this.buttonRefuse.Text = "拒绝(180)";
            this.buttonRefuse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonRefuse.UseVisualStyleBackColor = false;
            this.buttonRefuse.Click += new System.EventHandler(this.ButtonRefuse_Click);
            // 
            // buttonAcceptFTR
            // 
            this.buttonAcceptFTR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.buttonAcceptFTR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonAcceptFTR.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.buttonAcceptFTR.FlatAppearance.BorderSize = 0;
            this.buttonAcceptFTR.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.buttonAcceptFTR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.buttonAcceptFTR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAcceptFTR.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonAcceptFTR.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonAcceptFTR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAcceptFTR.Location = new System.Drawing.Point(193, 0);
            this.buttonAcceptFTR.Name = "buttonAcceptFTR";
            this.buttonAcceptFTR.Size = new System.Drawing.Size(140, 50);
            this.buttonAcceptFTR.TabIndex = 27;
            this.buttonAcceptFTR.Text = "接受";
            this.buttonAcceptFTR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAcceptFTR.UseVisualStyleBackColor = false;
            this.buttonAcceptFTR.Click += new System.EventHandler(this.ButtonAcceptFTR_Click);
            // 
            // labelWating
            // 
            this.labelWating.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(33)))), ((int)(((byte)(42)))));
            this.labelWating.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.labelWating.ForeColor = System.Drawing.Color.White;
            this.labelWating.Location = new System.Drawing.Point(0, 149);
            this.labelWating.Name = "labelWating";
            this.labelWating.Size = new System.Drawing.Size(367, 286);
            this.labelWating.TabIndex = 26;
            this.labelWating.Text = "正在等待对方确认接收文件...";
            this.labelWating.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelWating.Visible = false;
            // 
            // buttonSelectFile
            // 
            this.buttonSelectFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.buttonSelectFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSelectFile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.buttonSelectFile.FlatAppearance.BorderSize = 0;
            this.buttonSelectFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.buttonSelectFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.buttonSelectFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSelectFile.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSelectFile.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSelectFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSelectFile.Location = new System.Drawing.Point(22, 650);
            this.buttonSelectFile.Name = "buttonSelectFile";
            this.buttonSelectFile.Size = new System.Drawing.Size(314, 50);
            this.buttonSelectFile.TabIndex = 5;
            this.buttonSelectFile.Text = "选择文件";
            this.buttonSelectFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSelectFile.UseVisualStyleBackColor = false;
            this.buttonSelectFile.Click += new System.EventHandler(this.ButtonSelectFile_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(33)))), ((int)(((byte)(42)))));
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Silver;
            this.label6.Location = new System.Drawing.Point(3, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(350, 34);
            this.label6.TabIndex = 3;
            this.label6.Text = "将你的文件传输给";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTarget
            // 
            this.labelTarget.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(33)))), ((int)(((byte)(42)))));
            this.labelTarget.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.labelTarget.ForeColor = System.Drawing.Color.White;
            this.labelTarget.Location = new System.Drawing.Point(3, 55);
            this.labelTarget.Name = "labelTarget";
            this.labelTarget.Size = new System.Drawing.Size(353, 39);
            this.labelTarget.TabIndex = 4;
            this.labelTarget.Text = "23333";
            this.labelTarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer3
            // 
            this.timer3.Interval = 3;
            // 
            // labelAlert
            // 
            this.labelAlert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.labelAlert.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelAlert.ForeColor = System.Drawing.Color.DarkOrange;
            this.labelAlert.Location = new System.Drawing.Point(1073, 684);
            this.labelAlert.Name = "labelAlert";
            this.labelAlert.Size = new System.Drawing.Size(133, 29);
            this.labelAlert.TabIndex = 3;
            this.labelAlert.Text = "不能发送空消息";
            this.labelAlert.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelAlert.Visible = false;
            // 
            // labelForbid
            // 
            this.labelForbid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.labelForbid.Font = new System.Drawing.Font("微软雅黑 Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelForbid.ForeColor = System.Drawing.Color.DarkGray;
            this.labelForbid.Location = new System.Drawing.Point(37, 325);
            this.labelForbid.Name = "labelForbid";
            this.labelForbid.Size = new System.Drawing.Size(821, 143);
            this.labelForbid.TabIndex = 24;
            this.labelForbid.Text = "对方已下线。你无法继续与 ta 聊天。";
            this.labelForbid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelForbid.Visible = false;
            this.labelForbid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LabelForbid_MouseDown);
            // 
            // panelTips
            // 
            this.panelTips.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panelTips.Controls.Add(this.pictureBoxTips);
            this.panelTips.Controls.Add(this.labelForbid);
            this.panelTips.Location = new System.Drawing.Point(418, 37);
            this.panelTips.Name = "panelTips";
            this.panelTips.Size = new System.Drawing.Size(861, 682);
            this.panelTips.TabIndex = 21;
            this.panelTips.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelTips_MouseDown);
            // 
            // pictureBoxTips
            // 
            this.pictureBoxTips.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.pictureBoxTips.BackgroundImage = global::UChat.Properties.Resources.Chat;
            this.pictureBoxTips.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxTips.Location = new System.Drawing.Point(2, 136);
            this.pictureBoxTips.Name = "pictureBoxTips";
            this.pictureBoxTips.Size = new System.Drawing.Size(856, 184);
            this.pictureBoxTips.TabIndex = 25;
            this.pictureBoxTips.TabStop = false;
            this.pictureBoxTips.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseDown);
            // 
            // backgroundWorkerFileReceiver
            // 
            this.backgroundWorkerFileReceiver.WorkerReportsProgress = true;
            this.backgroundWorkerFileReceiver.WorkerSupportsCancellation = true;
            this.backgroundWorkerFileReceiver.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerFileReceiver_DoWork);
            this.backgroundWorkerFileReceiver.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerFileReceiver_RunWorkerCompleted);
            // 
            // timerFTTimeout
            // 
            this.timerFTTimeout.Interval = 1000;
            this.timerFTTimeout.Tick += new System.EventHandler(this.TimerFTTimeout_Tick);
            // 
            // backgroundWorkerFileSender
            // 
            this.backgroundWorkerFileSender.WorkerReportsProgress = true;
            this.backgroundWorkerFileSender.WorkerSupportsCancellation = true;
            this.backgroundWorkerFileSender.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerFileSender_DoWork);
            this.backgroundWorkerFileSender.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerFileSender_RunWorkerCompleted);
            // 
            // buttonSendM
            // 
            this.buttonSendM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.buttonSendM.BackgroundImage = global::UChat.Properties.Resources.发送2;
            this.buttonSendM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSendM.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.buttonSendM.FlatAppearance.BorderSize = 0;
            this.buttonSendM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(125)))), ((int)(((byte)(236)))));
            this.buttonSendM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.buttonSendM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSendM.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSendM.ForeColor = System.Drawing.Color.White;
            this.buttonSendM.Location = new System.Drawing.Point(1212, 681);
            this.buttonSendM.Name = "buttonSendM";
            this.buttonSendM.Size = new System.Drawing.Size(67, 38);
            this.buttonSendM.TabIndex = 23;
            this.buttonSendM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSendM.UseVisualStyleBackColor = false;
            this.buttonSendM.Click += new System.EventHandler(this.ButtonSendM_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.buttonExit.BackgroundImage = global::UChat.Properties.Resources.guanbi3;
            this.buttonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.buttonExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonExit.ForeColor = System.Drawing.Color.White;
            this.buttonExit.Location = new System.Drawing.Point(1234, 1);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(45, 30);
            this.buttonExit.TabIndex = 4;
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // panelLANBar
            // 
            this.panelLANBar.AutoScroll = true;
            this.panelLANBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(33)))), ((int)(((byte)(42)))));
            this.panelLANBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelLANBar.Controls.Add(this.panel2);
            this.panelLANBar.Controls.Add(this.panelEmpty);
            this.panelLANBar.Location = new System.Drawing.Point(51, 1);
            this.panelLANBar.Name = "panelLANBar";
            this.panelLANBar.Size = new System.Drawing.Size(367, 718);
            this.panelLANBar.TabIndex = 6;
            this.panelLANBar.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelLANBar_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel2.ForeColor = System.Drawing.Color.Transparent;
            this.panel2.Location = new System.Drawing.Point(6, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 100);
            this.panel2.TabIndex = 1;
            this.panel2.Visible = false;
            this.panel2.MouseEnter += new System.EventHandler(this.Panel2_MouseEnter);
            this.panel2.MouseLeave += new System.EventHandler(this.Panel2_MouseLeave);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.DarkOrange;
            this.label7.Location = new System.Drawing.Point(16, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 29);
            this.label7.TabIndex = 3;
            this.label7.Text = " ◉ 未读消息 ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Visible = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(323, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "杰哥不要啊杰哥不要啊杰哥不要啊啊";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(125)))), ((int)(((byte)(236)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 100);
            this.label1.TabIndex = 1;
            // 
            // panelEmpty
            // 
            this.panelEmpty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(33)))), ((int)(((byte)(42)))));
            this.panelEmpty.Controls.Add(this.pictureBoxEmptyIcon);
            this.panelEmpty.Controls.Add(this.labelEmptyText);
            this.panelEmpty.Location = new System.Drawing.Point(6, 172);
            this.panelEmpty.Name = "panelEmpty";
            this.panelEmpty.Size = new System.Drawing.Size(355, 330);
            this.panelEmpty.TabIndex = 0;
            // 
            // pictureBoxEmptyIcon
            // 
            this.pictureBoxEmptyIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(33)))), ((int)(((byte)(42)))));
            this.pictureBoxEmptyIcon.BackgroundImage = global::UChat.Properties.Resources.kong;
            this.pictureBoxEmptyIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxEmptyIcon.Location = new System.Drawing.Point(0, 47);
            this.pictureBoxEmptyIcon.Name = "pictureBoxEmptyIcon";
            this.pictureBoxEmptyIcon.Size = new System.Drawing.Size(355, 174);
            this.pictureBoxEmptyIcon.TabIndex = 4;
            this.pictureBoxEmptyIcon.TabStop = false;
            // 
            // labelEmptyText
            // 
            this.labelEmptyText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(33)))), ((int)(((byte)(42)))));
            this.labelEmptyText.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.labelEmptyText.ForeColor = System.Drawing.Color.White;
            this.labelEmptyText.Location = new System.Drawing.Point(3, 245);
            this.labelEmptyText.Name = "labelEmptyText";
            this.labelEmptyText.Size = new System.Drawing.Size(337, 29);
            this.labelEmptyText.TabIndex = 3;
            this.labelEmptyText.Text = "这里是空的呢~";
            this.labelEmptyText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerPercent
            // 
            this.timerPercent.Interval = 50;
            this.timerPercent.Tick += new System.EventHandler(this.TimerPercent_Tick);
            // 
            // panelSetting
            // 
            this.panelSetting.AutoScroll = true;
            this.panelSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(33)))), ((int)(((byte)(42)))));
            this.panelSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSetting.Controls.Add(this.panelChangeName);
            this.panelSetting.Location = new System.Drawing.Point(51, 1);
            this.panelSetting.Name = "panelSetting";
            this.panelSetting.Size = new System.Drawing.Size(367, 718);
            this.panelSetting.TabIndex = 26;
            // 
            // panelChangeName
            // 
            this.panelChangeName.AutoScroll = true;
            this.panelChangeName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panelChangeName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelChangeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelChangeName.Controls.Add(this.textBoxChangeName);
            this.panelChangeName.Controls.Add(this.label8);
            this.panelChangeName.Controls.Add(this.buttonCancelChange);
            this.panelChangeName.Controls.Add(this.buttonConfirmChange);
            this.panelChangeName.Location = new System.Drawing.Point(14, 234);
            this.panelChangeName.Name = "panelChangeName";
            this.panelChangeName.Size = new System.Drawing.Size(339, 245);
            this.panelChangeName.TabIndex = 27;
            // 
            // textBoxChangeName
            // 
            this.textBoxChangeName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.textBoxChangeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxChangeName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxChangeName.ForeColor = System.Drawing.Color.White;
            this.textBoxChangeName.Location = new System.Drawing.Point(21, 102);
            this.textBoxChangeName.MaxLength = 16;
            this.textBoxChangeName.Name = "textBoxChangeName";
            this.textBoxChangeName.Size = new System.Drawing.Size(297, 29);
            this.textBoxChangeName.TabIndex = 35;
            this.textBoxChangeName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(103, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 21);
            this.label8.TabIndex = 34;
            this.label8.Text = "请输入新的用户名：";
            // 
            // buttonCancelChange
            // 
            this.buttonCancelChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.buttonCancelChange.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCancelChange.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.buttonCancelChange.FlatAppearance.BorderSize = 0;
            this.buttonCancelChange.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.buttonCancelChange.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.buttonCancelChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelChange.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCancelChange.ForeColor = System.Drawing.Color.White;
            this.buttonCancelChange.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancelChange.Location = new System.Drawing.Point(21, 186);
            this.buttonCancelChange.Name = "buttonCancelChange";
            this.buttonCancelChange.Size = new System.Drawing.Size(105, 35);
            this.buttonCancelChange.TabIndex = 33;
            this.buttonCancelChange.Text = "取消";
            this.buttonCancelChange.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCancelChange.UseVisualStyleBackColor = false;
            // 
            // buttonConfirmChange
            // 
            this.buttonConfirmChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.buttonConfirmChange.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonConfirmChange.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.buttonConfirmChange.FlatAppearance.BorderSize = 0;
            this.buttonConfirmChange.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.buttonConfirmChange.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.buttonConfirmChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfirmChange.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonConfirmChange.ForeColor = System.Drawing.Color.White;
            this.buttonConfirmChange.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonConfirmChange.Location = new System.Drawing.Point(213, 186);
            this.buttonConfirmChange.Name = "buttonConfirmChange";
            this.buttonConfirmChange.Size = new System.Drawing.Size(105, 35);
            this.buttonConfirmChange.TabIndex = 32;
            this.buttonConfirmChange.Text = "保存";
            this.buttonConfirmChange.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonConfirmChange.UseVisualStyleBackColor = false;
            // 
            // FormMain
            // 
            this.AcceptButton = this.buttonSendM;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(125)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panelTips);
            this.Controls.Add(this.labelAlert);
            this.Controls.Add(this.labelChatBorder);
            this.Controls.Add(this.buttonSendM);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.buttonMin);
            this.Controls.Add(this.labelNameIndicator);
            this.Controls.Add(this.panelSideBar);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.labelChatBoxBG);
            this.Controls.Add(this.panelLANBar);
            this.Controls.Add(this.panelSetting);
            this.Controls.Add(this.panelFileBar);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UChat";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown);
            this.panelSideBar.ResumeLayout(false);
            this.panelDetail.ResumeLayout(false);
            this.panelDetail.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panelFileBar.ResumeLayout(false);
            this.panelPercent.ResumeLayout(false);
            this.panelConfirm.ResumeLayout(false);
            this.panelTips.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTips)).EndInit();
            this.panelLANBar.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelEmpty.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmptyIcon)).EndInit();
            this.panelSetting.ResumeLayout(false);
            this.panelChangeName.ResumeLayout(false);
            this.panelChangeName.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelChatBoxBG;
        private System.Windows.Forms.Panel panelLANBar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelSideBar;
        private System.Windows.Forms.Button buttonMenu;
        private System.Windows.Forms.Button buttonExit2;
        private System.Windows.Forms.Button buttonLAN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSetting;
        private System.Windows.Forms.RichTextBox richTextBoxChat;
        private System.Windows.Forms.Label labelNameIndicator;
        private System.Windows.Forms.Panel panelEmpty;
        private System.Windows.Forms.Label labelEmptyText;
        private System.Windows.Forms.PictureBox pictureBoxEmptyIcon;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button buttonMin;
        private System.Windows.Forms.Button buttonFiles;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Panel panelDetail;
        private System.Windows.Forms.Button buttonDetail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxUID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Label labelSideBarBorder;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonScrollToTheBottom;
        private System.Windows.Forms.Button buttonSendM;
        private System.Windows.Forms.Label labelChatBorder;
        private System.Windows.Forms.Panel panelFileBar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelTarget;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Label labelAlert;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelForbid;
        private System.Windows.Forms.Panel panelTips;
        private System.Windows.Forms.PictureBox pictureBoxTips;
        private System.Windows.Forms.Button buttonSelectFile;
        private System.Windows.Forms.Label labelWating;
        private System.Windows.Forms.Panel panelConfirm;
        private System.Windows.Forms.Button buttonRefuse;
        private System.Windows.Forms.Button buttonAcceptFTR;
        private System.Windows.Forms.Timer timerFTTimeout;
        public System.ComponentModel.BackgroundWorker backgroundWorkerFileReceiver;
        public System.ComponentModel.BackgroundWorker backgroundWorkerFileSender;
        public System.Windows.Forms.Panel panelPercent;
        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.Label labelPercent;
        private System.Windows.Forms.Timer timerPercent;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonCancelFTR;
        private System.Windows.Forms.Panel panelSetting;
        private System.Windows.Forms.Panel panelChangeName;
        private System.Windows.Forms.Button buttonCancelChange;
        private System.Windows.Forms.Button buttonConfirmChange;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxChangeName;
    }
}