using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SP.Forms
{
    public partial class Form外购清单调用 : Form
    {
        public Form外购清单调用()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                return;
            }

            if (comboBox1.Text == "请选择")
            {
                MessageBox.Show("请选择");
                return;
            }

            string 外购清单 = comboBox1.Text;

            Program.FormMainWindowInstance.mUserContext.当前外购清单 = 外购清单;

            MessageBox.Show("调用外购清单成功:" + 外购清单);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form外购清单调用_Load(object sender, EventArgs e)
        {
            SqlData tSqlData = SqlDataPool.Instance().GetSqlDataByName("外购清单");

            object[] objs = Utils.Common.getUniqueItemsFromDataSet(tSqlData.mDataSet, "名称");

            comboBox1.Items.AddRange(objs); 
        }
    }
}
