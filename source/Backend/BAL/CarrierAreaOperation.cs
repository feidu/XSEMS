using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.DAL;
using Backend.Models.Pagination;

namespace Backend.BAL
{
    public class CarrierAreaOperation
    {
        private static readonly CarrierAreaDAL dal = new CarrierAreaDAL();

        public static bool CreateCarrierArea(CarrierArea ca)
        {
            if (dal.GetCarrierAreaByName(ca.Name, ca.Carrier.Id) != null)
            {
                return false;
            }
            dal.CreateCarrierArea(ca);
            return true;
        }

        public static List<CarrierArea> GetCarrierAreaByCarrierId(int id)
        {
            return dal.GetCarrierAreaByCarrierId(id);
        }

        public static PaginationQueryResult<CarrierArea> GetCarrierArea(PaginationQueryCondition condition)
        {
            return dal.GetCarrierArea(condition);
        }

        public static string GetNextEncode()
        {
            return dal.GetNextEncode();
        }

        public static CarrierArea GetCarrierAreaById(int id)
        {
            return dal.GetCarrierAreaById(id);
        }

        public static void UpdateCarrierArea(CarrierArea ca)
        {
            dal.UpdateCarrierArea(ca);
        }

        public static void DeleteCarrierAreaByIds(string ids)
        {
            if (ids == null)
            {
                return;
            }
            string[] array = ids.Split(',');
            foreach (string sId in array)
            {
                int id = 0;
                if (int.TryParse(sId, out id))
                {
                    dal.DeleteCarrierAreaById(id);
                }
            }
        }
    }
}
