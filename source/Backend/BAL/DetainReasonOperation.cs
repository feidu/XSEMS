using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.DAL;

namespace Backend.BAL
{
    public class DetainReasonOperation
    {
        private static readonly DetainReasonDAL dal = new DetainReasonDAL();

        public static void CreateDetainReason(DetainReason dr)
        {
            dal.CreateDetainReason(dr);
        }

        public static DetainReason GetDetainReasonByOrderId(int orderId)
        {
            return dal.GetDetainReasonByOrderId(orderId);
        }
    }
}

