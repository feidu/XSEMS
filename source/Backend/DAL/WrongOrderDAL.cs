using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Backend.Utilities;
using Backend.Models;
using System.Data;
using Backend.Models.Pagination;

namespace Backend.DAL
{
    public class WrongOrderDAL
    {
        public void CreateWrongOrder(WrongOrder wo)
        {
            SqlParameter[] param = new SqlParameter[] { 
                    SqlUtilities.GenerateInputIntParameter("@order_id", wo.Order.Id),
                    SqlUtilities.GenerateInputIntParameter("@company_id", wo.CompanyId),
                    SqlUtilities.GenerateInputNVarcharParameter("@company_name", 50, wo.CompanyName),
                    SqlUtilities.GenerateInputNVarcharParameter("@encode", 50,wo.Encode),
                    SqlUtilities.GenerateInputParameter("@status", SqlDbType.TinyInt, (byte)wo.Status),
                    SqlUtilities.GenerateInputNVarcharParameter("@reason", 500, wo.Reason),
                    SqlUtilities.GenerateInputNVarcharParameter("@type", 50, wo.Type),
                    SqlUtilities.GenerateInputDateTimeParameter("@create_time",wo.CreateTime),
                    SqlUtilities.GenerateInputDateTimeParameter("@last_update_time",wo.LastUpdateCreateTime),
                    SqlUtilities.GenerateInputIntParameter("@create_user_id", wo.CreateUserId)
            };
                string sql = "INSERT INTO wrong_orders(order_id, company_id, company_name, encode, status, reason, type, create_time, create_user_id, last_update_time) VALUES(@order_id, @company_id, @company_name, @encode, @status,  @reason, @type, @create_time, @create_user_id, @last_update_time)";
            
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdateWrongOrder(WrongOrder wo)
        {
            SqlParameter[] param = null;
            string sql = "";
            if (wo.Order != null)
            {
                param = new SqlParameter[] { 
                    SqlUtilities.GenerateInputIntParameter("@id", wo.Id),
                    SqlUtilities.GenerateInputIntParameter("@order_id", wo.Order.Id),
                    SqlUtilities.GenerateInputParameter("@status", SqlDbType.TinyInt, (byte)wo.Status),
                    SqlUtilities.GenerateInputNVarcharParameter("@reason", 500, wo.Reason),
                    SqlUtilities.GenerateInputDateTimeParameter("@last_update_time",wo.LastUpdateCreateTime),
                    SqlUtilities.GenerateInputNVarcharParameter("@type", 50, wo.Type)
            };
                sql = "UPDATE wrong_orders SET order_id = @order_id, status = @status, reason = @reason, type = @type, last_update_time = @last_update_time WHERE id = @id";
            }
            else
            {
                param = new SqlParameter[] { 
                    SqlUtilities.GenerateInputIntParameter("@id", wo.Id),
                    SqlUtilities.GenerateInputParameter("@status", SqlDbType.TinyInt, (byte)wo.Status),
                    SqlUtilities.GenerateInputNVarcharParameter("@reason", 500, wo.Reason),
                    SqlUtilities.GenerateInputDateTimeParameter("@last_update_time",wo.LastUpdateCreateTime),
                    SqlUtilities.GenerateInputNVarcharParameter("@type", 50, wo.Type)
            };
                sql = "UPDATE wrong_orders SET status = @status, reason = @reason, type = @type, last_update_time = @last_update_time WHERE id = @id";
            }
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void DeleteWrongOrderById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "UPDATE wrong_orders SET is_delete = 1 WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public WrongOrder GetWrongOrderById(int id)
        {
            WrongOrder wo = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "SELECT id, order_id, company_id, company_name, encode, status, reason, type, create_time, create_user_id, last_update_time FROM wrong_orders WHERE id = @id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    wo = new WrongOrder();
                    wo.Id = dr.GetInt32(0);
                    if (!dr.IsDBNull(1))
                    {
                        Order order = new OrderDAL().GetOrderById(dr.GetInt32(1));
                        wo.Order = order;
                    }
                    wo.CompanyId = dr.GetInt32(2);
                    wo.CompanyName = dr.GetString(3);
                    wo.Encode = dr.GetString(4);
                    wo.Status = EnumConvertor.ConvertToWrongOrderStatus(dr.GetByte(5));
                    wo.Reason = dr.GetString(6);
                    wo.Type = dr.GetString(7);
                    wo.CreateTime = dr.GetDateTime(8);
                    wo.CreateUserId = dr.GetInt32(9);
                    wo.LastUpdateCreateTime = dr.GetDateTime(10);
                }
            }
            return wo;
        }

