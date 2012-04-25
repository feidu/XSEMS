using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Backend.Utilities
{
    public class SqlUtilities
    {
        public const string CHARACHER_COMMA = ",";

        public static int ParseInt(object obj)
        {
            if (obj is DBNull) return 0;
            return (int)obj;
        }

        public static SqlParameter GenerateInputVarcharParameter(string name, int size, object value, bool nullable)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = name;
            param.Direction = ParameterDirection.Input;
            param.Size = size;
            param.SqlDbType = SqlDbType.VarChar;
            param.SqlValue = value;
            param.IsNullable = nullable;
            return param;
        }

        public static SqlParameter GenerateInputNVarcharParameter(string name, int size, object value, bool nullable)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = name;
            param.Direction = ParameterDirection.Input;
            param.Size = size;
            param.SqlDbType = SqlDbType.NVarChar;
            param.SqlValue = value;
            param.IsNullable = nullable;
            return param;
        }

        public static SqlParameter GenerateInputVarcharParameter(string name, int size, object value)
        {
            return GenerateInputVarcharParameter(name, size, value, false);
        }

        public static SqlParameter GenerateInputNVarcharParameter(string name, int size, object value)
        {
            return GenerateInputNVarcharParameter(name, size, value, false);
        }

        public static SqlParameter GenerateInputVarcharParameterFromIntArray(string name, int size, int[] array)
        {
            string value = null;
            if (array == null || array.Length == 0)
            {
                value = string.Empty;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < array.Length; i++)
                {
                    if (i > 0) sb.Append(CHARACHER_COMMA);
                    sb.Append(array[i]);
                }
                value = sb.ToString();
            }
            return GenerateInputVarcharParameter(name, size, value, false);
        }

        public static SqlParameter GenerateInputParameter(string name, SqlDbType type, object value)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = name;
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = type;
            param.SqlValue = value;
            return param;
        }

        public static SqlParameter GenerateInputParameter(string name, SqlDbType type, int size, object value)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = name;
            param.Direction = ParameterDirection.Input;
            param.Size = size;
            param.SqlDbType = type;
            param.SqlValue = value;
            return param;
        }

        public static SqlParameter GenerateInputIntParameter(string name, object value)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = name;
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.Int;
            param.SqlValue = value;
            return param;
        }

        public static SqlParameter GenerateInputDateTimeParameter(string name, object value)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = name;
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.DateTime;
            param.SqlValue = value;
            return param;
        }
    }
}
