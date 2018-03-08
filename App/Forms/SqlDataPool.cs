using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DataModel;
using SP.Utils;

namespace SP.Forms
{

    public class SqlData
    {
        public SqlDataAdapter mSqlDataAdapter;
        public DataSet mDataSet;
    };

    class SqlDataPool
    {

        static SqlDataPool pool;

        Dictionary<string, SqlData> dict = new Dictionary<string, SqlData>();

        public static SqlDataPool Instance()
        {
            if (pool == null)
            {
                pool = new SqlDataPool();
            }
            return pool;
        }

        public SqlData GetSqlDataByName(string name)
        {

            if (!dict.ContainsKey(name))
            {
                dict[name] = new SqlData();
             
                SqlDataAdapter adapter = new SqlDataAdapter("select * from dbo." + name, DBConnect.Instance().getConnectString());
                DataSet dSet = new DataSet();
                dict[name].mSqlDataAdapter = adapter;
                dict[name].mDataSet = dSet;

                adapter.Fill(dSet);
                Common.dumpDataSet(dSet);
            }

            return dict[name];
        }
    }
}
