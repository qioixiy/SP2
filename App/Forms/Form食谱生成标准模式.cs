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
using SP.Forms;

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

            init描述();
            init第一步();
            init第二步();
            init第三步();
            init第四步();
            init第五步();
        }

        private void init描述()
        {
            fillComboBox1();
            fillComboBox2();

            textBox4.Text = "";

            comboBox3.Items.Add("750");
            comboBox3.Items.Add("650");
            comboBox3.Items.Add("550");
            comboBox3.Text = "750";

            comboBox4.Items.Add("0");
            comboBox4.Items.Add("50");
            comboBox4.Items.Add("100");
            comboBox4.Text = "0";
        }
        
        private void init第一步()
        {

        }
        
        private void init第二步()
        {
            onValueChanged();
        }

        private void init第三步()
        {

        }

        private void init第四步()
        {

        }

        private void init第五步()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateStepButton(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch (步骤.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    if (comboBox1.Text == "请选择")
                    {
                        MessageBox.Show("请选择单位");
                        return;
                    }
                    break;
                default:
                    break;
            }
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

        private void fillComboBox2()
        {
            comboBox2.Items.AddRange(Common.getUniqueItemsFromDataSet(dSet驻地, "名称"));
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

                    numericUpDown1.Text = Convert.ToString(就餐人数);
                    comboBox2.Text = 驻地;
                    textBox6.Text = get地区By驻地(驻地);

                    update_textBox4(get米面比例By名称驻地(驻地));
                }
            }
        }

        private string get米面比例By名称驻地(string 驻地)
        {
            string ret= (string)Common.selectDataItemFromDataSet(dSet驻地, "名称", 驻地, "米面比例");
            return ret;
        }

        private void update_textBox4(string s)
        {
            textBox4.Text = s;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            String 驻地 = comboBox2.Items[comboBox2.SelectedIndex].ToString();
            update_textBox4(get米面比例By名称驻地(驻地));
            textBox6.Text = get地区By驻地(驻地);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            onValueChanged();
        }

        private void onValueChanged()
        {
            //3～5月为春季，6～8月为夏季，9～11月为秋季，12月～来年2月为冬季
            int mouth = Convert.ToInt32(dateTimePicker1.Value.ToString("MM"));//月

            String Seasons;
            switch (mouth)
            {
                case 3:
                case 4:
                case 5:
                    Seasons = "春";
                    break;
                case 6:
                case 7:
                case 8:
                    Seasons = "夏";
                    break;
                case 9:
                case 10:
                case 11:
                    Seasons = "秋";
                    break;
                case 12:
                case 1:
                case 2:
                    Seasons = "冬";
                    break;
                default:
                    return;
            }

            textBox7.Text = Seasons;

            String LightHighSeason = "平";
            switch (mouth)
            {
                case 1: LightHighSeason = "旺"; break;
                case 2: LightHighSeason = "旺"; break;
                case 3: LightHighSeason = "平"; break;
                case 4: LightHighSeason = "平"; break;
                case 5: LightHighSeason = "旺"; break;
                case 6: LightHighSeason = "平"; break;
                case 7: LightHighSeason = "平"; break;
                case 8: LightHighSeason = "平"; break;
                case 9: LightHighSeason = "旺"; break;
                case 10: LightHighSeason = "旺"; break;
                case 11: LightHighSeason = "平"; break;
                case 12: LightHighSeason = "平"; break;
                default:
                    return;
            }

            textBox8.Text = LightHighSeason;
        }

        private string dateTimeToString(DateTime dateTime)
        {
            //星期一(02/26/2018)
            string ret = "星期";
            switch (dateTime.DayOfWeek)
            {
                case DayOfWeek.Monday: ret += "一";  break;
                case DayOfWeek.Tuesday: ret += "二"; break;
                case DayOfWeek.Wednesday: ret += "三"; break;
                case DayOfWeek.Thursday: ret += "四"; break;
                case DayOfWeek.Friday: ret += "五"; break;
                case DayOfWeek.Saturday: ret += "六"; break;
                case DayOfWeek.Sunday: ret += "日"; break;
            }
            ret += "(";
            ret += dateTime.Month.ToString("00");
            ret += "/";
            ret += dateTime.Day.ToString("00");
            ret += "/";
            ret += dateTime.Year.ToString();

            ret += ")";

            return ret;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form节日与外出设定 tForm节日与外出设定 = new Form节日与外出设定();

            DayOfWeek tDayOfWeek = dateTimePicker1.Value.DayOfWeek;
            tForm节日与外出设定.setLabel3Text(dateTimeToString(dateTimePicker1.Value.AddDays(0)));
            tForm节日与外出设定.setLabel4Text(dateTimeToString(dateTimePicker1.Value.AddDays(1)));
            tForm节日与外出设定.setLabel5Text(dateTimeToString(dateTimePicker1.Value.AddDays(2)));
            tForm节日与外出设定.setLabel6Text(dateTimeToString(dateTimePicker1.Value.AddDays(3)));
            tForm节日与外出设定.setLabel7Text(dateTimeToString(dateTimePicker1.Value.AddDays(4)));
            tForm节日与外出设定.setLabel8Text(dateTimeToString(dateTimePicker1.Value.AddDays(5)));
            tForm节日与外出设定.setLabel9Text(dateTimeToString(dateTimePicker1.Value.AddDays(6)));
            
            DialogResult result = tForm节日与外出设定.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox9.Text = tForm节日与外出设定.getTextBox1Text();
                textBox10.Text = tForm节日与外出设定.getTextBox2Text();
            }
        }
    }
}
