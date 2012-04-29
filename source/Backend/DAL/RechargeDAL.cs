using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.Utilities;
using System.Data.SqlClient;
using System.Data;
using Backend.Models.Pagination;

namespace Backend.DAL
{
    public class RechargeDAL
    {
        public void CreateRecharge(Recharge recharge)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@client_id", recharge.ClientId),
                SqlUtilities.GenerateInputIntParameter("@company_id", recharge.CompanyId),
                SqlUtilities.GenerateInputNVarcharParameter("@encode", 50, recharge.Encode),      
                SqlUtilities.GenerateInputNVarcharParameter("@invoice", 50, recharge.Invoice),
                SqlUtilities.GenerateInputParameter("@money",SqlDbType.Decimal, recharge.Money),
                SqlUtilities.GenerateInputNVarcharParameter("@account", 50, recharge.Account),
                SqlUtilities.GenerateInputDateTimeParameter("@receive_time",recharge.ReceiveTime),
                SqlUtilities.GenerateInputDateTimeParameter("@create_time",recharge.CreateTime),
                SqlUtilities.GenerateInputIntParameter("@user_id", recharge.UserId),
                SqlUtilities.GenerateInputIntParameter("@payment_method_id", recharge.PaymentMethodId),
                SqlUtilities.GenerateInputParameter("@payment_type",SqlDbType.TinyInt, recharge.PaymentType),
                SqlUtilities.GenerateInputParameter("@currency_type",SqlDbType.TinyInt, recharge.CurrencyType),
                SqlUtilities.GenerateInputNVarcharParameter("@remark", 500, recharge.Remark),
                SqlUtilities.GenerateInputParameter("@paid",SqlDbType.Decimal, recharge.Paid),
                SqlUtilities.GenerateInputParameter("@exchange_rate",SqlDbType.Decimal, recharge.ExchangeRate),

            };
            string sql = "INSERT INTO recharges(client_id, company_id, encode, money, account, receive_time, create_time, user_id, payment_method_id, payment_type, currency_type, remark, paid, exchange_rate, invoice) VALUES(@client_id, @company_id, @encode, @money, @account, @receive_time,           @create_time, @user_id, @payment_method_id, @payment_type, @currency_type, @remark, @paid, @exchange_rate, @invoice)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        //public void UpdateRecharge(Recharge recharge)
        //{
        //    SqlParameter[] param = new SqlParameter[] { 
        //        SqlUtilities.GenerateInputIntParameter("@id", recharge.Id),
        //        SqlUtilities.GenerateInputNVarcharParameter("@english_name", 50, recharge.EnglishName),
        //        SqlUtilities.GenerateInputNVarcharParameter("@chinese_name", 50, recharge.ChineseName),
        //        SqlUtilities.GenerateInputNVarcharParameter("@code", 50, recharge.Code),
        //        SqlUtilities.GenerateInputParameter("@state",SqlDbType.TinyInt, recharge.State)
        //    };
        //    string sql = "UPDATE recharges SET english_name = @english_name, chinese_name = @chinese_name, code = @code, state = @state WHERE id =      @id";
        //    SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        //}

        //public void DeleteRechargeById(int id)
        //{
        //    SqlParameter[] param = new SqlParameter[] { 
        //        SqlUtilities.GenerateInputIntParameter("@id", id)
        //    };
        //    string sql = "DELETE FROM recharges WHERE id = @id";
        //    SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        //}

        public void DeleteRechargeById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "UPDATE recharges SET is_delete = 1 WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);

