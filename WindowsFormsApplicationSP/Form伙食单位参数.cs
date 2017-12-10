using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplicationSP
{
    public partial class Form伙食单位参数 : Form
    {
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

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Form伙食单位参数_Load(object sender, EventArgs e)
        {
            listView1.GridLines = true;//表格是否显示网格线
            listView1.FullRowSelect = true;//是否选中整行

            listView1.View = View.Details;//设置显示方式
            listView1.Scrollable = true;//是否自动显示滚动条
            listView1.MultiSelect = false;//是否可以选择多行

            ////添加表头（列）
            //listView1.Columns.Add("ProductName", "产品名称");
            //listView1.Columns.Add("SN", "产品型号");
            //listView1.Columns.Add("Price", "价格");
            //listView1.Columns.Add("Number", "数量");

            //添加表格内容
            for (int i = 0; i < 3; i++)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Clear();

                item.SubItems[0].Text = "产品" + i.ToString();
                item.SubItems.Add(i.ToString());
                item.SubItems.Add((i + 7).ToString());
                item.SubItems.Add((i * i).ToString());
                listView1.Items.Add(item);
            }

            //listView1.Columns["ProductName"].Width = -1;//根据内容设置宽度
            //listView1.Columns["SN"].Width = -2;//根据标题设置宽度

            //listView1.Columns["Price"].Width = -2;
            //listView1.Columns["Number"].Width = -2;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
