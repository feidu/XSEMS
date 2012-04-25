using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.DAL;

namespace Backend.BAL
{
    public class PaymentMethodOperation
    {
        private static readonly PaymentMethodDAL dal = new PaymentMethodDAL();

        public static bool CreatePaymentMethod(PaymentMethod pm)
        {
            if (dal.GetPaymentMethodByName(pm.Name) != null)
            {
                return false;
            }
            dal.CreatePaymentMethod(pm);
            return true;
        }

        public static void UpdatePaymentMethod(PaymentMethod pm)
        {
            dal.UpdatePaymentMethod(pm);
        }

        public static PaymentMethod GetPaymentMethodById(int id)
        {
            return dal.GetPaymentMethodById(id);
        }

        public static List<PaymentMethod> GetPaymentMethod()
        {
            return dal.GetPaymentMethod();
        }

        public static void DeletePaymentMethodByIds(string ids)
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
                    dal.DeletePaymentMethodById(id);
                }
            }

        }
    
    }
}
