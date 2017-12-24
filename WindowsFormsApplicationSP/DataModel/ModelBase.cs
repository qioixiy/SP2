using System;
using System.Data.SQLite;
using System.IO;

namespace WindowsFormsApplicationSP.DataModel
{
    class ModelBase
    {
        //数据库连接
        SQLiteConnection mSQLiteConnection;

        public ModelBase()
        {
            //test();
        }



        private void test()
        {
            createNewDatabase();
            connectToDatabase();
            createTable();
            fillTable();
            printHighscores();
            disconnectToDatabase();
        }

        //创建一个空的数据库
        void createNewDatabase()
        {
            if (File.Exists("MyDatabase.db"))
            {
                return;
            }
            SQLiteConnection.CreateFile("MyDatabase.db");
        }

        //创建一个连接到指定数据库
        void connectToDatabase()
        {
            mSQLiteConnection = new SQLiteConnection("Data Source=MyDatabase.db;Version=3;");
            mSQLiteConnection.Open();
        }

        void disconnectToDatabase()
        {
            mSQLiteConnection.Close();
        }

        //在指定数据库中创建一个table
        void createTable()
        {
            string sql = "create table highscores (name varchar(20), score int)";
            SQLiteCommand command = new SQLiteCommand(sql, mSQLiteConnection);
            command.ExecuteNonQuery();
        }

        //插入一些数据
        void fillTable()
        {
            string sql = "insert into highscores (name, score) values ('Me', 3000)";
            SQLiteCommand command = new SQLiteCommand(sql, mSQLiteConnection);
            command.ExecuteNonQuery();

            sql = "insert into highscores (name, score) values ('Myself', 6000)";
            command = new SQLiteCommand(sql, mSQLiteConnection);
            command.ExecuteNonQuery();

            sql = "insert into highscores (name, score) values ('And I', 9001)";
            command = new SQLiteCommand(sql, mSQLiteConnection);
            command.ExecuteNonQuery();
        }

        //使用sql查询语句，并显示结果
        void printHighscores()
        {
            string sql = "select * from highscores order by score desc";
            SQLiteCommand command = new SQLiteCommand(sql, mSQLiteConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("Name: " + reader["name"] + "\tScore: " + reader["score"]);
            Console.ReadLine();
        }
    }
}
