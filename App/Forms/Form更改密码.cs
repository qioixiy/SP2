using DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP
{
    public partial class Form更改密码 : Form
    {
        /// <summary>  
        /// 数据适配器  
        /// </summary>  
        SqlDataAdapter adapter = null;
        /// <summary>  
        /// 数据集对象  
        /// </summary>  
        DataSet dSet = null;

        /// <summary>  
        /// 连接字符串  
        /// </summary>  
        private static string strConn = LocalDBConnect.Instance().getConnectString();

        public Form更改密码()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
            {
                MessageBox.Show("密码不能为空");
                return;
            }
            if (textBox2.Text == textBox3.Text)
            {
                string user = Program.FormMainWindowInstance.mUserContext.UserName;
                string oldpasswd = textBox1.Text;
                string sql = "select* from dbo.用户 where 用户 = '" + user + "' and 密码 = '" + oldpasswd + "'";

                adapter = new SqlDataAdapter(sql, strConn);
                dSet = new DataSet();
                adapter.Fill(dSet);

                if (dSet.Tables[0].Rows.Count < 1)
                {
                    MessageBox.Show("当前密码错误");
                    return;
                }

                Utils.Common.dumpDataSet(dSet);
                string newPasswd = textBox2.Text;
                dSet.Tables[0].Rows[0]["密码"] = newPasswd;
                Utils.Common.dumpDataSet(dSet);

                SqlCommandBuilder sql_command = new SqlCommandBuilder(adapter);
                adapter.Update(dSet.Tables[0]);

                MessageBox.Show("密码修改成功");
            }
            else
            {
                MessageBox.Show("修改的密码不一致");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form更改密码_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
                button1_Click(sender, e);
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
                button1_Click(sender, e);
            }
        }
    }
}
