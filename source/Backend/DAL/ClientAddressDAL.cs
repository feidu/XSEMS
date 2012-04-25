using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.Utilities;
using System.Data;
using System.Data.SqlClient;

namespace Backend.DAL
{
    public class ClientAddressDAL
    {
        public void CreateClientAddress(ClientAddress ca)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@client_id",  ca.ClientId),
                SqlUtilities.GenerateInputNVarcharParameter("@province", 50, ca.Province),
                SqlUtilities.GenerateInputNVarcharParameter("@sender_name", 50, ca.SenderName),
                SqlUtilities.GenerateInputNVarcharParameter("@phone", 50, ca.Phone),
                SqlUtilities.GenerateInputNVarcharParameter("@email", 50, ca.Email),
                SqlUtilities.GenerateInputNVarcharParameter("@postcode", 50, ca.Postcode),
                SqlUtilities.GenerateInputNVarcharParameter("@address", 200, ca.Address),
                SqlUtilities.GenerateInputNVarcharParameter("@remark", 500, ca.Remark),
                SqlUtilities.GenerateInputNVarcharParameter("@fax", 50, ca.Fax),
            };
            string sql = "INSERT INTO client_address(client_id, sender_name, phone, email, postcode, address, remark, fax, province) VALUES(@client_id, @sender_name, @phone, @email, @postcode, @address, @remark, @fax, @province)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public List<ClientAddress> GetClientAddressByClientId(int clientId)
        {
            List<ClientAddress> result = new List<ClientAddress>();
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@client_id", clientId)
            };
            string sql = "SELECT id, client_id, sender_name, phone, email, postcode, address, remark, fax, province FROM client_address WHERE client_id = @client_id";
            using(SqlDataReader dr=SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while(dr.Read())
                {
                    ClientAddress ca = new ClientAddress();
                    ca.Id = dr.GetInt32(0);
                    ca.ClientId = dr.GetInt32(1);
                    ca.SenderName = dr.GetString(2);
                    ca.Phone = dr.GetString(3);
                    ca.Email = dr.GetString(4);
                    ca.Postcode = dr.GetString(5);
                    ca.Address = dr.GetString(6);
                    ca.Remark = dr.GetString(7);
                    ca.Fax = dr.GetString(8);
                    ca.Province = dr.GetString(9);
                    result.Add(ca);
                }
            }
            return result;
        }

        public ClientAddress GetClientAddressById(int id)
        {
            ClientAddress ca = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "SELECT id, client_id, sender_name, phone, email, postcode, address, remark, fax, province FROM client_address WHERE id = @id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    ca = new ClientAddress();
                    ca.Id = dr.GetInt32(0);
                    ca.ClientId = dr.GetInt32(1);
                    ca.SenderName = dr.GetString(2);
                    ca.Phone = dr.GetString(3);
                    ca.Email = dr.GetString(4);
                    ca.Postcode = dr.GetString(5);
                    ca.Address = dr.GetString(6);
                    ca.Remark = dr.GetString(7);
                    ca.Fax = dr.GetString(8);
                    ca.Province = dr.GetString(9);
                }
            }
            return ca;
        }

        public void DeleteClientAddressById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id",  id),
            };
            string sql = "DELETE FROM client_address WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }
    }
}
