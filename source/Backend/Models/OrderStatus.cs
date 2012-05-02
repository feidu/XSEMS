using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public enum OrderStatus
    {
        /// <summary>
        /// �����
        /// </summary>
        WAIT_AUDIT = 1,

        /// <summary>
        /// �����
        /// </summary>
        AUDITED = 2,

        /// <summary>
        /// �ѿۻ�
        /// </summary>
        DETAINED = 3,

        /// <summary>
        /// ������
        /// </summary>
        WAIT_CHECK = 4,

        /// <summary>
        /// �����
        /// </summary>
        FINISHED = 5,

        /// <summary>
        /// ��ȡ��
        /// </summary>
        CANCELED = 6
    }
}
