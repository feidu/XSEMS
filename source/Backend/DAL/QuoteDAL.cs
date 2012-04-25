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
    public class QuoteDAL
    {
        public void CreateQuote(Quote quote)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@encode", 50, quote.Encode),
                SqlUtilities.GenerateInputIntParameter("@client_id", quote.Client.Id),
                SqlUtilities.GenerateInputIntParameter("@company_id", quote.CompanyId),
                SqlUtilities.GenerateInputNVarcharParameter("@company_name", 50, quote.CompanyName),                
                SqlUtilities.GenerateInputParameter("@status", SqlDbType.Bit, quote.Status),
                SqlUtilities.GenerateInputDateTimeParameter("@quote_time", quote.QuoteTime),
                SqlUtilities.GenerateInputIntParameter("@user_id", quote.User.Id),
                SqlUtilities.GenerateInputDateTimeParameter("@create_time", quote.CreateTime),
                SqlUtilities.GenerateInputNVarcharParameter("@remark", 500, quote.Remark)
            };
            string sql = "INSERT INTO quote(encode, client_id, company_id, company_name, status, quote_time, user_id, create_time, remark) VALUES(      @encode, @client_id, @company_id, @company_name, @status, @quote_time, @user_id, @create_time, @remark)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdateQuote(Quote quote)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", quote.Id),
                SqlUtilities.GenerateInputIntParameter("@client_id", quote.Client.Id),
                SqlUtilities.GenerateInputDateTimeParameter("@quote_time", quote.QuoteTime),
                SqlUtilities.GenerateInputNVarcharParameter("@remark", 500, quote.Remark)
            };
            string sql = "UPDATE quote SET client_id = @client_id, quote_time = @quote_time, remark = @remark WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdateQuoteStatus(Quote quote)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", quote.Id),
                SqlUtilities.GenerateInputParameter("@status", SqlDbType.Bit, quote.Status)
             };
            string sql = " UPDATE quote SET status = @status WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdateQuoteAuditInfo(Quote quote)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", quote.Id),
                SqlUtilities.GenerateInputIntParameter("@audit_user_id", quote.AuditUserId),
                SqlUtilities.GenerateInputDateTimeParameter("@audit_time", quote.AuditTime)
             };
            string sql = " UPDATE quote SET audit_user_id = @audit_user_id, audit_time = @audit_time WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void DeleteQuoteById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
             };
            string sql = " UPDATE quote SET is_delete = 1 WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public Quote GetQuoteById(int id)
        {
            Quote quote = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "SELECT id, encode, client_id, company_id, company_name, status, quote_time, user_id, create_time, remark, audit_user_id, audit_time FROM quote WHERE id = @id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    quote = new Quote();
                    quote.Id = dr.GetInt32(0);
                    quote.Encode = dr.GetString(1);
                    Client client = new ClientDAL().GetClientById(dr.GetInt32(2));
                    quote.Client = client;
                    quote.CompanyId = dr.GetInt32(3);
                    quote.CompanyName = dr.GetString(4);
                    quote.Status = dr.GetBoolean(5);
                    quote.QuoteTime = dr.GetDateTime(6);
                    User user = new UserDAL().GetUserById(dr.GetInt32(7));
                    quote.User = user;
                    quote.CreateTime = dr.GetDateTime(8);
                    quote.Remark = dr.GetString(9);
                    if (!dr.IsDBNull(10))
                    {
                        quote.AuditUserId = dr.GetInt32(10);
                    }
                    if (!dr.IsDBNull(11))
                    {
                        quote.AuditTime = dr.GetDateTime(11);
                    }
                }
            }
            return quote;
        }

        public Quote GetQuoteByEncode(string encode)
        {
            Quote quote = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@encode", 50, encode)
            };
            string sql = "SELECT id, encode, client_id, company_id, company_name, status, quote_time, user_id, create_time, remark, audit_user_id, audit_time FROM quote WHERE encode = @encode";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    quote = new Quote();
                    quote.Id = dr.GetInt32(0);
                    quote.Encode = dr.GetString(1);
                    Client client = new ClientDAL().GetClientById(dr.GetInt32(2));
                    quote.Client = client;
                    quote.CompanyId = dr.GetInt32(3);
                    quote.CompanyName = dr.GetString(4);
                    quote.Status = dr.GetBoolean(5);
                    quote.QuoteTime = dr.GetDateTime(6);
                    User user = new UserDAL().GetUserById(dr.GetInt32(7));
                    quote.User = user;
                    quote.CreateTime = dr.GetDateTime(8);
                    quote.Remark = dr.GetString(9);
                    if (!dr.IsDBNull(10))
                    {
                        quote.AuditUserId = dr.GetInt32(10);
                    }
                    if (!dr.IsDBNull(11))
                    {
                        quote.AuditTime = dr.GetDateTime(11);
                    }
                }
            }
            return quote;
        }

        public PaginationQueryResult<Quote> GetQuoteByCompanyId(PaginationQueryCondition condition, int compId)
        {
            PaginationQueryResult<Quote> result = new PaginationQueryResult<Quote>();
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@company_id", compId)
            };
            string sql = "SELECT TOP " + condition.PageSize + " id, encode, client_id, company_id, company_name, status, quote_time, user_id, create_time, remark, audit_user_id, audit_time FROM quote WHERE company_id = @company_id AND is_delete = 0 ";
            if (condition.CurrentPage > 1)
            {
                sql += " AND id< (SELECT MIN(id) FROM ( SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM quote WHERE  company_id = @company_id AND is_delete = 0 ORDER BY ID DESC)AS Q) ";
            }
            sql += " ORDER BY ID DESC; SELECT COUNT(*) FROM quote WHERE company_id = @company_id AND is_delete = 0 ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    Quote quote = new Quote();
                    quote.Id = dr.GetInt32(0);
                    quote.Encode = dr.GetString(1);
                    Client client = new ClientDAL().GetClientById(dr.GetInt32(2));
                    quote.Client = client;
                    quote.CompanyId = dr.GetInt32(3);
                    quote.CompanyName = dr.GetString(4);
                    quote.Status = dr.GetBoolean(5);
                    quote.QuoteTime = dr.GetDateTime(6);
                    User user = new UserDAL().GetUserById(dr.GetInt32(7));
                    quote.User = user;
                    quote.CreateTime = dr.GetDateTime(8);
                    quote.Remark = dr.GetString(9);
                    if (!dr.IsDBNull(10))
                    {
                        quote.AuditUserId = dr.GetInt32(10);
                    }
                    if (!dr.IsDBNull(11))
                    {
                        quote.AuditTime = dr.GetDateTime(11);
                    }
                    result.Results.Add(quote);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public PaginationQueryResult<Quote> GetQuoteByParameters(PaginationQueryCondition condition, int compId, DateTime startDate, DateTime endDate, string strStatus, string keyword)
        {
            DateTime minTime = new DateTime(1999, 1, 1);
            string sqlParam = "";
            bool status = true;
            if (startDate > minTime && endDate > minTime)
            {
                sqlParam += " AND create_time BETWEEN @start_date AND @end_date";
            }
            else if (startDate > minTime && endDate <= minTime)
            {
                sqlParam += " AND create_time >= @start_date ";
            }
            else if(startDate <= minTime && endDate > minTime)
            {
                sqlParam += " AND create_time <= @end_date";
            }
            if (strStatus != "0")
            {
                status = bool.Parse(strStatus);
                if (status)
                {
                    sqlParam += " AND status = 1";
                }
                else
                {
                    sqlParam += " AND status = 0";
                }
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                sqlParam += " AND client_id IN(SELECT id FROM clients WHERE real_name LIKE '%" + keyword + "%')";
            }
            PaginationQueryResult<Quote> result = new PaginationQueryResult<Quote>();
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@company_id", compId),
                SqlUtilities.GenerateInputDateTimeParameter("@start_date", startDate),
                SqlUtilities.GenerateInputDateTimeParameter("@end_date", endDate)
            };
            string sql = "SELECT TOP " + condition.PageSize + " id, encode, client_id, company_id, company_name, status, quote_time, user_id, create_time, remark, audit_user_id, audit_time FROM quote WHERE company_id = @company_id AND is_delete = 0 " + sqlParam;
            if (condition.CurrentPage > 1)
            {
                sql += " AND id< (SELECT MIN(id) FROM ( SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM quote WHERE  company_id = @company_id AND is_delete = 0 " + sqlParam + " ORDER BY ID DESC)AS Q) ";
            }
            sql += " ORDER BY ID DESC; SELECT COUNT(*) FROM quote WHERE company_id = @company_id AND is_delete = 0 " + sqlParam;
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    Quote quote = new Quote();
                    quote.Id = dr.GetInt32(0);
                    quote.Encode = dr.GetString(1);
                    Client client = new ClientDAL().GetClientById(dr.GetInt32(2));
                    quote.Client = client;
                    quote.CompanyId = dr.GetInt32(3);
                    quote.CompanyName = dr.GetString(4);
                    quote.Status = dr.GetBoolean(5);
                    quote.QuoteTime = dr.GetDateTime(6);
                    User user = new UserDAL().GetUserById(dr.GetInt32(7));
                    quote.User = user;
                    quote.CreateTime = dr.GetDateTime(8);
                    quote.Remark = dr.GetString(9);
                    if (!dr.IsDBNull(10))
                    {
                        quote.AuditUserId = dr.GetInt32(10);
                    }
                    if (!dr.IsDBNull(11))
                    {
                        quote.AuditTime = dr.GetDateTime(11);
                    }
                    result.Results.Add(quote);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public void CreateQuoteDetail(QuoteDetail qd)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@quote_id", 50, qd.QuoteId),
                SqlUtilities.GenerateInputIntParameter("@carrier_id", qd.Carrier.Id),
                SqlUtilities.GenerateInputIntParameter("@carrier_area_id", qd.CarrierArea.Id),
                SqlUtilities.GenerateInputIntParameter("@client_id", qd.ClientId),                
                SqlUtilities.GenerateInputParameter("@status", SqlDbType.Bit, qd.Status),
                SqlUtilities.GenerateInputParameter("@discount", SqlDbType.Decimal, qd.Discount),
                SqlUtilities.GenerateInputIntParameter("@user_id", qd.UserId),
                SqlUtilities.GenerateInputDateTimeParameter("@create_time", qd.CreateTime),
                SqlUtilities.GenerateInputParameter("@preferential_gram", SqlDbType.Decimal, qd.PreferentialGram),
                SqlUtilities.GenerateInputParameter("@is_register_abate", SqlDbType.Bit, qd.IsRegisterAbate),
                SqlUtilities.GenerateInputParameter("@register_costs", SqlDbType.Decimal, qd.RegisterCosts)
            };
            string sql = "INSERT INTO quote_details(quote_id, carrier_id, carrier_area_id, client_id, status, discount, user_id, create_time, preferential_gram, is_register_abate, register_costs) VALUES(@quote_id, @carrier_id, @carrier_area_id, @client_id, @status, @discount, @user_id, @create_time, @preferential_gram,                 @is_register_abate, @register_costs)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdateQutoeDetail(QuoteDetail qd)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", qd.Id),
                SqlUtilities.GenerateInputIntParameter("@carrier_id", qd.Carrier.Id),
                SqlUtilities.GenerateInputIntParameter("@carrier_area_id", qd.CarrierArea.Id), 
                SqlUtilities.GenerateInputParameter("@discount", SqlDbType.Decimal, qd.Discount),
                SqlUtilities.GenerateInputIntParameter("@user_id", qd.UserId),
                SqlUtilities.GenerateInputParameter("@preferential_gram", SqlDbType.Decimal, qd.PreferentialGram),
                SqlUtilities.GenerateInputParameter("@is_register_abate", SqlDbType.Bit, qd.IsRegisterAbate),
                SqlUtilities.GenerateInputParameter("@register_costs", SqlDbType.Decimal, qd.RegisterCosts)
            };
            string sql = "UPDATE quote_details SET carrier_id = @carrier_id, carrier_area_id = @carrier_area_id, discount = @discount, user_id =        @user_id, preferential_gram = @preferential_gram, is_register_abate = @is_register_abate, register_costs = @register_costs WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdateQutoeDetailStatusByQuoteId(int quoteId)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@quote_id", quoteId)
            };
            string sql = "UPDATE quote_details SET status = 1 WHERE quote_id = @quote_id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void DeleteQuoteDetailById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "Update quote_details SET is_delete = 1 where id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void DeleteQuoteDetailByQuoteId(int quoteId)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@quote_id", quoteId)
            };
            string sql = "Update quote_details SET is_delete = 1 where quote_id = @quote_id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public QuoteDetail GetQuoteDetailById(int id)
        {
            QuoteDetail qd = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "SELECT id, quote_id, carrier_id, carrier_area_id, discount, preferential_gram, is_register_abate, register_costs FROM quote_details WHERE id = @id AND is_delete = 0";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    qd = new QuoteDetail();
                    qd.Id = dr.GetInt32(0);
                    qd.QuoteId = dr.GetInt32(1);
                    Carrier carrier = new CarrierDAL().GetCarrierById(dr.GetInt32(2));
                    qd.Carrier = carrier;
                    CarrierArea ca = new CarrierAreaDAL().GetCarrierAreaById(dr.GetInt32(3));
                    qd.CarrierArea = ca;
                    qd.Discount = dr.GetDecimal(4);
                    qd.PreferentialGram = dr.GetDecimal(5);
                    qd.IsRegisterAbate = dr.GetBoolean(6);
                    qd.RegisterCosts = dr.GetDecimal(7);
                }
            }
            return qd;
        }

        public List<QuoteDetail> GetQuoteDetailByQuoteId(int id)
        {
            List<QuoteDetail> result = new List<QuoteDetail>();
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@quote_id", id)
            };
            string sql = "SELECT id, quote_id, carrier_id, carrier_area_id, discount, preferential_gram, is_register_abate, register_costs FROM quote_details WHERE quote_id = @quote_id AND is_delete = 0";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    QuoteDetail qd = new QuoteDetail();
                    qd.Id = dr.GetInt32(0);
                    qd.QuoteId = dr.GetInt32(1);
                    Carrier carrier = new CarrierDAL().GetCarrierById(dr.GetInt32(2));
                    qd.Carrier = carrier;
                    CarrierArea ca = new CarrierAreaDAL().GetCarrierAreaById(dr.GetInt32(3));
                    qd.CarrierArea = ca;
                    qd.Discount = dr.GetDecimal(4);
                    qd.PreferentialGram = dr.GetDecimal(5);
                    qd.IsRegisterAbate = dr.GetBoolean(6);
                    qd.RegisterCosts = dr.GetDecimal(7);
                    result.Add(qd);
                }
            }
            return result;
        }
         
    }
}
    

