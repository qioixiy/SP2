using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SP.Forms
{
    public partial class Form外购清单生成 : Form
    {
        public Form外购清单生成()
        {
            InitializeComponent();
        }

        private void Form外购清单生成_Load(object sender, EventArgs e)
        {
            SqlData tSqlData = SqlDataPool.Instance().GetSqlDataByName("食谱");

            object[] objs = Utils.Common.getUniqueItemsFromDataSet(tSqlData.mDataSet, "名称");

            comboBox1.Items.AddRange(objs);
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

            string 食谱名称 = comboBox1.Text;
            if (gen外购清单By食谱名称(食谱名称))
            {
                MessageBox.Show("外购清单生成成功");
            }
            else
            {
                MessageBox.Show("外购清单生成失败");
            }
        }

        private bool gen外购清单By食谱名称(string 食谱名称)
        {
            SqlData tSqlData = SqlDataPool.Instance().GetSqlDataByName("外购清单");

            DataRow dr = tSqlData.mDataSet.Tables[0].NewRow();
            
            dr["对应食谱名称"] = 食谱名称;
            dr["名称"] = 食谱名称+"外购清单";

            tSqlData.mDataSet.Tables[0].Rows.Add(dr);

            SqlCommandBuilder sql_command = new SqlCommandBuilder(tSqlData.mSqlDataAdapter);
            tSqlData.mSqlDataAdapter.Update(tSqlData.mDataSet.Tables[0]);

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
