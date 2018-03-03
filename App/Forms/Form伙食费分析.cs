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
        PrintDocument printDocument1 = new PrintDocument();

        public Form伙食费分析()
        {
            InitializeComponent();
        }

        private void Form伙食费分析_Load(object sender, EventArgs e)
        {
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

            //这是添加的两组数据
            List<int> txData2 = new List<int>() { 2011, 2012, 2013, 2014, 2015, 2016 };
            List<int> tyData2 = new List<int>() { 9, 6, 7, 4, 5, 4 };
            List<int> txData3 = new List<int>() { 2012 };
            List<int> tyData3 = new List<int>() { 7 };

            Chart ct = chart1;
            //若为new一个Chart，需同时Add其Title，Series,ChartAreas等属性
            //若是直接拖入控件则只需在控件属性中自己调整就好
            //标题
            ct.Titles.Add("我的历年合同均价(元/兆千瓦时)");
            //背景
            ct.ChartAreas.Add(new ChartArea() { Name = "ca1" });     //背景框
            ct.ChartAreas[0].Axes[0].MajorGrid.Enabled = false;       //X轴上网格
            ct.ChartAreas[0].Axes[1].MajorGrid.Enabled = false;      //y轴上网格
            ct.ChartAreas[0].Axes[0].MajorGrid.LineDashStyle = ChartDashStyle.Dash;   //网格类型 短横线
            ct.ChartAreas[0].Axes[0].MajorGrid.LineColor = Color.Gray;
            ct.ChartAreas[0].Axes[0].MajorTickMark.Enabled = false;                   //  x轴上突出的小点
            ct.ChartAreas[0].Axes[1].MajorTickMark.Enabled = false;                  //
            ct.ChartAreas[0].Axes[1].IsInterlaced = true;  //显示交错带 
            ct.ChartAreas[0].Axes[0].LabelStyle.Format = "#年";                      //设置X轴显示样式
            ct.ChartAreas[0].Axes[1].MajorGrid.LineDashStyle = ChartDashStyle.Dash;   //网格类型 短横线
            ct.ChartAreas[0].Axes[1].MajorGrid.LineColor = Color.Gray;
            ct.ChartAreas[0].Axes[1].MajorGrid.LineWidth = 3;
            //图表数据区，有多个重叠则循环添加
            ct.Series.Add(new Series()); //添加一个图表序列
            // ct.Series[0].XValueType = ChartValueType.String;  //设置X轴上的值类型
            ct.Series[0].Label = "#VAL";                //设置显示X Y的值    
            ct.Series[0].ToolTip = "#VALX年\r#VAL";     //鼠标移动到对应点显示数值
            ct.Series[0].ChartArea = "ca1";                   //设置图表背景框
            ct.Series[0].ChartType = SeriesChartType.Line;    //图类型(折线)
            ct.Series[0].Points.DataBindXY(txData2, tyData2); //添加数据
            //折线段配置
            ct.Series[0].Color = Color.Red;               //线条颜色
            ct.Series[0].BorderWidth = 3;                 //线条粗细
            ct.Series[0].MarkerBorderColor = Color.Red;   //标记点边框颜色
            ct.Series[0].MarkerBorderWidth = 3;             //标记点边框大小
            ct.Series[0].MarkerColor = Color.Red;       //标记点中心颜色
            ct.Series[0].MarkerSize = 5;                 //标记点大小
            ct.Series[0].MarkerStyle = MarkerStyle.Circle;  //标记点类型

            ct.Series.Add(new Series()); //添加一个图表序列
            ct.Series[1].Label = "#VAL";                //设置显示X Y的值
            ct.Series[1].ToolTip = "#VALX年\r#VAL";     //鼠标移动到对应点显示数值
            ct.Series[1].ChartType = SeriesChartType.Line;    //图类型(折线)
            ct.Series[1].Points.DataBindXY(txData3, tyData3); //添加数据
            //折线段配置
            ct.Series[1].Color = Color.Black;               //线条颜色
            ct.Series[1].BorderWidth = 3;                   //线条粗细
            ct.Series[1].MarkerBorderColor = Color.Black;   //标记点边框颜色
            ct.Series[1].MarkerBorderWidth = 3;             //标记点边框大小
            ct.Series[1].MarkerColor = Color.Black;         //标记点中心颜色
            ct.Series[1].MarkerSize = 5;                    //标记点大小
            ct.Series[1].MarkerStyle = MarkerStyle.Circle;  //标记点类型

            //另外
            //饼图说明设置，这用来设置饼图每一块的信息显示在什么地方
            ct.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
            ct.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
            //柱状图其他设置
            ct.Series[0]["DrawingStyle"] = "Emboss";   //设置柱状平面形状
            ct.Series[0]["PointWidth"] = "0.5"; //设置柱状大小

        }
        
        Bitmap memoryImage;
        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(
           this.Location.X, this.Location.Y, 0, 0, s);
        }

        private void printDocument1_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        } 

        private void button1_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            printDocument1.Print();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
