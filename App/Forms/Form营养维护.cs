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

namespace SP
{
    public partial class Form营养维护 : Form
    {
        SqlDataAdapter adapter营养维护 = new SqlDataAdapter("select * from dbo.营养维护", DBConnect.Instance().getConnectString());
        DataSet dSet营养维护 = new DataSet();

        public Form营养维护()
        {
            InitializeComponent();
        }

        private void Form营养维护_Load(object sender, EventArgs e)
        {
            adapter营养维护.Fill(dSet营养维护);

            //Common.dumpDataSet(dSet营养维护);

            comboBox1.Items.Add("全部");
            comboBox1.Items.AddRange(get分类());

            updateListBoxBy分类("全部");

            updateTextByIndex(0);

            updateTextReadOnly(true);
        }

        private void updateTextReadOnly(bool b)
        {
            textBox2.ReadOnly = b;
            textBox3.ReadOnly = b;
            textBox4.ReadOnly = b;
            textBox5.ReadOnly = b;
            textBox6.ReadOnly = b;
            textBox7.ReadOnly = b;
            textBox8.ReadOnly = b;
            textBox9.ReadOnly = b;
            textBox10.ReadOnly = b;
            textBox11.ReadOnly = b;
            textBox12.ReadOnly = b;
            textBox13.ReadOnly = b;
            textBox14.ReadOnly = b;
            textBox15.ReadOnly = b;
            textBox16.ReadOnly = b;
            textBox17.ReadOnly = b;
            textBox18.ReadOnly = b;
            textBox19.ReadOnly = b;
            textBox20.ReadOnly = b;
            textBox21.ReadOnly = b;
            textBox22.ReadOnly = b;
            textBox23.ReadOnly = b;
            textBox24.ReadOnly = b;
            textBox25.ReadOnly = b;
        }

        private object[] get分类()
        {
            Dictionary<string, int> map = new Dictionary<string, int>();

            foreach (DataTable dt in dSet营养维护.Tables)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string str = (string)dr["分类"];
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

        private object[] get所有原料名称()
        {
            Dictionary<string, int> map = new Dictionary<string, int>();

            foreach (DataTable dt in dSet营养维护.Tables)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string str = (string)dr["原料名称"];
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

        private void updateTextByIndex(int index)
        {
            textBox2.Text = (string)dSet营养维护.Tables[0].Rows[index]["原料名称"];
            textBox3.Text = (string)dSet营养维护.Tables[0].Rows[index]["可食部"];
            textBox4.Text = (string)dSet营养维护.Tables[0].Rows[index]["蛋白质"];
            textBox5.Text = (string)dSet营养维护.Tables[0].Rows[index]["脂肪"];
            textBox6.Text = (string)dSet营养维护.Tables[0].Rows[index]["胡萝卜素"];
            textBox7.Text = (string)dSet营养维护.Tables[0].Rows[index]["维生素A"];
            textBox8.Text = (string)dSet营养维护.Tables[0].Rows[index]["维生素E23"];
            textBox9.Text = (string)dSet营养维护.Tables[0].Rows[index]["维生素E1"];
            textBox10.Text = (string)dSet营养维护.Tables[0].Rows[index]["维生素E4"];
            textBox11.Text = (string)dSet营养维护.Tables[0].Rows[index]["维生素B1"];
            textBox12.Text = (string)dSet营养维护.Tables[0].Rows[index]["维生素PP"];
            textBox13.Text = (string)dSet营养维护.Tables[0].Rows[index]["维生素B2"];
            textBox14.Text = (string)dSet营养维护.Tables[0].Rows[index]["维生素C"];
            textBox15.Text = (string)dSet营养维护.Tables[0].Rows[index]["铁"];
            textBox16.Text = (string)dSet营养维护.Tables[0].Rows[index]["镁"];
            textBox17.Text = (string)dSet营养维护.Tables[0].Rows[index]["糖"];
            textBox18.Text = (string)dSet营养维护.Tables[0].Rows[index]["胆固醇"];
            textBox19.Text = (string)dSet营养维护.Tables[0].Rows[index]["硒"];
            textBox20.Text = (string)dSet营养维护.Tables[0].Rows[index]["铜"];
            textBox21.Text = (string)dSet营养维护.Tables[0].Rows[index]["锌"];
            textBox22.Text = (string)dSet营养维护.Tables[0].Rows[index]["钙"];
            textBox23.Text = (string)dSet营养维护.Tables[0].Rows[index]["锰"];
            textBox24.Text = (string)dSet营养维护.Tables[0].Rows[index]["钠"];
            textBox25.Text = (string)dSet营养维护.Tables[0].Rows[index]["钾"];
        }

