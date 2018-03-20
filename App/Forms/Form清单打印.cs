using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using DataModel;
using System.Data.SqlClient;
using SP.Utils;
using SP.DataModel;

namespace SP.Forms
{
    public partial class Form清单打印 : Form
    {
        public Form清单打印()
        {
            InitializeComponent();
        }

        private string objectToString(object obj)
        {
            string ret = "";

            if (!Convert.IsDBNull(obj))
            {
                try
                {
                    ret = (string)obj;
                }
                catch (Exception ex)
                {

                }
            }

            return ret;
        }

        private 外购清单 get当前外购清单()
        {
            外购清单 ret = new 外购清单();

            string 当前外购清单 = Program.FormMainWindowInstance.mUserContext.当前外购清单;
            SqlData tSqlData = SqlDataPool.Instance().GetSqlDataByName("外购清单");

            ret.原料名称1 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "原料名称1"));
            ret.原料名称2 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "原料名称2"));
            ret.原料名称3 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "原料名称3"));
            ret.原料名称4 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "原料名称4"));
            ret.原料名称5 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "原料名称5"));
            ret.原料名称6 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "原料名称6"));
            ret.原料名称7 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "原料名称7"));
            ret.原料名称8 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "原料名称8"));
            ret.原料名称9 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "原料名称9"));
            ret.原料名称10 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "原料名称10"));
            ret.原料名称11 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "原料名称11"));
            ret.原料名称12 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "原料名称12"));
            ret.原料名称13 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "原料名称13"));
            ret.原料名称14 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "原料名称14"));
            ret.原料名称15 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "原料名称15"));
            ret.原料名称16 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "原料名称16"));
            ret.原料名称17 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "原料名称17"));
            ret.原料名称18 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "原料名称18"));
            ret.原料名称19 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "原料名称19"));
            ret.原料名称20 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "原料名称20"));
            ret.总量1 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "总量1"));
            ret.总量2 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "总量2"));
            ret.总量3 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "总量3"));
            ret.总量4 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "总量4"));
            ret.总量5 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "总量5"));
            ret.总量6 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "总量6"));
            ret.总量7 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "总量7"));
            ret.总量8 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "总量8"));
            ret.总量9 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "总量9"));
            ret.总量10 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "总量10"));
            ret.总量11 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "总量11"));
            ret.总量12 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "总量12"));
            ret.总量13 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "总量13"));
            ret.总量14 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "总量14"));
            ret.总量15 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "总量15"));
            ret.总量16 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "总量16"));
            ret.总量17 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "总量17"));
            ret.总量18 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "总量18"));
            ret.总量19 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "总量19"));
            ret.总量20 = objectToString(Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 当前外购清单, "总量20"));
            
            return ret;
        }

        private void Form清单打印_Load(object sender, EventArgs e)
        {
            initDataSet1();
            try
            {
                List<ReportParameter> reportParameterList = new List<ReportParameter>();

                外购清单 外购清单Obj = get当前外购清单();

                reportParameterList.Add(new ReportParameter("ReportParameter原料名称1", 外购清单Obj.原料名称1));
                reportParameterList.Add(new ReportParameter("ReportParameter原料名称2", 外购清单Obj.原料名称2));
                reportParameterList.Add(new ReportParameter("ReportParameter原料名称3", 外购清单Obj.原料名称3));
                reportParameterList.Add(new ReportParameter("ReportParameter原料名称4", 外购清单Obj.原料名称4));
                reportParameterList.Add(new ReportParameter("ReportParameter原料名称5", 外购清单Obj.原料名称5));
                reportParameterList.Add(new ReportParameter("ReportParameter原料名称6", 外购清单Obj.原料名称6));
                reportParameterList.Add(new ReportParameter("ReportParameter原料名称7", 外购清单Obj.原料名称7));
                reportParameterList.Add(new ReportParameter("ReportParameter原料名称8", 外购清单Obj.原料名称8));
                reportParameterList.Add(new ReportParameter("ReportParameter原料名称9", 外购清单Obj.原料名称9));
                reportParameterList.Add(new ReportParameter("ReportParameter原料名称10", 外购清单Obj.原料名称10));
                reportParameterList.Add(new ReportParameter("ReportParameter原料名称11", 外购清单Obj.原料名称11));
                reportParameterList.Add(new ReportParameter("ReportParameter原料名称12", 外购清单Obj.原料名称12));
                reportParameterList.Add(new ReportParameter("ReportParameter原料名称13", 外购清单Obj.原料名称13));
                reportParameterList.Add(new ReportParameter("ReportParameter原料名称14", 外购清单Obj.原料名称14));
                reportParameterList.Add(new ReportParameter("ReportParameter原料名称15", 外购清单Obj.原料名称15));
                reportParameterList.Add(new ReportParameter("ReportParameter原料名称16", 外购清单Obj.原料名称16));
                reportParameterList.Add(new ReportParameter("ReportParameter原料名称17", 外购清单Obj.原料名称17));
                reportParameterList.Add(new ReportParameter("ReportParameter原料名称18", 外购清单Obj.原料名称18));
                reportParameterList.Add(new ReportParameter("ReportParameter原料名称19", 外购清单Obj.原料名称19));
                reportParameterList.Add(new ReportParameter("ReportParameter原料名称20", 外购清单Obj.原料名称20));
                reportParameterList.Add(new ReportParameter("ReportParameter总量1", 外购清单Obj.总量1));
                reportParameterList.Add(new ReportParameter("ReportParameter总量2", 外购清单Obj.总量2));
                reportParameterList.Add(new ReportParameter("ReportParameter总量3", 外购清单Obj.总量3));
                reportParameterList.Add(new ReportParameter("ReportParameter总量4", 外购清单Obj.总量4));
                reportParameterList.Add(new ReportParameter("ReportParameter总量5", 外购清单Obj.总量5));
                reportParameterList.Add(new ReportParameter("ReportParameter总量6", 外购清单Obj.总量6));
                reportParameterList.Add(new ReportParameter("ReportParameter总量7", 外购清单Obj.总量7));
                reportParameterList.Add(new ReportParameter("ReportParameter总量8", 外购清单Obj.总量8));
                reportParameterList.Add(new ReportParameter("ReportParameter总量9", 外购清单Obj.总量9));
                reportParameterList.Add(new ReportParameter("ReportParameter总量10", 外购清单Obj.总量10));
                reportParameterList.Add(new ReportParameter("ReportParameter总量11", 外购清单Obj.总量11));
                reportParameterList.Add(new ReportParameter("ReportParameter总量12", 外购清单Obj.总量12));
                reportParameterList.Add(new ReportParameter("ReportParameter总量13", 外购清单Obj.总量13));
                reportParameterList.Add(new ReportParameter("ReportParameter总量14", 外购清单Obj.总量14));
                reportParameterList.Add(new ReportParameter("ReportParameter总量15", 外购清单Obj.总量15));
                reportParameterList.Add(new ReportParameter("ReportParameter总量16", 外购清单Obj.总量16));
                reportParameterList.Add(new ReportParameter("ReportParameter总量17", 外购清单Obj.总量17));
                reportParameterList.Add(new ReportParameter("ReportParameter总量18", 外购清单Obj.总量18));
                reportParameterList.Add(new ReportParameter("ReportParameter总量19", 外购清单Obj.总量19));
                reportParameterList.Add(new ReportParameter("ReportParameter总量20", 外购清单Obj.总量20));

                string 当前外购清单 = Program.FormMainWindowInstance.mUserContext.当前外购清单;
                SqlData tSqlData = SqlDataPool.Instance().GetSqlDataByName("外购清单");
                string 食谱 = (string)Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称",当前外购清单, "对应食谱名称");
                tSqlData = SqlDataPool.Instance().GetSqlDataByName("食谱");
                string 单位首长 = (string)Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称",食谱, "单位首长");
                string 司务长 = (string)Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 食谱, "司务长");
                reportParameterList.Add(new ReportParameter("ReportParameter单位首长", 单位首长));
                reportParameterList.Add(new ReportParameter("ReportParameter司务长", 司务长));

                reportViewer1.LocalReport.SetParameters(reportParameterList);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void initDataSet1()
        {
            string connstring = DBConnect.Instance().getConnectString();

            SqlConnection conn = new SqlConnection(connstring);

            SqlCommand cmd = conn.CreateCommand();
            string 当前外购清单 = Program.FormMainWindowInstance.mUserContext.当前外购清单;
            cmd.CommandText = "select * from dbo.外购清单 where 名称 = '" + 当前外购清单 + "'";

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

            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();

            this.reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.Clear();

            this.reportViewer1.RefreshReport();
        }

        private void Form清单打印_FormClosing(object sender, FormClosingEventArgs e)
        {
            reportViewer1.LocalReport.ReleaseSandboxAppDomain();
            reportViewer1.LocalReport.Dispose();
        }
    }
}
