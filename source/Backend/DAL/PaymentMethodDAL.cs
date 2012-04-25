using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Backend.Models;
using Backend.Utilities;

namespace Backend.DAL
{
    public class PaymentMethodDAL
    {
        public void CreatePaymentMethod(PaymentMethod pm)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@name", 50, pm.Name)
            };
            string sql = "INSERT INTO payment_methods(name) VALUES(@name)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdatePaymentMethod(PaymentMethod pm)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", pm.Id),
                SqlUtilities.GenerateInputNVarcharParameter("@name", 50, pm.Name)
            };
            string sql = "UPDATE payment_methods SET name = @name WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void DeletePaymentMethodById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "DELETE FROM payment_methods WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public PaymentMethod GetPaymentMethodById(int id)
        {
            PaymentMethod pm = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "SELECT id, name FROM payment_methods WHERE id = @id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    pm = new PaymentMethod();
                    pm.Id = dr.GetInt32(0);
                    pm.Name = dr.GetString(1);
                }
            }
            return pm;
        }

        public PaymentMethod GetPaymentMethodByName(string name)
        {
            PaymentMethod pm = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@name", 50, name)
            };
            string sql = "SELECT id, name FROM payment_methods WHERE name = @name";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    pm = new PaymentMethod();
                    pm.Id = dr.GetInt32(0);
                    pm.Name = dr.GetString(1);
                }
            }
            return pm;
        }

        public List<PaymentMethod> GetPaymentMethod()
        {
            List<PaymentMethod> result = new List<PaymentMethod>();
            string sql = "SELECT id, name FROM payment_methods";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    PaymentMethod pm = new PaymentMethod();
                    pm.Id = dr.GetInt32(0);
                    pm.Name = dr.GetString(1);
                    result.Add(pm);
                }
            }
            return result;
        }
    }
}
