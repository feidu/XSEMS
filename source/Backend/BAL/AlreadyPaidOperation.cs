using System;
using System.Collections.Generic;
using System.Text;
using Backend.DAL;
using Backend.Models;
using Backend.Models.Pagination;

namespace Backend.BAL
{
    public class AlreadyPaidOperation
    {
        private static readonly AlreadyPaidDAL dal = new AlreadyPaidDAL();

        public static void CreateAlreadyPaid(AlreadyPaid ap)
        {
            dal.CreateAlreadyPaid(ap);
        }

        public static void DeleteAlreadyPaidByIds(string ids)
        {
            string[] arrray = ids.Split(',');
            foreach (string sId in arrray)
            {
                int id = 0;
                if (int.TryParse(sId, out id))
                {
                    dal.DeleteAlreadyPaidById(id);
                }
            }
        }

        public static AlreadyPaid GetAlreadyPaidById(int id)
        {
            return dal.GetAlreadyPaidById(id);
        }

        public static PaginationQueryResult<AlreadyPaid> GetAlreadyPaidByCompanyId(PaginationQueryCondition condition, int compId)
        {
            return dal.GetAlreadyPaidByCompanyId(condition, compId);
        }

        public static PaginationQueryResult<AlreadyPaid> GetAlreadyPaidByCompanyIdAndDate(PaginationQueryCondition condition, int compId, DateTime startDate, DateTime endDate)
        {
            return dal.GetAlreadyPaidByCompanyIdAndDate(condition, compId, startDate, endDate);
        }
    }
}
