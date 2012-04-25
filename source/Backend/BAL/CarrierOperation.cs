using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.DAL;

namespace Backend.BAL
{
    public class CarrierOperation
    {
        private static readonly CarrierDAL dal = new CarrierDAL();

        public static bool CreateCarrier(Carrier carrier)
        {
            if (dal.GetCarrierByEncode(carrier.Encode) != null)
            {
                return false;
            }
            dal.CreateCarrier(carrier);
            return true;
        }

        public static void UpdateCarrier(Carrier carrier)
        {
            dal.UpdateCarrier(carrier);
        }

        public static Carrier GetCarrierById(int id)
        {
            return dal.GetCarrierById(id);
        }

        public static Carrier GetCarrierByEncode(string encode)
        {
            return dal.GetCarrierByEncode(encode);
        }

        public static List<Carrier> GetCarrier()
        {
            return dal.GetCarrier();
        }

        public static void DeleteCarrierByIds(string ids)
        {
            if (ids == null)
            {
                return;
            }
            string[] array = ids.Split(',');
            foreach (string sId in array)
            {
                int id = 0;
                if(int.TryParse(sId, out id))
                {
                    dal.DeleteCarrierById(id);
                }
            }
 
        }
    }
}
