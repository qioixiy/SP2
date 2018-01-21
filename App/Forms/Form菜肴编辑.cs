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
    public partial class Form菜肴编辑 : Form
    {
        SqlDataAdapter adapter常用菜肴 = new SqlDataAdapter("select * from dbo.常用菜肴", DBConnect.Instance().getConnectString());
        DataSet dSet常用菜肴 = new DataSet();

        public Form菜肴编辑()
        {
            InitializeComponent();
        }

        private void Form菜肴编辑_Load(object sender, EventArgs e)
        {
            adapter常用菜肴.Fill(dSet常用菜肴);
            Common.dumpDataSet(dSet常用菜肴);

            comboBox1.Items.Add("全部");
            comboBox1.Items.AddRange(get所有常用菜肴());

            updatelistBox1("全部");

            listBox1.SelectedIndex = 0;
            listBox1SelectedIndexChanged();
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

            foreach (DataRow dr in dSet常用菜肴.Tables[0].Rows)
            {
                string 菜肴类型 = (string)dr["菜肴类型"];

                if (selectAll || 菜肴类型 == selectStr)
                {
                    string str = (string)dr["菜肴名称"];
                    Console.Write(str);
                    listBox1.Items.Add(str);
                }
            }
        }

        private void updateTextBoxs(string selectStr)
        {
            foreach (DataRow dr in dSet常用菜肴.Tables[0].Rows)
            {
                string 菜肴名称 = (string)dr["菜肴名称"];

                if (菜肴名称 == selectStr)
                {
                    textBox1.Text = 菜肴名称;

                    textBox2.Text = (string)dr["用料1"].ToString();
                    textBox3.Text = (string)dr["用料2"].ToString();
                    textBox4.Text = (string)dr["用料3"].ToString();
                    textBox5.Text = (string)dr["用料4"].ToString();
                    textBox6.Text = (string)dr["用料5"].ToString();

                    textBox7.Text = (string)dr["用量1"].ToString();
                    textBox8.Text = (string)dr["用量2"].ToString();
                    textBox9.Text = (string)dr["用量3"].ToString();
                    textBox10.Text = (string)dr["用量4"].ToString();
                    textBox11.Text = (string)dr["用量5"].ToString();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Form原料编辑().ShowDialog();
        }

        private void listBox1SelectedIndexChanged()
        {
            updateTextBoxs((string)listBox1.Items[listBox1.SelectedIndex]);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                return;
            }
            listBox1SelectedIndexChanged();
        }

        private void syncDataSetToDB()
        {
            SqlCommandBuilder sql_command = new SqlCommandBuilder(adapter常用菜肴);
            adapter常用菜肴.Update(dSet常用菜肴.Tables[0]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "保存")
            {
                string selectStr = (string)listBox1.Items[listBox1.SelectedIndex];

                foreach (DataRow dr in dSet常用菜肴.Tables[0].Rows)
                {
                    string 菜肴名称 = (string)dr["菜肴名称"];

                    if (菜肴名称 == selectStr)
                    {
                        dr["菜肴名称"] = textBox1.Text;

                        dr["用料1"] = textBox2.Text;
                        dr["用料2"] = textBox3.Text;
                        dr["用料3"] = textBox4.Text;
                        dr["用料4"] = textBox5.Text;
                        dr["用料5"] = textBox6.Text;

                        dr["用量1"] = textBox7.Text;
                        dr["用量2"] = textBox8.Text;
                        dr["用量3"] = textBox9.Text;
                        dr["用量4"] = textBox10.Text;
                        dr["用量5"] = textBox11.Text;

                        break;
                    }
                }

                syncDataSetToDB();
                MessageBox.Show("保存成功");
                button2.Text = "修改";
            }
            else
            {
                button2.Text = "保存";
            }

            bool b = false;
            if (button2.Text != "保存")
            {
                b = true;
            }
            updateTextBoxReadOnly(b);
        }

        private void updateTextBoxReadOnly(bool b)
        {
            textBox1.ReadOnly = b;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 || (string)comboBox1.Items[comboBox1.SelectedIndex] == "全部")
            {
                MessageBox.Show("请选择具体菜肴类型再添加");
                return;
            }

            if (button1.Text == "保存")
            {
                button1.Text = "添加";

                DataRow dr = dSet常用菜肴.Tables[0].NewRow();

                dr["菜肴名称"] = textBox1.Text;

                dr["菜肴类型"] = comboBox1.Items[comboBox1.SelectedIndex];

                dr["用料1"] = textBox2.Text;
                dr["用料2"] = textBox3.Text;
                dr["用料3"] = textBox4.Text;
                dr["用料4"] = textBox5.Text;
                dr["用料5"] = textBox6.Text;

                dr["用量1"] = textBox7.Text;
                dr["用量2"] = textBox8.Text;
                dr["用量3"] = textBox9.Text;
                dr["用量4"] = textBox10.Text;
                dr["用量5"] = textBox11.Text;

                dSet常用菜肴.Tables[0].Rows.Add(dr);

                syncDataSetToDB();
                MessageBox.Show("添加成功");
                updateTextBoxReadOnly(true);
            }
            else
            {
                button1.Text = "保存";
                updateTextBoxReadOnly(false);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                return;
            }
            updatelistBox1((string)comboBox1.Items[comboBox1.SelectedIndex]);
        }
    }
}
