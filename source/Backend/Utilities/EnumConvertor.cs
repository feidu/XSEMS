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
                    return "华中";
                case (byte)AreaCode.CHN_EAST:
                    return "华东";
                case (byte)AreaCode.CHN_SOUTH:
                    return "华南";
                case (byte)AreaCode.CHN_NORTH:
                    return "华北";
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
                    return "待提交";
                case (byte)OrderStatus.WAIT_AUDIT:
                    return "待审核";
                case (byte)OrderStatus.DETAINED:
                    return "已扣货";
                case (byte)OrderStatus.WAIT_CHECK:
                    return "待检验";
                case (byte)OrderStatus.FINISHED:
                    return "已完成";
                case (byte)OrderStatus.CANCELED:
                    return "已取消";
                
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
                    return "未付款";
                case (byte)PaymentStatus.PARTIAL_PAID:
                    return "部分付款";
                case (byte)PaymentStatus.ALL_PAID:
                    return "已付全款";
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
                    return "客户下单";
                case (byte)OrderType.COMPANY_ORDER:
                    return "公司下单";
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
                    return "正常付款";
                case (byte)PaymentType.DEPOSIT:
                    return "押金";
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
                    return "人民币";
                case (byte)CurrencyType.USD:
                    return "美元";
                default:
                    throw new Exception("CurrencyType " + value + " is illegal!");
            }
        }

        public static string ContinentTypeConvertToString(byte value)
        {
            switch (value)
            {
                case (byte)ContinentType.ASIA:
                    return "亚洲";
                case (byte)ContinentType.EUROPE:
                    return "欧洲";
                case (byte)ContinentType.AFRICA:
                    return "非洲";
                case (byte)ContinentType.NORTH_AMERICA:
                    return "北美洲";
                case (byte)ContinentType.SOUTH_AMERICA:
                    return "南美洲";
                case (byte)ContinentType.OCEANIA:
                    return "大洋洲";
                case (byte)ContinentType.ANTARCTICA:
                    return "南极洲";
                default:
                    throw new Exception("ContinentType " + value + " is illegal!");
            }
        }

        public static string GoodsTypeConvertToString(byte value)
        {
            switch (value)
            {
                case 1:
                    return "包裹";
                case 2:
                    return "文件";
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
                    return "已开档查询";
                case (byte)WrongOrderStatus.SEND_SUCCESS:
                    return "成功派送";
                case (byte)WrongOrderStatus.CONFIRM_PAPER:
                    return "收到确认函";
                case (byte)WrongOrderStatus.FAXED_FILES:
                    return "已传真确认函、投寄证明书、投寄记录";
                case (byte)WrongOrderStatus.CLAIM_PAPER:
                    return "收到索赔函";
                case (byte)WrongOrderStatus.SUBMIT_CLAIM:
                    return "已递交索赔资料";
                case (byte)WrongOrderStatus.RECEIVED_PAID:
                    return "收到赔款";
                case (byte)WrongOrderStatus.PAY_FOR_CLIENT:
                    return "写责任认定交财务赔偿给客户";
                case (byte)WrongOrderStatus.FINISHED:
                    return "处理完毕";
                case (byte)WrongOrderStatus.OTHER:
                    return "其它";

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
                    return "开单错误";
                case (byte)LiabilityEventType.DAMAGE:
                    return "损失与赔偿";
                case (byte)LiabilityEventType.RETURN:
                    return "退件";
                case (byte)LiabilityEventType.REMOTE:
                    return "偏远地区附加费";
                case (byte)LiabilityEventType.OTHER:
                    return "其它";
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
                    return "待审核";
                case (byte)LiabilityStatus.WAIT_CORRECT:
                    return "待更正确认";
                case (byte)LiabilityStatus.WAIT_FINANCE:
                    return "待财务确认";
                case (byte)LiabilityStatus.WAIT_CASHIER:
                    return "待出纳确认";
                case (byte)LiabilityStatus.FINISHED:
                    return "完成"; 

                default:
                    throw new Exception("LiabilityStatus " + value + " is illegal!");
            }
        }
       
    }
}
