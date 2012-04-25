using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Backend.Models;
using Backend.Utilities;

namespace Backend.DAL
{
    public class CarrierDAL
    {
        public void CreateCarrier(Carrier carrier)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@encode", 50, carrier.Encode),
                SqlUtilities.GenerateInputNVarcharParameter("@name", 50, carrier.Name),
                SqlUtilities.GenerateInputNVarcharParameter("@contact_person", 50, carrier.ContactPerson),
                SqlUtilities.GenerateInputNVarcharParameter("@address", 200, carrier.Address),
                SqlUtilities.GenerateInputNVarcharParameter("@return_address", 200, carrier.ReturnAddress),
                SqlUtilities.GenerateInputNVarcharParameter("@phone", 50, carrier.Phone),
                SqlUtilities.GenerateInputNVarcharParameter("@fax", 50, carrier.Fax),
                SqlUtilities.GenerateInputNVarcharParameter("@email", 50, carrier.Email),
                SqlUtilities.GenerateInputNVarcharParameter("@quote_type", 50, carrier.QuoteType),
                SqlUtilities.GenerateInputNVarcharParameter("@transport_time", 50, carrier.TransportTime),
                SqlUtilities.GenerateInputParameter("@agency_discount", SqlDbType.Decimal, carrier.AgencyDiscount),
                SqlUtilities.GenerateInputParameter("@client_discount", SqlDbType.Decimal, carrier.ClientDiscount),
                SqlUtilities.GenerateInputParameter("@fuel_sg_rate", SqlDbType.Decimal, carrier.FuelSgRate),
                SqlUtilities.GenerateInputParameter("@is_invoice", SqlDbType.Bit, carrier.IsInvoice),
                SqlUtilities.GenerateInputParameter("@is_limit_weight", SqlDbType.Bit, carrier.IsLimitWeight),
                SqlUtilities.GenerateInputParameter("@is_open_api", SqlDbType.Bit, carrier.IsOpenApi),
                SqlUtilities.GenerateInputParameter("@is_follow", SqlDbType.Bit, carrier.IsFollow),
                SqlUtilities.GenerateInputParameter("@is_useable", SqlDbType.Bit, carrier.IsUseable),
                SqlUtilities.GenerateInputParameter("@is_client_show", SqlDbType.Bit, carrier.IsClientShow),
                SqlUtilities.GenerateInputParameter("@is_charge_wv", SqlDbType.Bit, carrier.IsChargeByWV),
                SqlUtilities.GenerateInputParameter("@min_weight", SqlDbType.Decimal, carrier.MinWeight),
                SqlUtilities.GenerateInputParameter("@max_weight", SqlDbType.Decimal, carrier.MaxWeight),
                SqlUtilities.GenerateInputNVarcharParameter("@remark", 200, carrier.Remark)
            };
            string sql = "INSERT INTO carriers(encode, name, contact_person, address, return_address, phone, fax, email, is_invoice, quote_type, transport_time, agency_discount, client_discount, fuel_sg_rate, is_limit_weight, is_open_api, is_follow, is_useable, is_client_show, is_charge_wv,min_weight, max_weight, remark) VALUES(@encode, @name, @contact_person, @address, @return_address, @phone, @fax, @email, @is_invoice, @quote_type,      @transport_time, @agency_discount, @client_discount, @fuel_sg_rate, @is_limit_weight, @is_open_api, @is_follow, @is_useable, @is_client_show,        @is_charge_wv, @min_weight, @max_weight, @remark)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdateCarrier(Carrier carrier)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", carrier.Id),
                SqlUtilities.GenerateInputNVarcharParameter("@name", 50, carrier.Name),
                SqlUtilities.GenerateInputNVarcharParameter("@contact_person", 50, carrier.ContactPerson),
                SqlUtilities.GenerateInputNVarcharParameter("@address", 200, carrier.Address),
                SqlUtilities.GenerateInputNVarcharParameter("@return_address", 200, carrier.ReturnAddress),
                SqlUtilities.GenerateInputNVarcharParameter("@phone", 50, carrier.Phone),
                SqlUtilities.GenerateInputNVarcharParameter("@fax", 50, carrier.Fax),
                SqlUtilities.GenerateInputNVarcharParameter("@email", 50, carrier.Email),
                SqlUtilities.GenerateInputNVarcharParameter("@quote_type", 50, carrier.QuoteType),
                SqlUtilities.GenerateInputNVarcharParameter("@transport_time", 50, carrier.TransportTime),
                SqlUtilities.GenerateInputParameter("@agency_discount", SqlDbType.Decimal, carrier.AgencyDiscount),
                SqlUtilities.GenerateInputParameter("@client_discount", SqlDbType.Decimal, carrier.ClientDiscount),
                SqlUtilities.GenerateInputParameter("@fuel_sg_rate", SqlDbType.Decimal, carrier.FuelSgRate),
                SqlUtilities.GenerateInputParameter("@is_invoice", SqlDbType.Bit, carrier.IsInvoice),
                SqlUtilities.GenerateInputParameter("@is_limit_weight", SqlDbType.Bit, carrier.IsLimitWeight),
                SqlUtilities.GenerateInputParameter("@is_open_api", SqlDbType.Bit, carrier.IsOpenApi),
                SqlUtilities.GenerateInputParameter("@is_follow", SqlDbType.Bit, carrier.IsFollow),
                SqlUtilities.GenerateInputParameter("@is_useable", SqlDbType.Bit, carrier.IsUseable),
                SqlUtilities.GenerateInputParameter("@is_client_show", SqlDbType.Bit, carrier.IsClientShow),
                SqlUtilities.GenerateInputParameter("@is_charge_wv", SqlDbType.Bit, carrier.IsChargeByWV),
                SqlUtilities.GenerateInputParameter("@min_weight", SqlDbType.Decimal, carrier.MinWeight),
                SqlUtilities.GenerateInputParameter("@max_weight", SqlDbType.Decimal, carrier.MaxWeight),
                SqlUtilities.GenerateInputNVarcharParameter("@remark", 200, carrier.Remark)
            };
            string sql = "UPDATE carriers SET name = @name, contact_person = @contact_person, address = @address, phone = @phone, fax = @fax, email = @email, is_invoice = @is_invoice, quote_type = @quote_type, transport_time = @transport_time, agency_discount = @agency_discount, client_discount=           @client_discount, fuel_sg_rate = @fuel_sg_rate, is_limit_weight = @is_limit_weight, is_open_api = @is_open_api, is_follow = @is_follow, is_useable = @is_useable, is_client_show = @is_client_show, is_charge_wv = @is_charge_wv, min_weight = @min_weight, max_weight = @max_weight, remark = @remark, return_address = @return_address WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void DeleteCarrierById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "UPDATE carriers SET is_delete = 1 WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public Carrier GetCarrierById(int id)
        {
            Carrier carrier = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "SELECT id, name, contact_person, address, phone, fax, email, is_invoice, quote_type, transport_time, agency_discount, fuel_sg_rate, is_limit_weight, is_open_api, is_follow, is_useable, is_client_show, is_charge_wv, remark, client_discount, return_address, encode, min_weight, max_weight FROM carriers WHERE id = @id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    carrier = new Carrier();
                    carrier.Id = dr.GetInt32(0);
                    carrier.Name = dr.GetString(1);
                    carrier.ContactPerson = dr.GetString(2);
                    carrier.Address = dr.GetString(3);
                    carrier.Phone = dr.GetString(4);
                    carrier.Fax = dr.GetString(5);
                    carrier.Email = dr.GetString(6);
                    carrier.IsInvoice = dr.GetBoolean(7);
                    carrier.QuoteType = dr.GetString(8);
                    carrier.TransportTime = dr.GetString(9);
                    carrier.AgencyDiscount = dr.GetDecimal(10);
                    carrier.FuelSgRate = dr.GetDecimal(11);
                    carrier.IsLimitWeight=dr.GetBoolean(12);
                    carrier.IsOpenApi=dr.GetBoolean(13);
                    carrier.IsFollow=dr.GetBoolean(14);
                    carrier.IsUseable=dr.GetBoolean(15);
                    carrier.IsClientShow = dr.GetBoolean(16);
                    carrier.IsChargeByWV = dr.GetBoolean(17);
                    carrier.Remark = dr.GetString(18);
                    carrier.ClientDiscount = dr.GetDecimal(19);
                    carrier.ReturnAddress = dr.GetString(20);
                    carrier.Encode = dr.GetString(21);
                    carrier.MinWeight = dr.GetDecimal(22);
                    carrier.MaxWeight = dr.GetDecimal(23);
                }
            }
            return carrier;
        }

        public Carrier GetCarrierByEncode(string encode)
        {
            Carrier carrier = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@encode", 50, encode)
            };
            string sql = "SELECT id, name, contact_person, address, phone, fax, email, is_invoice, quote_type, transport_time, agency_discount, fuel_sg_rate, is_limit_weight, is_open_api, is_follow, is_useable, is_client_show, is_charge_wv, remark, client_discount, return_address, encode, min_weight, max_weight FROM carriers WHERE encode = @encode";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    carrier = new Carrier();
                    carrier.Id = dr.GetInt32(0);
                    carrier.Name = dr.GetString(1);
                    carrier.ContactPerson = dr.GetString(2);
                    carrier.Address = dr.GetString(3);
                    carrier.Phone = dr.GetString(4);
                    carrier.Fax = dr.GetString(5);
                    carrier.Email = dr.GetString(6);
                    carrier.IsInvoice = dr.GetBoolean(7);
                    carrier.QuoteType = dr.GetString(8);
                    carrier.TransportTime = dr.GetString(9);
                    carrier.AgencyDiscount = dr.GetDecimal(10);
                    carrier.FuelSgRate = dr.GetDecimal(11);
                    carrier.IsLimitWeight = dr.GetBoolean(12);
                    carrier.IsOpenApi = dr.GetBoolean(13);
                    carrier.IsFollow = dr.GetBoolean(14);
                    carrier.IsUseable = dr.GetBoolean(15);
                    carrier.IsClientShow = dr.GetBoolean(16);
                    carrier.IsChargeByWV = dr.GetBoolean(17);
                    carrier.Remark = dr.GetString(18);
                    carrier.ClientDiscount = dr.GetDecimal(19);
                    carrier.ReturnAddress = dr.GetString(20);
                    carrier.Encode = dr.GetString(21);
                    carrier.MinWeight = dr.GetDecimal(22);
                    carrier.MaxWeight = dr.GetDecimal(23);
                }
            }
            return carrier;
        }

        public List<Carrier> GetCarrier()
        {
            List<Carrier> result = new List<Carrier>();
            string sql = "SELECT id, name, contact_person, address, phone, fax, email, is_invoice, quote_type, transport_time, agency_discount, fuel_sg_rate, is_limit_weight, is_open_api, is_follow, is_useable, is_client_show, is_charge_wv, remark, client_discount, return_address, encode, min_weight, max_weight FROM carriers WHERE is_delete = 0 AND is_useable = 1";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    Carrier carrier = new Carrier();
                    carrier.Id = dr.GetInt32(0);
                    carrier.Name = dr.GetString(1);
                    carrier.ContactPerson = dr.GetString(2);
                    carrier.Address = dr.GetString(3);
                    carrier.Phone = dr.GetString(4);
                    carrier.Fax = dr.GetString(5);
                    carrier.Email = dr.GetString(6);
                    carrier.IsInvoice = dr.GetBoolean(7);
                    carrier.QuoteType = dr.GetString(8);
                    carrier.TransportTime = dr.GetString(9);
                    carrier.AgencyDiscount = dr.GetDecimal(10);
                    carrier.FuelSgRate = dr.GetDecimal(11);
                    carrier.IsLimitWeight = dr.GetBoolean(12);
                    carrier.IsOpenApi = dr.GetBoolean(13);
                    carrier.IsFollow = dr.GetBoolean(14);
                    carrier.IsUseable = dr.GetBoolean(15);
                    carrier.IsClientShow = dr.GetBoolean(16);
                    carrier.IsChargeByWV = dr.GetBoolean(17);
                    carrier.Remark = dr.GetString(18);
                    carrier.ClientDiscount = dr.GetDecimal(19);
                    carrier.ReturnAddress = dr.GetString(20);
                    carrier.Encode = dr.GetString(21);
                    carrier.MinWeight = dr.GetDecimal(22);
                    carrier.MaxWeight = dr.GetDecimal(23);
                    result.Add(carrier);
                }
            }
            return result;
        }
    }
}
