using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public enum LiabilityEventType
    {
        /// <summary>
        /// ��������
        /// </summary>        
        ORDER_WRONG = 1,

        /// <summary>
        /// ��ʧ���⳥
        /// </summary>
        DAMAGE = 2,

        /// <summary>
        /// �˼�
        /// </summary>
        RETURN = 3,

        /// <summary>
        /// ƫԶ�������ӷ�
        /// </summary>
        REMOTE = 4,

        /// <summary>
        /// ����
        /// </summary>
        OTHER = 5,
    }
}