        private int getIndexBy原料名称(string 原料名称)
        {
            int index = 0;
            foreach (DataTable dt in dSet营养维护.Tables)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string str = (string)dr["原料名称"];
                    if (原料名称 == str)
                    {
                        return index;
                    }
                    index++;
                }
            }
            return -1;
        }

        private void updateTextBy原料名称(string 原料名称)
        {
            int index = getIndexBy原料名称(原料名称);

            if (index < 0)
            {
                MessageBox.Show("没有找到原料名称:" + 原料名称);
                return;
            }

            textBox2.Text = (string)dSet营养维护.Tables[0].Rows[index]["原料名称"];
            textBox3.Text = (string)dSet营养维护.Tables[0].Rows[index]["可食部"];
            textBox4.Text = (string)dSet营养维护.Tables[0].Rows[index]["蛋白质"];
            textBox5.Text = (string)dSet营养维护.Tables[0].Rows[index]["脂肪"];
            textBox6.Text = (string)dSet营养维护.Tables[0].Rows[index]["胡萝卜素"];
            textBox7.Text = (string)dSet营养维护.Tables[0].Rows[index]["维生素A"];
            textBox8.Text = (string)dSet营养维护.Tables[0].Rows[index]["维生素E23"];
            textBox9.Text = (string)dSet营养维护.Tables[0].Rows[index]["维生素E1"];
            textBox10.Text = (string)dSet营养维护.Tables[0].Rows[index]["维生素E4"];
            textBox11.Text = (string)dSet营养维护.Tables[0].Rows[index]["维生素B1"];
            textBox12.Text = (string)dSet营养维护.Tables[0].Rows[index]["维生素PP"];
            textBox13.Text = (string)dSet营养维护.Tables[0].Rows[index]["维生素B2"];
            textBox14.Text = (string)dSet营养维护.Tables[0].Rows[index]["维生素C"];
            textBox15.Text = (string)dSet营养维护.Tables[0].Rows[index]["铁"];
            textBox16.Text = (string)dSet营养维护.Tables[0].Rows[index]["镁"];
            textBox17.Text = (string)dSet营养维护.Tables[0].Rows[index]["糖"];
            textBox18.Text = (string)dSet营养维护.Tables[0].Rows[index]["胆固醇"];
            textBox19.Text = (string)dSet营养维护.Tables[0].Rows[index]["硒"];
            textBox20.Text = (string)dSet营养维护.Tables[0].Rows[index]["铜"];
            textBox21.Text = (string)dSet营养维护.Tables[0].Rows[index]["锌"];
            textBox22.Text = (string)dSet营养维护.Tables[0].Rows[index]["钙"];
            textBox23.Text = (string)dSet营养维护.Tables[0].Rows[index]["锰"];
            textBox24.Text = (string)dSet营养维护.Tables[0].Rows[index]["钠"];
            textBox25.Text = (string)dSet营养维护.Tables[0].Rows[index]["钾"];
        }

        private void updateListBoxBy分类(string 分类)
        {
            listBox1.Items.Clear();

            Dictionary<string, int> map = new Dictionary<string, int>();

            foreach (DataTable dt in dSet营养维护.Tables)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string str = (string)dr["分类"];
                    if (分类 == "全部" || str == 分类)
                    {
                        string tmp = (string)dr["原料名称"];
                        if (map.ContainsKey(tmp))
                        {
                            map[tmp]++;
                        }
                        else
                        {
                            map.Add(tmp, 1);
                        }
                    }
                    Console.Write(str);
                }
            }
            object[] objs = new object[map.Count];

