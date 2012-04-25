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
    public class PostPlanDAL
    {
        public void CreatePostPlan(PostPlan pp)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@carrier_id", pp.Carrier.Id),
                SqlUtilities.GenerateInputIntParameter("@company_id", pp.CompanyId),
                SqlUtilities.GenerateInputIntParameter("@package_count", pp.PackageCount),
                SqlUtilities.GenerateInputParameter("@weight", SqlDbType.Decimal, pp.Weight),
                SqlUtilities.GenerateInputIntParameter("@depot_id", pp.Depot.Id),
                SqlUtilities.GenerateInputIntParameter("@user_id", pp.User.Id),
                SqlUtilities.GenerateInputDateTimeParameter("@create_time", pp.CreateTime)
            };
            string sql = "INSERT INTO post_plans(carrier_id, company_id, package_count, weight, depot_id, user_id, create_time) VALUES(@carrier_id,         @company_id, @package_count, @weight, @depot_id, @user_id, @create_time)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdatePostPlan(PostPlan pp)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", pp.Id),
                SqlUtilities.GenerateInputIntParameter("@carrier_id", pp.Carrier.Id),
                SqlUtilities.GenerateInputIntParameter("@package_count", pp.PackageCount),
                SqlUtilities.GenerateInputParameter("@weight", SqlDbType.Decimal, pp.Weight),
                SqlUtilities.GenerateInputIntParameter("@depot_id", pp.Depot.Id),
                SqlUtilities.GenerateInputIntParameter("@user_id", pp.User.Id)
            };
            string sql = "UPDATE post_plans SET carrier_id = @carrier_id, package_count = @package_count, weight = @weight, depot_id = @depot_id, user_id = @user_id WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void DeletePostPlanById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "UPDATE post_plans SET is_delete = 1 WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public PostPlan GetPostPlanById(int id)
        {
            PostPlan pp = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "SELECT id, carrier_id, company_id, package_count, weight, depot_id, user_id, create_time FROM post_plans WHERE id = @id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    pp = new PostPlan();
                    pp.Id = dr.GetInt32(0);
                    Carrier carrier = new CarrierDAL().GetCarrierById(dr.GetInt32(1));
                    pp.Carrier = carrier;
                    pp.CompanyId = dr.GetInt32(2);
                    pp.PackageCount = dr.GetInt32(3);
                    pp.Weight = dr.GetDecimal(4);
                    Depot depot = new DepotDAL().GetDepotById(dr.GetInt32(5));
                    pp.Depot = depot;
                    User user = new UserDAL().GetUserById(dr.GetInt32(6));
                    pp.User = user;
                    pp.CreateTime = dr.GetDateTime(7);
                }
            }
            return pp;
        }

        public List<PostPlan> GetPostPlan()
        {
            List<PostPlan> result = new List<PostPlan>();
            string sql = "SELECT id, carrier_id, company_id, package_count, weight, depot_id, user_id, create_time FROM post_plans WHERE is_delete = 0";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    PostPlan pp = new PostPlan();
                    pp.Id = dr.GetInt32(0);
                    Carrier carrier = new CarrierDAL().GetCarrierById(dr.GetInt32(1));
                    pp.Carrier = carrier;
                    pp.CompanyId = dr.GetInt32(2);
                    pp.PackageCount = dr.GetInt32(3);
                    pp.Weight = dr.GetDecimal(4);
                    Depot depot = new DepotDAL().GetDepotById(dr.GetInt32(5));
                    pp.Depot = depot;
                    User user = new UserDAL().GetUserById(dr.GetInt32(6));
                    pp.User = user;
                    pp.CreateTime = dr.GetDateTime(7);
                    result.Add(pp);
                }
            }
            return result;
        }

        public PaginationQueryResult<PostPlan> GetPostPlanByCompanyId(PaginationQueryCondition condition, int compId)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@company_id", compId)
            };
            PaginationQueryResult<PostPlan> result = new PaginationQueryResult<PostPlan>();
            string sql = "SELECT TOP " + condition.PageSize + " id, carrier_id, company_id, package_count, weight, depot_id, user_id, create_time FROM post_plans WHERE company_id = @company_id AND is_delete = 0";
            if (condition.CurrentPage > 1)
            {
                sql += " AND id < (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize*(condition.CurrentPage - 1) + " id FROM post_plans WHERE company_id = @company_id AND is_delete = 0 ORDER BY id DESC) AS P)";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM post_plans WHERE company_id = @company_id AND is_delete = 0";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    PostPlan pp = new PostPlan();
                    pp.Id = dr.GetInt32(0);
                    Carrier carrier = new CarrierDAL().GetCarrierById(dr.GetInt32(1));
                    pp.Carrier = carrier;
                    pp.CompanyId = dr.GetInt32(2);
                    pp.PackageCount = dr.GetInt32(3);
                    pp.Weight = dr.GetDecimal(4);
                    Depot depot = new DepotDAL().GetDepotById(dr.GetInt32(5));
                    pp.Depot = depot;
                    User user = new UserDAL().GetUserById(dr.GetInt32(6));
                    pp.User = user;
                    pp.CreateTime = dr.GetDateTime(7);
                    result.Results.Add(pp);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public PaginationQueryResult<PostPlan> GetPostPlanByCompanyIdAndDate(PaginationQueryCondition condition, int compId, DateTime startDate, DateTime endDate)
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
            PaginationQueryResult<PostPlan> result = new PaginationQueryResult<PostPlan>();
            string sql = "SELECT TOP " + condition.PageSize + " id, carrier_id, company_id, package_count, weight, depot_id, user_id, create_time FROM post_plans WHERE company_id = @company_id AND is_delete = 0"+sqlTime;
            if (condition.CurrentPage > 1)
            {
                sql += " AND id < (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM post_plans WHERE company_id = @company_id AND is_delete = 0 "+sqlTime+" ORDER BY id DESC) AS P)";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM post_plans WHERE company_id = @company_id AND is_delete = 0 "+sqlTime;
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    PostPlan pp = new PostPlan();
                    pp.Id = dr.GetInt32(0);
                    Carrier carrier = new CarrierDAL().GetCarrierById(dr.GetInt32(1));
                    pp.Carrier = carrier;
                    pp.CompanyId = dr.GetInt32(2);
                    pp.PackageCount = dr.GetInt32(3);
                    pp.Weight = dr.GetDecimal(4);
                    Depot depot = new DepotDAL().GetDepotById(dr.GetInt32(5));
                    pp.Depot = depot;
                    User user = new UserDAL().GetUserById(dr.GetInt32(6));
                    pp.User = user;
                    pp.CreateTime = dr.GetDateTime(7);
                    result.Results.Add(pp);
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
