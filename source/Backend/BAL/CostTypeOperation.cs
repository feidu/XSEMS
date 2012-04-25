using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.DAL;

namespace Backend.BAL
{
    public class CostTypeOperation
    {
        private static readonly CostTypeDAL dal = new CostTypeDAL();

        public static bool CreateCostType(CostType ct)
        {
            if (dal.GetCostTypeByName(ct.Name) != null)
            {
                return false;
            }
            dal.CreateCostType(ct);
            return true;
        }

        public static void UpdateCostType(CostType ct)
        {
            dal.UpdateCostType(ct);
        }

        public static CostType GetCostTypeById(int id)
        {
            return dal.GetCostTypeById(id);
        }

        public static List<CostType> GetCostType()
        {
            return dal.GetCostType();
        }

        public static void DeleteCostTypeByIds(string ids)
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
                    dal.DeleteCostTypeById(id);
                }
            }

        }
    }
}
