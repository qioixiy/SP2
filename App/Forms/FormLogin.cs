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
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Dao用户 dao = new Dao用户();

            string user = "admin";
            string passwd = textBox1.Text;

            if (dao.verfiyWithUserPasswd(user, passwd))
            {
                Program.FormMainWindowInstance.mUserContext.UserName = user;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("密码不正确");
                textBox1.Focus();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.buttonOk.Focus();
                buttonOk_Click(sender, e);
            }
        }
    }
}
