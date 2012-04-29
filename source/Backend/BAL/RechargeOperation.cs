using System;
using System.Collections.Generic;
using System.Text;
using Backend.DAL;
using Backend.Models;
using Backend.Models.Pagination;

namespace Backend.BAL
{
    public class RechargeOperation
    {
        private static readonly RechargeDAL dal = new RechargeDAL();

        public static void CreateRecharge(Recharge recharge)
        {
            dal.CreateRecharge(recharge);
        }

        public static List<Recharge> GetRechargeStatistic(DateTime startDate, DateTime endDate, int companyId, int clientId, int userId, int receiveUserId, string pmIds)
        {
            return dal.GetRechargeStatistic(startDate, endDate, clientId, pmIds);
        }

        public static PaginationQueryResult<Recharge> GetRechargeByClientId(PaginationQueryCondition condition, int clientId)
        {
            return dal.GetRechargeByClientId(condition, clientId);
        }

        public static PaginationQueryResult<Recharge> GetRechargeByClientIdAndDate(PaginationQueryCondition condition, int clientId, DateTime startDate, DateTime endDate)
        {
            return dal.GetRechargeByClientIdAndDate(condition, clientId, startDate, endDate);
        }

        public static PaginationQueryResult<Recharge> GetRechargeByCompanyId(PaginationQueryCondition condition, int companyId)
        {
            return dal.GetRechargeByCompanyId(condition, companyId);
        }

        public static PaginationQueryResult<Recharge> GetRechargeByCompanyIdAndDate(PaginationQueryCondition condition, int companyId, DateTime startDate, DateTime endDate)
        {
            return dal.GetRechargeByCompanyIdAndDate(condition, companyId, startDate, endDate);
        }

        public static Recharge GetRechargeById(int id)
        {
            return dal.GetRechargeById(id);
        }

        public static void DeleteRechargeById(int id)
        {
            dal.DeleteRechargeById(id);
        }

        public static void DeleteRechargeByIds(string ids)
        {
            string[] arrray = ids.Split(',');
            foreach (string sId in arrray)
            {
                int id = 0;
                if (int.TryParse(sId, out id))
                {
                    dal.DeleteRechargeById(id);
                }
            }
        }
    }
}
