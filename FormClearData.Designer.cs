namespace UChat
{
    partial class FormClearData
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
            this.panel = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.textBoxNewPW = new System.Windows.Forms.TextBox();
            this.buttonCancelChangePW = new System.Windows.Forms.Button();
            this.buttonSavePW = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panel.Controls.Add(this.labelError);
            this.panel.Controls.Add(this.label20);
            this.panel.Controls.Add(this.textBoxNewPW);
            this.panel.Controls.Add(this.buttonCancelChangePW);
            this.panel.Controls.Add(this.buttonSavePW);
            this.panel.Controls.Add(this.label8);
            this.panel.Location = new System.Drawing.Point(1, 1);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(656, 367);
            this.panel.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(11, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(595, 82);
            this.label8.TabIndex = 35;
            this.label8.Text = "警告：你将清空所有本机用户数据（包括聊天历史记录，但不包括已传输的文件），这个操作是不可挽回的！";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labelError.Location = new System.Drawing.Point(276, 212);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(106, 21);
            this.labelError.TabIndex = 45;
            this.labelError.Text = "密码不正确。";
            this.labelError.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(195, 128);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(266, 21);
            this.label20.TabIndex = 44;
            this.label20.Text = "需要输入密码以确认接下来的操作。";
            // 
            // textBoxNewPW
            // 
            this.textBoxNewPW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.textBoxNewPW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNewPW.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxNewPW.ForeColor = System.Drawing.Color.White;
            this.textBoxNewPW.Location = new System.Drawing.Point(177, 162);
            this.textBoxNewPW.MaxLength = 16;
            this.textBoxNewPW.Name = "textBoxNewPW";
            this.textBoxNewPW.Size = new System.Drawing.Size(297, 29);
            this.textBoxNewPW.TabIndex = 43;
            this.textBoxNewPW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxNewPW.UseSystemPasswordChar = true;
            // 
            // buttonCancelChangePW
            // 
            this.buttonCancelChangePW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.buttonCancelChangePW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCancelChangePW.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.buttonCancelChangePW.FlatAppearance.BorderSize = 0;
            this.buttonCancelChangePW.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.buttonCancelChangePW.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.buttonCancelChangePW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelChangePW.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCancelChangePW.ForeColor = System.Drawing.Color.White;
            this.buttonCancelChangePW.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancelChangePW.Location = new System.Drawing.Point(417, 321);
            this.buttonCancelChangePW.Name = "buttonCancelChangePW";
            this.buttonCancelChangePW.Size = new System.Drawing.Size(105, 35);
            this.buttonCancelChangePW.TabIndex = 42;
            this.buttonCancelChangePW.Text = "取消";
            this.buttonCancelChangePW.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCancelChangePW.UseVisualStyleBackColor = false;
            this.buttonCancelChangePW.Click += new System.EventHandler(this.ButtonCancelChangePW_Click);
            // 
            // buttonSavePW
            // 
            this.buttonSavePW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.buttonSavePW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSavePW.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.buttonSavePW.FlatAppearance.BorderSize = 0;
            this.buttonSavePW.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.buttonSavePW.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.buttonSavePW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSavePW.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSavePW.ForeColor = System.Drawing.Color.White;
            this.buttonSavePW.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSavePW.Location = new System.Drawing.Point(540, 321);
            this.buttonSavePW.Name = "buttonSavePW";
            this.buttonSavePW.Size = new System.Drawing.Size(105, 35);
            this.buttonSavePW.TabIndex = 41;
            this.buttonSavePW.Text = "继续";
            this.buttonSavePW.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSavePW.UseVisualStyleBackColor = false;
            this.buttonSavePW.Click += new System.EventHandler(this.ButtonSavePW_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(656, 367);
            this.panel1.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑 Light", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(31, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(614, 200);
            this.label3.TabIndex = 35;
            this.label3.Text = "本机用户数据已全部清空。";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑 Light", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(89, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(499, 73);
            this.label1.TabIndex = 36;
            this.label1.Text = "程序即将关闭。";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // FormClearData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(125)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(658, 369);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormClearData";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormClearData";
            this.TopMost = true;
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBoxNewPW;
        private System.Windows.Forms.Button buttonCancelChangePW;
        private System.Windows.Forms.Button buttonSavePW;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}