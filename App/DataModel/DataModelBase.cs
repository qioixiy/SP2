using System;
using System.Data.SQLite;
using System.IO;

namespace SP.DataModel
{
    class ModelBase
    {
        protected string dbName = "SP2.db";
        //数据库连接
        protected SQLiteConnection mSQLiteConnection;

        public ModelBase()
        {
            connectToDatabase();
        }

        ~ModelBase()
        {
            disconnectToDatabase();
        }

        private void testCase()
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
            SQLiteConnection.CreateFile(dbName);
        }

        //创建一个连接到指定数据库
        void connectToDatabase()
        {
            if (!File.Exists(dbName))
            {
                createNewDatabase();
            }
            mSQLiteConnection = new SQLiteConnection("Data Source=" + dbName+ ";Version=3;");
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
