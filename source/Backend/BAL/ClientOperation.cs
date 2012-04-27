using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.Models.Pagination;
using Backend.DAL;
using Backend.Utilities;

namespace Backend.BAL
{     
    public class ClientOperation
    {
        private static readonly ClientDAL dal = new ClientDAL();

        public static bool CreateClient(Client client)
        {
            if (dal.GetClientByUsername(client.Username) != null)
            {
                return false;
            }
            client.Password = EncryptionHelper.EncryptString(client.Password);
            dal.CreateClient(client);
            return true;
        }

        public static Client GetClientByUsername(string username)
        {
            return dal.GetClientByUsername(username);
        }

        public static bool ClientLogin(Client client,out string msg)
        {
            Client newClient = null;
            newClient = dal.GetClientByUsername(client.Username);
            if (newClient == null)
            {                
                msg = "”√ªß√˚¥ÌŒÛ£°";
                return false;
            }

            if (newClient.Password == EncryptionHelper.EncryptString(client.Password))
            {
                msg = "";
                return true;
            }
            else
            {
                msg = "√‹¬Î¥ÌŒÛ£°";
                return false;
            }
        }

        public static Client GetClientById(int id)
        {
            return dal.GetClientById(id);
        }

        public static Client GetClientByRealName(string realName)
        {
            return dal.GetClientByRealName(realName);
        }

        public static PaginationQueryResult<Client> GetClient(PaginationQueryCondition condition)
        {
            return dal.GetClient(condition);
        }

        public static List<Client> GetClient()
        {
            return dal.GetClient();
        }

        public static PaginationQueryResult<Client> GetClientByCompanyId(PaginationQueryCondition condition)
        {
            return dal.GetClient(condition);
        }

        public static PaginationQueryResult<Client> GetClientByParameters(PaginationQueryCondition condition, string keyword)
        {
            return dal.GetClientByParameters(condition, keyword);
        }

        public static List<Client> GetClientList()
        {
            return dal.GetClientList();
        }

        public static List<Client> GetClientByParameters(string searchKey)
        {
            return dal.GetClientByParameters(searchKey);
        }

        public static void UpdateClientPwd(Client client)
        {
            client.Password = EncryptionHelper.EncryptString(client.Password);
            dal.UpdateClientPwd(client);
        }

        public static void UpdateClientInfo(Client client)
        {
            dal.UpdateClientInfo(client);
        }

        public static void UpdateClientBalance(Client client)
        {
            dal.UpdateClientBalance(client);
        }

        public static void UpdateClientDiscount(Client client)
        {
            dal.UpdateClientDiscount(client);
        }

        public static void DeleteClientByIds(string ids)
        {
            if (ids == null)
            {
                return;
            }
            string[] array = ids.Split(',');
            foreach (string sId in array)
            {
                int id = 0;
                if (int.TryParse(sId, out id))
                {
                    dal.DeleteClientById(id);
                }
            }
        }

        public static List<Client> GetClientStatistic(DateTime startDate, DateTime endDate)
        {
            return dal.GetClientStatistic(startDate, endDate);
        }
    }
}
