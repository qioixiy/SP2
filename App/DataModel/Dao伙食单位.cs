using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace SP.DataModel
{
    class Dao伙食单位 : ModelBase
    {
        public void insertItem(Model伙食单位 item)
        {

        }
        public void deleteItem(Model伙食单位 item)
        {

        }
        public void updateItem(Model伙食单位 item)
        {

        }
        public Model伙食单位[] select()
        {
            return new Model伙食单位[2];
            string sql = "select* from 使用单位 order by id desc";
            SQLiteCommand command = new SQLiteCommand(sql, mSQLiteConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("Name: " + reader["name"] + "\tScore: " + reader["score"]);
            Console.ReadLine();

            Model伙食单位[] ret = new Model伙食单位[2];
            return ret;
        }
    }
}
