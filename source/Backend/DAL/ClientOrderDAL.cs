using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.Utilities;
using System.Data;
using System.Data.SqlClient;
using Backend.Models.Pagination;

namespace Backend.DAL
{
    public class ClientOrderDAL
    {
        public void CreateClientOrder(ClientOrder co)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@client_address_id",  co.ClientAddressId),
                SqlUtilities.GenerateInputIntParameter("@client_id", co.ClientId),
                SqlUtilities.GenerateInputNVarcharParameter("@real_name", 50, co.RealName),
                SqlUtilities.GenerateInputNVarcharParameter("@phone", 50, co.Phone),
                SqlUtilities.GenerateInputNVarcharParameter("@email", 50, co.Email),
                SqlUtilities.GenerateInputNVarcharParameter("@postcode", 50, co.Postcode),
                SqlUtilities.GenerateInputNVarcharParameter("@address", 200, co.Address),
                SqlUtilities.GenerateInputNVarcharParameter("@remark", 500, co.Remark),
                SqlUtilities.GenerateInputDateTimeParameter("@create_time", co.CreateTime),
                SqlUtilities.GenerateInputNVarcharParameter("@country", 50, co.Country),
                SqlUtilities.GenerateInputNVarcharParameter("@city", 50, co.City),
                SqlUtilities.GenerateInputNVarcharParameter("@encode", 50, co.Encode)
            };
            string sql = "INSERT INTO client_orders(client_id, client_address_id, real_name, phone, email, postcode, address, remark, create_time, country, city, encode) VALUES(@client_id, @client_address_id, @real_name, @phone, @email, @postcode, @address, @remark, @create_time, @country, @city ,@encode)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public List<ClientOrder> GetClientOrderByClientId(int clientId)
        {
            List<ClientOrder> result = new List<ClientOrder>();
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@client_id", clientId)
            };
            string sql = "SELECT id, client_id, client_address_id, real_name, phone, email, postcode, address, remark, create_time, country, city, encode FROM client_orders WHERE client_id = @client_id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    ClientOrder co = new ClientOrder();
                    co.Id = dr.GetInt32(0);
                    co.ClientId = dr.GetInt32(1);
                    co.ClientAddressId = dr.GetInt32(2);
                    co.RealName = dr.GetString(3);
                    co.Phone = dr.GetString(4);
                    co.Email = dr.GetString(5);
                    co.Postcode = dr.GetString(6);
                    co.Address = dr.GetString(7);
                    co.Remark = dr.GetString(8);
                    co.CreateTime = dr.GetDateTime(9);
                    co.Country = dr.GetString(10);
                    co.City = dr.GetString(11);
                    co.Encode = dr.GetString(12);
                    result.Add(co);
                }
            }
            return result;
        }

        public void DeleteClientOrderById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id",  id),
            };
            string sql = "DELETE FROM client_orders WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void DeleteClientOrderByClientId(int clientId)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@client_id",  clientId),
            };
            string sql = "DELETE FROM client_orders WHERE client_id = @client_id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public PaginationQueryResult<ClientOrder> GetClientOrderByParameters(PaginationQueryCondition condition, int clientId, DateTime startDate, DateTime endDate)
        {
            PaginationQueryResult<ClientOrder> result = new PaginationQueryResult<ClientOrder>();

            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputDateTimeParameter("@start_date", startDate),
                SqlUtilities.GenerateInputDateTimeParameter("@end_date", endDate),
                SqlUtilities.GenerateInputIntParameter("@client_id", clientId)
            };

            string sqlParam = "";
            DateTime minTime = new DateTime(1999, 1, 1);
            if (startDate > minTime && endDate > minTime)
            {
                sqlParam += " AND create_time BETWEEN @start_date AND @end_date";
            }
            else if (startDate > minTime && endDate <= minTime)
            {
                sqlParam += " AND create_time >= @start_date ";
            }
            else if (startDate <= minTime && endDate > minTime)
            {
                sqlParam += " AND create_time <= @end_date";
            }
            if (clientId >= 0)
            {
                sqlParam += " AND client_id = @client_id";
            }

            string sql = "SELECT TOP " + condition.PageSize + " id, client_id, client_address_id, real_name, phone, email, postcode, address, remark, create_time, country, city, encode FROM client_orders WHERE 1=1 " + sqlParam;
            if (condition.CurrentPage > 1)
            {
                sql += " AND id <(SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM client_orders WHERE 1=1" + sqlParam + " ORDER BY id DESC) AS O)";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(1) FROM client_orders WHERE 1=1" + sqlParam;

            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    ClientOrder co = new ClientOrder();
                    co.Id = dr.GetInt32(0);
                    co.ClientId = dr.GetInt32(1);
                    co.ClientAddressId = dr.GetInt32(2);
                    co.RealName = dr.GetString(3);
                    co.Phone = dr.GetString(4);
                    co.Email = dr.GetString(5);
                    co.Postcode = dr.GetString(6);
                    co.Address = dr.GetString(7);
                    co.Remark = dr.GetString(8);
                    co.CreateTime = dr.GetDateTime(9);
                    co.Country = dr.GetString(10);
                    co.City = dr.GetString(11);
                    co.Encode = dr.GetString(12);
                    result.Results.Add(co);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }

            return result;
        }

        public List<ClientOrder> GetClientOrderListByParameters(int clientId, DateTime startDate, DateTime endDate)
        {
            List<ClientOrder> result = new List<ClientOrder>();

            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputDateTimeParameter("@start_date", startDate),
                SqlUtilities.GenerateInputDateTimeParameter("@end_date", endDate),
                SqlUtilities.GenerateInputIntParameter("@client_id", clientId)
            };

            string sqlParam = "";
            DateTime minTime = new DateTime(1999, 1, 1);
            if (startDate > minTime && endDate > minTime)
            {
                sqlParam += " AND create_time BETWEEN @start_date AND @end_date";
            }
            else if (startDate > minTime && endDate <= minTime)
            {
                sqlParam += " AND create_time >= @start_date ";
            }
            else if (startDate <= minTime && endDate > minTime)
            {
                sqlParam += " AND create_time <= @end_date";
            }
            if (clientId >= 0)
            {
                sqlParam += " AND client_id = @client_id";
            }

            string sql = "SELECT id, client_id, client_address_id, real_name, phone, email, postcode, address, remark, create_time, country, city, encode FROM client_orders WHERE 1=1" + sqlParam + " ORDER BY create_time ASC";

            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    ClientOrder co = new ClientOrder();
                    co.Id = dr.GetInt32(0);
                    co.ClientId = dr.GetInt32(1);
                    co.ClientAddressId = dr.GetInt32(2);
                    co.RealName = dr.GetString(3);
                    co.Phone = dr.GetString(4);
                    co.Email = dr.GetString(5);
                    co.Postcode = dr.GetString(6);
                    co.Address = dr.GetString(7);
                    co.Remark = dr.GetString(8);
                    co.CreateTime = dr.GetDateTime(9);
                    co.Country = dr.GetString(10);
                    co.City = dr.GetString(11);
                    co.Encode = dr.GetString(12);
                    //ClientAddress ca = new ClientAddress();
                    //ca = new ClientAddressDAL().GetClientAddressById(co.ClientAddressId);
                    //if (ca != null)
                    //{
                    //    co.PostAddress = ca.Address + ", " + ca.Province;
                    //}
                    //else
                    //{
                    //    co.PostAddress = "";
                    //}
                    Client client = new ClientDAL().GetClientById(co.ClientId);
                    if (client != null)
                    {
                        Company comp = new CompanyDAL().GetCompanyById(client.CompanyId);
                        if (comp != null)
                        {
                            switch (comp.Name)
                            {
                                case "亿度物流宁波总公司":
                                    co.PostAddress = "站前路238 (NB)";
                                    break;
                                case "亿度物流义乌分公司":
                                    co.PostAddress = "站前路238 (YW)";
                                    break;
                                case "亿度物流杭州分公司":
                                    co.PostAddress = "站前路238 (HZ)";
                                    break;
                                case "亿度物流上海分公司":
                                    co.PostAddress = "站前路238 (SH)";
                                    break;
                                case "亿度物流深圳分公司":
                                    co.PostAddress = "站前路238 (SZ)";
                                    break;
                                default:
                                    co.PostAddress = "站前路238";
                                    break;
                            }
                        }
                    }
                    result.Add(co);
                }
            }
            return result;
        }
    }
}
