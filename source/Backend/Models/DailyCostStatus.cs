using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public enum DailyCostStatus
    {
        /// <summary>
        /// �����
        /// </summary>
        WAIT_AUDIT = 1,

        /// <summary>
        /// ���ͨ��
        /// </summary>
        AUDIT_THROUGH = 2
    }
}
