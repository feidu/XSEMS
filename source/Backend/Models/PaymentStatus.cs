using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public enum PaymentStatus
    {
        /// <summary>
        /// δ����
        /// </summary>
        UNPAID = 1,

        /// <summary>
        /// ���ָ���
        /// </summary>
        PARTIAL_PAID = 2,

        /// <summary>
        /// �Ѹ�ȫ��
        /// </summary>
        ALL_PAID = 3
    }
}
