using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;

namespace Backend.Utilities
{
    public class EnumConvertor
    {      
        public static AreaCode ConvertToAreaCode(byte value)
        {
            switch (value)
            {
                case (byte)AreaCode.CHN_CENTER:
                    return AreaCode.CHN_CENTER;
                case (byte)AreaCode.CHN_EAST:
                    return AreaCode.CHN_EAST;
                case (byte)AreaCode.CHN_SOUTH:
                    return AreaCode.CHN_SOUTH;
                case (byte)AreaCode.CHN_NORTH:
                    return AreaCode.CHN_NORTH;                
                default:
                    throw new Exception("AreaCode " + value + " is illegal!");
            }
        }

        public static string AreaCodeConvertToString(byte value)
        {
            switch (value)
            {
                case (byte)AreaCode.CHN_CENTER:
                    return "����";
                case (byte)AreaCode.CHN_EAST:
                    return "����";
                case (byte)AreaCode.CHN_SOUTH:
                    return "����";
                case (byte)AreaCode.CHN_NORTH:
                    return "����";
                default:
                    throw new Exception("AreaCode " + value + " is illegal!");
            }
        }

        public static OrderStatus ConvertToOrderStatus(byte value)
        {
            switch (value)
            {
                case (byte)OrderStatus.WAIT_SUBMIT:
                    return OrderStatus.WAIT_SUBMIT;
                case (byte)OrderStatus.WAIT_AUDIT:
                    return OrderStatus.WAIT_AUDIT;
                case (byte)OrderStatus.DETAINED:
                    return OrderStatus.DETAINED;
                case (byte)OrderStatus.WAIT_CHECK:
                    return OrderStatus.WAIT_CHECK;
                case (byte)OrderStatus.FINISHED:
                    return OrderStatus.FINISHED;
                case (byte)OrderStatus.CANCELED:
                    return OrderStatus.CANCELED;
                default:
                    throw new Exception("OrderStatus " + value + " is illegal!");
            }
        }

        public static string OrderStatusConvertToString(byte value)
        {
            switch (value)
            {
                case (byte)OrderStatus.WAIT_SUBMIT:
                    return "���ύ";
                case (byte)OrderStatus.WAIT_AUDIT:
                    return "�����";
                case (byte)OrderStatus.DETAINED:
                    return "�ѿۻ�";
                case (byte)OrderStatus.WAIT_CHECK:
                    return "������";
                case (byte)OrderStatus.FINISHED:
                    return "�����";
                case (byte)OrderStatus.CANCELED:
                    return "��ȡ��";
                
                default:
                    throw new Exception("OrderStatus " + value + " is illegal!");
            }
        }

        public static PaymentStatus ConvertToPaymentStatus(byte value)
        {
            switch (value)
            {
                case (byte)PaymentStatus.UNPAID:
                    return PaymentStatus.UNPAID;
                case (byte)PaymentStatus.PARTIAL_PAID:
                    return PaymentStatus.PARTIAL_PAID;
                case (byte)PaymentStatus.ALL_PAID:
                    return PaymentStatus.ALL_PAID;
                default:
                    throw new Exception("PaymentStatus " + value + " is illegal!");
            }
        }

        public static string PaymentStatusConvertToString(byte value)
        {
            switch (value)
            {
                case (byte)PaymentStatus.UNPAID:
                    return "δ����";
                case (byte)PaymentStatus.PARTIAL_PAID:
                    return "���ָ���";
                case (byte)PaymentStatus.ALL_PAID:
                    return "�Ѹ�ȫ��";
                default:
                    throw new Exception("PaymentStatus " + value + " is illegal!");
            }
        }


        public static OrderType ConvertToOrderType(byte value)
        {
            switch (value)
            {
                case (byte)OrderType.CLIENT_ORDER:
                    return OrderType.CLIENT_ORDER;
                case (byte)OrderType.COMPANY_ORDER:
                    return OrderType.COMPANY_ORDER;
                default:
                    throw new Exception("OrderType " + value + " is illegal!");
            }
        }

