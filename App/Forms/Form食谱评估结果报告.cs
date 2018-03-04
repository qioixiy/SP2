﻿using System;
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

            ReportParameter strrp = new ReportParameter("ReportParameter使用单位", "参数值");
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { strrp });

            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();

            this.reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.Clear();

            this.reportViewer1.RefreshReport();
        }
    }
}
