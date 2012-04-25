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
    public class LiabilityDAL
    {
        public void CreateLiability(Liability ly)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@encode", 50, ly.Encode),
                SqlUtilities.GenerateInputNVarcharParameter("@order_encode", 50, ly.Order.Encode),
                SqlUtilities.GenerateInputIntParameter("@company_id", ly.CompanyId),
                SqlUtilities.GenerateInputParameter("@event_type", SqlDbType.TinyInt, (byte)ly.EventType),
                SqlUtilities.GenerateInputParameter("@status", SqlDbType.TinyInt, (byte)ly.Status),
                SqlUtilities.GenerateInputNVarcharParameter("@fill_user", 50, ly.FillUser),
                SqlUtilities.GenerateInputDateTimeParameter("@fill_time", ly.FillTime),
                SqlUtilities.GenerateInputNVarcharParameter("@create_user", 50, ly.CreateUser),
                SqlUtilities.GenerateInputDateTimeParameter("@create_time", ly.CreateTime),
                SqlUtilities.GenerateInputNVarcharParameter("@detail", 2000, ly.Detail),
                SqlUtilities.GenerateInputNVarcharParameter("@result", 1000, ly.Result),
                SqlUtilities.GenerateInputNVarcharParameter("@client_name", 50, ly.ClientName),
                SqlUtilities.GenerateInputNVarcharParameter("@currency_type", 50, ly.CurrencyType)
            };
            string sql = "INSERT INTO liabilities (encode, order_encode, company_id, event_type, status, fill_user, fill_time, create_user, create_time, detail, result, client_name, currency_type) VALUES(@encode, @order_encode, @company_id, @event_type, @status, @fill_user, @fill_time,      @create_user, @create_time, @detail, @result, @client_name, @currency_type)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdateLiability(Liability ly)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", ly.Id),
                SqlUtilities.GenerateInputNVarcharParameter("@order_encode", 50, ly.Order.Encode),
                SqlUtilities.GenerateInputIntParameter("@company_id", ly.CompanyId),
                SqlUtilities.GenerateInputParameter("@event_type", SqlDbType.TinyInt, (byte)ly.EventType),
                SqlUtilities.GenerateInputNVarcharParameter("@bar_code", 50, ly.BarCode),
                SqlUtilities.GenerateInputParameter("@status", SqlDbType.TinyInt, (byte)ly.Status),
                SqlUtilities.GenerateInputNVarcharParameter("@fill_user", 50, ly.FillUser),
                SqlUtilities.GenerateInputDateTimeParameter("@fill_time", ly.FillTime),
                SqlUtilities.GenerateInputNVarcharParameter("@detail", 2000, ly.Detail),
                SqlUtilities.GenerateInputNVarcharParameter("@result", 1000, ly.Result),
                SqlUtilities.GenerateInputNVarcharParameter("@currency_type", 50, ly.CurrencyType),
                SqlUtilities.GenerateInputParameter("@correct_status", SqlDbType.TinyInt, ly.CorrectStatus),
                SqlUtilities.GenerateInputNVarcharParameter("@client_name", 50, ly.ClientName),
                SqlUtilities.GenerateInputParameter("@total_money", SqlDbType.Decimal, ly.TotalMoney),
                SqlUtilities.GenerateInputParameter("@zr_dt_money", SqlDbType.Decimal, ly.ZrDtMoney),
                SqlUtilities.GenerateInputParameter("@zr_ur_money", SqlDbType.Decimal, ly.ZrUrMoney),
                SqlUtilities.GenerateInputParameter("@client_pt_eadu", SqlDbType.Decimal, ly.ClientPtEadu),
                SqlUtilities.GenerateInputParameter("@eadu_pt_client", SqlDbType.Decimal, ly.EaduPtClient),
                SqlUtilities.GenerateInputParameter("@carrier_pt_eadu", SqlDbType.Decimal, ly.CarrierPtEadu),
                SqlUtilities.GenerateInputParameter("@eadu_pt_carrier", SqlDbType.Decimal, ly.EaduPtCarrier),
                SqlUtilities.GenerateInputParameter("@jl_dt_money", SqlDbType.Decimal, ly.JlDtMoney),
                SqlUtilities.GenerateInputParameter("@jl_ur_money", SqlDbType.Decimal, ly.JlUrMoney),                
                SqlUtilities.GenerateInputNVarcharParameter("@zr_department", 50, ly.ZrDepartment),
                SqlUtilities.GenerateInputNVarcharParameter("@zr_user", 50, ly.ZrUser),
                SqlUtilities.GenerateInputNVarcharParameter("@carrier_name", 50, ly.CarrierName),
                SqlUtilities.GenerateInputNVarcharParameter("@jl_department", 50, ly.JlDepartment),
                SqlUtilities.GenerateInputNVarcharParameter("@jl_user", 50, ly.JlUser),
                SqlUtilities.GenerateInputNVarcharParameter("@liability_user", 50, ly.LiabilityUser),
                SqlUtilities.GenerateInputNVarcharParameter("@correct_user", 50, ly.CorrectUser),
                SqlUtilities.GenerateInputNVarcharParameter("@finance_user", 50, ly.FinanceUser),
                SqlUtilities.GenerateInputNVarcharParameter("@cashier_user", 50, ly.CashierUser)
            };
            string sql = "UPDATE liabilities SET company_id = @company_id, order_encode = @order_encode, bar_code = @bar_code, currency_type =          @currency_type, event_type = @event_type, correct_status = @correct_status, status = @status, fill_user = @fill_user, fill_time = @fill_time, detail = @detail, result = @result, total_money = @total_money, zr_department = @zr_department, zr_dt_money = @zr_dt_money, zr_user = @zr_user, zr_ur_money = @zr_ur_money, client_name = @client_name, client_pt_eadu = @client_pt_eadu, eadu_pt_client = @eadu_pt_client, carrier_name =              @carrier_name, carrier_pt_eadu = @carrier_pt_eadu, eadu_pt_carrier = @eadu_pt_carrier, jl_department = @jl_department, jl_dt_money = @jl_dt_money, jl_user = @jl_user, jl_ur_money = @jl_ur_money, liability_user = @liability_user, correct_user = @correct_user, finance_user = @finance_user, cashier_user = @cashier_user FROM liabilities WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void DeleteLiabilityById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "UPDATE liabilities SET is_delete = 1 WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public Liability GetLiabilityByEncode(string encode)
        {
            Liability ly = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@encode", 50, encode)
            };
            string sql = "SELECT id, company_id, encode, order_encode, bar_code, currency_type, create_user, create_time, event_type, correct_status, status, fill_user, fill_time, detail, result, total_money, zr_department, zr_dt_money, zr_user, zr_ur_money, client_name, client_pt_eadu, eadu_pt_client, carrier_name, carrier_pt_eadu, eadu_pt_carrier, jl_department, jl_dt_money, jl_user, jl_ur_money, liability_user, correct_user, finance_user, cashier_user FROM liabilities WHERE encode = @encode";
            using(SqlDataReader dr=SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    ly = new Liability();
                    ly.Id = dr.GetInt32(0);
                    ly.CompanyId = dr.GetInt32(1);
                    ly.Encode = dr.GetString(2);
                    Order order = new OrderDAL().GetOrderByEncode(dr.GetString(3));
                    ly.Order = order;
                    if (!dr.IsDBNull(4))
                    {
                        ly.BarCode = dr.GetString(4);
                    }
                    if (!dr.IsDBNull(5))
                    {
                        ly.CurrencyType = dr.GetString(5);
                    }
                    ly.CreateUser = dr.GetString(6);
                    ly.CreateTime = dr.GetDateTime(7);
                    ly.EventType = EnumConvertor.ConvertToLiabilityEventType(dr.GetByte(8));
                    ly.CorrectStatus = dr.GetBoolean(9);
                    ly.Status = EnumConvertor.ConvertToLiabilityStatus(dr.GetByte(10));
                    ly.FillUser = dr.GetString(11);
                    ly.FillTime = dr.GetDateTime(12);
                    ly.Detail = dr.GetString(13);
                    ly.Result = dr.GetString(14);
                    ly.TotalMoney = dr.GetDecimal(15);
                    if (!dr.IsDBNull(16))
                    {
                        ly.ZrDepartment = dr.GetString(16);
                    }
                    if (!dr.IsDBNull(17))
                    {
                        ly.ZrDtMoney = dr.GetDecimal(17);
                    }
                    if (!dr.IsDBNull(18))
                    {
                        ly.ZrUser = dr.GetString(18);
                    }
                    if (!dr.IsDBNull(19))
                    {
                        ly.ZrUrMoney = dr.GetDecimal(19);
                    }
                    ly.ClientName = dr.GetString(20);
                    ly.ClientPtEadu = dr.GetDecimal(21);
                    ly.EaduPtClient = dr.GetDecimal(22);
                    if (!dr.IsDBNull(23))
                    {
                        ly.CarrierName = dr.GetString(23);
                    }
                    ly.CarrierPtEadu = dr.GetDecimal(24);
                    ly.EaduPtCarrier = dr.GetDecimal(25);
                    if (!dr.IsDBNull(26))
                    {
                        ly.JlDepartment = dr.GetString(26);
                    }
                    if (!dr.IsDBNull(27))
                    {
                        ly.JlDtMoney = dr.GetDecimal(27);
                    }
                    if (!dr.IsDBNull(28))
                    {
                        ly.JlUser = dr.GetString(28);
                    }
                    if (!dr.IsDBNull(29))
                    {
                        ly.JlUrMoney = dr.GetDecimal(29);
                    }
                    if (!dr.IsDBNull(30))
                    {
                        ly.LiabilityUser = dr.GetString(30);
                    }
                    if (!dr.IsDBNull(31))
                    {
                        ly.CorrectUser = dr.GetString(31);
                    }
                    if (!dr.IsDBNull(32))
                    {
                        ly.FinanceUser = dr.GetString(32);
                    }
                    if (!dr.IsDBNull(33))
                    {
                        ly.CashierUser = dr.GetString(33);
                    }
                }
            }
            return ly;
        }

        public Liability GetLiabilityById(int id)
        {
            Liability ly = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "SELECT id, company_id, encode, order_encode, bar_code, currency_type, create_user, create_time, event_type, correct_status, status, fill_user, fill_time, detail, result, total_money, zr_department, zr_dt_money, zr_user, zr_ur_money, client_name, client_pt_eadu, eadu_pt_client, carrier_name, carrier_pt_eadu, eadu_pt_carrier, jl_department, jl_dt_money, jl_user, jl_ur_money, liability_user, correct_user, finance_user, cashier_user FROM liabilities WHERE id = @id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    ly = new Liability();
                    ly.Id = dr.GetInt32(0);
                    ly.CompanyId = dr.GetInt32(1);
                    ly.Encode = dr.GetString(2);
                    Order order = new OrderDAL().GetOrderByEncode(dr.GetString(3));
                    ly.Order = order;
                    if (!dr.IsDBNull(4))
                    {
                        ly.BarCode = dr.GetString(4);
                    }
                    if (!dr.IsDBNull(5))
                    {
                        ly.CurrencyType = dr.GetString(5);
                    }
                    ly.CreateUser = dr.GetString(6);
                    ly.CreateTime = dr.GetDateTime(7);
                    ly.EventType = EnumConvertor.ConvertToLiabilityEventType(dr.GetByte(8));
                    ly.CorrectStatus = dr.GetBoolean(9);
                    ly.Status = EnumConvertor.ConvertToLiabilityStatus(dr.GetByte(10));
                    ly.FillUser = dr.GetString(11);
                    ly.FillTime = dr.GetDateTime(12);
                    ly.Detail = dr.GetString(13);
                    ly.Result = dr.GetString(14);
                    ly.TotalMoney = dr.GetDecimal(15);
                    if (!dr.IsDBNull(16))
                    {
                        ly.ZrDepartment = dr.GetString(16);
                    }
                    if (!dr.IsDBNull(17))
                    {
                        ly.ZrDtMoney = dr.GetDecimal(17);
                    }
                    if (!dr.IsDBNull(18))
                    {
                        ly.ZrUser = dr.GetString(18);
                    }
                    if (!dr.IsDBNull(19))
                    {
                        ly.ZrUrMoney = dr.GetDecimal(19);
                    }
                    ly.ClientName = dr.GetString(20);
                    ly.ClientPtEadu = dr.GetDecimal(21);
                    ly.EaduPtClient = dr.GetDecimal(22);
                    if (!dr.IsDBNull(23))
                    {
                        ly.CarrierName = dr.GetString(23);
                    }
                    ly.CarrierPtEadu = dr.GetDecimal(24);
                    ly.EaduPtCarrier = dr.GetDecimal(25);
                    if (!dr.IsDBNull(26))
                    {
                        ly.JlDepartment = dr.GetString(26);
                    }
                    if (!dr.IsDBNull(27))
                    {
                        ly.JlDtMoney = dr.GetDecimal(27);
                    }
                    if (!dr.IsDBNull(28))
                    {
                        ly.JlUser = dr.GetString(28);
                    }
                    if (!dr.IsDBNull(29))
                    {
                        ly.JlUrMoney = dr.GetDecimal(29);
                    }
                    if (!dr.IsDBNull(30))
                    {
                        ly.LiabilityUser = dr.GetString(30);
                    }
                    if (!dr.IsDBNull(31))
                    {
                        ly.CorrectUser = dr.GetString(31);
                    }
                    if (!dr.IsDBNull(32))
                    {
                        ly.FinanceUser = dr.GetString(32);
                    }
                    if (!dr.IsDBNull(33))
                    {
                        ly.CashierUser = dr.GetString(33);
                    }
                }
            }
            return ly;
        }

        public PaginationQueryResult<Liability> GetLiabilityByCompanyId(PaginationQueryCondition condition, int companyId)
        {
            PaginationQueryResult<Liability> result = new PaginationQueryResult<Liability>();
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@company_id", companyId)
            };
            string sql = "SELECT TOP " + condition.PageSize + " id, company_id, encode, order_encode, bar_code, currency_type, create_user, create_time, event_type, correct_status, status, fill_user, fill_time, detail, result, total_money, zr_department, zr_dt_money, zr_user, zr_ur_money, client_name, client_pt_eadu, eadu_pt_client, carrier_name, carrier_pt_eadu, eadu_pt_carrier, jl_department, jl_dt_money, jl_user, jl_ur_money, liability_user, correct_user, finance_user, cashier_user FROM liabilities WHERE company_id = @company_id AND is_delete = 0";
            if (condition.CurrentPage > 1)
            {
                sql += " AND id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM liabilities WHERE company_id = @company_id AND is_delete = 0 ORDER BY id DESC) AS L)";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM liabilities WHERE company_id = @company_id AND is_delete = 0";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    Liability ly = new Liability();
                    ly.Id = dr.GetInt32(0);
                    ly.CompanyId = dr.GetInt32(1);
                    ly.Encode = dr.GetString(2);
                    Order order = new OrderDAL().GetOrderByEncode(dr.GetString(3));
                    ly.Order = order;
                    if (!dr.IsDBNull(4))
                    {
                        ly.BarCode = dr.GetString(4);
                    }
                    if (!dr.IsDBNull(5))
                    {
                        ly.CurrencyType = dr.GetString(5);
                    }
                    ly.CreateUser = dr.GetString(6);
                    ly.CreateTime = dr.GetDateTime(7);
                    ly.EventType = EnumConvertor.ConvertToLiabilityEventType(dr.GetByte(8));
                    ly.CorrectStatus = dr.GetBoolean(9);
                    ly.Status = EnumConvertor.ConvertToLiabilityStatus(dr.GetByte(10));
                    ly.FillUser = dr.GetString(11);
                    ly.FillTime = dr.GetDateTime(12);
                    ly.Detail = dr.GetString(13);
                    ly.Result = dr.GetString(14);
                    ly.TotalMoney = dr.GetDecimal(15);
                    if (!dr.IsDBNull(16))
                    {
                        ly.ZrDepartment = dr.GetString(16);
                    }
                    if (!dr.IsDBNull(17))
                    {
                        ly.ZrDtMoney = dr.GetDecimal(17);
                    }
                    if (!dr.IsDBNull(18))
                    {
                        ly.ZrUser = dr.GetString(18);
                    }
                    if (!dr.IsDBNull(19))
                    {
                        ly.ZrUrMoney = dr.GetDecimal(19);
                    }
                    ly.ClientName = dr.GetString(20);
                    ly.ClientPtEadu = dr.GetDecimal(21);
                    ly.EaduPtClient = dr.GetDecimal(22);
                    if (!dr.IsDBNull(23))
                    {
                        ly.CarrierName = dr.GetString(23);
                    }
                    ly.CarrierPtEadu = dr.GetDecimal(24);
                    ly.EaduPtCarrier = dr.GetDecimal(25);
                    if (!dr.IsDBNull(26))
                    {
                        ly.JlDepartment = dr.GetString(26);
                    }
                    if (!dr.IsDBNull(27))
                    {
                        ly.JlDtMoney = dr.GetDecimal(27);
                    }
                    if (!dr.IsDBNull(28))
                    {
                        ly.JlUser = dr.GetString(28);
                    }
                    if (!dr.IsDBNull(29))
                    {
                        ly.JlUrMoney = dr.GetDecimal(29);
                    }
                    if (!dr.IsDBNull(30))
                    {
                        ly.LiabilityUser = dr.GetString(30);
                    }
                    if (!dr.IsDBNull(31))
                    {
                        ly.CorrectUser = dr.GetString(31);
                    }
                    if (!dr.IsDBNull(32))
                    {
                        ly.FinanceUser = dr.GetString(32);
                    }
                    if (!dr.IsDBNull(33))
                    {
                        ly.CashierUser = dr.GetString(33);
                    }
                    result.Results.Add(ly);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public PaginationQueryResult<Liability> GetLiabilityByCompanyIdAndDate(PaginationQueryCondition condition, int companyId, DateTime startDate, DateTime endDate)
        {
            PaginationQueryResult<Liability> result = new PaginationQueryResult<Liability>();
            DateTime minTime = new DateTime(1999, 1, 1);
            string sqlParam = "";
            if (companyId > 0)
            {
                sqlParam += " AND company_id = @company_id";
            }
            if (startDate > minTime && endDate > minTime)
            {
                sqlParam = " AND create_time BETWEEN @start_date AND @end_date";
            }
            else if (startDate > minTime && endDate <= minTime)
            {
                sqlParam = " AND create_time >= @start_date ";
            }
            else if(startDate <= minTime && endDate > minTime)
            {
                sqlParam = " AND create_time <= @end_date";
            }

            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@company_id", companyId),
                SqlUtilities.GenerateInputDateTimeParameter("@start_date", startDate),
                SqlUtilities.GenerateInputDateTimeParameter("@end_date", endDate)
            };
            string sql = "SELECT TOP " + condition.PageSize + " id, company_id, encode, order_encode, bar_code, currency_type, create_user, create_time, event_type, correct_status, status, fill_user, fill_time, detail, result, total_money, zr_department, zr_dt_money, zr_user, zr_ur_money, client_name, client_pt_eadu, eadu_pt_client, carrier_name, carrier_pt_eadu, eadu_pt_carrier, jl_department, jl_dt_money, jl_user, jl_ur_money, liability_user, correct_user, finance_user, cashier_user FROM liabilities WHERE is_delete = 0"+sqlParam;
            if (condition.CurrentPage > 1)
            {
                sql += " AND id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM liabilities WHERE is_delete = 0 " + sqlParam + " ORDER BY id DESC) AS L)";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM liabilities WHERE is_delete = 0"+sqlParam;
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    Liability ly = new Liability();
                    ly.Id = dr.GetInt32(0);
                    ly.CompanyId = dr.GetInt32(1);
                    ly.Encode = dr.GetString(2);
                    Order order = new OrderDAL().GetOrderByEncode(dr.GetString(3));
                    ly.Order = order;
                    if (!dr.IsDBNull(4))
                    {
                        ly.BarCode = dr.GetString(4);
                    }
                    if (!dr.IsDBNull(5))
                    {
                        ly.CurrencyType = dr.GetString(5);
                    }
                    ly.CreateUser = dr.GetString(6);
                    ly.CreateTime = dr.GetDateTime(7);
                    ly.EventType = EnumConvertor.ConvertToLiabilityEventType(dr.GetByte(8));
                    ly.CorrectStatus = dr.GetBoolean(9);
                    ly.Status = EnumConvertor.ConvertToLiabilityStatus(dr.GetByte(10));
                    ly.FillUser = dr.GetString(11);
                    ly.FillTime = dr.GetDateTime(12);
                    ly.Detail = dr.GetString(13);
                    ly.Result = dr.GetString(14);
                    ly.TotalMoney = dr.GetDecimal(15);
                    if (!dr.IsDBNull(16))
                    {
                        ly.ZrDepartment = dr.GetString(16);
                    }
                    if (!dr.IsDBNull(17))
                    {
                        ly.ZrDtMoney = dr.GetDecimal(17);
                    }
                    if (!dr.IsDBNull(18))
                    {
                        ly.ZrUser = dr.GetString(18);
                    }
                    if (!dr.IsDBNull(19))
                    {
                        ly.ZrUrMoney = dr.GetDecimal(19);
                    }
                    ly.ClientName = dr.GetString(20);
                    ly.ClientPtEadu = dr.GetDecimal(21);
                    ly.EaduPtClient = dr.GetDecimal(22);
                    if (!dr.IsDBNull(23))
                    {
                        ly.CarrierName = dr.GetString(23);
                    }
                    ly.CarrierPtEadu = dr.GetDecimal(24);
                    ly.EaduPtCarrier = dr.GetDecimal(25);
                    if (!dr.IsDBNull(26))
                    {
                        ly.JlDepartment = dr.GetString(26);
                    }
                    if (!dr.IsDBNull(27))
                    {
                        ly.JlDtMoney = dr.GetDecimal(27);
                    }
                    if (!dr.IsDBNull(28))
                    {
                        ly.JlUser = dr.GetString(28);
                    }
                    if (!dr.IsDBNull(29))
                    {
                        ly.JlUrMoney = dr.GetDecimal(29);
                    }
                    if (!dr.IsDBNull(30))
                    {
                        ly.LiabilityUser = dr.GetString(30);
                    }
                    if (!dr.IsDBNull(31))
                    {
                        ly.CorrectUser = dr.GetString(31);
                    }
                    if (!dr.IsDBNull(32))
                    {
                        ly.FinanceUser = dr.GetString(32);
                    }
                    if (!dr.IsDBNull(33))
                    {
                        ly.CashierUser = dr.GetString(33);
                    }
                    result.Results.Add(ly);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public PaginationQueryResult<Liability> GetFinishedLiabilityByParameters(PaginationQueryCondition condition, int companyId, DateTime startDate, DateTime endDate)
        {
            PaginationQueryResult<Liability> result = new PaginationQueryResult<Liability>();
            DateTime minTime = new DateTime(1999, 1, 1);
            string sqlParam = "";
            if (companyId > 0)
            {
                sqlParam += " AND company_id = @company_id";
            }
            if (startDate > minTime && endDate > minTime)
            {
                sqlParam = " AND create_time BETWEEN @start_date AND @end_date";
            }
            else if (startDate > minTime && endDate <= minTime)
            {
                sqlParam = " AND create_time >= @start_date ";
            }
            else if (startDate <= minTime && endDate > minTime)
            {
                sqlParam = " AND create_time <= @end_date";
            }

            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@company_id", companyId),
                SqlUtilities.GenerateInputDateTimeParameter("@start_date", startDate),
                SqlUtilities.GenerateInputDateTimeParameter("@end_date", endDate)
            };
            string sql = "SELECT TOP " + condition.PageSize + " id, company_id, encode, order_encode, bar_code, currency_type, create_user, create_time, event_type, correct_status, status, fill_user, fill_time, detail, result, total_money, zr_department, zr_dt_money, zr_user, zr_ur_money, client_name, client_pt_eadu, eadu_pt_client, carrier_name, carrier_pt_eadu, eadu_pt_carrier, jl_department, jl_dt_money, jl_user, jl_ur_money, liability_user, correct_user, finance_user, cashier_user FROM liabilities WHERE is_delete = 0 AND status = 5" + sqlParam;
            if (condition.CurrentPage > 1)
            {
                sql += " AND id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM liabilities WHERE is_delete = 0 AND status = 5 " + sqlParam + " ORDER BY id DESC) AS L)";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM liabilities WHERE is_delete = 0 AND status = 5" + sqlParam;
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    Liability ly = new Liability();
                    ly.Id = dr.GetInt32(0);
                    ly.CompanyId = dr.GetInt32(1);
                    ly.Encode = dr.GetString(2);
                    Order order = new OrderDAL().GetOrderByEncode(dr.GetString(3));
                    ly.Order = order;
                    if (!dr.IsDBNull(4))
                    {
                        ly.BarCode = dr.GetString(4);
                    }
                    if (!dr.IsDBNull(5))
                    {
                        ly.CurrencyType = dr.GetString(5);
                    }
                    ly.CreateUser = dr.GetString(6);
                    ly.CreateTime = dr.GetDateTime(7);
                    ly.EventType = EnumConvertor.ConvertToLiabilityEventType(dr.GetByte(8));
                    ly.CorrectStatus = dr.GetBoolean(9);
                    ly.Status = EnumConvertor.ConvertToLiabilityStatus(dr.GetByte(10));
                    ly.FillUser = dr.GetString(11);
                    ly.FillTime = dr.GetDateTime(12);
                    ly.Detail = dr.GetString(13);
                    ly.Result = dr.GetString(14);
                    ly.TotalMoney = dr.GetDecimal(15);
                    if (!dr.IsDBNull(16))
                    {
                        ly.ZrDepartment = dr.GetString(16);
                    }
                    if (!dr.IsDBNull(17))
                    {
                        ly.ZrDtMoney = dr.GetDecimal(17);
                    }
                    if (!dr.IsDBNull(18))
                    {
                        ly.ZrUser = dr.GetString(18);
                    }
                    if (!dr.IsDBNull(19))
                    {
                        ly.ZrUrMoney = dr.GetDecimal(19);
                    }
                    ly.ClientName = dr.GetString(20);
                    ly.ClientPtEadu = dr.GetDecimal(21);
                    ly.EaduPtClient = dr.GetDecimal(22);
                    if (!dr.IsDBNull(23))
                    {
                        ly.CarrierName = dr.GetString(23);
                    }
                    ly.CarrierPtEadu = dr.GetDecimal(24);
                    ly.EaduPtCarrier = dr.GetDecimal(25);
                    if (!dr.IsDBNull(26))
                    {
                        ly.JlDepartment = dr.GetString(26);
                    }
                    if (!dr.IsDBNull(27))
                    {
                        ly.JlDtMoney = dr.GetDecimal(27);
                    }
                    if (!dr.IsDBNull(28))
                    {
                        ly.JlUser = dr.GetString(28);
                    }
                    if (!dr.IsDBNull(29))
                    {
                        ly.JlUrMoney = dr.GetDecimal(29);
                    }
                    if (!dr.IsDBNull(30))
                    {
                        ly.LiabilityUser = dr.GetString(30);
                    }
                    if (!dr.IsDBNull(31))
                    {
                        ly.CorrectUser = dr.GetString(31);
                    }
                    if (!dr.IsDBNull(32))
                    {
                        ly.FinanceUser = dr.GetString(32);
                    }
                    if (!dr.IsDBNull(33))
                    {
                        ly.CashierUser = dr.GetString(33);
                    }
                    result.Results.Add(ly);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }
    }
}