            Recharge recharge = new RechargeDAL().GetRechargeById(id);
            Client client = new ClientDAL().GetClientById(recharge.ClientId);
            decimal balance = client.Balance - recharge.Money;
            client.Balance = balance;
            new ClientDAL().UpdateClientBalance(client);
        }

        public Recharge GetRechargeById(int id)
        {
            Recharge recharge = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "SELECT id, client_id, company_id, encode, money, account, receive_time, create_time, user_id, payment_method_id, payment_type, currency_type, remark, paid, exchange_rate, invoice FROM recharges WHERE id = @id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    recharge = new Recharge();
                    recharge.Id = dr.GetInt32(0);
                    recharge.ClientId = dr.GetInt32(1);
                    Client client = new ClientDAL().GetClientById(recharge.ClientId);
                    recharge.ClientName = client.RealName;
                    recharge.CompanyId = dr.GetInt32(2);
                    recharge.Encode = dr.GetString(3);
                    recharge.Money = dr.GetDecimal(4);
                    recharge.Account = dr.GetString(5);
                    recharge.ReceiveTime = dr.GetDateTime(6);
                    recharge.CreateTime = dr.GetDateTime(7);
                    recharge.UserId = dr.GetInt32(8);
                    User user = new UserDAL().GetUserById(recharge.UserId);
                    recharge.UserName = user.RealName;
                    recharge.PaymentMethodId = dr.GetInt32(9);
                    PaymentMethod pm = new PaymentMethodDAL().GetPaymentMethodById(recharge.PaymentMethodId);
                    recharge.PaymentMethodName = pm.Name;
                    recharge.PaymentType = EnumConvertor.ConvertToPaymentType(dr.GetByte(10));
                    recharge.CurrencyType = EnumConvertor.ConvertToCurrencyType(dr.GetByte(11));
                    recharge.Remark = dr.GetString(12);
                    recharge.Paid = dr.GetDecimal(13);
                    recharge.ExchangeRate = dr.GetDecimal(14);
                    recharge.Invoice = dr.GetString(15);
                }
            }
            return recharge;
        }

        public List<Recharge> GetRechargeStatistic(DateTime startDate, DateTime endDate, int clientId, string pmIds)
        {
            List<Recharge> result = new List<Recharge>();
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputDateTimeParameter("@start_date", startDate),
                SqlUtilities.GenerateInputDateTimeParameter("@end_date", endDate),
                SqlUtilities.GenerateInputIntParameter("@client_id", clientId)
            };

            string sqlParam = "";
            DateTime minTime = new DateTime(1999, 1, 1);
            if (startDate > minTime && endDate > minTime)
            {
                sqlParam += " AND create_time BETWEEN @start_date AND @end_date";
            }
            else if (startDate > minTime && endDate <= minTime)
            {
                sqlParam += " AND create_time >= @start_date ";
            }
            else if (startDate <= minTime && endDate > minTime)
            {
                sqlParam += " AND create_time <= @end_date";
            }
            if (clientId >= 0)
            {
                sqlParam += " AND client_id = @client_id";
            }            
            if (!string.IsNullOrEmpty(pmIds))
            {
                sqlParam += " AND payment_method_id IN(" + pmIds + ")";
            }
            string sql = "SELECT id, client_id, encode, money, account, receive_time, create_time, user_id, payment_method_id, payment_type, currency_type, remark, paid, exchange_rate, invoice FROM recharges WHERE is_delete = 0 "+sqlParam;           
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    Recharge recharge = new Recharge();
                    recharge.Id = dr.GetInt32(0);
                    recharge.ClientId = dr.GetInt32(1);
                    Client client = new ClientDAL().GetClientById(recharge.ClientId);
                    recharge.ClientName = client.RealName;
                    recharge.Encode = dr.GetString(2);
                    recharge.Money = dr.GetDecimal(3);
                    recharge.Account = dr.GetString(4);
                    recharge.ReceiveTime = dr.GetDateTime(5);
                    recharge.CreateTime = dr.GetDateTime(6);
                    recharge.UserId = dr.GetInt32(7);
                    User user = new UserDAL().GetUserById(recharge.UserId);
                    recharge.UserName = user.RealName;
                    recharge.PaymentMethodId = dr.GetInt32(8);
                    PaymentMethod pm = new PaymentMethodDAL().GetPaymentMethodById(recharge.PaymentMethodId);
                    recharge.PaymentMethodName = pm.Name;
                    recharge.PaymentType = EnumConvertor.ConvertToPaymentType(dr.GetByte(9));
                    recharge.CurrencyType = EnumConvertor.ConvertToCurrencyType(dr.GetByte(10));
                    recharge.Remark = dr.GetString(11);
                    recharge.Paid = dr.GetDecimal(12);
                    recharge.ExchangeRate = dr.GetDecimal(13);
                    recharge.Invoice = dr.GetString(14);
                    result.Add(recharge);
                }
            }
            return result;
        }
               
        public PaginationQueryResult<Recharge> GetRechargeByClientId(PaginationQueryCondition condition, int clientId)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@client_id", clientId)
            };
            PaginationQueryResult<Recharge> result = new PaginationQueryResult<Recharge>();
            string sql = "SELECT TOP " + condition.PageSize + " id, client_id, company_id, encode, money, account, receive_time, create_time, user_id, payment_method_id, payment_type, currency_type, remark, paid, exchange_rate, invoice FROM recharges WHERE is_delete = 0 AND client_id =              @client_id";
            if (condition.CurrentPage > 1)
            {
                sql += " AND id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM recharges WHERE is_delete = 0 AND client_id = @client_id ORDER BY id DESC) AS R )";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM recharges WHERE is_delete = 0 AND client_id = @client_id ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    Recharge recharge = new Recharge();
                    recharge.Id = dr.GetInt32(0);
                    recharge.ClientId = dr.GetInt32(1);
                    Client client = new ClientDAL().GetClientById(recharge.ClientId);
                    recharge.ClientName = client.RealName;
                    recharge.CompanyId = dr.GetInt32(2);
                    recharge.Encode = dr.GetString(3);
                    recharge.Money = dr.GetDecimal(4);
                    recharge.Account = dr.GetString(5);
                    recharge.ReceiveTime = dr.GetDateTime(6);
                    recharge.CreateTime = dr.GetDateTime(7);
                    recharge.UserId = dr.GetInt32(8);
                    User user = new UserDAL().GetUserById(recharge.UserId);
                    recharge.UserName = user.RealName;
                    recharge.PaymentMethodId = dr.GetInt32(9);
                    PaymentMethod pm = new PaymentMethodDAL().GetPaymentMethodById(recharge.PaymentMethodId);
                    recharge.PaymentMethodName = pm.Name;
                    recharge.PaymentType = EnumConvertor.ConvertToPaymentType(dr.GetByte(10));
                    recharge.CurrencyType = EnumConvertor.ConvertToCurrencyType(dr.GetByte(11));
                    recharge.Remark = dr.GetString(12);
                    recharge.Paid = dr.GetDecimal(13);
                    recharge.ExchangeRate = dr.GetDecimal(14);
                    recharge.Invoice = dr.GetString(15);
                    result.Results.Add(recharge);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public PaginationQueryResult<Recharge> GetRechargeByClientIdAndDate(PaginationQueryCondition condition, int clientId, DateTime startDate, DateTime endDate)
        {
            PaginationQueryResult<Recharge> result = new PaginationQueryResult<Recharge>();
            DateTime minTime = new DateTime(1999, 1, 1);
            string sqlTime = "";
            if (startDate > minTime && endDate > minTime)
            {
                sqlTime = " AND create_time BETWEEN @start_date AND @end_date";
            }
            else if (startDate > minTime && endDate <= minTime)
            {
                sqlTime = " AND create_time >= @start_date ";
            }
            else
            {
                sqlTime = " AND create_time <= @end_date";
            }
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@client_id", clientId),
                SqlUtilities.GenerateInputDateTimeParameter("@start_date", startDate),
                SqlUtilities.GenerateInputDateTimeParameter("@end_date", endDate)
            };
            
            string sql = "SELECT TOP " + condition.PageSize + " id, client_id, company_id, encode, money, account, receive_time, create_time, user_id, payment_method_id, payment_type, currency_type, remark, paid, exchange_rate, invoice FROM recharges WHERE is_delete = 0 AND client_id =              @client_id"+sqlTime;
            if (condition.CurrentPage > 1)
            {
                sql += " AND id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM recharges WHERE is_delete = 0 AND client_id = @client_id "+sqlTime+" ORDER BY id DESC) AS R )";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM recharges WHERE is_delete = 0 AND client_id = @client_id "+sqlTime;
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    Recharge recharge = new Recharge();
                    recharge.Id = dr.GetInt32(0);
                    recharge.ClientId = dr.GetInt32(1);
                    Client client = new ClientDAL().GetClientById(recharge.ClientId);
                    recharge.ClientName = client.RealName;
                    recharge.CompanyId = dr.GetInt32(2);
                    recharge.Encode = dr.GetString(3);
                    recharge.Money = dr.GetDecimal(4);
                    recharge.Account = dr.GetString(5);
                    recharge.ReceiveTime = dr.GetDateTime(6);
                    recharge.CreateTime = dr.GetDateTime(7);
                    recharge.UserId = dr.GetInt32(8);
                    User user = new UserDAL().GetUserById(recharge.UserId);
                    recharge.UserName = user.RealName;
                    recharge.PaymentMethodId = dr.GetInt32(9);
                    PaymentMethod pm = new PaymentMethodDAL().GetPaymentMethodById(recharge.PaymentMethodId);
                    recharge.PaymentMethodName = pm.Name;
                    recharge.PaymentType = EnumConvertor.ConvertToPaymentType(dr.GetByte(10));
                    recharge.CurrencyType = EnumConvertor.ConvertToCurrencyType(dr.GetByte(11));
                    recharge.Remark = dr.GetString(12);
                    recharge.Paid = dr.GetDecimal(13);
                    recharge.ExchangeRate = dr.GetDecimal(14);
                    recharge.Invoice = dr.GetString(15);
                    result.Results.Add(recharge);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public PaginationQueryResult<Recharge> GetRechargeByCompanyId(PaginationQueryCondition condition, int compId)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@company_id", compId)
            };
            PaginationQueryResult<Recharge> result = new PaginationQueryResult<Recharge>();
            string sql = "SELECT TOP " + condition.PageSize + " id, client_id, company_id, encode, money, account, receive_time, create_time, user_id, payment_method_id, payment_type, currency_type, remark, paid, exchange_rate, invoice FROM recharges WHERE is_delete = 0 AND company_id =              @company_id";
            if (condition.CurrentPage > 1)
            {
                sql += " AND id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM recharges WHERE is_delete = 0 AND company_id = @company_id ORDER BY id DESC) AS R )";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM recharges WHERE is_delete = 0 AND company_id = @company_id ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    Recharge recharge = new Recharge();
                    recharge.Id = dr.GetInt32(0);
                    recharge.ClientId = dr.GetInt32(1);
                    Client client = new ClientDAL().GetClientById(recharge.ClientId);
                    recharge.ClientName = client.RealName;
                    recharge.CompanyId = dr.GetInt32(2);
                    recharge.Encode = dr.GetString(3);
                    recharge.Money = dr.GetDecimal(4);
                    recharge.Account = dr.GetString(5);
                    recharge.ReceiveTime = dr.GetDateTime(6);
                    recharge.CreateTime = dr.GetDateTime(7);
                    recharge.UserId = dr.GetInt32(8);
                    User user = new UserDAL().GetUserById(recharge.UserId);
                    recharge.UserName = user.RealName;
                    recharge.PaymentMethodId = dr.GetInt32(9);
                    PaymentMethod pm = new PaymentMethodDAL().GetPaymentMethodById(recharge.PaymentMethodId);
                    recharge.PaymentMethodName = pm.Name;
                    recharge.PaymentType = EnumConvertor.ConvertToPaymentType(dr.GetByte(10));
                    recharge.CurrencyType = EnumConvertor.ConvertToCurrencyType(dr.GetByte(11));
                    recharge.Remark = dr.GetString(12);
                    recharge.Paid = dr.GetDecimal(13);
                    recharge.ExchangeRate = dr.GetDecimal(14);
                    recharge.Invoice = dr.GetString(15);
                    result.Results.Add(recharge);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public PaginationQueryResult<Recharge> GetRechargeByCompanyIdAndDate(PaginationQueryCondition condition, int compId, DateTime startDate, DateTime endDate)
        {
            DateTime minTime = new DateTime(1999, 1, 1);
            string sqlTime = "";
            if (startDate > minTime && endDate > minTime)
            {
                sqlTime = " AND create_time BETWEEN @start_date AND @end_date";
            }
            else if (startDate > minTime && endDate <= minTime)
            {
                sqlTime = " AND create_time >= @start_date ";
            }
            else
            {
                sqlTime = " AND create_time <= @end_date";
            }
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@company_id", compId),
                SqlUtilities.GenerateInputDateTimeParameter("@start_date", startDate),
                SqlUtilities.GenerateInputDateTimeParameter("@end_date", endDate)
            };
            PaginationQueryResult<Recharge> result = new PaginationQueryResult<Recharge>();
            string sql = "SELECT TOP " + condition.PageSize + " id, client_id, company_id, encode, money, account, receive_time, create_time, user_id, payment_method_id, payment_type, currency_type, remark, paid, exchange_rate, invoice FROM recharges WHERE is_delete = 0 AND company_id =              @company_id" + sqlTime;
            if (condition.CurrentPage > 1)
            {
                sql += " AND id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM recharges WHERE is_delete = 0 AND company_id = @company_id" + sqlTime + " ORDER BY id DESC) AS R )";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM recharges WHERE is_delete = 0 AND company_id = @company_id " + sqlTime;
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    Recharge recharge = new Recharge();
                    recharge.Id = dr.GetInt32(0);
                    recharge.ClientId = dr.GetInt32(1);
                    Client client = new ClientDAL().GetClientById(recharge.ClientId);
                    recharge.ClientName = client.RealName;
                    recharge.CompanyId = dr.GetInt32(2);
                    recharge.Encode = dr.GetString(3);
                    recharge.Money = dr.GetDecimal(4);
                    recharge.Account = dr.GetString(5);
                    recharge.ReceiveTime = dr.GetDateTime(6);
                    recharge.CreateTime = dr.GetDateTime(7);
                    recharge.UserId = dr.GetInt32(8);
                    User user = new UserDAL().GetUserById(recharge.UserId);
                    recharge.UserName = user.RealName;
                    recharge.PaymentMethodId = dr.GetInt32(9);
                    PaymentMethod pm = new PaymentMethodDAL().GetPaymentMethodById(recharge.PaymentMethodId);
                    recharge.PaymentMethodName = pm.Name;
                    recharge.PaymentType = EnumConvertor.ConvertToPaymentType(dr.GetByte(10));
                    recharge.CurrencyType = EnumConvertor.ConvertToCurrencyType(dr.GetByte(11));
                    recharge.Remark = dr.GetString(12);
                    recharge.Paid = dr.GetDecimal(13);
                    recharge.ExchangeRate = dr.GetDecimal(14);
                    recharge.Invoice = dr.GetString(15);
                    result.Results.Add(recharge);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }
    }
}
