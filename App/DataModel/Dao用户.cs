using DataModel;
using System;
using System.Data;

namespace SP.DataModel
{
    class Dao用户 : ModelBase
    {
        public void insertItem(Model用户 item)
        {

        }
        public void deleteItem(Model用户 item)
        {

        }
        public void updateItem(Model用户 item)
        {

        }
        public Model用户[] select()
        {
            return new Model用户[2];
            Model用户[] ret = new Model用户[2];
            return ret;
        }

        public bool verfiyWithUserPasswd(string user, string passwd)
        {
            bool ret = false;

            string sql = "select* from dbo.用户 where 用户 = '" + user + "' and 密码 = '" + passwd + "'";

            bool b = LocalDBConnect.Instance().exist(sql);
            if (b)
            {
                ret = true;
            }

            return ret;
        }

        public bool verify()
        {
            bool ret = false;

            string sql = "select * from dbo.用户";
            DataSet ds = LocalDBConnect.Instance().query(sql);

            foreach (DataTable dt in ds.Tables)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    Console.WriteLine(dc.ColumnName);
                }
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (object obj in dr.ItemArray)
                    {
                        Console.WriteLine(obj);
                    }
                }
            }
            
            return ret;
        }
    }
}
