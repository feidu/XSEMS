using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Backend.BAL;
using Backend.Authorization;
using Backend.Models;
using Backend.Utilities;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

public partial class Admin_Statistic_AlreadyReceivedReport : System.Web.UI.Page
{
    protected List<PaymentMethod> result = null;
    protected string companyId = "0";
    DateTime minTime = new DateTime(1999, 1, 1);
    protected void Page_Load(object sender, EventArgs e)
    {       
        txtStartDate.Value = DateTime.Now.ToShortDateString();
        txtEndDate.Value = DateTime.Now.ToShortDateString();

        result = PaymentMethodOperation.GetPaymentMethod();
    }
       
    protected void btnArStatistic_Click(object sender, EventArgs e)
    {
        string sDate = Request.Form[txtStartDate.ID].Trim();
        string eDate = Request.Form[txtEndDate.ID].Trim();

        DateTime startDate = new DateTime();
        if (string.IsNullOrEmpty(sDate))
        {
            startDate = minTime;
        }
        else
        {
            startDate = DateTime.Parse(sDate);
        }

        DateTime endDate = new DateTime();
        if (string.IsNullOrEmpty(eDate))
        {
            endDate = minTime;
        }
        else
        {
            endDate = DateTime.Parse(eDate);
            endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59);
        }
               
        string pmIds = Request.Form["chkPaymentMethod"];   

        int clientId = 0;
        string clientName = Request.Form[txtClientName.ID].Trim();
        if (!string.IsNullOrEmpty(clientName))
        {
            Client client = ClientOperation.GetClientByRealName(clientName);
            if (client != null)
            {
                clientId = client.Id;
            }
            else
            {
                clientId = 0;
            }
        }
        else
        {
            clientId = -1;
        }

        int companyId = 0;
    

        List<Recharge> result = StatisticOperation.GetRechargeStatistic(startDate, endDate, clientId, pmIds);

        string fileName = StringHelper.GetEncodeNumber("SK");
        string titleContent = "";      
        if (startDate > minTime)
        {
            titleContent += "开始日期：" + startDate.ToShortDateString() + "      ";
        }

