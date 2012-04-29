using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.Utilities;
using Backend.Models.Pagination;
using System.Data;
using System.Data.SqlClient;

namespace Backend.DAL
{
    public class ClientDAL
    {
        public void CreateClient(Client client)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@username", 50, client.Username),
                SqlUtilities.GenerateInputNVarcharParameter("@password", 50, client.Password),
                SqlUtilities.GenerateInputNVarcharParameter("@real_name", 50, client.RealName),
                SqlUtilities.GenerateInputNVarcharParameter("@id_card", 50, client.IdCard),
                SqlUtilities.GenerateInputNVarcharParameter("@phone", 50, client.Phone),
                SqlUtilities.GenerateInputNVarcharParameter("@mobile", 50, client.Mobile),
                SqlUtilities.GenerateInputNVarcharParameter("@email", 50, client.Email),
                SqlUtilities.GenerateInputNVarcharParameter("@address", 200, client.Address),
                SqlUtilities.GenerateInputParameter("@credit", SqlDbType.Decimal, client.Credit),
                SqlUtilities.GenerateInputParameter("@is_message", SqlDbType.Bit, client.IsMessage),
                SqlUtilities.GenerateInputDateTimeParameter("@create_date", client.CreateDate)
            };

            string sql = "INSERT INTO clients(username, password, real_name, id_card, phone, mobile, email, address, credit, is_message, create_date) VALUES(@username, @password, @real_name, @id_card, @phone, @mobile, @email, @address, @credit, @is_message, @create_date)";

            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }


        public void UpdateClient(Client client, string sql)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", client.Id),
                SqlUtilities.GenerateInputNVarcharParameter("@password", 50, client.Password),
                SqlUtilities.GenerateInputNVarcharParameter("@real_name", 50, client.RealName),
                SqlUtilities.GenerateInputNVarcharParameter("@id_card", 50, client.IdCard),
                SqlUtilities.GenerateInputNVarcharParameter("@phone", 50, client.Phone),
                SqlUtilities.GenerateInputNVarcharParameter("@mobile", 50, client.Mobile),
                SqlUtilities.GenerateInputNVarcharParameter("@email", 50, client.Email),
                SqlUtilities.GenerateInputNVarcharParameter("@address", 200, client.Address),
                SqlUtilities.GenerateInputParameter("@credit", SqlDbType.Decimal, client.Credit),
                SqlUtilities.GenerateInputParameter("@is_message", SqlDbType.Bit, client.IsMessage),
                SqlUtilities.GenerateInputParameter("@balance", SqlDbType.Decimal, client.Balance)
            };
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdateClientPwd(Client client)
        {
            string sql = "UPDATE clients SET password = @password WHERE id = @id ";
            UpdateClient(client, sql);
        }

        public void UpdateClientInfo(Client client)
        {
            string sql = "UPDATE clients SET real_name = @real_name, id_card = @id_card, phone = @phone, mobile = @mobile, email = @email, address = @address, credit = @credit, is_message = @is_message WHERE id = @id ";
            UpdateClient(client, sql);
        }

        public void UpdateClientDiscount(Client client)
        {
            string sql = "UPDATE clients SET credit = @credit WHERE id = @id ";
            UpdateClient(client, sql);
        }

        public void UpdateClientBalance(Client client)
        {
            string sql = "UPDATE clients SET balance = @balance WHERE id = @id";
            UpdateClient(client, sql);
        }

        public void DeleteClientById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "UPDATE clients SET is_delete = 1 WHERE id = @id ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public Client GetClientById(int id)
        {
            Client client = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "SELECT id, username, password, real_name, id_card, phone, mobile, email, address, credit, is_message, create_date, balance FROM clients WHERE id = @id ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    client = new Client();
                    client.Id = dr.GetInt32(0);
                    client.Username = dr.GetString(1);
                    client.Password = dr.GetString(2);
                    client.RealName = dr.GetString(3);
                    client.IdCard = dr.GetString(4);
                    client.Phone = dr.GetString(5);
                    client.Mobile = dr.GetString(6);
                    client.Email = dr.GetString(7);
                    client.Address = dr.GetString(8);
                    client.Credit = dr.GetDecimal(9);
                    client.IsMessage = dr.GetBoolean(10);
                    client.CreateDate = dr.GetDateTime(11);
                    client.Balance = dr.GetDecimal(12);
                }
            }
            return client;
        }

        public Client GetClientByUsername(string username)
        {
            Client client = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@username", 50, username)
            };
            string sql = "SELECT id, username, password, real_name, id_card, phone, mobile, email, address, credit, is_message , create_date, balance FROM clients WHERE username = @username AND is_delete = 0 ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    client = new Client();
                    client.Id = dr.GetInt32(0);
                    client.Username = dr.GetString(1);
                    client.Password = dr.GetString(2);
                    client.RealName = dr.GetString(3);
                    client.IdCard = dr.GetString(4);
                    client.Phone = dr.GetString(5);
                    client.Mobile = dr.GetString(6);
                    client.Email = dr.GetString(7);
                    client.Address = dr.GetString(8);
                    client.Credit = dr.GetDecimal(9);
                    client.IsMessage = dr.GetBoolean(10);
                    client.CreateDate = dr.GetDateTime(11);
                    client.Balance = dr.GetDecimal(12);
                }
            }
            return client;
        }

        public Client GetClientByRealName(string realName)
        {
            Client client = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@real_name", 50, realName)
            };
            string sql = "SELECT id, username, password, real_name, id_card, phone, mobile, email, address, credit, is_message, create_date, balance FROM clients WHERE real_name = @real_name ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    client = new Client();
                    client.Id = dr.GetInt32(0);
                    client.Username = dr.GetString(1);
                    client.Password = dr.GetString(2);
                    client.RealName = dr.GetString(3);
                    client.IdCard = dr.GetString(4);
                    client.Phone = dr.GetString(5);
                    client.Mobile = dr.GetString(6);
                    client.Email = dr.GetString(7);
                    client.Address = dr.GetString(8);
                    client.Credit = dr.GetDecimal(9);
                    client.IsMessage = dr.GetBoolean(10);
                    client.CreateDate = dr.GetDateTime(11);
                    client.Balance = dr.GetDecimal(12);
                }
            }
            return client;
        }

        public Client GetClientByRealNameAndCompanyId(string realName)
        {
            Client client = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@real_name", 50, realName)
            };
            string sql = "SELECT id, username, password, real_name, id_card, phone, mobile, email, address, province, city, credit, is_message, create_date, balance FROM clients WHERE real_name = @real_name";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    client = new Client();
                    client.Id = dr.GetInt32(0);
                    client.Username = dr.GetString(1);
                    client.Password = dr.GetString(2);
                    client.RealName = dr.GetString(3);
                    client.IdCard = dr.GetString(4);
                    client.Phone = dr.GetString(5);
                    client.Mobile = dr.GetString(6);
                    client.Email = dr.GetString(7);
                    client.Address = dr.GetString(8);
                    client.Credit = dr.GetDecimal(9);
                    client.IsMessage = dr.GetBoolean(10);
                    client.CreateDate = dr.GetDateTime(11);
                    client.Balance = dr.GetDecimal(12);
                }
            }
            return client;
        }

        public List<Client> GetClient()
        {
            List<Client> result = new List<Client>();
            string sql = "SELECT id, username, password, real_name, id_card, phone, mobile, email, address, credit, is_message, create_date, balance FROM clients WHERE is_delete = 0 ";

            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    Client client = new Client();
                    client.Id = dr.GetInt32(0);
                    client.Username = dr.GetString(1);
                    client.Password = dr.GetString(2);
                    client.RealName = dr.GetString(3);
                    client.IdCard = dr.GetString(4);
                    client.Phone = dr.GetString(5);
                    client.Mobile = dr.GetString(6);
                    client.Email = dr.GetString(7);
                    client.Address = dr.GetString(8);
                    client.Credit = dr.GetDecimal(9);
                    client.IsMessage = dr.GetBoolean(10);
                    client.CreateDate = dr.GetDateTime(11);
                    client.Balance = dr.GetDecimal(12);
                    result.Add(client);
                }
            }
            return result;
        }
        
        public PaginationQueryResult<Client> GetClient(PaginationQueryCondition condition)
        {
            PaginationQueryResult<Client> result = new PaginationQueryResult<Client>();
            string sql = "SELECT TOP " + condition.PageSize + " id, username, password, real_name, id_card, phone, mobile, email, address, credit, is_message, create_date, balance FROM clients WHERE is_delete = 0 ";
            if (condition.CurrentPage > 1)
            {
                sql += " AND id<(SELECT MIN(id) FROM(SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM clients WHERE is_delete = 0 ORDER BY id DESC) AS D)";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM clients WHERE is_delete = 0 ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    Client client = new Client();
                    client.Id = dr.GetInt32(0);
                    client.Username = dr.GetString(1);
                    client.Password = dr.GetString(2);
                    client.RealName = dr.GetString(3);
                    client.IdCard = dr.GetString(4);
                    client.Phone = dr.GetString(5);
                    client.Mobile = dr.GetString(6);
                    client.Email = dr.GetString(7);
                    client.Address = dr.GetString(8);
                    client.Credit = dr.GetDecimal(9);
                    client.IsMessage = dr.GetBoolean(10);
                    client.CreateDate = dr.GetDateTime(11);
                    client.Balance = dr.GetDecimal(12);
                    result.Results.Add(client);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public PaginationQueryResult<Client> GetClientByCompanyId(PaginationQueryCondition condition)
        {
            PaginationQueryResult<Client> result = new PaginationQueryResult<Client>();
            string sql = "SELECT TOP " + condition.PageSize + " id, username, password, real_name, id_card, phone, mobile, email, address, credit, is_message, create_date, balance, user_id FROM clients WHERE is_delete = 0 AND company_id = @company_id";
            if (condition.CurrentPage > 1)
            {
                sql += " AND id<(SELECT MIN(id) FROM(SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM clients  WHERE is_delete = 0 AND company_id = @company_id ORDER BY id DESC) AS D)";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM clients WHERE is_delete = 0";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    Client client = new Client();
                    client.Id = dr.GetInt32(0);
                    client.Username = dr.GetString(1);
                    client.Password = dr.GetString(2);
                    client.RealName = dr.GetString(3);
                    client.IdCard = dr.GetString(4);
                    client.Phone = dr.GetString(5);
                    client.Mobile = dr.GetString(6);
                    client.Email = dr.GetString(7);
                    client.Address = dr.GetString(8);
                    client.Credit = dr.GetDecimal(9);
                    client.IsMessage = dr.GetBoolean(10);
                    client.CreateDate = dr.GetDateTime(11);
                    client.Balance = dr.GetDecimal(12);
                    result.Results.Add(client);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public PaginationQueryResult<Client> GetClientByParameters(PaginationQueryCondition condition, string keyword)
        {
            string sqlParam = "";
            if (!string.IsNullOrEmpty(keyword))
            {
                sqlParam = " AND username LIKE '%" + keyword + "%' OR real_name LIKE '%" + keyword + "%'";
            }
            PaginationQueryResult<Client> result = new PaginationQueryResult<Client>();
            string sql = "SELECT TOP " + condition.PageSize + " id, username, password, real_name, id_card, phone, mobile, email, address, credit, is_message, create_date, balance FROM clients WHERE is_delete = 0 "+sqlParam;
            if (condition.CurrentPage > 1)
            {
                sql += " AND id<(SELECT MIN(id) FROM(SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM clients  WHERE is_delete = 0 "+sqlParam+" ORDER BY id DESC) AS D)";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM clients WHERE is_delete = 0" + sqlParam;
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    Client client = new Client();
                    client.Id = dr.GetInt32(0);
                    client.Username = dr.GetString(1);
                    client.Password = dr.GetString(2);
                    client.RealName = dr.GetString(3);
                    client.IdCard = dr.GetString(4);
                    client.Phone = dr.GetString(5);
                    client.Mobile = dr.GetString(6);
                    client.Email = dr.GetString(7);
                    client.Address = dr.GetString(8);
                    client.Credit = dr.GetDecimal(9);
                    client.IsMessage = dr.GetBoolean(10);
                    client.CreateDate = dr.GetDateTime(11);
                    client.Balance = dr.GetDecimal(12);
                    result.Results.Add(client);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public List<Client> GetClientList()
        {
            List<Client> result = new List<Client>();
            string sql = "SELECT  id, username, password, real_name, id_card, phone, mobile, email, address, province, city, credit, is_message, create_date, balance FROM clients WHERE is_delete = 0";
           
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    Client client = new Client();
                    client.Id = dr.GetInt32(0);
                    client.Username = dr.GetString(1);
                    client.Password = dr.GetString(2);
                    client.RealName = dr.GetString(3);
                    client.IdCard = dr.GetString(4);
                    client.Phone = dr.GetString(5);
                    client.Mobile = dr.GetString(6);
                    client.Email = dr.GetString(7);
                    client.Address = dr.GetString(8);
                    client.Credit = dr.GetDecimal(9);
                    client.IsMessage = dr.GetBoolean(10);
                    client.CreateDate = dr.GetDateTime(11);
                    client.Balance = dr.GetDecimal(12);
                    result.Add(client);
                }                
            }
            return result;
        }
      
        public List<Client> GetClientByParameters(string searchKey)
        {
            string sql = "SELECT  id, username, password, real_name, id_card, phone, mobile, email, address, credit, is_message, create_date, balance FROM clients WHERE is_delete = 0 ";
            DataTable dtClient = SqlHelper.ExecuteDataTable(CommandType.Text, sql, null);

            DataTable dtSearchClient = new DataTable();
            dtSearchClient.Columns.Add("real_name", typeof(string));
            dtSearchClient.Columns.Add("real_name_py", typeof(string));
            for(int i=0; i<dtClient.Rows.Count; i++)
            {
                DataRow dr=dtSearchClient.NewRow();
                dr["real_name"] = dtClient.Rows[i][3].ToString();
                dr["real_name_py"] = StringHelper.GetChineseSpell(dtClient.Rows[i][3].ToString());
                dtSearchClient.Rows.Add(dr);
            }
            DataView dv = dtSearchClient.DefaultView;
            if (!string.IsNullOrEmpty(searchKey))
            {
                dv.RowFilter = "real_name like '%" + searchKey + "%' OR real_name_py like '%" + searchKey + "%'";
            }

            List<Client> result = new List<Client>();

            foreach (DataRowView drv in dv)
            {
                Client client = new Client();
                client.RealName = drv["real_name"].ToString();
                result.Add(client);
            }

            return result;
        }

        public List<Client> GetClientStatistic(DateTime startDate, DateTime endDate)
        {
            List<Client> result = new List<Client>();

            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputDateTimeParameter("@start_date", startDate),
                SqlUtilities.GenerateInputDateTimeParameter("@end_date", endDate)
            };

            string sqlParam = "";
            DateTime minTime = new DateTime(1999, 1, 1);
            if (startDate > minTime && endDate > minTime)
            {
                sqlParam += " AND create_date BETWEEN @start_date AND @end_date";
            }
            else if (startDate > minTime && endDate <= minTime)
            {
                sqlParam += " AND create_date >= @start_date ";
            }
            else if (startDate <= minTime && endDate > minTime)
            {
                sqlParam += " AND create_date <= @end_date";
            }
            
            string sql = "SELECT id, username, password, real_name, id_card, phone, mobile, email, address, credit, is_message, create_date, balance FROM clients WHERE is_delete = 0 " + sqlParam;

            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    Client client = new Client();
                    client.Id = dr.GetInt32(0);
                    client.Username = dr.GetString(1);
                    client.Password = dr.GetString(2);
                    client.RealName = dr.GetString(3);
                    client.IdCard = dr.GetString(4);
                    client.Phone = dr.GetString(5);
                    client.Mobile = dr.GetString(6);
                    client.Email = dr.GetString(7);
                    client.Address = dr.GetString(8);
                    client.Credit = dr.GetDecimal(9);
                    client.IsMessage = dr.GetBoolean(10);
                    client.CreateDate = dr.GetDateTime(11);
                    client.Balance = dr.GetDecimal(12);
                    result.Add(client);
                }
            }
            return result;
        }
    }
}
