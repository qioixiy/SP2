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

namespace SP.Forms
{
    public partial class Form预定菜肴 : Form
    {
        Dictionary<string, int> chooseMap = new Dictionary<string, int>();

        SqlDataAdapter adapter常用原料 = new SqlDataAdapter("select * from dbo.常用原料", DBConnect.Instance().getConnectString());
        DataSet dSet常用原料 = new DataSet();

        SqlDataAdapter adapter常用菜肴 = new SqlDataAdapter("select * from dbo.常用菜肴", DBConnect.Instance().getConnectString());
        DataSet dSet常用菜肴 = new DataSet();

        public Form预定菜肴()
        {
            InitializeComponent();

            adapter常用菜肴.Fill(dSet常用菜肴);
            Common.dumpDataSet(dSet常用菜肴);

            foreach (DataRow dr in dSet常用菜肴.Tables[0].Rows)
            {
                string str = (string)dr["菜肴名称"];
                chooseMap[str] = 0;
            }

            adapter常用原料.Fill(dSet常用原料);
            Common.dumpDataSet(dSet常用原料);

            comboBox1.Items.Add("全部");
            comboBox1.Items.AddRange(get所有原料分类());

            foreach (DataTable dt in dSet常用原料.Tables)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    object[] items = dr.ItemArray;
                    string str = (string)dr["原料"];
                    chooseMap[str] = 0;
                }
            }

            updatelistView1("全部");

            updatelistBox1("全部");

            //
            comboBox2.Items.Add("全部");
            comboBox2.Items.AddRange(get所有常用菜肴());
            
            updateListView2("全部");
        }

        private void Form预定菜肴_Load(object sender, EventArgs e)
        {

        }

        private object[] get所有常用菜肴()
        {
            return Common.getUniqueItemsFromDataSet(dSet常用菜肴, "菜肴类型");
        }
        private void updatelistBox1(string selectStr)
        {
            bool selectAll = false;
            if (selectStr == "全部")
            {
                selectAll = true;
            }
            listBox1.Items.Clear();

            foreach (DataRow dr in dSet常用原料.Tables[0].Rows)
            {
                string 原料分类 = (string)dr["原料分类"];

                if (selectAll || 原料分类 == selectStr)
                {
                    string 原料 = (string)dr["原料"];

                    listBox1.Items.AddRange(new string[] {原料});
                }
            }
        }

        private object[] getUniqueItemsFromDataSet(DataSet dataSet, string rowName)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();

            foreach (DataTable dt in dataSet.Tables)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string str = (string)dr[rowName];
                    if (map.ContainsKey(str))
                    {
                        map[str]++;
                    }
                    else
                    {
                        map.Add(str, 1);
                    }
                    Console.Write(str);
                }
            }

            object[] ret = new object[map.Count];

            int index = 0;
            foreach (KeyValuePair<string, int> pair in map)
            {
                ret[index++] = pair.Key;
            }

            return ret;
        }

        private object[] get所有原料分类()
        {
            return getUniqueItemsFromDataSet(dSet常用原料, "原料分类");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                return;
            }
            string s = (string)comboBox1.Items[comboBox1.SelectedIndex];
            updatelistBox1(s);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex < 0)
            {
                return;
            }
            updateListView2((string)comboBox2.Items[comboBox2.SelectedIndex]);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView2_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            System.Text.StringBuilder b = new System.Text.StringBuilder();
            b.AppendFormat("{0}={1}", "isSelected", e.IsSelected);
            b.AppendFormat("{0}={1}", "item", e.Item);
            b.AppendFormat("{0}={1}", "itemIndex", e.ItemIndex);

            //MessageBox.Show(b.ToString(), "xxx");

            if (e.IsSelected)
            {
                string 菜肴 = e.Item.SubItems[1].Text;
                update菜肴细节(菜肴);
            }
        }

        private void update菜肴细节(string selectStr)
        {
            foreach (DataRow dr in dSet常用菜肴.Tables[0].Rows)
            {
                string 菜肴名称 = (string)dr["菜肴名称"];

                if (菜肴名称 == selectStr)
                {
                    textBox1.Text = 菜肴名称;

                    textBox2.Text = dr["用料1"].ToString();
                    textBox3.Text = dr["用量1"].ToString();

                    textBox4.Text = dr["用料2"].ToString();
                    textBox5.Text = dr["用量2"].ToString();

                    textBox6.Text = dr["用料3"].ToString();
                    textBox7.Text = dr["用量3"].ToString();

                    textBox8.Text = dr["用料4"].ToString();
                    textBox9.Text = dr["用量4"].ToString();

                    textBox10.Text = dr["用料5"].ToString();
                    textBox11.Text = dr["用量5"].ToString();

                }
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string 菜肴 = "x";
            update菜肴细节(菜肴);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void updatelistView1(string selectStr)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = (string)listBox1.Items[listBox1.SelectedIndex];

            //updateListView2("原料");
        }

        private void updateListView2(string 菜肴类型)
        {
            bool selectAll = false;
            if (菜肴类型 == "全部")
            {
                selectAll = true;
            }
            listView2.Items.Clear();

            foreach (DataRow dr in dSet常用菜肴.Tables[0].Rows)
            {
                string 菜肴类型2 = (string)dr["菜肴类型"];

                if (selectAll || 菜肴类型 == 菜肴类型2)
                {
                    string str = (string)dr["菜肴名称"];

                    ListViewItem lvi = new ListViewItem();
                    lvi.SubItems.AddRange(new string[] { str });
                    lvi.Checked = (chooseMap[str] != 0) ? true : false;
                    this.listView2.Items.Add(lvi);
                }
            }
        }

        private void updateCheckedListView()
        {
            listView3.Items.Clear();

            foreach (KeyValuePair<string, int> kv in chooseMap)
            {
                if (kv.Value != 0)
                {
                    listView3.Items.Add(kv.Key);
                }
            }
        }

        private void listView2_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            string s = e.Item.SubItems[1].Text;
            chooseMap[s] = e.Item.Checked ? 1 : 0;

            updateCheckedListView();
        }
    }
}
