using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Backend.Models;
using Backend.Utilities;

namespace Backend.DAL
{
    public class DepartmentDAL
    {
        public void CreateDepartment(Department dept)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@name",50, dept.Name),
                SqlUtilities.GenerateInputIntParameter("@company_id", dept.CompanyId),
            };
            string sql = "INSERT INTO departments(name, company_id) VALUES(@name, @company_id)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdateDepartment(Department dept)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", dept.Id),
                SqlUtilities.GenerateInputNVarcharParameter("@name",50, dept.Name),
                SqlUtilities.GenerateInputIntParameter("@company_id", dept.CompanyId)
            };
            string sql = "UPDATE departments SET name =@name, company_id =@company_id WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void DeleteDepartmentById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id),
            };
            string sql = "DELETE FROM departments WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public Department GetDepartmentById(int id)
        {
            Department dept = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id),
            };
            string sql = "SELECT id, name, company_id FROM departments WHERE id = @id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    dept = new Department();
                    dept.Id = dr.GetInt32(0);
                    dept.Name = dr.GetString(1);
                    dept.CompanyId = dr.GetInt32(2);
                }
            }
            return dept;
        }

        public Department GetDepartmentByName(string name)
        {
            Department dept = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@name", 50, name),
            };
            string sql = "SELECT id, name, company_id FROM departments WHERE name = @name";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    dept = new Department();
                    dept.Id = dr.GetInt32(0);
                    dept.Name = dr.GetString(1);
                    dept.CompanyId = dr.GetInt32(2);
                }
            }
            return dept;
        }

        public List<Department> GetDepartmentByCompanyId(int compId)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@company_id", compId)
            };
            List<Department> result = new List<Department>();

            string sql = "SELECT id, name, company_id FROM departments WHERE company_id = @company_id ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    Department dept = new Department();
                    dept.Id = dr.GetInt32(0);
                    dept.Name = dr.GetString(1);
                    dept.CompanyId = dr.GetInt32(2);
                    result.Add(dept);
                }
            }
            return result;
        }
       
    }
}
