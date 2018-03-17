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

        class 食物定量
        {
            public string 动物性食品;
            public string 黄豆;
            public string 蔬菜;
            public string 蔗糖;
            public string 海带;
            public string 豆乳粉;
        }

        class 营养素供给
        {
            public string 热能;
            public string 蛋白质;
            public string 优质蛋白质;
            public string 蛋白质脂肪糖发热;
            public string 动物性来源脂肪;
            public string 钙;
            public string 铁;
            public string 锌;
            public string 硒;
            public string 维A;
            public string 维E;
            public string 维B1;
            public string 维B2;
            public string 维PP;
            public string 维C;
        }

        class Parameter
        {
            public Parameter()
            {
                食物定量标准值 = new 食物定量();
                食物定量实际值 = new 食物定量();
                食物定量权重 = new 食物定量();
                食物定量得分 = new 食物定量();

                营养素供给标准值 = new 营养素供给();
                营养素供给实际值 = new 营养素供给();
                营养素供给权重 = new 营养素供给();
                营养素供给得分 = new 营养素供给();

                get食物定量标准值();
                get食物定量实际值();
                get食物定量权重();
                get食物定量得分();

                get营养素供给标准值();
                get营养素供给实际值();
                get营养素供给权重();
                get营养素供给得分();
            }

            void get食物定量标准值()
            {
                string 当前食谱 = Program.FormMainWindowInstance.mUserContext.当前食谱;
                SqlData sqlData = SqlDataPool.Instance().GetSqlDataByName("食谱");
                object obj = Common.selectDataItemFromDataSet(sqlData.mDataSet, "名称", 当前食谱, "灶别");
                sqlData = SqlDataPool.Instance().GetSqlDataByName("食物定量标准");
                string 动物性食品 = Convert.ToString(Convert.ToInt32(Common.selectDataItemFromDataSet(sqlData.mDataSet, "灶别", (string)obj, "猪肉"))
                    + Convert.ToInt32(Common.selectDataItemFromDataSet(sqlData.mDataSet, "灶别", (string)obj, "牛羊肉"))
                    + Convert.ToInt32(Common.selectDataItemFromDataSet(sqlData.mDataSet, "灶别", (string)obj, "禽肉"))
                    + Convert.ToInt32(Common.selectDataItemFromDataSet(sqlData.mDataSet, "灶别", (string)obj, "禽蛋"))
                    + Convert.ToInt32(Common.selectDataItemFromDataSet(sqlData.mDataSet, "灶别", (string)obj, "鱼虾")));
                string 黄豆 = (string)Common.selectDataItemFromDataSet(sqlData.mDataSet, "灶别", (string)obj, "黄豆");
                string 蔬菜 = (string)Common.selectDataItemFromDataSet(sqlData.mDataSet, "灶别", (string)obj, "蔬菜");
                string 蔗糖 = (string)Common.selectDataItemFromDataSet(sqlData.mDataSet, "灶别", (string)obj, "蔗糖");
                string 海带 = (string)Common.selectDataItemFromDataSet(sqlData.mDataSet, "灶别", (string)obj, "海带");
                string 豆乳粉 = (string)Common.selectDataItemFromDataSet(sqlData.mDataSet, "灶别", (string)obj, "豆乳粉");

                食物定量标准值.动物性食品 = 动物性食品;
                食物定量标准值.黄豆 = 黄豆;
                食物定量标准值.蔬菜 = 蔬菜;
                食物定量标准值.蔗糖 = 蔗糖;
                食物定量标准值.海带 = 海带;
                食物定量标准值.豆乳粉 = 豆乳粉;
            }

            void get食物定量实际值()
            {
                食物定量实际值.动物性食品 = 食物定量标准值.动物性食品;
                食物定量实际值.黄豆 = 食物定量标准值.黄豆;
                食物定量实际值.蔬菜 = 食物定量标准值.蔬菜;
                食物定量实际值.蔗糖 = 食物定量标准值.蔗糖;
                食物定量实际值.海带 = 食物定量标准值.海带;
                食物定量实际值.豆乳粉 = 食物定量标准值.豆乳粉;
            }

            void get食物定量权重()
            {
                食物定量权重.动物性食品 = "0.40";
                食物定量权重.黄豆 = "0.20";
                食物定量权重.蔬菜 = "0.25";
                食物定量权重.蔗糖 = "0.05";
                食物定量权重.海带 = "0.05";
                食物定量权重.豆乳粉 = "0.05";
            }

            void get食物定量得分()
            {
                食物定量得分.动物性食品 = Convert.ToString(Math.Round(Convert.ToDouble(食物定量标准值.动物性食品) / Convert.ToDouble(食物定量实际值.动物性食品) * 100));
                食物定量得分.黄豆 = Convert.ToString(Math.Round(Convert.ToDouble(食物定量标准值.黄豆) / Convert.ToDouble(食物定量实际值.黄豆) * 100));
                食物定量得分.蔬菜 = Convert.ToString(Math.Round(Convert.ToDouble(食物定量标准值.蔬菜) / Convert.ToDouble(食物定量实际值.蔬菜) * 100));
                食物定量得分.蔗糖 = Convert.ToString(Math.Round(Convert.ToDouble(食物定量标准值.蔗糖) / Convert.ToDouble(食物定量实际值.蔗糖) * 100));
                食物定量得分.海带 = Convert.ToString(Math.Round(Convert.ToDouble(食物定量标准值.海带) / Convert.ToDouble(食物定量实际值.海带) * 100));
                食物定量得分.豆乳粉 = Convert.ToString(Math.Round(Convert.ToDouble(食物定量标准值.豆乳粉) / Convert.ToDouble(食物定量实际值.豆乳粉) * 100));
            }

            void get营养素供给标准值()
            {
                string 当前食谱 = Program.FormMainWindowInstance.mUserContext.当前食谱;
                SqlData sqlData = SqlDataPool.Instance().GetSqlDataByName("食谱");
                object 劳动强度 = Common.selectDataItemFromDataSet(sqlData.mDataSet, "名称", 当前食谱, "劳动强度");
                sqlData = SqlDataPool.Instance().GetSqlDataByName("营养素标准");
                string 能量 = (string)Common.selectDataItemFromDataSet(sqlData.mDataSet, "类型", (string)劳动强度, "能量");
                string[] sArray = 能量.Split(new char[2] { '(', ')' });
                string[] sArray2 = sArray[1].Split(new char[2] { '~', '<' });
                能量 = sArray2[2];
                string 蛋白质 = (string)Common.selectDataItemFromDataSet(sqlData.mDataSet, "类型", (string)劳动强度, "蛋白质");
                
                string 钙 = (string)Common.selectDataItemFromDataSet(sqlData.mDataSet, "类型", (string)劳动强度, "钙");
                string 铁 = (string)Common.selectDataItemFromDataSet(sqlData.mDataSet, "类型", (string)劳动强度, "铁");
                string 锌 = (string)Common.selectDataItemFromDataSet(sqlData.mDataSet, "类型", (string)劳动强度, "锌");
                string 硒 = (string)Common.selectDataItemFromDataSet(sqlData.mDataSet, "类型", (string)劳动强度, "硒");
                string 维A = (string)Common.selectDataItemFromDataSet(sqlData.mDataSet, "类型", (string)劳动强度, "维生素A");
                string 维E = (string)Common.selectDataItemFromDataSet(sqlData.mDataSet, "类型", (string)劳动强度, "维生素E");
                string 维B1 = (string)Common.selectDataItemFromDataSet(sqlData.mDataSet, "类型", (string)劳动强度, "维生素B1");
                string 维B2 = (string)Common.selectDataItemFromDataSet(sqlData.mDataSet, "类型", (string)劳动强度, "维生素B2");
                string 维PP = (string)Common.selectDataItemFromDataSet(sqlData.mDataSet, "类型", (string)劳动强度, "烟酸");
                string 维C = (string)Common.selectDataItemFromDataSet(sqlData.mDataSet, "类型", (string)劳动强度, "维生素C");

                营养素供给标准值.热能 = (string)能量;
                营养素供给标准值.蛋白质 = 蛋白质;
                营养素供给标准值.优质蛋白质 = "30-50";
                营养素供给标准值.蛋白质脂肪糖发热 = "13.5:25:60";
                营养素供给标准值.动物性来源脂肪 = "40";
                营养素供给标准值.钙 = 钙;
                营养素供给标准值.铁 = 铁;
                营养素供给标准值.锌 = 锌;
                营养素供给标准值.硒 = 硒;
                营养素供给标准值.维A = 维A;
                营养素供给标准值.维E = 维E;
                营养素供给标准值.维B1 = 维B1;
                营养素供给标准值.维B2 = 维B2;
                营养素供给标准值.维PP = 维PP;
                营养素供给标准值.维C = 维C;
            }

            void get营养素供给实际值()
            {
                营养素供给实际值.热能 = 营养素供给标准值.热能;
                营养素供给实际值.蛋白质 = 营养素供给标准值.蛋白质;
                营养素供给实际值.优质蛋白质 = 营养素供给标准值.优质蛋白质;
                营养素供给实际值.蛋白质脂肪糖发热 = 营养素供给标准值.蛋白质脂肪糖发热;
                营养素供给实际值.动物性来源脂肪 = 营养素供给标准值.动物性来源脂肪;
                营养素供给实际值.钙 = 营养素供给标准值.钙;
                营养素供给实际值.铁 = 营养素供给标准值.铁;
                营养素供给实际值.锌 = 营养素供给标准值.锌;
                营养素供给实际值.硒 = 营养素供给标准值.硒;
                营养素供给实际值.维A = 营养素供给标准值.维A;
                营养素供给实际值.维E = 营养素供给标准值.维E;
                营养素供给实际值.维B1 = 营养素供给标准值.维B1;
                营养素供给实际值.维B2 = 营养素供给标准值.维B2;
                营养素供给实际值.维PP = 营养素供给标准值.维PP;
                营养素供给实际值.维C = 营养素供给标准值.维C;
            }

            void get营养素供给权重()
            {
                营养素供给权重.热能 = "0.25";
                营养素供给权重.蛋白质 = "0.10";
                营养素供给权重.优质蛋白质 = "0.15";
                营养素供给权重.蛋白质脂肪糖发热 = "0.25";
                营养素供给权重.动物性来源脂肪 = "0.10";
                营养素供给权重.钙 = "0.02";
                营养素供给权重.铁 = "0.01";
                营养素供给权重.锌 = "0.01";
                营养素供给权重.硒 = "0.01";
                营养素供给权重.维A = "0.02";
                营养素供给权重.维E = "0.01";
                营养素供给权重.维B1 = "0.01";
                营养素供给权重.维B2 = "0.02";
                营养素供给权重.维PP = "0.01";
                营养素供给权重.维C = "0.03";
            }

            void get营养素供给得分()
            {
                营养素供给得分.热能 = Convert.ToString(Math.Round(Convert.ToDouble(营养素供给标准值.热能) / Convert.ToDouble(营养素供给实际值.热能) * 100));
                营养素供给得分.蛋白质 = Convert.ToString(Math.Round(Convert.ToDouble(营养素供给标准值.蛋白质) / Convert.ToDouble(营养素供给实际值.蛋白质) * 100));
                try
                {
                    营养素供给得分.优质蛋白质 = Convert.ToString(Math.Round(Convert.ToDouble(营养素供给标准值.优质蛋白质) / Convert.ToDouble(营养素供给实际值.优质蛋白质) * 100)); ;
                    营养素供给得分.蛋白质脂肪糖发热 = Convert.ToString(Math.Round(Convert.ToDouble(营养素供给标准值.蛋白质脂肪糖发热) / Convert.ToDouble(营养素供给实际值.蛋白质脂肪糖发热) * 100)); ;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    营养素供给得分.优质蛋白质 = "100";
                    营养素供给得分.蛋白质脂肪糖发热 = "100";
                }
                营养素供给得分.动物性来源脂肪 = Convert.ToString(Math.Round(Convert.ToDouble(营养素供给标准值.动物性来源脂肪) / Convert.ToDouble(营养素供给实际值.动物性来源脂肪) * 100)); ;
                营养素供给得分.钙 = Convert.ToString(Math.Round(Convert.ToDouble(营养素供给标准值.钙) / Convert.ToDouble(营养素供给实际值.钙) * 100)); ;
                营养素供给得分.铁 = Convert.ToString(Math.Round(Convert.ToDouble(营养素供给标准值.铁) / Convert.ToDouble(营养素供给实际值.铁) * 100)); ;
                营养素供给得分.锌 = Convert.ToString(Math.Round(Convert.ToDouble(营养素供给标准值.锌) / Convert.ToDouble(营养素供给实际值.锌) * 100)); ;
                营养素供给得分.硒 = Convert.ToString(Math.Round(Convert.ToDouble(营养素供给标准值.硒) / Convert.ToDouble(营养素供给实际值.硒) * 100)); ;
                营养素供给得分.维A = Convert.ToString(Math.Round(Convert.ToDouble(营养素供给标准值.维A) / Convert.ToDouble(营养素供给实际值.维A) * 100)); ;
                营养素供给得分.维E = Convert.ToString(Math.Round(Convert.ToDouble(营养素供给标准值.维E) / Convert.ToDouble(营养素供给实际值.维E) * 100)); ;
                营养素供给得分.维B1 = Convert.ToString(Math.Round(Convert.ToDouble(营养素供给标准值.维B1) / Convert.ToDouble(营养素供给实际值.维B1) * 100)); ;
                营养素供给得分.维B2 = Convert.ToString(Math.Round(Convert.ToDouble(营养素供给标准值.维B2) / Convert.ToDouble(营养素供给实际值.维B2) * 100)); ;
                营养素供给得分.维PP = Convert.ToString(Math.Round(Convert.ToDouble(营养素供给标准值.维PP) / Convert.ToDouble(营养素供给实际值.维PP) * 100)); ;
                营养素供给得分.维C = Convert.ToString(Math.Round(Convert.ToDouble(营养素供给标准值.维C) / Convert.ToDouble(营养素供给实际值.维C) * 100)); ;
            }
            
            public 食物定量 食物定量标准值;
            public 食物定量 食物定量实际值;
            public 食物定量 食物定量权重;
            public 食物定量 食物定量得分;

            public 营养素供给 营养素供给标准值;
            public 营养素供给 营养素供给实际值;
            public 营养素供给 营养素供给权重;
            public 营养素供给 营养素供给得分;
        }

        private object getItem(string itemName)
        {
            SqlData sqlData = SqlDataPool.Instance().GetSqlDataByName("食谱");
            string 当前食谱 = Program.FormMainWindowInstance.mUserContext.当前食谱;

            object obj = Common.selectDataItemFromDataSet(sqlData.mDataSet, "名称", 当前食谱, itemName);

            return obj;
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

            List<ReportParameter> reportParameterList = new List<ReportParameter>();

            reportParameterList.Add(new ReportParameter("ReportParameter使用单位", (string)getItem("单位")));
            reportParameterList.Add(new ReportParameter("ReportParameter使用时间", (string)getItem("生成日期")));
            reportParameterList.Add(new ReportParameter("ReportParameter食谱要求", (string)getItem("灶别") + (string)getItem("劳动强度")));
            reportParameterList.Add(new ReportParameter("ReportParameter评估时间", DateTime.Now.ToString("yyyy-MM-dd")));

            Parameter tParameter = new Parameter();

            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_标准值_1", tParameter.食物定量标准值.动物性食品));
            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_标准值_2", tParameter.食物定量标准值.黄豆));
            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_标准值_3", tParameter.食物定量标准值.蔬菜));
            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_标准值_4", tParameter.食物定量标准值.蔗糖));
            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_标准值_5", tParameter.食物定量标准值.海带));
            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_标准值_6", tParameter.食物定量标准值.豆乳粉));

            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_实际值_1", tParameter.食物定量实际值.动物性食品));
            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_实际值_2", tParameter.食物定量实际值.黄豆));
            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_实际值_3", tParameter.食物定量实际值.蔬菜));
            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_实际值_4", tParameter.食物定量实际值.蔗糖));
            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_实际值_5", tParameter.食物定量实际值.海带));
            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_实际值_6", tParameter.食物定量实际值.豆乳粉));

            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_权重_1", tParameter.食物定量权重.动物性食品));
            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_权重_2", tParameter.食物定量权重.黄豆));
            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_权重_3", tParameter.食物定量权重.蔬菜));
            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_权重_4", tParameter.食物定量权重.蔗糖));
            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_权重_5", tParameter.食物定量权重.海带));
            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_权重_6", tParameter.食物定量权重.豆乳粉));

            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_得分_1", tParameter.食物定量得分.动物性食品));
            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_得分_2", tParameter.食物定量得分.黄豆));
            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_得分_3", tParameter.食物定量得分.蔬菜));
            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_得分_4", tParameter.食物定量得分.蔗糖));
            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_得分_5", tParameter.食物定量得分.海带));
            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_得分_6", tParameter.食物定量得分.豆乳粉));

            double 食物定量得分 = Convert.ToDouble(tParameter.食物定量得分.动物性食品) * Convert.ToDouble(tParameter.食物定量权重.动物性食品)
                 + Convert.ToDouble(tParameter.食物定量得分.黄豆) * Convert.ToDouble(tParameter.食物定量权重.黄豆)
                 + Convert.ToDouble(tParameter.食物定量得分.蔬菜) * Convert.ToDouble(tParameter.食物定量权重.蔬菜)
                 + Convert.ToDouble(tParameter.食物定量得分.蔗糖) * Convert.ToDouble(tParameter.食物定量权重.蔗糖)
                 + Convert.ToDouble(tParameter.食物定量得分.海带) * Convert.ToDouble(tParameter.食物定量权重.海带)
                 + Convert.ToDouble(tParameter.食物定量得分.豆乳粉) * Convert.ToDouble(tParameter.食物定量权重.豆乳粉);
            reportParameterList.Add(new ReportParameter("ReportParameter食物定量_得分_和", Convert.ToString(Math.Round(食物定量得分))));

            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_标准值_热能", tParameter.营养素供给标准值.热能));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_标准值_蛋白质", tParameter.营养素供给标准值.蛋白质));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_标准值_优质蛋白质", tParameter.营养素供给标准值.优质蛋白质));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_标准值_蛋白质脂肪糖发热", tParameter.营养素供给标准值.蛋白质脂肪糖发热));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_标准值_动物性来源脂肪", tParameter.营养素供给标准值.动物性来源脂肪));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_标准值_钙", tParameter.营养素供给标准值.钙));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_标准值_铁", tParameter.营养素供给标准值.铁));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_标准值_锌", tParameter.营养素供给标准值.锌));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_标准值_硒", tParameter.营养素供给标准值.硒));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_标准值_维A", tParameter.营养素供给标准值.维A));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_标准值_维E", tParameter.营养素供给标准值.维E));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_标准值_维B1", tParameter.营养素供给标准值.维B1));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_标准值_维B2", tParameter.营养素供给标准值.维B2));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_标准值_维PP", tParameter.营养素供给标准值.维PP));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_标准值_维C", tParameter.营养素供给标准值.维C));

            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_实际值_热能", tParameter.营养素供给实际值.热能));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_实际值_蛋白质", tParameter.营养素供给实际值.蛋白质));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_实际值_优质蛋白质", tParameter.营养素供给实际值.优质蛋白质));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_实际值_蛋白质脂肪糖发热", tParameter.营养素供给实际值.蛋白质脂肪糖发热));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_实际值_动物性来源脂肪", tParameter.营养素供给实际值.动物性来源脂肪));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_实际值_钙", tParameter.营养素供给实际值.钙));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_实际值_铁", tParameter.营养素供给实际值.铁));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_实际值_锌", tParameter.营养素供给实际值.锌));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_实际值_硒", tParameter.营养素供给实际值.硒));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_实际值_维A", tParameter.营养素供给实际值.维A));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_实际值_维E", tParameter.营养素供给实际值.维E));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_实际值_维B1", tParameter.营养素供给实际值.维B1));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_实际值_维B2", tParameter.营养素供给实际值.维B2));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_实际值_维PP", tParameter.营养素供给实际值.维PP));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_实际值_维C", tParameter.营养素供给实际值.维C));

            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_权重_热能", tParameter.营养素供给权重.热能));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_权重_蛋白质", tParameter.营养素供给权重.蛋白质));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_权重_优质蛋白质", tParameter.营养素供给权重.优质蛋白质));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_权重_蛋白质脂肪糖发热", tParameter.营养素供给权重.蛋白质脂肪糖发热));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_权重_动物性来源脂肪", tParameter.营养素供给权重.动物性来源脂肪));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_权重_钙", tParameter.营养素供给权重.钙));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_权重_铁", tParameter.营养素供给权重.铁));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_权重_锌", tParameter.营养素供给权重.锌));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_权重_硒", tParameter.营养素供给权重.硒));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_权重_维A", tParameter.营养素供给权重.维A));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_权重_维E", tParameter.营养素供给权重.维E));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_权重_维B1", tParameter.营养素供给权重.维B1));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_权重_维B2", tParameter.营养素供给权重.维B2));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_权重_维PP", tParameter.营养素供给权重.维PP));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_权重_维C", tParameter.营养素供给权重.维C));

            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_得分_热能", tParameter.营养素供给得分.热能));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_得分_蛋白质", tParameter.营养素供给得分.蛋白质));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_得分_优质蛋白质", tParameter.营养素供给得分.优质蛋白质));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_得分_蛋白质脂肪糖发热", tParameter.营养素供给得分.蛋白质脂肪糖发热));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_得分_动物性来源脂肪", tParameter.营养素供给得分.动物性来源脂肪));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_得分_钙", tParameter.营养素供给得分.钙));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_得分_铁", tParameter.营养素供给得分.铁));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_得分_锌", tParameter.营养素供给得分.锌));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_得分_硒", tParameter.营养素供给得分.硒));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_得分_维A", tParameter.营养素供给得分.维A));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_得分_维E", tParameter.营养素供给得分.维E));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_得分_维B1", tParameter.营养素供给得分.维B1));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_得分_维B2", tParameter.营养素供给得分.维B2));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_得分_维PP", tParameter.营养素供给得分.维PP));
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_得分_维C", tParameter.营养素供给得分.维C));

            double 营养素供给得分 = Convert.ToDouble(tParameter.营养素供给得分.热能) * Convert.ToDouble(tParameter.营养素供给权重.热能)
                + Convert.ToDouble(tParameter.营养素供给得分.蛋白质) * Convert.ToDouble(tParameter.营养素供给权重.蛋白质)
                + Convert.ToDouble(tParameter.营养素供给得分.优质蛋白质) * Convert.ToDouble(tParameter.营养素供给权重.优质蛋白质)
                + Convert.ToDouble(tParameter.营养素供给得分.蛋白质脂肪糖发热) * Convert.ToDouble(tParameter.营养素供给权重.蛋白质脂肪糖发热)
                + Convert.ToDouble(tParameter.营养素供给得分.动物性来源脂肪) * Convert.ToDouble(tParameter.营养素供给权重.动物性来源脂肪)
                + Convert.ToDouble(tParameter.营养素供给得分.钙) * Convert.ToDouble(tParameter.营养素供给权重.钙)
                + Convert.ToDouble(tParameter.营养素供给得分.铁) * Convert.ToDouble(tParameter.营养素供给权重.铁)
                + Convert.ToDouble(tParameter.营养素供给得分.锌) * Convert.ToDouble(tParameter.营养素供给权重.锌)
                + Convert.ToDouble(tParameter.营养素供给得分.硒) * Convert.ToDouble(tParameter.营养素供给权重.硒)
                + Convert.ToDouble(tParameter.营养素供给得分.维A) * Convert.ToDouble(tParameter.营养素供给权重.维A)
                + Convert.ToDouble(tParameter.营养素供给得分.维E) * Convert.ToDouble(tParameter.营养素供给权重.维E)
                + Convert.ToDouble(tParameter.营养素供给得分.维B1) * Convert.ToDouble(tParameter.营养素供给权重.维B1)
                + Convert.ToDouble(tParameter.营养素供给得分.维B2) * Convert.ToDouble(tParameter.营养素供给权重.维B2)
                + Convert.ToDouble(tParameter.营养素供给得分.维PP) * Convert.ToDouble(tParameter.营养素供给权重.维PP)
                + Convert.ToDouble(tParameter.营养素供给得分.维C) * Convert.ToDouble(tParameter.营养素供给权重.维C);
            reportParameterList.Add(new ReportParameter("ReportParameter营养素供给_得分_和", Convert.ToString(Math.Round(营养素供给得分))));

            string 伙食费标准值 = "25.97";
            string 伙食费实际值 = "25.97";
            string 伙食费权重 = "0.30";
            string 伙食费得分 = Convert.ToString(Math.Round(Convert.ToDouble(伙食费实际值) / Convert.ToDouble(伙食费标准值) * 100));
            string 伙食费得分和 = 伙食费得分;

            reportParameterList.Add(new ReportParameter("ReportParameter伙食费标准值", 伙食费标准值));
            reportParameterList.Add(new ReportParameter("ReportParameter伙食费实际值", 伙食费实际值));
            reportParameterList.Add(new ReportParameter("ReportParameter伙食费权重", 伙食费权重));
            reportParameterList.Add(new ReportParameter("ReportParameter伙食费得分", 伙食费得分));
            reportParameterList.Add(new ReportParameter("ReportParameter伙食费得分和", 伙食费得分和));

            string 食物定量权重 = "0.40";
            string 营养素供给权重 = "0.30";

            string 总分 = Convert.ToString(Math.Round(
                Convert.ToDouble(食物定量得分) * Convert.ToDouble(食物定量权重)
                + Convert.ToDouble(营养素供给得分) * Convert.ToDouble(营养素供给权重)
                + Convert.ToDouble(伙食费得分和) * Convert.ToDouble(伙食费权重)));
            reportParameterList.Add(new ReportParameter("ReportParameter总分", 总分));

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
