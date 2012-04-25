using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public enum WrongOrderStatus
    {
        /// <summary>
        /// �ѿ�����ѯ
        /// </summary>        
        SEARCHED = 1,

        /// <summary>
        /// �ɹ�����
        /// </summary>
        SEND_SUCCESS = 2,

        /// <summary>
        /// �յ�ȷ�Ϻ�
        /// </summary>
        CONFIRM_PAPER = 3,

        /// <summary>
        /// �Ѵ���ȷ�Ϻ���Ͷ��֤���顢Ͷ�ļ�¼
        /// </summary>
        FAXED_FILES = 4,

        /// <summary>
        /// �յ����⺯
        /// </summary>
        CLAIM_PAPER = 5,

        /// <summary>
        /// �ѵݽ���������
        /// </summary>
        SUBMIT_CLAIM = 6,

        /// <summary>
        /// �յ����
        /// </summary>
        RECEIVED_PAID = 7,

        /// <summary>
        /// д�����϶��������⳥���ͻ�
        /// </summary>
        PAY_FOR_CLIENT = 8,

        /// <summary>
        /// �������
        /// </summary>
        FINISHED = 9,

        /// <summary>
        /// ����
        /// </summary>
        OTHER = 10
    }
}
