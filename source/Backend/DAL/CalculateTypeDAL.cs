using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Backend.Models;
using Backend.Utilities;

namespace Backend.DAL
{
    public class CalculateTypeDAL
    {
        public void CreateCalculateType(CalculateType ct)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@name", 50, ct.Name)
            };
            string sql = "INSERT INTO calculate_types(name) VALUES(@name)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdateCalculateType(CalculateType ct)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", ct.Id),
                SqlUtilities.GenerateInputNVarcharParameter("@name", 50, ct.Name)
            };
            string sql = "UPDATE calculate_types SET name = @name WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void DeleteCalculateTypeById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "DELETE FROM calculate_types WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public CalculateType GetCalculateTypeById(int id)
        {
            CalculateType ct = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "SELECT id, name FROM calculate_types WHERE id = @id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    ct = new CalculateType();
                    ct.Id = dr.GetInt32(0);
                    ct.Name = dr.GetString(1);
                }
            }
            return ct;
        }

        public CalculateType GetCalculateTypeByName(string name)
        {
            CalculateType ct = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@name", 50, name)
            };
            string sql = "SELECT id, name FROM calculate_types WHERE name = @name";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    ct = new CalculateType();
                    ct.Id = dr.GetInt32(0);
                    ct.Name = dr.GetString(1);
                }
            }
            return ct;
        }

        public List<CalculateType> GetCalculateType()
        {
            List<CalculateType> result = new List<CalculateType>();
            string sql = "SELECT id, name FROM calculate_types";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    CalculateType ct = new CalculateType();
                    ct.Id = dr.GetInt32(0);
                    ct.Name = dr.GetString(1);
                    result.Add(ct);
                }
            }
            return result;
        }
    }
    
}
