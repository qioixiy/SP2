using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataModel
{
    class LocalDBConnect
    {
        public static string test()
        {
            //数据库连接字符串，注意这个写法（localdb）后面必须是两个斜杠，因为这中间有个转义的过程
            //Initial Catalog=要连接的数据库名
            //Intergrated Security=true  开启windows身份验证
            string ConnectString = "Server=(localdb)\\ProjectsV12;Initial Catalog=mrestaurant;Integrated Security=true";
            string dbName = "SP.mdf";
            string dbDir = System.Environment.CurrentDirectory + "\\db\\";
            string attachDbFilename = dbDir + dbName;
            ConnectString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + attachDbFilename;

            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader str = null;
            try
            {
                con = new SqlConnection(ConnectString);       //连接到数据库
                con.Open();                                  //创建连接后需要用Open打开连接，结束后要关闭连接，及时释放资源

                cmd = con.CreateCommand();
                cmd.CommandText = "select * from dbo.Table1"; //T-SQL语句   
                str = cmd.ExecuteReader();

                string s = "null";
                while (str.Read())
                {
                    Console.WriteLine(str[0]);
                    s = (string)str[1];
                }

                return s;
            }
            catch (Exception ms)
            {
                Console.WriteLine(ms.Message);
            }
            finally
            {
                if (str != null) str.Close();
                if (cmd != null) cmd.Clone();
                if (con != null) con.Close();
            }

            return "error";
        }
    }
}