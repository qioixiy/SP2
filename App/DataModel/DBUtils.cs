using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.DataModel
{
    class DBUtils
    {
        /// <summary>
        /// 将数据库数据类型字符串，转为C#数据类型字符串。
        /// </summary>
        /// <param name="dbType">数据库数据类型字符串。</param>
        /// <returns>C#数据类型字符串。</returns>
        public static string DBTypeToCSharpType(string dbType)
        {
            string cSharpType = string.Empty;
            switch (dbType.ToLower())
            {
                case "bit":
                    cSharpType = "bool";
                    break;
                case "tinyint":
                    cSharpType = "byte";
                    break;
                case "smallint":
                    cSharpType = "short";
                    break;
                case "int":
                    cSharpType = "int";
                    break;
                case "bigint":
                    cSharpType = "long";
                    break;
                case "real":
                    cSharpType = "float";
                    break;
                case "float":
                    cSharpType = "double";
                    break;
                case "smallmoney":
                case "money":
                case "decimal":
                case "numeric":
                    cSharpType = "decimal";
                    break;
                case "char":
                case "varchar":
                case "nchar":
                case "nvarchar":
                case "text":
                case "ntext":
                    cSharpType = "string";
                    break;
                case "samlltime":
                case "date":
                case "smalldatetime":
                case "datetime":
                case "datetime2":
                case "datetimeoffset":
                case "timestamp":
                    cSharpType = "System.DateTime";
                    break;
                case "image":
                case "binary":
                case "varbinary":
                    cSharpType = "byte[]";
                    break;
                case "uniqueidentifier":
                    cSharpType = "System.Guid";
                    break;
                case "variant":
                case "sql_variant":
                    cSharpType = "object";
                    break;
                default:
                    cSharpType = "string";
                    break;
            }
            return cSharpType;
        }
    }
}
