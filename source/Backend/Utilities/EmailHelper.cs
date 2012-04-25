using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mail;
using Backend.Models;
using Backend.BAL;

namespace Backend.Utilities
{
    public class EmailHelper
    {
        public static bool SendMail(Company company, Client client, string title, string content, out string msg)
        {
            string mailFrom = company.Email;
            string mailAccount = mailFrom.Substring(0, mailFrom.IndexOf('@'));
            string mailPwd = company.EmailPassword;
            string smtp = company.Smtp;
            string mailTo = client.Email;

            Setting setting = SettingOperation.LoadSetting();

            StringBuilder sb = new StringBuilder();
            sb.Append("<table border='0' cellspacing='0' cellpadding='0' width='100%' style='font-size:12px; line-height:24px;'>");
            sb.Append("<tr><td align='left' valign='top'>尊敬的" + client.RealName + "：<br/>");
            sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;您好！<br/>");
            sb.Append("</td></tr>");
            sb.Append("<tr><td align='left' valign='top'>");
            sb.Append(content);
            sb.Append("</td></tr>");
            sb.Append("<tr><td align='left' valign='top'>");
            sb.Append("<br/><br/><br/>");
            sb.Append("顺祝商祺！<br/>");
            sb.Append("亿度物流<br/>");
            sb.Append(DateTime.Now.ToShortDateString() + "<br/><br/>");
            sb.Append("此邮件为系统邮件，请勿直接回复！<br/>");
            sb.Append("若有疑问请发邮件至客服邮箱："+setting.Email+" 或来电："+company.Phone+"");
            sb.Append("</td></tr>");
            sb.Append("</table>");

            MailMessage objMailMessage = new MailMessage();
            objMailMessage.From = mailFrom;
            objMailMessage.To = mailTo;
            objMailMessage.Subject = title;
            objMailMessage.Body = sb.ToString();
            objMailMessage.BodyFormat = MailFormat.Html;
            objMailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
            //用户名 
            objMailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", mailAccount);
            //密码 
            objMailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", mailPwd);
            SmtpMail.SmtpServer = smtp;

            if (client.IsMessage)
            {
                try
                {
                    SmtpMail.Send(objMailMessage);
                    msg = "操作成功，邮件已成功发送！";
                    return true;
                }
                catch (Exception ex)
                {
                    msg = "操作成功，但公司或客户邮箱有误，邮件发送失败！";
                    return false;
                }
            }
            else
            {
                msg = "操作成功！";
                return false;
            }
        }

        public static bool SendMailForArrearage(Company company, Client client, decimal money, out string msg)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;您本次发货欠款" + money.ToString() + " 元，您当前的账户余额为RMB " + client.Balance.ToString() + " 元，请及时充值，以免影响您下次发货和信用额度的增加！");
            return SendMail(company, client, "欠款通知", sb.ToString(), out msg);
        }

        public static bool SendMailForReceiveMoney(Company company, Client client, decimal money, out string msg)
        {
            StringBuilder sb = new StringBuilder();                       
            sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;我司已收到您本次付款RMB "+money.ToString()+" 元，您当前的账户余额为RMB "+client.Balance.ToString()+" 元，请核对，有问题请与您的业务人员联系！");
            return SendMail(company, client, "收款通知", sb.ToString(), out msg); 
        }

        public static List<Client> SendMailForAnnounce(Company company, List<Client> result, string title, string content)
        {
            List<Client> listClients = new List<Client>();
            content = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + content;
            if (result.Count > 0)
            {
                foreach (Client client in result)
                {
                    string msg = "";
                    if (!SendMail(company, client, title, content, out msg))
                    {
                        listClients.Add(client);
                    }
                }
            }
            return listClients;
        }

