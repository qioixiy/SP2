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
    public partial class Form原料优选 : Form
    {
        Dictionary<string, int> chooseMap = new Dictionary<string, int>();

        SqlDataAdapter adapter常用原料 = new SqlDataAdapter("select * from dbo.常用原料", DBConnect.Instance().getConnectString());
        DataSet dSet常用原料 = new DataSet();

        public Form原料优选()
        {
            InitializeComponent();
                        
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

        private void updatelistView1(string selectStr)
        {
            bool selectAll = false;
            if (selectStr == "全部")
            {
                selectAll = true;
            }
            listView1.Items.Clear();

            foreach (DataRow dr in dSet常用原料.Tables[0].Rows)
            {
                string 原料分类 = (string)dr["原料分类"];

                if (selectAll || 原料分类 == selectStr)
                {
                    string 原料 = (string)dr["原料"];
                    string 价格 = (string)dr["价格(元/千克)"];
                    string 损耗率 = (string)dr["损耗率(%)"];
                    ListViewItem lvi = new ListViewItem();

                    lvi.SubItems.AddRange(new string[] { 原料, 价格, 损耗率});
                    lvi.Checked = (chooseMap[原料] != 0) ? true : false;
                    this.listView1.Items.Add(lvi);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form原料优选_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                return;
            }
            updatelistView1((string)comboBox1.Items[comboBox1.SelectedIndex]);
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {

        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            string s = e.Item.SubItems[1].Text;
            chooseMap[s] = e.Item.Checked ? 1 : 0;
        }
    }
}
