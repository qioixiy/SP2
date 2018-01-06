using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

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
            string sql = "select* from 使用单位 order by id desc";
            SQLiteCommand command = new SQLiteCommand(sql, mSQLiteConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("Name: " + reader["name"] + "\tScore: " + reader["score"]);
            Console.ReadLine();

            Model用户[] ret = new Model用户[2];
            return ret;
        }
    }
}
