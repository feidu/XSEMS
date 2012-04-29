using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.Models.Pagination;
using Backend.DAL;
using Backend.Utilities;

namespace Backend.BAL
{
    public class OrderOperation
    {
        private static readonly OrderDAL dal = new OrderDAL();

        public static void CreateClientOrder(Order order)
        {
            dal.CreateClientOrder(order);
        }

        public static void CreateOrder(Order order)
        {
            dal.CreateOrder(order);
        }

        public static void UpdateOrder(Order order)
        {
            dal.UpdateOrder(order);
        }

        public static void UpdateClientOrder(Order order)
        {
            dal.UpdateClientOrder(order);
        }

        public static void UpdateOrderStatus(Order order)
        {
            dal.UpdateOrderStatus(order);
        }

        public static void UpdateOrderAuditInfo(Order order)
        {
            dal.UpdateOrderAuditInfo(order);
        }

        public static void UpdateOrderCheckInfo(Order order)
        {
            dal.UpdateOrderCheckInfo(order);
        }

        public static void UpdateOrderIsMailSend(Order order)
        {
            dal.UpdateOrderIsMailSend(order);
        }

        public static void UpdateOrderReason(Order order)
        {
            dal.UpdateOrderReason(order);
        }

        public static void DeleteOrderById(int id)
        {
            dal.DeleteOrderById(id);
            new OrderDetailDAL().DeleteOrderDetailByOrderId(id);
        }

        public static void DeleteOrderByIds(string ids)
        {
            string[] array = ids.Split(',');
            foreach (string sId in array)
            {
                int id = 0;
                if (int.TryParse(sId, out id))
                {
                    dal.DeleteOrderById(id);
                    new OrderDetailDAL().DeleteOrderDetailByOrderId(id);
                }
            }
        }

        public static Order GetOrderById(int id)
        {
            return dal.GetOrderById(id);
        }

        public static Order GetOrderByEncode(string encode)
        {
            return dal.GetOrderByEncode(encode);
        }
        
        public static Order GetOrderByClientIdAndEncode(int clientId, string encode)
        {
            return dal.GetOrderByClientIdAndEncode(clientId, encode);
        }

        public static Order GetOrderByClientIdEncodeAndStatus(int clientId, string encode, OrderStatus status)
        {
            return dal.GetOrderByClientIdEncodeAndStatus(clientId, encode, status);
        }

        public static Order GetTodayClientOrderByParameters(int clientId, DateTime dtToday)
        {
            return dal.GetTodayClientOrderByParameters(clientId, dtToday);
        }

        //public static PaginationQueryResult<Order> GetOrderCostByClientId(PaginationQueryCondition condition, int clientId)
        //{
        //    return dal.GetOrderCostByClientId(condition, clientId); 
        //}

        //public static PaginationQueryResult<Order> GetOrderCostByClientIdAndDate(PaginationQueryCondition condition, int clientId, DateTime startDate, DateTime endDate)
        //{
        //    return dal.GetOrderCostByClientIdAndDate(condition, clientId, startDate, endDate);
        //}

        public static PaginationQueryResult<SearchOrderDetail> GetOrderCostsDetailByParameters(PaginationQueryCondition condition, int clientId, DateTime startDate, DateTime endDate, string barCode, string remark)
        {
            return dal.GetOrderCostsDetailByParameters(condition, clientId, startDate, endDate, barCode, remark);
        }

        public static PaginationQueryResult<SearchOrderDetail> GetOrderCostsPostInfoDetailsByParameters(PaginationQueryCondition condition, int clientId, DateTime startDate, DateTime endDate, string barCode, string remark)
        {
            return dal.GetOrderCostsPostInfoDetailsByParameters(condition, clientId, startDate, endDate, barCode, remark);
        }

        public static List<SearchOrderDetail> GetOrderCostsDetailByParameters(int clientId, DateTime startDate, DateTime endDate, string barCode, string remark)
        {
            return dal.GetOrderCostsDetailByParameters(clientId, startDate, endDate, barCode, remark);
        }

        public static decimal GetClientTodayOrderCostsByParameters(int clientId)
        {
            return dal.GetClientTodayOrderCostsByParameters(clientId);
        }

