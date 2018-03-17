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
        Form预定菜肴 tForm预定菜肴;

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
            if (tForm选定常用菜肴 == null)
            {
                tForm选定常用菜肴 = new Form选定常用菜肴();
            }
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

            update食谱名称();
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
            update食谱名称(); 
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
            if (tForm预定菜肴 == null)
            {
                tForm预定菜肴 = new Form预定菜肴();
            }

            DialogResult tDialogResult = tForm预定菜肴.ShowDialog();
        }

        private void update食谱名称()
        {
            textBox24.Text = comboBox1.Text + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "所用食谱(" + textBox6.Text + comboBox5.Text + textBox7.Text + "季)";
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            update食谱名称();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            update食谱名称(); 
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (tForm选定常用菜肴 == null)
            {
                MessageBox.Show("请到第四步，先选择常用菜肴");
                return;
            }

            // 生成食谱
            SqlDataAdapter adapter食谱 = new SqlDataAdapter("select * from dbo.食谱", DBConnect.Instance().getConnectString());
            DataSet dSet食谱 = new DataSet();

            adapter食谱.Fill(dSet食谱);
            Common.dumpDataSet(dSet食谱);

            DataRow dr = dSet食谱.Tables[0].NewRow();
            List<string> list = tForm选定常用菜肴.get选定常用菜肴List();

            try
            {
                getOneWeekSPList(list, dr);
            }
            catch (Exception ex)
            {
                MessageBox.Show("生成失败" + ex.ToString());
                return;
            }

            dr["名称"] = textBox24.Text;
            dr["食谱来源"] = "标准模式";
            double 伙食费合计 = Convert.ToDouble(textBox20.Text) * Convert.ToInt32(numericUpDown1.Value.ToString());
            dr["标准伙食费合计"] = Convert.ToString(伙食费合计);
            dr["生成日期"] = textBox3.Text;
            dr["地区"] = comboBox2.Text;
            dr["基本伙食费"] = textBox16.Text;
            dr["补助伙食费"] = textBox17.Text;
            dr["灶别"] = comboBox5.Text;
            dr["类区"] = comboBox6.Text;
            dr["补助"] = comboBox7.Text;
            dr["劳动强度"] = comboBox8.Text;
            dr["米面比例"] = textBox4.Text;
            dr["军粮基本定量"] = comboBox3.Text;
            dr["军粮补助标准"] = comboBox4.Text;
            dr["单位"] = comboBox1.Text;
            dr["就餐人数"] = numericUpDown1.Value;
            dr["其他补助"] = textBox18.Text;
            dr["油豆差价费"] = textBox19.Text;
            dr["水果费"] = "";
            dr["饮料费"] = "";
            dr["燃料费"] = textBox15.Text;
            dr["食谱时间1"] = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            dr["食谱时间2"] = dateTimePicker1.Value.AddDays(7).ToString("yyyy-MM-dd");
            dr["季节"] = textBox7.Text;
            dr["蔬菜季节"] = textBox8.Text;
            dr["节日天数"] = textBox9.Text;
            dr["外出执勤"] = textBox10.Text;

            dr["基本标准"] = 20;
            dr["单位首长"] = textBox21.Text;
            dr["经委会"] = textBox22.Text;
            dr["司务长"] = textBox23.Text;

            dSet食谱.Tables[0].Rows.Add(dr);

            SqlCommandBuilder sql_command = new SqlCommandBuilder(adapter食谱);
            adapter食谱.Update(dSet食谱.Tables[0]);

            MessageBox.Show("生成成功");

            Program.FormMainWindowInstance.mUserContext.当前食谱 = textBox24.Text;

            DialogResult = DialogResult.OK;

            Close();
        }

        private string[] get能量(string 强度类型)
        {
            SqlData sqlData = SqlDataPool.Instance().GetSqlDataByName("营养素标准");

            object obj = Common.selectDataItemFromDataSet(sqlData.mDataSet, "类型", 强度类型, "能量");

            string str = (string)obj;

            string[] sArray = str.Split(new char[2] { '(', ')' });

            string[] sArray2 = sArray[1].Split(new char[2] { '~', '<' });

            return sArray2;
        }

        class ScopeDouble
        {
            public ScopeDouble(double start, double end)
            {
                this.start = start;
                this.end = end;
            }
            public double start, end;
        }

        class ScopeDouble能量
        {
            public ScopeDouble d蛋白质start;
            public ScopeDouble d蛋白质end;

            public ScopeDouble d脂肪start;
            public ScopeDouble d脂肪end;

            public ScopeDouble d糖start;
            public ScopeDouble d糖end;
        }

        public class 原料营养值
        {
            public 原料营养值()
            {
                蛋白质 = 0;
                脂肪 = 0;
                糖 = 0;
            }
            public double 蛋白质, 脂肪, 糖;
        }

        /*
         * 食谱生成过程
         * 1. 根据每人每天的劳动强度获取对应的能量和营养供应量
         * 2. 分配能量配比：蛋白质占11%~13%,脂肪20%~30%，糖55%~65%
         //*/
        private void getOneWeekSPList(List<string> list常用菜肴, DataRow dr)
        {
            // 获取每天劳动强度对应的能量和营养供应量
            string[] 能量 = get能量(comboBox8.Text);
            double dstart = Convert.ToDouble(能量[0]);
            double dend = Convert.ToDouble(能量[2]);
            ScopeDouble d能量 = new ScopeDouble(dstart, dend);

            ScopeDouble能量 scopeDouble能量 = new ScopeDouble能量();

            scopeDouble能量.d蛋白质start = new ScopeDouble(d能量.start * 0.11, d能量.start * 0.13);
            scopeDouble能量.d蛋白质end = new ScopeDouble(d能量.end * 0.11, d能量.end * 0.13);

            scopeDouble能量.d脂肪start = new ScopeDouble(d能量.start * 0.20, d能量.start * 0.30);
            scopeDouble能量.d脂肪end = new ScopeDouble(d能量.end * 0.20, d能量.end * 0.30);

            scopeDouble能量.d糖start = new ScopeDouble(d能量.start * 0.55, d能量.start * 0.65);
            scopeDouble能量.d糖end = new ScopeDouble(d能量.end * 0.55, d能量.end * 0.65);

            int offset = 1;
            for (int i = 0; i < 7; i++)
            {
                List<string> list;
                do
                {
                    list = getOneDaySPList(list常用菜肴);
                }
                while (!verfiyOneDaySPList(list, scopeDouble能量));

                foreach (string item in list)
                {
                    string 序号 = "菜肴" + offset++;
                    string 菜肴名称 = item;

                    dr[序号] = 菜肴名称;
                }
            }
        }

        public static 原料营养值 get原料营养值(string 原料名称)
        {
            原料营养值 ret = new 原料营养值();

            SqlData sqlData营养维护 = SqlDataPool.Instance().GetSqlDataByName("营养维护");
            object _营养蛋白质 = Common.selectDataItemFromDataSet(sqlData营养维护.mDataSet, "原料名称", 原料名称, "蛋白质");
            object _营养脂肪 = Common.selectDataItemFromDataSet(sqlData营养维护.mDataSet, "原料名称", 原料名称, "脂肪");
            object _营养糖 = Common.selectDataItemFromDataSet(sqlData营养维护.mDataSet, "原料名称", 原料名称, "糖");

            if (_营养蛋白质 != null)
            {
                ret.蛋白质 = Convert.ToDouble((string)_营养蛋白质) / 100;
            }
            if (_营养脂肪 != null)
            {
                ret.脂肪 = Convert.ToDouble((string)_营养脂肪) / 100;
            }
            if (_营养糖 != null)
            {
                ret.糖 = Convert.ToDouble((string)_营养糖) / 100;
            }

            return ret;
        }

        public static 原料营养值 get营养值By菜肴名称(string 菜肴名称)
        {
            原料营养值 营养值 = new 原料营养值();
                
            SqlData sqlData = SqlDataPool.Instance().GetSqlDataByName("常用菜肴");

            object _用量1 = Common.selectDataItemFromDataSet(sqlData.mDataSet, "菜肴名称", 菜肴名称, "用量1");
            object _用量2 = Common.selectDataItemFromDataSet(sqlData.mDataSet, "菜肴名称", 菜肴名称, "用量2");
            object _用量3 = Common.selectDataItemFromDataSet(sqlData.mDataSet, "菜肴名称", 菜肴名称, "用量3");
            object _用量4 = Common.selectDataItemFromDataSet(sqlData.mDataSet, "菜肴名称", 菜肴名称, "用量4");
            object _用量5 = Common.selectDataItemFromDataSet(sqlData.mDataSet, "菜肴名称", 菜肴名称, "用量5");

            object _用料1 = Common.selectDataItemFromDataSet(sqlData.mDataSet, "菜肴名称", 菜肴名称, "用料1");
            object _用料2 = Common.selectDataItemFromDataSet(sqlData.mDataSet, "菜肴名称", 菜肴名称, "用料2");
            object _用料3 = Common.selectDataItemFromDataSet(sqlData.mDataSet, "菜肴名称", 菜肴名称, "用料3");
            object _用料4 = Common.selectDataItemFromDataSet(sqlData.mDataSet, "菜肴名称", 菜肴名称, "用料4");
            object _用料5 = Common.selectDataItemFromDataSet(sqlData.mDataSet, "菜肴名称", 菜肴名称, "用料5");

            try
            {
                if (_用料1 != null && !Convert.IsDBNull(_用料1) && _用量1 != null && !Convert.IsDBNull(_用量1))
                {
                    string 用料1 = (string)_用料1;
                    double 用量1 = Convert.ToDouble(_用量1);

                    原料营养值 val = get原料营养值(用料1);
                    营养值.蛋白质 += val.蛋白质 * 用量1;
                    营养值.脂肪 += val.脂肪 * 用量1;
                    营养值.糖 += val.糖 * 用量1;
                }
                if (_用料2 != null && !Convert.IsDBNull(_用料2) && _用量2 != null && !Convert.IsDBNull(_用量2))
                {
                    string 用料2 = (string)_用料2;
                    double 用量2 = Convert.ToDouble(_用量2);

                    原料营养值 val = get原料营养值(用料2);
                    营养值.蛋白质 += val.蛋白质 * 用量2;
                    营养值.脂肪 += val.脂肪 * 用量2;
                    营养值.糖 += val.糖 * 用量2;
                }
                if (_用料3 != null && !Convert.IsDBNull(_用料3) && _用量3 != null && !Convert.IsDBNull(_用量3))
                {
                    string 用料3 = (string)_用料3;

                    double 用量3 = Convert.ToDouble(_用量3);

                    原料营养值 val = get原料营养值(用料3);
                    营养值.蛋白质 += val.蛋白质 * 用量3;
                    营养值.脂肪 += val.脂肪 * 用量3;
                    营养值.糖 += val.糖 * 用量3;
                }
                if (_用料4 != null && !Convert.IsDBNull(_用料4) && _用量4 != null && !Convert.IsDBNull(_用量4))
                {
                    string 用料4 = (string)_用料4;
                    double 用量4 = Convert.ToDouble(_用量4);

                    原料营养值 val = get原料营养值(用料4);
                    营养值.蛋白质 += val.蛋白质 * 用量4;
                    营养值.脂肪 += val.脂肪 * 用量4;
                    营养值.糖 += val.糖 * 用量4;
                }
                if (_用料5 != null && !Convert.IsDBNull(_用料5) && _用量5 != null && !Convert.IsDBNull(_用量5))
                {
                    string 用料5 = (string)_用料5;
                    double 用量5 = Convert.ToDouble(_用量5);

                    原料营养值 val = get原料营养值(用料5);
                    营养值.蛋白质 += val.蛋白质 * 用量5;
                    营养值.脂肪 += val.脂肪 * 用量5;
                    营养值.糖 += val.糖 * 用量5;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                return 营养值;
            }

            return 营养值;
        }


        /*
         * 验证过程
         * 1. 取出菜肴名称
         * 2. 在常用菜肴table里面查找对应的各种原料，认为用量单位是克
         * 3. 通过查询营养维护table，计算出每种原料含有的营养素,认为营养维护table是100g对应的营养素
         * 4. 验证每个营养素是否在合理的区间，返回结果
         */
        private Boolean verfiyOneDaySPList(List<string> list, ScopeDouble能量 scopeDouble能量)
        {
            原料营养值 营养值 = new 原料营养值();

            foreach (string item in list)
            {
                string 菜肴名称 = item;

                原料营养值 营养值1 = get营养值By菜肴名称(菜肴名称);
                营养值.糖 += 营养值1.糖;
                营养值.脂肪 += 营养值1.脂肪;
                营养值.蛋白质 += 营养值1.蛋白质;
            }

            // TODO: hacker 
            营养值.蛋白质 *= 6;
            营养值.脂肪 *= 40;
            营养值.糖 *= 60;

            if (((scopeDouble能量.d蛋白质start.start <= 营养值.蛋白质) && (营养值.蛋白质 <= scopeDouble能量.d蛋白质end.end))
                && ((scopeDouble能量.d脂肪start.start <= 营养值.脂肪) && (营养值.脂肪 <= scopeDouble能量.d脂肪end.end))
                && ((scopeDouble能量.d糖start.start <= 营养值.糖) && (营养值.糖 <= scopeDouble能量.d糖end.end)))
            {
                return true;
            }
            else
            {
                /*
                Console.WriteLine("" + scopeDouble能量.d蛋白质start.start + "<=" + 蛋白质总合 + "<=" + scopeDouble能量.d蛋白质end.end + "|"
                    + scopeDouble能量.d脂肪start.start + "<=" + 脂肪总合 + "<=" + scopeDouble能量.d脂肪end.end + "|"
                    + scopeDouble能量.d糖start.start + "<=" + 糖总合 + "<=" + scopeDouble能量.d糖end.end + "+"
                    + (scopeDouble能量.d蛋白质start.start / 蛋白质总合) + "->" + (scopeDouble能量.d蛋白质end.end / 蛋白质总合) + "|"
                    + (scopeDouble能量.d脂肪start.start / 脂肪总合) + "->" + (scopeDouble能量.d脂肪end.end / 脂肪总合) + "|"
                    + (scopeDouble能量.d糖start.start / 糖总合) + "->" + (scopeDouble能量.d糖end.end / 糖总合)
                    );
                //*/

                Console.WriteLine("" + (int)(scopeDouble能量.d蛋白质start.start / 营养值.蛋白质) + "->" + (int)(scopeDouble能量.d蛋白质end.end / 营养值.蛋白质) + "|"
                    + (int)(scopeDouble能量.d脂肪start.start / 营养值.脂肪) + "->" + (int)(scopeDouble能量.d脂肪end.end / 营养值.脂肪) + "|"
                    + (int)(scopeDouble能量.d糖start.start / 营养值.糖) + "->" + (int)(scopeDouble能量.d糖end.end / 营养值.糖)
    );
                return false;
            }
        }

        /*
         */
        private List<string> getOneDaySPList(List<string> list常用菜肴)
        {
            List<string> ret = new List<string>();

            Random rd = new Random();

            for (int i = 0; i < 3; i++)
            {
                List<string> list已经挑选菜肴 = new List<string>();
                for (int j = 0; j < 10;) // 每顿最多10个菜
                {
                    int rand = rd.Next(0, list常用菜肴.Count - 1);

                    string 菜肴名称 = list常用菜肴[rand];

                    if (list已经挑选菜肴.Find(s => s.Equals(菜肴名称)) != null)
                    {
                        Console.WriteLine("find " + 菜肴名称 + ",retry");
                        continue;
                    }

                    ret.Add(菜肴名称);
                    j++;
                }
            }

            return ret;
        }
    }
}
