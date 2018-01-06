using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SP.DataModel;
using DataModel;
using System.Data.SqlClient;

namespace SP
{
    public partial class Form伙食单位参数 : Form
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

        public Form伙食单位参数()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //创建命令重建对象  
            SqlCommandBuilder scb = new SqlCommandBuilder(adapter);

            //更新数据  
            try
            {
                upadte();

                MessageBox.Show("修改成功");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                upadte();

                MessageBox.Show("添加成功");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            upadte();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Form伙食单位参数_Load(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("select * from 伙食单位参数", strConn);
            dSet = new DataSet();
            adapter.Fill(dSet);
            dataGridView1.DataSource = dSet.Tables[0];
            //adapter.Fill(dSet, "t1");
            //dataGridView1.DataSource = dSet;
            //dataGridView1.DataMember = "t1";

            return;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void upadte()
        {
            SqlCommandBuilder sql_command = new SqlCommandBuilder(adapter);
            adapter.Update(dSet.Tables[0]);
        }
    }
}
