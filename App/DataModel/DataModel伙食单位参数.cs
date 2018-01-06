using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace SP.DataModel
{
    class DataModel伙食单位参数 : ModelBase
    {
        public void insertItem(伙食单位 item)
        {

        }
        public void deleteItem(伙食单位 item)
        {

        }
        public void updateItem(伙食单位 item)
        {

        }
        public 伙食单位[] select()
        {
            return new 伙食单位[2];
            string sql = "select* from 使用单位 order by id desc";
            SQLiteCommand command = new SQLiteCommand(sql, mSQLiteConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("Name: " + reader["name"] + "\tScore: " + reader["score"]);
            Console.ReadLine();

            伙食单位[] ret = new 伙食单位[2];
            return ret;
        }
    }
}
