using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataModel;
using System.Data.SqlClient;
using SP.Utils;

namespace SP.Forms
{
    public partial class Form原料编辑 : Form
    {
        SqlDataAdapter adapter常用原料 = new SqlDataAdapter("select * from dbo.常用原料", DBConnect.Instance().getConnectString());
        DataSet dSet常用原料 = new DataSet();

        public Form原料编辑()
        {
            InitializeComponent();
        }

        private void Form原料编辑_Load(object sender, EventArgs e)
        {
            adapter常用原料.Fill(dSet常用原料);
            dSet常用原料 = new DataSet();
            adapter常用原料.Fill(dSet常用原料);
            Common.dumpDataSet(dSet常用原料);

            comboBox1.Items.Add("全部");
            comboBox1.Items.AddRange(get所有原料分类());
            comboBox1.SelectedIndex = 0;

            updateListBox1("全部");

            listBox1.SetSelected(0, true);

            textBox1.Enabled = false;
        }

        private object[] get所有原料分类()
        {
            return Common.getUniqueItemsFromDataSet(dSet常用原料, "原料分类");
        }

        private String current_Mode = "选择模式";
        private void update_buttonsText(String mode)
        {
            current_Mode = mode;
            switch (mode)
            {
                case "添加模式":
                    button1.Text = "保存";
                    button2.Text = "放弃";
                    update_textBoxs_enable(true);
                    break;
                case "编辑模式":
                    button1.Text = "保存";
                    button2.Text = "放弃";
                    update_textBoxs_enable(true);
                    break;
                case "选择模式":
                    button1.Text = "添加";
                    button2.Text = "编辑";
                    update_textBoxs_enable(false);
                    break;
                default:
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "添加")
            {
                update_buttonsText("添加模式");
            }
            else
            {
                update_buttonsText("选择模式");

                if (current_Mode == "添加模式")
                {
                    DataRow dr = dSet常用原料.Tables[0].NewRow();

                    dr["常用"] = "否";
                    dr["原料"] = textBox1.Text;
                    dr["价格(元/千克)"] = numericUpDown1.Text;
                    dr["损耗率(%)"] = numericUpDown2.Text;
                    dr["原料分类"] = comboBox2.Text;

                    dSet常用原料.Tables[0].Rows.Add(dr);

                    sync常用原料ToDB();
                    MessageBox.Show("添加成功");
                }
                else
                {
                    if (listBox1.SelectedIndex < 0)
                    {
                        MessageBox.Show("保存失败，请选择需要编辑的项");
                    }
                    else
                    {
                        string oldName = (string)listBox1.Items[listBox1.SelectedIndex];
                        foreach (DataRow dr in dSet常用原料.Tables[0].Rows)
                        {
                            string 原料 = (string)dr["原料"];

                            if (原料 == oldName)
                            {
                                dr["原料"] = textBox1.Text;
                                dr["价格(元/千克)"] = numericUpDown1.Text;
                                dr["损耗率(%)"] = numericUpDown2.Text;
                                dr["原料分类"] = comboBox2.Text;

                                break;
                            }
                        }

                        sync常用原料ToDB();
                        MessageBox.Show("保存成功");
                    }
                }
            }
        }

        private void update_textBoxs_enable(bool b)
        {
            textBox1.Enabled = b;
            numericUpDown1.Enabled = b;
            numericUpDown2.Enabled = b;
            comboBox2.Enabled = b;
            comboBox3.Enabled = b;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "编辑")
            {
                update_buttonsText("编辑模式");
            }
            else
            {
                update_buttonsText("选择模式");
            }
        }

        private void sync常用原料ToDB()
        {
            SqlCommandBuilder sql_command = new SqlCommandBuilder(adapter常用原料);
            adapter常用原料.Update(dSet常用原料.Tables[0]);
            updateListBox1((string)comboBox1.Items[comboBox1.SelectedIndex]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form菜肴编辑().ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void updateListBox1(string selectStr)
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
                    string str = (string)dr["原料"];
                    Console.Write(str);
                    listBox1.Items.Add(str);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                return;
            }

            updateListBox1((string)comboBox1.Items[comboBox1.SelectedIndex]);
        }

        private void listBoxSelectedIndexChanged(string selectStr)
        {
            foreach (DataRow dr in dSet常用原料.Tables[0].Rows)
            {
                string 原料 = (string)dr["原料"];

                if (原料 == selectStr)
                {
                    comboBox2.Text = (string)dr["原料分类"];
                    textBox1.Text = (string)dr["原料"];
                    numericUpDown1.Text = (string)dr["价格(元/千克)"];
                    numericUpDown2.Text = (string)dr["损耗率(%)"];
                    numericUpDown2.Text = (string)dr["损耗率(%)"];
                }
            };
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                return;
            }
            listBoxSelectedIndexChanged((string)listBox1.Items[listBox1.SelectedIndex]);
        }
    }
}
