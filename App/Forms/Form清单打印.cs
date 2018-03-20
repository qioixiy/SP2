using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace SP.Forms
{
    public partial class Form清单打印 : Form
    {
        public Form清单打印()
        {
            InitializeComponent();
        }

        private void Form清单打印_Load(object sender, EventArgs e)
        {
            string 当前外购清单 = Program.FormMainWindowInstance.mUserContext.当前外购清单;
            SqlData tSqlData = SqlDataPool.Instance().GetSqlDataByName("外购清单");

            List<ReportParameter> reportParameterList = new List<ReportParameter>();

            reportParameterList.Add(new ReportParameter("ReportParameter原料名称1", "xxxx"));


            ReportDataSource rds = new ReportDataSource("DataSet1", tSqlData.mDataSet);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.LocalReport.SetParameters(reportParameterList);

            this.reportViewer1.RefreshReport();
        }

        private void Form清单打印_FormClosing(object sender, FormClosingEventArgs e)
        {
            reportViewer1.LocalReport.ReleaseSandboxAppDomain();
            reportViewer1.LocalReport.Dispose();
        }
    }
}
