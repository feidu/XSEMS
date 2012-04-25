using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.DAL;
using Backend.Models.Pagination;

namespace Backend.BAL
{
    public class FetchArrangeOperation
    {
        private static readonly FetchArrangeDAL dal = new FetchArrangeDAL();

        public static void CreateFetchArrange(FetchArrange fa)
        {
            dal.CreateFetchArrange(fa);
        }

        public static void UpdateFetchArrange(FetchArrange fa)
        {
            dal.UpdateFetchArrange(fa);
        }

        public static void DeleteFetchArrangeById(int id)
        {
            dal.DeleteFetchArrangeById(id);
        }

        public static void DeleteFetchArrangeByIds(string ids)
        {
            string[] array = ids.Split(',');
            foreach (string sId in array)
            {
                int id = 0;
                if (int.TryParse(sId, out id))
                {
                    dal.DeleteFetchArrangeById(id);
                }

            }
        }

        public static FetchArrange GetFetchArrangeById(int id)
        {
            return dal.GetFetchArrangeById(id);
        }

        public static PaginationQueryResult<FetchArrange> GetFetchArrangeByCompanyId(PaginationQueryCondition condition, int companyId)
        {
            return dal.GetFetchArrangeByCompanyId(condition, companyId);
        }

        public static PaginationQueryResult<FetchArrange> GetFetchArrangeByCompanyIdAndDate(PaginationQueryCondition condition, int companyId, DateTime startDate, DateTime endDate)
        {
            return dal.GetFetchArrangeByCompanyIdAndDate(condition, companyId, startDate, endDate);
        }
    }
}