        public static string OrderTypeConvertToString(byte value)
        {
            switch (value)
            {
                case (byte)OrderType.CLIENT_ORDER:
                    return "�ͻ��µ�";
                case (byte)OrderType.COMPANY_ORDER:
                    return "��˾�µ�";
                default:
                    throw new Exception("OrderType " + value + " is illegal!");
            }
        }

        public static PaymentType ConvertToPaymentType(byte value)
        {
            switch (value)
            {
                case (byte)PaymentType.NORMAL:
                    return PaymentType.NORMAL;
                case (byte)PaymentType.DEPOSIT:
                    return PaymentType.DEPOSIT;
                default:
                    throw new Exception("PaymentType " + value + " is illegal!");
            }
        }

        public static string PaymentTypeConvertToString(byte value)
        {
            switch (value)
            {
                case (byte)PaymentType.NORMAL:
                    return "��������";
                case (byte)PaymentType.DEPOSIT:
                    return "Ѻ��";
                default:
                    throw new Exception("PaymentType " + value + " is illegal!");
            }
        }

        public static CurrencyType ConvertToCurrencyType(byte value)
        {
            switch (value)
            {
                case (byte)CurrencyType.RMB:
                    return CurrencyType.RMB;
                case (byte)CurrencyType.USD:
                    return CurrencyType.USD;
                default:
                    throw new Exception("CurrencyType " + value + " is illegal!");
            }
        }

        public static string CurrencyTypeConvertToString(byte value)
        {
            switch (value)
            {
                case (byte)CurrencyType.RMB:
                    return "�����";
                case (byte)CurrencyType.USD:
                    return "��Ԫ";
                default:
                    throw new Exception("CurrencyType " + value + " is illegal!");
            }
        }

        public static string ContinentTypeConvertToString(byte value)
        {
            switch (value)
            {
                case (byte)ContinentType.ASIA:
                    return "����";
                case (byte)ContinentType.EUROPE:
                    return "ŷ��";
                case (byte)ContinentType.AFRICA:
                    return "����";
                case (byte)ContinentType.NORTH_AMERICA:
                    return "������";
                case (byte)ContinentType.SOUTH_AMERICA:
                    return "������";
                case (byte)ContinentType.OCEANIA:
                    return "������";
                case (byte)ContinentType.ANTARCTICA:
                    return "�ϼ���";
                default:
                    throw new Exception("ContinentType " + value + " is illegal!");
            }
        }

        public static string GoodsTypeConvertToString(byte value)
        {
            switch (value)
            {
                case 1:
                    return "����";
                case 2:
                    return "�ļ�";
                default:
                    throw new Exception("GoodsType " + value + " is illegal!");
            }
        }


        public static WrongOrderStatus ConvertToWrongOrderStatus(byte value)
        {
            switch (value)
            {
                case (byte)WrongOrderStatus.SEARCHED:
                    return WrongOrderStatus.SEARCHED;
                case (byte)WrongOrderStatus.SEND_SUCCESS:
                    return WrongOrderStatus.SEND_SUCCESS;
                case (byte)WrongOrderStatus.CONFIRM_PAPER:
                    return WrongOrderStatus.CONFIRM_PAPER;
                case (byte)WrongOrderStatus.FAXED_FILES:
                    return WrongOrderStatus.FAXED_FILES;
                case (byte)WrongOrderStatus.CLAIM_PAPER:
                    return WrongOrderStatus.CLAIM_PAPER;
                case (byte)WrongOrderStatus.SUBMIT_CLAIM:
                    return WrongOrderStatus.SUBMIT_CLAIM;
                case (byte)WrongOrderStatus.RECEIVED_PAID:
                    return WrongOrderStatus.RECEIVED_PAID;
                case (byte)WrongOrderStatus.PAY_FOR_CLIENT:
                    return WrongOrderStatus.PAY_FOR_CLIENT;
                case (byte)WrongOrderStatus.FINISHED:
                    return WrongOrderStatus.FINISHED;
                case (byte)WrongOrderStatus.OTHER:
                    return WrongOrderStatus.OTHER;
                default:
                    throw new Exception("WrongOrderStatus " + value + " is illegal!");
            }
        }

