using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Backend.Models;
using Backend.Models.Pagination;
using Backend.Utilities;

namespace Backend.DAL
{
    public class OrderDAL
    {
        public void CreateClientOrder(Order order)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@client_id", order.Client.Id),
                SqlUtilities.GenerateInputIntParameter("@company_id", order.CompanyId),
                SqlUtilities.GenerateInputNVarcharParameter("@company_name", 50, order.CompanyName),
                SqlUtilities.GenerateInputNVarcharParameter("@encode", 50,order.Encode),
                SqlUtilities.GenerateInputParameter("@status", SqlDbType.TinyInt, (byte)order.Status),
                SqlUtilities.GenerateInputParameter("@costs", SqlDbType.Money, order.Costs),
                SqlUtilities.GenerateInputParameter("@self_costs", SqlDbType.Money, order.SelfCosts),
                SqlUtilities.GenerateInputParameter("@type", SqlDbType.TinyInt, (byte)order.Type),
                SqlUtilities.GenerateInputDateTimeParameter("@create_time",order.CreateTime),
                SqlUtilities.GenerateInputNVarcharParameter("@remark", 500, order.Remark),
                SqlUtilities.GenerateInputNVarcharParameter("@to_username", 50, order.ToUsername),
                SqlUtilities.GenerateInputNVarcharParameter("@to_phone", 50, order.ToPhone),
                SqlUtilities.GenerateInputNVarcharParameter("@to_email", 50, order.ToEmail),
                SqlUtilities.GenerateInputNVarcharParameter("@to_city", 50, order.ToCity),
                SqlUtilities.GenerateInputNVarcharParameter("@to_country", 50, order.ToCountry),
                SqlUtilities.GenerateInputNVarcharParameter("@to_address", 200, order.ToAddress),
                SqlUtilities.GenerateInputNVarcharParameter("@to_postcode", 50, order.ToPostcode)
            };
            string sql = "INSERT INTO orders(client_id, company_id, company_name, encode, status, costs, self_costs, type, create_time, remark, to_username, to_phone, to_email, to_city, to_country, to_address, to_postcode) VALUES(@client_id, @company_id, @company_name, @encode, @status,         @costs, @self_costs, @type,@create_time, @remark, @to_username, @to_phone, @to_email, @to_city, @to_country, @to_address, @to_postcode)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void CreateOrder(Order order)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@client_id", order.Client.Id),
                //SqlUtilities.GenerateInputIntParameter("@company_id", order.CompanyId),
                //SqlUtilities.GenerateInputNVarcharParameter("@company_name", 50, order.CompanyName),
                //SqlUtilities.GenerateInputIntParameter("@user_id", order.UserId),
                SqlUtilities.GenerateInputVarcharParameter("@encode", 50,order.Encode),
                SqlUtilities.GenerateInputParameter("@status", SqlDbType.TinyInt, (byte)order.Status),
                SqlUtilities.GenerateInputParameter("@costs", SqlDbType.Money, order.Costs),
                SqlUtilities.GenerateInputParameter("@self_costs", SqlDbType.Money, order.SelfCosts),
                SqlUtilities.GenerateInputDateTimeParameter("@receive_date",order.ReceiveDate),
                //SqlUtilities.GenerateInputParameter("@type", SqlDbType.TinyInt, (byte)order.Type),
                SqlUtilities.GenerateInputDateTimeParameter("@create_time",order.CreateTime),
                //SqlUtilities.GenerateInputIntParameter("@calculate_type", order.CalculateType),
                //SqlUtilities.GenerateInputNVarcharParameter("@receive_type", 20, order.ReceiveType),
                //SqlUtilities.GenerateInputIntParameter("@create_user_id", order.CreateUser.Id),
                //SqlUtilities.GenerateInputIntParameter("@receive_user_id", order.ReceiveUserId),
                SqlUtilities.GenerateInputNVarcharParameter("@remark", 500, order.Remark),
                SqlUtilities.GenerateInputNVarcharParameter("@to_username", 50, order.ToUsername),
                SqlUtilities.GenerateInputNVarcharParameter("@to_phone", 50, order.ToPhone),
                SqlUtilities.GenerateInputNVarcharParameter("@to_email", 50, order.ToEmail),
                SqlUtilities.GenerateInputNVarcharParameter("@to_city", 50, order.ToCity),
                SqlUtilities.GenerateInputNVarcharParameter("@to_country", 50, order.ToCountry),
                SqlUtilities.GenerateInputNVarcharParameter("@to_address", 200, order.ToAddress),
                SqlUtilities.GenerateInputNVarcharParameter("@to_postcode", 50, order.ToPostcode),
                SqlUtilities.GenerateInputParameter("@is_quick_order", SqlDbType.Bit, order.IsQuickOrder)
            };
            string sql = "INSERT INTO orders(client_id, encode, status, costs, self_costs, receive_date, create_time, remark, to_username, to_phone, to_email, to_city, to_country, to_address, to_postcode, is_quick_order) VALUES(@client_id, @encode, @status, @costs, @self_costs, @receive_date, @create_time, @remark, @to_username, @to_phone, @to_email, @to_city, @to_country, @to_address, @to_postcode, @is_quick_order)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdateClientOrder(Order order)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", order.Id),
                SqlUtilities.GenerateInputNVarcharParameter("@to_username", 50, order.ToUsername),
                SqlUtilities.GenerateInputNVarcharParameter("@to_phone", 50, order.ToPhone),
                SqlUtilities.GenerateInputNVarcharParameter("@to_email", 50, order.ToEmail),
                SqlUtilities.GenerateInputNVarcharParameter("@to_city", 50, order.ToCity),
                SqlUtilities.GenerateInputNVarcharParameter("@to_country", 50, order.ToCountry),
                SqlUtilities.GenerateInputNVarcharParameter("@to_address", 200, order.ToAddress),
                SqlUtilities.GenerateInputNVarcharParameter("@to_postcode", 50, order.ToPostcode),
                SqlUtilities.GenerateInputNVarcharParameter("@remark", 500, order.Remark)
            };
            string sql = "UPDATE orders SET to_username = @to_username, to_phone = @to_phone, to_email = @to_email, to_city = @to_city, remark = @remark, to_country = @to_country, to_address = @to_address, to_postcode = @to_postcode WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdateOrder(Order order)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", order.Id),
                //SqlUtilities.GenerateInputIntParameter("@create_user_id", order.CreateUser.Id),
                SqlUtilities.GenerateInputDateTimeParameter("@receive_date", order.ReceiveDate),
                SqlUtilities.GenerateInputParameter("@costs", SqlDbType.Money, order.Costs),
                SqlUtilities.GenerateInputParameter("@self_costs", SqlDbType.Money, order.SelfCosts),
                //SqlUtilities.GenerateInputIntParameter("@receive_user_id", order.ReceiveUserId),
                SqlUtilities.GenerateInputNVarcharParameter("@remark", 500, order.Remark)
            };
            string sql = "UPDATE orders SET costs = @costs, self_costs= @self_costs, remark = @remark, receive_date = @receive_date, WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdateOrderStatus(Order order)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", order.Id),
                SqlUtilities.GenerateInputParameter("@status", SqlDbType.TinyInt, (byte)order.Status)
             };
            string sql = " UPDATE orders SET status = @status WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdateOrderAuditInfo(Order order)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", order.Id),
                SqlUtilities.GenerateInputIntParameter("@audit_user_id", order.AuditUserId),
                SqlUtilities.GenerateInputDateTimeParameter("@audit_time", order.AuditTime)
             };
            string sql = " UPDATE orders SET audit_user_id = @audit_user_id, audit_time = @audit_time WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdateOrderCheckInfo(Order order)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", order.Id),
                SqlUtilities.GenerateInputIntParameter("@check_user_id", order.CheckUserId),
                SqlUtilities.GenerateInputDateTimeParameter("@check_time", order.CheckTime)
             };
            string sql = " UPDATE orders SET check_user_id = @check_user_id, check_time = @check_time WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdateOrderReason(Order order)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", order.Id),
                SqlUtilities.GenerateInputNVarcharParameter("@reason", 500, order.Reason)
             };
            string sql = " UPDATE orders SET reason = @reason WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdateOrderIsMailSend(Order order)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", order.Id),
                SqlUtilities.GenerateInputParameter("@is_mail_send", SqlDbType.Bit, order.IsMailSend)
             };
            string sql = " UPDATE orders SET is_mail_send = @is_mail_send WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void DeleteOrderById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
             };
            string sql = " UPDATE orders SET is_delete = 1 WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public Order GetOrderById(int id)
        {
            Order order = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "SELECT id, client_id, encode, status, costs, receive_date, create_time, remark, is_mail_send, audit_user_id, audit_time, check_user_id, check_time, reason, to_username, to_phone, to_email, to_city, to_country, to_address, to_postcode, self_costs FROM orders WHERE id = @id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    order = new Order();
                    order.Id = dr.GetInt32(0);
                    Client client = new ClientDAL().GetClientById(dr.GetInt32(1));
                    order.Client = client;      
                    order.Encode = dr.GetString(2);
                    order.Status = EnumConvertor.ConvertToOrderStatus(dr.GetByte(3));
                    order.Costs = dr.GetDecimal(4);
                    if (!dr.IsDBNull(5))
                    {
                        order.ReceiveDate = dr.GetDateTime(5);
                    }
                    order.CreateTime = dr.GetDateTime(6);                                      
                    order.Remark = dr.GetString(7);
                    order.IsMailSend = dr.GetBoolean(8);
                    if (!dr.IsDBNull(9))
                    {
                        order.AuditUserId = dr.GetInt32(9);
                    }
                    if (!dr.IsDBNull(10))
                    {
                        order.AuditTime = dr.GetDateTime(10);
                    }
                    if (!dr.IsDBNull(11))
                    {
                        order.CheckUserId = dr.GetInt32(11);
                    }
                    if (!dr.IsDBNull(12))
                    {
                        order.CheckTime = dr.GetDateTime(12);
                    }
                    if (!dr.IsDBNull(13))
                    {
                        order.Reason = dr.GetString(13);
                    }
                    order.ToUsername = dr.GetString(14);
                    order.ToPhone = dr.GetString(14);
                    order.ToEmail = dr.GetString(16);
                    order.ToCity = dr.GetString(17);
                    order.ToCountry = dr.GetString(18);
                    order.ToAddress = dr.GetString(19);
                    order.ToPostcode = dr.GetString(20);
                    order.SelfCosts = dr.GetDecimal(21);
                }
            }
            return order;
        }

        public Order GetOrderByEncode(string encode)
        {
            Order order = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@encode", 50, encode)
            };
            string sql = "SELECT id, client_id, encode, status, costs, receive_date, create_time, remark, is_mail_send, audit_user_id, audit_time, check_user_id, check_time, reason, to_username, to_phone, to_email, to_city, to_country, to_address, to_postcode, self_costs FROM orders WHERE encode = @encode";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    order = new Order();
                    order.Id = dr.GetInt32(0);
                    Client client = new ClientDAL().GetClientById(dr.GetInt32(1));
                    order.Client = client;
                    order.Encode = dr.GetString(2);
                    order.Status = EnumConvertor.ConvertToOrderStatus(dr.GetByte(3));
                    order.Costs = dr.GetDecimal(4);
                    if (!dr.IsDBNull(5))
                    {
                        order.ReceiveDate = dr.GetDateTime(5);
                    }
                    order.CreateTime = dr.GetDateTime(6);
                    order.Remark = dr.GetString(7);
                    order.IsMailSend = dr.GetBoolean(8);
                    if (!dr.IsDBNull(9))
                    {
                        order.AuditUserId = dr.GetInt32(9);
                    }
                    if (!dr.IsDBNull(10))
                    {
                        order.AuditTime = dr.GetDateTime(10);
                    }
                    if (!dr.IsDBNull(11))
                    {
                        order.CheckUserId = dr.GetInt32(11);
                    }
                    if (!dr.IsDBNull(12))
                    {
                        order.CheckTime = dr.GetDateTime(12);
                    }
                    if (!dr.IsDBNull(13))
                    {
                        order.Reason = dr.GetString(13);
                    }
                    order.ToUsername = dr.GetString(14);
                    order.ToPhone = dr.GetString(14);
                    order.ToEmail = dr.GetString(16);
                    order.ToCity = dr.GetString(17);
                    order.ToCountry = dr.GetString(18);
                    order.ToAddress = dr.GetString(19);
                    order.ToPostcode = dr.GetString(20);
                    order.SelfCosts = dr.GetDecimal(21);
                }
            }
            return order;
        }

        public Order GetOrderByClientIdAndEncode(int clientId, string encode)
        {
            Order order = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@client_id", clientId),
                SqlUtilities.GenerateInputNVarcharParameter("@encode", 50, encode)
            };
            string sql = "SELECT id, client_id, encode, status, costs, receive_date, create_time, remark, is_mail_send, audit_user_id, audit_time, check_user_id, check_time, reason, to_username, to_phone, to_email, to_city, to_country, to_address, to_postcode, self_costs FROM orders WHERE is_delete = 0 AND client_id = @client_id AND encode = @encode";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    order = new Order();
                    order.Id = dr.GetInt32(0);
                    Client client = new ClientDAL().GetClientById(dr.GetInt32(1));
                    order.Client = client;
                    order.Encode = dr.GetString(2);
                    order.Status = EnumConvertor.ConvertToOrderStatus(dr.GetByte(3));
                    order.Costs = dr.GetDecimal(4);
                    if (!dr.IsDBNull(5))
                    {
                        order.ReceiveDate = dr.GetDateTime(5);
                    }
                    order.CreateTime = dr.GetDateTime(6);
                    order.Remark = dr.GetString(7);
                    order.IsMailSend = dr.GetBoolean(8);
                    if (!dr.IsDBNull(9))
                    {
                        order.AuditUserId = dr.GetInt32(9);
                    }
                    if (!dr.IsDBNull(10))
                    {
                        order.AuditTime = dr.GetDateTime(10);
                    }
                    if (!dr.IsDBNull(11))
                    {
                        order.CheckUserId = dr.GetInt32(11);
                    }
                    if (!dr.IsDBNull(12))
                    {
                        order.CheckTime = dr.GetDateTime(12);
                    }
                    if (!dr.IsDBNull(13))
                    {
                        order.Reason = dr.GetString(13);
                    }
                    order.ToUsername = dr.GetString(14);
                    order.ToPhone = dr.GetString(14);
                    order.ToEmail = dr.GetString(16);
                    order.ToCity = dr.GetString(17);
                    order.ToCountry = dr.GetString(18);
                    order.ToAddress = dr.GetString(19);
                    order.ToPostcode = dr.GetString(20);
                    order.SelfCosts = dr.GetDecimal(21);
                }
            }
            return order;
        }

        public Order GetOrderByClientIdEncodeAndStatus(int clientId, string encode, OrderStatus status)
        {
            Order order = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@client_id", clientId),
                SqlUtilities.GenerateInputParameter("@status", SqlDbType.TinyInt, (byte)status),
                SqlUtilities.GenerateInputNVarcharParameter("@encode", 50, encode)
            };
            string sql = "SELECT id, client_id, encode, status, costs, receive_date, create_time, remark, is_mail_send, audit_user_id, audit_time, check_user_id, check_time, reason, to_username, to_phone, to_email, to_city, to_country, to_address, to_postcode, self_costs FROM orders WHERE is_delete = 0 AND client_id = @client_id AND encode = @encode AND status = @status";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    order = new Order();
                    order.Id = dr.GetInt32(0);
                    Client client = new ClientDAL().GetClientById(dr.GetInt32(1));
                    order.Client = client;
                    order.Encode = dr.GetString(2);
                    order.Status = EnumConvertor.ConvertToOrderStatus(dr.GetByte(3));
                    order.Costs = dr.GetDecimal(4);
                    if (!dr.IsDBNull(5))
                    {
                        order.ReceiveDate = dr.GetDateTime(5);
                    }
                    order.CreateTime = dr.GetDateTime(6);
                    order.Remark = dr.GetString(7);
                    order.IsMailSend = dr.GetBoolean(8);
                    if (!dr.IsDBNull(9))
                    {
                        order.AuditUserId = dr.GetInt32(9);
                    }
                    if (!dr.IsDBNull(10))
                    {
                        order.AuditTime = dr.GetDateTime(10);
                    }
                    if (!dr.IsDBNull(11))
                    {
                        order.CheckUserId = dr.GetInt32(11);
                    }
                    if (!dr.IsDBNull(12))
                    {
                        order.CheckTime = dr.GetDateTime(12);
                    }
                    if (!dr.IsDBNull(13))
                    {
                        order.Reason = dr.GetString(13);
                    }
                    order.ToUsername = dr.GetString(14);
                    order.ToPhone = dr.GetString(14);
                    order.ToEmail = dr.GetString(16);
                    order.ToCity = dr.GetString(17);
                    order.ToCountry = dr.GetString(18);
                    order.ToAddress = dr.GetString(19);
                    order.ToPostcode = dr.GetString(20);
                    order.SelfCosts = dr.GetDecimal(21);
                }
            }
            return order;
        }

        public Order GetTodayClientOrderByParameters(int clientId, DateTime dtToday)
        {
            Order order = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@client_id", clientId),
                SqlUtilities.GenerateInputDateTimeParameter("@startTime", new DateTime(dtToday.Year, dtToday.Month, dtToday.Day, 0, 0, 0)),
                SqlUtilities.GenerateInputDateTimeParameter("@endTime", new DateTime(dtToday.Year, dtToday.Month, dtToday.Day, 23, 59, 59))
            };
            string sql = "SELECT id, client_id, encode, status, costs, receive_date, create_time, remark, is_mail_send, audit_user_id, audit_time, check_user_id, check_time, reason, to_username, to_phone, to_email, to_city, to_country, to_address, to_postcode, self_costs FROM orders WHERE is_delete = 0 AND client_id = @client_id AND is_quick_order = 1 AND create_time BETWEEN @startTime AND @endTime AND status = 1";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    order = new Order();
                    order.Id = dr.GetInt32(0);
                    Client client = new ClientDAL().GetClientById(dr.GetInt32(1));
                    order.Client = client;
                    order.Encode = dr.GetString(2);
                    order.Status = EnumConvertor.ConvertToOrderStatus(dr.GetByte(3));
                    order.Costs = dr.GetDecimal(4);
                    if (!dr.IsDBNull(5))
                    {
                        order.ReceiveDate = dr.GetDateTime(5);
                    }
                    order.CreateTime = dr.GetDateTime(6);
                    order.Remark = dr.GetString(7);
                    order.IsMailSend = dr.GetBoolean(8);
                    if (!dr.IsDBNull(9))
                    {
                        order.AuditUserId = dr.GetInt32(9);
                    }
                    if (!dr.IsDBNull(10))
                    {
                        order.AuditTime = dr.GetDateTime(10);
                    }
                    if (!dr.IsDBNull(11))
                    {
                        order.CheckUserId = dr.GetInt32(11);
                    }
                    if (!dr.IsDBNull(12))
                    {
                        order.CheckTime = dr.GetDateTime(12);
                    }
                    if (!dr.IsDBNull(13))
                    {
                        order.Reason = dr.GetString(13);
                    }
                    order.ToUsername = dr.GetString(14);
                    order.ToPhone = dr.GetString(14);
                    order.ToEmail = dr.GetString(16);
                    order.ToCity = dr.GetString(17);
                    order.ToCountry = dr.GetString(18);
                    order.ToAddress = dr.GetString(19);
                    order.ToPostcode = dr.GetString(20);
                    order.SelfCosts = dr.GetDecimal(21);
                }
            }
            return order;
        }

        //public PaginationQueryResult<Order> GetOrderCostByClientId(PaginationQueryCondition condition, int clientId)
        //{
        //    PaginationQueryResult<Order> result = new PaginationQueryResult<Order>();
        //    SqlParameter[] param = new SqlParameter[] { 
        //        SqlUtilities.GenerateInputIntParameter("@client_id", clientId)
        //    };
        //    string sql = "SELECT TOP " + condition.PageSize + " id, client_id, company_id, company_name, user_id, encode, status, costs, receive_date, type, create_time, calculate_type, receive_type, create_user_id, receive_user_id, remark, is_mail_send, audit_user_id, audit_time, check_user_id, check_time FROM orders WHERE is_delete = 0 AND client_id = @client_id AND status IN(4,5) ";
        //    if (condition.CurrentPage > 1)
        //    {
        //        sql += " AND id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM orders WHERE is_delete = 0 AND client_id = @client_id AND status IN(4,5) ORDER BY id DESC) AS O) ";
        //    }
        //    sql += " ORDER BY id DESC; SELECT COUNT(*) FROM orders WHERE is_delete = 0 AND client_id = @client_id AND status IN(4,5) ";
        //    using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
        //    {
        //        while (dr.Read())
        //        {
        //            Order order = new Order();
        //            order.Id = dr.GetInt32(0);
        //            Client client = new ClientDAL().GetClientById(dr.GetInt32(1));
        //            order.Client = client;
        //            order.CompanyId = dr.GetInt32(2);
        //            order.CompanyName = dr.GetString(3);
        //            if (!dr.IsDBNull(4))
        //            {
        //                order.UserId = dr.GetInt32(4);
        //            }
        //            order.Encode = dr.GetString(5);
        //            order.Status = EnumConvertor.ConvertToOrderStatus(dr.GetByte(6));
        //            order.Costs = dr.GetDecimal(7);
        //            if (!dr.IsDBNull(8))
        //            {
        //                order.ReceiveDate = dr.GetDateTime(8);
        //            }
        //            order.Type = EnumConvertor.ConvertToOrderType(dr.GetByte(9));
        //            order.CreateTime = dr.GetDateTime(10);
        //            order.CalculateType = dr.GetInt32(11);
        //            order.ReceiveType = dr.GetString(12);
        //            if (!dr.IsDBNull(13))
        //            {
        //                User user = new UserDAL().GetUserById(dr.GetInt32(13));
        //                order.CreateUser = user;
        //            }
        //            if (!dr.IsDBNull(14))
        //            {
        //                order.ReceiveUserId = dr.GetInt32(14);
        //            }
        //            order.Remark = dr.GetString(15);
        //            order.IsMailSend = dr.GetBoolean(16);
        //            if (!dr.IsDBNull(17))
        //            {
        //                order.AuditUserId = dr.GetInt32(17);
        //            }
        //            if (!dr.IsDBNull(18))
        //            {
        //                order.AuditTime = dr.GetDateTime(18);
        //            }
        //            if (!dr.IsDBNull(19))
        //            {
        //                order.CheckUserId = dr.GetInt32(19);
        //            }
        //            if (!dr.IsDBNull(20))
        //            {
        //                order.CheckTime = dr.GetDateTime(20);
        //            }
        //            result.Results.Add(order);
        //        }
        //        dr.NextResult();
        //        while (dr.Read())
        //        {
        //            result.TotalCount = dr.GetInt32(0);
        //        }
        //    }
        //    return result;
        //}

        //public PaginationQueryResult<Order> GetOrderCostByClientIdAndDate(PaginationQueryCondition condition, int clientId, DateTime startDate, DateTime endDate)
        //{
        //    DateTime minTime = new DateTime(1999, 1, 1);
        //    string sqlTime = "";
        //    if (startDate > minTime && endDate > minTime)
        //    {
        //        sqlTime = " AND create_time BETWEEN @start_date AND @end_date";
        //    }
        //    else if (startDate > minTime && endDate <= minTime)
        //    {
        //        sqlTime = " AND create_time >= @start_date ";
        //    }
        //    else
        //    {
        //        sqlTime = " AND create_time <= @end_date";
        //    }
        //    PaginationQueryResult<Order> result = new PaginationQueryResult<Order>();
        //    SqlParameter[] param = new SqlParameter[] { 
        //        SqlUtilities.GenerateInputDateTimeParameter("@start_date", startDate),
        //        SqlUtilities.GenerateInputDateTimeParameter("@end_date", endDate),
        //        SqlUtilities.GenerateInputIntParameter("@client_id", clientId),
        //    };
        //    string sql = "SELECT TOP " + condition.PageSize + " id, client_id, company_id, company_name, user_id, encode, status, costs, receive_date, type, create_time, calculate_type, receive_type, create_user_id, receive_user_id, remark, is_mail_send, audit_user_id, audit_time, check_user_id, check_time FROM orders WHERE is_delete = 0 AND client_id = @client_id AND status IN(4,5) " + sqlTime;
        //    if (condition.CurrentPage > 1)
        //    {
        //        sql += " AND id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM orders WHERE is_delete = 0 AND client_id = @client_id AND status IN(4,5) " + sqlTime + " ORDER BY id DESC) AS O) ";
        //    }
        //    sql += " ORDER BY id DESC; SELECT COUNT(*) FROM orders WHERE is_delete = 0 AND client_id = @client_id AND status IN(4,5) " + sqlTime;
        //    using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
        //    {
        //        while (dr.Read())
        //        {
        //            Order order = new Order();
        //            order.Id = dr.GetInt32(0);
        //            Client client = new ClientDAL().GetClientById(dr.GetInt32(1));
        //            order.Client = client;
        //            order.CompanyId = dr.GetInt32(2);
        //            order.CompanyName = dr.GetString(3);
        //            if (!dr.IsDBNull(4))
        //            {
        //                order.UserId = dr.GetInt32(4);
        //            }
        //            order.Encode = dr.GetString(5);
        //            order.Status = EnumConvertor.ConvertToOrderStatus(dr.GetByte(6));
        //            order.Costs = dr.GetDecimal(7);
        //            if (!dr.IsDBNull(8))
        //            {
        //                order.ReceiveDate = dr.GetDateTime(8);
        //            }
        //            order.Type = EnumConvertor.ConvertToOrderType(dr.GetByte(9));
        //            order.CreateTime = dr.GetDateTime(10);
        //            order.CalculateType = dr.GetInt32(11);
        //            order.ReceiveType = dr.GetString(12);
        //            if (!dr.IsDBNull(13))
        //            {
        //                User user = new UserDAL().GetUserById(dr.GetInt32(13));
        //                order.CreateUser = user;
        //            }
        //            if (!dr.IsDBNull(14))
        //            {
        //                order.ReceiveUserId = dr.GetInt32(14);
        //            }
        //            order.Remark = dr.GetString(15);
        //            order.IsMailSend = dr.GetBoolean(16);
        //            if (!dr.IsDBNull(17))
        //            {
        //                order.AuditUserId = dr.GetInt32(17);
        //            }
        //            if (!dr.IsDBNull(18))
        //            {
        //                order.AuditTime = dr.GetDateTime(18);
        //            }
        //            if (!dr.IsDBNull(19))
        //            {
        //                order.CheckUserId = dr.GetInt32(19);
        //            }
        //            if (!dr.IsDBNull(20))
        //            {
        //                order.CheckTime = dr.GetDateTime(20);
        //            }
        //            result.Results.Add(order);
        //        }
        //        dr.NextResult();
        //        while (dr.Read())
        //        {
        //            result.TotalCount = dr.GetInt32(0);
        //        }
        //    }
        //    return result;
        //}

        public  PaginationQueryResult<SearchOrderDetail> GetOrderCostsDetailByParameters(PaginationQueryCondition condition, int clientId, DateTime startDate, DateTime endDate, string barCode, string remark)
        {
            PaginationQueryResult<SearchOrderDetail> result = new PaginationQueryResult<SearchOrderDetail>();

            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputDateTimeParameter("@start_date", startDate),
                SqlUtilities.GenerateInputDateTimeParameter("@end_date", endDate),
                SqlUtilities.GenerateInputIntParameter("@client_id", clientId),
                SqlUtilities.GenerateInputNVarcharParameter("@bar_code", 50, barCode),
                SqlUtilities.GenerateInputNVarcharParameter("@remark", 50, remark)
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
            if (clientId >= 0)
            {
                sqlParam += " AND O.client_id = @client_id";
            }
            if (!string.IsNullOrEmpty(barCode))
            {
                sqlParam += " AND OD.bar_code = @bar_code";
            }
            if (!string.IsNullOrEmpty(remark))
            {
                sqlParam += " AND OD.remark = @remark";
            }


            string sql = "SELECT TOP " + condition.PageSize + " O.encode, O.create_time, O.client_id, O.receive_date, OD.carrier_encode, OD.weight AS weight, OD.[count] AS conunt, OD.total_costs AS costs, OD.self_total_costs, OD.create_time, OD.bar_code, OD.to_country, OD.remark, OD.to_username FROM orders AS O INNER JOIN order_details AS OD ON O.id =   OD.order_id WHERE O.is_delete = 0 AND OD.is_delete = 0 AND O.status IN(4,5) " + sqlParam;
            if (condition.CurrentPage > 1)
            {
                sql += " AND OD.id <(SELECT MIN(id) FROM (SELECT TOP "+condition.PageSize*(condition.CurrentPage-1)+" OD.id FROM orders AS O INNER JOIN order_details AS OD ON O.id =   OD.order_id WHERE O.is_delete = 0 AND OD.is_delete = 0 AND O.status IN(4,5) " + sqlParam+" ORDER BY OD.id DESC) AS O)";
            }
            sql += " ORDER BY OD.id DESC; SELECT COUNT(*) FROM orders AS O INNER JOIN order_details AS OD ON O.id =   OD.order_id WHERE O.is_delete = 0 AND OD.is_delete = 0 AND O.status IN(4,5) " + sqlParam;

            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    SearchOrderDetail sod = new SearchOrderDetail();
                    sod.OrderEncode = dr.GetString(0);
                    sod.CreateTime = dr.GetDateTime(1);
                    Client client = new ClientDAL().GetClientById(dr.GetInt32(2));
                    sod.Client = client;
                    sod.OrderReceiveDate = dr.GetDateTime(3);
                    sod.CarrierEncode = dr.GetString(4);
                    sod.Weight = dr.GetDecimal(5);
                    sod.Count = dr.GetInt32(6);
                    sod.TotalCosts = dr.GetDecimal(7);
                    sod.SelfTotalCosts = dr.GetDecimal(8);
                    sod.CreateTime = dr.GetDateTime(9);
                    sod.BarCode = dr.GetString(10);
                    sod.ToCountry = dr.GetString(11);
                    sod.Remark = dr.GetString(12);
                    sod.ToUsername = dr.GetString(13);
                    result.Results.Add(sod);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public PaginationQueryResult<SearchOrderDetail> GetOrderCostsPostInfoDetailsByParameters(PaginationQueryCondition condition, int clientId, DateTime startDate, DateTime endDate, string barCode, string remark)
        {
            PaginationQueryResult<SearchOrderDetail> result = new PaginationQueryResult<SearchOrderDetail>();

            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputDateTimeParameter("@start_date", startDate),
                SqlUtilities.GenerateInputDateTimeParameter("@end_date", endDate),
                SqlUtilities.GenerateInputIntParameter("@client_id", clientId),
                SqlUtilities.GenerateInputNVarcharParameter("@bar_code", 50, barCode),
                SqlUtilities.GenerateInputNVarcharParameter("@remark", 50, remark)
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
            if (clientId >= 0)
            {
                sqlParam += " AND O.client_id = @client_id";
            }
            if (!string.IsNullOrEmpty(barCode))
            {
                sqlParam += " AND OD.bar_code = @bar_code";
            }
            if (!string.IsNullOrEmpty(remark))
            {
                sqlParam += " AND OD.remark = @remark";
            }


            string sql = "SELECT TOP " + condition.PageSize + " O.encode, O.create_time, O.client_id, O.receive_date, OD.carrier_encode, OD.weight AS weight, OD.[count] AS conunt, OD.total_costs AS costs, OD.self_total_costs, OD.create_time, OD.bar_code, OD.to_country, OD.remark, OD.to_username, OD.last_disposal_time, OD.post_status, OD.is_tracking FROM orders AS O INNER JOIN order_details AS OD ON O.id =   OD.order_id WHERE O.is_delete = 0 AND OD.is_delete = 0 AND O.status IN(4,5) " + sqlParam;
            if (condition.CurrentPage > 1)
            {
                sql += " AND OD.id <(SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " OD.id FROM orders AS O INNER JOIN order_details AS OD ON O.id =   OD.order_id WHERE O.is_delete = 0 AND OD.is_delete = 0 AND O.status IN(4,5) " + sqlParam + " ORDER BY OD.id DESC) AS O)";
            }
            sql += " ORDER BY OD.id DESC; SELECT COUNT(*) FROM orders AS O INNER JOIN order_details AS OD ON O.id =   OD.order_id WHERE O.is_delete = 0 AND OD.is_delete = 0 AND O.status IN(4,5) " + sqlParam;

            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    SearchOrderDetail sod = new SearchOrderDetail();
                    sod.OrderEncode = dr.GetString(0);
                    sod.CreateTime = dr.GetDateTime(1);
                    Client client = new ClientDAL().GetClientById(dr.GetInt32(2));
                    sod.Client = client;
                    sod.OrderReceiveDate = dr.GetDateTime(3);
                    sod.CarrierEncode = dr.GetString(4);
                    sod.Weight = dr.GetDecimal(5);
                    sod.Count = dr.GetInt32(6);
                    sod.TotalCosts = dr.GetDecimal(7);
                    sod.SelfTotalCosts = dr.GetDecimal(8);
                    sod.CreateTime = dr.GetDateTime(9);
                    sod.BarCode = dr.GetString(10);
                    sod.ToCountry = dr.GetString(11);
                    sod.Remark = dr.GetString(12);
                    sod.ToUsername = dr.GetString(13);
                    if (!dr.IsDBNull(14))
                    {
                        sod.LastDisposalTime = dr.GetDateTime(14);
                    }
                    if (!dr.IsDBNull(15))
                    {
                        sod.PostStatus = dr.GetString(15);
                    }
                    sod.IsTracking = dr.GetBoolean(16);
                    result.Results.Add(sod);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public List<SearchOrderDetail> GetOrderCostsDetailByParameters(int clientId, DateTime startDate, DateTime endDate, string barCode, string remark)
        {
            List<SearchOrderDetail> result = new List<SearchOrderDetail>();

            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputDateTimeParameter("@start_date", startDate),
                SqlUtilities.GenerateInputDateTimeParameter("@end_date", endDate),
                SqlUtilities.GenerateInputIntParameter("@client_id", clientId),
                SqlUtilities.GenerateInputNVarcharParameter("@bar_code", 50, barCode),
                SqlUtilities.GenerateInputNVarcharParameter("@remark", 50, remark)
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
            if (clientId >= 0)
            {
                sqlParam += " AND O.client_id = @client_id";
            }
            if (!string.IsNullOrEmpty(barCode))
            {
                sqlParam += " AND OD.bar_code = @bar_code";
            }
            if (!string.IsNullOrEmpty(remark))
            {
                sqlParam += " AND OD.remark = @remark";
            }


            string sql = "SELECT O.encode, O.create_time, O.client_id, O.receive_date, OD.carrier_encode, OD.weight AS weight, OD.[count] AS conunt, OD.total_costs AS costs, OD.self_total_costs, OD.create_time, OD.bar_code, OD.to_country, OD.remark, OD.to_username FROM orders AS O INNER JOIN order_details AS OD ON O.id =   OD.order_id WHERE O.is_delete = 0 AND OD.is_delete = 0 AND O.status IN(4,5) " + sqlParam + " ORDER BY O.id DESC";
            
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    SearchOrderDetail sod = new SearchOrderDetail();
                    sod.OrderEncode = dr.GetString(0);
                    sod.CreateTime = dr.GetDateTime(1);
                    Client client = new ClientDAL().GetClientById(dr.GetInt32(2));
                    sod.Client = client;
                    sod.OrderReceiveDate = dr.GetDateTime(3);
                    sod.CarrierEncode = dr.GetString(4);
                    sod.Weight = dr.GetDecimal(5);
                    sod.Count = dr.GetInt32(6);
                    sod.TotalCosts = dr.GetDecimal(7);
                    sod.SelfTotalCosts = dr.GetDecimal(8);
                    sod.CreateTime = dr.GetDateTime(9);
                    sod.BarCode = dr.GetString(10);
                    sod.ToCountry = dr.GetString(11);
                    sod.Remark = dr.GetString(12);
                    sod.ToUsername = dr.GetString(13);
                    result.Add(sod);
                }          
            }
            return result;
        }

        public decimal GetClientTodayOrderCostsByParameters(int clientId)
        {
            DateTime dtNow = DateTime.Now;
            DateTime startDate = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 0,0,0,0);
            DateTime endDate = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 23, 59, 59, 999);
            DateTime minTime = new DateTime(1999, 1, 1);
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@client_id", clientId),
                SqlUtilities.GenerateInputDateTimeParameter("@startDate", startDate),
                SqlUtilities.GenerateInputDateTimeParameter("@endDate", endDate),
            };

            string sqlParam = "   AND O.create_time BETWEEN @startDate AND @endDate AND O.client_id = @client_id";
           


            string sql = "SELECT SUM(OD.total_costs) FROM orders AS O INNER JOIN order_details AS OD ON O.id =   OD.order_id WHERE O.is_delete = 0 AND OD.is_delete = 0 AND O.status IN(4,5) " + sqlParam;

            decimal todayCosts = 0;
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        todayCosts = dr.GetDecimal(0);
                    }
                }
            }
            return todayCosts;
        }

        public PaginationQueryResult<Order> GetOrderByClientId(PaginationQueryCondition condition, int cId)
        {
            PaginationQueryResult<Order> result = new PaginationQueryResult<Order>();
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@client_id", cId)
            };
            string sql = "SELECT TOP " + condition.PageSize + " id, client_id, company_id, company_name, user_id, encode, status, costs, receive_date, type, create_time, calculate_type, receive_type, create_user_id, receive_user_id, remark, is_mail_send, audit_user_id, audit_time, check_user_id, check_time FROM orders WHERE is_delete = 0 AND client_id = @client_id";
            if (condition.CurrentPage > 1)
            {
                sql += " AND id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM orders WHERE is_delete = 0 AND client_id = @client_id ORDER BY id DESC) AS O) ";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM orders WHERE is_delete = 0 AND client_id = @client_id ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    Order order = new Order();
                    order.Id = dr.GetInt32(0);
                    Client client = new ClientDAL().GetClientById(dr.GetInt32(1));
                    order.Client = client;
                    order.CompanyId = dr.GetInt32(2);
                    order.CompanyName = dr.GetString(3);
                    if (!dr.IsDBNull(4))
                    {
                        order.UserId = dr.GetInt32(4);
                    }
                    order.Encode = dr.GetString(5);
                    order.Status = EnumConvertor.ConvertToOrderStatus(dr.GetByte(6));
                    order.Costs = dr.GetDecimal(7);
                    if (!dr.IsDBNull(8))
                    {
                        order.ReceiveDate = dr.GetDateTime(8);
                    }
                    order.Type = EnumConvertor.ConvertToOrderType(dr.GetByte(9));
                    order.CreateTime = dr.GetDateTime(10);
                    order.CalculateType = dr.GetInt32(11);
                    order.ReceiveType = dr.GetString(12);
                    if (!dr.IsDBNull(13))
                    {
                        User user = new UserDAL().GetUserById(dr.GetInt32(13));
                        order.CreateUser = user;
                    }
                    if (!dr.IsDBNull(14))
                    {
                        order.ReceiveUserId = dr.GetInt32(14);
                    }
                    order.Remark = dr.GetString(15);
                    order.IsMailSend = dr.GetBoolean(16);
                    if (!dr.IsDBNull(17))
                    {
                        order.AuditUserId = dr.GetInt32(17);
                    }
                    if (!dr.IsDBNull(18))
                    {
                        order.AuditTime = dr.GetDateTime(18);
                    }
                    if (!dr.IsDBNull(19))
                    {
                        order.CheckUserId = dr.GetInt32(19);
                    }
                    if (!dr.IsDBNull(20))
                    {
                        order.CheckTime = dr.GetDateTime(20);
                    }
                    result.Results.Add(order);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public PaginationQueryResult<Order> GetOrderByClientIdAndStatus(PaginationQueryCondition condition, int clientId, OrderStatus status)
        {
            PaginationQueryResult<Order> result = new PaginationQueryResult<Order>();
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@client_id", clientId),
                SqlUtilities.GenerateInputParameter("@status", SqlDbType.TinyInt, (byte)status)
            };
            string sql = "SELECT TOP " + condition.PageSize + " id, client_id, company_id, company_name, user_id, encode, status, costs, receive_date, type, create_time, calculate_type, receive_type, create_user_id, receive_user_id, remark, is_mail_send, audit_user_id, audit_time, check_user_id, check_time FROM orders WHERE is_delete = 0 AND client_id = @client_id AND status = @status";
            if (condition.CurrentPage > 1)
            {
                sql += " AND id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM orders WHERE is_delete = 0 AND client_id = @client_id AND status = @status ORDER BY id DESC) AS O) ";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM orders WHERE is_delete = 0 AND client_id = @client_id AND status = @status ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    Order order = new Order();
                    order.Id = dr.GetInt32(0);
                    Client client = new ClientDAL().GetClientById(dr.GetInt32(1));
                    order.Client = client;
                    order.CompanyId = dr.GetInt32(2);
                    order.CompanyName = dr.GetString(3);
                    if (!dr.IsDBNull(4))
                    {
                        order.UserId = dr.GetInt32(4);
                    }
                    order.Encode = dr.GetString(5);
                    order.Status = EnumConvertor.ConvertToOrderStatus(dr.GetByte(6));
                    order.Costs = dr.GetDecimal(7);
                    if (!dr.IsDBNull(8))
                    {
                        order.ReceiveDate = dr.GetDateTime(8);
                    }
                    order.Type = EnumConvertor.ConvertToOrderType(dr.GetByte(9));
                    order.CreateTime = dr.GetDateTime(10);
                    order.CalculateType = dr.GetInt32(11);
                    order.ReceiveType = dr.GetString(12);
                    if (!dr.IsDBNull(13))
                    {
                        User user = new UserDAL().GetUserById(dr.GetInt32(13));
                        order.CreateUser = user;
                    }
                    if (!dr.IsDBNull(14))
                    {
                        order.ReceiveUserId = dr.GetInt32(14);
                    }
                    order.Remark = dr.GetString(15);
                    order.IsMailSend = dr.GetBoolean(16);
                    if (!dr.IsDBNull(17))
                    {
                        order.AuditUserId = dr.GetInt32(17);
                    }
                    if (!dr.IsDBNull(18))
                    {
                        order.AuditTime = dr.GetDateTime(18);
                    }
                    if (!dr.IsDBNull(19))
                    {
                        order.CheckUserId = dr.GetInt32(19);
                    }
                    if (!dr.IsDBNull(20))
                    {
                        order.CheckTime = dr.GetDateTime(20);
                    }
                    result.Results.Add(order);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public PaginationQueryResult<Order> GetOrderByClientIdAndDate(PaginationQueryCondition condition, int clientId, DateTime startDate, DateTime endDate)
        {
            DateTime minTime = new DateTime(1999, 1, 1);
            string sqlTime = "";
            if (startDate > minTime && endDate>minTime)
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
            PaginationQueryResult<Order> result = new PaginationQueryResult<Order>();
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputDateTimeParameter("@start_date", startDate),
                SqlUtilities.GenerateInputDateTimeParameter("@end_date", endDate),
                SqlUtilities.GenerateInputIntParameter("@client_id", clientId)
            };
            string sql = "SELECT TOP " + condition.PageSize + " id, client_id, company_id, company_name, user_id, encode, status, costs, receive_date, type, create_time, calculate_type, receive_type, create_user_id, receive_user_id, remark, is_mail_send, audit_user_id, audit_time, check_user_id, check_time FROM orders WHERE is_delete = 0 AND client_id = @client_id "+sqlTime ;
            if (condition.CurrentPage > 1)
            {
                sql += " AND id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM orders WHERE is_delete = 0 AND client_id = @client_id "+sqlTime+" ORDER BY id DESC) AS O) ";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM orders WHERE is_delete = 0 AND client_id = @client_id "+sqlTime;
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    Order order = new Order();
                    order.Id = dr.GetInt32(0);
                    Client client = new ClientDAL().GetClientById(dr.GetInt32(1));
                    order.Client = client;
                    order.CompanyId = dr.GetInt32(2);
                    order.CompanyName = dr.GetString(3);
                    if (!dr.IsDBNull(4))
                    {
                        order.UserId = dr.GetInt32(4);
                    }
                    order.Encode = dr.GetString(5);
                    order.Status = EnumConvertor.ConvertToOrderStatus(dr.GetByte(6));
                    order.Costs = dr.GetDecimal(7);
                    if (!dr.IsDBNull(8))
                    {
                        order.ReceiveDate = dr.GetDateTime(8);
                    }
                    order.Type = EnumConvertor.ConvertToOrderType(dr.GetByte(9));
                    order.CreateTime = dr.GetDateTime(10);
                    order.CalculateType = dr.GetInt32(11);
                    order.ReceiveType = dr.GetString(12);
                    if (!dr.IsDBNull(13))
                    {
                        User user = new UserDAL().GetUserById(dr.GetInt32(13));
                        order.CreateUser = user;
                    }
                    if (!dr.IsDBNull(14))
                    {
                        order.ReceiveUserId = dr.GetInt32(14);
                    }
                    order.Remark = dr.GetString(15);
                    order.IsMailSend = dr.GetBoolean(16);
                    if (!dr.IsDBNull(17))
                    {
                        order.AuditUserId = dr.GetInt32(17);
                    }
                    if (!dr.IsDBNull(18))
                    {
                        order.AuditTime = dr.GetDateTime(18);
                    }
                    if (!dr.IsDBNull(19))
                    {
                        order.CheckUserId = dr.GetInt32(19);
                    }
                    if (!dr.IsDBNull(20))
                    {
                        order.CheckTime = dr.GetDateTime(20);
                    }
                    result.Results.Add(order);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public PaginationQueryResult<Order> GetOrderByClientIdStatusAndDate(PaginationQueryCondition condition, int clientId, OrderStatus status,DateTime startDate, DateTime endDate)
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
            PaginationQueryResult<Order> result = new PaginationQueryResult<Order>();
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputDateTimeParameter("@start_date", startDate),
                SqlUtilities.GenerateInputDateTimeParameter("@end_date", endDate),
                SqlUtilities.GenerateInputIntParameter("@client_id", clientId),
                SqlUtilities.GenerateInputParameter("@status", SqlDbType.TinyInt, (byte)status)
            };
            string sql = "SELECT TOP " + condition.PageSize + " id, client_id, company_id, company_name, user_id, encode, status, costs, receive_date, type, create_time, calculate_type, receive_type, create_user_id, receive_user_id, remark, is_mail_send, audit_user_id, audit_time, check_user_id, check_time FROM orders WHERE is_delete = 0 AND client_id = @client_id AND status = @status "+sqlTime;
            if (condition.CurrentPage > 1)
            {
                sql += " AND id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM orders WHERE is_delete = 0 AND client_id = @client_id AND status = @status "+sqlTime+" ORDER BY id DESC) AS O) ";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM orders WHERE is_delete = 0 AND client_id = @client_id AND status = @status "+sqlTime;
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    Order order = new Order();
                    order.Id = dr.GetInt32(0);
                    Client client = new ClientDAL().GetClientById(dr.GetInt32(1));
                    order.Client = client;
                    order.CompanyId = dr.GetInt32(2);
                    order.CompanyName = dr.GetString(3);
                    if (!dr.IsDBNull(4))
                    {
                        order.UserId = dr.GetInt32(4);
                    }
                    order.Encode = dr.GetString(5);
                    order.Status = EnumConvertor.ConvertToOrderStatus(dr.GetByte(6));
                    order.Costs = dr.GetDecimal(7);
                    if (!dr.IsDBNull(8))
                    {
                        order.ReceiveDate = dr.GetDateTime(8);
                    }
                    order.Type = EnumConvertor.ConvertToOrderType(dr.GetByte(9));
                    order.CreateTime = dr.GetDateTime(10);
                    order.CalculateType = dr.GetInt32(11);
                    order.ReceiveType = dr.GetString(12);
                    if (!dr.IsDBNull(13))
                    {
                        User user = new UserDAL().GetUserById(dr.GetInt32(13));
                        order.CreateUser = user;
                    }
                    if (!dr.IsDBNull(14))
                    {
                        order.ReceiveUserId = dr.GetInt32(14);
                    }
                    order.Remark = dr.GetString(15);
                    order.IsMailSend = dr.GetBoolean(16);
                    if (!dr.IsDBNull(17))
                    {
                        order.AuditUserId = dr.GetInt32(17);
                    }
                    if (!dr.IsDBNull(18))
                    {
                        order.AuditTime = dr.GetDateTime(18);
                    }
                    if (!dr.IsDBNull(19))
                    {
                        order.CheckUserId = dr.GetInt32(19);
                    }
                    if (!dr.IsDBNull(20))
                    {
                        order.CheckTime = dr.GetDateTime(20);
                    }
                    result.Results.Add(order);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public PaginationQueryResult<Order> GetOrderByCompanyIdAndStatus(PaginationQueryCondition condition, int compId, OrderStatus status)
        {
            PaginationQueryResult<Order> result = new PaginationQueryResult<Order>();
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@company_id", compId),
                SqlUtilities.GenerateInputParameter("@status", SqlDbType.TinyInt, (byte)status)
            };
            string sql = "SELECT TOP " + condition.PageSize + " id, client_id, company_id, company_name, user_id, encode, status, costs, receive_date, type, create_time, calculate_type, receive_type, create_user_id, receive_user_id, remark, is_mail_send, audit_user_id, audit_time, check_user_id, check_time FROM orders WHERE is_delete = 0 AND company_id = @company_id AND status = @status";
            if (condition.CurrentPage > 1)
            {
                sql += " AND id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM orders WHERE is_delete = 0 AND company_id = @company_id AND status = @status ORDER BY id DESC) AS O) ";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM orders WHERE company_id = @company_id AND status = @status";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    Order order = new Order();
                    order.Id = dr.GetInt32(0);
                    Client client = new ClientDAL().GetClientById(dr.GetInt32(1));
                    order.Client = client;
                    order.CompanyId = dr.GetInt32(2);
                    order.CompanyName = dr.GetString(3);
                    if (!dr.IsDBNull(4))
                    {
                        order.UserId = dr.GetInt32(4);
                    }
                    order.Encode = dr.GetString(5);
                    order.Status = EnumConvertor.ConvertToOrderStatus(dr.GetByte(6));
                    order.Costs = dr.GetDecimal(7);
                    if (!dr.IsDBNull(8))
                    {
                        order.ReceiveDate = dr.GetDateTime(8);
                    }
                    order.Type = EnumConvertor.ConvertToOrderType(dr.GetByte(9));
                    order.CreateTime = dr.GetDateTime(10);
                    order.CalculateType = dr.GetInt32(11);
                    order.ReceiveType = dr.GetString(12);
                    if (!dr.IsDBNull(13))
                    {
                        User user = new UserDAL().GetUserById(dr.GetInt32(13));
                        order.CreateUser = user;
                    }
                    if (!dr.IsDBNull(14))
                    {
                        order.ReceiveUserId = dr.GetInt32(14);
                    }
                    order.Remark = dr.GetString(15);
                    order.IsMailSend = dr.GetBoolean(16);
                    if (!dr.IsDBNull(17))
                    {
                        order.AuditUserId = dr.GetInt32(17);
                    }
                    if (!dr.IsDBNull(18))
                    {
                        order.AuditTime = dr.GetDateTime(18);
                    }
                    if (!dr.IsDBNull(19))
                    {
                        order.CheckUserId = dr.GetInt32(19);
                    }
                    if (!dr.IsDBNull(20))
                    {
                        order.CheckTime = dr.GetDateTime(20);
                    }
                    result.Results.Add(order);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public PaginationQueryResult<Order> GetOrderByCompanyIdStatusAndEncode(PaginationQueryCondition condition, int compId, OrderStatus status, string encode)
        {
            PaginationQueryResult<Order> result = new PaginationQueryResult<Order>();
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@encode", 50, encode), 
                SqlUtilities.GenerateInputIntParameter("@company_id", compId),
                SqlUtilities.GenerateInputParameter("@status", SqlDbType.TinyInt, (byte)status)
            };
            string sql = "SELECT TOP " + condition.PageSize + " id, client_id, company_id, company_name, user_id, encode, status, costs, receive_date, type, create_time, calculate_type, receive_type, create_user_id, receive_user_id, remark, is_mail_send, audit_user_id, audit_time, check_user_id, check_time FROM orders WHERE is_delete = 0 AND company_id = @company_id AND status = @status AND encode = @encode";
            if (condition.CurrentPage > 1)
            {
                sql += " AND id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM orders WHERE is_delete = 0 AND company_id = @company_id AND status = @status AND encode = @encode ORDER BY id DESC) AS O) ";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM orders WHERE company_id = @company_id AND status = @status AND encode = @encode";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    Order order = new Order();
                    order.Id = dr.GetInt32(0);
                    Client client = new ClientDAL().GetClientById(dr.GetInt32(1));
                    order.Client = client;
                    order.CompanyId = dr.GetInt32(2);
                    order.CompanyName = dr.GetString(3);
                    if (!dr.IsDBNull(4))
                    {
                        order.UserId = dr.GetInt32(4);
                    }
                    order.Encode = dr.GetString(5);
                    order.Status = EnumConvertor.ConvertToOrderStatus(dr.GetByte(6));
                    order.Costs = dr.GetDecimal(7);
                    if (!dr.IsDBNull(8))
                    {
                        order.ReceiveDate = dr.GetDateTime(8);
                    }
                    order.Type = EnumConvertor.ConvertToOrderType(dr.GetByte(9));
                    order.CreateTime = dr.GetDateTime(10);
                    order.CalculateType = dr.GetInt32(11);
                    order.ReceiveType = dr.GetString(12);
                    if (!dr.IsDBNull(13))
                    {
                        User user = new UserDAL().GetUserById(dr.GetInt32(13));
                        order.CreateUser = user;
                    }
                    if (!dr.IsDBNull(14))
                    {
                        order.ReceiveUserId = dr.GetInt32(14);
                    }
                    order.Remark = dr.GetString(15);
                    order.IsMailSend = dr.GetBoolean(16);
                    if (!dr.IsDBNull(17))
                    {
                        order.AuditUserId = dr.GetInt32(17);
                    }
                    if (!dr.IsDBNull(18))
                    {
                        order.AuditTime = dr.GetDateTime(18);
                    }
                    if (!dr.IsDBNull(19))
                    {
                        order.CheckUserId = dr.GetInt32(19);
                    }
                    if (!dr.IsDBNull(20))
                    {
                        order.CheckTime = dr.GetDateTime(20);
                    }
                    result.Results.Add(order);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public PaginationQueryResult<Order> GetOrderByCompanyIdStatusAndDate(PaginationQueryCondition condition, int compId, OrderStatus status, DateTime startDate, DateTime endDate)
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
            PaginationQueryResult<Order> result = new PaginationQueryResult<Order>();
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputDateTimeParameter("@start_date", startDate),
                SqlUtilities.GenerateInputDateTimeParameter("@end_date", endDate),
                SqlUtilities.GenerateInputIntParameter("@company_id", compId),
                SqlUtilities.GenerateInputParameter("@status", SqlDbType.TinyInt, (byte)status)
            };
            string sql = "SELECT TOP " + condition.PageSize + " id, client_id, company_id, company_name, user_id, encode, status, costs, receive_date, type, create_time, calculate_type, receive_type, create_user_id, receive_user_id, remark, is_mail_send, audit_user_id, audit_time, check_user_id, check_time FROM orders WHERE is_delete = 0 AND company_id = @company_id AND status = @status "+sqlTime;
            if (condition.CurrentPage > 1)
            {
                sql += " AND id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM orders WHERE is_delete = 0 AND company_id = @company_id AND status = @status "+sqlTime+" ORDER BY id DESC) AS O) ";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM orders WHERE company_id = @company_id AND status = @status "+sqlTime;
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    Order order = new Order();
                    order.Id = dr.GetInt32(0);
                    Client client = new ClientDAL().GetClientById(dr.GetInt32(1));
                    order.Client = client;
                    order.CompanyId = dr.GetInt32(2);
                    order.CompanyName = dr.GetString(3);
                    if (!dr.IsDBNull(4))
                    {
                        order.UserId = dr.GetInt32(4);
                    }
                    order.Encode = dr.GetString(5);
                    order.Status = EnumConvertor.ConvertToOrderStatus(dr.GetByte(6));
                    order.Costs = dr.GetDecimal(7);
                    if (!dr.IsDBNull(8))
                    {
                        order.ReceiveDate = dr.GetDateTime(8);
                    }
                    order.Type = EnumConvertor.ConvertToOrderType(dr.GetByte(9));
                    order.CreateTime = dr.GetDateTime(10);
                    order.CalculateType = dr.GetInt32(11);
                    order.ReceiveType = dr.GetString(12);
                    if (!dr.IsDBNull(13))
                    {
                        User user = new UserDAL().GetUserById(dr.GetInt32(13));
                        order.CreateUser = user;
                    }
                    if (!dr.IsDBNull(14))
                    {
                        order.ReceiveUserId = dr.GetInt32(14);
                    }
                    order.Remark = dr.GetString(15);
                    order.IsMailSend = dr.GetBoolean(16);
                    if (!dr.IsDBNull(17))
                    {
                        order.AuditUserId = dr.GetInt32(17);
                    }
                    if (!dr.IsDBNull(18))
                    {
                        order.AuditTime = dr.GetDateTime(18);
                    }
                    if (!dr.IsDBNull(19))
                    {
                        order.CheckUserId = dr.GetInt32(19);
                    }
                    if (!dr.IsDBNull(20))
                    {
                        order.CheckTime = dr.GetDateTime(20);
                    }
                    result.Results.Add(order);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public PaginationQueryResult<Order> GetAuditOrderByCompanyIdAndConsignType(PaginationQueryCondition condition, int compId, int consignType)
        {
            PaginationQueryResult<Order> result = new PaginationQueryResult<Order>();
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@company_id", compId),
                SqlUtilities.GenerateInputParameter("@status", SqlDbType.TinyInt, (byte)OrderStatus.WAIT_AUDIT)
            };
            string sql = "";
            switch (consignType)
            {
                case 1:
                    sql = "SELECT TOP " + condition.PageSize + " id, client_id, company_id, company_name, user_id, encode, status, costs, receive_date, type, create_time, calculate_type, receive_type, create_user_id, receive_user_id, remark FROM orders WHERE is_delete = 0 AND company_id = @company_id AND status = @status";
                    if (condition.CurrentPage > 1)
                    {
                        sql += " AND id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM orders WHERE is_delete = 0 AND company_id = @company_id AND status = @status ORDER BY id DESC) AS O) ";
                    }
                    sql += " ORDER BY id DESC; SELECT COUNT(*) FROM orders WHERE company_id = @company_id AND status = @status";
                    break;
                case 2:
                    sql = "SELECT TOP " + condition.PageSize + " OS.id, OS.client_id, OS.company_id, OS.company_name, OS.user_id, OS.encode,             OS.status, OS.costs, OS.receive_date, OS.type, OS.create_time, OS.calculate_type, OS.receive_type, OS.create_user_id, OS.receive_user_id,           OS.remark, CS.balance FROM orders AS OS INNER JOIN clients AS CS ON  OS.client_id = CS.id WHERE OS.is_delete = 0 AND OS.company_id = @company_id AND OS.status = @status AND (CS.balance + CS.credit) >= OS.costs";
                    if (condition.CurrentPage > 1)
                    {
                        sql += " AND OS.id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " OS.id FROM orders WHERE OS.is_delete = 0 AND OS.company_id = @company_id AND OS.status = @status AND (CS.balance + CS.credit) >= OS.costs ORDER BY OS.id DESC) AS O) ";
                    }
                    sql += " ORDER BY OS.id DESC; SELECT COUNT(*) FROM orders AS OS INNER JOIN clients AS CS ON  OS.client_id = CS.id WHERE         OS.is_delete = 0 AND OS.company_id = @company_id AND OS.status = @status AND (CS.balance + CS.credit) >= OS.costs";
                    break;
                case 3:
                    sql = "SELECT TOP " + condition.PageSize + " OS.id, OS.client_id, OS.company_id, OS.company_name, OS.user_id, OS.encode,             OS.status, OS.costs, OS.receive_date, OS.type, OS.create_time, OS.calculate_type, OS.receive_type, OS.create_user_id, OS.receive_user_id,           OS.remark, CS.balance FROM orders AS OS INNER JOIN clients AS CS ON  OS.client_id = CS.id WHERE OS.is_delete = 0 AND OS.company_id = @company_id AND OS.status = @status AND (CS.balance + CS.credit) < OS.costs";
                    if (condition.CurrentPage > 1)
                    {
                        sql += " AND OS.id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " OS.id FROM orders WHERE OS.is_delete = 0 AND OS.company_id = @company_id AND OS.status = @status AND (CS.balance + CS.credit) < OS.costs ORDER BY OS.id DESC) AS O) ";
                    }
                    sql += " ORDER BY OS.id DESC; SELECT COUNT(*) FROM orders AS OS INNER JOIN clients AS CS ON  OS.client_id = CS.id WHERE         OS.is_delete = 0 AND OS.company_id = @company_id AND OS.status = @status AND (CS.balance + CS.credit) < OS.costs";
                    break;
            }          
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    Order order = new Order();
                    order.Id = dr.GetInt32(0);
                    Client client = new ClientDAL().GetClientById(dr.GetInt32(1));
                    order.Client = client;
                    order.CompanyId = dr.GetInt32(2);
                    order.CompanyName = dr.GetString(3);
                    if (!dr.IsDBNull(4))
                    {
                        order.UserId = dr.GetInt32(4);
                    }
                    order.Encode = dr.GetString(5);
                    order.Status = EnumConvertor.ConvertToOrderStatus(dr.GetByte(6));
                    order.Costs = dr.GetDecimal(7);
                    if (!dr.IsDBNull(8))
                    {
                        order.ReceiveDate = dr.GetDateTime(8);
                    }
                    order.Type = EnumConvertor.ConvertToOrderType(dr.GetByte(9));
                    order.CreateTime = dr.GetDateTime(10);
                    order.CalculateType = dr.GetInt32(11);
                    order.ReceiveType = dr.GetString(12);
                    if (!dr.IsDBNull(13))
                    {
                        User user = new UserDAL().GetUserById(dr.GetInt32(13));
                        order.CreateUser = user;
                    }
                    if (!dr.IsDBNull(14))
                    {
                        order.ReceiveUserId = dr.GetInt32(14);
                    }
                    order.Remark = dr.GetString(15);
                    result.Results.Add(order);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public PaginationQueryResult<Order> GetAuditOrderByCompIdConsignTypeAndEncode(PaginationQueryCondition condition, int compId, int consignType, string encode)
        {
            PaginationQueryResult<Order> result = new PaginationQueryResult<Order>();
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@company_id", compId),
                SqlUtilities.GenerateInputNVarcharParameter("@encode", 50, encode),
                SqlUtilities.GenerateInputParameter("@status", SqlDbType.TinyInt, (byte)OrderStatus.WAIT_AUDIT)
            };
            string sql = "";
            switch (consignType)
            {
                case 1:
                    sql = "SELECT TOP " + condition.PageSize + " id, client_id, company_id, company_name, user_id, encode, status, costs, receive_date, type, create_time, calculate_type, receive_type, create_user_id, receive_user_id, remark FROM orders WHERE is_delete = 0 AND company_id = @company_id AND status = @status AND encode = @encode";
                    if (condition.CurrentPage > 1)
                    {
                        sql += " AND id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM orders WHERE is_delete = 0 AND company_id = @company_id AND status = @status AND encode = @encode ORDER BY id DESC) AS O) ";
                    }
                    sql += " ORDER BY id DESC; SELECT COUNT(*) FROM orders WHERE company_id = @company_id AND status = @status AND encode = @encode";
                    break;
                case 2:
                    sql = "SELECT TOP " + condition.PageSize + " OS.id, OS.client_id, OS.company_id, OS.company_name, OS.user_id, OS.encode,             OS.status, OS.costs, OS.receive_date, OS.type, OS.create_time, OS.calculate_type, OS.receive_type, OS.create_user_id, OS.receive_user_id,           OS.remark, CS.balance FROM orders AS OS INNER JOIN clients AS CS ON  OS.client_id = CS.id WHERE OS.is_delete = 0 AND OS.company_id = @company_id AND OS.status = @status AND OS.encode = @encode AND (CS.balance + CS.credit) >= OS.costs";
                    if (condition.CurrentPage > 1)
                    {
                        sql += " AND OS.id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " OS.id FROM orders WHERE OS.is_delete = 0 AND OS.company_id = @company_id AND OS.status = @status AND OS.encode = @encode AND (CS.balance + CS.credit) >=       OS.costs ORDER BY   OS.id DESC) AS O) ";
                    }
                    sql += " ORDER BY OS.id DESC; SELECT COUNT(*) FROM orders AS OS INNER JOIN clients AS CS ON  OS.client_id = CS.id WHERE         OS.is_delete = 0 AND OS.company_id = @company_id AND OS.status = @status AND OS.encode = @encode AND (CS.balance + CS.credit) >= OS.costs";
                    break;
                case 3:
                    sql = "SELECT TOP " + condition.PageSize + " OS.id, OS.client_id, OS.company_id, OS.company_name, OS.user_id, OS.encode,             OS.status, OS.costs, OS.receive_date, OS.type, OS.create_time, OS.calculate_type, OS.receive_type, OS.create_user_id, OS.receive_user_id,           OS.remark, CS.balance FROM orders AS OS INNER JOIN clients AS CS ON  OS.client_id = CS.id WHERE OS.is_delete = 0 AND OS.company_id = @company_id AND OS.status = @status AND OS.encode = @encode AND (CS.balance + CS.credit) < OS.costs";
                    if (condition.CurrentPage > 1)
                    {
                        sql += " AND OS.id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " OS.id FROM orders WHERE OS.is_delete = 0 AND OS.company_id = @company_id AND OS.status = @status AND OS.encode = @encode AND (CS.balance + CS.credit) < OS.costs ORDER BY    OS.id DESC) AS O) ";
                    }
                    sql += " ORDER BY OS.id DESC; SELECT COUNT(*) FROM orders AS OS INNER JOIN clients AS CS ON  OS.client_id = CS.id WHERE         OS.is_delete = 0 AND OS.company_id = @company_id AND OS.status = @status AND OS.encode = @encode AND (CS.balance + CS.credit) < OS.costs";
                    break;
            }
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    Order order = new Order();
                    order.Id = dr.GetInt32(0);
                    Client client = new ClientDAL().GetClientById(dr.GetInt32(1));
                    order.Client = client;
                    order.CompanyId = dr.GetInt32(2);
                    order.CompanyName = dr.GetString(3);
                    if (!dr.IsDBNull(4))
                    {
                        order.UserId = dr.GetInt32(4);
                    }
                    order.Encode = dr.GetString(5);
                    order.Status = EnumConvertor.ConvertToOrderStatus(dr.GetByte(6));
                    order.Costs = dr.GetDecimal(7);
                    if (!dr.IsDBNull(8))
                    {
                        order.ReceiveDate = dr.GetDateTime(8);
                    }
                    order.Type = EnumConvertor.ConvertToOrderType(dr.GetByte(9));
                    order.CreateTime = dr.GetDateTime(10);
                    order.CalculateType = dr.GetInt32(11);
                    order.ReceiveType = dr.GetString(12);
                    if (!dr.IsDBNull(13))
                    {
                        User user = new UserDAL().GetUserById(dr.GetInt32(13));
                        order.CreateUser = user;
                    }
                    if (!dr.IsDBNull(14))
                    {
                        order.ReceiveUserId = dr.GetInt32(14);
                    }
                    order.Remark = dr.GetString(15);
                    result.Results.Add(order);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public PaginationQueryResult<Order> GetAuditOrderByCompanyIdConsignTypeAndDate(PaginationQueryCondition condition, int compId, int consignType, DateTime startDate, DateTime endDate)
        {
            DateTime minTime = new DateTime(1999, 1, 1);
            string sqlTime = "";
            string sqlTimes = "";
            if (startDate > minTime && endDate > minTime)
            {
                sqlTime = " AND create_time BETWEEN @start_date AND @end_date";
                sqlTimes = " AND OS.create_time BETWEEN @start_date AND @end_date";
            }
            else if (startDate > minTime && endDate <= minTime)
            {
                sqlTime = " AND create_time >= @start_date ";
                sqlTimes = " AND OS.create_time >= @start_date ";
            }
            else
            {
                sqlTime = " AND create_time <= @end_date";
                sqlTimes = " AND OS.create_time <= @end_date ";
            }
            PaginationQueryResult<Order> result = new PaginationQueryResult<Order>();
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputDateTimeParameter("@start_date", startDate),
                SqlUtilities.GenerateInputDateTimeParameter("@end_date", endDate),
                SqlUtilities.GenerateInputIntParameter("@company_id", compId),
                SqlUtilities.GenerateInputParameter("@status", SqlDbType.TinyInt, (byte)OrderStatus.WAIT_AUDIT)
            };
            string sql = "";
            switch (consignType)
            {
                case 1:
                    sql = "SELECT TOP " + condition.PageSize + " id, client_id, company_id, company_name, user_id, encode, status, costs, receive_date, type, create_time, calculate_type, receive_type, create_user_id, receive_user_id, remark FROM orders WHERE is_delete = 0 AND company_id = @company_id AND status = @status"+sqlTime;
                    if (condition.CurrentPage > 1)
                    {
                        sql += " AND id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM orders WHERE is_delete = 0 AND company_id = @company_id AND status = @status "+sqlTime+" ORDER BY id DESC) AS O) ";
                    }
                    sql += " ORDER BY id DESC; SELECT COUNT(*) FROM orders WHERE company_id = @company_id AND status = @status"+sqlTime;
                    break;
                case 2:
                    sql = "SELECT TOP " + condition.PageSize + " OS.id, OS.client_id, OS.company_id, OS.company_name, OS.user_id, OS.encode,             OS.status, OS.costs, OS.receive_date, OS.type, OS.create_time, OS.calculate_type, OS.receive_type, OS.create_user_id, OS.receive_user_id,           OS.remark, CS.balance FROM orders AS OS INNER JOIN clients AS CS ON  OS.client_id = CS.id WHERE OS.is_delete = 0 AND OS.company_id = @company_id AND OS.status = @status AND (CS.balance + CS.credit) >= OS.costs" + sqlTimes;
                    if (condition.CurrentPage > 1)
                    {
                        sql += " AND OS.id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " OS.id FROM orders WHERE OS.is_delete = 0 AND OS.company_id = @company_id AND OS.status = @status " + sqlTimes + " AND (CS.balance + CS.credit) >= OS.costs ORDER BY OS.id DESC) AS O) ";
                    }
                    sql += " ORDER BY OS.id DESC; SELECT COUNT(*) FROM orders AS OS INNER JOIN clients AS CS ON  OS.client_id = CS.id WHERE         OS.is_delete = 0 AND OS.company_id = @company_id AND OS.status = @status AND (CS.balance + CS.credit) >= OS.costs" + sqlTimes;
                    break;
                case 3:
                    sql = "SELECT TOP " + condition.PageSize + " OS.id, OS.client_id, OS.company_id, OS.company_name, OS.user_id, OS.encode,             OS.status, OS.costs, OS.receive_date, OS.type, OS.create_time, OS.calculate_type, OS.receive_type, OS.create_user_id, OS.receive_user_id,           OS.remark, CS.balance FROM orders AS OS INNER JOIN clients AS CS ON  OS.client_id = CS.id WHERE OS.is_delete = 0 AND OS.company_id = @company_id AND OS.status = @status AND (CS.balance + CS.credit) < OS.costs" + sqlTimes;
                    if (condition.CurrentPage > 1)
                    {
                        sql += " AND OS.id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " OS.id FROM orders WHERE OS.is_delete = 0 AND OS.company_id = @company_id AND OS.status = @status " + sqlTimes + " AND (CS.balance + CS.credit) < OS.costs ORDER BY OS.id DESC) AS O) ";
                    }
                    sql += " ORDER BY OS.id DESC; SELECT COUNT(*) FROM orders AS OS INNER JOIN clients AS CS ON  OS.client_id = CS.id WHERE         OS.is_delete = 0 AND OS.company_id = @company_id AND OS.status = @status AND (CS.balance + CS.credit) < OS.costs" + sqlTimes;
                    break;
            }
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    Order order = new Order();
                    order.Id = dr.GetInt32(0);
                    Client client = new ClientDAL().GetClientById(dr.GetInt32(1));
                    order.Client = client;
                    order.CompanyId = dr.GetInt32(2);
                    order.CompanyName = dr.GetString(3);
                    if (!dr.IsDBNull(4))
                    {
                        order.UserId = dr.GetInt32(4);
                    }
                    order.Encode = dr.GetString(5);
                    order.Status = EnumConvertor.ConvertToOrderStatus(dr.GetByte(6));
                    order.Costs = dr.GetDecimal(7);
                    if (!dr.IsDBNull(8))
                    {
                        order.ReceiveDate = dr.GetDateTime(8);
                    }
                    order.Type = EnumConvertor.ConvertToOrderType(dr.GetByte(9));
                    order.CreateTime = dr.GetDateTime(10);
                    order.CalculateType = dr.GetInt32(11);
                    order.ReceiveType = dr.GetString(12);
                    if (!dr.IsDBNull(13))
                    {
                        User user = new UserDAL().GetUserById(dr.GetInt32(13));
                        order.CreateUser = user;
                    }
                    if (!dr.IsDBNull(14))
                    {
                        order.ReceiveUserId = dr.GetInt32(14);
                    }
                    order.Remark = dr.GetString(15);
                    result.Results.Add(order);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public PaginationQueryResult<SearchOrder> GetSearchOrderByParameters(PaginationQueryCondition condition, string carrierEncode, int clientId, string encode, string ydEncode, string barCode, DateTime startDate, DateTime endDate, byte status, int companyId)
        {
            PaginationQueryResult<SearchOrder> result = new PaginationQueryResult<SearchOrder>();

            SqlParameter[] param = new SqlParameter[] { 
                    SqlUtilities.GenerateInputDateTimeParameter("@start_date", startDate),
                    SqlUtilities.GenerateInputDateTimeParameter("@end_date", endDate),
                    SqlUtilities.GenerateInputIntParameter("@client_id", clientId),
                    SqlUtilities.GenerateInputNVarcharParameter("@carrier_encode", 50, carrierEncode),
                    SqlUtilities.GenerateInputNVarcharParameter("@encode", 50, encode),
                    SqlUtilities.GenerateInputNVarcharParameter("@yd_encode", 50, ydEncode),
                    SqlUtilities.GenerateInputNVarcharParameter("@bar_code", 50, barCode),
                    SqlUtilities.GenerateInputParameter("@status", SqlDbType.TinyInt, status),
                    SqlUtilities.GenerateInputIntParameter("@company_id", companyId)
                };

            string sqlParam = "";
            if (!string.IsNullOrEmpty(carrierEncode))
            {
                sqlParam += " AND OD.carrier_encode = @carrier_encode";
            }
            if (clientId >= 0)
            {
                sqlParam += " AND O.client_id = @client_id";
            }
            if (!string.IsNullOrEmpty(encode))
            {
                sqlParam += " AND O.encode = @encode";
            }
            if(!string.IsNullOrEmpty(ydEncode))
            {
                sqlParam += " AND OD.encode = @yd_encode";
            }
            if (!string.IsNullOrEmpty(barCode))
            {
                sqlParam += " AND OD.bar_code = @bar_code";
            }
            DateTime minTime = new DateTime(1999, 1, 1);            
            if (startDate > minTime && endDate > minTime)
            {
                sqlParam += " AND O.create_time BETWEEN @start_date AND @end_date";
            }
            else if (startDate > minTime && endDate <= minTime)
            {
                sqlParam += " AND O.create_time >= @start_date ";
            }
            else if(startDate<= minTime && endDate > minTime)
            {
                sqlParam += " AND O.create_time <= @end_date";
            }
            if (status != 0)
            {
                sqlParam += " AND O.status = @status";
            }
            if (companyId > 0)
            {
                sqlParam += " AND O.company_id = @company_id";
            }
            string sql = "SELECT TOP " + condition.PageSize + " O.id, O.create_time, O.encode, O.client_id, OD.carrier_encode, OD.to_country,       OD.to_username, OD.bar_code, OD.id, O.status FROM orders AS O inner JOIN order_details AS OD ON O.id = OD.order_id WHERE O.is_delete = 0 AND        OD.is_delete = 0 " + sqlParam;
            if (condition.CurrentPage > 1)
            {
                sql += " AND OD.id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " OD.id FROM orders AS O inner JOIN order_details AS OD ON O.id = OD.order_id WHERE O.is_delete = 0 AND OD.is_delete = 0 " + sqlParam + " ORDER BY OD.id DESC) AS R) ";
            }
            sql += " ORDER BY OD.id DESC; SELECT COUNT(*) FROM orders AS O INNER JOIN order_details AS OD ON O.id = OD.order_id WHERE O.is_delete = 0 AND OD.is_delete = 0 " + sqlParam;
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    SearchOrder so = new SearchOrder();
                    so.Id = dr.GetInt32(0);
                    so.CreateTime = dr.GetDateTime(1);
                    so.Encode = dr.GetString(2);                    
                    Client client = new ClientDAL().GetClientById(dr.GetInt32(3));
                    so.Client = client;
                    if(!dr.IsDBNull(4))
                    {
                        so.CarrierEncode = dr.GetString(4);
                    }
                    if (!dr.IsDBNull(5))
                    {
                        so.ToCountry = dr.GetString(5);
                    }
                    if (!dr.IsDBNull(6))
                    {
                        so.ToUsername = dr.GetString(6);
                    }
                    if (!dr.IsDBNull(7))
                    {
                        so.BarCode = dr.GetString(7);
                    }
                    so.OrderDetailId = dr.GetInt32(8);
                    so.Status = EnumConvertor.ConvertToOrderStatus(dr.GetByte(9));
                    result.Results.Add(so);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public List<SearchOrder> GetReceiveOrderStatistic(DateTime startDate, DateTime endDate, int companyId, int clientId, string carrierEncode, int userId)
        {
            List<SearchOrder> result = new List<SearchOrder>();

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
            else if(startDate<= minTime && endDate > minTime)
            {
                sqlParam += " AND O.create_time <= @end_date";
            }       

            if(companyId>0)
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
            if(!string.IsNullOrEmpty(carrierEncode))
            {
                sqlParam += " AND OD.carrier_encode = @carrier_encode";
            }

            string sql = "SELECT O.client_id, SUM(OD.weight) AS weight, SUM(count) AS conunt, SUM(total_costs) AS costs FROM orders AS O INNER JOIN order_details AS OD ON O.id = OD.order_id WHERE O.is_delete = 0 AND OD.is_delete = 0 AND O.status IN(4,5) "+sqlParam+" GROUP BY O.client_id";

            using(SqlDataReader dr=SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while(dr.Read())
                {
                    SearchOrder so=new SearchOrder();
                    Client client = new ClientDAL().GetClientById(dr.GetInt32(0));
                    so.Client = client;
                    so.TotalWeight=dr.GetDecimal(1);
                    so.TotalCount=dr.GetInt32(2);
                    so.TotalCost=dr.GetDecimal(3);
                    result.Add(so);
                }
            }
            return result;
        }

        public List<SearchOrderDetail> GetReceiveOrderDetailStatistic(DateTime startDate, DateTime endDate, int companyId, int clientId, string carrierEncode, int userId)
        {
            List<SearchOrderDetail> result = new List<SearchOrderDetail>();

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
            sqlParam += " ORDER BY O.id ASC";

            string sql = "SELECT O.encode, O.create_time, O.client_id, O.receive_date, OD.carrier_encode, OD.weight AS weight, OD.[count] AS conunt, OD.total_costs AS costs, OD.self_total_costs, OD.create_time, OD.bar_code, OD.to_country, OD.to_username, OD.remark FROM orders AS O INNER JOIN order_details AS OD ON O.id =  OD.order_id WHERE O.is_delete = 0 AND OD.is_delete = 0 AND O.status IN(4,5) " + sqlParam;

            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    SearchOrderDetail sod = new SearchOrderDetail();
                    sod.OrderEncode = dr.GetString(0);
                    sod.CreateTime = dr.GetDateTime(1);
                    Client client = new ClientDAL().GetClientById(dr.GetInt32(2));
                    sod.Client = client;
                    sod.OrderReceiveDate = dr.GetDateTime(3);
                    sod.CarrierEncode = dr.GetString(4);
                    sod.Weight = dr.GetDecimal(5);
                    sod.Count = dr.GetInt32(6);
                    sod.TotalCosts = dr.GetDecimal(7);
                    sod.SelfTotalCosts = dr.GetDecimal(8);
                    sod.CreateTime = dr.GetDateTime(9);
                    sod.BarCode = dr.GetString(10);
                    sod.ToCountry = dr.GetString(11);
                    sod.ToUsername = dr.GetString(12);
                    sod.Remark = dr.GetString(13);
                    
                    result.Add(sod);
                }
            }
            return result;
        }

        public List<SearchOrderDetail> GetEaduOrderDetailStatistic(DateTime startDate, DateTime endDate, int companyId, int clientId, string carrierEncode, int userId)
        {
            List<SearchOrderDetail> result = new List<SearchOrderDetail>();

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
            sqlParam += " ORDER BY OD.carrier_encode DESC,OD.post_status ASC";

            string sql = "SELECT O.encode, O.create_time, O.client_id, O.receive_date, OD.carrier_encode, OD.weight AS weight, OD.[count] AS conunt, OD.total_costs AS costs, OD.self_total_costs, OD.create_time, OD.bar_code, OD.to_country, OD.to_username, OD.remark, OD.last_disposal_time, OD.post_status, OD.tracking_time FROM orders AS O INNER JOIN order_details AS OD ON O.id =  OD.order_id WHERE O.is_delete = 0 AND OD.is_delete = 0 AND O.status IN(4,5) AND OD.carrier_encode IN('CNBJ','CNAM','ZJEMS','BRAM','SHCN') AND OD.bar_code NOT LIKE '%D%CN' AND LEN(OD.bar_code)=13" + sqlParam;

            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    SearchOrderDetail sod = new SearchOrderDetail();
                    sod.OrderEncode = dr.GetString(0);
                    sod.CreateTime = dr.GetDateTime(1);
                    Client client = new ClientDAL().GetClientById(dr.GetInt32(2));
                    sod.Client = client;
                    sod.OrderReceiveDate = dr.GetDateTime(3);
                    sod.CarrierEncode = dr.GetString(4);
                    sod.Weight = dr.GetDecimal(5);
                    sod.Count = dr.GetInt32(6);
                    sod.TotalCosts = dr.GetDecimal(7);
                    sod.SelfTotalCosts = dr.GetDecimal(8);
                    sod.CreateTime = dr.GetDateTime(9);
                    sod.BarCode = dr.GetString(10);
                    sod.ToCountry = dr.GetString(11);
                    sod.ToUsername = dr.GetString(12);
                    sod.Remark = dr.GetString(13);
                    if (!dr.IsDBNull(14))
                    {
                        sod.LastDisposalTime = dr.GetDateTime(14);
                    }
                    else
                    {
                        sod.LastDisposalTime = minTime;
                    }
                    if (!dr.IsDBNull(15))
                    {
                        sod.PostStatus = dr.GetString(15);
                    }
                    else
                    {
                        sod.PostStatus = "";

                    }
                    if (!dr.IsDBNull(16))
                    {
                        sod.TrackingTime = dr.GetDateTime(16);
                    }
                    else
                    {
                        sod.TrackingTime = minTime;
                    }

                    result.Add(sod);
                }
            }
            return result;
        }

        public List<SearchOrderDetail> GetFetchCostsStatistic(DateTime startDate, DateTime endDate, int companyId, int clientId, string carrierEncode, int userId)
        {
            List<SearchOrderDetail> result = new List<SearchOrderDetail>();

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

            string sql = "SELECT O.client_id, SUM(OD.fetch_costs), SUM(OD.disposal_costs), SUM(OD.material_costs), SUM(OD.other_costs) FROM orders AS O INNER JOIN order_details AS OD ON O.id = OD.order_id WHERE O.is_delete = 0 AND OD.is_delete = 0 AND O.status IN(4,5) AND OD.fetch_costs > 0 OR                 OD.disposal_costs > 0 OR OD.material_costs > 0 OR OD.other_costs > 0 " + sqlParam + " GROUP BY O.client_id";

            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    SearchOrderDetail sod = new SearchOrderDetail();
                    Client client = new ClientDAL().GetClientById(dr.GetInt32(0));
                    sod.Client = client;
                    sod.TotalFetchCosts = dr.GetDecimal(1);
                    sod.TotalDisposalCosts = dr.GetDecimal(2);
                    sod.TotalMaterialCosts = dr.GetDecimal(3);
                    sod.TotalOtherCosts = dr.GetDecimal(4);
                    result.Add(sod);
                }
            }
            return result;
        }

        public List<SearchOrderDetail> GetNotOnlineOrderDetail(DateTime startDate, int judgeDays, int companyId, int clientId, string carrierEncode)
        {
            List<SearchOrderDetail> result = new List<SearchOrderDetail>();

            DateTime judgeDate=startDate.AddDays(-judgeDays);
            DateTime judgeTime=new DateTime(judgeDate.Year, judgeDate.Month, judgeDate.Day, 23, 59, 59);
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputDateTimeParameter("@judge_time", judgeTime),                
                SqlUtilities.GenerateInputIntParameter("@client_id", clientId),
                SqlUtilities.GenerateInputIntParameter("@company_id", companyId),
                SqlUtilities.GenerateInputNVarcharParameter("@carrier_encode", 50, carrierEncode)
            };

            string sqlParam = "";

            sqlParam += " AND O.audit_time <= @judge_time";
            if (companyId > 0)
            {
                sqlParam += " AND O.company_id = @company_id";
            }
            if (clientId > 0)
            {
                sqlParam += " AND O.client_id = @client_id";
            }
            if (!string.IsNullOrEmpty(carrierEncode))
            {
                sqlParam += " AND OD.carrier_encode = @carrier_encode";
            }

            string sql = "SELECT O.encode, O.create_time, O.client_id, O.receive_date, OD.carrier_encode, OD.weight AS weight, OD.[count] AS conunt, OD.total_costs AS costs, OD.self_total_costs, OD.create_time, OD.bar_code, OD.to_country, OD.to_username, OD.remark FROM orders AS O INNER JOIN order_details AS OD ON O.id =  OD.order_id WHERE O.is_delete = 0 AND OD.is_delete = 0 AND OD.bar_code LIKE 'RA%' AND OD.is_tracking = 0 " + sqlParam;

            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    SearchOrderDetail sod = new SearchOrderDetail();
                    sod.OrderEncode = dr.GetString(0);
                    sod.CreateTime = dr.GetDateTime(1);
                    Client client = new ClientDAL().GetClientById(dr.GetInt32(2));
                    sod.Client = client;
                    sod.OrderReceiveDate = dr.GetDateTime(3);
                    sod.CarrierEncode = dr.GetString(4);
                    sod.Weight = dr.GetDecimal(5);
                    sod.Count = dr.GetInt32(6);
                    sod.TotalCosts = dr.GetDecimal(7);
                    sod.SelfTotalCosts = dr.GetDecimal(8);
                    sod.CreateTime = dr.GetDateTime(9);
                    sod.BarCode = dr.GetString(10);
                    sod.ToCountry = dr.GetString(11);
                    sod.ToUsername = dr.GetString(12);
                    sod.Remark = dr.GetString(13);

                    result.Add(sod);
                }
            }
            return result;
        }
    }
}
