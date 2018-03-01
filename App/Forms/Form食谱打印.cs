using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;
using DataModel;

namespace SP.Forms
{
    public partial class 食谱打印 : Form
    {
        public 食谱打印()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Form http://blog.csdn.net/bigpudding24/article/details/50541276


            string connstring = DBConnect.Instance().getConnectString();

            SqlConnection conn = new SqlConnection(connstring);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from dbo.常用菜肴";

            conn.Open();
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();

            try
            {
                System.Data.SqlClient.SqlDataAdapter ada1 = new System.Data.SqlClient.SqlDataAdapter(cmd);
                ada1.Fill(dt);

            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();

            this.reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.Clear();
            this.reportViewer1.RefreshReport();
        }
    }
}
