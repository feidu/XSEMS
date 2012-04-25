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
    public class ShouldPayDAL
    {
        public void CreateShouldPay(ShouldPay sp)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@order_encode", 50, sp.OrderEncode),
                SqlUtilities.GenerateInputIntParameter("@order_detail_id", sp.OrderDetail.Id),
                SqlUtilities.GenerateInputIntParameter("@carrier_id", sp.Carrier.Id),
                SqlUtilities.GenerateInputNVarcharParameter("@type", 50, sp.Type),
                SqlUtilities.GenerateInputIntParameter("@user_id", sp.UserId),
                SqlUtilities.GenerateInputIntParameter("@company_id", sp.CompanyId),
                SqlUtilities.GenerateInputDateTimeParameter("@create_time", sp.CreateTime),
                SqlUtilities.GenerateInputNVarcharParameter("@encode", 50, sp.Encode)
            };

            string sql = "INSERT INTO should_pay(order_encode, order_detail_id, carrier_id, type, user_id, company_id, create_time, encode) VALUES(     @order_encode, @order_detail_id, @carrier_id, @type, @user_id, @company_id, @create_time, @encode)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public ShouldPay GetShouldPayById(int id)
        {
            ShouldPay sp = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "SELECT id, order_encode, order_detail_id, carrier_id, type, user_id, company_id, create_time, encode FROM should_pay WHERE id = @id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    sp = new ShouldPay();
                    sp.Id = dr.GetInt32(0);
                    sp.OrderEncode = dr.GetString(1);
                    sp.OrderDetail = new OrderDetailDAL().GetOrderDetailById(dr.GetInt32(2));
                    sp.Carrier = new CarrierDAL().GetCarrierById(dr.GetInt32(3));
                    sp.Type = dr.GetString(4);
                    sp.UserId = dr.GetInt32(5);
                    sp.CompanyId = dr.GetInt32(6);
                    sp.CreateTime = dr.GetDateTime(7);
                    sp.Encode = dr.GetString(8);
                }
            }
            return sp;
        }

        public void DeleteShouldPayById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "UPDATE should_pay SET is_delete = 1 WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdateShouldPayIsPaid(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "UPDATE should_pay SET is_paid = 1 WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void DeleteShouldPayByOrderDetailId(int orderDetailId)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@order_detail_id", orderDetailId)
            };
            string sql = "UPDATE should_pay SET is_delete = 1 WHERE order_detail_id = @order_detail_id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public PaginationQueryResult<ShouldPay> GetShouldPayByCompanyId(PaginationQueryCondition condition, int compId)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@company_id", compId)
            };
            PaginationQueryResult<ShouldPay> result = new PaginationQueryResult<ShouldPay>();
            string sql = "SELECT TOP " + condition.PageSize + " id, order_encode, order_detail_id, carrier_id, type, user_id, company_id, create_time, encode FROM should_pay WHERE is_delete = 0 AND is_paid = 0 AND company_id = @company_id";
            if (condition.CurrentPage > 1)
            {
                sql += " AND id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM should_pay ORDER BY id DESC) AS R )";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM should_pay WHERE is_delete = 0 AND company_id = @company_id ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    ShouldPay sp = new ShouldPay();
                    sp.Id = dr.GetInt32(0);
                    sp.OrderEncode = dr.GetString(1);
                    sp.OrderDetail = new OrderDetailDAL().GetOrderDetailById(dr.GetInt32(2));
                    sp.Carrier = new CarrierDAL().GetCarrierById(dr.GetInt32(3));
                    sp.Type = dr.GetString(4);
                    sp.UserId = dr.GetInt32(5);
                    sp.CompanyId = dr.GetInt32(6);
                    sp.CreateTime = dr.GetDateTime(7);
                    sp.Encode = dr.GetString(8);
                    result.Results.Add(sp);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public PaginationQueryResult<ShouldPay> GetShouldPayByParameters(PaginationQueryCondition condition, int compId, DateTime startDate, DateTime endDate, int carrierId)
        {
            DateTime minTime = new DateTime(1999, 1, 1);
            string sqlParam = "";
            if (startDate > minTime && endDate > minTime)
            {
                sqlParam += " AND create_time BETWEEN @start_date AND @end_date";
            }
            else if (startDate > minTime && endDate <= minTime)
            {
                sqlParam += " AND create_time >= @start_date ";
            }
            else if(startDate <= minTime && endDate > minTime)
            {
                sqlParam += " AND create_time <= @end_date";
            }
            if (carrierId > 0)
            {
                sqlParam += " AND carrier_id = @carrier_id";
            }
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@company_id", compId),
                SqlUtilities.GenerateInputDateTimeParameter("@start_date", startDate),
                SqlUtilities.GenerateInputDateTimeParameter("@end_date", endDate),
                SqlUtilities.GenerateInputIntParameter("@carrier_id", carrierId)
            };
            PaginationQueryResult<ShouldPay> result = new PaginationQueryResult<ShouldPay>();
            string sql = "SELECT TOP " + condition.PageSize + " id, order_encode, order_detail_id, carrier_id, type, user_id, company_id, create_time, encode FROM should_pay WHERE is_delete = 0 AND is_paid = 0 AND company_id = @company_id" + sqlParam;
            if (condition.CurrentPage > 1)
            {
                sql += " AND id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM should_pay WHERE is_delete = 0 AND is_paid = 0 AND company_id = @company_id" + sqlParam + " ORDER BY id DESC) AS R )";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM should_pay WHERE is_delete = 0 AND is_paid = 0 AND company_id = @company_id " + sqlParam;
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    ShouldPay sp = new ShouldPay();
                    sp.Id = dr.GetInt32(0);
                    sp.OrderEncode = dr.GetString(1);
                    sp.OrderDetail = new OrderDetailDAL().GetOrderDetailById(dr.GetInt32(2));
                    sp.Carrier = new CarrierDAL().GetCarrierById(dr.GetInt32(3));
                    sp.Type = dr.GetString(4);
                    sp.UserId = dr.GetInt32(5);
                    sp.CompanyId = dr.GetInt32(6);
                    sp.CreateTime = dr.GetDateTime(7);
                    sp.Encode = dr.GetString(8);
                    result.Results.Add(sp);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public List<ShouldPay> GetShouldPayByParameters(int compId, DateTime startDate, DateTime endDate, int carrierId)
        {
            DateTime minTime = new DateTime(1999, 1, 1);
            string sqlParam = "";
            if (startDate > minTime && endDate > minTime)
            {
                sqlParam += " AND create_time BETWEEN @start_date AND @end_date";
            }
            
            if (carrierId > 0)
            {
                sqlParam += " AND carrier_id = @carrier_id";
            }
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@company_id", compId),
                SqlUtilities.GenerateInputDateTimeParameter("@start_date", startDate),
                SqlUtilities.GenerateInputDateTimeParameter("@end_date", endDate),
                SqlUtilities.GenerateInputIntParameter("@carrier_id", carrierId)
            };

            List<ShouldPay> result = new List<ShouldPay>();
            string sql = "SELECT id, order_encode, order_detail_id, carrier_id, type, user_id, company_id, create_time, encode FROM should_pay WHERE is_delete = 0 AND is_paid = 0 AND company_id = @company_id" + sqlParam;            
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    ShouldPay sp = new ShouldPay();
                    sp.Id = dr.GetInt32(0);
                    sp.OrderEncode = dr.GetString(1);
                    sp.OrderDetail = new OrderDetailDAL().GetOrderDetailById(dr.GetInt32(2));
                    sp.Carrier = new CarrierDAL().GetCarrierById(dr.GetInt32(3));
                    sp.Type = dr.GetString(4);
                    sp.UserId = dr.GetInt32(5);
                    sp.CompanyId = dr.GetInt32(6);
                    sp.CreateTime = dr.GetDateTime(7);
                    sp.Encode = dr.GetString(8);
                    result.Add(sp);
                }                
            }
            return result;
        }
    }
}
