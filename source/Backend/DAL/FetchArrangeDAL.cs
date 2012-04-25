using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Backend.Models;
using Backend.Utilities;
using Backend.Models.Pagination;

namespace Backend.DAL
{
    public class FetchArrangeDAL
    {
        public void CreateFetchArrange(FetchArrange fa)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@client_id", fa.ClientId),
                SqlUtilities.GenerateInputIntParameter("@user_id", fa.UserId),
                SqlUtilities.GenerateInputIntParameter("@company_id", fa.CompanyId),
                SqlUtilities.GenerateInputParameter("@type", SqlDbType.TinyInt, (byte)fa.Type),
                SqlUtilities.GenerateInputNVarcharParameter("@address", 200, fa.Address),
                SqlUtilities.GenerateInputNVarcharParameter("@phone", 50, fa.Phone),
                SqlUtilities.GenerateInputDateTimeParameter("@fetch_time", fa.FetchTime),
                SqlUtilities.GenerateInputDateTimeParameter("@create_time", fa.CreateTime),
                SqlUtilities.GenerateInputNVarcharParameter("@remark", 500, fa.Remark)
            };
            string sql = "INSERT INTO fetch_arranges(client_id, user_id, company_id, type, address, phone, fetch_time, create_time, remark) VALUES(     @client_id, @user_id, @company_id, @type, @address, @phone, @fetch_time, @create_time, @remark)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdateFetchArrange(FetchArrange fa)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", fa.Id),
                SqlUtilities.GenerateInputNVarcharParameter("@address", 200, fa.Address),
                SqlUtilities.GenerateInputNVarcharParameter("@phone", 50, fa.Phone),
                SqlUtilities.GenerateInputDateTimeParameter("@fetch_time", fa.FetchTime),
                SqlUtilities.GenerateInputNVarcharParameter("@remark", 500, fa.Remark)
            };
            string sql = "UPDATE fetch_arranges SET address = @address, phone = @phone, fetch_time = @fetch_time, remark = @remark WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void DeleteFetchArrangeById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "UPDATE fetch_arranges SET is_delete = 1 WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public FetchArrange GetFetchArrangeById(int id)
        {
            FetchArrange fa = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "SELECT id, client_id, type, address, phone, fetch_time, create_time, company_id, remark, user_id FROM fetch_arranges WHERE id = @id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    fa = new FetchArrange();
                    fa.Id = dr.GetInt32(0);
                    fa.ClientId = dr.GetInt32(1);
                    fa.ClientName = new ClientDAL().GetClientById(fa.ClientId).RealName;
                    fa.Type = EnumConvertor.ConvertToOrderType(dr.GetByte(2));
                    fa.Address = dr.GetString(3);
                    fa.Phone = dr.GetString(4);
                    fa.FetchTime = dr.GetDateTime(5);
                    fa.CreateTime = dr.GetDateTime(6);
                    fa.CompanyId = dr.GetInt32(7);
                    fa.Remark = dr.GetString(8);
                    if (!dr.IsDBNull(9))
                    {
                        fa.UserId = dr.GetInt32(9);
                    }
                }
            }
            return fa;
        }        
 
        public PaginationQueryResult<FetchArrange> GetFetchArrangeByCompanyId(PaginationQueryCondition condition, int companyId)
        {
            PaginationQueryResult<FetchArrange> result = new PaginationQueryResult<FetchArrange>();
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@company_id", companyId)
            };
            string sql = "SELECT TOP " + condition.PageSize + " id, client_id, type, address, phone, fetch_time, create_time, company_id, remark, user_id FROM fetch_arranges WHERE company_id = @company_id AND is_delete = 0";
            if (condition.CurrentPage > 1)
            {
                sql += " AND id< (SELECT MIN(id) FROM(SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM fetch_arranges WHERE company_id = @company_id AND is_delete = 0 ORDER BY id DESC) AS F)";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM fetch_arranges WHERE company_id = @company_id AND is_delete = 0";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    FetchArrange fa = new FetchArrange();
                    fa.Id = dr.GetInt32(0);
                    fa.ClientId = dr.GetInt32(1);
                    fa.ClientName = new ClientDAL().GetClientById(fa.ClientId).RealName;
                    fa.Type = EnumConvertor.ConvertToOrderType(dr.GetByte(2));
                    fa.Address = dr.GetString(3);
                    fa.Phone = dr.GetString(4);
                    fa.FetchTime = dr.GetDateTime(5);
                    fa.CreateTime = dr.GetDateTime(6);
                    fa.CompanyId = dr.GetInt32(7);
                    fa.Remark = dr.GetString(8);
                    if (!dr.IsDBNull(9))
                    {
                        fa.UserId = dr.GetInt32(9);
                    }
                    result.Results.Add(fa);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
               
            }
            return result;
        }

        public PaginationQueryResult<FetchArrange> GetFetchArrangeByCompanyIdAndDate(PaginationQueryCondition condition, int companyId, DateTime startDate, DateTime endDate)
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
            PaginationQueryResult<FetchArrange> result = new PaginationQueryResult<FetchArrange>();
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@company_id", companyId),
                SqlUtilities.GenerateInputDateTimeParameter("@start_date", startDate),
                SqlUtilities.GenerateInputDateTimeParameter("@end_date", endDate)
            };
            string sql = "SELECT TOP " + condition.PageSize + " id, client_id, type, address, phone, fetch_time, create_time, company_id, remark, user_id FROM fetch_arranges WHERE company_id = @company_id AND is_delete = 0"+sqlTime;
            if (condition.CurrentPage > 1)
            {
                sql += " AND id< (SELECT MIN(id) FROM(SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM fetch_arranges WHERE company_id = @company_id AND is_delete = 0 "+sqlTime+" ORDER BY id DESC) AS F)";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM fetch_arranges WHERE company_id = @company_id AND is_delete = 0" + sqlTime;
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    FetchArrange fa = new FetchArrange();
                    fa.Id = dr.GetInt32(0);
                    fa.ClientId = dr.GetInt32(1);
                    fa.ClientName = new ClientDAL().GetClientById(fa.ClientId).RealName;
                    fa.Type = EnumConvertor.ConvertToOrderType(dr.GetByte(2));
                    fa.Address = dr.GetString(3);
                    fa.Phone = dr.GetString(4);
                    fa.FetchTime = dr.GetDateTime(5);
                    fa.CreateTime = dr.GetDateTime(6);
                    fa.CompanyId = dr.GetInt32(7);
                    fa.Remark = dr.GetString(8);
                    if (!dr.IsDBNull(9))
                    {
                        fa.UserId = dr.GetInt32(9);
                    }
                    result.Results.Add(fa);
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

