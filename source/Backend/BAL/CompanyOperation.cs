using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.DAL;
using Backend.Models.Pagination;
using Backend.Utilities;
using Backend.Models.Admin;

namespace Backend.BAL
{
    public class CompanyOperation
    {
        private static readonly CompanyDAL dal = new CompanyDAL();

        public static bool CreateCompany(Company company)
        {
            if (dal.GetCompanyByName(company.Name) != null)
            {
                return false;
            }
            dal.CreateCompany(company);
            return true;
        }

        public static List<Company> GetCompany()
        {
            return dal.GetCompany();
        }

        public static void DeleteCompanyByIds(string ids)
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
                    dal.DeleteCompanyById(id);
                }

            }
        }

        public static Company GetCompanyById(int id)
        {
            return dal.GetCompanyById(id);
        }

        public static void UpdateCompany(Company company)
        {
            dal.UpdateCompany(company);
        }

        public static void UpdateCompanyAuthorization(int compId, List<ModuleAuthorization> mas)
        {
            dal.UpdateCompanyAuthorization(compId, mas);
        }

        public static string GetCompanyRuleAuthorizationModuleIds(int companyId)
        {
            return dal.GetCompanyRuleAuthorizationModuleIds(companyId);
        }
    }
}
