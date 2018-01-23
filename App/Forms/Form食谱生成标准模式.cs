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
    public partial class Form食谱生成标准模式 : Form
    {
        SqlDataAdapter adapter伙食单位参数 = new SqlDataAdapter("select * from dbo.伙食单位参数", DBConnect.Instance().getConnectString());
        DataSet dSet伙食单位参数 = new DataSet();

        SqlDataAdapter adapter驻地 = new SqlDataAdapter("select * from dbo.驻地", DBConnect.Instance().getConnectString());
        DataSet dSet驻地 = new DataSet();
        

        public Form食谱生成标准模式()
        {
            InitializeComponent();
        }

        private void Form食谱生成标准模式_Load(object sender, EventArgs e)
        {
            textBox3.Text = DateTime.Now.ToString("yyyy-MM-dd");

            adapter伙食单位参数.Fill(dSet伙食单位参数);
            Common.dumpDataSet(dSet伙食单位参数);

            adapter驻地.Fill(dSet驻地);
            Common.dumpDataSet(dSet驻地);

            fillComboBox1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateStepButton(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            updateStepButton(true);
        }

        private void updateStepButton(bool next)
        {
            if (next)
            {
                if (步骤.SelectedIndex == 5)
                {
                    button3.Visible = false;
                }
                else
                {
                    button3.Visible = true;
                    步骤.SelectedIndex = 步骤.SelectedIndex + 1;
                }
            }
            else
            {
                if (步骤.SelectedIndex == 0)
                {
                    button1.Visible = false;
                }
                else
                {
                    button1.Visible = true;
                    步骤.SelectedIndex = 步骤.SelectedIndex - 1;
                }
            }

            if (步骤.SelectedIndex > 0 && 步骤.SelectedIndex < 5)
            {
                button1.Visible = true;
                button3.Visible = true;
            }
        }

        private void fillComboBox1()
        {

            comboBox1.Items.AddRange(Common.getUniqueItemsFromDataSet(dSet伙食单位参数, "名称"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void 步骤_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (步骤.SelectedIndex == 0)
            {
                button1.Visible = false;
            }
            else
            {
                button1.Visible = true;
            }
            
            if (步骤.SelectedIndex == 5)
            {
                button3.Visible = false;
            }
            else
            {
                button3.Visible = true;
            }
        }

        private string get地区By驻地(string 驻地)
        {
            foreach (DataRow dr in dSet驻地.Tables[0].Rows)
            {
                string 名称 = (string)dr["名称"];
                if (驻地 == 名称)
                {
                    string 地区 = (string)dr["地区"];

                    return 地区;
                }
            }
            return "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                return;
            }

            string selectStr = (string)comboBox1.Items[comboBox1.SelectedIndex];
            foreach (DataRow dr in dSet伙食单位参数.Tables[0].Rows)
            {
                string 名称 = (string)dr["名称"];

                if (名称 == selectStr)
                {
                    string 驻地 = (string)dr["驻地"];
                    Int32 就餐人数 = (Int32)dr["就餐人数"];

                    textBox25.Text = Convert.ToString(就餐人数);
                    comboBox2.Text = 驻地;
                    textBox6.Text = get地区By驻地(驻地);
                }
            }
        }
    }
}
