using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.DAL;

namespace Backend.BAL
{
    public class ChargeStandardOperation
    {
        private static readonly ChargeStandardDAL dal = new ChargeStandardDAL();

        public static void CreateChargeStandard(ChargeStandard cs)
        {
            dal.CreateChargeStandard(cs);
        }

        public static string GetNextEncode(int carrierAreaId)
        {
            return dal.GetNextEncode(carrierAreaId);
        }

        public static List<ChargeStandard> GetChargeStandardByCarrierAreaId(int carrierAreaId)
        {
            return dal.GetChargeStandardByCarrierAreaId(carrierAreaId);
        }

        public static List<ChargeStandard> GetChargeStandardByCarrierId(int carrierId)
        {
            return dal.GetChargeStandardByCarrierId(carrierId);
        }

        public static void UpdateChargeStandard(ChargeStandard cs)
        {
            dal.UpdateChargeStandard(cs);
        }

        public static ChargeStandard GetChargeStandardByEncode(int carrierAreaId, string encode)
        {
            return dal.GetChargeStandardByEncode(carrierAreaId, encode);
        }

        public static void DeleteChargeStandardByIds(string ids)
        {
            string[] array = ids.Split(',');
            foreach (string sId in array)
            {
                int id = 0;
                if (int.TryParse(sId, out id))
                {
                    dal.DeleteChargeStandardById(id);
                }
            }
        }

        public static List<CarrierCharge> GetCarrierCharge(int countryId, decimal weight, byte type, int count, int clientId)
        {
            return dal.GetCarrierCharge(countryId, weight, type, count, clientId);
        }

        public static List<CarrierCharge> GetSysCarrierCharge(int countryId, decimal weight, byte type, int count, int clientId)
        {
            return dal.GetSysCarrierCharge(countryId, weight, type, count, clientId);
        }

        //public static CarrierCharge GetCarrierChargeByParameter(int countryId, decimal weight, byte type, int count, int carrierId, int clientId)
        //{
        //    return dal.GetCarrierChargeByParameter(countryId, weight, type, count, carrierId, clientId);
        //}

        public static CarrierCharge GetClientCarrierChargeByParameter(int countryId, decimal weight, byte type, int count, int carrierId, int clientId)
        {
            return dal.GetClientCarrierChargeByParameter(countryId, weight, type, count, carrierId, clientId);
        }
        
        public static CarrierCharge GetSelfCarrierChargeByParameter(int countryId, decimal weight, byte type, int count, int carrierId, int clientId)
        {
            return dal.GetSelfCarrierChargeByParameter(countryId, weight, type, count, carrierId, clientId);
        }
    }
}
