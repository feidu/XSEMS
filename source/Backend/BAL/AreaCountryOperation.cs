using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.DAL;

namespace Backend.BAL
{
    public class AreaCountryOperation
    {
        private static readonly AreaCountryDAL dal = new AreaCountryDAL();

        public static void CreateAreaCountry(AreaCountry ac)
        {
            dal.CreateAreaCountry(ac);
        }

        public static List<AreaCountry> GetAreaCountryByCarrierAreaId(int id)
        {
            return dal.GetAreaCountryByCarrierAreaId(id);
        }

        public static void DeleteAreaCountryByCarrierAreaId(int id)
        {
            dal.DeleteAreaCountryByCarrierAreaId(id);
        }

    }
}
