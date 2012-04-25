using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Backend.Models;
using Backend.Utilities;

namespace Backend.DAL
{
    public class CostTypeDAL
    {
        public void CreateCostType(CostType ct)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@name", 50, ct.Name),
                SqlUtilities.GenerateInputParameter("@is_manage_costs", SqlDbType.Bit, ct.IsManageCosts),
                SqlUtilities.GenerateInputParameter("@is_salor_costs", SqlDbType.Bit, ct.IsSalorCosts)
            };
            string sql = "INSERT INTO cost_types(name, is_manage_costs, is_salor_costs) VALUES(@name, @is_manage_costs, @is_salor_costs)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdateCostType(CostType ct)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", ct.Id),
                SqlUtilities.GenerateInputNVarcharParameter("@name", 50, ct.Name),
                SqlUtilities.GenerateInputParameter("@is_manage_costs", SqlDbType.Bit, ct.IsManageCosts),
                SqlUtilities.GenerateInputParameter("@is_salor_costs", SqlDbType.Bit, ct.IsSalorCosts)
            };
            string sql = "UPDATE cost_types SET name = @name, is_manage_costs = @is_manage_costs, is_salor_costs = @is_salor_costs WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void DeleteCostTypeById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "DELETE FROM cost_types WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public CostType GetCostTypeById(int id)
        {
            CostType ct = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "SELECT id, name, is_manage_costs, is_salor_costs FROM cost_types WHERE id = @id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    ct = new CostType();
                    ct.Id = dr.GetInt32(0);
                    ct.Name = dr.GetString(1);
                    ct.IsManageCosts = dr.GetBoolean(2);
                    ct.IsSalorCosts = dr.GetBoolean(3);
                }
            }
            return ct;
        }

        public CostType GetCostTypeByName(string name)
        {
            CostType ct = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@name", 50, name)
            };
            string sql = "SELECT id, name, is_manage_costs, is_salor_costs FROM cost_types WHERE name = @name";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    ct = new CostType();
                    ct.Id = dr.GetInt32(0);
                    ct.Name = dr.GetString(1);
                    ct.IsManageCosts = dr.GetBoolean(2);
                    ct.IsSalorCosts = dr.GetBoolean(3);
                }
            }
            return ct;
        }

        public List<CostType> GetCostType()
        {
            List<CostType> result = new List<CostType>();
            string sql = "SELECT id, name, is_manage_costs, is_salor_costs FROM cost_types";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    CostType ct = new CostType();
                    ct.Id = dr.GetInt32(0);
                    ct.Name = dr.GetString(1);
                    ct.IsManageCosts = dr.GetBoolean(2);
                    ct.IsSalorCosts = dr.GetBoolean(3);
                    result.Add(ct);
                }
            }
            return result;
        }
    }
}
