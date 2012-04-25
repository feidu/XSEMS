using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public enum LiabilityStatus
    {
        /// <summary>
        /// 待审核
        /// </summary>
        WAIT_AUDIT = 1,

        /// <summary>
        /// 待更正确认
        /// </summary>
        WAIT_CORRECT = 2,

        /// <summary>
        /// 待财务确认
        /// </summary>
        WAIT_FINANCE = 3,

        /// <summary>
        /// 待出纳确认
        /// </summary>
        WAIT_CASHIER = 4,

        /// <summary>
        /// 完成
        /// </summary>
        FINISHED = 5
    }
}
