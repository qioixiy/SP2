using DataModel;
using SP.DataModel;
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
    public partial class FormLogin : Form
    {
        public FormLogin()//建立一个公共函数
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)//确定按钮
        {
            Dao用户 dao = new Dao用户();//实例化

            string user = "admin";//字符串 定义user等于admin，相当于调用用户数据库
            string passwd = textBox1.Text;//字符串等于textbox1输入的

            if (dao.verfiyWithUserPasswd(user, passwd))
            {
                Program.FormMainWindowInstance.mUserContext.UserName = user;//？
                DialogResult = DialogResult.OK;//密码正确，ok.
            }
            else
            {
                MessageBox.Show("密码不正确");//用户密码不对，
                textBox1.Focus();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)//取消按钮，关闭窗口
        {
            Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//输入密码是对的
            {
                this.buttonOk.Focus();
                buttonOk_Click(sender, e);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            label1.BackColor = System.Drawing.Color.Transparent;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
