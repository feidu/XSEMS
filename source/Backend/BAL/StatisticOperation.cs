using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.DAL;

namespace Backend.BAL
{
    public class StatisticOperation
    {
        private static readonly StatisticDAL dal = new StatisticDAL();

        public static List<UserSales> GetUserSalesStatistic(DateTime startDate, DateTime endDate, int companyId, int userId)
        {
            return dal.GetUserSalesStatistic(startDate, endDate, companyId, userId);
        }

        public static List<UserSales> GetUserAssessStatistic(DateTime startDate, DateTime endDate, int companyId, int clientId, string carrierEncode, int userId)
        {
            return dal.GetUserAssessStatistic(startDate, endDate, companyId, clientId, carrierEncode, userId);
        }

        public static List<CompanySales> GetCompanySalesStatistic(DateTime startDate, DateTime endDate, int companyId, int userId)
        {
            return dal.GetCompanySalesStatistic(startDate, endDate, companyId, userId);
        }

        public static List<ShouldReceive> GetShouldReceiveStatistic(DateTime startDate, DateTime endDate, int clientId)
        {
            return dal.GetShouldReceiveStatistic(startDate, endDate, clientId);
        }

        public static List<Recharge> GetRechargeStatistic(DateTime startDate, DateTime endDate, int clientId, string pmIds)
        {
            return dal.GetRechargeStatistic(startDate, endDate, clientId, pmIds);
        }

        public static List<ClientRecharge> GetRechargeDetailStatistic(DateTime startDate, DateTime endDate, int clientId, string pmIds)
        {
            return dal.GetRechargeDetailStatistic(startDate, endDate,  clientId, pmIds);
        }
    }
}
