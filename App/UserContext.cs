using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DataModel;
using System.Data;

namespace SP
{
    public class UserContext
    {
        private string userName;

        public string 当前食谱
        {
            get
            {
                SqlDataAdapter adapter系统状态 = new SqlDataAdapter("select * from dbo.系统状态", DBConnect.Instance().getConnectString());
                DataSet dSet系统状态 = new DataSet();

                adapter系统状态.Fill(dSet系统状态);

                foreach (DataRow dr in dSet系统状态.Tables[0].Rows)
                {
                    string str = (string)dr["当前食谱"];
                    return str;
                }

                return "当前没有选定任何食谱";
            }

            set
            {
                try
                {
                    SqlDataAdapter adapter系统状态 = new SqlDataAdapter("select * from dbo.系统状态", DBConnect.Instance().getConnectString());
                    DataSet dSet系统状态 = new DataSet();

                    adapter系统状态.Fill(dSet系统状态);

                    dSet系统状态.Tables[0].Rows[0]["当前食谱"] = value;

                    SqlCommandBuilder sql_command = new SqlCommandBuilder(adapter系统状态);
                    adapter系统状态.Update(dSet系统状态.Tables[0]);

                    Program.FormMainWindowInstance.Text = value;
                }
                catch (Exception e)
                {
                    string str = e.ToString();
                }
            }
        }

        public string 当前外购清单
        {
            get
            {
                SqlDataAdapter adapter系统状态 = new SqlDataAdapter("select * from dbo.系统状态", DBConnect.Instance().getConnectString());
                DataSet dSet系统状态 = new DataSet();

                adapter系统状态.Fill(dSet系统状态);

                foreach (DataRow dr in dSet系统状态.Tables[0].Rows)
                {
                    string str = (string)dr["当前外购清单"];
                    return str;
                }

                return "当前没有选定外购清单";
            }

            set
            {
                try
                {
                    SqlDataAdapter adapter系统状态 = new SqlDataAdapter("select * from dbo.系统状态", DBConnect.Instance().getConnectString());
                    DataSet dSet系统状态 = new DataSet();

                    adapter系统状态.Fill(dSet系统状态);

                    dSet系统状态.Tables[0].Rows[0]["当前外购清单"] = value;

                    SqlCommandBuilder sql_command = new SqlCommandBuilder(adapter系统状态);
                    adapter系统状态.Update(dSet系统状态.Tables[0]);

                    Program.FormMainWindowInstance.Text = value;
                }
                catch (Exception e)
                {
                    string str = e.ToString();
                }
            }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

    }
}
