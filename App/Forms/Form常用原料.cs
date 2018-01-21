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

namespace SP.Forms
{
    public partial class Form常用原料 : Form
    {
        SqlDataAdapter adapter常用原料 = new SqlDataAdapter("select * from dbo.常用原料", DBConnect.Instance().getConnectString());
        DataSet dSet常用原料 = new DataSet();

        public Form常用原料()
        {
            InitializeComponent();
        }

        private void Form常用原料_Load(object sender, EventArgs e)
        {
            adapter常用原料.Fill(dSet常用原料);
            dSet常用原料 = new DataSet();
            adapter常用原料.Fill(dSet常用原料);
            Common.dumpDataSet(dSet常用原料);
            dataGridView1.DataSource = dSet常用原料.Tables[0];

            comboBox1.Items.Add("全部");
            comboBox1.Items.AddRange(get所有原料分类());
        }

        private object[] getUniqueItemsFromDataSet(DataSet dataSet, string rowName)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();

            foreach (DataTable dt in dataSet.Tables)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string str = (string)dr[rowName];
                    if (map.ContainsKey(str))
                    {
                        map[str]++;
                    }
                    else
                    {
                        map.Add(str, 1);
                    }
                    Console.Write(str);
                }
            }

            object[] ret = new object[map.Count];

            int index = 0;
            foreach (KeyValuePair<string, int> pair in map)
            {
                ret[index++] = pair.Key;
            }

            return ret;
        }

        private object[] get所有原料分类()
        {
            return getUniqueItemsFromDataSet(dSet常用原料, "原料分类");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string select = comboBox1.Text;

            string s = (dataGridView1.DataSource as DataTable).DefaultView.RowFilter;
            if (select == "全部")
            {
                updateDataGridView1RowFilter("");
            }
            else
            {
                updateDataGridView1RowFilter(string.Format("原料分类 = '{0}'", select));
            }
        }

        private void updateDataGridView1RowFilter(string filter)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = filter;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filter = string.Format("原料 like '%{0}%'", textBox1.Text);
            updateDataGridView1RowFilter(filter);
        }
    }
}
