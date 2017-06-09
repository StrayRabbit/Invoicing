using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using System.Web.Script.Serialization;
using System.Collections;

namespace Common
{
    public class JsonConverter
    {

        /// <summary>
        /// 自定义查询对象转换动态类
        /// add yuangang by 2015-05-19
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static dynamic JsonClass(object obj)
        {
            return ConvertJson(Serialize(obj, true));
        }

        /// <summary>
        /// object动态类转换json包
        /// add yuangang by 2015-05-19
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="DateConvert">时间戳是否转换成日期类型</param>
        /// <returns></returns>
        public static string Serialize(object obj, bool DateConvert = false)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var str = jss.Serialize(obj);
            if (DateConvert)
            {
                str = System.Text.RegularExpressions.Regex.Replace(str, @"\\/Date\((\d+)\)\\/", match =>
                {
                    DateTime dt = new DateTime(1970, 1, 1);
                    dt = dt.AddMilliseconds(long.Parse(match.Groups[1].Value));
                    dt = dt.ToLocalTime();
                    return dt.ToString("yyyy-MM-dd HH:mm:ss");
                });
            }
            return str;
        }

        /// <summary>
        /// json转换object动态类
        /// add yuangang by 2015-05-19
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static dynamic ConvertJson(string json)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            jss.RegisterConverters(new JavaScriptConverter[] { new DynamicJsonConverter() });
            dynamic dy = jss.Deserialize(json, typeof(object)) as dynamic;
            return dy;
        }

        /// <summary>   
        /// DataReader转换为Json   
        /// </summary>   
        /// <param name="dataReader">DataReader对象</param>   
        /// <returns>Json字符串</returns>   
        public static string ToJson(IDataReader dataReader)
        {
            try
            {
                StringBuilder jsonString = new StringBuilder();
                jsonString.Append("[");

                while (dataReader.Read())
                {
                    jsonString.Append("{");
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        Type type = dataReader.GetFieldType(i);
                        string strKey = dataReader.GetName(i);
                        string strValue = dataReader[i].ToString();
                        jsonString.Append("\"" + strKey + "\":");
                        strValue = StringFormat(strValue, type);
                        if (i < dataReader.FieldCount - 1)
                        {
                            jsonString.Append(strValue + ",");
                        }
                        else
                        {
                            jsonString.Append(strValue);
                        }
                    }
                    jsonString.Append("},");
                }
                if (!dataReader.IsClosed)
                {
                    dataReader.Close();
                }
                jsonString.Remove(jsonString.Length - 1, 1);
                jsonString.Append("]");
                if (jsonString.Length == 1)
                {
                    return "[]";
                }
                return jsonString.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>   
        /// DataSet转换为Json   
        /// add yuangang by 2015-05-19
        /// </summary>   
        /// <param name="dataSet">DataSet对象</param>   
        /// <returns>Json字符串</returns>   
        public static string ToJson(DataSet dataSet)
        {
            string jsonString = "{";
            foreach (DataTable table in dataSet.Tables)
            {
                jsonString += "\"" + table.TableName + "\":" + ToJson(table) + ",";
            }
            jsonString = jsonString.TrimEnd(',');
            return jsonString + "}";
        }
        /// <summary>  
        /// DataTable转成Json   
        /// add yuangang by 2015-05-19
        /// </summary>  
        /// <param name="jsonName"></param>  
        /// <param name="dt"></param>  
        /// <returns></returns>  
        public static string ToJson(DataTable dt, string jsonName)
        {
            StringBuilder Json = new StringBuilder();
            if (string.IsNullOrEmpty(jsonName))
                jsonName = dt.TableName;
            Json.Append("{\"" + jsonName + "\":[");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Json.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Type type = dt.Rows[i][j].GetType();
                        Json.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + StringFormat(dt.Rows[i][j] is DBNull ? string.Empty : dt.Rows[i][j].ToString(), type));
                        if (j < dt.Columns.Count - 1)
                        {
                            Json.Append(",");
                        }
                    }
                    Json.Append("}");
                    if (i < dt.Rows.Count - 1)
                    {
                        Json.Append(",");
                    }
                }
            }
            Json.Append("]}");
            return Json.ToString();
        }
        /// <summary>   
        /// Datatable转换为Json   
        /// add yuangang by 2015-05-19
        /// </summary>   
        /// <param name="table">Datatable对象</param>   
        /// <returns>Json字符串</returns>   
        public static string ToJson(DataTable dt)
        {
            StringBuilder jsonString = new StringBuilder();
            jsonString.Append("[");
            DataRowCollection drc = dt.Rows;
            for (int i = 0; i < drc.Count; i++)
            {
                jsonString.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string strKey = dt.Columns[j].ColumnName;
                    string strValue = drc[i][j].ToString();
                    Type type = dt.Columns[j].DataType;
                    jsonString.Append("\"" + strKey + "\":");
                    strValue = StringFormat(strValue, type);
                    if (j < dt.Columns.Count - 1)
                    {
                        jsonString.Append(strValue + ",");
                    }
                    else
                    {
                        jsonString.Append(strValue);
                    }
                }
                jsonString.Append("},");
            }
            jsonString.Remove(jsonString.Length - 1, 1);
            jsonString.Append("]");
            if (jsonString.Length == 1)
            {
                return "[]";
            }
            return jsonString.ToString();
        }
        /// <summary>  
        /// 格式化字符型、日期型、布尔型  
        /// add yuangang by 2015-05-19
        /// </summary>  
        /// <param name="str"></param>  
        /// <param name="type"></param>  
        /// <returns></returns>  
        private static string StringFormat(string str, Type type)
        {
            if (type != typeof(string) && string.IsNullOrEmpty(str))
            {
                str = "\"" + str + "\"";
            }
            else if (type == typeof(string))
            {
                str = String2Json(str);
                str = "\"" + str + "\"";
            }
            else if (type == typeof(DateTime))
            {
                str = "\"" + str + "\"";
            }
            else if (type == typeof(bool))
            {
                str = str.ToLower();
            }
            else if (type == typeof(byte[]))
            {
                str = "\"" + str + "\"";
            }
            else if (type == typeof(Guid))
            {
                str = "\"" + str + "\"";
            }
            return str;
        }
        /// <summary>  
        /// 过滤特殊字符  
        /// add yuangang by 2015-05-19
        /// </summary>  
        /// <param name="s"></param>  
        /// <returns></returns>  
        public static string String2Json(String s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s.ToCharArray()[i];
                switch (c)
                {
                    case '\"':
                        sb.Append("\\\""); break;
                    case '\\':
                        sb.Append("\\\\"); break;
                    case '/':
                        sb.Append("\\/"); break;
                    case '\b':
                        sb.Append("\\b"); break;
                    case '\f':
                        sb.Append("\\f"); break;
                    case '\n':
                        sb.Append("\\n"); break;
                    case '\r':
                        sb.Append("\\r"); break;
                    case '\t':
                        sb.Append("\\t"); break;
                    case '\v':
                        sb.Append("\\v"); break;
                    case '\0':
                        sb.Append("\\0"); break;
                    default:
                        sb.Append(c); break;
                }
            }
            return sb.ToString();
        }

        public static string GetDataGridJsonByDataSet(DataSet ds, string totalProperty, string root)
        {
            return GetDataGridJsonByDataTable(ds.Tables[0], totalProperty, root);
        }
        public static string GetDataGridJsonByDataTable(DataTable dt, string totalProperty, string root)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("({\"" + totalProperty + "\":\"" + dt.Rows.Count + "\",");
            jsonBuilder.Append("\"");
            jsonBuilder.Append(root);
            jsonBuilder.Append("\":[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Columns[j].ColumnName);
                    jsonBuilder.Append("\":\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString());
                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]");
            jsonBuilder.Append("})");
            return jsonBuilder.ToString();
        }

        public static string GetTreeJsonByDataSet(DataSet ds)
        {
            return GetTreeJsonByDataTable(ds.Tables[0]);
        }
        public static string GetTreeJsonByDataTable(DataTable dataTable)
        {
            DataTable dt = FormatDataTableForTree(dataTable);
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\'");

                    if (dt.Columns[j].ColumnName == "leaf")
                    {
                        string leafValue = dt.Rows[i][j].ToString();

                        if (!string.IsNullOrEmpty(leafValue))
                        {
                            jsonBuilder.Append(dt.Columns[j].ColumnName);
                            jsonBuilder.Append("\':\'");
                            jsonBuilder.Append(dt.Rows[i][j].ToString());
                            jsonBuilder.Append("\',");
                        }
                        else
                        {
                            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                        }
                    }
                    else if (dt.Columns[j].ColumnName == "customUrl")
                    {
                        jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                        jsonBuilder.Append(dt.Columns[j].ColumnName);
                        jsonBuilder.Append(":\'");
                        jsonBuilder.Append(dt.Rows[i][j].ToString());
                        jsonBuilder.Append("\',");
                    }
                    else
                    {
                        jsonBuilder.Append(dt.Columns[j].ColumnName);
                        jsonBuilder.Append("\':\'");
                        jsonBuilder.Append(dt.Rows[i][j].ToString());
                        jsonBuilder.Append("\',");
                    }

                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]");
            return jsonBuilder.ToString();
        }
        private static DataTable FormatDataTableForTree(DataTable dt)
        {
            DataTable dtTree = new DataTable();
            dtTree.Columns.Add("id", typeof(string));
            dtTree.Columns.Add("text", typeof(string));
            dtTree.Columns.Add("leaf", typeof(string));
            dtTree.Columns.Add("cls", typeof(string));
            dtTree.Columns.Add("customUrl", typeof(string));
            dtTree.AcceptChanges();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow drTree = dtTree.NewRow();
                drTree["id"] = dt.Rows[i]["id"].ToString();
                drTree["text"] = dt.Rows[i]["text"].ToString();
                if (dt.Rows[i]["leaf"].ToString() == "Y")
                {
                    drTree["leaf"] = "true";
                    drTree["cls"] = "file";
                }
                else
                {
                    drTree["cls"] = "folder";
                }
                drTree["customUrl"] = dt.Rows[i]["customUrl"].ToString();
                dtTree.Rows.Add(drTree);
            }
            return dtTree;
        }

    }
    /// <summary>
    /// 动态JSON解析
    /// add yuangang by 2015-05-19
    /// </summary>
    public class DynamicJsonObject : System.Dynamic.DynamicObject
    {
        private IDictionary<string, object> Dictionary { get; set; }

        public DynamicJsonObject(IDictionary<string, object> dictionary)
        {
            this.Dictionary = dictionary;
        }

        public override bool TryGetMember(System.Dynamic.GetMemberBinder binder, out object result)
        {
            result = this.Dictionary[binder.Name];

            if (result is IDictionary<string, object>)
            {
                result = new DynamicJsonObject(result as IDictionary<string, object>);
            }
            else if (result is ArrayList && (result as ArrayList) is IDictionary<string, object>)
            {
                result = new List<DynamicJsonObject>((result as ArrayList).ToArray().Select(x => new DynamicJsonObject(x as IDictionary<string, object>)));
            }
            else if (result is ArrayList)
            {
                result = new List<object>((result as ArrayList).ToArray());
            }

            return this.Dictionary.ContainsKey(binder.Name);
        }
    }
    /// <summary>
    /// 动态JSON转换
    /// add yuangang by 2015-05-19
    /// </summary>
    public class DynamicJsonConverter : JavaScriptConverter
    {
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            if (dictionary == null)
                throw new ArgumentNullException("dictionary");

            if (type == typeof(object))
            {
                return new DynamicJsonObject(dictionary);
            }

            return null;
        }

        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Type> SupportedTypes
        {
            get { return new System.Collections.ObjectModel.ReadOnlyCollection<Type>(new List<Type>(new Type[] { typeof(object) })); }
        }
    }
}