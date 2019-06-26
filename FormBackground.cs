using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.IO;

namespace UChat
{
    public partial class FormBackground : Form
    {
        public FormBackground()
        {
            InitializeComponent();
        }

        private void FormBackground_Load(object sender, EventArgs e)
        {
            CheckFilesExist();
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
        }

        public static void CheckFilesExist()
        {
            if (Directory.Exists(CommonFoundations.directory_Path) == true && File.Exists(CommonFoundations.hostUsers_FilePath) == true)//若存在目录直接登录
            {
                CommonFoundations.fileExist = true;
            }
            else
            {
                CommonFoundations.fileExist = false;
            }
        }
    }
}
