using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public enum PaymentStatus
    {
        /// <summary>
        /// 未付款
        /// </summary>
        UNPAID = 1,

        /// <summary>
        /// 部分付款
        /// </summary>
        PARTIAL_PAID = 2,

        /// <summary>
        /// 已付全款
        /// </summary>
        ALL_PAID = 3
    }
}
