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
    public class CarrierAreaDAL
    {
        public void CreateCarrierArea(CarrierArea ca)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@name", 50, ca.Name),
                SqlUtilities.GenerateInputNVarcharParameter("@Encode", 50, ca.Encode),
                SqlUtilities.GenerateInputIntParameter("@carrier_id", ca.Carrier.Id)
            };
            string sql = "INSERT INTO carrier_area(name, encode, carrier_id) VALUES(@name, @encode, @carrier_id)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }
        
        public CarrierArea GetCarrierAreaByName(string name, int carrierId)
        {
            CarrierArea ca = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@name", 50, name),
                SqlUtilities.GenerateInputIntParameter("@carrier_id", carrierId)
            };
            string sql = "SELECT id FROM carrier_area WHERE name = @name AND carrier_id = @carrier_id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while(dr.Read())
                {
                    ca = new CarrierArea();
                    ca.Id = dr.GetInt32(0);
                }
            }
            return ca;
        }

        public CarrierArea GetCarrierAreaById(int id)
        {
            CarrierArea ca = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "SELECT id, carrier_id, name, encode FROM carrier_area WHERE id = @id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while(dr.Read())
                {
                    ca = new CarrierArea();
                    ca.Id = dr.GetInt32(0);
                    Carrier carrier = new CarrierDAL().GetCarrierById(dr.GetInt32(1));
                    ca.Carrier = carrier;
                    ca.Name = dr.GetString(2);
                    ca.Encode = dr.GetString(3);
                }
            }
            return ca;
        }

        public void UpdateCarrierArea(CarrierArea ca)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", ca.Id),
                SqlUtilities.GenerateInputNVarcharParameter("@name", 50, ca.Name),
                SqlUtilities.GenerateInputNVarcharParameter("@Encode", 50, ca.Encode),
                SqlUtilities.GenerateInputIntParameter("@carrier_id", ca.Carrier.Id)
            };
            string sql = "UPDATE carrier_area SET name = @name, carrier_id = @carrier_id WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public string GetNextEncode()
        {
            string encode = "000";
            string sql = "SELECT encode FROM carrier_area WHERE id=(SELECT MAX(id) FROM carrier_area)";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    encode = dr.GetString(0);
                }
            }
            return StringHelper.GetNextEncodeNumber(3, encode);
        }

        public List<CarrierArea> GetCarrierAreaByCarrierId(int id)
        {
            List<CarrierArea> result = new List<CarrierArea>();
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@carrier_id", id)
            };
            string sql = "SELECT id, carrier_id, name, encode FROM carrier_area WHERE carrier_id = @carrier_id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    CarrierArea ca = new CarrierArea();
                    ca.Id = dr.GetInt32(0);
                    Carrier carrier = new CarrierDAL().GetCarrierById(dr.GetInt32(1));
                    ca.Carrier = carrier;
                    ca.Name = dr.GetString(2);
                    ca.Encode = dr.GetString(3);
                    result.Add(ca);
                }
            }
            return result;
        }

        public PaginationQueryResult<CarrierArea> GetCarrierArea(PaginationQueryCondition condition)
        {
            PaginationQueryResult<CarrierArea> result = new PaginationQueryResult<CarrierArea>();
            string sql = "SELECT TOP " + condition.PageSize + " id, carrier_id, name , encode FROM carrier_area ";
            if (condition.CurrentPage > 1)
            {
                sql += " WHERE id > (SELECT MAX(id) FROM (SELECT TOP " + condition.PageSize*(condition.CurrentPage-1) + " id FROM carrier_area ORDER BY encode ASC) AS C)";
            }
            sql += " ORDER BY encode ASC; SELECT COUNT(*) FROM carrier_area ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    CarrierArea ca = new CarrierArea();
                    ca.Id = dr.GetInt32(0);
                    Carrier carrier = new CarrierDAL().GetCarrierById(dr.GetInt32(1));
                    ca.Carrier = carrier;
                    ca.Name = dr.GetString(2);
                    ca.Encode = dr.GetString(3);
                    result.Results.Add(ca);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;

        }

        public void DeleteCarrierAreaById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "DELETE FROM carrier_area WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }
    }
}
