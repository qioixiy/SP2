using DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP
{
    public partial class FormSplashScreen : Form//splashsreen意思是启动画面
    {
        public FormSplashScreen()
        {
            InitializeComponent();
        }

        private void FormSplashScreen_Load(object sender, EventArgs e)
        {
            ;
        }

        private void FormSplashScreen_Click(object sender, EventArgs e)//单击窗体
        {
            DialogResult result = Program.FormLoginInstance.ShowDialog();//调用在program主程序中创建的函数
            if (result == DialogResult.Cancel)
            {
                ;
            }
            else if (result == DialogResult.OK)
            {
                Program.FormMainWindowInstance.ShowDialog();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