        if (endDate > minTime)
        {
            titleContent += "结束日期：" + endDate.ToShortDateString() + "      ";
        }

          
            Response.Clear();
            Response.Buffer = true;
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName + ".xls");
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.ContentType = "application/vnd.ms-excel";

            Response.Write("<table border='1'>");
            Response.Write("<tr style='font-size:16px;font-weight:bold;height:35px;'><td align='center' valign='middle' colspan='7'>已收款汇总</td></tr>");
            Response.Write("<tr style='font-weight:bold;'><td align='left' colspan='7'>&nbsp;"+titleContent+"</td></tr>");
            Response.Write("<tr style='font-weight:bold;'><td align='left'>&nbsp;所属公司</td><td align='left'>&nbsp;收款单号</td><td align='left'>&nbsp;收款日期</td><td align='left'>&nbsp;发票号码</td><td align='left'>&nbsp;付款方式</td><td align='left'>&nbsp;经手人</td><td align='right'>&nbsp;收款金额</td></tr>");

            decimal totalMoney = 0;
            foreach (Recharge recharge in result)
            {
                Response.Write("<tr>");
                Response.Write("<td align='left'>&nbsp;" + CompanyOperation.GetCompanyById(recharge.CompanyId).Name + "</td>");
                Response.Write("<td align='left'>&nbsp;" + recharge.Encode + "</td>");
                Response.Write("<td align='left'>&nbsp;" + recharge.ReceiveTime.ToShortDateString() + "</td>");
                Response.Write("<td align='left'>&nbsp;" + recharge.Invoice + "</td>");
                Response.Write("<td align='left'>&nbsp;" + recharge.PaymentMethodName + "</td>");
                Response.Write("<td align='left'>&nbsp;" + recharge.UserName + "</td>");
                Response.Write("<td align='right'>" + recharge.Money.ToString() + "</td>");
                Response.Write("</tr>");

                totalMoney += recharge.Money;
            }

            Response.Write("<tr style='font-weight:bold;'><td align='left'>&nbsp;合计：</td><td colspan='5'>&nbsp;</td><td align='right'>" + totalMoney.ToString() + "</td></tr>");
            Response.Write("</table>");
            Response.Flush();
            Response.End();
       
    }
    protected void btnArDetailStatistic_Click(object sender, EventArgs e)
    {
        string sDate = Request.Form[txtStartDate.ID].Trim();
        string eDate = Request.Form[txtEndDate.ID].Trim();

        DateTime startDate = new DateTime();
        if (string.IsNullOrEmpty(sDate))
        {
            startDate = minTime;
        }
        else
        {
            startDate = DateTime.Parse(sDate);
        }

        DateTime endDate = new DateTime();
        if (string.IsNullOrEmpty(eDate))
        {
            endDate = minTime;
        }
        else
        {
            endDate = DateTime.Parse(eDate);
            endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59);
        }
           
        string pmIds = Request.Form["chkPaymentMethod"];

        int clientId = 0;
        string clientName = Request.Form[txtClientName.ID].Trim();
        if (!string.IsNullOrEmpty(clientName))
        {
            Client client = ClientOperation.GetClientByRealName(clientName);
            if (client != null)
            {
                clientId = client.Id;
            }
            else
            {
                clientId = 0;
            }
        }
        else
        {
            clientId = -1;
        }

        int companyId = 0;
       

        List<ClientRecharge> result = StatisticOperation.GetRechargeDetailStatistic(startDate, endDate, clientId, pmIds);

        string fileName = StringHelper.GetEncodeNumber("SK");
        string titleContent = "";
      
        if (startDate > minTime)
        {
            titleContent += "开始日期：" + startDate.ToShortDateString() + "      ";
        }
        if (endDate > minTime)
        {
            titleContent += "结束日期：" + endDate.ToShortDateString() + "      ";
        }

    
            Response.Clear();
            Response.Buffer = true;
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName + ".xls");
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.ContentType = "application/vnd.ms-excel";

            Response.Write("<table border='1'>");
            Response.Write("<tr style='font-size:16px;font-weight:bold;height:35px;'><td align='center' valign='middle' colspan='7'>已收款明细</td></tr>");
            Response.Write("<tr style='font-weight:bold;'><td align='left' colspan='7'>&nbsp;" + titleContent + "</td></tr>");
            Response.Write("<tr style='font-weight:bold;'><td align='left'>&nbsp;所属公司</td><td align='left'>&nbsp;收款单号</td><td align='left'>&nbsp;收款日期</td><td align='left'>&nbsp;发票号码</td><td align='left'>&nbsp;付款方式</td><td align='left'>&nbsp;经手人</td><td align='right'>&nbsp;收款金额</td></tr>");

            foreach (ClientRecharge cr in result)
            {
                Response.Write("<tr style='font-weight:bold;'><td align='left' colspan='7'>&nbsp;客户姓名：" + cr.Client.RealName + "</td></tr>");

                decimal totalMoney = 0;
                foreach (Recharge recharge in cr.RechargeList)
                {
                    Response.Write("<tr>");
                    Response.Write("<td align='left'>&nbsp;" + CompanyOperation.GetCompanyById(recharge.CompanyId).Name + "</td>");
                    Response.Write("<td align='left'>&nbsp;" + recharge.Encode + "</td>");
                    Response.Write("<td align='left'>&nbsp;" + recharge.ReceiveTime.ToShortDateString() + "</td>");
                    Response.Write("<td align='left'>&nbsp;" + recharge.Invoice + "</td>");
                    Response.Write("<td align='left'>&nbsp;" + recharge.PaymentMethodName + "</td>");
                    Response.Write("<td align='left'>&nbsp;" + recharge.UserName + "</td>");
                    Response.Write("<td align='right'>" + recharge.Money.ToString() + "</td>");
                    Response.Write("</tr>");
                    totalMoney += recharge.Money;
                }
                Response.Write("<tr style='font-weight:bold;'><td align='left'>&nbsp;合计：</td><td colspan='5'>&nbsp;</td><td align='right'>" + totalMoney.ToString() + "</td></tr>");
            }
            Response.Write("</table>");
            Response.Flush();
            Response.End();
        
    }
}
