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
using Microsoft.Reporting.WinForms;
using SP.Utils;

namespace SP.Forms
{
    public partial class Form食谱公布表打印 : Form
    {
        public Form食谱公布表打印()
        {
            InitializeComponent();
        }

        private void Form食谱公布表打印_Load(object sender, EventArgs e)
        {
            string connstring = DBConnect.Instance().getConnectString();

            SqlConnection conn = new SqlConnection(connstring);

            SqlCommand cmd = conn.CreateCommand();
            string 当前食谱 = Program.FormMainWindowInstance.mUserContext.当前食谱;
            cmd.CommandText = "select * from dbo.食谱 where 名称 = '" + 当前食谱 + "'";

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

            ReportDataSource rds = new ReportDataSource("DataSet食谱", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();

            this.reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.Clear();

            this.reportViewer1.RefreshReport();
        }

        private void Form食谱公布表打印_FormClosing(object sender, FormClosingEventArgs e)
        {
            reportViewer1.LocalReport.ReleaseSandboxAppDomain();
            reportViewer1.LocalReport.Dispose();
        }
    }
}
