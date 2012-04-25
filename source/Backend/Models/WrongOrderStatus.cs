using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public enum WrongOrderStatus
    {
        /// <summary>
        /// 已开档查询
        /// </summary>        
        SEARCHED = 1,

        /// <summary>
        /// 成功派送
        /// </summary>
        SEND_SUCCESS = 2,

        /// <summary>
        /// 收到确认函
        /// </summary>
        CONFIRM_PAPER = 3,

        /// <summary>
        /// 已传真确认函、投寄证明书、投寄记录
        /// </summary>
        FAXED_FILES = 4,

        /// <summary>
        /// 收到索赔函
        /// </summary>
        CLAIM_PAPER = 5,

        /// <summary>
        /// 已递交索赔资料
        /// </summary>
        SUBMIT_CLAIM = 6,

        /// <summary>
        /// 收到赔款
        /// </summary>
        RECEIVED_PAID = 7,

        /// <summary>
        /// 写责任认定交财务赔偿给客户
        /// </summary>
        PAY_FOR_CLIENT = 8,

        /// <summary>
        /// 处理完毕
        /// </summary>
        FINISHED = 9,

        /// <summary>
        /// 其它
        /// </summary>
        OTHER = 10
    }
}
