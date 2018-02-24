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

namespace SP.Forms
{
    public partial class Form选定军粮品种 : Form
    {
        SqlDataAdapter adapter军粮品种 = new SqlDataAdapter("select * from dbo.军粮品种", DBConnect.Instance().getConnectString());
        DataSet dSet军粮品种 = new DataSet();

        public Form选定军粮品种()
        {
            InitializeComponent();

            adapter军粮品种.Fill(dSet军粮品种);

            object[] set = Utils.Common.getUniqueItemsFromDataSet(dSet军粮品种, "分类");
            comboBox1.Items.Add("全部军粮");
            comboBox1.Items.AddRange(set);

            foreach (DataTable dt in dSet军粮品种.Tables)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    object[] items = dr.ItemArray;
                    chooseMap[(string)items[2]] = (int)items[4];
                }
            }

            updateListView();
            updateInfo();
        }

        Dictionary<string, int> chooseMap = new Dictionary<string, int>();
        private void Form选定军粮品种_Load(object sender, EventArgs e)
        {
        }

        private void updateListView()
        {
            this.listView1.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度  

            listView1.Items.Clear();

            foreach (DataTable dt in dSet军粮品种.Tables)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    object[] items = dr.ItemArray;
                    ListViewItem lvi = new ListViewItem();

                    bool discard = true;
                    if (comboBox1.Text == "全部军粮")
                    {
                        discard = false;
                    }
                    else if ((string)items[1] == comboBox1.Text)
                    {
                        discard = false;
                    }
                    if (!discard)
                    {
                        lvi.SubItems.AddRange(new string[] { (string)items[2], (string)items[3] });
                        lvi.Checked = (chooseMap[(string)items[2]] != 0) ? true : false;
                        this.listView1.Items.Add(lvi);
                    }
                }
            }

            this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。
        }

        private void updateInfo()
        {
            int count大米 = 0, count面粉 = 0, count食油 = 0;
            
            foreach (DataTable dt in dSet军粮品种.Tables)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    object[] items = dr.ItemArray;
                    string 分类 = (string)items[1];
                    string 粮食种类 = (string)items[2];

                    if (chooseMap[粮食种类] != 0)
                    {
                        if (分类 == "大米")
                        {
                            count大米++;
                        }
                        else if (分类 == "面粉")
                        {
                            count面粉++;
                        }
                        else if (分类 == "食油")
                        {
                            count食油++;
                        }
                    }
                }
            }

            label3.Text = Convert.ToString(count大米);
            label4.Text = Convert.ToString(count面粉);
            label5.Text = Convert.ToString(count食油);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateListView();
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            string s = e.Item.SubItems[1].Text;
            chooseMap[s] = e.Item.Checked ? 1 : 0;

            updateInfo();
        }
    }
}
