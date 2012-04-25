using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Backend.Models;
using Backend.Utilities;

namespace Backend.DAL
{
    public class DepotDAL
    {
        public void CreateDepot(Depot depot)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@name", 50, depot.Name),
                SqlUtilities.GenerateInputIntParameter("@company_id", depot.CompanyId),
                SqlUtilities.GenerateInputIntParameter("@department_id", depot.Department.Id),
                SqlUtilities.GenerateInputNVarcharParameter("@contact_person", 50, depot.ContactPerson),
                SqlUtilities.GenerateInputNVarcharParameter("@phone", 50, depot.Phone),
                SqlUtilities.GenerateInputNVarcharParameter("@fax", 50, depot.Fax),
                SqlUtilities.GenerateInputNVarcharParameter("@address", 200, depot.Address),
                SqlUtilities.GenerateInputParameter("@status", SqlDbType.Bit, depot.Status)                
            };
            string sql = "INSERT INTO depots(name, department_id, contact_person, phone, fax, address, status, company_id) VALUES(@name,                @department_id, @contact_person, @phone, @fax, @address, @status, @company_id)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdateDepot(Depot depot)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", depot.Id),
                SqlUtilities.GenerateInputIntParameter("@company_id", depot.CompanyId),
                SqlUtilities.GenerateInputNVarcharParameter("@name", 50, depot.Name),
                SqlUtilities.GenerateInputIntParameter("@department_id", depot.Department.Id),
                SqlUtilities.GenerateInputNVarcharParameter("@contact_person", 50, depot.ContactPerson),
                SqlUtilities.GenerateInputNVarcharParameter("@phone", 50, depot.Phone),
                SqlUtilities.GenerateInputNVarcharParameter("@fax", 50, depot.Fax),
                SqlUtilities.GenerateInputNVarcharParameter("@address", 200, depot.Address),
                SqlUtilities.GenerateInputParameter("@status", SqlDbType.Bit, depot.Status)    
            };
            string sql = "UPDATE depots SET name = @name, department_id = @department_id, contact_person = @contact_person, phone = @phone, fax =       @fax, address = @address, status, = @status, company_id = @company_id WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void DeleteDepotById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "UPDATE depots SET is_delete = 1 WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public Depot GetDepotById(int id)
        {
            Depot depot = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "SELECT id, name, department_id, contact_person, phone, fax, address, status, company_id FROM depots WHERE id = @id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    depot = new Depot();
                    depot.Id = dr.GetInt32(0);
                    depot.Name = dr.GetString(1);
                    Department depart = new DepartmentDAL().GetDepartmentById(dr.GetInt32(2));
                    depot.Department = depart;
                    depot.ContactPerson = dr.GetString(3);
                    depot.Phone = dr.GetString(4);
                    depot.Fax = dr.GetString(5);
                    depot.Address = dr.GetString(6);
                    depot.Status = dr.GetBoolean(7);
                    depot.CompanyId = dr.GetInt32(8);
                }
            }
            return depot;
        }

        public Depot GetDepotByName(string name)
        {
            Depot depot = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@name", 50, name)
            };
            string sql = "SELECT id, name, department_id, contact_person, phone, fax, address, status, company_id FROM depots WHERE name = @name AND is_delete = 0";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    depot = new Depot();
                    depot.Id = dr.GetInt32(0);
                    depot.Name = dr.GetString(1);
                    Department depart = new DepartmentDAL().GetDepartmentById(dr.GetInt32(2));
                    depot.Department = depart;
                    depot.ContactPerson = dr.GetString(3);
                    depot.Phone = dr.GetString(4);
                    depot.Fax = dr.GetString(5);
                    depot.Address = dr.GetString(6);
                    depot.Status = dr.GetBoolean(7);
                    depot.CompanyId = dr.GetInt32(8);
                }
            }
            return depot;
        }

        public List<Depot> GetDepot()
        {
            List<Depot> result = new List<Depot>();
            string sql = "SELECT id, name, department_id, contact_person, phone, fax, address, status, company_id FROM depots WHERE is_delete = 0";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    Depot depot = new Depot();
                    depot.Id = dr.GetInt32(0);
                    depot.Name = dr.GetString(1);
                    Department depart = new DepartmentDAL().GetDepartmentById(dr.GetInt32(2));
                    depot.Department = depart;
                    depot.ContactPerson = dr.GetString(3);
                    depot.Phone = dr.GetString(4);
                    depot.Fax = dr.GetString(5);
                    depot.Address = dr.GetString(6);
                    depot.Status = dr.GetBoolean(7);
                    depot.CompanyId = dr.GetInt32(8);
                    result.Add(depot);
                }
            }
            return result;
        }

        public List<Depot> GetDepotByCompanyId(int compId)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@company_id", compId)
            };
            List<Depot> result = new List<Depot>();
            string sql = "SELECT id, name, department_id, contact_person, phone, fax, address, status, company_id FROM depots WHERE company_id =        @company_id AND is_delete = 0";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    Depot depot = new Depot();
                    depot.Id = dr.GetInt32(0);
                    depot.Name = dr.GetString(1);
                    Department depart = new DepartmentDAL().GetDepartmentById(dr.GetInt32(2));
                    depot.Department = depart;
                    depot.ContactPerson = dr.GetString(3);
                    depot.Phone = dr.GetString(4);
                    depot.Fax = dr.GetString(5);
                    depot.Address = dr.GetString(6);
                    depot.Status = dr.GetBoolean(7);
                    depot.CompanyId = dr.GetInt32(8);
                    result.Add(depot);
                }
            }
            return result;
        }
    }
}