        public WrongOrder GetWrongOrderByEncode(string encode)
        {
            WrongOrder wo = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@encode", 50, encode)
            };
            string sql = "SELECT id, order_id, company_id, company_name, encode, status, reason, type, create_time, create_user_id, last_update_time FROM wrong_orders WHERE encode = @encode";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    wo = new WrongOrder();
                    wo.Id = dr.GetInt32(0);
                    if (!dr.IsDBNull(1))
                    {
                        Order order = new OrderDAL().GetOrderById(dr.GetInt32(1));
                        wo.Order = order;
                    }
                    wo.CompanyId = dr.GetInt32(2);
                    wo.CompanyName = dr.GetString(3);
                    wo.Encode = dr.GetString(4);
                    wo.Status = EnumConvertor.ConvertToWrongOrderStatus(dr.GetByte(5));
                    wo.Reason = dr.GetString(6);
                    wo.Type = dr.GetString(7);
                    wo.CreateTime = dr.GetDateTime(8);
                    wo.CreateUserId = dr.GetInt32(9);
                    wo.LastUpdateCreateTime = dr.GetDateTime(10);
                }
            }
            return wo;
        }

        public PaginationQueryResult<WrongOrder> GetWrongOrderByCompanyId(PaginationQueryCondition condition, int companyId)
        {
            PaginationQueryResult<WrongOrder> result = new PaginationQueryResult<WrongOrder>();
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@company_id", companyId)
            };
            string sql = "SELECT TOP " + condition.PageSize + " id, order_id, company_id, company_name, encode, status, reason, type, create_time, create_user_id, last_update_time FROM wrong_orders WHERE is_delete = 0 AND company_id = @company_id";
            if (condition.CurrentPage > 1)
            {
                sql += " AND id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM wrong_orders WHERE is_delete = 0 AND company_id = @company_id ORDER BY id DESC) AS W)";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM wrong_orders WHERE is_delete = 0 AND company_id = @company_id";

            using(SqlDataReader dr=SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    WrongOrder wo = new WrongOrder();
                    wo.Id = dr.GetInt32(0);
                    if (!dr.IsDBNull(1))
                    {
                        Order order = new OrderDAL().GetOrderById(dr.GetInt32(1));
                        wo.Order = order;
                    }
                    wo.CompanyId = dr.GetInt32(2);
                    wo.CompanyName = dr.GetString(3);
                    wo.Encode = dr.GetString(4);
                    wo.Status = EnumConvertor.ConvertToWrongOrderStatus(dr.GetByte(5));
                    wo.Reason = dr.GetString(6);
                    wo.Type = dr.GetString(7);
                    wo.CreateTime = dr.GetDateTime(8);
                    wo.CreateUserId = dr.GetInt32(9);
                    wo.LastUpdateCreateTime = dr.GetDateTime(10);
                    result.Results.Add(wo);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public PaginationQueryResult<WrongOrder> GetWrongOrderByClientId(PaginationQueryCondition condition, int clientId)
        {
            PaginationQueryResult<WrongOrder> result = new PaginationQueryResult<WrongOrder>();
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@client_id", clientId)
            };
            string sql = "SELECT TOP " + condition.PageSize + " WO.id, WO.order_id, WO.company_id, WO.company_name, WO.encode, WO.status, WO.reason, WO.[type], WO.create_time, WO.create_user_id, WO.last_update_time FROM wrong_orders AS WO INNER JOIN orders AS O ON WO.order_id = O.id WHERE            O.client_id = @client_id AND WO.is_delete = 0 AND O.is_delete = 0";
            if (condition.CurrentPage > 1)
            {
                sql += " AND WO.id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " WO.id FROM wrong_orders AS WO INNER JOIN orders AS O ON WO.order_id = O.id WHERE O.client_id = @client_id AND WO.is_delete = 0 AND O.is_delete = 0 ORDER BY WO.id DESC) AS W)";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM wrong_orders AS WO INNER JOIN orders AS O ON WO.order_id = O.id WHERE O.client_id =         @client_id AND WO.is_delete = 0 AND O.is_delete = 0";

            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    WrongOrder wo = new WrongOrder();
                    wo.Id = dr.GetInt32(0);
                    if (!dr.IsDBNull(1))
                    {
                        Order order = new OrderDAL().GetOrderById(dr.GetInt32(1));
                        wo.Order = order;
                    }
                    wo.CompanyId = dr.GetInt32(2);
                    wo.CompanyName = dr.GetString(3);
                    wo.Encode = dr.GetString(4);
                    wo.Status = EnumConvertor.ConvertToWrongOrderStatus(dr.GetByte(5));
                    wo.Reason = dr.GetString(6);
                    wo.Type = dr.GetString(7);
                    wo.CreateTime = dr.GetDateTime(8);
                    wo.CreateUserId = dr.GetInt32(9);
                    wo.LastUpdateCreateTime = dr.GetDateTime(10);
                    result.Results.Add(wo);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public PaginationQueryResult<WrongOrder> GetWrongOrderByClientIdAndDate(PaginationQueryCondition condition, int clientId, DateTime startDate, DateTime endDate)
        {
            PaginationQueryResult<WrongOrder> result = new PaginationQueryResult<WrongOrder>();
            DateTime minTime = new DateTime(1999, 1, 1);
            string sqlTime = "";
            if (startDate > minTime && endDate > minTime)
            {
                sqlTime = " AND WO.create_time BETWEEN @start_date AND @end_date";
            }
            else if (startDate > minTime && endDate <= minTime)
            {
                sqlTime = " AND WO.create_time >= @start_date ";
            }
            else
            {
                sqlTime = " AND WO.create_time <= @end_date";
            }
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@client_id", clientId),
                SqlUtilities.GenerateInputDateTimeParameter("@start_date", startDate),
                SqlUtilities.GenerateInputDateTimeParameter("@end_date", endDate)
            };
            string sql = "SELECT TOP " + condition.PageSize + " WO.id, WO.order_id, WO.company_id, WO.company_name, WO.encode, WO.status, WO.reason, WO.[type], WO.create_time, WO.create_user_id, WO.last_update_time FROM wrong_orders AS WO INNER JOIN orders AS O ON WO.order_id = O.id WHERE            O.client_id = @client_id AND WO.is_delete = 0 AND O.is_delete = 0"+sqlTime;
            if (condition.CurrentPage > 1)
            {
                sql += " AND WO.id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " WO.id FROM wrong_orders AS WO INNER JOIN orders AS O ON WO.order_id = O.id WHERE O.client_id = @client_id AND WO.is_delete = 0 AND O.is_delete = 0 "+sqlTime+" ORDER BY    WO.id DESC) AS W)";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM wrong_orders AS WO INNER JOIN orders AS O ON WO.order_id = O.id WHERE O.client_id =         @client_id AND WO.is_delete = 0 AND O.is_delete = 0"+sqlTime;

            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    WrongOrder wo = new WrongOrder();
                    wo.Id = dr.GetInt32(0);
                    if (!dr.IsDBNull(1))
                    {
                        Order order = new OrderDAL().GetOrderById(dr.GetInt32(1));
                        wo.Order = order;
                    }
                    wo.CompanyId = dr.GetInt32(2);
                    wo.CompanyName = dr.GetString(3);
                    wo.Encode = dr.GetString(4);
                    wo.Status = EnumConvertor.ConvertToWrongOrderStatus(dr.GetByte(5));
                    wo.Reason = dr.GetString(6);
                    wo.Type = dr.GetString(7);
                    wo.CreateTime = dr.GetDateTime(8);
                    wo.CreateUserId = dr.GetInt32(9);
                    wo.LastUpdateCreateTime = dr.GetDateTime(10);
                    result.Results.Add(wo);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public PaginationQueryResult<WrongOrder> GetWrongOrderByCompanyIdAndDate(PaginationQueryCondition condition, int companyId, DateTime startDate, DateTime endDate)
        {
            PaginationQueryResult<WrongOrder> result = new PaginationQueryResult<WrongOrder>();
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
                SqlUtilities.GenerateInputIntParameter("@company_id", companyId),
                SqlUtilities.GenerateInputDateTimeParameter("@start_date", startDate),
                SqlUtilities.GenerateInputDateTimeParameter("@end_date", endDate)
            };
            string sql = "SELECT TOP " + condition.PageSize + " id, order_id, company_id, company_name, encode, status, reason, type, create_time, create_user_id, last_update_time FROM wrong_orders WHERE is_delete = 0 AND company_id = @company_id" + sqlTime;
            if (condition.CurrentPage > 1)
            {
                sql += " AND id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM wrong_orders WHERE is_delete = 0 AND company_id = @company_id "+sqlTime+" ORDER BY id DESC) AS W)";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM wrong_orders WHERE is_delete = 0 AND company_id = @company_id"+sqlTime;

            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    WrongOrder wo = new WrongOrder();
                    wo.Id = dr.GetInt32(0);
                    if (!dr.IsDBNull(1))
                    {
                        Order order = new OrderDAL().GetOrderById(dr.GetInt32(1));
                        wo.Order = order;
                    }
                    wo.CompanyId = dr.GetInt32(2);
                    wo.CompanyName = dr.GetString(3);
                    wo.Encode = dr.GetString(4);
                    wo.Status = EnumConvertor.ConvertToWrongOrderStatus(dr.GetByte(5));
                    wo.Reason = dr.GetString(6);
                    wo.Type = dr.GetString(7);
                    wo.CreateTime = dr.GetDateTime(8);
                    wo.CreateUserId = dr.GetInt32(9);
                    wo.LastUpdateCreateTime = dr.GetDateTime(10);
                    result.Results.Add(wo);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public void CreateWrongOrderDetail(WrongOrderDetail wod)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@wrong_order_id", wod.WrongOrderId),
                SqlUtilities.GenerateInputNVarcharParameter("@detail", 500, wod.Detail),
                SqlUtilities.GenerateInputDateTimeParameter("@create_time", wod.CreateTime),
                SqlUtilities.GenerateInputIntParameter("@create_user_id", wod.CreateUserId),
                SqlUtilities.GenerateInputNVarcharParameter("@result", 50, wod.Result)
            };
            string sql = "INSERT INTO wrong_order_details(wrong_order_id, detail, result, create_time, create_user_id) VALUES(@wrong_order_id, @detail, @result, @create_time, @create_user_id)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdateWrongOrderDetail(WrongOrderDetail wod)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("id", wod.Id),
                SqlUtilities.GenerateInputNVarcharParameter("@detail", 500, wod.Detail),
                SqlUtilities.GenerateInputNVarcharParameter("@result", 50, wod.Result)
            };
            string sql = "UPDATE wrong_order_details SET detail = @detail, result = @result WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void DeleteWrongOrderDetailById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = " UPDATE wrong_order_details SET is_delete = 1 WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public WrongOrderDetail GetWrongOrderDetailById(int id)
        {
            WrongOrderDetail wod = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = " SELECT id, wrong_order_id, detail, result, create_time, create_user_id FROM wrong_order_details WHERE id = @id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    wod = new WrongOrderDetail();
                    wod.Id = dr.GetInt32(0);
                    wod.WrongOrderId = dr.GetInt32(1);
                    wod.Detail = dr.GetString(2);
                    wod.Result = dr.GetString(3);
                    wod.CreateTime = dr.GetDateTime(4);
                    wod.CreateUserId = dr.GetInt32(5);
                }
            }
            return wod;
        }

        public List<WrongOrderDetail> GetWrongOrderDetailByWrongOrderId(int woId)
        {
            List<WrongOrderDetail> result = new List<WrongOrderDetail>();
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@wrong_order_id", woId)
            };
            string sql = "SELECT id, wrong_order_id, detail, result, create_time, create_user_id FROM wrong_order_details WHERE is_delete = 0 AND wrong_order_id = @wrong_order_id ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    WrongOrderDetail wod = new WrongOrderDetail();
                    wod.Id = dr.GetInt32(0);
                    wod.WrongOrderId = dr.GetInt32(1);
                    wod.Detail = dr.GetString(2);
                    wod.Result = dr.GetString(3);
                    wod.CreateTime = dr.GetDateTime(4);
                    wod.CreateUserId = dr.GetInt32(5);
                    result.Add(wod);
                }
            }
            return result;
        }
    }
}
