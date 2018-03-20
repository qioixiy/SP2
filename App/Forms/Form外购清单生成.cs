using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using SP.Utils;

namespace SP.Forms
{
    public partial class Form外购清单生成 : Form
    {
        public Form外购清单生成()
        {
            InitializeComponent();
        }

        private void Form外购清单生成_Load(object sender, EventArgs e)
        {
            SqlData tSqlData = SqlDataPool.Instance().GetSqlDataByName("食谱");

            object[] objs = Utils.Common.getUniqueItemsFromDataSet(tSqlData.mDataSet, "名称");

            comboBox1.Items.AddRange(objs);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                return;
            }

            if (comboBox1.Text == "请选择")
            {
                MessageBox.Show("请选择");
                return;
            }

            string 食谱名称 = comboBox1.Text;
            if (gen外购清单By食谱名称(食谱名称))
            {
                MessageBox.Show("外购清单生成成功");
            }
            else
            {
                MessageBox.Show("外购清单生成失败");
            }
        }

        private void put用料用量To外购清单(Dictionary<string, double> 外购清单Map, string 用料, double 用量)
        {
            try
            {
                double cur用料用量1 = 外购清单Map[用料];
            }
            catch (Exception ex)
            {
                外购清单Map[用料] = new double();
            }

            double cur用料用量 = 外购清单Map[用料];

            cur用料用量 += 用量;

            外购清单Map[用料] = cur用料用量;
        }

        private void get外购清单By菜肴名称(string 菜肴名称, Dictionary<string, double> 外购清单Map)
        {
            SqlData sqlData = SqlDataPool.Instance().GetSqlDataByName("常用菜肴");

            object _用量1 = Common.selectDataItemFromDataSet(sqlData.mDataSet, "菜肴名称", 菜肴名称, "用量1");
            object _用量2 = Common.selectDataItemFromDataSet(sqlData.mDataSet, "菜肴名称", 菜肴名称, "用量2");
            object _用量3 = Common.selectDataItemFromDataSet(sqlData.mDataSet, "菜肴名称", 菜肴名称, "用量3");
            object _用量4 = Common.selectDataItemFromDataSet(sqlData.mDataSet, "菜肴名称", 菜肴名称, "用量4");
            object _用量5 = Common.selectDataItemFromDataSet(sqlData.mDataSet, "菜肴名称", 菜肴名称, "用量5");

            object _用料1 = Common.selectDataItemFromDataSet(sqlData.mDataSet, "菜肴名称", 菜肴名称, "用料1");
            object _用料2 = Common.selectDataItemFromDataSet(sqlData.mDataSet, "菜肴名称", 菜肴名称, "用料2");
            object _用料3 = Common.selectDataItemFromDataSet(sqlData.mDataSet, "菜肴名称", 菜肴名称, "用料3");
            object _用料4 = Common.selectDataItemFromDataSet(sqlData.mDataSet, "菜肴名称", 菜肴名称, "用料4");
            object _用料5 = Common.selectDataItemFromDataSet(sqlData.mDataSet, "菜肴名称", 菜肴名称, "用料5");

            try
            {
                if (_用料1 != null && !Convert.IsDBNull(_用料1) && _用量1 != null && !Convert.IsDBNull(_用量1))
                {
                    string 用料1 = (string)_用料1;
                    double 用量1 = Convert.ToDouble(_用量1);

                    put用料用量To外购清单(外购清单Map, 用料1, 用量1);
                }
                if (_用料2 != null && !Convert.IsDBNull(_用料2) && _用量2 != null && !Convert.IsDBNull(_用量2))
                {
                    string 用料2 = (string)_用料2;
                    double 用量2 = Convert.ToDouble(_用量2);

                    put用料用量To外购清单(外购清单Map, 用料2, 用量2);
                }
                if (_用料3 != null && !Convert.IsDBNull(_用料3) && _用量3 != null && !Convert.IsDBNull(_用量3))
                {
                    string 用料3 = (string)_用料3;
                    double 用量3 = Convert.ToDouble(_用量3);

                    put用料用量To外购清单(外购清单Map, 用料3, 用量3);
                }
                if (_用料4 != null && !Convert.IsDBNull(_用料4) && _用量4 != null && !Convert.IsDBNull(_用量4))
                {
                    string 用料4 = (string)_用料4;
                    double 用量4 = Convert.ToDouble(_用量4);

                    put用料用量To外购清单(外购清单Map, 用料4, 用量4);
                }
                if (_用料5 != null && !Convert.IsDBNull(_用料5) && _用量5 != null && !Convert.IsDBNull(_用量5))
                {
                    string 用料5 = (string)_用料5;
                    double 用量5 = Convert.ToDouble(_用量5);

                    put用料用量To外购清单(外购清单Map, 用料5, 用量5);
                }
            }
            catch (Exception ex)
            {
                ;
            }

        }

        private void gen外购清单(string 食谱名称, DataRow dr)
        {
            Dictionary<string, double> 外购清单Map = new Dictionary<string, double>();

            SqlData tSqlData = SqlDataPool.Instance().GetSqlDataByName("食谱");

            string 就餐人数 = (string)Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 食谱名称, "就餐人数");

            for (int index = 1; index <= 30; index++)
            {
                string 菜肴名称 = (string)Utils.Common.selectDataItemFromDataSet(tSqlData.mDataSet, "名称", 食谱名称, "菜肴" + index);

                get外购清单By菜肴名称(菜肴名称, 外购清单Map);
            }

            int count = 1;
            foreach (KeyValuePair<string, double> item in 外购清单Map)
            {
                dr["原料名称" + count] = item.Key;
                dr["总量" + count] = item.Value;

                count++;

                if (count > 20)
                {
                    MessageBox.Show("原料大于20个，当前支持最大20");
                    break;
                }
            }
        }

        private bool gen外购清单By食谱名称(string 食谱名称)
        {
            SqlData tSqlData = SqlDataPool.Instance().GetSqlDataByName("外购清单");

            DataRow dr = tSqlData.mDataSet.Tables[0].NewRow();
            
            dr["对应食谱名称"] = 食谱名称;

            string 名称 = 食谱名称 + DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss") + "外购清单";
            dr["名称"] = 名称;

            gen外购清单(食谱名称, dr);

            tSqlData.mDataSet.Tables[0].Rows.Add(dr);

            SqlCommandBuilder sql_command = new SqlCommandBuilder(tSqlData.mSqlDataAdapter);

            try
            {
                tSqlData.mSqlDataAdapter.Update(tSqlData.mDataSet.Tables[0]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
