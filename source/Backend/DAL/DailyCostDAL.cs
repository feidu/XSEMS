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
    public class DailyCostDAL
    {
        public void CreateDailyCost(DailyCost dc)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@user_id", dc.UserId),
                SqlUtilities.GenerateInputIntParameter("@company_id", dc.CompanyId),
                SqlUtilities.GenerateInputIntParameter("@order_user_id", dc.OrderUserId),
                SqlUtilities.GenerateInputDateTimeParameter("@order_time", dc.OrderTime),
                SqlUtilities.GenerateInputDateTimeParameter("@create_time", dc.CreateTime),
                SqlUtilities.GenerateInputNVarcharParameter("@encode", 50, dc.Encode),
                SqlUtilities.GenerateInputParameter("@money", SqlDbType.Decimal, dc.Money),
                SqlUtilities.GenerateInputIntParameter("@cost_type_id", dc.CostTypeId),
                SqlUtilities.GenerateInputNVarcharParameter("@remark", 500, dc.Remark)
            };

            string sql = "INSERT INTO daily_costs(user_id, company_id, order_user_id, order_time, create_time, encode, money, cost_type_id, remark) VALUES(@user_id, @company_id, @order_user_id, @order_time, @create_time, @encode, @money, @cost_type_id, @remark)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void DeleteDailyCostById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "UPDATE daily_costs SET is_delete = 1 WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public DailyCost GetDailyCostById(int id)
        {
            DailyCost dc = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "SELECT  id, user_id, company_id, audit_user_id, order_user_id, order_time, create_time, audit_time, encode, money, cost_type_id, remark FROM daily_costs WHERE id = @id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    dc = new DailyCost();
                    dc.Id = dr.GetInt32(0);
                    dc.UserId = dr.GetInt32(1);
                    User user = UserOperation.GetUserById(dc.UserId);
                    dc.Username = user.RealName;
                    dc.DepartmentName = DepartmentOperation.GetDepartmentById(user.DepartmentId).Name;
                    dc.CompanyId = dr.GetInt32(2);
                    Company company = CompanyOperation.GetCompanyById(dc.CompanyId);
                    dc.CompanyName = company.Name;
                    if (!dr.IsDBNull(3))
                    {
                        dc.AuditUserId = dr.GetInt32(3);
                    }
                    dc.OrderUserId = dr.GetInt32(4);
                    user = UserOperation.GetUserById(dc.OrderUserId);
                    dc.OrderUserName = user.RealName;
                    dc.OrderTime = dr.GetDateTime(5);
                    dc.CreateTime = dr.GetDateTime(6);
                    if (!dr.IsDBNull(7))
                    {
                        dc.AuditTime = dr.GetDateTime(7);
                    }
                    dc.Encode = dr.GetString(8);
                    dc.Money = dr.GetDecimal(9);
                    dc.CostTypeId = dr.GetInt32(10);
                    CostType ct = CostTypeOperation.GetCostTypeById(dc.CostTypeId);
                    dc.CostType = ct.Name;
                    dc.Remark = dr.GetString(11);
                }
            }
            return dc;
        }

        public PaginationQueryResult<DailyCost> GetDailyCostByCompanyId(PaginationQueryCondition condition, int compId)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@company_id", compId)
            };
            PaginationQueryResult<DailyCost> result = new PaginationQueryResult<DailyCost>();
            string sql = "SELECT TOP " + condition.PageSize + " id, user_id, company_id, audit_user_id, order_user_id, order_time, create_time, audit_time, encode, money, cost_type_id, remark FROM daily_costs WHERE is_delete = 0 AND company_id = @company_id";
            if (condition.CurrentPage > 1)
            {
                sql += " AND id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM daily_costs WHERE is_delete = 0 AND company_id = @company_id ORDER BY id DESC) AS R )";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM daily_costs WHERE is_delete = 0 AND company_id = @company_id ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    DailyCost dc = new DailyCost();
                    dc.Id = dr.GetInt32(0);
                    dc.UserId = dr.GetInt32(1);
                    User user = UserOperation.GetUserById(dc.UserId);
                    dc.Username = user.RealName;
                    dc.DepartmentName = DepartmentOperation.GetDepartmentById(user.DepartmentId).Name;
                    dc.CompanyId = dr.GetInt32(2);
                    Company company = CompanyOperation.GetCompanyById(dc.CompanyId);
                    dc.CompanyName = company.Name;
                    if (!dr.IsDBNull(3))
                    {
                        dc.AuditUserId = dr.GetInt32(3);
                    }
                    dc.OrderUserId = dr.GetInt32(4);
                    user = UserOperation.GetUserById(dc.OrderUserId);
                    dc.OrderUserName = user.RealName;
                    dc.OrderTime = dr.GetDateTime(5);
                    dc.CreateTime = dr.GetDateTime(6);
                    if (!dr.IsDBNull(7))
                    {
                        dc.AuditTime = dr.GetDateTime(7);
                    }
                    dc.Encode = dr.GetString(8);
                    dc.Money = dr.GetDecimal(9);
                    dc.CostTypeId = dr.GetInt32(10);
                    CostType ct = CostTypeOperation.GetCostTypeById(dc.CostTypeId);
                    dc.CostType = ct.Name;
                    dc.Remark = dr.GetString(11);
                    result.Results.Add(dc);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public PaginationQueryResult<DailyCost> GetDailyCostByCompanyIdAndDate(PaginationQueryCondition condition, int compId, DateTime startDate, DateTime endDate)
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
            PaginationQueryResult<DailyCost> result = new PaginationQueryResult<DailyCost>();
            string sql = "SELECT TOP " + condition.PageSize + " id, user_id, company_id, audit_user_id, order_user_id, order_time, create_time, audit_time, encode, money, cost_type_id, remark FROM daily_costs WHERE is_delete = 0 AND company_id = @company_id" + sqlTime;
            if (condition.CurrentPage > 1)
            {
                sql += " AND id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM daily_costs WHERE is_delete = 0 AND company_id = @company_id" + sqlTime + " ORDER BY id DESC) AS R )";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM daily_costs WHERE is_delete = 0 AND company_id = @company_id " + sqlTime;
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    DailyCost dc = new DailyCost();
                    dc.Id = dr.GetInt32(0);
                    dc.UserId = dr.GetInt32(1);
                    User user = UserOperation.GetUserById(dc.UserId);
                    dc.Username = user.RealName;
                    dc.DepartmentName = DepartmentOperation.GetDepartmentById(user.DepartmentId).Name;
                    dc.CompanyId = dr.GetInt32(2);
                    Company company = CompanyOperation.GetCompanyById(dc.CompanyId);
                    dc.CompanyName = company.Name;
                    if (!dr.IsDBNull(3))
                    {
                        dc.AuditUserId = dr.GetInt32(3);
                    }
                    dc.OrderUserId = dr.GetInt32(4);
                    user = UserOperation.GetUserById(dc.OrderUserId);
                    dc.OrderUserName = user.RealName;
                    dc.OrderTime = dr.GetDateTime(5);
                    dc.CreateTime = dr.GetDateTime(6);
                    if (!dr.IsDBNull(7))
                    {
                        dc.AuditTime = dr.GetDateTime(7);
                    }
                    dc.Encode = dr.GetString(8);
                    dc.Money = dr.GetDecimal(9);
                    dc.CostTypeId = dr.GetInt32(10);
                    CostType ct = CostTypeOperation.GetCostTypeById(dc.CostTypeId);
                    dc.CostType = ct.Name;
                    dc.Remark = dr.GetString(11);
                    result.Results.Add(dc);
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
