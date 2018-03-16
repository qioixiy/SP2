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

        private void get一周伙食费()
        {
            一周伙食费.Add(new 伙食费("星期一", "20", "10"));
            一周伙食费.Add(new 伙食费("星期二", "22", "12"));
            一周伙食费.Add(new 伙食费("星期三", "24", "12"));
            一周伙食费.Add(new 伙食费("星期四", "23", "14"));
            一周伙食费.Add(new 伙食费("星期五", "21", "18"));
            一周伙食费.Add(new 伙食费("星期六", "19", "12"));
            一周伙食费.Add(new 伙食费("星期日", "15", "11"));
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

            series2.ChartType = SeriesChartType.Spline;
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
                series1.Points.AddXY(一周伙食费[i].名称, 一周伙食费[i].调剂标准);
                series1.Points.AddXY(一周伙食费[i].名称, 一周伙食费[i].食谱开支);
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
