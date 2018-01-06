using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataModel
{
    class LocalDBConnect
    {
        //数据库连接字符串，注意这个写法（localdb）后面必须是两个斜杠，因为这中间有个转义的过程
        //Initial Catalog=要连接的数据库名
        //Intergrated Security=true  开启windows身份验证
        string ConnectString = "Server=(localdb)\\ProjectsV12;Initial Catalog=mrestaurant;Integrated Security=true";
        private static LocalDBConnect sLocalDBConnect = null;
        private SqlConnection con = null;

        public static LocalDBConnect Instance()
        {
            if (null == sLocalDBConnect)
            {
                string dbName = "SP.mdf";
                string dbDir = System.Environment.CurrentDirectory + "\\db\\";
                string attachDbFilename = dbDir + dbName;

                sLocalDBConnect = new LocalDBConnect(attachDbFilename);
            }

            return sLocalDBConnect;
        }

        public LocalDBConnect(string attachDbFilename)
        {
            ConnectString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + attachDbFilename;

            try
            {
                con = new SqlConnection(ConnectString);       //连接到数据库
                con.Open();                                  //创建连接后需要用Open打开连接，结束后要关闭连接，及时释放资源
            }
            catch (Exception ms)
            {
                Console.WriteLine(ms.Message);
            }
            finally
            {
                ;
            }
        }

        ~LocalDBConnect()
        {
            if (con != null)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public List<object> ExecuteCommand(string command)
        {
            List<object> ret = new List<object>();

            SqlCommand cmd = null;
            SqlDataReader str = null;

            cmd = con.CreateCommand();
            cmd.CommandText = command; //T-SQL语句   

            str = cmd.ExecuteReader();

            while (str.Read())
            {
                Console.WriteLine(str[0]);
            }

            return ret;
        }

        /// <summary>  
        /// 从数据库中查询数据的,返回为DataSet  
        /// </summary>  
        /// <param name="sql"></param>  
        /// <returns></returns>  
        public DataSet query(string sql)
        {
            DataSet ds = new DataSet();//DataSet是表的集合  
            SqlDataAdapter da = new SqlDataAdapter(sql, con);//从数据库中查询  
            da.Fill(ds);//将数据填充到DataSet
            return ds;//返回结果  
        }

        /// <summary>  
        /// 更新数据库  
        /// </summary>  
        /// <param name="sql"></param>  
        /// <returns></returns>  
        public int update(string sql)
        {
            SqlCommand oc = new SqlCommand();//表示要对数据源执行的SQL语句或存储过程  
            oc.CommandText = sql;//设置命令的文本  
            oc.CommandType = CommandType.Text;//设置命令的类型  
            oc.Connection = con;//设置命令的连接  
            int x = oc.ExecuteNonQuery();//执行SQL语句  
            return x;   //返回一个影响行数  
        }

        public bool exist(string sql)
        {
            bool ret = false;

            SqlCommand cmd = null;

            cmd = con.CreateCommand();
            cmd.CommandText = sql; //T-SQL语句   

            SqlDataReader reader = cmd.ExecuteReader();

            ret = reader.Read();

            reader.Close();
            
            return ret;
        }

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
                cmd.CommandText = "select * from dbo.用户"; //T-SQL语句   
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
                if (con != null) con.Close();
                if (cmd != null) cmd.Clone();
                if (con != null) con.Close();
            }

            return "error";
        }
    }
}