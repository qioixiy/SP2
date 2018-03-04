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
using Microsoft.Reporting.WinForms;

namespace SP.Forms
{
    public partial class Form食谱评估结果报告 : Form
    {
        public Form食谱评估结果报告()
        {
            InitializeComponent();
        }

        class Pair
        {
            public Pair(string key, string value)
            {
                this.key = key;
                this.value = value;
            }
            public string key, value;
        };

        private void Form食谱评估结果报告_Load(object sender, EventArgs e)
        {
            string connstring = DBConnect.Instance().getConnectString();

            SqlConnection conn = new SqlConnection(connstring);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from dbo.食谱";

            conn.Open();
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();

            try
            {
                System.Data.SqlClient.SqlDataAdapter ada1 = new System.Data.SqlClient.SqlDataAdapter(cmd);
                ada1.Fill(dt);
                Common.dumpDataTable(dt);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

            List<ReportParameter> reportParameterList = new List<ReportParameter>();

            reportParameterList.Add(new ReportParameter("ReportParameter使用单位", "参数值"));
            reportParameterList.Add(new ReportParameter("ReportParameter使用时间", "参数值"));
            reportParameterList.Add(new ReportParameter("ReportParameter食谱要求", "参数值"));
            reportParameterList.Add(new ReportParameter("ReportParameter评估时间", "参数值"));

            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_实际值_1", "参数值"));
            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_实际值_2", "参数值"));
            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_实际值_3", "参数值"));
            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_实际值_4", "参数值"));
            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_实际值_5", "参数值"));
            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_实际值_6", "参数值"));

            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_得分_1", "10"));
            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_得分_2", "10"));
            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_得分_3", "10"));
            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_得分_4", "10"));
            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_得分_5", "10"));
            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_得分_6", "10"));

            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_得分_和", "100"));

            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_实际值_热能", "参数值"));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_实际值_蛋白质", "参数值"));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_实际值_优质蛋白质", "参数值"));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_实际值_蛋白质脂肪糖发热", "参数值"));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_实际值_动物性来源脂肪", "参数值"));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_实际值_钙", "参数值"));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_实际值_铁", "参数值"));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_实际值_锌", "参数值"));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_实际值_硒", "参数值"));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_实际值_维A", "参数值"));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_实际值_维E", "参数值"));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_实际值_维B1", "参数值"));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_实际值_维B2", "参数值"));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_实际值_维PP", "参数值"));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_实际值_维C", "参数值"));

            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_得分_热能", "10"));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_得分_蛋白质", "10"));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_得分_优质蛋白质", "10"));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_得分_蛋白质脂肪糖发热", "10"));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_得分_动物性来源脂肪", "10"));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_得分_钙", "10"));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_得分_铁", "10"));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_得分_锌", "10"));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_得分_硒", "10"));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_得分_维A", "10"));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_得分_维E", "10"));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_得分_维B1", "10"));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_得分_维B2", "10"));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_得分_维PP", "10"));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_得分_维C", "10"));

            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_得分_和", "100"));
            reportViewer1.LocalReport.SetParameters(reportParameterList);

            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.Clear();

            reportViewer1.RefreshReport();
        }

        private void Form食谱评估结果报告_FormClosing(object sender, FormClosingEventArgs e)
        {
            reportViewer1.LocalReport.ReleaseSandboxAppDomain();
            reportViewer1.LocalReport.Dispose();
        }
    }
}
