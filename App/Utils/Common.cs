using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Data;

namespace SP.Utils
{
    class Common
    {
        // 将Image转换为二进制序列  
        public static byte[] ImageToBytes(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Jpeg);
            byte[] bytes = new Byte[ms.Length];
            ms.Position = 0;
            ms.Read(bytes, 0, bytes.Length);
            ms.Close();
            return bytes;
        }

        // 将二进制序列转换为Image  
        public static Image BytesToImage(byte[] bytes)
        {
            try
            {
                using (Stream fStream = new MemoryStream(bytes.Length))
                {
                    BinaryWriter bw = new BinaryWriter(fStream);
                    bw.Write(bytes);
                    bw.Flush();
                    Bitmap bitMap = new Bitmap(fStream);
                    bw.Close();
                    fStream.Close();
                    Image image = Image.FromHbitmap(bitMap.GetHbitmap());
                    return image;
                }
            }
            catch (IOException ex)
            {
                throw new Exception("读取图片失败：" + ex.Message);

            }
        }

        public static void dumpDataSet(DataSet ds)
        {
            foreach (DataTable dt in ds.Tables)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    Console.Write(dc.ColumnName + " ");
                }
                Console.Write('\n');
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (object obj in dr.ItemArray)
                    {
                        Console.Write(obj + " ");
                    }
                    Console.Write('\n');
                }
            }
        }

        public static void dumpDataTable(DataTable dt)
        {
            foreach (DataColumn dc in dt.Columns)
            {
                Console.Write(dc.ColumnName + " ");
            }
            Console.Write('\n');
            foreach (DataRow dr in dt.Rows)
            {
                foreach (object obj in dr.ItemArray)
                {
                    Console.Write(obj + " ");
                }
                Console.Write('\n');
            }
        }

        public static object[] getUniqueItemsFromDataSet(DataSet dataSet, string rowName)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();

            foreach (DataTable dt in dataSet.Tables)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string str = (string)dr[rowName];
                    if (map.ContainsKey(str))
                    {
                        map[str]++;
                    }
                    else
                    {
                        map.Add(str, 1);
                    }
                    Console.Write(str);
                }
            }

            object[] ret = new object[map.Count];

            int index = 0;
            foreach (KeyValuePair<string, int> pair in map)
            {
                ret[index++] = pair.Key;
            }

            return ret;
        }

        public static object selectDataItemFromDataSet(DataSet dataSet, string rowName, string colName, string target)
        {
            object ret = new object();

            foreach (DataTable dt in dataSet.Tables)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string str = (string)dr[rowName];
                    if (str == colName)
                    {
                        ret = (string)dr[target];
                    }
                }
            }

            return ret;

        }
        public static object[] getItemsFromDataSet(DataSet dataSet, string rowName)
        {
            foreach (DataTable dt in dataSet.Tables)
            {
                int index = 0;
                object[] ret = new object[dt.Rows.Count];
                foreach (DataRow dr in dt.Rows)
                {
                    string str = (string)dr[rowName];
                    Console.Write(str);
                    ret[index++] = str;
                }
                return ret;
            }

            return null;
        }
    }
}
