using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.DAL;

namespace Backend.BAL
{
    public class DepotOperation
    {
        private static readonly DepotDAL dal = new DepotDAL();

        public static bool CreateDepot(Depot depot)
        {
            if (dal.GetDepotByName(depot.Name) != null)
            {
                return false;
            }
            dal.CreateDepot(depot);
            return true;
        }

        public static void UpdateDepot(Depot depot)
        {
            dal.UpdateDepot(depot);
        }

        public static Depot GetDepotById(int id)
        {
            return dal.GetDepotById(id);
        }

        public static List<Depot> GetDepot()
        {
            return dal.GetDepot();
        }

        public static List<Depot> GetDepotByCompanyId(int compId)
        {
            return dal.GetDepotByCompanyId(compId);
        }

        public static void DeleteDepotByIds(string ids)
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
                    dal.DeleteDepotById(id);
                }
            }
        }
    }
}
