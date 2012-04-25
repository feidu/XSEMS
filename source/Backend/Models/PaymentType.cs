using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public enum PaymentType
    {
        /// <summary>
        /// 正常付款
        /// </summary>
        NORMAL = 1,

        /// <summary>
        /// 押金
        /// </summary>
        DEPOSIT = 2
    }
}
