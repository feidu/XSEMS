using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.DAL;
using Backend.Models.Pagination;

namespace Backend.BAL
{
    public class DailyCostOperation
    {
        private static readonly DailyCostDAL dal = new DailyCostDAL();

        public static void CreateDailyCost(DailyCost dc)
        {
            dal.CreateDailyCost(dc);
        }

        public static void DeleteDailyCostByIds(string ids)
        {
            string[] arrray = ids.Split(',');
            foreach (string sId in arrray)
            {
                int id = 0;
                if (int.TryParse(sId, out id))
                {
                    dal.DeleteDailyCostById(id);
                }
            }
        }

        public static DailyCost GetDailyCostById(int id)
        {
            return dal.GetDailyCostById(id);
        }

        public static PaginationQueryResult<DailyCost> GetDailyCostByCompanyId(PaginationQueryCondition condition, int compId)
        {
            return dal.GetDailyCostByCompanyId(condition, compId);
        }

        public static PaginationQueryResult<DailyCost> GetDailyCostByCompanyIdAndDate(PaginationQueryCondition condition, int compId, DateTime startDate, DateTime endDate)
        {
            return dal.GetDailyCostByCompanyIdAndDate(condition, compId, startDate, endDate);
        }
    }
}
