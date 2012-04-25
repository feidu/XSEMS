using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Backend.Utilities;
using Backend.Models;
using Backend.Models.Pagination;
using Backend.BAL;

namespace Backend.DAL
{
    public class ShouldReceiveDAL
    {
        public void CreateOrderShouldReceive(ShouldReceive sr)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@client_id",sr.ClientId),
                SqlUtilities.GenerateInputIntParameter("@order_id", sr.Order.Id),
                SqlUtilities.GenerateInputNVarcharParameter("@type", 50, sr.Type),
                SqlUtilities.GenerateInputParameter("@status", SqlDbType.Bit, sr.Status),
                SqlUtilities.GenerateInputIntParameter("@user_id", sr.UserId),
                SqlUtilities.GenerateInputIntParameter("@company_id", sr.CompanyId),
                SqlUtilities.GenerateInputDateTimeParameter("@create_time", sr.CreateTime),
                SqlUtilities.GenerateInputDateTimeParameter("@receive_time", sr.ReceiveTime),
                SqlUtilities.GenerateInputNVarcharParameter("@encode", 50, sr.Encode),
                SqlUtilities.GenerateInputParameter("@money", SqlDbType.Decimal, sr.Money),
                SqlUtilities.GenerateInputNVarcharParameter("@remark", 500, sr.Remark)
            };

