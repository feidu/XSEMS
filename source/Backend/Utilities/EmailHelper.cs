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
            sb.Append("<tr><td align='left' valign='top'>�𾴵�" + client.RealName + "��<br/>");
            sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;���ã�<br/>");
            sb.Append("</td></tr>");
            sb.Append("<tr><td align='left' valign='top'>");
            sb.Append(content);
            sb.Append("</td></tr>");
            sb.Append("<tr><td align='left' valign='top'>");
            sb.Append("<br/><br/><br/>");
            sb.Append("˳ף������<br/>");
            sb.Append("�ڶ�����<br/>");
            sb.Append(DateTime.Now.ToShortDateString() + "<br/><br/>");
            sb.Append("���ʼ�Ϊϵͳ�ʼ�������ֱ�ӻظ���<br/>");
            sb.Append("���������뷢�ʼ����ͷ����䣺"+setting.Email+" �����磺"+company.Phone+"");
            sb.Append("</td></tr>");
            sb.Append("</table>");

            MailMessage objMailMessage = new MailMessage();
            objMailMessage.From = mailFrom;
            objMailMessage.To = mailTo;
            objMailMessage.Subject = title;
            objMailMessage.Body = sb.ToString();
            objMailMessage.BodyFormat = MailFormat.Html;
            objMailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
            //�û��� 
            objMailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", mailAccount);
            //���� 
            objMailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", mailPwd);
            SmtpMail.SmtpServer = smtp;

            if (client.IsMessage)
            {
                try
                {
                    SmtpMail.Send(objMailMessage);
                    msg = "�����ɹ����ʼ��ѳɹ����ͣ�";
                    return true;
                }
                catch (Exception ex)
                {
                    msg = "�����ɹ�������˾��ͻ����������ʼ�����ʧ�ܣ�";
                    return false;
                }
            }
            else
            {
                msg = "�����ɹ���";
                return false;
            }
        }

        public static bool SendMailForArrearage(Company company, Client client, decimal money, out string msg)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�����η���Ƿ��" + money.ToString() + " Ԫ������ǰ���˻����ΪRMB " + client.Balance.ToString() + " Ԫ���뼰ʱ��ֵ������Ӱ�����´η��������ö�ȵ����ӣ�");
            return SendMail(company, client, "Ƿ��֪ͨ", sb.ToString(), out msg);
        }

        public static bool SendMailForReceiveMoney(Company company, Client client, decimal money, out string msg)
        {
            StringBuilder sb = new StringBuilder();                       
            sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��˾���յ������θ���RMB "+money.ToString()+" Ԫ������ǰ���˻����ΪRMB "+client.Balance.ToString()+" Ԫ����˶ԣ���������������ҵ����Ա��ϵ��");
            return SendMail(company, client, "�տ�֪ͨ", sb.ToString(), out msg); 
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
            sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�������� "+startDate.ToShortDateString()+" �� "+endDate.ToShortDateString()+" �Ķ��˵���<br/><br/>");
            sb.Append("<table border='1' cellspacing='0' cellpadding='0' width='100%' style='line-height:18px;font-size:12px;'>");
            sb.Append("<tr style='font-weight:bold;'>");
            sb.Append("<td align='left' valign='middle'>&nbsp;����</td>");
            sb.Append("<td align='left' valign='middle'>&nbsp;������</td><td align='left' valign='middle'>&nbsp;��������</td>");
            sb.Append("<td align='left' valign='middle'>&nbsp;����</td><td align='right' valign='middle'>����(KG)</td>");
            sb.Append("<td align='right' valign='middle'>����</td><td align='right' valign='middle'>����(��)</td>");
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
            sb.Append("<tr style='font-weight:bold;'><td align='left'>&nbsp;�ϼƣ�</td><td colspan='5'>&nbsp;</td><td align='right'>&nbsp;" + totalMoney.ToString() + "</td></tr>");
            sb.Append("</table>");
            return SendMail(company, client, "���˵�", sb.ToString(), out msg);
        }

        public static bool SendMailForService(Company company, Client client, WrongOrderDetail wod, out string msg)
        {
            StringBuilder sb = new StringBuilder();
            WrongOrder wrongOrder = WrongOrderOperation.GetWrongOrderById(wod.WrongOrderId);
            sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;���ķ�����Ϣ�и��£�<br/>");
            sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�����룺"+wrongOrder.BarCode+"<br/>");
            sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�������ݣ�"+wrongOrder.Reason+"<br/>");
            sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;����ʽ�����̣�"+wod.Detail+"<br/>");
            sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��������"+wod.Result+"<br/>");
            sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�����ˣ�"+UserOperation.GetUserById(wod.CreateUserId).RealName+"<br/>");

            return SendMail(company, client, "�ͻ������и���", sb.ToString(), out msg);
        }

        public static bool SendMailForConsign(Company company, Client client, Order order, out string msg)
        {
            StringBuilder sb = new StringBuilder();
            List<OrderDetail> result = OrderDetailOperation.GetOrderDetailByOrderId(order.Id);
            
            sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�����������εĻ��˵���<br/><br/>");
            sb.Append("<table border='1' cellspacing='0' cellpadding='0' width='100%' style='font-size:12px;'>");
            sb.Append("<tr>");
            sb.Append("<td width='9%' align='right' valign='middle'>�ռ�����:</td><td width='36%' align='left' valign='middle'>&nbsp;" + order.Encode + "</td>");
            sb.Append("<td width='9%' align='right' valign='middle'>�ռ�����:</td><td width='18%' align='left' valign='middle'>&nbsp;" + order.ReceiveDate.ToShortDateString() + "</td>");
            sb.Append("<td width='9%' align='right' valign='middle'>�ͻ����:</td><td width='19%' align='left' valign='middle'>&nbsp;" + order.Client.Id + "</td></tr>");
            sb.Append("<tr>");
            sb.Append("<td align='right' valign='middle'>�ͻ�����:</td><td align='left' valign='middle'>&nbsp;" + order.Client.RealName + "</td>");
            sb.Append("<td align='right' valign='middle'>��ϵ��:</td><td align='left' valign='middle'>&nbsp;" + order.Client.RealName + "</td>");
            sb.Append("<td align='right' valign='middle'>��ϵ�绰:</td><td align='left' valign='middle'>&nbsp;" + order.Client.Phone + "</td></tr>");
            sb.Append("<tr>");
            sb.Append("<td align='right' valign='middle'>��ϵ��ַ:</td><td align='left' valign='middle'>&nbsp;" + order.Client.Address + "</td>");
            sb.Append("<td align='right' valign='middle'>Ӧ���ܼ�:</td><td colspan='3' align='left' valign='middle'>&nbsp;" + order.Costs + " Ԫ</td></tr>");
            sb.Append("<tr>");
            sb.Append("<td width='9%' align='right' valign='middle'>��ע:</td><td colspan='5' align='left' valign='middle'>&nbsp;"+order.Remark+"</td></tr>");
            sb.Append("<tr><td colspan='6' height='8'></td></tr>");

            sb.Append("<tr><td colspan='6' valign='top'>");
            sb.Append("<table border='1' cellspacing='0' cellpadding='0' width='100%' style='border-top:0px; border-bottom:0px; border-left:0px; border-right:0px; line-height:18px;font-size:12px;'>");
            sb.Append("<tr>");
            sb.Append("<td width='4%' align='center' valign='middle'>���</td><td width='8%' align='right' valign='middle'>������</td>");
            sb.Append("<td width='7%' align='right' valign='middle'>�ʼ�����</td><td width='8%' align='right' valign='middle'>����(KG)</td>");
            sb.Append("<td width='7%' align='right' valign='middle'>�˷�(��)</td><td width='8%' align='right' valign='middle'>�Һŷ�(��)</td>");
            sb.Append("<td width='7%' align='right' valign='middle'>ƫԶ��(��)</td><td width='7%' align='right' valign='middle'>�����(��)</td>");
            sb.Append("<td width='7%' align='right' valign='middle'>ȡ����(��)</td><td width='7%' align='right' valign='middle'>���Ϸ�(��)</td>");
            sb.Append("<td width='7%' align='right' valign='middle'>���۷�(��)</td><td width='7%' align='right' valign='middle'>������(��)</td>");
            sb.Append("<td width='7%' align='right' valign='middle'>ȼ�ͷ�(��)</td>");
            sb.Append("<td width='10%' align='right' valign='middle'>Ӧ������(��)</td></tr>");
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
            sb.Append("&nbsp;���Ļ����Ѿ��ﵽ���ǵĴ������ģ�������Сʱ�Ĵ����Ժ󼴽�����.<br />");
            sb.Append("&nbsp;����ϸ�˶Ի��˵�������,��������������ҵ����Ա��ϵ.<br />");
            sb.Append("&nbsp;����ĸ����������������վ(<a href='http://www.eadu.com.cn' target='_blank'>http://www.eadu.com.cn</a>)�ϲ�ѯ. <br />");
            sb.Append("&nbsp;�����˻����: <span style='color:#0000FF;'>" + client.Balance.ToString() + "</span> Ԫ </td></tr></table>");

            return SendMail(company, client, "���˵�", sb.ToString(), out msg);

        }
    }
}
