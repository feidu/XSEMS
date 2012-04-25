using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Backend.Models;
using Backend.Models.Pagination;
using Backend.Utilities;


namespace Backend.DAL
{
    public class ComplaintDAL
    {
        public void CreateComplaint(Complaint comp)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@client_id",comp.ClientId),
            SqlUtilities.GenerateInputIntParameter("@company_id",comp.CompanyId),
                SqlUtilities.GenerateInputNVarcharParameter("@client_name",50,comp.ClientName),
                SqlUtilities.GenerateInputNVarcharParameter("@title",50,comp.Title),
                SqlUtilities.GenerateInputNVarcharParameter("@content", 2000,comp.Content),
                SqlUtilities.GenerateInputDateTimeParameter("@create_time",comp.CreateTime)
            };
            string sql = "INSERT INTO complaints(client_id, company_id, client_name, title, content, create_time) VALUES(@client_id, @company_id,           @client_name, @title, @content, @create_time) ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);          
        }

        public Complaint GetComplaintById(int id)
        {
            Complaint comp = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "SELECT id, client_id, client_name, content, create_time,company_id, is_reply, title FROM complaints WHERE id = @id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    comp = new Complaint();
                    comp.Id = dr.GetInt32(0);
                    comp.ClientId = dr.GetInt32(1);
                    comp.ClientName = dr.GetString(2);
                    comp.Content = dr.GetString(3);
                    comp.CreateTime = dr.GetDateTime(4);
                    comp.CompanyId = dr.GetInt32(5);
                    comp.IsReply = dr.GetBoolean(6);
                    comp.Title = dr.GetString(7);
                }
            }
            return comp;
        }

        public PaginationQueryResult<Complaint> GetComplaint(PaginationQueryCondition condition)
        {
            PaginationQueryResult<Complaint> result = new PaginationQueryResult<Complaint>();
            
            string sql = "SELECT TOP " + condition.PageSize + " id, client_id, client_name, content, create_time, company_id FROM complaints ";
            if (condition.CurrentPage > 1)
            {
                sql += " WHERE id<(SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize*(condition.CurrentPage-1) + " id FROM complaints ORDER BY id DESC) AS D) ";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM complaints ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    Complaint comp = new Complaint();
                    comp.Id = dr.GetInt32(0);
                    comp.ClientId = dr.GetInt32(1);
                    comp.ClientName = dr.GetString(2);
                    comp.Content = dr.GetString(3);
                    comp.CreateTime = dr.GetDateTime(4);
                    comp.CompanyId = dr.GetInt32(5);
                    result.Results.Add(comp);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }            
            return result;
        }

        public PaginationQueryResult<Complaint> GetComplaintByCompanyId(PaginationQueryCondition condition, int compId)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@company_id", compId)
            };
            PaginationQueryResult<Complaint> result = new PaginationQueryResult<Complaint>();

            string sql = "SELECT TOP " + condition.PageSize + " id, client_id, client_name, content, create_time, company_id, is_reply, title FROM complaints WHERE company_id = @company_id AND is_delete = 0 ";
            if (condition.CurrentPage > 1)
            {
                sql += " AND id<(SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM complaints WHERE company_id = @company_id AND is_delete = 0  ORDER BY id DESC) AS D) ";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM complaints WHERE company_id = @company_id AND is_delete = 0 ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    Complaint comp = new Complaint();
                    comp.Id = dr.GetInt32(0);
                    comp.ClientId = dr.GetInt32(1);
                    comp.ClientName = dr.GetString(2);
                    comp.Content = dr.GetString(3);
                    comp.CreateTime = dr.GetDateTime(4);
                    comp.CompanyId = dr.GetInt32(5);
                    comp.IsReply = dr.GetBoolean(6);
                    comp.Title = dr.GetString(7);
                    result.Results.Add(comp);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public PaginationQueryResult<Complaint> GetComplaintByCompanyIdAndIsReply(PaginationQueryCondition condition, int compId, bool isReply)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@company_id", compId),
                SqlUtilities.GenerateInputParameter("@is_reply", SqlDbType.Bit, isReply)
            };
            PaginationQueryResult<Complaint> result = new PaginationQueryResult<Complaint>();

            string sql = "SELECT TOP " + condition.PageSize + " id, client_id, client_name, content, create_time, company_id, is_reply, title FROM complaints WHERE company_id = @company_id AND is_delete = 0 AND is_reply = @is_reply ";
            if (condition.CurrentPage > 1)
            {
                sql += " AND id<(SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM complaints WHERE company_id = @company_id AND is_delete = 0 AND is_reply = @is_reply ORDER BY id DESC) AS D) ";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM complaints WHERE company_id = @company_id AND is_delete = 0 AND is_reply = @is_reply ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    Complaint comp = new Complaint();
                    comp.Id = dr.GetInt32(0);
                    comp.ClientId = dr.GetInt32(1);
                    comp.ClientName = dr.GetString(2);
                    comp.Content = dr.GetString(3);
                    comp.CreateTime = dr.GetDateTime(4);
                    comp.CompanyId = dr.GetInt32(5);
                    comp.IsReply = dr.GetBoolean(6);
                    comp.Title = dr.GetString(7);
                    result.Results.Add(comp);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public PaginationQueryResult<Complaint> GetComplaintByClientIdAndIsReply(PaginationQueryCondition condition, int clientId, bool isReply)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@client_id", clientId),
                SqlUtilities.GenerateInputParameter("@is_reply", SqlDbType.Bit, isReply)
            };
            PaginationQueryResult<Complaint> result = new PaginationQueryResult<Complaint>();

            string sql = "SELECT TOP " + condition.PageSize + " id, client_id, client_name, content, create_time, company_id, is_reply, title FROM complaints WHERE client_id = @client_id AND is_delete = 0 AND is_reply = @is_reply";
            if (condition.CurrentPage > 1)
            {
                sql += " AND id<(SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM complaints WHERE client_id = @client_id AND is_delete = 0 AND is_reply = @is_reply ORDER BY id DESC) AS D) ";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM complaints WHERE client_id = @client_id AND is_delete = 0 AND is_reply = @is_reply ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    Complaint comp = new Complaint();
                    comp.Id = dr.GetInt32(0);
                    comp.ClientId = dr.GetInt32(1);
                    comp.ClientName = dr.GetString(2);
                    comp.Content = dr.GetString(3);
                    comp.CreateTime = dr.GetDateTime(4);
                    comp.CompanyId = dr.GetInt32(5);
                    comp.IsReply = dr.GetBoolean(6);
                    comp.Title = dr.GetString(7);
                    result.Results.Add(comp);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public PaginationQueryResult<Complaint> GetComplaintByClientId(PaginationQueryCondition condition, int clientId)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@client_id", clientId)
            };
            PaginationQueryResult<Complaint> result = new PaginationQueryResult<Complaint>();

            string sql = "SELECT TOP " + condition.PageSize + " id, client_id, client_name, content, create_time, company_id, is_reply, title FROM complaints WHERE client_id = @client_id AND is_delete = 0";
            if (condition.CurrentPage > 1)
            {
                sql += " AND id<(SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM complaints WHERE client_id = @client_id AND is_delete = 0 ORDER BY id DESC) AS D) ";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM complaints WHERE client_id = @client_id AND is_delete = 0 ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    Complaint comp = new Complaint();
                    comp.Id = dr.GetInt32(0);
                    comp.ClientId = dr.GetInt32(1);
                    comp.ClientName = dr.GetString(2);
                    comp.Content = dr.GetString(3);
                    comp.CreateTime = dr.GetDateTime(4);
                    comp.CompanyId = dr.GetInt32(5);
                    comp.IsReply = dr.GetBoolean(6);
                    comp.Title = dr.GetString(7);
                    result.Results.Add(comp);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public void DeleteComplaintById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "UPDATE complaints SET is_delete = 1 WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdateComplaintIsReply(Complaint complaint)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", complaint.Id),
                SqlUtilities.GenerateInputParameter("@is_reply", SqlDbType.Bit, complaint.IsReply)
            };
            string sql = "UPDATE complaints SET is_reply = @is_reply WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void CreateComplaintReply(ComplaintReply compReply)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@complaint_id", compReply.ComplaintId),
                SqlUtilities.GenerateInputIntParameter("@replier_id",compReply.ReplierId),
                SqlUtilities.GenerateInputNVarcharParameter("@replier_name",50,compReply.ReplierName),
                SqlUtilities.GenerateInputParameter("@content",SqlDbType.Text,compReply.Content),
                SqlUtilities.GenerateInputDateTimeParameter("@reply_time",compReply.ReplyTime)
            };
            string sql = "INSERT INTO complaint_replies(complaint_id, replier_id, replier_name, content, reply_time) VALUES(@complaint_id,              @replier_id, @replier_name, @content, @reply_time) ";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public ComplaintReply GetComplaintReplyByComplaintId(int compId)
        {
            ComplaintReply cr = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@complaint_id", compId)
            };            
            string sql = "SELECT id, complaint_id, replier_id, replier_name, content, reply_time FROM complaint_replies WHERE complaint_id =            @complaint_id ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    cr = new ComplaintReply();
                    cr.Id = dr.GetInt32(0);
                    cr.ComplaintId = dr.GetInt32(1);
                    cr.ReplierId = dr.GetInt32(2);
                    cr.ReplierName = dr.GetString(3);
                    cr.Content = dr.GetString(4);
                    cr.ReplyTime = dr.GetDateTime(5);
                }
            }
            return cr;
        }
    }
}
