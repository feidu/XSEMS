using System;
using System.Text;
using Backend.Models;
using Backend.DAL;
using System.Collections.Generic;

namespace Backend.BAL
{
    public class ReceivableAccountOperation
    {
        private static readonly ReceivableAccountDAL dal = new ReceivableAccountDAL();

        public static bool CreateReceivableAccount(ReceivableAccount ra)
        {
            if (dal.GetReceivableAccountByNumber(ra.AccountNumber) != null)
            {
                return false;
            }
            dal.CreateReceivableAccount(ra);
            return true;
        }

        public static void UpdateReceivableAccount(ReceivableAccount ra)
        {
            dal.UpdateReceivableAccount(ra);
        }

        public static ReceivableAccount GetReceivableAccountById(int id)
        {
            return dal.GetReceivableAccountById(id);
        }

        public static List<ReceivableAccount> GetReceivableAccount()
        {
            return dal.GetReceivableAccount();
        }

        //public static List<ReceivableAccount> GetReceivableAccountByCompanyId(int compId)
        //{
        //    return dal.GetReceivableAccountByCompanyId(compId);
        //}

        public static void DeleteReceivableAccountByIds(string ids)
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
                    dal.DeleteReceivableAccountById(id);
                }
            }

        }
    }
}
