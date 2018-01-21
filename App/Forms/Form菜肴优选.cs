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
using System.Text.RegularExpressions;

namespace SP.Forms
{
    public partial class Form菜肴优选 : Form
    {
        SqlDataAdapter adapter常用菜肴 = new SqlDataAdapter("select * from dbo.常用菜肴", DBConnect.Instance().getConnectString());
        DataSet dSet常用菜肴 = new DataSet();

        public Form菜肴优选()
        {
            InitializeComponent();
        }

        private void Form菜肴优选_Load(object sender, EventArgs e)
        {
            adapter常用菜肴.Fill(dSet常用菜肴);
            dSet常用菜肴 = new DataSet();
            adapter常用菜肴.Fill(dSet常用菜肴);
            Common.dumpDataSet(dSet常用菜肴);

            comboBox1.Items.Add("全部");
            comboBox1.Items.AddRange(get所有常用菜肴());

            updateCheckedListBox1("全部");
        }

        private object[] get所有常用菜肴()
        {
            return Common.getUniqueItemsFromDataSet(dSet常用菜肴, "菜肴类型");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void updateCheckedListBox1(string selectStr)
        {
            bool selectAll = false;
            if (selectStr == "全部")
            {
                selectAll = true;
            }
            checkedListBox1.Items.Clear();

            foreach (DataRow dr in dSet常用菜肴.Tables[0].Rows)
            {
                string 菜肴类型 = (string)dr["菜肴类型"];

                if (selectAll || 菜肴类型 == selectStr)
                {
                    string str = (string)dr["菜肴名称"];
                    Console.Write(str);
                    checkedListBox1.Items.Add(str);
                }
            }
        }

        private void updateTextBox1(string selectStr)
        {
            foreach (DataRow dr in dSet常用菜肴.Tables[0].Rows)
            {
                string 菜肴名称 = (string)dr["菜肴名称"];

                if (菜肴名称 == selectStr)
                {
                    string str = 菜肴名称;
                    Console.Write(str);

                    textBox1.Text = (string)dr["菜肴用料"];
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateCheckedListBox1((string)comboBox1.Items[comboBox1.SelectedIndex]);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectStr = (string)checkedListBox1.Items[checkedListBox1.SelectedIndex];
            updateTextBox1(selectStr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();

            string likeStr = textBox2.Text;

            foreach (DataRow dr in dSet常用菜肴.Tables[0].Rows)
            {
                string 菜肴名称 = (string)dr["菜肴名称"];

                string pat = likeStr;

                Regex r = new Regex(pat, RegexOptions.IgnoreCase);
                Match m = r.Match(菜肴名称);
                if (m.Success)
                {
                    string str = 菜肴名称;
                    Console.Write(str);

                    checkedListBox1.Items.Add(str);
                }
            }
        }
    }
}
