using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public enum OrderType
    {
        /// <summary>
        /// 客户下单
        /// </summary>        
        CLIENT_ORDER = 1,

        /// <summary>
        /// 公司下单
        /// </summary>
        COMPANY_ORDER = 2
       
    }
}
