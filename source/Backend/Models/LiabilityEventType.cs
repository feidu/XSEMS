using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public enum LiabilityEventType
    {
        /// <summary>
        /// 开单错误
        /// </summary>        
        ORDER_WRONG = 1,

        /// <summary>
        /// 损失与赔偿
        /// </summary>
        DAMAGE = 2,

        /// <summary>
        /// 退件
        /// </summary>
        RETURN = 3,

        /// <summary>
        /// 偏远地区附加费
        /// </summary>
        REMOTE = 4,

        /// <summary>
        /// 其它
        /// </summary>
        OTHER = 5,
    }
}
