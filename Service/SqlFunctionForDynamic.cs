using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace Service
{
    /// <summary>
    /// 查询动态类
    /// add yuangang by 2016-05-10
    /// </summary>
    public static class DatabaseExtensions
    {
        /// <summary>
        /// 自定义Connection对象
        /// </summary>
        private static IDbConnection DefaultConnection
        {
            get
            {
                return Domain.MyConfig.DefaultConnection;
            }
        }
        /// <summary>
        /// 自定义数据库连接字符串，与EF连接模式一致
        /// </summary>
        private static string DefaultConnectionString
        {
            get
            {
                return Domain.MyConfig.DefaultConnectionString;
            }
        }
        /// <summary>
        /// 动态查询主方法
        /// </summary>
        /// <returns></returns>
        public static IEnumerable SqlQueryForDynamic(this Database db,
                string sql,
                params object[] parameters)
        {
            IDbConnection defaultConn = DefaultConnection;

            //ADO.NET数据库连接字符串
            db.Connection.ConnectionString = DefaultConnectionString;

            return SqlQueryForDynamicOtherDB(db, sql, defaultConn, parameters);
        }
        private static IEnumerable SqlQueryForDynamicOtherDB(this Database db, string sql, IDbConnection conn, params object[] parameters)
        {
            conn.ConnectionString = db.Connection.ConnectionString;

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            if (parameters != null)
            {
                foreach (var item in parameters)
                {
                    cmd.Parameters.Add(item);
                }
            }

            using (IDataReader dataReader = cmd.ExecuteReader())
            {

                if (!dataReader.Read())
                {
                    return null; //无结果返回Null
                }

                #region 构建动态字段

                TypeBuilder builder = DatabaseExtensions.CreateTypeBuilder(
                    "EF_DynamicModelAssembly",
                    "DynamicModule",
                    "DynamicType");

                int fieldCount = dataReader.FieldCount;
                for (int i = 0; i < fieldCount; i++)
                {
                    Type t = dataReader.GetFieldType(i);
                    switch (t.Name.ToLower())
                    {
                        case "decimal":
                            t = typeof(Decimal?);
                            break;
                        case "double":
                            t = typeof(Double?);
                            break;
                        case "datetime":
                            t = typeof(DateTime?);
                            break;
                        case "single":
                            t = typeof(float?);
                            break;
                        case "int16":
                            t = typeof(int?);
                            break;
                        case "int32":
                            t = typeof(int?);
                            break;
                        case "int64":
                            t = typeof(int?);
                            break;
                        default:
                            break;
                    }
                    DatabaseExtensions.CreateAutoImplementedProperty(
                        builder,
                        dataReader.GetName(i),
                        t);
                }

                #endregion

                cmd.Parameters.Clear();
                dataReader.Close();
                dataReader.Dispose();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();

                Type returnType = builder.CreateType();

                if (parameters != null)
                {
                    return db.SqlQuery(returnType, sql, parameters);
                }
                else
                {
                    return db.SqlQuery(returnType, sql);
                }
            }
        }

        private static TypeBuilder CreateTypeBuilder(string assemblyName, string moduleName, string typeName)
        {
            TypeBuilder typeBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(
              new AssemblyName(assemblyName),
              AssemblyBuilderAccess.Run).DefineDynamicModule(moduleName).DefineType(typeName,
              TypeAttributes.Public);
            typeBuilder.DefineDefaultConstructor(MethodAttributes.Public);
            return typeBuilder;
        }

        private static void CreateAutoImplementedProperty(TypeBuilder builder, string propertyName, Type propertyType)
        {
            const string PrivateFieldPrefix = "m_";
            const string GetterPrefix = "get_";
            const string SetterPrefix = "set_";

            // Generate the field.
            FieldBuilder fieldBuilder = builder.DefineField(
              string.Concat(
                PrivateFieldPrefix, propertyName),
              propertyType,
              FieldAttributes.Private);

            // Generate the property
            PropertyBuilder propertyBuilder = builder.DefineProperty(
              propertyName,
              System.Reflection.PropertyAttributes.HasDefault,
              propertyType, null);

            // Property getter and setter attributes.
            MethodAttributes propertyMethodAttributes = MethodAttributes.Public
              | MethodAttributes.SpecialName
              | MethodAttributes.HideBySig;

            // Define the getter method.
            MethodBuilder getterMethod = builder.DefineMethod(
                string.Concat(
                  GetterPrefix, propertyName),
                propertyMethodAttributes,
                propertyType,
                Type.EmptyTypes);

            // Emit the IL code.
            // ldarg.0
            // ldfld,_field
            // ret
            ILGenerator getterILCode = getterMethod.GetILGenerator();
            getterILCode.Emit(OpCodes.Ldarg_0);
            getterILCode.Emit(OpCodes.Ldfld, fieldBuilder);
            getterILCode.Emit(OpCodes.Ret);

            // Define the setter method.
            MethodBuilder setterMethod = builder.DefineMethod(
              string.Concat(SetterPrefix, propertyName),
              propertyMethodAttributes,
              null,
              new Type[] { propertyType });

            // Emit the IL code.
            // ldarg.0
            // ldarg.1
            // stfld,_field
            // ret
            ILGenerator setterILCode = setterMethod.GetILGenerator();
            setterILCode.Emit(OpCodes.Ldarg_0);
            setterILCode.Emit(OpCodes.Ldarg_1);
            setterILCode.Emit(OpCodes.Stfld, fieldBuilder);
            setterILCode.Emit(OpCodes.Ret);

            propertyBuilder.SetGetMethod(getterMethod);
            propertyBuilder.SetSetMethod(setterMethod);
        }

        public static dynamic SqlFunctionForDynamic(this Database db,
                string sql,
                params object[] parameters)
        {
            IDbConnection conn = DefaultConnection;

            //ADO.NET数据库连接字符串
            conn.ConnectionString = DefaultConnectionString;

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.StoredProcedure;
            if (parameters != null)
            {
                foreach (var item in parameters)
                {
                    cmd.Parameters.Add(item);
                }
            }
            //1、DataReader查询数据
            using (IDataReader dataReader = cmd.ExecuteReader())
            {
                if (!dataReader.Read())
                {
                    return null;
                }
                //2、DataReader转换Json
                string jsonstr = Common.JsonConverter.ToJson(dataReader);
                dataReader.Close();
                dataReader.Dispose();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
                //3、Json转换动态类
                dynamic dyna = Common.JsonConverter.ConvertJson(jsonstr);
                return dyna;
            }
        }
        /// <summary>
        /// 对可空类型进行判断转换(*要不然会报错)
        /// </summary>
        /// <param name="value">DataReader字段的值</param>
        /// <param name="conversionType">该字段的类型</param>
        /// <returns></returns>
        private static object CheckType(object value, Type conversionType)
        {
            if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                    return null;
                System.ComponentModel.NullableConverter nullableConverter = new System.ComponentModel.NullableConverter(conversionType);
                conversionType = nullableConverter.UnderlyingType;
            }
            return Convert.ChangeType(value, conversionType);
        }

        /// <summary>
        /// 判断指定对象是否是有效值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static bool IsNullOrDBNull(object obj)
        {
            return (obj == null || (obj is DBNull)) ? true : false;
        }
    }
}