            int index = 0;
            foreach (KeyValuePair<string, int> pair in map)
            {
                objs[index++] = pair.Key;
            }
            listBox1.Items.AddRange(objs);
        }

        private void searchText()
        {
            object[] 所有原料名称 = get所有原料名称();

            listBox1.Items.Clear();

            foreach (object obj in 所有原料名称)
            {
                string text = (string)obj;

                string pat = textBox26.Text;

                Regex r = new Regex(pat, RegexOptions.IgnoreCase);
                Match m = r.Match(text);
                if (m.Success)
                {
                    listBox1.Items.Add(text);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            searchText();
        }

        private void syncToDB营养维护()
        {
            int index = getIndexBy原料名称(textBox2.Text);
            
            Console.WriteLine(index);
            Common.dumpDataSet(dSet营养维护);

            dSet营养维护.Tables[0].Rows[index]["原料名称"] = textBox2.Text;
            dSet营养维护.Tables[0].Rows[index]["可食部"] = textBox3.Text;
            dSet营养维护.Tables[0].Rows[index]["蛋白质"] = textBox4.Text;
            dSet营养维护.Tables[0].Rows[index]["脂肪"] = textBox5.Text;
            dSet营养维护.Tables[0].Rows[index]["胡萝卜素"] = textBox6.Text;
            dSet营养维护.Tables[0].Rows[index]["维生素A"] = textBox7.Text;
            dSet营养维护.Tables[0].Rows[index]["维生素E23"] = textBox8.Text;
            dSet营养维护.Tables[0].Rows[index]["维生素E1"] = textBox9.Text;
            dSet营养维护.Tables[0].Rows[index]["维生素E4"] = textBox10.Text;
            dSet营养维护.Tables[0].Rows[index]["维生素B1"] = textBox11.Text;
            dSet营养维护.Tables[0].Rows[index]["维生素PP"] = textBox12.Text;
            dSet营养维护.Tables[0].Rows[index]["维生素B2"] = textBox13.Text;
            dSet营养维护.Tables[0].Rows[index]["维生素C"] = textBox14.Text;
            dSet营养维护.Tables[0].Rows[index]["铁"] = textBox15.Text;
            dSet营养维护.Tables[0].Rows[index]["镁"] = textBox16.Text;
            dSet营养维护.Tables[0].Rows[index]["糖"] = textBox17.Text;
            dSet营养维护.Tables[0].Rows[index]["胆固醇"] = textBox18.Text;
            dSet营养维护.Tables[0].Rows[index]["硒"] = textBox19.Text;
            dSet营养维护.Tables[0].Rows[index]["铜"] = textBox20.Text;
            dSet营养维护.Tables[0].Rows[index]["锌"] = textBox21.Text;
            dSet营养维护.Tables[0].Rows[index]["钙"] = textBox22.Text;
            dSet营养维护.Tables[0].Rows[index]["锰"] = textBox23.Text;
            dSet营养维护.Tables[0].Rows[index]["钠"] = textBox24.Text;
            dSet营养维护.Tables[0].Rows[index]["钾"] = textBox25.Text;

            Common.dumpDataSet(dSet营养维护);

            SqlCommandBuilder sql_command = new SqlCommandBuilder(adapter营养维护);
            adapter营养维护.Update(dSet营养维护.Tables[0]);

            MessageBox.Show("保存成功");
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "修改")
            {
                button2.Text = "保存";
                updateTextReadOnly(false);
            }
            else
            {
                button2.Text = "修改";
                updateTextReadOnly(true);
                syncToDB营养维护();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateListBoxBy分类((string)comboBox1.Items[comboBox1.SelectedIndex]);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                updateTextBy原料名称((string)listBox1.Items[listBox1.SelectedIndex]);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox26_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchText();
            }
        }
    }
}
