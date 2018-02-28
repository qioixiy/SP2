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
    public partial class Form选定常用菜肴 : Form
    {
        Dictionary<string, int> chooseMap = new Dictionary<string, int>();

        SqlDataAdapter adapter常用菜肴 = new SqlDataAdapter("select * from dbo.常用菜肴", DBConnect.Instance().getConnectString());
        DataSet dSet常用菜肴 = new DataSet();

        public Form选定常用菜肴()
        {
            InitializeComponent();

            adapter常用菜肴.Fill(dSet常用菜肴);
            Common.dumpDataSet(dSet常用菜肴);

            comboBox1.Items.Add("全部");
            comboBox1.Items.AddRange(get所有常用菜肴());

            foreach (DataTable dt in dSet常用菜肴.Tables)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    object[] items = dr.ItemArray;
                    string str = (string)dr["菜肴名称"];
                    chooseMap[str] = 0;
                }
            }

            updatelistView1("全部");
        }

        private void Form选定常用菜肴_Load(object sender, EventArgs e)
        {
            ;
        }

        private object[] get所有常用菜肴()
        {
            return Common.getUniqueItemsFromDataSet(dSet常用菜肴, "菜肴类型");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void updatelistView1(string selectStr)
        {
            bool selectAll = false;
            if (selectStr == "全部")
            {
                selectAll = true;
            }
            listView1.Items.Clear();

            foreach (DataRow dr in dSet常用菜肴.Tables[0].Rows)
            {
                string 菜肴类型 = (string)dr["菜肴类型"];

                if (selectAll || 菜肴类型 == selectStr)
                {
                    string str = (string)dr["菜肴名称"];
                    ListViewItem lvi = new ListViewItem();

                    lvi.SubItems.AddRange(new string[] { str });
                    lvi.Checked = (chooseMap[str] != 0) ? true : false;
                    this.listView1.Items.Add(lvi);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                return;
            }
            updatelistView1((string)comboBox1.Items[comboBox1.SelectedIndex]);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ;
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            string s = e.Item.SubItems[1].Text;
            chooseMap[s] = e.Item.Checked ? 1 : 0;
        }

        private void updateTextBox1(string selectStr)
        {
            foreach (DataRow dr in dSet常用菜肴.Tables[0].Rows)
            {
                string 菜肴名称 = (string)dr["菜肴名称"];

                if (菜肴名称 == selectStr)
                {
                    string 菜肴用料 = 菜肴名称 + "需要下列原料：\n";
                    if (dr["用料1"].ToString() != "") 菜肴用料 += dr["用料1"] + " " + dr["用量1"];
                    if (dr["用料2"].ToString() != "") 菜肴用料 += "," + dr["用料2"] + " " + dr["用量2"];
                    if (dr["用料3"].ToString() != "") 菜肴用料 += "," + dr["用料3"] + " " + dr["用量3"];
                    if (dr["用料4"].ToString() != "") 菜肴用料 += "," + dr["用料4"] + " " + dr["用量4"];
                    if (dr["用料5"].ToString() != "") 菜肴用料 += "," + dr["用料5"] + " " + dr["用量5"];

                    textBox1.Text = 菜肴用料;
                }
            }
        }
        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            string s = e.Item.SubItems[1].Text;

            updateTextBox1(s);
        }
    }
}
