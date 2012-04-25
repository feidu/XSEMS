using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public enum DailyCostStatus
    {
        /// <summary>
        /// ´ýÉóºË
        /// </summary>
        WAIT_AUDIT = 1,

        /// <summary>
        /// ÉóºËÍ¨¹ý
        /// </summary>
        AUDIT_THROUGH = 2
    }
}
