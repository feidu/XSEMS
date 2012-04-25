using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.DAL;
using Backend.Models.Pagination;

namespace Backend.BAL
{
    public class LiabilityOperation
    {
        private static readonly LiabilityDAL dal = new LiabilityDAL();

        public static void CreateLiability(Liability ly)
        {
            dal.CreateLiability(ly);
        }

        public static Liability GetLiabilityByEncode(string encode)
        {
            return dal.GetLiabilityByEncode(encode);
        }

        public static Liability GetLiabilityById(int id)
        {
            return dal.GetLiabilityById(id);
        }

        public static void DeleteLiabilityByIds(string ids)
        {
            string[] array = ids.Split(',');
            foreach (string sId in array)
            {
                int id = 0;
                if (int.TryParse(sId, out id))
                {
                    dal.DeleteLiabilityById(id);
                }
            }
        }

        public static void UpdateLiability(Liability ly)
        {
            dal.UpdateLiability(ly);
        }

        public static PaginationQueryResult<Liability> GetLiabilityByCompanyId(PaginationQueryCondition condition, int companyId)
        {
            return dal.GetLiabilityByCompanyId(condition, companyId);
        }

        public static PaginationQueryResult<Liability> GetLiabilityByCompanyIdAndDate(PaginationQueryCondition condition, int companyId, DateTime startDate, DateTime endDate)
        {
            return dal.GetLiabilityByCompanyIdAndDate(condition, companyId, startDate, endDate);
        }

        public static PaginationQueryResult<Liability> GetFinishedLiabilityByParameters(PaginationQueryCondition condition, int companyId, DateTime startDate, DateTime endDate)
        {
            return dal.GetFinishedLiabilityByParameters(condition, companyId, startDate, endDate);
        }
    }
}
