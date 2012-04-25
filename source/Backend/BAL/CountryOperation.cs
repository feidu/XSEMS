using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.DAL;
using Backend.Utilities;
using Backend.Models.Pagination;

namespace Backend.BAL
{
    public class CountryOperation
    {
        private static readonly CountryDAL dal = new CountryDAL();

        public static bool CreateCountry(Country country)
        {
            if (dal.GetCountryByEnglishName(country.EnglishName) != null)
            {
                return false;
            }
            dal.CreateCountry(country);
            return true;
        }

        public static void UpdateCountry(Country country)
        {
            dal.UpdateCountry(country);
        }

        public static Country GetCountryById(int id)
        {
            return dal.GetCountryById(id);
        }
        public static Country GetCountryByEnglishName(string name)
        {
            return dal.GetCountryByEnglishName(name);
        }

        public static List<Country> GetCountry()
        {
            return dal.GetCountry();
        }

        public static List<Country> GetCountryForArea()
        {
            return dal.GetCountryForArea();
        }

        public static List<Country> GetCountryBySearchKey(string searchKey)
        {
            return dal.GetCountryBySearchKey(searchKey);
        }

        public static PaginationQueryResult<Country> GetCountry(PaginationQueryCondition condition)
        {
            return dal.GetCountry(condition);
        }

        public static void DeleteCountryByIds(string ids)
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
                    dal.DeleteCountryById(id);
                }
            }

        }
    }
}
