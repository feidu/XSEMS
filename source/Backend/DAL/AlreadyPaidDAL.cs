using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Backend.Models;
using Backend.Models.Pagination;
using Backend.Utilities;
using Backend.BAL;

namespace Backend.DAL
{
    public class AlreadyPaidDAL
    {
        public void CreateAlreadyPaid(AlreadyPaid ap)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@payment_method_id",ap.PaymentMethod.Id),
                SqlUtilities.GenerateInputNVarcharParameter("@invoice", 50, ap.Invoice),
                SqlUtilities.GenerateInputIntParameter("@carrier_id",ap.Carrier.Id),
                SqlUtilities.GenerateInputIntParameter("@user_id", ap.User.Id),
                SqlUtilities.GenerateInputIntParameter("@company_id", ap.CompanyId),
                SqlUtilities.GenerateInputDateTimeParameter("@create_time", ap.CreateTime),
                SqlUtilities.GenerateInputDateTimeParameter("@paid_time", ap.PaidTime),
                SqlUtilities.GenerateInputNVarcharParameter("@encode", 50, ap.Encode),
                SqlUtilities.GenerateInputParameter("@money", SqlDbType.Decimal, ap.Money),
                SqlUtilities.GenerateInputNVarcharParameter("@remark", 500, ap.Remark),
                SqlUtilities.GenerateInputDateTimeParameter("@start_time", ap.StartTime),
                SqlUtilities.GenerateInputDateTimeParameter("@end_time", ap.EndTime)
            };

            string sql = "INSERT INTO already_paid(payment_method_id, invoice, carrier_id, user_id, company_id, create_time, paid_time, encode, money, remark, start_time, end_time) VALUES(@payment_method_id, @invoice, @carrier_id, @user_id, @company_id, @create_time, @paid_time, @encode, @money,     @remark, @start_time, @end_time)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void DeleteAlreadyPaidById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "UPDATE already_paid SET is_delete = 1 WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public AlreadyPaid GetAlreadyPaidById(int id)
        {
            AlreadyPaid ap = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "SELECT  id, payment_method_id, invoice, carrier_id, user_id, company_id, create_time, paid_time, encode, money, remark, start_time, end_time FROM already_paid WHERE id = @id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    ap = new AlreadyPaid();
                    ap.Id = dr.GetInt32(0);
                    ap.PaymentMethod = PaymentMethodOperation.GetPaymentMethodById(dr.GetInt32(1));
                    ap.Invoice = dr.GetString(2);
                    ap.Carrier = CarrierOperation.GetCarrierById(dr.GetInt32(3));
                    ap.User = UserOperation.GetUserById(dr.GetInt32(4));
                    ap.CompanyId = dr.GetInt32(5);
                    ap.CreateTime = dr.GetDateTime(6);
                    ap.PaidTime = dr.GetDateTime(7);
                    ap.Encode = dr.GetString(8);
                    ap.Money = dr.GetDecimal(9);
                    ap.Remark = dr.GetString(10);
                    ap.StartTime = dr.GetDateTime(11);
                    ap.EndTime = dr.GetDateTime(12);
                }
            }
            return ap;
        }

        public PaginationQueryResult<AlreadyPaid> GetAlreadyPaidByCompanyId(PaginationQueryCondition condition, int compId)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@company_id", compId)
            };
            PaginationQueryResult<AlreadyPaid> result = new PaginationQueryResult<AlreadyPaid>();
            string sql = "SELECT TOP " + condition.PageSize + " id, payment_method_id, invoice, carrier_id, user_id, company_id, create_time, paid_time, encode, money, remark, start_time, end_time FROM already_paid WHERE is_delete = 0 AND company_id = @company_id";
            if (condition.CurrentPage > 1)
            {
                sql += " AND id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM already_paid WHERE is_delete = 0 AND company_id = @company_id ORDER BY id DESC) AS R )";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM already_paid WHERE is_delete = 0 AND company_id = @company_id ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    AlreadyPaid ap = new AlreadyPaid();
                    ap.Id = dr.GetInt32(0);
                    ap.PaymentMethod=PaymentMethodOperation.GetPaymentMethodById(dr.GetInt32(1));
                    ap.Invoice = dr.GetString(2);
                    ap.Carrier = CarrierOperation.GetCarrierById(dr.GetInt32(3));
                    ap.User = UserOperation.GetUserById(dr.GetInt32(4));
                    ap.CompanyId = dr.GetInt32(5);
                    ap.CreateTime = dr.GetDateTime(6);
                    ap.PaidTime = dr.GetDateTime(7);
                    ap.Encode = dr.GetString(8);
                    ap.Money = dr.GetDecimal(9);
                    ap.Remark = dr.GetString(10);
                    ap.StartTime = dr.GetDateTime(11);
                    ap.EndTime = dr.GetDateTime(12);
                    result.Results.Add(ap);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public PaginationQueryResult<AlreadyPaid> GetAlreadyPaidByCompanyIdAndDate(PaginationQueryCondition condition, int compId, DateTime startDate, DateTime endDate)
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
            PaginationQueryResult<AlreadyPaid> result = new PaginationQueryResult<AlreadyPaid>();
            string sql = "SELECT TOP " + condition.PageSize + " id, payment_method_id, invoice, carrier_id, user_id, company_id, create_time, paid_time, encode, money, remark, start_time, end_time FROM already_paid WHERE is_delete = 0 AND company_id = @company_id" + sqlTime;
            if (condition.CurrentPage > 1)
            {
                sql += " AND id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM already_paid WHERE is_delete = 0 AND company_id = @company_id" + sqlTime + " ORDER BY id DESC) AS R )";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM already_paid WHERE is_delete = 0 AND company_id = @company_id " + sqlTime;
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    AlreadyPaid ap = new AlreadyPaid();
                    ap.Id = dr.GetInt32(0);
                    ap.PaymentMethod = PaymentMethodOperation.GetPaymentMethodById(dr.GetInt32(1));
                    ap.Invoice = dr.GetString(2);
                    ap.Carrier = CarrierOperation.GetCarrierById(dr.GetInt32(3));
                    ap.User = UserOperation.GetUserById(dr.GetInt32(4));
                    ap.CompanyId = dr.GetInt32(5);
                    ap.CreateTime = dr.GetDateTime(6);
                    ap.PaidTime = dr.GetDateTime(7);
                    ap.Encode = dr.GetString(8);
                    ap.Money = dr.GetDecimal(9);
                    ap.Remark = dr.GetString(10);
                    ap.StartTime = dr.GetDateTime(11);
                    ap.EndTime = dr.GetDateTime(12);
                    result.Results.Add(ap);
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
