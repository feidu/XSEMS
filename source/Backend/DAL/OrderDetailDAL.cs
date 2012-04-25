using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Backend.Models;
using Backend.Utilities;

namespace Backend.DAL
{
    public class OrderDetailDAL
    {
        public void CreateOrderDetail(OrderDetail od)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@encode", 50, od.Encode),
                SqlUtilities.GenerateInputIntParameter("@order_id", od.OrderId),
                SqlUtilities.GenerateInputNVarcharParameter("@carrier_encode", 50, od.CarrierEncode),
                SqlUtilities.GenerateInputParameter("@weight", SqlDbType.Decimal, od.Weight),
                SqlUtilities.GenerateInputParameter("@type", SqlDbType.TinyInt, (byte)od.Type),
                SqlUtilities.GenerateInputIntParameter("@count", od.Count),
                SqlUtilities.GenerateInputParameter("@kg_price", SqlDbType.Decimal, od.KgPrice),
                SqlUtilities.GenerateInputParameter("@post_costs", SqlDbType.Decimal, od.PostCosts),
                SqlUtilities.GenerateInputParameter("@self_post_costs", SqlDbType.Decimal, od.SelfPostCosts),
                SqlUtilities.GenerateInputParameter("@register_costs", SqlDbType.Decimal, od.RegisterCosts),
                SqlUtilities.GenerateInputParameter("@disposal_costs", SqlDbType.Decimal, od.DisposalCosts),
                SqlUtilities.GenerateInputParameter("@remote_costs", SqlDbType.Decimal, od.RemoteCosts),
                SqlUtilities.GenerateInputParameter("@fetch_costs", SqlDbType.Decimal, od.FetchCosts),
                SqlUtilities.GenerateInputParameter("@material_costs", SqlDbType.Decimal, od.MaterialCosts),
                SqlUtilities.GenerateInputParameter("@other_costs", SqlDbType.Decimal, od.OtherCosts),
                SqlUtilities.GenerateInputNVarcharParameter("@other_costs_note", 200, od.OtherCostsNote),
                SqlUtilities.GenerateInputParameter("@insure_costs", SqlDbType.Decimal, od.InsureCosts),
                SqlUtilities.GenerateInputParameter("@address_change_costs", SqlDbType.Decimal, od.AddressChangeCosts),
                SqlUtilities.GenerateInputParameter("@return_costs", SqlDbType.Decimal, od.ReturnCosts),
                SqlUtilities.GenerateInputParameter("@fuel_costs", SqlDbType.Decimal, od.FuelCosts),
                SqlUtilities.GenerateInputParameter("@damage_money", SqlDbType.Decimal, od.DamageMoney),
                SqlUtilities.GenerateInputParameter("@return_money", SqlDbType.Decimal, od.ReturnMoney),
                SqlUtilities.GenerateInputParameter("@total_costs", SqlDbType.Decimal, od.TotalCosts),
                SqlUtilities.GenerateInputParameter("@self_total_costs", SqlDbType.Decimal, od.SelfTotalCosts),
                SqlUtilities.GenerateInputIntParameter("@user_id", od.UserId),
                SqlUtilities.GenerateInputDateTimeParameter("@create_time",od.CreateTime),
                SqlUtilities.GenerateInputNVarcharParameter("@bar_code", 50, od.BarCode),
                SqlUtilities.GenerateInputNVarcharParameter("@remark", 500, od.Remark),
                SqlUtilities.GenerateInputNVarcharParameter("@to_username", 50, od.ToUsername),
                SqlUtilities.GenerateInputNVarcharParameter("@to_phone", 50, od.ToPhone),
                SqlUtilities.GenerateInputNVarcharParameter("@to_email", 50, od.ToEmail),
                SqlUtilities.GenerateInputNVarcharParameter("@to_city", 50, od.ToCity),
                SqlUtilities.GenerateInputNVarcharParameter("@to_country", 50, od.ToCountry),
                SqlUtilities.GenerateInputNVarcharParameter("@to_address", 200, od.ToAddress),
                SqlUtilities.GenerateInputNVarcharParameter("@to_postcode", 50, od.ToPostcode)
            };
            string sql = "INSERT INTO order_details(order_id, carrier_encode, weight, type, count, kg_price, post_costs, register_costs, disposal_costs, remote_costs, fetch_costs, material_costs, other_costs, other_costs_note, insure_costs, address_change_costs, return_costs, damage_money, return_money, total_costs, user_id, create_time, bar_code, remark, to_username, to_phone, to_email, to_city, to_country, to_address, to_postcode, encode, self_post_costs, self_total_costs, fuel_costs) VALUES(@order_id, @carrier_encode, @weight, @type, @count, @kg_price, @post_costs, @register_costs, @disposal_costs, @remote_costs, @fetch_costs, @material_costs, @other_costs, @other_costs_note, @insure_costs,                      @address_change_costs, @return_costs, @damage_money, @return_money, @total_costs, @user_id, @create_time, @bar_code, @remark, @to_username,          @to_phone, @to_email, @to_city, @to_country, @to_address, @to_postcode, @encode, @self_post_costs, @self_total_costs, @fuel_costs)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void CreateClientOrderDetail(OrderDetail od)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@encode", 50, od.Encode),
                SqlUtilities.GenerateInputIntParameter("@order_id", od.OrderId),
                SqlUtilities.GenerateInputParameter("@client_weight", SqlDbType.Decimal, od.ClientWeight),
                SqlUtilities.GenerateInputIntParameter("@client_count", od.ClientCount),
                SqlUtilities.GenerateInputNVarcharParameter("@title", 100, od.Title),
                SqlUtilities.GenerateInputParameter("@declare_worth", SqlDbType.Decimal, od.DeclareWorth),
                SqlUtilities.GenerateInputNVarcharParameter("@hs_encode", 200, od.HsEncode),
                SqlUtilities.GenerateInputNVarcharParameter("@decalare_cn_name", 200, od.DeclareCnName),
                SqlUtilities.GenerateInputDateTimeParameter("@create_time", od.CreateTime),
                SqlUtilities.GenerateInputNVarcharParameter("@to_username", 50, od.ToUsername),
                SqlUtilities.GenerateInputNVarcharParameter("@to_phone", 50, od.ToPhone),
                SqlUtilities.GenerateInputNVarcharParameter("@to_email", 50, od.ToEmail),
                SqlUtilities.GenerateInputNVarcharParameter("@to_city", 50, od.ToCity),
                SqlUtilities.GenerateInputNVarcharParameter("@to_country", 50, od.ToCountry),
                SqlUtilities.GenerateInputNVarcharParameter("@to_address", 200, od.ToAddress),
                SqlUtilities.GenerateInputNVarcharParameter("@to_postcode", 50, od.ToPostcode)

            };
            string sql = "INSERT INTO order_details(order_id, create_time, to_username, to_phone, to_email, to_city, to_country, to_address, to_postcode, encode, title, client_weight, client_count, declare_worth, hs_encode, decalare_cn_name) VALUES(@order_id, @create_time, @to_username,      @to_phone, @to_email, @to_city, @to_country, @to_address, @to_postcode, @encode, @title, @client_weight, @client_count, @declare_worth, @hs_encode, @decalare_cn_name)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdateOrderDetail(OrderDetail od)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", od.Id),                
                SqlUtilities.GenerateInputNVarcharParameter("@carrier_encode", 50, od.CarrierEncode),
                SqlUtilities.GenerateInputParameter("@weight", SqlDbType.Decimal, od.Weight),
                SqlUtilities.GenerateInputParameter("@type", SqlDbType.TinyInt, (byte)od.Type),
                SqlUtilities.GenerateInputIntParameter("@count", od.Count),
                SqlUtilities.GenerateInputParameter("@kg_price", SqlDbType.Decimal, od.KgPrice),
                SqlUtilities.GenerateInputParameter("@post_costs", SqlDbType.Decimal, od.PostCosts),
                SqlUtilities.GenerateInputParameter("@self_post_costs", SqlDbType.Decimal, od.SelfPostCosts),
                SqlUtilities.GenerateInputParameter("@register_costs", SqlDbType.Decimal, od.RegisterCosts),
                SqlUtilities.GenerateInputParameter("@disposal_costs", SqlDbType.Decimal, od.DisposalCosts),
                SqlUtilities.GenerateInputParameter("@remote_costs", SqlDbType.Decimal, od.RemoteCosts),
                SqlUtilities.GenerateInputParameter("@fetch_costs", SqlDbType.Decimal, od.FetchCosts),
                SqlUtilities.GenerateInputParameter("@material_costs", SqlDbType.Decimal, od.MaterialCosts),
                SqlUtilities.GenerateInputParameter("@other_costs", SqlDbType.Decimal, od.OtherCosts),
                SqlUtilities.GenerateInputNVarcharParameter("@other_costs_note", 200, od.OtherCostsNote),
                SqlUtilities.GenerateInputParameter("@insure_costs", SqlDbType.Decimal, od.InsureCosts),
                SqlUtilities.GenerateInputParameter("@address_change_costs", SqlDbType.Decimal, od.AddressChangeCosts),
                SqlUtilities.GenerateInputParameter("@return_costs", SqlDbType.Decimal, od.ReturnCosts),
                SqlUtilities.GenerateInputParameter("@fuel_costs", SqlDbType.Decimal, od.FuelCosts),
                SqlUtilities.GenerateInputParameter("@damage_money", SqlDbType.Decimal, od.DamageMoney),
                SqlUtilities.GenerateInputParameter("@return_money", SqlDbType.Decimal, od.ReturnMoney),
                SqlUtilities.GenerateInputParameter("@total_costs", SqlDbType.Decimal, od.TotalCosts),
                SqlUtilities.GenerateInputParameter("@self_total_costs", SqlDbType.Decimal, od.SelfTotalCosts),
                SqlUtilities.GenerateInputNVarcharParameter("@bar_code", 50, od.BarCode),
                SqlUtilities.GenerateInputNVarcharParameter("@remark", 500, od.Remark),
                SqlUtilities.GenerateInputNVarcharParameter("@to_username", 50, od.ToUsername),
                SqlUtilities.GenerateInputNVarcharParameter("@to_phone", 50, od.ToPhone),
                SqlUtilities.GenerateInputNVarcharParameter("@to_email", 50, od.ToEmail),
                SqlUtilities.GenerateInputNVarcharParameter("@to_city", 50, od.ToCity),
                SqlUtilities.GenerateInputNVarcharParameter("@to_country", 50, od.ToCountry),
                SqlUtilities.GenerateInputNVarcharParameter("@to_address", 200, od.ToAddress),
                SqlUtilities.GenerateInputNVarcharParameter("@to_postcode", 50, od.ToPostcode)
            };
            string sql = "UPDATE order_details SET carrier_encode = @carrier_encode, weight = @weight, type = @type, count = @count, kg_price =         @kg_price, post_costs = @post_costs,self_post_costs = @self_post_costs, register_costs = @register_costs, disposal_costs = @disposal_costs, remote_costs = @remote_costs, fetch_costs = @fetch_costs, material_costs = @material_costs, other_costs = @other_costs, other_costs_note =              @other_costs_note, insure_costs = @insure_costs, address_change_costs = @address_change_costs, return_costs = @return_costs, damage_money =          @damage_money, return_money = @return_money, total_costs = @total_costs, self_total_costs = @self_total_costs, bar_code = @bar_code, remark =        @remark, to_username = @to_username, to_phone = @to_phone, to_email = @to_email, to_city = @to_city, to_country = @to_country, to_address =          @to_address, to_postcode = @to_postcode WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }
               

        public void UpdateClientOrderDetail(OrderDetail od)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", od.Id),                
                SqlUtilities.GenerateInputParameter("@client_weight", SqlDbType.Decimal, od.ClientWeight),
                SqlUtilities.GenerateInputIntParameter("@client_count", od.ClientCount),
                SqlUtilities.GenerateInputNVarcharParameter("@title", 100, od.Title),
                SqlUtilities.GenerateInputParameter("@declare_worth", SqlDbType.Decimal, od.DeclareWorth),
                SqlUtilities.GenerateInputNVarcharParameter("@hs_encode", 200, od.HsEncode),
                SqlUtilities.GenerateInputNVarcharParameter("@decalare_cn_name", 200, od.DeclareCnName)
            };
            string sql = "UPDATE order_details SET client_weight = @client_weight, client_count = @client_count, title = @title, declare_worth =           @declare_worth, hs_encode = @hs_encode, decalare_cn_name = @decalare_cn_name WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void DeleteOrderDetailById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
             };
            string sql = " UPDATE order_details SET is_delete = 1 WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void DeleteOrderDetailByOrderId(int orderId)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@order_id", orderId)
             };
            string sql = " UPDATE order_details SET is_delete = 1 WHERE order_id = @order_id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public bool CheckEncodeExist(string encode)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@encode", 50, encode)
             };
            string sql = " SELECT id FROM order_details WHERE encode = @encode AND is_delete = 0";
            int id = 0;
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    id = dr.GetInt32(0);
                }
            }
            if (id > 0)
            {
                return true;
            }
            return false;
        }

        public OrderDetail GetOrderDetailById(int id)
        {
            OrderDetail od = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "SELECT id, order_id, carrier_encode, weight, type, count, kg_price, post_costs, register_costs, disposal_costs, remote_costs, fetch_costs, material_costs, other_costs, other_costs_note, insure_costs, address_change_costs, return_costs, damage_money, return_money, total_costs, user_id, create_time, bar_code, to_username, to_phone, to_email, to_city, to_country, to_address, to_postcode, remark, encode, title, client_weight, client_count, declare_worth, hs_encode, decalare_cn_name, self_post_costs, self_total_costs, fuel_costs FROM order_details WHERE id = @id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    od = new OrderDetail();
                    od.Id = dr.GetInt32(0);
                    od.OrderId = dr.GetInt32(1);
                    if (!dr.IsDBNull(2))
                    {
                        od.CarrierEncode = dr.GetString(2);
                    }
                    if (!dr.IsDBNull(3))
                    {
                        od.Weight = dr.GetDecimal(3);
                    }
                    if (!dr.IsDBNull(4))
                    {
                        od.Type = dr.GetByte(4);
                    }
                    if (!dr.IsDBNull(5))
                    {
                        od.Count = dr.GetInt32(5);
                    }
                    od.KgPrice = dr.GetDecimal(6);
                    od.PostCosts = dr.GetDecimal(7);
                    od.RegisterCosts = dr.GetDecimal(8);
                    od.DisposalCosts = dr.GetDecimal(9);
                    od.RemoteCosts = dr.GetDecimal(10);
                    od.FetchCosts = dr.GetDecimal(11);
                    od.MaterialCosts = dr.GetDecimal(12);
                    od.OtherCosts = dr.GetDecimal(13);
                    if (!dr.IsDBNull(14))
                    {
                        od.OtherCostsNote = dr.GetString(14);
                    }
                    od.InsureCosts = dr.GetDecimal(15);
                    od.AddressChangeCosts = dr.GetDecimal(16);
                    od.ReturnCosts = dr.GetDecimal(17);
                    od.DamageMoney = dr.GetDecimal(18);
                    od.ReturnMoney = dr.GetDecimal(19);
                    od.TotalCosts = dr.GetDecimal(20);
                    if (!dr.IsDBNull(21))
                    {
                        od.UserId = dr.GetInt32(21);
                    }
                    od.CreateTime = dr.GetDateTime(22);
                    if (!dr.IsDBNull(23))
                    {
                        od.BarCode = dr.GetString(23);
                    }
                    od.ToUsername = dr.GetString(24);
                    od.ToPhone = dr.GetString(25);
                    od.ToEmail = dr.GetString(26);
                    od.ToCity = dr.GetString(27);
                    od.ToCountry = dr.GetString(28);
                    od.ToAddress = dr.GetString(29);
                    od.ToPostcode = dr.GetString(30);
                    if (!dr.IsDBNull(31))
                    {
                        od.Remark = dr.GetString(31);
                    }
                    od.Encode = dr.GetString(32);
                    if (!dr.IsDBNull(33))
                    {
                        od.Title = dr.GetString(33);
                    }
                    if (!dr.IsDBNull(34))
                    {
                        od.ClientWeight = dr.GetDecimal(34);
                    }
                    if (!dr.IsDBNull(35))
                    {
                        od.ClientCount = dr.GetInt32(35);
                    }
                    if (!dr.IsDBNull(36))
                    {
                        od.DeclareWorth = dr.GetDecimal(36);
                    }
                    if (!dr.IsDBNull(37))
                    {
                        od.HsEncode = dr.GetString(37);
                    }
                    if (!dr.IsDBNull(38))
                    {
                        od.DeclareCnName = dr.GetString(38);
                    }
                    od.SelfPostCosts = dr.GetDecimal(39);
                    od.SelfTotalCosts = dr.GetDecimal(40);
                    od.FuelCosts = dr.GetDecimal(41);
                }
            }
            return od;
        }

        public bool GetOrderDetaiByBarCode(string barCode)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@bar_code", 50, barCode)
            };
            int id = 0;
            string sql = "SELECT id FROM order_details WHERE is_delete = 0 AND bar_code = @bar_code ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    id = dr.GetInt32(0);
                }
            }
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<OrderDetail> GetOrderDetailByOrderId(int orderId)
        {
            List<OrderDetail> result = new List<OrderDetail>();
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@order_id", orderId)
            };
            string sql = "SELECT id, order_id, carrier_encode, weight, type, count, kg_price, post_costs, register_costs, disposal_costs, remote_costs, fetch_costs, material_costs, other_costs, other_costs_note, insure_costs, address_change_costs, return_costs, damage_money, return_money, total_costs, user_id, create_time, bar_code, to_username, to_phone, to_email, to_city, to_country, to_address, to_postcode, remark, encode, title, client_weight, client_count, declare_worth, hs_encode, decalare_cn_name, self_post_costs, self_total_costs, fuel_costs FROM order_details WHERE is_delete = 0 AND order_id = @order_id"; 
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    OrderDetail od = new OrderDetail();
                    od.Id = dr.GetInt32(0);
                    od.OrderId = dr.GetInt32(1);
                    if (!dr.IsDBNull(2))
                    {
                        od.CarrierEncode = dr.GetString(2);
                    }
                    if (!dr.IsDBNull(3))
                    {
                        od.Weight = dr.GetDecimal(3);
                    }
                    if (!dr.IsDBNull(4))
                    {
                        od.Type = dr.GetByte(4);
                    }
                    if (!dr.IsDBNull(5))
                    {
                        od.Count = dr.GetInt32(5);
                    }
                    od.KgPrice = dr.GetDecimal(6);
                    od.PostCosts = dr.GetDecimal(7);
                    od.RegisterCosts = dr.GetDecimal(8);
                    od.DisposalCosts = dr.GetDecimal(9);
                    od.RemoteCosts = dr.GetDecimal(10);
                    od.FetchCosts = dr.GetDecimal(11);
                    od.MaterialCosts = dr.GetDecimal(12);
                    od.OtherCosts = dr.GetDecimal(13);
                    if (!dr.IsDBNull(14))
                    {
                        od.OtherCostsNote = dr.GetString(14);
                    }
                    od.InsureCosts = dr.GetDecimal(15);
                    od.AddressChangeCosts = dr.GetDecimal(16);
                    od.ReturnCosts = dr.GetDecimal(17);
                    od.DamageMoney = dr.GetDecimal(18);
                    od.ReturnMoney = dr.GetDecimal(19);
                    od.TotalCosts = dr.GetDecimal(20);
                    if (!dr.IsDBNull(21))
                    {
                        od.UserId = dr.GetInt32(21);
                    }
                    od.CreateTime = dr.GetDateTime(22);
                    if (!dr.IsDBNull(23))
                    {
                        od.BarCode = dr.GetString(23);
                    }
                    od.ToUsername = dr.GetString(24);
                    od.ToPhone = dr.GetString(25);
                    od.ToEmail = dr.GetString(26);
                    od.ToCity = dr.GetString(27);
                    od.ToCountry = dr.GetString(28);
                    od.ToAddress = dr.GetString(29);
                    od.ToPostcode = dr.GetString(30);
                    if (!dr.IsDBNull(31))
                    {
                        od.Remark = dr.GetString(31);
                    }
                    od.Encode = dr.GetString(32);
                    if (!dr.IsDBNull(33))
                    {
                        od.Title = dr.GetString(33);
                    }
                    if (!dr.IsDBNull(34))
                    {
                        od.ClientWeight = dr.GetDecimal(34);
                    }
                    if (!dr.IsDBNull(35))
                    {
                        od.ClientCount = dr.GetInt32(35);
                    }
                    if (!dr.IsDBNull(36))
                    {
                        od.DeclareWorth = dr.GetDecimal(36);
                    }
                    if (!dr.IsDBNull(37))
                    {
                        od.HsEncode = dr.GetString(37);
                    }
                    if (!dr.IsDBNull(38))
                    {
                        od.DeclareCnName = dr.GetString(38);
                    }
                    od.SelfPostCosts = dr.GetDecimal(39);
                    od.SelfTotalCosts = dr.GetDecimal(40);
                    od.FuelCosts = dr.GetDecimal(41);
                    result.Add(od);
                }            
            }
            return result;
        }

        public void UpdateOrderDetailCancelInfo(OrderDetail od)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", od.Id),
                SqlUtilities.GenerateInputIntParameter("@cancel_user", od.CancelUser),
                SqlUtilities.GenerateInputDateTimeParameter("@cancel_time", od.CancelTime)
            };
            string sql = "UPDATE order_details SET cancel_user = @cancel_user, @cancel_time = @cancel_time WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdateOrderDetailPostStatus(string barCode)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@bar_code", 50, barCode)
            };
            string sql = "UPDATE order_details SET is_arrive = 1 WHERE bar_code = @bar_code";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdateOrderDetailPostInfo(string barCode, string postStatus, DateTime lastDisposalTime)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@bar_code", 50, barCode),
                SqlUtilities.GenerateInputNVarcharParameter("@post_status", 50, postStatus),
                SqlUtilities.GenerateInputDateTimeParameter("@last_disposal_time", lastDisposalTime)
            };
            string sql = "UPDATE order_details SET last_disposal_time = @last_disposal_time, post_status = @post_status, is_tracking = 1 WHERE bar_code = @bar_code";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }
    }
}
