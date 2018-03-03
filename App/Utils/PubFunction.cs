using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using DataModel;

namespace DataAccess
{
    public class PubFunction
    {
        /// <summary>
        /// 把文件存入数据库
        /// </summary>
        /// <param name="filePaths">文件路径（含文件名）</param>
        /// <returns>存入是否成功</returns>
        public static bool StoreFiles(string[] filePaths)
        {
            try
            {
                for (int i = 0; i < filePaths.Length; i++)
                {
                    string filePath = filePaths[i];
                    string fileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);

                    using (SqlConnection connection = new SqlConnection(DBConnect.Instance().getConnectString()))
                    {
                        connection.Open();
                        FileStream pFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                        byte[] bytes = new byte[pFileStream.Length];
                        pFileStream.Read(bytes, 0, (int)pFileStream.Length);
                        string strSql = "insert into DataTable(FileName,FilePath,Data) values(@FileName,@FilePath,@Data)";
                        using (SqlCommand cmd = new SqlCommand(strSql, connection))
                        {
                            cmd.Parameters.Add("@FileName", SqlDbType.Text);
                            cmd.Parameters.Add("@FilePath", SqlDbType.Text);
                            cmd.Parameters.Add("@Data", SqlDbType.Binary);
                            cmd.Parameters["@FileName"].Value = fileName;
                            cmd.Parameters["@FilePath"].Value = filePath;
                            cmd.Parameters["@Data"].Value = bytes;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 将数据库中数据写入文件
        /// </summary>
        /// <param name="fileName">用于查找数据的文件名</param>
        /// <param name="destFilePath">目标文件路径（含文件名）</param>
        /// <returns>写入是否成功</returns>
        public static bool WriteFromDBtoFile(string fileName, string destFilePath)
        {
            FileStream pFileStream = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(DBConnect.Instance().getConnectString()))
                {
                    connection.Open();
                    string strSql0 = "select Data from DataTable where FileName = '{0}'";
                    string strSql1 = String.Format(strSql0, fileName);
                    SqlCommand cmd = new SqlCommand(strSql1, connection);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    byte[] bytes = (byte[])dr[0];
                    pFileStream = new FileStream(destFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    pFileStream.Write(bytes, 0, bytes.Length);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                if (pFileStream != null)
                {
                    pFileStream.Close();
                }
            }
        }

        public static DataTable GetDataFromSql(string strSql)
        {
            using (SqlConnection connection = new SqlConnection(DBConnect.Instance().getConnectString()))
            {
                using (SqlCommand cmd = new SqlCommand(strSql, connection))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        using (DataSet ds = new DataSet())
                        {
                            da.Fill(ds);
                            DataTable dt = ds.Tables[0];
                            return dt;
                        }
                    }
                }
            }
        }
    }
}