using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.DAL;

namespace Backend.BAL
{
    public class OrderDetailOperation
    {
        private static readonly OrderDetailDAL dal = new OrderDetailDAL();

        public static void CreateOrderDetail(OrderDetail od)
        {
            dal.CreateOrderDetail(od);
        }

        public static void CreateClientOrderDetail(OrderDetail od)
        {
            dal.CreateClientOrderDetail(od);
        }

        public static void UpdateOrderDetail(OrderDetail od)
        {
            dal.UpdateOrderDetail(od);
        }

        public static void UpdateClientOrderDetail(OrderDetail od)
        {
            dal.UpdateClientOrderDetail(od);
        }

        public static void DeleteOrderDetailById(int id)
        {
            OrderDetail od = dal.GetOrderDetailById(id);            
            Order order = new OrderDAL().GetOrderById(od.OrderId);
            order.Costs = order.Costs - od.TotalCosts;
            order.SelfCosts = order.SelfCosts - od.SelfTotalCosts;
            OrderOperation.UpdateOrder(order);
            dal.DeleteOrderDetailById(id);
        }

        public static void DeleteOrderDetailByIds(string ids)
        {
            string[] array = ids.Split(',');
            foreach (string sId in array)
            {
                int id = 0;
                if(int.TryParse(sId, out id))
                {                   
                    OrderDetail od = dal.GetOrderDetailById(id);
                    if (od.TotalCosts > 0)
                    {
                        Order order = new OrderDAL().GetOrderById(od.OrderId);
                        order.Costs = order.Costs - od.TotalCosts;
                        order.SelfCosts = order.SelfCosts - od.SelfTotalCosts;
                        OrderOperation.UpdateOrder(order);
                    }
                    dal.DeleteOrderDetailById(id);
                }
            }
        }

        public static OrderDetail GetOrderDetailById(int id)
        {
            return dal.GetOrderDetailById(id);
        }

        public static bool GetOrderDetaiByBarCode(string barCode)
        {
            return dal.GetOrderDetaiByBarCode(barCode);
        }

        public static List<OrderDetail> GetOrderDetailByOrderId(int orderId)
        {
            return dal.GetOrderDetailByOrderId(orderId);
        }

        public static void UpdateOrderDetailCancelInfo(OrderDetail od)
        {
            dal.UpdateOrderDetailCancelInfo(od);
        }

        public static void UpdateOrderDetailPostStatus(string barCode)
        {
            dal.UpdateOrderDetailPostStatus(barCode);
        }

        public static void UpdateOrderDetailPostInfo(string barCode, string postStatus, DateTime lastDisposalTime)
        {
            dal.UpdateOrderDetailPostInfo(barCode, postStatus, lastDisposalTime);
        }

        public static bool CheckEncodeExist(string encode)
        {
            return dal.CheckEncodeExist(encode);
        }
    }
}
