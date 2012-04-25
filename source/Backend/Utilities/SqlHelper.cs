using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Backend.Utilities
{
    public class SqlHelper
    {
        public static SqlConnection OpenNewConnection()
        {
            return AbstractSqlHelper.OpenNewConnection(AbstractSqlHelper.ConnString);
        }

        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return AbstractSqlHelper.ExecuteNonQuery(AbstractSqlHelper.ConnString, cmdType, cmdText, commandParameters);
        }

        public static int ExecuteNonQuery(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return AbstractSqlHelper.ExecuteNonQuery(connection, cmdType, cmdText, commandParameters);
        }

        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return AbstractSqlHelper.ExecuteNonQuery(trans, cmdType, cmdText, commandParameters);
        }

        public static SqlDataReader ExecuteReader(CommandType cmdType, string cmdText, int timeout, params SqlParameter[] commandParameters)
        {
            return AbstractSqlHelper.ExecuteReader(AbstractSqlHelper.ConnString, cmdType, cmdText, timeout, commandParameters);
        }

        public static SqlDataReader ExecuteReader(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return AbstractSqlHelper.ExecuteReader(AbstractSqlHelper.ConnString, cmdType, cmdText, commandParameters);
        }

        public static SqlDataReader ExecuteReader(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return AbstractSqlHelper.ExecuteReader(AbstractSqlHelper.ConnString, cmdType, cmdText, commandParameters);
        }

        public static object ExecuteScalar(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return AbstractSqlHelper.ExecuteScalar(AbstractSqlHelper.ConnString, cmdType, cmdText, commandParameters); ;
        }

        public static object ExecuteScalar(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return AbstractSqlHelper.ExecuteScalar(connection, cmdType, cmdText, commandParameters);
        }

        public static DataTable ExecuteDataTable(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return AbstractSqlHelper.ExecuteDataTable(AbstractSqlHelper.ConnString, cmdType, cmdText, commandParameters);
        }
    }
}