        public static string WrongOrderStatusConvertToString(byte value)
        {
            switch (value)
            {
                case (byte)WrongOrderStatus.SEARCHED:
                    return "�ѿ�����ѯ";
                case (byte)WrongOrderStatus.SEND_SUCCESS:
                    return "�ɹ�����";
                case (byte)WrongOrderStatus.CONFIRM_PAPER:
                    return "�յ�ȷ�Ϻ�";
                case (byte)WrongOrderStatus.FAXED_FILES:
                    return "�Ѵ���ȷ�Ϻ���Ͷ��֤���顢Ͷ�ļ�¼";
                case (byte)WrongOrderStatus.CLAIM_PAPER:
                    return "�յ����⺯";
                case (byte)WrongOrderStatus.SUBMIT_CLAIM:
                    return "�ѵݽ���������";
                case (byte)WrongOrderStatus.RECEIVED_PAID:
                    return "�յ����";
                case (byte)WrongOrderStatus.PAY_FOR_CLIENT:
                    return "д�����϶��������⳥���ͻ�";
                case (byte)WrongOrderStatus.FINISHED:
                    return "�������";
                case (byte)WrongOrderStatus.OTHER:
                    return "����";

                default:
                    throw new Exception("WrongOrderStatus " + value + " is illegal!");
            }
        }


        public static LiabilityEventType ConvertToLiabilityEventType(byte value)
        {
            switch (value)
            {
                case (byte)LiabilityEventType.ORDER_WRONG:
                    return LiabilityEventType.ORDER_WRONG;
                case (byte)LiabilityEventType.DAMAGE:
                    return LiabilityEventType.DAMAGE;
                case (byte)LiabilityEventType.RETURN:
                    return LiabilityEventType.RETURN;
                case (byte)LiabilityEventType.REMOTE:
                    return LiabilityEventType.REMOTE;
                case (byte)LiabilityEventType.OTHER:
                    return LiabilityEventType.OTHER;
                default:
                    throw new Exception("LiabilityEventType " + value + " is illegal!");
            }
        }

        public static string LiabilityEventTypeConvertToString(byte value)
        {
            switch (value)
            {
                case (byte)LiabilityEventType.ORDER_WRONG:
                    return "��������";
                case (byte)LiabilityEventType.DAMAGE:
                    return "��ʧ���⳥";
                case (byte)LiabilityEventType.RETURN:
                    return "�˼�";
                case (byte)LiabilityEventType.REMOTE:
                    return "ƫԶ�������ӷ�";
                case (byte)LiabilityEventType.OTHER:
                    return "����";
                default:
                    throw new Exception("LiabilityEventType " + value + " is illegal!");
            }
        }


        public static LiabilityStatus ConvertToLiabilityStatus(byte value)
        {
            switch (value)
            {
                case (byte)LiabilityStatus.WAIT_AUDIT:
                    return LiabilityStatus.WAIT_AUDIT;
                case (byte)LiabilityStatus.WAIT_CORRECT:
                    return LiabilityStatus.WAIT_CORRECT;
                case (byte)LiabilityStatus.WAIT_FINANCE:
                    return LiabilityStatus.WAIT_FINANCE;
                case (byte)LiabilityStatus.WAIT_CASHIER:
                    return LiabilityStatus.WAIT_CASHIER;
                case (byte)LiabilityStatus.FINISHED:
                    return LiabilityStatus.FINISHED; 
                default:
                    throw new Exception("LiabilityStatus " + value + " is illegal!");
            }
        }

        public static string LiabilityStatusConvertToString(byte value)
        {
            switch (value)
            {
                case (byte)LiabilityStatus.WAIT_AUDIT:
                    return "�����";
                case (byte)LiabilityStatus.WAIT_CORRECT:
                    return "������ȷ��";
                case (byte)LiabilityStatus.WAIT_FINANCE:
                    return "������ȷ��";
                case (byte)LiabilityStatus.WAIT_CASHIER:
                    return "������ȷ��";
                case (byte)LiabilityStatus.FINISHED:
                    return "���"; 

                default:
                    throw new Exception("LiabilityStatus " + value + " is illegal!");
            }
        }
       
    }
}
