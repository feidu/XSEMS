using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Backend.Models;
using Backend.Authorization;
using Backend.Utilities;
using Backend.Models.Admin;
using Backend.Models.Pagination;

namespace Backend.DAL
{
    public class UserDAL
    {
        public void UpdateOperatorAuthorization(int operator_id, List<ModuleAuthorization> mas)
        {
            SqlConnection conn = SqlHelper.OpenNewConnection();
            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);
            //delete
            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, "DELETE FROM operator_authorizations WHERE operator_id = " + operator_id, null);
            //insert
            foreach (ModuleAuthorization ma in mas)
            {
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, "INSERT INTO operator_authorizations (operator_id, module_id, accessible, writable) VALUES ("
                    + operator_id + ", " + ma.ModuleId + ", " + (ma.Accessible == true ? 1 : 0) + ", " + (ma.Writable == true ? 1 : 0) + ")", null);
            }
            // commit transcation
            try
            {
                trans.Commit();
            }
            catch
            {
                if (trans != null)
                {
                    trans.Rollback();
                }
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }


        public PaginationQueryResult<User> GetLightUser(PaginationQueryCondition condition)
        {
            PaginationQueryResult<User> result = new PaginationQueryResult<User>();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT id, username, real_name, sex, education, mobile, email, join_date, contract_date, commission, company_id  FROM (SELECT id, username, real_name, sex, education, mobile, email, join_date, contract_date, commission, company_id, row_number() over (ORDER BY Id DESC) AS RN FROM users WHERE is_delete = 0) AS Result WHERE RN BETWEEN ");
            sb.Append((condition.CurrentPage - 1) * condition.PageSize + 1);
            sb.Append(" AND ");
            sb.Append(condition.CurrentPage * condition.PageSize);
            sb.Append(";SELECT COUNT(*) FROM users where is_delete = 0");
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sb.ToString(), null))
            {
                while (dr.Read())
                {
                    User user = new User();
                    user.Id = dr.GetInt32(0);
                    user.Username = dr.GetString(1);
                    user.RealName = dr.GetString(2);
                    user.Sex = dr.GetBoolean(3);
                    user.Education = dr.GetString(4);
                    user.Mobile = dr.GetString(5);
                    user.Email = dr.GetString(6);
                    user.JoinDate = dr.GetDateTime(7);
                    user.ContractDate = dr.GetDateTime(8);
                    user.Commission = dr.GetDecimal(9);
                    user.CompanyId = dr.GetInt32(10);
                    result.Results.Add(user);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public List<User> GetLightUser()
        {
            List<User> result = new List<User>();
            string sql = "SELECT id, username, real_name, sex, education, mobile, email, join_date, contract_date, commission, company_id  FROM users WHERE is_delete = 0 ORDER BY id DESC";

            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    User user = new User();
                    user.Id = dr.GetInt32(0);
                    user.Username = dr.GetString(1);
                    user.RealName = dr.GetString(2);
                    user.Sex = dr.GetBoolean(3);
                    user.Education = dr.GetString(4);
                    user.Mobile = dr.GetString(5);
                    user.Email = dr.GetString(6);
                    user.JoinDate = dr.GetDateTime(7);
                    user.ContractDate = dr.GetDateTime(8);
                    user.Commission = dr.GetDecimal(9);
                    user.CompanyId = dr.GetInt32(10);
                    result.Add(user);
                }
            }
            return result;
        }

        public PaginationQueryResult<User> GetLightUserByCompanyId(PaginationQueryCondition condition, int compId)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@company_id", compId)
            };
            PaginationQueryResult<User> result = new PaginationQueryResult<User>();
            string sql = "SELECT TOP " + condition.PageSize + " id, username, real_name, sex, education, mobile, email, join_date, contract_date, commission, company_id  FROM users WHERE is_delete = 0 AND company_id = @company_id";
            if (condition.CurrentPage > 1)
            {
                sql += " AND id< SELECT MIN(id) FROM(SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM users Where is_delete = 0 AND company_id = @company_id ORDER BY id DESC) AS D)";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM users WHERE is_delete = 0 AND company_id = @company_id ";
            
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    User user = new User();
                    user.Id = dr.GetInt32(0);
                    user.Username = dr.GetString(1);
                    user.RealName = dr.GetString(2);
                    user.Sex = dr.GetBoolean(3);
                    user.Education = dr.GetString(4);
                    user.Mobile = dr.GetString(5);
                    user.Email = dr.GetString(6);
                    user.JoinDate = dr.GetDateTime(7);
                    user.ContractDate = dr.GetDateTime(8);
                    user.Commission = dr.GetDecimal(9);
                    user.CompanyId = dr.GetInt32(10);               
                    result.Results.Add(user);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }
   
        public List<User> GetLightUserByCompanyId(int compId)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@company_id", compId)
            };
            List<User> result = new List<User>();
            string sql = "SELECT id, username, real_name, sex, education, mobile, email, join_date, contract_date, commission, company_id  FROM users WHERE is_delete = 0 AND company_id = @company_id ORDER BY id DESC";
           
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    User user = new User();
                    user.Id = dr.GetInt32(0);
                    user.Username = dr.GetString(1);
                    user.RealName = dr.GetString(2);
                    user.Sex = dr.GetBoolean(3);
                    user.Education = dr.GetString(4);
                    user.Mobile = dr.GetString(5);
                    user.Email = dr.GetString(6);
                    user.JoinDate = dr.GetDateTime(7);
                    user.ContractDate = dr.GetDateTime(8);
                    user.Commission = dr.GetDecimal(9);
                    user.CompanyId = dr.GetInt32(10);
                    result.Add(user);
                }                
            }
            return result;
        }

        public void CreateUser(User user)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputVarcharParameter("@username", 50, user.Username),
                SqlUtilities.GenerateInputVarcharParameter("@password", 50, user.Password),
                SqlUtilities.GenerateInputNVarcharParameter("@real_name", 50, user.RealName),
                SqlUtilities.GenerateInputNVarcharParameter("@id_card", 50, user.IdCard),
                SqlUtilities.GenerateInputNVarcharParameter("@phone", 50, user.Phone),
                SqlUtilities.GenerateInputNVarcharParameter("@mobile", 50, user.Mobile),
                SqlUtilities.GenerateInputNVarcharParameter("@email", 50, user.Email),
                SqlUtilities.GenerateInputNVarcharParameter("@address", 200, user.Address),
                SqlUtilities.GenerateInputNVarcharParameter("@nation", 50, user.Nation),
                SqlUtilities.GenerateInputIntParameter("@company_id", user.CompanyId),
                SqlUtilities.GenerateInputParameter("@sex", SqlDbType.Bit, user.Sex),
                SqlUtilities.GenerateInputParameter("@birthday", SqlDbType.SmallDateTime, user.Birthday),
                SqlUtilities.GenerateInputIntParameter("@department_id", user.DepartmentId),
                SqlUtilities.GenerateInputParameter("@position_id", SqlDbType.TinyInt, user.PositionId),
                SqlUtilities.GenerateInputNVarcharParameter("@marital_status", 50, user.MaritalStatus),
                SqlUtilities.GenerateInputParameter("@join_date", SqlDbType.SmallDateTime, user.JoinDate),
                SqlUtilities.GenerateInputParameter("@contract_date", SqlDbType.SmallDateTime, user.ContractDate),
                SqlUtilities.GenerateInputNVarcharParameter("@education", 50, user.Education),
                SqlUtilities.GenerateInputParameter("@commission", SqlDbType.Decimal, user.Commission),
                SqlUtilities.GenerateInputParameter("@create_date", SqlDbType.SmallDateTime, user.CreateDate)
            };
            string sql = "INSERT INTO users (username, password, real_name, id_card, phone, mobile, email, address, nation, company_id, sex, birthday, department_id, marital_status, join_date, contract_date, education, commission, create_date, position_id) VALUES (@username, @password, @real_name,       @id_card, @phone, @mobile, @email, @address, @nation, @company_id, @sex, @birthday, @department_id, @marital_status, @join_date, @contract_date,     @education, @commission, @create_date, @position_id)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdateUser(User user)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", user.Id),
                SqlUtilities.GenerateInputNVarcharParameter("@real_name", 50, user.RealName),
                SqlUtilities.GenerateInputIntParameter("@company_id", user.CompanyId),
                SqlUtilities.GenerateInputNVarcharParameter("@id_card", 50, user.IdCard),
                SqlUtilities.GenerateInputNVarcharParameter("@phone", 50, user.Phone),
                SqlUtilities.GenerateInputNVarcharParameter("@mobile", 50, user.Mobile),
                SqlUtilities.GenerateInputNVarcharParameter("@email", 50, user.Email),
                SqlUtilities.GenerateInputNVarcharParameter("@address", 200, user.Address),
                SqlUtilities.GenerateInputNVarcharParameter("@nation", 50, user.Nation),
                SqlUtilities.GenerateInputParameter("@sex", SqlDbType.Bit, user.Sex),
                SqlUtilities.GenerateInputParameter("@birthday", SqlDbType.SmallDateTime, user.Birthday),
                SqlUtilities.GenerateInputIntParameter("@department_id", user.DepartmentId),
                SqlUtilities.GenerateInputParameter("@position_id", SqlDbType.TinyInt, user.PositionId),
                SqlUtilities.GenerateInputNVarcharParameter("@marital_status", 50, user.MaritalStatus),
                SqlUtilities.GenerateInputParameter("@join_date", SqlDbType.SmallDateTime, user.JoinDate),
                SqlUtilities.GenerateInputParameter("@contract_date", SqlDbType.SmallDateTime, user.ContractDate),
                SqlUtilities.GenerateInputNVarcharParameter("@education", 50, user.Education),
                SqlUtilities.GenerateInputParameter("@commission", SqlDbType.Decimal, user.Commission)
            };
            string sql = "UPDATE USERS SET real_name = @real_name, id_card = @id_card, phone = @phone, mobile = @mobile, email = @email, address =      @address, nation = @nation, sex = @sex, birthday = @birthday, department_id = @department_id, position_id = @position_id, marital_status = @marital_status, join_date = @join_date, contract_date = @contract_date, education = @education, commission = @commission, company_id = @company_id WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void DeleteUserById(int id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                SqlUtilities.GenerateInputIntParameter("@id",id)
            };
            string sql = " UPDATE users SET is_delete = 1 WHERE id = @id  ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdateUserPassword(int id, string password)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id",id),
                SqlUtilities.GenerateInputVarcharParameter("@password",50,password)
            };
            string sql = " update users set password = @password WHERE id = @id ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

       
        public User GetUserByUsername(string username)
        {
            return GetUser("username = @username", SqlUtilities.GenerateInputVarcharParameter("@username", 50, username));
        }

        public User GetUserById(int id)
        {
            return GetUser("id = @id", SqlUtilities.GenerateInputIntParameter("@id", id));
        }

        private User GetUser(string condition, SqlParameter param)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT id, username, password, real_name, id_card, phone, mobile, email, address, nation, company_id, sex, birthday, department_id, marital_status, join_date, contract_date, education, commission, create_date, position_id FROM users WHERE ");
            sb.Append(condition);
            sb.Append(";SELECT OA.module_id, OA.accessible, OA.writable FROM operator_Authorizations AS OA, users AS O WHERE O.is_delete = 0 AND O.id = OA.operator_id and O.");
            sb.Append(condition);
            User user = null;
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sb.ToString(), new SqlParameter[] { param }))
            {
                while (dr.Read())
                {
                    user = new User();
                    user.Id = dr.GetInt32(0);
                    user.Username = dr.GetString(1);
                    user.Password = dr.GetString(2);
                    user.RealName = dr.GetString(3);
                    user.IdCard = dr.GetString(4);
                    user.Phone = dr.GetString(5);
                    user.Mobile = dr.GetString(6);
                    user.Email = dr.GetString(7);
                    user.Address = dr.GetString(8);
                    user.Nation = dr.GetString(9);
                    user.CompanyId = dr.GetInt32(10);
                    user.Sex = dr.GetBoolean(11);
                    user.Birthday = dr.GetDateTime(12);
                    user.DepartmentId = dr.GetInt32(13);
                    user.MaritalStatus = dr.GetString(14);
                    user.JoinDate = dr.GetDateTime(15);
                    user.ContractDate = dr.GetDateTime(16);
                    user.Education = dr.GetString(17);
                    user.Commission = dr.GetDecimal(18);
                    user.CreateDate = dr.GetDateTime(19);
                    user.PositionId = dr.GetByte(20);
                }
                if (user != null)
                {
                    dr.NextResult();
                    user.ModuleAuthorizations = new List<ModuleAuthorization>();
                    while (dr.Read())
                    {
                        ModuleAuthorization ma = new ModuleAuthorization();
                        ma.ModuleId = dr.GetInt32(0);
                        ma.Accessible = dr.GetBoolean(1);
                        ma.Writable = dr.GetBoolean(2);
                        user.ModuleAuthorizations.Add(ma);
                    }
                }
            }
            return user;
        }
    }
}
