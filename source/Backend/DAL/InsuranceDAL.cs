using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.Models.Pagination;
using Backend.Utilities;
using System.Data;
using System.Data.SqlClient;

namespace Backend.DAL
{
    public class InsuranceDAL
    {
        public void CreateInsurance(Insurance insurance)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@order_id", insurance.OrderId),
                SqlUtilities.GenerateInputIntParameter("@order_detail_id", insurance.OrderDetailId),
                SqlUtilities.GenerateInputParameter("@insure_worth", SqlDbType.Decimal, insurance.InsureWorth),
                SqlUtilities.GenerateInputParameter("@insure_costs", SqlDbType.Decimal, insurance.InsureCosts),
                SqlUtilities.GenerateInputDateTimeParameter("@create_time", insurance.CreateTime),
                SqlUtilities.GenerateInputIntParameter("@create_user_id", insurance.CreateUserId),
                SqlUtilities.GenerateInputNVarcharParameter("@client_name", 50, insurance.ClientName),
                SqlUtilities.GenerateInputNVarcharParameter("@carrier_name", 50, insurance.CarrierName)
            };
            string sql = "INSERT INTO insurance(order_id, order_detail_id, insure_worth, insure_costs, create_time, create_user_id, client_name, carrier_name) VALUES(@order_id, @order_detail_id, @insure_worth, @insure_costs, @create_time, @create_user_id, @client_name, @carrier_name)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdateInsurance(Insurance insurance)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", insurance.Id),
                SqlUtilities.GenerateInputParameter("@insure_worth", SqlDbType.Decimal, insurance.InsureWorth),
                SqlUtilities.GenerateInputParameter("@insure_costs", SqlDbType.Decimal, insurance.InsureCosts)
            };
            string sql = "UPDATE insurance SET insure_worth =@insure_worth, insure_costs = @insure_costs WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void DeleteInsuranceById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "UPDATE insurance SET is_delete = 1 WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public Insurance GetInsuranceById(int id)
        {
            Insurance insurance = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "SELECT id, order_id, order_detail_id, insure_worth, insure_costs FROM insurance WHERE id = @id AND is_delete = 0";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    insurance = new Insurance();
                    insurance.Id = dr.GetInt32(0);
                    insurance.OrderId = dr.GetInt32(1);
                    insurance.OrderDetailId = dr.GetInt32(2);
                    insurance.InsureWorth = dr.GetDecimal(3);
                    insurance.InsureCosts = dr.GetDecimal(4);
                }
            }
            return insurance;
        }

        public Insurance GetInsuranceByOrderDetailId(int id)
        {
            Insurance insurance = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@order_detail_id", id)
            };
            string sql = "SELECT id, order_id, order_detail_id, insure_worth, insure_costs FROM insurance WHERE order_detail_id = @order_detail_id AND is_delete = 0";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    insurance = new Insurance();
                    insurance.Id = dr.GetInt32(0);
                    insurance.OrderId = dr.GetInt32(1);
                    insurance.OrderDetailId = dr.GetInt32(2);
                    insurance.InsureWorth = dr.GetDecimal(3);
                    insurance.InsureCosts = dr.GetDecimal(4);
                }
            }
            return insurance;
        }

        public PaginationQueryResult<Insurance> GetInsurance(PaginationQueryCondition condition)
        {
            PaginationQueryResult<Insurance> result = new PaginationQueryResult<Insurance>();
            string sql = "SELECT TOP " + condition.PageSize +" I.id, I.create_time, O.encode, OD.bar_code, OD.carrier_encode, O.client_id,              I.insure_worth FROM insurance AS I JOIN orders AS O ON I.order_id = O.id                                                                             JOIN order_details AS OD ON OD.id = I.order_detail_id WHERE I.is_delete = 0";
            if (condition.CurrentPage > 1)
            {
                sql += " AND I.id < (SELECT MIN(id) FROM (SELECT TOP "+condition.PageSize*(condition.CurrentPage - 1)+" I.id FROM insurance AS I WHERE I.is_delete = 0 ORDER BY I.id DESC) AS E ) ";
            }
            sql += " ORDER BY I.id DESC; SELECT COUNT(*) FROM insurance AS I JOIN orders AS O ON I.order_id = O.id JOIN order_details AS OD ON OD.id = I.order_detail_id WHERE I.is_delete = 0 ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    Insurance insurance = new Insurance();
                    insurance.Id = dr.GetInt32(0);
                    insurance.CreateTime = dr.GetDateTime(1);
                    insurance.OrderEncode = dr.GetString(2);
                    insurance.OrderDetailBarCode = dr.GetString(3);
                    insurance.CarrierName = new CarrierDAL().GetCarrierByEncode(dr.GetString(4)).Name;
                    insurance.ClientName=new ClientDAL().GetClientById(dr.GetInt32(5)).RealName;
                    insurance.InsureWorth = dr.GetDecimal(6);
                    result.Results.Add(insurance);
                }
            }
            return result;            
        }

        public PaginationQueryResult<Insurance> GetInsuranceByParameters(PaginationQueryCondition condition, DateTime startDate, DateTime endDate, decimal insureWorth, string searchKey)
        {
            PaginationQueryResult<Insurance> result = new PaginationQueryResult<Insurance>();

            DateTime minTime = new DateTime(1999, 1, 1);
            string sqlParam = "";
            if (startDate > minTime && endDate > minTime)
            {
                sqlParam += " AND I.create_time BETWEEN @start_date AND @end_date";
            }
            else if (startDate > minTime && endDate <= minTime)
            {
                sqlParam += " AND I.create_time >= @start_date ";
            }
            else if(startDate<=minTime && endDate >minTime)
            {
                sqlParam += " AND I.create_time <= @end_date";
            }

            if (insureWorth > 0)
            {
                sqlParam += " AND I.insure_worth > @insure_worth";
            }
            if (!string.IsNullOrEmpty(searchKey))
            {
                sqlParam += " AND O.encode LIKE '%" + searchKey + "%' OR OD.bar_code LIKE '%" + searchKey + "%' OR I.carrier_name LIKE '%" + searchKey + "%' OR I.client_name LIKE '%" + searchKey + "%'";
            }
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputDateTimeParameter("@start_date", startDate),
                SqlUtilities.GenerateInputDateTimeParameter("@end_date", endDate),
                SqlUtilities.GenerateInputParameter("@insure_worth", SqlDbType.Decimal, insureWorth)
            };

            string sql = "SELECT TOP " + condition.PageSize + " I.id, I.create_time, O.encode, OD.bar_code, OD.carrier_encode, O.client_id,              I.insure_worth FROM insurance AS I JOIN orders AS O ON I.order_id = O.id                                                                             JOIN order_details AS OD ON OD.id = I.order_detail_id WHERE I.is_delete = 0" + sqlParam;
            if (condition.CurrentPage > 1)
            {
                sql += " AND I.id < (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " I.id FROM insurance AS I WHERE I.is_delete = 0 " + sqlParam + " ORDER BY I.id DESC) AS E ) ";
            }
            sql += " ORDER BY I.id DESC; SELECT COUNT(*) FROM insurance AS I JOIN orders AS O ON I.order_id = O.id JOIN order_details AS OD ON OD.id = I.order_detail_id WHERE I.is_delete = 0" + sqlParam;
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    Insurance insurance = new Insurance();
                    insurance.Id = dr.GetInt32(0);
                    insurance.CreateTime = dr.GetDateTime(1);
                    insurance.OrderEncode = dr.GetString(2);
                    insurance.OrderDetailBarCode = dr.GetString(3);
                    insurance.CarrierName = new CarrierDAL().GetCarrierByEncode(dr.GetString(4)).Name;
                    insurance.ClientName = new ClientDAL().GetClientById(dr.GetInt32(5)).RealName;
                    insurance.InsureWorth = dr.GetDecimal(6);
                    result.Results.Add(insurance);
                }
            }
            return result;
        }
    }
}
