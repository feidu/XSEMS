using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.DAL;

namespace Backend.BAL
{
    public class ClientAddressOpreation
    {
        private static readonly ClientAddressDAL dal = new ClientAddressDAL();

        public static void CreateClientAddress(ClientAddress ca)
        {
            dal.CreateClientAddress(ca);
        }

        public static List<ClientAddress> GetClientAddressByClientId(int clientId)
        {
            return dal.GetClientAddressByClientId(clientId);
        }

        public static ClientAddress GetClientAddressById(int id)
        {
            return dal.GetClientAddressById(id);
        }

        public static void DeleteClientAddressById(int caId)
        {
            dal.DeleteClientAddressById(caId);
        }
    }
}