            string sql = "INSERT INTO should_receive(client_id, order_id, type, status, user_id, company_id, create_time, receive_time, encode, money, remark) VALUES(@client_id, @order_id, @type, @status, @user_id, @company_id, @create_time, @receive_time, @encode, @money, @remark)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public ShouldReceive GetShouldReceiveById(int id)
        {
            ShouldReceive sr = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "SELECT id, client_id, type, user_id, company_id, create_time, receive_time, encode, money, remark, order_id, status FROM should_receive WHERE id = @id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    sr = new ShouldReceive();
                    sr.Id = dr.GetInt32(0);
                    sr.ClientId = dr.GetInt32(1);
                    Client client = ClientOperation.GetClientById(sr.ClientId);
                    sr.ClientName = client.RealName;
                    sr.Type = dr.GetString(2);
                    sr.UserId = dr.GetInt32(3);
                    sr.CompanyId = dr.GetInt32(4);
                    sr.CreateTime = dr.GetDateTime(5);
                    sr.ReceiveTime = dr.GetDateTime(6);
                    sr.Encode = dr.GetString(7);
                    sr.Money = dr.GetDecimal(8);
                    sr.Remark = dr.GetString(9);
                    if (!dr.IsDBNull(10))
                    {
                        sr.Order = OrderOperation.GetOrderById(dr.GetInt32(10));
                    }
                    sr.Status = dr.GetBoolean(11);
                }               
            }
            return sr;
        }

        public ShouldReceive GetShouldReceiveByEncode(string encode)
        {
            ShouldReceive sr = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@encode", 50, encode)
            };
            string sql = "SELECT id, client_id, type, user_id, company_id, create_time, receive_time, encode, money, remark, order_id, status FROM should_receive WHERE encode = @encode AND status = 0 AND is_delete = 0";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    sr = new ShouldReceive();
                    sr.Id = dr.GetInt32(0);
                    sr.ClientId = dr.GetInt32(1);
                    Client client = ClientOperation.GetClientById(sr.ClientId);
                    sr.ClientName = client.RealName;
                    sr.Type = dr.GetString(2);
                    sr.UserId = dr.GetInt32(3);
                    sr.CompanyId = dr.GetInt32(4);
                    sr.CreateTime = dr.GetDateTime(5);
                    sr.ReceiveTime = dr.GetDateTime(6);
                    sr.Encode = dr.GetString(7);
                    sr.Money = dr.GetDecimal(8);
                    sr.Remark = dr.GetString(9);
                    if (!dr.IsDBNull(10))
                    {
                        sr.Order = OrderOperation.GetOrderById(dr.GetInt32(10));
                    }
                    sr.Status = dr.GetBoolean(11);
                }
            }
            return sr;
        }

        public ShouldReceive GetShouldReceivedByEncode(string encode)
        {
            ShouldReceive sr = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@encode", 50, encode)
            };
            string sql = "SELECT id, client_id, type, user_id, company_id, create_time, receive_time, encode, money, remark, order_id, status FROM should_receive WHERE encode = @encode AND status = 1 AND is_delete = 0";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    sr = new ShouldReceive();
                    sr.Id = dr.GetInt32(0);
                    sr.ClientId = dr.GetInt32(1);
                    Client client = ClientOperation.GetClientById(sr.ClientId);
                    sr.ClientName = client.RealName;
                    sr.Type = dr.GetString(2);
                    sr.UserId = dr.GetInt32(3);
                    sr.CompanyId = dr.GetInt32(4);
                    sr.CreateTime = dr.GetDateTime(5);
                    sr.ReceiveTime = dr.GetDateTime(6);
                    sr.Encode = dr.GetString(7);
                    sr.Money = dr.GetDecimal(8);
                    sr.Remark = dr.GetString(9);
                    if (!dr.IsDBNull(10))
                    {
                        sr.Order = OrderOperation.GetOrderById(dr.GetInt32(10));
                    }
                    sr.Status = dr.GetBoolean(11);
                }
            }
            return sr;
        }

        public void UpdateShouldReceive(ShouldReceive sr)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id",sr.Id),
                SqlUtilities.GenerateInputParameter("@money", SqlDbType.Decimal, sr.Money),
                SqlUtilities.GenerateInputParameter("@status", SqlDbType.Bit, sr.Status),
                SqlUtilities.GenerateInputNVarcharParameter("@type", 50, sr.Type),
                SqlUtilities.GenerateInputDateTimeParameter("@receive_time", sr.ReceiveTime),
            };

            string sql = "UPDATE should_receive SET money = @money, status = @status, type = @type, receive_time= @receive_time WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void DeleteShouldReceiveById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "UPDATE should_receive SET is_delete = 1 WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public ShouldReceive GetShouldReceiveByOrderId(int orderId)
        {
            ShouldReceive sr = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@order_id", orderId)
            };
            string sql = "SELECT id, client_id, type, user_id, company_id, create_time, receive_time, encode, money, remark, order_id, status FROM should_receive WHERE order_id = @order_id AND status = 0";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    sr = new ShouldReceive();
                    sr.Id = dr.GetInt32(0);
                    sr.ClientId = dr.GetInt32(1);
                    Client client = ClientOperation.GetClientById(sr.ClientId);
                    sr.ClientName = client.RealName;
                    sr.Type = dr.GetString(2);
                    sr.UserId = dr.GetInt32(3);
                    sr.CompanyId = dr.GetInt32(4);
                    sr.CreateTime = dr.GetDateTime(5);
                    sr.ReceiveTime = dr.GetDateTime(6);
                    sr.Encode = dr.GetString(7);
                    sr.Money = dr.GetDecimal(8);
                    sr.Remark = dr.GetString(9);
                    if (!dr.IsDBNull(10))
                    {
                        sr.Order = OrderOperation.GetOrderById(dr.GetInt32(10));
                    }
                    sr.Status = dr.GetBoolean(11);
                }               
            }
            return sr;
        }

        public ShouldReceive GetShouldReceivedByOrderId(int orderId)
        {
            ShouldReceive sr = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@order_id", orderId)
            };
            string sql = "SELECT id, client_id, type, user_id, company_id, create_time, receive_time, encode, money, remark, order_id, status FROM should_receive WHERE order_id = @order_id AND status = 1";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    sr = new ShouldReceive();
                    sr.Id = dr.GetInt32(0);
                    sr.ClientId = dr.GetInt32(1);
                    Client client = ClientOperation.GetClientById(sr.ClientId);
                    sr.ClientName = client.RealName;
                    sr.Type = dr.GetString(2);
                    sr.UserId = dr.GetInt32(3);
                    sr.CompanyId = dr.GetInt32(4);
                    sr.CreateTime = dr.GetDateTime(5);
                    sr.ReceiveTime = dr.GetDateTime(6);
                    sr.Encode = dr.GetString(7);
                    sr.Money = dr.GetDecimal(8);
                    sr.Remark = dr.GetString(9);
                    if (!dr.IsDBNull(10))
                    {
                        sr.Order = OrderOperation.GetOrderById(dr.GetInt32(10));
                    }
                    sr.Status = dr.GetBoolean(11);
                }
            }
            return sr;
        }

        public void DeleteShouldReceiveByOrderId(int orderId)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@order_id", orderId)
            };
            string sql = "UPDATE should_receive SET is_delete = 1 WHERE order_id = @order_id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public List<ShouldReceive> GetShouldReceiveByClientId(int clientId)
        {
            List<ShouldReceive> result = new List<ShouldReceive>();
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@client_id", clientId)
            };
            string sql = "SELECT  id, client_id, type, user_id, company_id, create_time, receive_time, encode, money, remark, order_id, status FROM should_receive WHERE is_delete = 0 AND status = 0 AND client_id = @client_id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    ShouldReceive sr = new ShouldReceive();
                    sr.Id = dr.GetInt32(0);
                    sr.ClientId = dr.GetInt32(1);
                    Client client = ClientOperation.GetClientById(sr.ClientId);
                    sr.ClientName = client.RealName;
                    sr.Type = dr.GetString(2);
                    sr.UserId = dr.GetInt32(3);
                    sr.CompanyId = dr.GetInt32(4);
                    sr.CreateTime = dr.GetDateTime(5);
                    sr.ReceiveTime = dr.GetDateTime(6);
                    sr.Encode = dr.GetString(7);
                    sr.Money = dr.GetDecimal(8);
                    sr.Remark = dr.GetString(9);
                    if (!dr.IsDBNull(10))
                    {
                        sr.Order = OrderOperation.GetOrderById(dr.GetInt32(10));
                    }
                    sr.Status = dr.GetBoolean(11);
                    result.Add(sr);
                }
            }
            return result;
        }

        public PaginationQueryResult<ShouldReceive> GetShouldReceiveByParameter(PaginationQueryCondition condition, int compId, bool status, DateTime startDate, DateTime endDate)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@company_id", compId),
                SqlUtilities.GenerateInputParameter("@status", SqlDbType.Bit, status),
                SqlUtilities.GenerateInputDateTimeParameter("@start_date", startDate),
                SqlUtilities.GenerateInputDateTimeParameter("@end_date", endDate)
            };
            DateTime minTime = new DateTime(1999, 1, 1);
            string sqlParam = " AND status = @status AND company_id = @company_id";
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
            PaginationQueryResult<ShouldReceive> result = new PaginationQueryResult<ShouldReceive>();
            string sql = "SELECT TOP " + condition.PageSize + " id, client_id, type, user_id, company_id, create_time, receive_time, encode, money, remark, order_id, status FROM should_receive WHERE is_delete = 0" + sqlParam;
            if (condition.CurrentPage > 1)
            {
                sql += " AND id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM should_receive  WHERE is_delete = 0 " + sqlParam + " ORDER BY id DESC) AS R )";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM should_receive WHERE is_delete = 0 " + sqlParam;
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    ShouldReceive sr = new ShouldReceive();
                    sr.Id = dr.GetInt32(0);
                    sr.ClientId = dr.GetInt32(1);
                    Client client = ClientOperation.GetClientById(sr.ClientId);
                    sr.ClientName = client.RealName;
                    sr.Type = dr.GetString(2);
                    sr.UserId = dr.GetInt32(3);
                    sr.CompanyId = dr.GetInt32(4);
                    sr.CreateTime = dr.GetDateTime(5);
                    sr.ReceiveTime = dr.GetDateTime(6);
                    sr.Encode = dr.GetString(7);
                    sr.Money = dr.GetDecimal(8);
                    sr.Remark = dr.GetString(9);
                    if (!dr.IsDBNull(10))
                    {
                        sr.Order = OrderOperation.GetOrderById(dr.GetInt32(10));
                    }
                    sr.Status = dr.GetBoolean(11);
                    result.Results.Add(sr);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }       

        public void CreateReceivedDeducted(ReceivedDeducted rd)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@company_id", rd.CompanyId),
                SqlUtilities.GenerateInputIntParameter("@client_id", rd.Client.Id),
                SqlUtilities.GenerateInputNVarcharParameter("@sr_encode", 50, rd.SrEncode),
                SqlUtilities.GenerateInputNVarcharParameter("@ar_encode", 50, rd.ArEncode),
                SqlUtilities.GenerateInputNVarcharParameter("@ar_account", 50, rd.ArAccount),
                SqlUtilities.GenerateInputIntParameter("@ar_user_id", rd.ArUserId),
                SqlUtilities.GenerateInputParameter("@money", SqlDbType.Decimal, rd.Money),
                SqlUtilities.GenerateInputDateTimeParameter("@create_time", rd.CreateTime)
            };
            string sql = "INSERT INTO received_deducted(company_id, client_id, sr_encode, ar_encode, money, create_time, ar_account, ar_user_id) VALUES(@company_id, @client_id, @sr_encode, @ar_encode, @money, @create_time, @ar_account, @ar_user_id)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void DeleteReceivedDeductedBySrEncode(string srEncode)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@sr_encode", 50, srEncode)
            };
            string sql = "UPDATE received_deducted SET is_delete = 1 WHERE sr_encode = @sr_encode";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void DeleteReceivedDeductedById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "UPDATE received_deducted SET is_delete = 1 WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public ReceivedDeducted GetReceivedDeductedBySrEncode(string srEncode)
        {
            ReceivedDeducted rd = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@sr_encode", 50, srEncode)
            };
            string sql = "SELECT id, company_id, client_id, sr_encode, ar_encode, money, create_time, ar_account, ar_user_id FROM received_deducted WHERE sr_encode = @sr_encode";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    rd = new ReceivedDeducted();
                    rd.Id = dr.GetInt32(0);
                    rd.CompanyId = dr.GetInt32(1);
                    Client client = new Client();
                    client = new ClientDAL().GetClientById(dr.GetInt32(2));
                    rd.Client = client;
                    rd.SrEncode = dr.GetString(3);
                    rd.ArEncode = dr.GetString(4);
                    rd.Money = dr.GetDecimal(5);
                    rd.CreateTime = dr.GetDateTime(6);
                    rd.ArAccount = dr.GetString(7);
                    rd.ArUserId = dr.GetInt32(8);
                }
            }
            return rd;
        }

        public List<ReceivedDeducted> GetReceivedDeductedByRechargeEncode(string arEncode)
        {
            List<ReceivedDeducted> result = new List<ReceivedDeducted>();
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@ar_encode", 50, arEncode)
            };
            string sql = "SELECT id, company_id, client_id, sr_encode, ar_encode, money, create_time, ar_account, ar_user_id FROM received_deducted WHERE ar_encode = @ar_encode";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    ReceivedDeducted rd = new ReceivedDeducted();
                    rd.Id = dr.GetInt32(0);
                    rd.CompanyId = dr.GetInt32(1);
                    Client client = new Client();
                    client = new ClientDAL().GetClientById(dr.GetInt32(2));
                    rd.Client = client;
                    rd.SrEncode = dr.GetString(3);
                    rd.ArEncode = dr.GetString(4);
                    rd.Money = dr.GetDecimal(5);
                    rd.CreateTime = dr.GetDateTime(6);
                    rd.ArAccount = dr.GetString(7);
                    rd.ArUserId = dr.GetInt32(8);
                    result.Add(rd);
                }
            }
            return result;
        }

        public void UpdateReceivedDeducted(ReceivedDeducted rd)
        {
            SqlParameter[] param=new SqlParameter[]{
                SqlUtilities.GenerateInputIntParameter("@id", rd.Id),
                SqlUtilities.GenerateInputParameter("@money", SqlDbType.Decimal, rd.Money)
                };
            string sql = "UPDATE received_deducted SET money = @money WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public PaginationQueryResult<ReceivedDeducted> GetReceivedDeductedByParameter(PaginationQueryCondition condition, int compId, DateTime startDate, DateTime endDate)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@company_id", compId),
                SqlUtilities.GenerateInputDateTimeParameter("@start_date", startDate),
                SqlUtilities.GenerateInputDateTimeParameter("@end_date", endDate)
            };
            DateTime minTime = new DateTime(1999, 1, 1);
            string sqlParam = " ";
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
            PaginationQueryResult<ReceivedDeducted> result = new PaginationQueryResult<ReceivedDeducted>();
            string sql = "SELECT TOP " + condition.PageSize + " id, company_id, client_id, sr_encode, ar_encode, money, create_time, ar_account, ar_user_id FROM received_deducted WHERE company_id = @company_id AND is_delete = 0" + sqlParam;
            if (condition.CurrentPage > 1)
            {
                sql += " AND id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM received_deducted  WHERE company_id = @company_id AND is_delete = 0" + sqlParam + " ORDER BY id DESC) AS R )";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM received_deducted WHERE company_id = @company_id AND is_delete = 0" + sqlParam;
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    ReceivedDeducted rd = new ReceivedDeducted();
                    rd.Id = dr.GetInt32(0);
                    rd.CompanyId = dr.GetInt32(1);
                    Client client = new Client();
                    client = new ClientDAL().GetClientById(dr.GetInt32(2));
                    rd.Client = client;
                    rd.SrEncode = dr.GetString(3);
                    rd.ArEncode = dr.GetString(4);
                    rd.Money = dr.GetDecimal(5);
                    rd.CreateTime = dr.GetDateTime(6);
                    rd.ArAccount = dr.GetString(7);
                    rd.ArUserId = dr.GetInt32(8);
                    result.Results.Add(rd);
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
