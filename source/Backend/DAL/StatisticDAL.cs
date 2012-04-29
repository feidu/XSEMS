using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Backend.Models;
using Backend.Utilities;

namespace Backend.DAL
{
    public class StatisticDAL
    {
        public List<UserSales> GetUserSalesStatistic(DateTime startDate, DateTime endDate, int companyId, int 
            userId)
        {
            List<UserSales> result = new List<UserSales>();

            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputDateTimeParameter("@start_date", startDate),
                SqlUtilities.GenerateInputDateTimeParameter("@end_date", endDate),
                SqlUtilities.GenerateInputIntParameter("@company_id", companyId)
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

            if (companyId > 0)
            {
                sqlParam += " AND company_id = @company_id";
            }

            if (userId > 0)
            {
                sqlParam += " AND user_id = @user_id";
            }

            string sql = "SELECT user_id, SUM(costs) AS money, SUM(costs-self_costs) AS profit FROM orders WHERE is_delete = 0 AND status IN(4,5) " + sqlParam + " GROUP BY user_id ORDER BY money DESC";

            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    UserSales us = new UserSales();
                    User user = new UserDAL().GetUserById(dr.GetInt32(0));
                    us.User = user;
                    us.Money = dr.GetDecimal(1);
                    us.Profit = dr.GetDecimal(2);
                    result.Add(us);
                }
            }
            return result;
        }

        public List<UserSales> GetUserAssessStatistic(DateTime startDate, DateTime endDate, int companyId, int clientId, string carrierEncode, int userId)
        {
            List<UserSales> result = new List<UserSales>();

            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputDateTimeParameter("@start_date", startDate),
                SqlUtilities.GenerateInputDateTimeParameter("@end_date", endDate),
                SqlUtilities.GenerateInputIntParameter("@client_id", clientId),
                SqlUtilities.GenerateInputIntParameter("@company_id", companyId),
                SqlUtilities.GenerateInputNVarcharParameter("@carrier_encode", 50, carrierEncode),
                SqlUtilities.GenerateInputIntParameter("@user_id", userId)
            };

            string sqlParam = "";
            DateTime minTime = new DateTime(1999, 1, 1);
            if (startDate > minTime && endDate > minTime)
            {
                sqlParam += " AND O.create_time BETWEEN @start_date AND @end_date";
            }
            else if (startDate > minTime && endDate <= minTime)
            {
                sqlParam += " AND O.create_time >= @start_date ";
            }
            else if (startDate <= minTime && endDate > minTime)
            {
                sqlParam += " AND O.create_time <= @end_date";
            }

            if (companyId > 0)
            {
                sqlParam += " AND O.company_id = @company_id";
            }
            if (clientId >= 0)
            {
                sqlParam += " AND O.client_id = @client_id";
            }
            if (userId > 0)
            {
                sqlParam += " AND O.user_id = @user_id";
            }
            if (!string.IsNullOrEmpty(carrierEncode))
            {
                sqlParam += " AND OD.carrier_encode = @carrier_encode";
            }

            string sql = "SELECT O.user_id, SUM(total_costs) AS costs FROM orders AS O INNER JOIN order_details AS OD ON O.id = OD.order_id WHERE O.is_delete = 0 AND OD.is_delete = 0 AND O.status IN(4,5) " + sqlParam + " GROUP BY O.user_id";

            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    UserSales us = new UserSales();
                    User user = new UserDAL().GetUserById(dr.GetInt32(0));
                    us.User = user;                    
                    us.Money = dr.GetDecimal(1);
                    result.Add(us);
                }
            }
            return result;
        }

        public List<CompanySales> GetCompanySalesStatistic(DateTime startDate, DateTime endDate, int companyId, int userId)
        {
            List<CompanySales> result = new List<CompanySales>();

            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputDateTimeParameter("@start_date", startDate),
                SqlUtilities.GenerateInputDateTimeParameter("@end_date", endDate),
                SqlUtilities.GenerateInputIntParameter("@company_id", companyId),
                SqlUtilities.GenerateInputIntParameter("@user_id", userId)
            };

            string sqlParam = "";
            DateTime minTime = new DateTime(1999, 1, 1);
            if (startDate > minTime && endDate > minTime)
            {
                sqlParam += " AND O.create_time BETWEEN @start_date AND @end_date";
            }
            else if (startDate > minTime && endDate <= minTime)
            {
                sqlParam += " AND O.create_time >= @start_date ";
            }
            else if (startDate <= minTime && endDate > minTime)
            {
                sqlParam += " AND O.create_time <= @end_date";
            }

            if (companyId > 0)
            {
                sqlParam += " AND O.company_id = @company_id";
            }
            if (userId > 0)
            {
                sqlParam += " AND O.user_id = @user_id";
            }
            string sql = "SELECT C.id, SUM(O.costs) AS money, SUM(O.costs-O.self_costs) AS profit FROM companies AS C INNER JOIN orders AS O ON C.id = O.company_id WHERE C.is_delete = 0 AND O.is_delete = 0 AND O.status IN(4,5) "+sqlParam+" GROUP BY C.id";

            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    CompanySales cs = new CompanySales();
                    Company company = new CompanyDAL().GetCompanyById(dr.GetInt32(0));
                    cs.Company = company;
                    cs.Money = dr.GetDecimal(1);
                    cs.Profit = dr.GetDecimal(2);
                    result.Add(cs);
                }
            }
            return result;
        }

        public List<ShouldReceive> GetShouldReceiveStatistic(DateTime startDate, DateTime endDate, int clientId)
        {
            List<ShouldReceive> result = new List<ShouldReceive>();

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
          
            string sql = "SELECT client_id, SUM(money) AS money FROM should_receive WHERE is_delete = 0 AND status = 0 " + sqlParam + " GROUP BY client_id";

            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    ShouldReceive sr = new ShouldReceive();
                    sr.ClientId = dr.GetInt32(0);
                    sr.Money = dr.GetDecimal(1);
                    result.Add(sr);
                }
            }

            return result;
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

            string sql = "SELECT id, client_id, encode, money, account, receive_time, create_time, user_id, payment_method_id, payment_type, currency_type, remark, paid, exchange_rate, invoice FROM recharges WHERE is_delete = 0" + sqlParam; 
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

        public List<ClientRecharge> GetRechargeDetailStatistic(DateTime startDate, DateTime endDate, int clientId, string pmIds)
        {
            List<ClientRecharge> result = new List<ClientRecharge>();

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

            string sql = "SELECT client_id FROM recharges WHERE is_delete = 0 " + sqlParam + " GROUP BY client_id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    ClientRecharge cr = new ClientRecharge();
                    Client client = new ClientDAL().GetClientById(dr.GetInt32(0));
                    cr.Client = client;
                    List<Recharge> rechargeResult = new RechargeDAL().GetRechargeStatistic(startDate, endDate, client.Id, pmIds);
                    cr.RechargeList = rechargeResult;
                    result.Add(cr);
                }
            }
            return result;
        }
    }
}
