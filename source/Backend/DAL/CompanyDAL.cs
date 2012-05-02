using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Backend.Models;
using Backend.Models.Pagination;
using Backend.Utilities;
using Backend.Models.Admin;

namespace Backend.DAL
{
    public class CompanyDAL
    {
        public void CreateCompany(Company company)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@name",50, company.Name),
                SqlUtilities.GenerateInputParameter("@area_code", SqlDbType.TinyInt, (byte)company.AreaCode),
                SqlUtilities.GenerateInputNVarcharParameter("@address", 200, company.Address),
                SqlUtilities.GenerateInputNVarcharParameter("@contact_person", 50, company.ContactPerson),
                SqlUtilities.GenerateInputNVarcharParameter("@phone", 50, company.Phone),
                SqlUtilities.GenerateInputNVarcharParameter("@email", 50, company.Email),
                SqlUtilities.GenerateInputNVarcharParameter("@email_password", 50, company.EmailPassword),
                SqlUtilities.GenerateInputNVarcharParameter("@smtp", 50, company.Smtp),
                SqlUtilities.GenerateInputParameter("@commission", SqlDbType.Decimal, company.Commission),
                SqlUtilities.GenerateInputNVarcharParameter("@qq", 50, company.QQ),
                SqlUtilities.GenerateInputNVarcharParameter("@msn", 50, company.MSN)
            };
            string sql = "INSERT INTO companies(name, area_code, address, contact_person, phone, email, email_password, smtp, commission, qq, msn) VALUES( @name, @area_code, @address, @contact_person, @phone, @email, @email_password, @smtp, @commission, @qq, @msn)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdateCompany(Company company)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", company.Id),
                SqlUtilities.GenerateInputNVarcharParameter("@name",50, company.Name),
                SqlUtilities.GenerateInputParameter("@area_code", SqlDbType.TinyInt, (byte)company.AreaCode),
                SqlUtilities.GenerateInputNVarcharParameter("@address", 200, company.Address),
                SqlUtilities.GenerateInputNVarcharParameter("@contact_person", 50, company.ContactPerson),
                SqlUtilities.GenerateInputNVarcharParameter("@phone", 50, company.Phone),
                SqlUtilities.GenerateInputNVarcharParameter("@email", 50, company.Email),
                SqlUtilities.GenerateInputNVarcharParameter("@email_password", 50, company.EmailPassword),
                SqlUtilities.GenerateInputNVarcharParameter("@smtp", 50, company.Smtp),
                SqlUtilities.GenerateInputParameter("@commission", SqlDbType.Decimal, company.Commission),
                SqlUtilities.GenerateInputNVarcharParameter("@qq", 50, company.QQ),
                SqlUtilities.GenerateInputNVarcharParameter("@msn", 50, company.MSN)
            };
            string sql = "UPDATE companies SET name =@name, area_code =@area_code, address =@address, contact_person =@contact_person, phone =@phone, email =@email, email_password = @email_password, smtp =@smtp, commission =@commission, qq = @qq, msn = @msn WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void DeleteCompanyById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id),
            };
            string sql = "UPDATE companies SET is_delete = 1 WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public Company GetCompanyById(int id)
        {
            Company company = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id),
            };
            string sql = "SELECT id, name, area_code, address, contact_person, phone, email, smtp, commission, email_password, qq, msn FROM companies WHERE id = @id;";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    company = new Company();
                    company.Id = dr.GetInt32(0);
                    company.Name = dr.GetString(1);
                    company.AreaCode =EnumConvertor.ConvertToAreaCode(dr.GetByte(2));
                    company.Address = dr.GetString(3);
                    company.ContactPerson = dr.GetString(4);
                    company.Phone = dr.GetString(5);
                    company.Email = dr.GetString(6);
                    company.Smtp = dr.GetString(7);
                    company.Commission = dr.GetDecimal(8);
                    company.EmailPassword = dr.GetString(9);
                    company.QQ = dr.GetString(10);
                    company.MSN = dr.GetString(11);
                }              
            }
            return company;
        }

        public Company GetCompanyByName(string name)
        {
            Company company = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@name", 50, name),
            };
            string sql = "SELECT id, name, area_code, address, contact_person, phone, email, smtp, commission, email_password, qq, msn FROM companies WHERE name = @name";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    company = new Company();
                    company.Id = dr.GetInt32(0);
                    company.Name = dr.GetString(1);
                    company.AreaCode =EnumConvertor.ConvertToAreaCode(dr.GetByte(2));
                    company.Address = dr.GetString(3);
                    company.ContactPerson = dr.GetString(4);
                    company.Phone = dr.GetString(5);
                    company.Email = dr.GetString(6);
                    company.Smtp = dr.GetString(7);
                    company.Commission = dr.GetDecimal(8);
                    company.EmailPassword = dr.GetString(9);
                    company.QQ = dr.GetString(10);
                    company.MSN = dr.GetString(11);
                }
            }
            return company;
        }

        public List<Company> GetCompany()
        {
            List<Company> result = new List<Company>();

            string sql = "SELECT id, name, area_code, address, contact_person, phone, email, smtp, commission, email_password, qq, msn FROM companies WHERE is_delete = 0 ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    Company company = new Company();
                    company.Id = dr.GetInt32(0);
                    company.Name = dr.GetString(1);
                    company.AreaCode =EnumConvertor.ConvertToAreaCode(dr.GetByte(2));
                    company.Address = dr.GetString(3);
                    company.ContactPerson = dr.GetString(4);
                    company.Phone = dr.GetString(5);
                    company.Email = dr.GetString(6);
                    company.Smtp = dr.GetString(7);
                    company.Commission = dr.GetDecimal(8);
                    company.EmailPassword = dr.GetString(9);
                    company.QQ = dr.GetString(10);
                    company.MSN = dr.GetString(11);
                    result.Add(company);
                }
            }
            return result;
        }

        public PaginationQueryResult<Company> GetCompany(PaginationQueryCondition condition)
        {
            PaginationQueryResult<Company> result=new PaginationQueryResult<Company>();

            string sql = "SELECT TOP " + condition.PageSize + " id, name, area_code, address, contact_person, phone, email, smtp, commission, email_password, qq, msn FROM companies WHERE id_delete = 0";
            if (condition.CurrentPage > 1)
            {
                sql += " AND id<(SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM companies WHERE is_delete = 0 ORDER BY id DESC) AS D)";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM companies WHERE id_delete = 0";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    Company company = new Company();
                    company.Id = dr.GetInt32(0);
                    company.Name = dr.GetString(1);
                    company.AreaCode = EnumConvertor.ConvertToAreaCode(dr.GetByte(2));
                    company.Address = dr.GetString(3);
                    company.ContactPerson = dr.GetString(4);
                    company.Phone = dr.GetString(5);
                    company.Email = dr.GetString(6);
                    company.Smtp = dr.GetString(7);
                    company.Commission = dr.GetDecimal(8);
                    company.EmailPassword = dr.GetString(9);
                    company.QQ = dr.GetString(10);
                    company.MSN = dr.GetString(11);
                    result.Results.Add(company);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public void UpdateCompanyAuthorization(int compId, List<ModuleAuthorization> mas)
        {
            SqlConnection conn = SqlHelper.OpenNewConnection();
            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);
            //delete
            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, "DELETE FROM company_authorizations WHERE company_id = " + compId, null);
            //insert
            foreach (ModuleAuthorization ma in mas)
            {
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, "INSERT INTO company_authorizations (company_id, module_id, accessible, writable) VALUES ("
                    + compId + ", " + ma.ModuleId + ", " + (ma.Accessible == true ? 1 : 0) + ", " + (ma.Writable == true ? 1 : 0) + ")", null);
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

        public string GetCompanyRuleAuthorizationModuleIds(int companyId)
        {
            string ids = "";
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@company_id", companyId)
            };
            string sql = "SELECT module_id FROM company_authorizations Where company_id = @company_id AND accessible = 1";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    ids += dr.GetInt32(0).ToString()+",";
                }
            }
            return ids;
        }
    }

}
