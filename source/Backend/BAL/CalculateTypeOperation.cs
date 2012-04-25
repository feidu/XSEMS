using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.DAL;

namespace Backend.BAL
{
    public class CalculateTypeOperation
    {
        private static readonly CalculateTypeDAL dal = new CalculateTypeDAL();

        public static bool CreateCalculateType(CalculateType ct)
        {
            if (dal.GetCalculateTypeByName(ct.Name) != null)
            {
                return false;
            }
            dal.CreateCalculateType(ct);
            return true;
        }

        public static void UpdateCalculateType(CalculateType ct)
        {
            dal.UpdateCalculateType(ct);
        }

        public static CalculateType GetCalculateTypeById(int id)
        {
            return dal.GetCalculateTypeById(id);
        }

        public static List<CalculateType> GetCalculateType()
        {
            return dal.GetCalculateType();
        }

        public static void DeleteCalculateTypeByIds(string ids)
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
                    dal.DeleteCalculateTypeById(id);
                }
            }

        }
    }
}
