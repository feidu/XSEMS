using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Backend.Models;
using Backend.Utilities;

namespace Backend.DAL
{
    public class PostStatusDAL
    {
        public void CreatePostStatus(LogisticsStatus ls)
        {
            SqlParameter[] param = new SqlParameter[] {
                SqlUtilities.GenerateInputNVarcharParameter("@bar_code", 50, ls.TrackNum),
                SqlUtilities.GenerateInputNVarcharParameter("@status", 50, ls.Status),
                SqlUtilities.GenerateInputNVarcharParameter("@location", 50, ls.Location),
                SqlUtilities.GenerateInputNVarcharParameter("@to_country", 50, ls.ToCountry),
                SqlUtilities.GenerateInputDateTimeParameter("@disposal_time", ls.DisposalTime),
                SqlUtilities.GenerateInputParameter("@is_arrive", SqlDbType.Bit, ls.IsArrive),
                SqlUtilities.GenerateInputDateTimeParameter("@create_time", ls.CreateTime)
            };
            string sql = "INSERT INTO post_status (bar_code, status, location, to_country, disposal_time, is_arrive, create_time) VALUES(@bar_code, @status, @location, @to_country, @disposal_time, @is_arrive, @create_time)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void DeletePostStatusByBarcode(string barCode)
        {
            SqlParameter[] param = new SqlParameter[] {
                SqlUtilities.GenerateInputNVarcharParameter("@bar_code", 50, barCode)
            };
            string sql = "DELETE FROM post_status WHERE bar_code = @bar_code";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public List<PostStatus> GetPostStatusByBarcode(string barCode)
        {
            List<PostStatus> result = new List<PostStatus>();
            SqlParameter[] param = new SqlParameter[] {
                SqlUtilities.GenerateInputNVarcharParameter("@bar_code", 50, barCode)
            };
            string sql = "SELECT id, bar_code, status, location, to_country, disposal_time from post_status WHERE bar_code = @bar_code";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    PostStatus ps = new PostStatus();
                    ps.Id = dr.GetInt32(0);
                    ps.BarCode = dr.GetString(1);
                    ps.Status = dr.GetString(2);
                    ps.Location = dr.GetString(3);
                    ps.ToCountry = dr.GetString(4);
                    ps.DisposalTime = dr.GetDateTime(5);
                    result.Add(ps);
                }
            }            
            return result;
        }

        public List<PostStatus> GetPostStatusByBarcodes(string barCodes)
        {
            List<PostStatus> result = new List<PostStatus>();
            SqlParameter[] param = new SqlParameter[] {
                SqlUtilities.GenerateInputNVarcharParameter("@bar_code", 200, barCodes)
            };
            string sql = "SELECT id, bar_code, status, location, to_country, disposal_time from post_status WHERE bar_code IN ('"+barCodes+"')";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                string barcode = "";
                int i=0;
                while (dr.Read())
                {
                    PostStatus ps = new PostStatus();
                    ps.Id = dr.GetInt32(0);
                    ps.BarCode = dr.GetString(1);
                    ps.Status = dr.GetString(2);
                    ps.Location = dr.GetString(3);
                    ps.ToCountry = dr.GetString(4);
                    ps.DisposalTime = dr.GetDateTime(5);                    
                    if (barcode != ps.BarCode)
                    {
                        i++;
                        barcode = ps.BarCode;
                    }
                    if (i >= 6)
                    {
                        break;
                    }
                    result.Add(ps);
                }
            }
            return result;
        }
    }
}
