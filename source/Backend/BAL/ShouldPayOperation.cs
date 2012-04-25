using System;
using System.Collections.Generic;
using System.Text;
using Backend.DAL;
using Backend.Models;
using Backend.Models.Pagination;

namespace Backend.BAL
{
    public class ShouldPayOperation
    {
        private static readonly ShouldPayDAL dal = new ShouldPayDAL();

        public static void CreateShouldPay(ShouldPay sp)
        {
            dal.CreateShouldPay(sp);
        }

        public static ShouldPay GetShouldPayById(int id)
        {
            return dal.GetShouldPayById(id);
        }

        public static PaginationQueryResult<ShouldPay> GetShouldPayByCompanyId(PaginationQueryCondition condition, int compId)
        {
            return dal.GetShouldPayByCompanyId(condition, compId);
        }

        public static PaginationQueryResult<ShouldPay> GetShouldPayByParameters(PaginationQueryCondition condition, int compId, DateTime startDate, DateTime endDate, int carrierId)
        {
            return dal.GetShouldPayByParameters(condition, compId, startDate, endDate, carrierId);
        }

        public static List<ShouldPay> GetShouldPayByParameters(int compId, DateTime startDate, DateTime endDate, int carrierId)
        {
            return dal.GetShouldPayByParameters(compId, startDate, endDate, carrierId);
        }

        public static void DeleteShouldPayByIds(string ids)
        {
            string[] arrray = ids.Split(',');
            foreach (string sId in arrray)
            {
                int id = 0;
                if (int.TryParse(sId, out id))
                {
                    dal.DeleteShouldPayById(id);
                }
            }
        }

        public static void UpdateShouldPayIsPaid(int id)
        {
            dal.UpdateShouldPayIsPaid(id);
        }

        public static void DeleteShouldPayByOrderDetailId(int orderDetailId)
        {
            dal.DeleteShouldPayByOrderDetailId(orderDetailId);
        }
    }
}
