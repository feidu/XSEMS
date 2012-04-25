using System;
using System.Collections.Generic;
using System.Text;
using Backend.DAL;
using Backend.Models;
using Backend.Models.Pagination;

namespace Backend.BAL
{
    public class ShouldReceiveOperation
    {
        private static readonly ShouldReceiveDAL dal = new ShouldReceiveDAL();

        public static void CreateOrderShouldReceive(ShouldReceive sr)
        {
            dal.CreateOrderShouldReceive(sr);
        }

        public static void DeleteShouldReceiveByIds(string ids)
        {
            string[] arrray = ids.Split(',');
            foreach (string sId in arrray)
            {
                int id = 0;
                if (int.TryParse(sId, out id))
                {
                    dal.DeleteShouldReceiveById(id);
                }
            }
        }

        public static void DeleteShouldReceiveById(int id)
        {
            dal.DeleteShouldReceiveById(id);
        }

        public static void UpdateShouldReceive(ShouldReceive sr)
        {
            dal.UpdateShouldReceive(sr);
        }

        public static ShouldReceive GetShouldReceiveById(int id)
        {
            return dal.GetShouldReceiveById(id);
        }

        public static ShouldReceive GetShouldReceiveByEncode(string encode)
        {
            return dal.GetShouldReceiveByEncode(encode);
        }

        public static ShouldReceive GetShouldReceivedByEncode(string encode)
        {
            return dal.GetShouldReceivedByEncode(encode);
        }

        public static void DeleteShouldReceiveByOrderId(int orderId)
        {
            dal.DeleteShouldReceiveByOrderId(orderId);
        }

        public static ShouldReceive GetShouldReceiveByOrderId(int orderId)
        {
            return dal.GetShouldReceiveByOrderId(orderId);
        }

        public static ShouldReceive GetShouldReceivedByOrderId(int orderId)
        {
            return dal.GetShouldReceivedByOrderId(orderId);
        }

        public static List<ShouldReceive> GetShouldReceiveByClientId(int clientId)
        {
            return dal.GetShouldReceiveByClientId(clientId);
        }

        public static PaginationQueryResult<ShouldReceive> GetShouldReceiveByParameter(PaginationQueryCondition condition, int compId, bool status, DateTime startDate, DateTime endDate)
        {
            return dal.GetShouldReceiveByParameter(condition, compId, status, startDate, endDate);
        }

        public static void CreateReceivedDeducted(ReceivedDeducted rd)
        {
            dal.CreateReceivedDeducted(rd);
        }

        public static void DeleteReceivedDeductedBySrEncode(string srEncode)
        {
            dal.DeleteReceivedDeductedBySrEncode(srEncode);
        }

        public static void DeleteReceivedDeductedById(int id)
        {
            dal.DeleteReceivedDeductedById(id);
        }

        public static ReceivedDeducted GetReceivedDeductedBySrEncode(string srEncode)
        {
            return dal.GetReceivedDeductedBySrEncode(srEncode);
        }

        public static List<ReceivedDeducted> GetReceivedDeductedByRechargeEncode(string arEncode)
        {
            return dal.GetReceivedDeductedByRechargeEncode(arEncode);
        }

        public static void UpdateReceivedDeducted(ReceivedDeducted rd)
        {
            dal.UpdateReceivedDeducted(rd);
        }

        public static PaginationQueryResult<ReceivedDeducted> GetReceivedDeductedByParameter(PaginationQueryCondition condition, int compId, DateTime startDate, DateTime endDate)
        {
            return dal.GetReceivedDeductedByParameter(condition, compId, startDate, endDate);
        }
    }
}
