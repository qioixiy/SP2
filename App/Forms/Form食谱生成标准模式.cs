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
        Form选定军粮品种 tForm选定军粮品种;
        Form选定常用菜肴 tForm选定常用菜肴;
        Form原料优选 tForm原料优选;

        SqlDataAdapter adapter伙食单位参数 = new SqlDataAdapter("select * from dbo.伙食单位参数", DBConnect.Instance().getConnectString());
        DataSet dSet伙食单位参数 = new DataSet();

        SqlDataAdapter adapter驻地 = new SqlDataAdapter("select * from dbo.驻地", DBConnect.Instance().getConnectString());
        DataSet dSet驻地 = new DataSet();

        SqlDataAdapter adapter伙食费标准 = new SqlDataAdapter("select * from dbo.伙食费标准", DBConnect.Instance().getConnectString());
        DataSet dSet伙食费标准 = new DataSet();
        int index伙食费标准 = 0;

        SqlDataAdapter adapter食物定量标准 = new SqlDataAdapter("select * from dbo.食物定量标准", DBConnect.Instance().getConnectString());
        DataSet dSet食物定量标准 = new DataSet();
        int index食物定量标准 = 0;

        SqlDataAdapter adapter营养素标准 = new SqlDataAdapter("select * from dbo.营养素标准", DBConnect.Instance().getConnectString());
        DataSet dSet营养素标准 = new DataSet();
        int index营养素标准 = 0;
        
        bool inited = false;

        public Form食谱生成标准模式()
        {
            InitializeComponent();
        }

        private void Form食谱生成标准模式_Load(object sender, EventArgs e)
        {
            textBox3.Text = DateTime.Now.ToString("yyyy-MM-dd");
            
            adapter伙食费标准.Fill(dSet伙食费标准);
            adapter食物定量标准.Fill(dSet食物定量标准);
            adapter营养素标准.Fill(dSet营养素标准);

            Common.dumpDataSet(dSet伙食费标准);
            Common.dumpDataSet(dSet食物定量标准);
            Common.dumpDataSet(dSet营养素标准);

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

            inited = true;
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

        private bool init第三步done = false;
        private void init第三步()
        {
            comboBox5.Items.AddRange(new object[] {
                "一类灶",
                "二类灶",
                "三类灶",
                "四类灶",
            });
            comboBox5.SelectedIndex = 0;
            
            comboBox6.Items.AddRange(new object[] {
                "一类区",
                "二类区",
                "三类区",
                "四类区",
                "五类区",
            });
            comboBox6.SelectedIndex = 0;

            comboBox7.Items.AddRange(new object[] {
                "无补助",
                "一类补助",
                "二类补助",
                "三类补助",
                "四类补助",
            });
            comboBox7.SelectedIndex = 0;
            
            init第三步done = true;

            update第三步();
        }

        private void init第四步()
        {

        }

        private void init第五步()
        {

        }

        private bool update第三步ing = false;
        private void update第三步()
        {
            if (update第三步ing)
            {
                return;
            }

            if (!init第三步done)
            {
                return;
            }

            update第三步ing = true;

            string comboBox5Text = (string)comboBox5.Items[comboBox5.SelectedIndex];
            if (comboBox5Text == "一类灶")
            {
                comboBox8.Items.Clear();
                comboBox8.Items.AddRange(new object[] {
                    "陆勤轻度",
                    "陆勤中度",
                    "陆勤重度",
                    "陆勤极重度",
                });
            }
            else if (comboBox5Text == "二类灶")
            {
                comboBox8.Items.Clear();
                comboBox8.Items.AddRange(new object[] {
                    "陆勤轻度",
                    "陆勤中度",
                    "陆勤重度",
                    "陆勤极重度",
                });
            }
            else if (comboBox5Text == "三类灶")
            {
                comboBox8.Items.Clear();
                comboBox8.Items.AddRange(new object[] {
                    "水面舰艇",
                });
            }
            else if (comboBox5Text == "四类灶")
            {
                comboBox8.Items.Clear();
                comboBox8.Items.AddRange(new object[] {
                    "潜艇",
                    "核潜艇",
                    "空勤",
                });
            }
            comboBox8.SelectedIndex = 0;

            // textbox
            textBox11.Text = (string)dSet食物定量标准.Tables[0].Rows[comboBox5.SelectedIndex]["植物油"];
            textBox12.Text = (string)dSet食物定量标准.Tables[0].Rows[comboBox5.SelectedIndex]["黄豆"];
            textBox13.Text = "3.60";
            textBox14.Text = "2.60";
            textBox15.Text = "0.00";

            string comboBox6Text = (string)comboBox6.Items[comboBox6.SelectedIndex];
            textBox16.Text = (string)Utils.Common.selectDataItemFromDataSet(dSet伙食费标准, "灶别", comboBox5Text, comboBox6Text);

            string comboBox7Text = (string)comboBox7.Items[comboBox7.SelectedIndex];
            if (comboBox7.Text == "无补助")
            {
                textBox17.Text = "0";
            }
            else
            {
                textBox16.Text = (string)Utils.Common.selectDataItemFromDataSet(dSet伙食费标准, "灶别", comboBox7.Text, comboBox6Text);
            }
            
            textBox18.Text = "0.00";

            double total = Convert.ToDouble(textBox11.Text) * Convert.ToDouble(textBox13.Text);
            total += Convert.ToDouble(textBox12.Text) * Convert.ToDouble(textBox14.Text);
            total /= 1000;
            total = Math.Round(total, 2, MidpointRounding.AwayFromZero);
            textBox19.Text = Convert.ToString(total);
            textBox20.Text = Convert.ToString(Convert.ToDouble(textBox15.Text)
                + Convert.ToDouble(textBox16.Text)
                + Convert.ToDouble(textBox17.Text)
                + Convert.ToDouble(textBox18.Text)
                + Convert.ToDouble(textBox19.Text));

            update第三步ing = false;
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

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            update第三步();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            update第三步();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            update第三步();
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            update第三步();
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (tForm选定军粮品种 == null)
            {
                tForm选定军粮品种 = new Form选定军粮品种();
            }

            DialogResult tDialogResult = tForm选定军粮品种.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (tForm选定常用菜肴 == null)
            {
                tForm选定常用菜肴 = new Form选定常用菜肴();
            }

            DialogResult tDialogResult = tForm选定常用菜肴.ShowDialog();

            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (tForm原料优选 == null)
            {
                tForm原料优选 = new Form原料优选();
            }

            DialogResult tDialogResult = tForm原料优选.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
    }
}
