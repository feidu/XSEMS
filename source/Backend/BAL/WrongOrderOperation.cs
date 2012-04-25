using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.DAL;
using Backend.Models.Pagination;

namespace Backend.BAL
{
    public class WrongOrderOperation
    {
        private static readonly WrongOrderDAL dal = new WrongOrderDAL();
        public static void CreateWrongOrder(WrongOrder wo)
        {
            dal.CreateWrongOrder(wo);
        }

        public static void UpdateWrongOrder(WrongOrder wo)
        {
            dal.UpdateWrongOrder(wo);
        }

        public static WrongOrder GetWrongOrderById(int id)
        {
            return dal.GetWrongOrderById(id);
        }

        public static WrongOrder GetWrongOrderByEncode(string encode)
        {
            return dal.GetWrongOrderByEncode(encode);
        }

        public static void DeleteWrongOrderById(int id)
        {
            dal.DeleteWrongOrderById(id);
        }

        public static void DeleteWrongOrderByIds(string ids)
        {
            string[] array = ids.Split(',');
            foreach (string sId in array)
            {
                int id = 0;
                if (int.TryParse(sId, out id))
                {
                    dal.DeleteWrongOrderById(id);
                }
            }
        }

        public static PaginationQueryResult<WrongOrder> GetWrongOrderByCompanyId(PaginationQueryCondition condition, int companyId)
        {
            return dal.GetWrongOrderByCompanyId(condition, companyId);
        }

        public static PaginationQueryResult<WrongOrder> GetWrongOrderByClientId(PaginationQueryCondition condition, int clientId)
        {
            return dal.GetWrongOrderByClientId(condition, clientId);
        }

        public static PaginationQueryResult<WrongOrder> GetWrongOrderByClientIdAndDate(PaginationQueryCondition condition, int clientId, DateTime startDate, DateTime endDate)
        {
            return dal.GetWrongOrderByClientIdAndDate(condition, clientId, startDate, endDate);
        }

        public static PaginationQueryResult<WrongOrder> GetWrongOrderByCompanyIdAndDate(PaginationQueryCondition condition, int companyId, DateTime startDate, DateTime endDate)
        {
            return dal.GetWrongOrderByCompanyIdAndDate(condition, companyId, startDate, endDate);
        }

        public static void CreateWrongOrderDetail(WrongOrderDetail wod)
        {
            dal.CreateWrongOrderDetail(wod);
        }

        public static void UpdateWrongOrderDetail(WrongOrderDetail wod)
        {
            dal.UpdateWrongOrderDetail(wod);
        }

        public static WrongOrderDetail GetWrongOrderDetailById(int id)
        {
            return dal.GetWrongOrderDetailById(id);
        }

        public static void DeleteWrongOrderDetailById(int id)
        {
            dal.DeleteWrongOrderDetailById(id);
        }

        public static void DeleteWrongOrderDetailByIds(string ids)
        {
            string[] array = ids.Split(',');
            foreach (string sId in array)
            {
                int id = 0;
                if (int.TryParse(sId, out id))
                {
                    dal.DeleteWrongOrderDetailById(id);
                }
            }
        }

        public static List<WrongOrderDetail> GetWrongOrderDetailByWrongOrderId(int woId)
        {
            return dal.GetWrongOrderDetailByWrongOrderId(woId);
        }
    }
}
