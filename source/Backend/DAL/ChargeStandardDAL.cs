using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Backend.Models;
using Backend.Utilities;

namespace Backend.DAL
{
    public class ChargeStandardDAL
    {
        public void CreateChargeStandard(ChargeStandard cs)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@carrier_id", cs.CarrierId),
                SqlUtilities.GenerateInputIntParameter("@carrier_area_id", cs.CarrierAreaId),
                SqlUtilities.GenerateInputNVarcharParameter("@encode", 50, cs.Encode),
                SqlUtilities.GenerateInputParameter("@goods_type", SqlDbType.TinyInt, cs.GoodsType),
                SqlUtilities.GenerateInputParameter("@start_weight", SqlDbType.Decimal, cs.StartWeight),
                SqlUtilities.GenerateInputParameter("@end_weight", SqlDbType.Decimal, cs.EndWeight),
                SqlUtilities.GenerateInputParameter("@base_weight", SqlDbType.Decimal, cs.BaseWeight),
                SqlUtilities.GenerateInputParameter("@increase_weight", SqlDbType.Decimal, cs.IncreaseWeight),
                SqlUtilities.GenerateInputParameter("@normal_base_price", SqlDbType.Decimal, cs.NormalBasePrice),
                SqlUtilities.GenerateInputParameter("@normal_continue_price", SqlDbType.Decimal, cs.NormalContinuePrice),
                SqlUtilities.GenerateInputParameter("@normal_kg_price", SqlDbType.Decimal, cs.NormalKgPrice),
                SqlUtilities.GenerateInputParameter("@normal_disposal_cost", SqlDbType.Decimal, cs.NormalDisposalCost),
                SqlUtilities.GenerateInputParameter("@normal_register_cost", SqlDbType.Decimal, cs.NormalRegisterCost),
                SqlUtilities.GenerateInputParameter("@client_base_price", SqlDbType.Decimal, cs.ClientBasePrice),
                SqlUtilities.GenerateInputParameter("@client_continue_price", SqlDbType.Decimal, cs.ClientContinuePrice),
                SqlUtilities.GenerateInputParameter("@client_kg_price", SqlDbType.Decimal, cs.ClientKgPrice),
                SqlUtilities.GenerateInputParameter("@client_disposal_cost", SqlDbType.Decimal, cs.ClientDisposalCost),
                SqlUtilities.GenerateInputParameter("@client_register_cost", SqlDbType.Decimal, cs.ClientRegisterCost),
                SqlUtilities.GenerateInputParameter("@self_base_price", SqlDbType.Decimal, cs.SelfBasePrice),
                SqlUtilities.GenerateInputParameter("@self_continue_price", SqlDbType.Decimal, cs.SelfContinuePrice),
                SqlUtilities.GenerateInputParameter("@self_kg_price", SqlDbType.Decimal, cs.SelfKgPrice),
                SqlUtilities.GenerateInputParameter("@self_disposal_cost", SqlDbType.Decimal, cs.SelfDisposalCost),
                SqlUtilities.GenerateInputParameter("@self_register_cost", SqlDbType.Decimal, cs.SelfRegisterCost),
                SqlUtilities.GenerateInputParameter("@preferential_gram", SqlDbType.Decimal, cs.PreferentialGram)
            };
            string sql = "INSERT INTO charge_standards(carrier_id, carrier_area_id, encode, goods_type, start_weight, end_weight, base_weight, increase_weight, normal_base_price, normal_continue_price, normal_kg_price, normal_disposal_cost, normal_register_cost, client_base_price, client_continue_price, client_kg_price, client_disposal_cost, client_register_cost, self_base_price, self_continue_price, self_kg_price, self_disposal_cost, self_register_cost, preferential_gram) VALUES (@carrier_id, @carrier_area_id, @encode, @goods_type, @start_weight, @end_weight,     @base_weight, @increase_weight, @normal_base_price, @normal_continue_price, @normal_kg_price, @normal_disposal_cost, @normal_register_cost,          @client_base_price, @client_continue_price, @client_kg_price, @client_disposal_cost, @client_register_cost, @self_base_price, @self_continue_price, @self_kg_price, @self_disposal_cost, @self_register_cost, @preferential_gram)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);         
        }

        public string GetNextEncode(int carrierAreaId)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@carrier_area_id", carrierAreaId)
            };
            string encode = "0";
            string sql = "SELECT encode FROM charge_standards WHERE id=(SELECT MAX(id) FROM charge_standards WHERE carrier_area_id = @carrier_area_id)";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    encode = dr.GetString(0);
                }
            }
            return StringHelper.GetNextEncodeNumber(1, encode);
        }

        public void UpdateChargeStandard(ChargeStandard cs)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", cs.Id),
                SqlUtilities.GenerateInputParameter("@goods_type", SqlDbType.TinyInt, cs.GoodsType),
                SqlUtilities.GenerateInputParameter("@start_weight", SqlDbType.Decimal, cs.StartWeight),
                SqlUtilities.GenerateInputParameter("@end_weight", SqlDbType.Decimal, cs.EndWeight),
                SqlUtilities.GenerateInputParameter("@base_weight", SqlDbType.Decimal, cs.BaseWeight),
                SqlUtilities.GenerateInputParameter("@increase_weight", SqlDbType.Decimal, cs.IncreaseWeight),
                SqlUtilities.GenerateInputParameter("@normal_base_price", SqlDbType.Decimal, cs.NormalBasePrice),
                SqlUtilities.GenerateInputParameter("@normal_continue_price", SqlDbType.Decimal, cs.NormalContinuePrice),
                SqlUtilities.GenerateInputParameter("@normal_kg_price", SqlDbType.Decimal, cs.NormalKgPrice),
                SqlUtilities.GenerateInputParameter("@normal_disposal_cost", SqlDbType.Decimal, cs.NormalDisposalCost),
                SqlUtilities.GenerateInputParameter("@normal_register_cost", SqlDbType.Decimal, cs.NormalRegisterCost),
                SqlUtilities.GenerateInputParameter("@client_base_price", SqlDbType.Decimal, cs.ClientBasePrice),
                SqlUtilities.GenerateInputParameter("@client_continue_price", SqlDbType.Decimal, cs.ClientContinuePrice),
                SqlUtilities.GenerateInputParameter("@client_kg_price", SqlDbType.Decimal, cs.ClientKgPrice),
                SqlUtilities.GenerateInputParameter("@client_disposal_cost", SqlDbType.Decimal, cs.ClientDisposalCost),
                SqlUtilities.GenerateInputParameter("@client_register_cost", SqlDbType.Decimal, cs.ClientRegisterCost),
                SqlUtilities.GenerateInputParameter("@self_base_price", SqlDbType.Decimal, cs.SelfBasePrice),
                SqlUtilities.GenerateInputParameter("@self_continue_price", SqlDbType.Decimal, cs.SelfContinuePrice),
                SqlUtilities.GenerateInputParameter("@self_kg_price", SqlDbType.Decimal, cs.SelfKgPrice),
                SqlUtilities.GenerateInputParameter("@self_disposal_cost", SqlDbType.Decimal, cs.SelfDisposalCost),
                SqlUtilities.GenerateInputParameter("@self_register_cost", SqlDbType.Decimal, cs.SelfRegisterCost),
                SqlUtilities.GenerateInputParameter("@preferential_gram", SqlDbType.Decimal, cs.PreferentialGram)
            };
            string sql = "UPDATE charge_standards SET goods_type = @goods_type, start_weight = @start_weight, end_weight = @end_weight, base_weight = @base_weight, increase_weight = @increase_weight, normal_base_price = @normal_base_price, normal_continue_price = @normal_continue_price, normal_kg_price = @normal_kg_price, normal_disposal_cost = @normal_disposal_cost, normal_register_cost = @normal_register_cost, client_base_price =     @client_base_price, client_continue_price = @client_continue_price, client_kg_price = @client_kg_price, client_disposal_cost =                       @client_disposal_cost, client_register_cost = @client_register_cost, self_base_price = @self_base_price, self_continue_price =                       @self_continue_price, self_kg_price = @self_kg_price, self_disposal_cost = @self_disposal_cost, self_register_cost = @self_register_cost, preferential_gram = @preferential_gram WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public List<ChargeStandard> GetChargeStandardByCarrierAreaId(int carrierAreaId)
        {
            List<ChargeStandard> result = new List<ChargeStandard>();
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@carrier_area_id", carrierAreaId)
            };
            string sql = "SELECT carrier_id, carrier_area_id, encode, goods_type, start_weight, end_weight, base_weight, increase_weight, normal_base_price, normal_continue_price, normal_kg_price, normal_disposal_cost, normal_register_cost, client_base_price, client_continue_price, client_kg_price, client_disposal_cost, client_register_cost, self_base_price, self_continue_price, self_kg_price, self_disposal_cost, self_register_cost, id, preferential_gram FROM charge_standards WHERE carrier_area_id = @carrier_area_id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    ChargeStandard cs = new ChargeStandard();
                    cs.CarrierId = dr.GetInt32(0);
                    cs.CarrierAreaId = dr.GetInt32(1);
                    cs.Encode = dr.GetString(2);
                    cs.GoodsType = dr.GetByte(3);
                    cs.StartWeight = dr.GetDecimal(4);
                    cs.EndWeight = dr.GetDecimal(5);
                    cs.BaseWeight = dr.GetDecimal(6);
                    cs.IncreaseWeight = dr.GetDecimal(7);
                    cs.NormalBasePrice = dr.GetDecimal(8);
                    cs.NormalContinuePrice = dr.GetDecimal(9);
                    cs.NormalKgPrice = dr.GetDecimal(10);
                    cs.NormalDisposalCost = dr.GetDecimal(11);
                    cs.NormalRegisterCost = dr.GetDecimal(12);
                    cs.ClientBasePrice = dr.GetDecimal(13);
                    cs.ClientContinuePrice = dr.GetDecimal(14);
                    cs.ClientKgPrice = dr.GetDecimal(15);
                    cs.ClientDisposalCost = dr.GetDecimal(16);
                    cs.ClientRegisterCost = dr.GetDecimal(17);
                    cs.SelfBasePrice = dr.GetDecimal(18);
                    cs.SelfContinuePrice = dr.GetDecimal(19);
                    cs.SelfKgPrice = dr.GetDecimal(20);
                    cs.SelfDisposalCost = dr.GetDecimal(21);
                    cs.SelfRegisterCost = dr.GetDecimal(22);
                    cs.Id = dr.GetInt32(23);
                    cs.PreferentialGram = dr.GetDecimal(24);
                    result.Add(cs);
                }
            }
            return result;
        }

        public List<ChargeStandard> GetChargeStandardByCarrierId(int carrierId)
        {
            List<ChargeStandard> result = new List<ChargeStandard>();
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@carrier_id", carrierId)
            };
            string sql = "SELECT carrier_id, carrier_area_id, encode, goods_type, start_weight, end_weight, base_weight, increase_weight, normal_base_price, normal_continue_price, normal_kg_price, normal_disposal_cost, normal_register_cost, client_base_price, client_continue_price, client_kg_price, client_disposal_cost, client_register_cost, self_base_price, self_continue_price, self_kg_price, self_disposal_cost, self_register_cost, id, preferential_gram FROM charge_standards WHERE carrier_id = @carrier_id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    ChargeStandard cs = new ChargeStandard();
                    cs.CarrierId = dr.GetInt32(0);
                    cs.CarrierAreaId = dr.GetInt32(1);
                    cs.Encode = dr.GetString(2);
                    cs.GoodsType = dr.GetByte(3);
                    cs.StartWeight = dr.GetDecimal(4);
                    cs.EndWeight = dr.GetDecimal(5);
                    cs.BaseWeight = dr.GetDecimal(6);
                    cs.IncreaseWeight = dr.GetDecimal(7);
                    cs.NormalBasePrice = dr.GetDecimal(8);
                    cs.NormalContinuePrice = dr.GetDecimal(9);
                    cs.NormalKgPrice = dr.GetDecimal(10);
                    cs.NormalDisposalCost = dr.GetDecimal(11);
                    cs.NormalRegisterCost = dr.GetDecimal(12);
                    cs.ClientBasePrice = dr.GetDecimal(13);
                    cs.ClientContinuePrice = dr.GetDecimal(14);
                    cs.ClientKgPrice = dr.GetDecimal(15);
                    cs.ClientDisposalCost = dr.GetDecimal(16);
                    cs.ClientRegisterCost = dr.GetDecimal(17);
                    cs.SelfBasePrice = dr.GetDecimal(18);
                    cs.SelfContinuePrice = dr.GetDecimal(19);
                    cs.SelfKgPrice = dr.GetDecimal(20);
                    cs.SelfDisposalCost = dr.GetDecimal(21);
                    cs.SelfRegisterCost = dr.GetDecimal(22);
                    cs.Id = dr.GetInt32(23);
                    cs.PreferentialGram = dr.GetDecimal(24);
                    result.Add(cs);
                }
            }
            return result;
        }

        public ChargeStandard GetChargeStandardByEncode(int carrierAreaId, string encode)
        {
            ChargeStandard cs = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@carrier_area_id", carrierAreaId),
                SqlUtilities.GenerateInputNVarcharParameter("@encode", 50, encode)
            };
            string sql = "SELECT carrier_id, carrier_area_id, encode, goods_type, start_weight, end_weight, base_weight, increase_weight, normal_base_price, normal_continue_price, normal_kg_price, normal_disposal_cost, normal_register_cost, client_base_price, client_continue_price, client_kg_price, client_disposal_cost, client_register_cost, self_base_price, self_continue_price, self_kg_price, self_disposal_cost, self_register_cost, id, preferential_gram FROM charge_standards WHERE carrier_area_id = @carrier_area_id AND encode = @encode";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    cs = new ChargeStandard();
                    cs.CarrierId = dr.GetInt32(0);
                    cs.CarrierAreaId = dr.GetInt32(1);
                    cs.Encode = dr.GetString(2);
                    cs.GoodsType = dr.GetByte(3);
                    cs.StartWeight = dr.GetDecimal(4);
                    cs.EndWeight = dr.GetDecimal(5);
                    cs.BaseWeight = dr.GetDecimal(6);
                    cs.IncreaseWeight = dr.GetDecimal(7);
                    cs.NormalBasePrice = dr.GetDecimal(8);
                    cs.NormalContinuePrice = dr.GetDecimal(9);
                    cs.NormalKgPrice = dr.GetDecimal(10);
                    cs.NormalDisposalCost = dr.GetDecimal(11);
                    cs.NormalRegisterCost = dr.GetDecimal(12);
                    cs.ClientBasePrice = dr.GetDecimal(13);
                    cs.ClientContinuePrice = dr.GetDecimal(14);
                    cs.ClientKgPrice = dr.GetDecimal(15);
                    cs.ClientDisposalCost = dr.GetDecimal(16);
                    cs.ClientRegisterCost = dr.GetDecimal(17);
                    cs.SelfBasePrice = dr.GetDecimal(18);
                    cs.SelfContinuePrice = dr.GetDecimal(19);
                    cs.SelfKgPrice = dr.GetDecimal(20);
                    cs.SelfDisposalCost = dr.GetDecimal(21);
                    cs.SelfRegisterCost = dr.GetDecimal(22);
                    cs.Id = dr.GetInt32(23);
                    cs.PreferentialGram = dr.GetDecimal(24);
                }
            }
            return cs;
        }

        public ChargeStandard GetChargeStandardById(int id)
        {
            ChargeStandard cs = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "SELECT carrier_id, carrier_area_id, encode, goods_type, start_weight, end_weight, base_weight, increase_weight, normal_base_price, normal_continue_price, normal_kg_price, normal_disposal_cost, normal_register_cost, client_base_price, client_continue_price, client_kg_price, client_disposal_cost, client_register_cost, self_base_price, self_continue_price, self_kg_price, self_disposal_cost, self_register_cost, id, preferential_gram FROM charge_standards WHERE id = @id ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    cs = new ChargeStandard();
                    cs.CarrierId = dr.GetInt32(0);
                    cs.CarrierAreaId = dr.GetInt32(1);
                    cs.Encode = dr.GetString(2);
                    cs.GoodsType = dr.GetByte(3);
                    cs.StartWeight = dr.GetDecimal(4);
                    cs.EndWeight = dr.GetDecimal(5);
                    cs.BaseWeight = dr.GetDecimal(6);
                    cs.IncreaseWeight = dr.GetDecimal(7);
                    cs.NormalBasePrice = dr.GetDecimal(8);
                    cs.NormalContinuePrice = dr.GetDecimal(9);
                    cs.NormalKgPrice = dr.GetDecimal(10);
                    cs.NormalDisposalCost = dr.GetDecimal(11);
                    cs.NormalRegisterCost = dr.GetDecimal(12);
                    cs.ClientBasePrice = dr.GetDecimal(13);
                    cs.ClientContinuePrice = dr.GetDecimal(14);
                    cs.ClientKgPrice = dr.GetDecimal(15);
                    cs.ClientDisposalCost = dr.GetDecimal(16);
                    cs.ClientRegisterCost = dr.GetDecimal(17);
                    cs.SelfBasePrice = dr.GetDecimal(18);
                    cs.SelfContinuePrice = dr.GetDecimal(19);
                    cs.SelfKgPrice = dr.GetDecimal(20);
                    cs.SelfDisposalCost = dr.GetDecimal(21);
                    cs.SelfRegisterCost = dr.GetDecimal(22);
                    cs.Id = dr.GetInt32(23);
                    cs.PreferentialGram = dr.GetDecimal(24);
                }
            }
            return cs;
        }

        public void DeleteChargeStandardById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "DELETE FROM charge_standards WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public List<CarrierCharge> GetCarrierCharge(int countryId, decimal weight, byte type, int count, int clientId)
        {
            List<CarrierCharge> result = new List<CarrierCharge>();
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@country_id", countryId),
                SqlUtilities.GenerateInputParameter("@weight", SqlDbType.Decimal, weight),
                SqlUtilities.GenerateInputParameter("@type", SqlDbType.TinyInt, type),
                SqlUtilities.GenerateInputIntParameter("@count", count)
            };
            string sql = "SELECT CA.carrier_id, CA.id, CS.id                                                                                         FROM carrier_area AS CA INNER JOIN charge_standards AS CS ON CA.id = CS.carrier_area_id                                                             WHERE carrier_area_id                                                                                                                               IN(SELECT carrier_area_id FROM area_countries WHERE country_id = @country_id)                                                                        AND start_weight <= @weight AND end_weight >= @weight                                                                                                AND goods_type = @type                                                                                                                              AND CS.carrier_id                                                                                                                                   IN(SELECT id FROM carriers WHERE  is_client_show=1 AND is_delete = 0 AND min_weight<= @weight AND (max_weight >= @weight OR max_weight = 0))";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    CarrierCharge cc = new CarrierCharge();
                    Carrier carrier = new CarrierDAL().GetCarrierById(dr.GetInt32(0));
                    cc.Carrier = carrier;
                    cc = GetClientCarrierChargeByParameter(countryId, weight, type, count, carrier.Id, clientId);
                    result.Add(cc);
                }
            }
            result.Sort();
            return result;
        }

        public List<CarrierCharge> GetSysCarrierCharge(int countryId, decimal weight, byte type, int count, int clientId)
        {
            List<CarrierCharge> result = new List<CarrierCharge>();
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@country_id", countryId),
                SqlUtilities.GenerateInputParameter("@weight", SqlDbType.Decimal, weight),
                SqlUtilities.GenerateInputParameter("@type", SqlDbType.TinyInt, type),
                SqlUtilities.GenerateInputIntParameter("@count", count)
            };
            string sql = "SELECT CA.carrier_id, CA.id, CS.id                                                                                         FROM carrier_area AS CA INNER JOIN charge_standards AS CS ON CA.id = CS.carrier_area_id                                                             WHERE carrier_area_id                                                                                                                               IN(SELECT carrier_area_id FROM area_countries WHERE country_id = @country_id)                                                                        AND start_weight <= @weight AND end_weight >= @weight                                                                                                AND goods_type = @type                                                                                                                              AND CS.carrier_id                                                                                                                                   IN(SELECT id FROM carriers WHERE is_delete = 0 AND min_weight<= @weight AND (max_weight >= @weight OR max_weight = 0))";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    CarrierCharge cc = new CarrierCharge();
                    Carrier carrier = new CarrierDAL().GetCarrierById(dr.GetInt32(0));
                    cc.Carrier = carrier;
                    cc = GetClientCarrierChargeByParameter(countryId, weight, type, count, carrier.Id, clientId);
                    result.Add(cc);
                }
            }
            result.Sort();
            return result;
        }

        private QuoteDetail GetClientQuoteDetailByParameters(int carrierAreaId, int clientId)
        {            
            QuoteDetail qd = new QuoteDetail();
            qd.Discount = 1;
            qd.PreferentialGram = 0;
            qd.RegisterCosts = 0;
            qd.IsRegisterAbate = true;
            SqlParameter[] param = new SqlParameter[] {                 
                SqlUtilities.GenerateInputIntParameter("@carrier_area_id", carrierAreaId),
                SqlUtilities.GenerateInputIntParameter("@client_id", clientId)
                };
            string sql = "SELECT TOP 1 discount, preferential_gram, is_register_abate, register_costs FROM quote_details WHERE client_id = @client_id AND status = 1 AND is_delete = 0 AND carrier_area_id = @carrier_area_id ORDER BY create_time DESC";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {                    
                    qd.Discount = dr.GetDecimal(0);
                    qd.PreferentialGram = dr.GetDecimal(1);
                    qd.IsRegisterAbate = dr.GetBoolean(2);
                    qd.RegisterCosts = dr.GetDecimal(3);
                }
            }
            return qd;
        }

        //public CarrierCharge GetCarrierChargeByParameter(int countryId, decimal weight, byte type, int count, int carrierId, int clientId)
        //{
        //    CarrierCharge cc = null;
        //    SqlParameter[] param = new SqlParameter[] {                 
        //        SqlUtilities.GenerateInputIntParameter("@country_id", countryId),
        //        SqlUtilities.GenerateInputParameter("@weight", SqlDbType.Decimal, weight),
        //        SqlUtilities.GenerateInputParameter("@type", SqlDbType.TinyInt, type),
        //        SqlUtilities.GenerateInputIntParameter("@count", count),
        //        SqlUtilities.GenerateInputIntParameter("@carrier_id", carrierId)
        //    };
        //    string sql = "SELECT CA.carrier_id, CA.id, CS.id,                                                                                       (CASE WHEN CS.normal_kg_price > 0                                                                                                                       THEN (CS.normal_kg_price*(CEILING(@weight/1)))*@count                                                                                                ELSE (CS.normal_base_price+ CS.normal_continue_price*(CEILING(@weight/CS.increase_weight)-1))*@count                                              END)AS normal_post_cost,                                                                                                                         (CASE WHEN CS.client_kg_price > 0                                                                                                                        THEN (CS.client_kg_price*(CEILING(@weight/1)))*@count                                                                                                ELSE (CS.client_base_price+ CS.client_continue_price*(CEILING(@weight/CS.increase_weight)-1))*@count                                             END)AS client_post_cost,                                                                                                                         (CASE WHEN CS.self_kg_price > 0                                                                                                                          THEN (CS.self_kg_price*(CEILING((@weight-CS.preferential_gram/1000)/1)))*@count                                                                      ELSE (CS.self_base_price+ CS.self_continue_price*(CEILING((@weight-CS.preferential_gram/1000)/CS.increase_weight)-1))*@count                     END)AS self_post_cost                                                                                                                              FROM carrier_area AS CA INNER JOIN charge_standards AS CS ON CA.id = CS.carrier_area_id                                                             WHERE carrier_area_id                                                                                                                               IN(SELECT carrier_area_id FROM area_countries WHERE country_id = @country_id)                                                                        AND start_weight <= @weight AND end_weight >= @weight                                                                                                AND goods_type = @type                                                                                                                              AND CS.carrier_id = @carrier_id";
        //    using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
        //    {
        //        while (dr.Read())
        //        {
        //            cc = new CarrierCharge();
        //            Carrier carrier = new CarrierDAL().GetCarrierById(dr.GetInt32(0));
        //            cc.Carrier = carrier;
        //            CarrierArea ca = new CarrierAreaDAL().GetCarrierAreaById(dr.GetInt32(1));
        //            cc.CarrierArea = ca;
        //            ChargeStandard cs = GetChargeStandardById(dr.GetInt32(2));
        //            QuoteDetail qd = GetClientQuoteDetailByParameters(ca.Id, clientId);
        //            decimal discount = qd.Discount;
        //            if (discount < 1)
        //            {
        //                cs.ClientBasePrice = Math.Round(cs.NormalBasePrice * discount, 2);
        //                cs.ClientContinuePrice = Math.Round(cs.NormalContinuePrice * discount, 2);
        //                cs.ClientDisposalCost = Math.Round(cs.NormalDisposalCost * discount, 2);
        //                cs.ClientKgPrice = Math.Round(cs.NormalKgPrice * discount, 2);
        //                cs.ClientRegisterCost = Math.Round(cs.NormalRegisterCost * discount, 2);
        //                cc.ClientPostCost = Math.Round(dr.GetDecimal(3) * discount, 2);
        //                cc.ClientTotalCost = Math.Round(dr.GetDecimal(3) * discount + (cs.NormalDisposalCost + cs.NormalRegisterCost) * discount * count, 2);
        //            }
        //            else
        //            {
        //                cc.ClientPostCost = dr.GetDecimal(4);
        //                cc.ClientTotalCost = Math.Round(dr.GetDecimal(4) + (cs.ClientDisposalCost + cs.ClientRegisterCost) * count, 2);
        //            }
        //            cc.ChargeStandard = cs;
        //            cc.SelfPostCost = dr.GetDecimal(5);
        //            cc.SelfTotalCost = Math.Round(dr.GetDecimal(5)+(cs.SelfDisposalCost+cs.SelfRegisterCost)*count, 2);
        //        }
        //    }
        //    return cc;
        //}

        public CarrierCharge GetClientCarrierChargeByParameter(int countryId, decimal weight, byte type, int count, int carrierId, int clientId)
        {
            CarrierCharge cc = null;
            SqlParameter[] param = new SqlParameter[] {                 
                SqlUtilities.GenerateInputIntParameter("@country_id", countryId),
                SqlUtilities.GenerateInputParameter("@weight", SqlDbType.Decimal, weight),
                SqlUtilities.GenerateInputParameter("@type", SqlDbType.TinyInt, type),
                SqlUtilities.GenerateInputIntParameter("@count", count),
                SqlUtilities.GenerateInputIntParameter("@carrier_id", carrierId)
            };
            string sql = "SELECT CA.carrier_id, CA.id, CS.id                                                                                         FROM carrier_area AS CA INNER JOIN charge_standards AS CS ON CA.id = CS.carrier_area_id                                                             WHERE carrier_area_id                                                                                                                               IN(SELECT carrier_area_id FROM area_countries WHERE country_id = @country_id)                                                                        AND start_weight <= @weight AND end_weight >= @weight                                                                                                AND goods_type = @type                                                                                                                              AND CS.carrier_id = @carrier_id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    cc = new CarrierCharge();
                    Carrier carrier = new CarrierDAL().GetCarrierById(dr.GetInt32(0));
                    cc.Carrier = carrier;
                    CarrierArea ca = new CarrierAreaDAL().GetCarrierAreaById(dr.GetInt32(1));
                    cc.CarrierArea = ca;
                    ChargeStandard cs = GetChargeStandardById(dr.GetInt32(2));
                    cc.ChargeStandard = cs;
                    
                    QuoteDetail qd = GetClientQuoteDetailByParameters(ca.Id, clientId);
                    decimal discount = qd.Discount;
                    decimal preferentialGram = qd.PreferentialGram;
                    if (!qd.IsRegisterAbate)
                    {
                        cs.ClientRegisterCost = cs.NormalRegisterCost;
                    }
                    if (qd.RegisterCosts != 0)
                    {
                        cs.ClientRegisterCost = qd.RegisterCosts;
                    }
                    if (preferentialGram > 0)
                    {
                        if (weight > (preferentialGram / 1000))
                        {
                            weight = weight - preferentialGram / 1000;
                            cs = GetActualWeightChargeStandardByParameters(countryId, weight, type, carrierId);
                            if (cs != null)
                            {
                                cc.ChargeStandard = cs;
                                if (!qd.IsRegisterAbate)
                                {
                                    cs.ClientRegisterCost = cs.NormalRegisterCost;
                                }
                                if (qd.RegisterCosts != 0)
                                {
                                    cs.ClientRegisterCost = qd.RegisterCosts;
                                }
                            }
                        }
                    }     

                    if (discount != 1 && discount !=0)
                    {
                        cs.ClientBasePrice = Math.Round(cs.NormalBasePrice * discount, 5);
                        cs.ClientContinuePrice = Math.Round(cs.NormalContinuePrice * discount, 5);
                        cs.ClientDisposalCost = cs.NormalDisposalCost;
                        cs.ClientKgPrice = Math.Round(cs.NormalKgPrice * discount, 5);
                        cs.ClientRegisterCost = Math.Round(cs.NormalRegisterCost * discount, 5);
                        if (!qd.IsRegisterAbate)
                        {
                            cs.ClientRegisterCost = cs.NormalRegisterCost;
                        }
                        if (qd.RegisterCosts != 0)
                        {
                            cs.ClientRegisterCost = qd.RegisterCosts;
                        }
                        if (cs.NormalKgPrice > 0)
                        {
                            cc.ClientPostCost = Math.Round(cs.ClientKgPrice * (Math.Ceiling(weight / 1)) * count, 5);
                            cc.ClientTotalCost = Math.Round(cc.ClientPostCost + (cs.ClientDisposalCost + cs.ClientRegisterCost) * count, 5);
                        }
                        else
                        {
                            decimal newWeight = weight - cs.BaseWeight;
                            if (newWeight < 0)
                            {
                                newWeight = 0;
                            }
                            cc.ClientPostCost = Math.Round((cs.ClientBasePrice + cs.ClientContinuePrice * (Math.Ceiling(newWeight / cs.IncreaseWeight))) * count, 5);
                            cc.ClientTotalCost = Math.Round(cc.ClientPostCost + (cs.ClientDisposalCost + cs.ClientRegisterCost + cc.ClientPostCost * carrier.FuelSgRate) * count, 5);
                        }
                    }
                    else
                    {
                        if (cs.ClientKgPrice > 0)
                        {
                            cc.ClientPostCost = Math.Round(cs.ClientKgPrice * (Math.Ceiling(weight / 1) * count), 5);
                            cc.ClientTotalCost = Math.Round(cc.ClientPostCost + (cs.ClientDisposalCost + cs.ClientRegisterCost + cc.ClientPostCost * carrier.FuelSgRate) * count, 5);
                        }
                        else
                        {
                            decimal newWeight = weight - cs.BaseWeight;
                            if (newWeight < 0)
                            {
                                newWeight = 0;
                            }
                            cc.ClientPostCost = Math.Round((cs.ClientBasePrice + cs.ClientContinuePrice * (Math.Ceiling(newWeight /                 cs.IncreaseWeight))) * count, 5);
                            cc.ClientTotalCost = Math.Round(cc.ClientPostCost + (cs.ClientDisposalCost + cs.ClientRegisterCost + cc.ClientPostCost * carrier.FuelSgRate) * count, 5);
                        }
                    }                    
                }
            }
            return cc;
        }

        private ChargeStandard GetActualWeightChargeStandardByParameters(int countryId, decimal weight, byte type, int carrierId)
        {
            ChargeStandard cs = null;
            SqlParameter[] param = new SqlParameter[] {                 
                SqlUtilities.GenerateInputIntParameter("@country_id", countryId),
                SqlUtilities.GenerateInputParameter("@weight", SqlDbType.Decimal, weight),
                SqlUtilities.GenerateInputParameter("@type", SqlDbType.TinyInt, type),
                SqlUtilities.GenerateInputIntParameter("@carrier_id", carrierId)
            };
            string sql = "SELECT CS.id                                                                                                              FROM carrier_area AS CA INNER JOIN charge_standards AS CS ON CA.id = CS.carrier_area_id                                                             WHERE carrier_area_id                                                                                                                               IN(SELECT carrier_area_id FROM area_countries WHERE country_id = @country_id)                                                                        AND start_weight <= @weight AND end_weight >= @weight                                                                                                AND goods_type = @type                                                                                                                              AND CS.carrier_id = @carrier_id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    cs = GetChargeStandardById(dr.GetInt32(0));
                }
            }
            return cs;
        }

        public CarrierCharge GetSelfCarrierChargeByParameter(int countryId, decimal weight, byte type, int count, int carrierId, int clientId)
        {
            CarrierCharge cc = null;
            SqlParameter[] param = new SqlParameter[] {                 
                SqlUtilities.GenerateInputIntParameter("@country_id", countryId),
                SqlUtilities.GenerateInputParameter("@weight", SqlDbType.Decimal, weight),
                SqlUtilities.GenerateInputParameter("@type", SqlDbType.TinyInt, type),
                SqlUtilities.GenerateInputIntParameter("@count", count),
                SqlUtilities.GenerateInputIntParameter("@carrier_id", carrierId)
            };
            string sql = "SELECT CA.carrier_id, CA.id, CS.id                                                                                         FROM carrier_area AS CA INNER JOIN charge_standards AS CS ON CA.id = CS.carrier_area_id                                                             WHERE carrier_area_id                                                                                                                               IN(SELECT carrier_area_id FROM area_countries WHERE country_id = @country_id)                                                                        AND start_weight <= @weight AND end_weight >= @weight                                                                                              AND goods_type = @type                                                                                                                              AND CS.carrier_id = @carrier_id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    cc = new CarrierCharge();
                    Carrier carrier = new CarrierDAL().GetCarrierById(dr.GetInt32(0));
                    cc.Carrier = carrier;
                    CarrierArea ca = new CarrierAreaDAL().GetCarrierAreaById(dr.GetInt32(1));
                    cc.CarrierArea = ca;
                    ChargeStandard cs = GetChargeStandardById(dr.GetInt32(2));                    
                    cc.ChargeStandard = cs;
                    if (cs.PreferentialGram > 0)
                    {
                        if (weight > (cs.PreferentialGram / 1000))
                        {
                            weight = weight - cs.PreferentialGram / 1000;
                            cs = GetActualWeightChargeStandardByParameters(countryId, weight, type, carrierId);
                            if (cs != null)
                            {
                                cc.ChargeStandard = cs;
                            }
                        }
                    }                 
                    if(cs.SelfKgPrice>0)
                    {
                        cc.SelfPostCost = cs.SelfKgPrice * (Math.Ceiling(weight /1))*count;
                        cc.SelfTotalCost = Math.Round(cc.SelfPostCost + (cs.SelfDisposalCost + cs.SelfRegisterCost + cc.ClientPostCost * carrier.FuelSgRate) * count, 5);
                    }
                    else
                    {
                        decimal newWeight = weight - cs.BaseWeight;
                        if (newWeight < 0)
                        {
                            newWeight = 0;
                        }
                        cc.SelfPostCost = (cs.SelfBasePrice + cs.SelfContinuePrice * (Math.Ceiling(newWeight / cs.IncreaseWeight))) * count;
                        cc.SelfTotalCost = Math.Round(cc.SelfPostCost + (cs.SelfDisposalCost + cs.SelfRegisterCost + cc.SelfPostCost * carrier.FuelSgRate) * count, 5);
                    }
                }
            }
            return cc;
        }
    }
}