        public static PaginationQueryResult<Order> GetOrderByClientId(PaginationQueryCondition condition, int cId)
        {
            return dal.GetOrderByClientId(condition, cId);
        }

        public static PaginationQueryResult<Order> GetOrderByClientIdAndStatus(PaginationQueryCondition condition, int cId, OrderStatus status)
        {
            return dal.GetOrderByClientIdAndStatus(condition, cId, status);
        }

        public static PaginationQueryResult<Order> GetOrderByClientIdAndDate(PaginationQueryCondition condition, int clientId, DateTime startDate, DateTime endDate)
        {
            return dal.GetOrderByClientIdAndDate(condition, clientId, startDate, endDate);
        }

        public static PaginationQueryResult<Order> GetOrderByClientIdStatusAndDate(PaginationQueryCondition condition, int clientId, OrderStatus status, DateTime startDate, DateTime endDate)
        {
            return dal.GetOrderByClientIdStatusAndDate(condition, clientId, status, startDate, endDate);
        }

        public static PaginationQueryResult<Order> GetOrderByStatus(PaginationQueryCondition condition, OrderStatus status)
        {
            return dal.GetOrderByStatus(condition, status);
        }

        public static PaginationQueryResult<Order> GetOrderByStatusAndEncode(PaginationQueryCondition condition, OrderStatus status, string encode)
        {
            return dal.GetOrderByStatusAndEncode(condition, status, encode);
        }

        public static PaginationQueryResult<Order> GetOrderByStatusAndDate(PaginationQueryCondition condition, OrderStatus status, DateTime startDate, DateTime endDate)
        {
            return dal.GetOrderByStatusAndDate(condition, status, startDate, endDate);
        }

        public static PaginationQueryResult<Order> GetAuditOrderByConsignType(PaginationQueryCondition condition, int consignType)
        {
            return dal.GetAuditOrderByConsignType(condition, consignType);
        }

        public static PaginationQueryResult<Order> GetAuditOrderByConsignTypeAndEncode(PaginationQueryCondition condition, int consignType, string encode)
        {
            return dal.GetAuditOrderByConsignTypeAndEncode(condition, consignType, encode);
        }

        public static PaginationQueryResult<Order> GetAuditOrderByConsignTypeAndDate(PaginationQueryCondition condition, int consignType, DateTime startDate, DateTime endDate)
        {
            return dal.GetAuditOrderByConsignTypeAndDate(condition, consignType, startDate, endDate);
        }

        public static PaginationQueryResult<SearchOrder> GetSearchOrderByParameters(PaginationQueryCondition condition, string carrierEncode, int clientId, string encode, string ydEncode, string barCode, DateTime startDate, DateTime endDate, byte status)
        {
            return dal.GetSearchOrderByParameters(condition, carrierEncode, clientId, encode, ydEncode, barCode, startDate, endDate, status);
        }

        public static List<SearchOrder> GetReceiveOrderStatistic(DateTime startDate, DateTime endDate, int clientId, string carrierEncode)
        {
            return dal.GetReceiveOrderStatistic(startDate, endDate, clientId, carrierEncode);
        }

        public static List<SearchOrderDetail> GetReceiveOrderDetailStatistic(DateTime startDate, DateTime endDate, int clientId, string carrierEncode)
        {
            return dal.GetReceiveOrderDetailStatistic(startDate, endDate, clientId, carrierEncode);
        }

        public static List<SearchOrderDetail> GetEaduOrderDetailStatistic(DateTime startDate, DateTime endDate, int clientId, string carrierEncode)
        {
            return dal.GetEaduOrderDetailStatistic(startDate, endDate, clientId, carrierEncode);
        }

        public static List<SearchOrderDetail> GetFetchCostsStatistic(DateTime startDate, DateTime endDate, int clientId, string carrierEncode, int userId)
        {
            return dal.GetFetchCostsStatistic(startDate, endDate, clientId, carrierEncode, userId);
        }

        public static List<SearchOrderDetail> GetNotOnlineOrderDetail(DateTime startDate, int judgeDays, int clientId, string carrierEncode)
        {
            return dal.GetNotOnlineOrderDetail(startDate, judgeDays, clientId, carrierEncode);
        }
    }
}
