using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Windows.Forms.DataVisualization.Charting;

namespace SP.Forms
{
    public partial class Form伙食费分析 : Form
    {

        class 伙食费
        {
            public 伙食费(string 名称, string 调剂标准, string 食谱开支)
            {
                this.名称 = 名称;
                this.调剂标准 = 调剂标准;
                this.食谱开支 = 食谱开支;
            }
            public string 名称;
            public string 调剂标准, 食谱开支;
        };

        PrintDocument printDocument1 = new PrintDocument();

        List<伙食费> 一周伙食费 = new List<伙食费>();

        public Form伙食费分析()
        {
            InitializeComponent();
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
        }

        private void Form伙食费分析_Load(object sender, EventArgs e)
        {
            get一周伙食费();

            initListView();
            initChart();
        }

        private double get价格By原料(object 原料名称, object 原料用量)
        {
            if (原料名称 == null || Convert.IsDBNull(原料名称) || 原料用量 == null || Convert.IsDBNull(原料用量))
            {
                Console.WriteLine("get价格By原料 exception");
                return 0.0;
            }

            string str原料名称 = (string)原料名称;

            SqlData tSqlData = SqlDataPool.Instance().GetSqlDataByName("常用原料");

            object 单位价格 = Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "原料", str原料名称, "价格(元/千克)");

            if (单位价格 == null)
            {
                单位价格 = "0.001";
            }

            double double原料价格 = 0.1;
            try
            {
                double原料价格 = Convert.ToDouble(原料用量) * Convert.ToDouble(单位价格);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return double原料价格;
        }

        private double get价格By菜肴名称(string 菜肴名称)
        {
            double total = 0.0;

            SqlData tSqlData = SqlDataPool.Instance().GetSqlDataByName("常用菜肴");
            foreach (DataTable dt in tSqlData.mDataSet.Tables)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string str = (string)dr["菜肴名称"];
                    if (菜肴名称 == str)
                    {
                        object 用料1 = dr["用料1"];
                        object 用料2 = dr["用料2"];
                        object 用料3 = dr["用料3"];
                        object 用料4 = dr["用料4"];
                        object 用料5 = dr["用料5"];

                        object 用量1 = dr["用量1"];
                        object 用量2 = dr["用量2"];
                        object 用量3 = dr["用量3"];
                        object 用量4 = dr["用量4"];
                        object 用量5 = dr["用量5"];

                        total += get价格By原料(用料1, 用量1);
                        total += get价格By原料(用料2, 用量2);
                        total += get价格By原料(用料3, 用量3);
                        total += get价格By原料(用料4, 用量4);
                        total += get价格By原料(用料5, 用量5);
                        break;
                    }
                }
            }

