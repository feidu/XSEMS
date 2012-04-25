using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.DAL;
using Backend.Utilities;
using Backend.Models.Pagination;

namespace Backend.BAL
{
    public class ClientOrderOperation
    {
        private static readonly ClientOrderDAL dal = new ClientOrderDAL();

        public static void CreateClientOrder(ClientOrder co)
        {
            dal.CreateClientOrder(co);
        }

        public static List<ClientOrder> GetClientOrderById(int clientId)
        {
            return dal.GetClientOrderByClientId(clientId);
        }

        public static PaginationQueryResult<ClientOrder> GetClientOrderByParameters(PaginationQueryCondition condition, int clientId, DateTime startDate, DateTime endDate)
        {
            return dal.GetClientOrderByParameters(condition, clientId, startDate, endDate);
        }

        public static List<ClientOrder> GetClientOrderListByParameters(int clientId, DateTime startDate, DateTime endDate)
        {
            return dal.GetClientOrderListByParameters(clientId, startDate, endDate);
        }

        public static void DeleteClientOrderByIds(string ids)
        {
            string[] strArray=ids.Split(',');
            foreach (string sId in strArray)
            {
                int id = 0;
                if (int.TryParse(sId, out id))
                {
                    dal.DeleteClientOrderById(id);
                }
            }
        }

        public static void DeleteClientOrderById(int id)
        {
            dal.DeleteClientOrderById(id);
        }

        public static void DeleteClientOrderByClientId(int clintId)
        {
            dal.DeleteClientOrderByClientId(clintId);
        }
    }
}
