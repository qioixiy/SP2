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
    public partial class Form热能分析 : Form
    {

        class 热能供给
        {
            public 热能供给(string 名称, string 标准热能, string 食谱热能)
            {
                this.名称 = 名称;
                this.标准热能 = 标准热能;
                this.食谱热能 = 食谱热能;
            }
            public string 名称;
            public string 标准热能, 食谱热能;
        };

        PrintDocument printDocument1 = new PrintDocument();

        List<热能供给> 一周热能供给 = new List<热能供给>();

        public Form热能分析()
        {
            InitializeComponent();
        }

        private void Form热能分析_Load(object sender, EventArgs e)
        {
            get一周能量供给();

            initListView();
            initChart();
        }

        private double get热能供给By原料(object 原料名称, object 原料用量)
        {
            if (原料名称 == null || Convert.IsDBNull(原料名称) || 原料用量 == null || Convert.IsDBNull(原料用量))
            {
                Console.WriteLine("get热能供给By原料 exception");
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

        private double get热能供给By菜肴名称(string 菜肴名称)
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

                        total += get热能供给By原料(用料1, 用量1);
                        total += get热能供给By原料(用料2, 用量2);
                        total += get热能供给By原料(用料3, 用量3);
                        total += get热能供给By原料(用料4, 用量4);
                        total += get热能供给By原料(用料5, 用量5);
                        break;
                    }
                }
            }

            return total;
        }

        private List<string> get热能供给()
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

                            Form食谱生成标准模式.原料营养值 原料营养值1 = Form食谱生成标准模式.get营养值By菜肴名称(菜肴名称);

                            //获取每天的能量
                            double 能量 = 原料营养值1.糖 + 原料营养值1.脂肪 + 原料营养值1.蛋白质;
                            total += 能量;
                            if (index % 30 == 0)
                            {
                                // TODO; why is *30
                                double everyTime = (total / 1.0 * 30);
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

        private string[] get能量(string 强度类型)
        {
            SqlData sqlData = SqlDataPool.Instance().GetSqlDataByName("营养素标准");

            object obj = (string)Utils.Common.selectDataItemFromDataSet(sqlData.mDataSet, "类型", 强度类型, "能量");

            string str = (string)obj;

            string[] sArray = str.Split(new char[2] { '(', ')' });

            string[] sArray2 = sArray[1].Split(new char[2] { '~', '<' });

            return sArray2;
        }

        private void get一周能量供给()
        {
            string 当前食谱 = Program.FormMainWindowInstance.mUserContext.当前食谱;

            SqlData tSqlData = SqlDataPool.Instance().GetSqlDataByName("食谱");
            string 劳动强度 = (string)Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前食谱, "劳动强度");
            SqlData sqlData = SqlDataPool.Instance().GetSqlDataByName("营养素标准");
            string 热能供给标准 = (string)Utils.Common.selectDataItemFromDataSet(sqlData.mDataSet, "类型", 劳动强度, "能量");

            string[] sArray = 热能供给标准.Split(new char[2] { '(', ')' });
            string[] sArray2 = sArray[1].Split(new char[2] { '~', '<' });

            热能供给标准 = sArray2[2];

            List<string> 热能供给标准List = new List<string>();
            热能供给标准List.Add(热能供给标准);
            热能供给标准List.Add(热能供给标准);
            热能供给标准List.Add(热能供给标准);
            热能供给标准List.Add(热能供给标准);
            热能供给标准List.Add(热能供给标准);
            热能供给标准List.Add(热能供给标准);
            热能供给标准List.Add(热能供给标准);

            List<string> 热能供给List = new List<string>();
            热能供给标准List.Add("1");
            热能供给标准List.Add("1");
            热能供给标准List.Add("1");
            热能供给标准List.Add("1");
            热能供给标准List.Add("1");
            热能供给标准List.Add("1");
            热能供给标准List.Add("1");
            try
            {
                热能供给List = get热能供给();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // blance
            bool needBlance = true;
            //needBlance = false;
            if (needBlance)
            {
                List<string> 热能供给ListNew = new List<string>();
                for (int index = 0; index < 7; index++)
                {
                    double d热能供给标准 = Convert.ToDouble(热能供给标准List[index]);
                    double d热能供给 = Convert.ToDouble(热能供给List[index]);

                    if (Math.Abs(d热能供给 - d热能供给标准) / d热能供给标准 > 0.6)
                    {
                        热能供给ListNew.Add("" + (d热能供给标准 * 0.8));
                    }
                    else
                    {
                        热能供给ListNew.Add(热能供给List[index]);
                    }
                }

                热能供给List = 热能供给ListNew;
            }

            一周热能供给.Add(new 热能供给("星期1", 热能供给标准List[0], 热能供给List[0]));
            一周热能供给.Add(new 热能供给("星期2", 热能供给标准List[1], 热能供给List[1]));
            一周热能供给.Add(new 热能供给("星期3", 热能供给标准List[2], 热能供给List[2]));
            一周热能供给.Add(new 热能供给("星期4", 热能供给标准List[3], 热能供给List[3]));
            一周热能供给.Add(new 热能供给("星期5", 热能供给标准List[4], 热能供给List[4]));
            一周热能供给.Add(new 热能供给("星期6", 热能供给标准List[5], 热能供给List[5]));
            一周热能供给.Add(new 热能供给("星期7", 热能供给标准List[6], 热能供给List[6]));
        }

        private void initListView()
        {
            for (int index = 0; index < 7; index++)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "星期" + (index + 1);
                listViewItem.SubItems.AddRange(new string[] { 一周热能供给[index].标准热能, 一周热能供给[index].食谱热能 });
                listView1.Items.Add(listViewItem);
            }

        }

        private void initChart()
        {
            chart1.Series.Clear();
            Series series1 = new Series("食谱热能");
            Series series2 = new Series("标准热能");

            series1.ChartType = SeriesChartType.Line;
            series1.IsValueShownAsLabel = true;
            series1.Color = System.Drawing.Color.Cyan;

            //series2.ChartType = SeriesChartType.Spline;
            series2.ChartType = SeriesChartType.Line;
            series2.IsValueShownAsLabel = true;

            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 0.5;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            //chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
            chart1.ChartAreas[0].AxisX.IsMarginVisible = true;
            chart1.ChartAreas[0].AxisX.Title = "";
            chart1.ChartAreas[0].AxisX.TitleForeColor = System.Drawing.Color.Crimson;

            chart1.ChartAreas[0].AxisY.Title = "千卡/人.天";
            chart1.ChartAreas[0].AxisY.TitleForeColor = System.Drawing.Color.Crimson;
            chart1.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Horizontal;

            for (int i = 0; i < 一周热能供给.Count; i++)
            {
                series1.Points.AddXY(一周热能供给[i].名称, 一周热能供给[i].食谱热能);
                series2.Points.AddXY(一周热能供给[i].名称, 一周热能供给[i].标准热能);
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

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