            return total;
        }

        private List<string> get伙食费()
        {
            List<string> ret = new List<String>();

            string 当前食谱 = Program.FormMainWindowInstance.mUserContext.当前食谱;

            SqlData tSqlData = SqlDataPool.Instance().GetSqlDataByName("食谱");

            foreach (DataTable dt in tSqlData.mDataSet.Tables)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string str = (string)dr["名称"];
                    if (当前食谱 == str)
                    {
                        double total = 0;
                        for (int index = 1; index <= 210; index++)
                        {
                            string 菜肴名称 = (string)dr["菜肴" + index];
                            double 价格 = get价格By菜肴名称(菜肴名称);
                            total += 价格;
                            if (index % 30 == 0)
                            {
                                double everyTime = (total/3.0);
                                string s = "" + Math.Round(everyTime, 1);
                                ret.Add(s);
                                total = 0;
                                continue;
                            }
                        }
                        break;
                    }
                }
            }

            return ret;
        }

        private void get一周伙食费()
        {
            string 当前食谱 = Program.FormMainWindowInstance.mUserContext.当前食谱;

            SqlData tSqlData = SqlDataPool.Instance().GetSqlDataByName("食谱");
            string 灶别 = (string)Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前食谱, "灶别");
            string 类区 = (string)Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前食谱, "类区");
            SqlData sqlData = SqlDataPool.Instance().GetSqlDataByName("伙食费标准");
            string 伙食费标准 = (string)Utils.Common.selectDataItemFromDataSet(sqlData.mDataSet, "灶别", 灶别, 类区);

            List<string> 伙食费标准List = new List<string>();
            伙食费标准List.Add(伙食费标准);
            伙食费标准List.Add(伙食费标准);
            伙食费标准List.Add(伙食费标准);
            伙食费标准List.Add(伙食费标准);
            伙食费标准List.Add(伙食费标准);
            伙食费标准List.Add(伙食费标准);
            伙食费标准List.Add(伙食费标准);

            List<string> 伙食费List = new List<string>();
            伙食费标准List.Add("1");
            伙食费标准List.Add("1");
            伙食费标准List.Add("1");
            伙食费标准List.Add("1");
            伙食费标准List.Add("1");
            伙食费标准List.Add("1");
            伙食费标准List.Add("1");
            try
            {
                伙食费List = get伙食费();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // blance
            bool needBlance = true;
            //needBlance = false;
            if (needBlance)
            {
                List<string> 伙食费ListNew = new List<string>();
                for (int index = 0; index < 7; index++)
                {
                    double d伙食费标准 = Convert.ToDouble(伙食费标准List[index]);
                    double d伙食费 = Convert.ToDouble(伙食费List[index]);

                    if (Math.Abs(d伙食费 - d伙食费标准) / d伙食费标准 > 0.6)
                    {
                        伙食费ListNew.Add("" + (d伙食费标准*0.8));
                    }
                    else
                    {
                        伙食费ListNew.Add(伙食费List[index]);
                    }
                }

                伙食费List = 伙食费ListNew;
            }

            一周伙食费.Add(new 伙食费("星期一", 伙食费标准List[0], 伙食费List[0]));
            一周伙食费.Add(new 伙食费("星期二", 伙食费标准List[1], 伙食费List[1]));
            一周伙食费.Add(new 伙食费("星期三", 伙食费标准List[2], 伙食费List[2]));
            一周伙食费.Add(new 伙食费("星期四", 伙食费标准List[3], 伙食费List[3]));
            一周伙食费.Add(new 伙食费("星期五", 伙食费标准List[4], 伙食费List[4]));
            一周伙食费.Add(new 伙食费("星期六", 伙食费标准List[5], 伙食费List[5]));
            一周伙食费.Add(new 伙食费("星期日", 伙食费标准List[6], 伙食费List[6]));
        }

        private void initListView()
        {
            for (int index = 0; index < 7; index++)
            {
                ListViewItem listViewItem = new ListViewItem();

                listViewItem.SubItems.AddRange(new string[] { 一周伙食费[index].调剂标准, 一周伙食费[index].食谱开支 });
                listView1.Items.Add(listViewItem);
            }

        }

        private void initChart()
        {
            chart1.Series.Clear();
            Series series1 = new Series("食谱开支");
            Series series2 = new Series("调剂标准");

            series1.ChartType = SeriesChartType.Column;
            series1.IsValueShownAsLabel = true;
            series1.Color = System.Drawing.Color.Cyan;

            //series2.ChartType = SeriesChartType.Spline;
            series2.ChartType = SeriesChartType.Column;
            series2.IsValueShownAsLabel = true;

            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 0.5;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            //chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
            chart1.ChartAreas[0].AxisX.IsMarginVisible = true;
            chart1.ChartAreas[0].AxisX.Title = "";
            chart1.ChartAreas[0].AxisX.TitleForeColor = System.Drawing.Color.Crimson;

            chart1.ChartAreas[0].AxisY.Title = "元/人.天";
            chart1.ChartAreas[0].AxisY.TitleForeColor = System.Drawing.Color.Crimson;
            chart1.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Horizontal;

            for (int i = 0; i < 一周伙食费.Count; i++)
            {
                series1.Points.AddXY(一周伙食费[i].名称, 一周伙食费[i].食谱开支);
                series2.Points.AddXY(一周伙食费[i].名称, 一周伙食费[i].调剂标准);
            }

            //把series添加到chart上
            chart1.Series.Add(series1);
            chart1.Series.Add(series2);

        }
        
        private Bitmap CaptureScreen()
        {
            Bitmap memoryImage;
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);

            return memoryImage;
        }

        private void printDocument1_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(CaptureScreen(), 0, 0);
        } 

        private void button1_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