        public static bool SendMailForBill(DateTime startDate, DateTime endDate, Company company, Client client, List<SearchOrderDetail> result, out string msg)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;以下是您 "+startDate.ToShortDateString()+" 至 "+endDate.ToShortDateString()+" 的对账单：<br/><br/>");
            sb.Append("<table border='1' cellspacing='0' cellpadding='0' width='100%' style='line-height:18px;font-size:12px;'>");
            sb.Append("<tr style='font-weight:bold;'>");
            sb.Append("<td align='left' valign='middle'>&nbsp;日期</td>");
            sb.Append("<td align='left' valign='middle'>&nbsp;承运商</td><td align='left' valign='middle'>&nbsp;包裹单号</td>");
            sb.Append("<td align='left' valign='middle'>&nbsp;国家</td><td align='right' valign='middle'>重量(KG)</td>");
            sb.Append("<td align='right' valign='middle'>数量</td><td align='right' valign='middle'>费用(￥)</td>");
            sb.Append("</tr>");
            decimal totalMoney = 0;
            foreach (SearchOrderDetail sod in result)
            {
                sb.Append("<tr>");
                sb.Append("<td align='left' valign='middle'>&nbsp;" + sod.CreateTime.ToShortDateString() + "</td>");
                sb.Append("<td align='left' valign='middle'>&nbsp;" + CarrierOperation.GetCarrierByEncode(sod.CarrierEncode).Name + "</td><td align='left' valign='middle'>&nbsp;" + sod.BarCode + "</td>");
                sb.Append("<td align='left' valign='middle'>&nbsp;" + sod.ToCountry + "</td><td align='right' valign='middle'>&nbsp;" + sod.Weight.ToString() + "</td>");
                sb.Append("<td align='right' valign='middle'>&nbsp;" + sod.Count.ToString() + "</td>");
                sb.Append("<td align='right' valign='middle'>&nbsp;" + sod.TotalCosts.ToString() + "</td></tr>");

                totalMoney += sod.TotalCosts;
            }
            sb.Append("<tr style='font-weight:bold;'><td align='left'>&nbsp;合计：</td><td colspan='5'>&nbsp;</td><td align='right'>&nbsp;" + totalMoney.ToString() + "</td></tr>");
            sb.Append("</table>");
            return SendMail(company, client, "对账单", sb.ToString(), out msg);
        }

        public static bool SendMailForService(Company company, Client client, WrongOrderDetail wod, out string msg)
        {
            StringBuilder sb = new StringBuilder();
            WrongOrder wrongOrder = WrongOrderOperation.GetWrongOrderById(wod.WrongOrderId);
            sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;您的服务信息有更新：<br/>");
            sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;条号码："+wrongOrder.BarCode+"<br/>");
            sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;服务内容："+wrongOrder.Reason+"<br/>");
            sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;处理方式及过程："+wod.Detail+"<br/>");
            sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;处理结果："+wod.Result+"<br/>");
            sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;处理人："+UserOperation.GetUserById(wod.CreateUserId).RealName+"<br/>");

            return SendMail(company, client, "客户服务有更新", sb.ToString(), out msg);
        }

        public static bool SendMailForConsign(Company company, Client client, Order order, out string msg)
        {
            StringBuilder sb = new StringBuilder();
            List<OrderDetail> result = OrderDetailOperation.GetOrderDetailByOrderId(order.Id);
            
            sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;以下是您本次的货运单：<br/><br/>");
            sb.Append("<table border='1' cellspacing='0' cellpadding='0' width='100%' style='font-size:12px;'>");
            sb.Append("<tr>");
            sb.Append("<td width='9%' align='right' valign='middle'>收件单号:</td><td width='36%' align='left' valign='middle'>&nbsp;" + order.Encode + "</td>");
            sb.Append("<td width='9%' align='right' valign='middle'>收件日期:</td><td width='18%' align='left' valign='middle'>&nbsp;" + order.ReceiveDate.ToShortDateString() + "</td>");
            sb.Append("<td width='9%' align='right' valign='middle'>客户编号:</td><td width='19%' align='left' valign='middle'>&nbsp;" + order.Client.Id + "</td></tr>");
            sb.Append("<tr>");
            sb.Append("<td align='right' valign='middle'>客户名称:</td><td align='left' valign='middle'>&nbsp;" + order.Client.RealName + "</td>");
            sb.Append("<td align='right' valign='middle'>联系人:</td><td align='left' valign='middle'>&nbsp;" + order.Client.RealName + "</td>");
            sb.Append("<td align='right' valign='middle'>联系电话:</td><td align='left' valign='middle'>&nbsp;" + order.Client.Phone + "</td></tr>");
            sb.Append("<tr>");
            sb.Append("<td align='right' valign='middle'>联系地址:</td><td align='left' valign='middle'>&nbsp;" + order.Client.Address + "</td>");
            sb.Append("<td align='right' valign='middle'>应付总计:</td><td colspan='3' align='left' valign='middle'>&nbsp;" + order.Costs + " 元</td></tr>");
            sb.Append("<tr>");
            sb.Append("<td width='9%' align='right' valign='middle'>备注:</td><td colspan='5' align='left' valign='middle'>&nbsp;"+order.Remark+"</td></tr>");
            sb.Append("<tr><td colspan='6' height='8'></td></tr>");

            sb.Append("<tr><td colspan='6' valign='top'>");
            sb.Append("<table border='1' cellspacing='0' cellpadding='0' width='100%' style='border-top:0px; border-bottom:0px; border-left:0px; border-right:0px; line-height:18px;font-size:12px;'>");
            sb.Append("<tr>");
            sb.Append("<td width='4%' align='center' valign='middle'>序号</td><td width='8%' align='right' valign='middle'>承运商</td>");
            sb.Append("<td width='7%' align='right' valign='middle'>邮件数量</td><td width='8%' align='right' valign='middle'>重量(KG)</td>");
            sb.Append("<td width='7%' align='right' valign='middle'>运费(￥)</td><td width='8%' align='right' valign='middle'>挂号费(￥)</td>");
            sb.Append("<td width='7%' align='right' valign='middle'>偏远费(￥)</td><td width='7%' align='right' valign='middle'>处理费(￥)</td>");
            sb.Append("<td width='7%' align='right' valign='middle'>取件费(￥)</td><td width='7%' align='right' valign='middle'>材料费(￥)</td>");
            sb.Append("<td width='7%' align='right' valign='middle'>保价费(￥)</td><td width='7%' align='right' valign='middle'>其他费(￥)</td>");
            sb.Append("<td width='7%' align='right' valign='middle'>燃油费(￥)</td>");
            sb.Append("<td width='10%' align='right' valign='middle'>应付费用(￥)</td></tr>");
            foreach (OrderDetail od in result)
            {
                int i=1;
                sb.Append("<tr>");
                sb.Append("<td align='center' valign='middle'>"+i.ToString()+"</td><td align='right' valign='middle'>"+od.CarrierEncode+"</td>");
                sb.Append("<td align='right' valign='middle'>"+od.Count.ToString()+"</td><td align='right' valign='middle'>"+od.Weight.ToString()+"</td>");
                sb.Append("<td align='right' valign='middle'>"+od.PostCosts.ToString()+"</td><td align='right' valign='middle'>"+od.RegisterCosts.ToString()+"</td>");
                sb.Append("<td align='right' valign='middle'>"+od.RemoteCosts.ToString()+"</td><td align='right' valign='middle'>"+od.DisposalCosts.ToString()+"</td>");
                sb.Append("<td align='right' valign='middle'>"+od.FetchCosts.ToString()+"</td><td align='right' valign='middle'>"+od.MaterialCosts.ToString()+"</td>");
                sb.Append("<td align='right' valign='middle'>"+od.InsureCosts.ToString()+"</td><td align='right' valign='middle'>"+od.OtherCosts.ToString()+"</td>");
                sb.Append("<td align='right' valign='middle'>" + od.FuelCosts.ToString() + "</td>");
                sb.Append("<td align='right' valign='middle'>"+od.TotalCosts.ToString()+"</td></tr>");                
                i++;
            }
            sb.Append("</table></td></tr>");
            sb.Append("<tr><td colspan='6' height='10'></td></tr>");
            sb.Append("<tr>");
            sb.Append("<td colspan='6' align='left' style='line-height:20px;'>");
            sb.Append("&nbsp;您的货物已经达到我们的处理中心，经过几小时的处理以后即将交寄.<br />");
            sb.Append("&nbsp;请仔细核对货运单的内容,有问题请与您的业务人员联系.<br />");
            sb.Append("&nbsp;货物的跟踪条码可在我们网站(<a href='http://www.eadu.com.cn' target='_blank'>http://www.eadu.com.cn</a>)上查询. <br />");
            sb.Append("&nbsp;您的账户余额: <span style='color:#0000FF;'>" + client.Balance.ToString() + "</span> 元 </td></tr></table>");

            return SendMail(company, client, "货运单", sb.ToString(), out msg);

        }
    }
}
