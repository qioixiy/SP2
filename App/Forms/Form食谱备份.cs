using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DataModel;
using System.Collections;
using System.IO;
using SP.Forms;

namespace SP
{
    public partial class 食谱备份 : Form
    {
        public 食谱备份()
        {
            InitializeComponent();
        }

        private void Action食谱备份()
        {
            ArrayList list = new ArrayList();
            using (SqlConnection conn = new SqlConnection(DBConnect.Instance().getConnectString()))
            {
                conn.Open();
                using (SqlCommand command = conn.CreateCommand())
                {
                    command.CommandText = "select * from 食谱";
                    using (SqlDataAdapter adp = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adp.Fill(dt);
                        foreach (DataRow row in dt.Rows)
                        {
                            list.Add(row[0].ToString());
                        }
                    }
                }
            }
            // 创建文件。如果文件存在则覆盖
            FileStream fs = File.Open(@"食谱.sql", FileMode.Create);
            // 创建写入流
            StreamWriter wr = new StreamWriter(fs, System.Text.Encoding.UTF8);
            // 将ArrayList中的每个项逐一写入文件
            for (int i = 0; i < list.Count; i++)
            {
                wr.WriteLine(list[i]);
            }
            // 关闭写入流
            wr.Flush();
            wr.Close();

            // 关闭文件
            fs.Close();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            string 当前食谱 = Program.FormMainWindowInstance.mUserContext.当前食谱;

            Action食谱备份();

            MessageBox.Show("备份成功:" + 当前食谱);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
