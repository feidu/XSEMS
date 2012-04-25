using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using System.Data;
using System.Data.SqlClient;
using Backend.Utilities;

namespace Backend.DAL
{
    public class DetainReasonDAL
    {
        public void CreateDetainReason(DetainReason dr)
        {
            SqlParameter[] param=new SqlParameter[]{
                SqlUtilities.GenerateInputIntParameter("@order_id", dr.OrderId),
                SqlUtilities.GenerateInputNVarcharParameter("@order_encode", 50, dr.OrderEncode),
                SqlUtilities.GenerateInputNVarcharParameter("@reason", 500, dr.Reason),
                SqlUtilities.GenerateInputDateTimeParameter("@create_time", dr.CreateTime),
                SqlUtilities.GenerateInputIntParameter("@user_id", dr.UserId)
            };
            string sql = "INSERT INTO detain_reasons(order_id, order_encode, reason, create_time, user_id) VALUES(@order_id, @order_encode, @reason, @create_time, @user_id)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public DetainReason GetDetainReasonByOrderId(int orderId)
        {
            DetainReason detainReason = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@order_id", orderId)
            };
            string sql = "SELECT id, order_id, order_encode, reason, create_time, user_id FROM detain_reasons WHERE order_id = @order_id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    detainReason = new DetainReason();
                    detainReason.Id = dr.GetInt32(0);
                    detainReason.OrderId = dr.GetInt32(1);
                    detainReason.OrderEncode = dr.GetString(2);
                    detainReason.Reason = dr.GetString(3);
                    detainReason.CreateTime = dr.GetDateTime(4);
                    detainReason.UserId = dr.GetInt32(5);
                }
            }
            return detainReason;
        }

    }
}
