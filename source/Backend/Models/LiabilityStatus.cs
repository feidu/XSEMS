using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public enum LiabilityStatus
    {
        /// <summary>
        /// �����
        /// </summary>
        WAIT_AUDIT = 1,

        /// <summary>
        /// ������ȷ��
        /// </summary>
        WAIT_CORRECT = 2,

        /// <summary>
        /// ������ȷ��
        /// </summary>
        WAIT_FINANCE = 3,

        /// <summary>
        /// ������ȷ��
        /// </summary>
        WAIT_CASHIER = 4,

        /// <summary>
        /// ���
        /// </summary>
        FINISHED = 5
    }
}
