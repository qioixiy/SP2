using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DataModel;
using SP.Utils;

namespace SP
{
    public partial class Form食谱调用 : Form
    {
        SqlDataAdapter adapter食谱 = new SqlDataAdapter("select * from dbo.食谱", DBConnect.Instance().getConnectString());
        DataSet dSet食谱 = new DataSet();

        public Form食谱调用()
        {
            InitializeComponent();

            adapter食谱.Fill(dSet食谱);
            Common.dumpDataSet(dSet食谱);
        }

        private void Form食谱调用_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("全部");
            comboBox2.Items.Add("全部");
            comboBox3.Items.Add("全部");
            comboBox4.Items.Add("全部");
            comboBox5.Items.Add("全部");

            object[] objs = Common.getItemsFromDataSet(dSet食谱, "名称");
            listBox1.Items.AddRange(objs);

            objs = Common.getUniqueItemsFromDataSet(dSet食谱, "单位");
            comboBox1.Items.AddRange(objs);
            objs = Common.getUniqueItemsFromDataSet(dSet食谱, "灶别");
            comboBox2.Items.AddRange(objs);
            objs = Common.getUniqueItemsFromDataSet(dSet食谱, "地区");
            comboBox3.Items.AddRange(objs);
            objs = Common.getUniqueItemsFromDataSet(dSet食谱, "季节");
            comboBox4.Items.AddRange(objs);
            objs = Common.getUniqueItemsFromDataSet(dSet食谱, "食谱来源");
            comboBox5.Items.AddRange(objs);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("请选择一项");
                return;
            }

            Program.FormMainWindowInstance.mUserContext.当前食谱 = listBox1.SelectedItem.ToString();

            MessageBox.Show("调用成功");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
