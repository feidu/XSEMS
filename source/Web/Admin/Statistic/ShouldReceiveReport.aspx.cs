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

public partial class Admin_Statistic_ShouldReceiveReport : System.Web.UI.Page
{
    protected string companyId = "0";
    DateTime minTime = new DateTime(1999, 1, 1);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtStartDate.Value = DateTime.Now.AddMonths(-1).ToShortDateString();
            txtEndDate.Value = DateTime.Now.ToShortDateString();
        }
        
    }

    protected void btnSrStatistic_Click(object sender, EventArgs e)
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
        
        List<ShouldReceive> result = StatisticOperation.GetShouldReceiveStatistic(startDate, endDate, clientId);
        
        string fileName = StringHelper.GetEncodeNumber("YS");
        string titleContent = "";        
        if (startDate > minTime)
        {
            titleContent += "开始日期：" + startDate.ToShortDateString() + "    ";
        }
        if (endDate > minTime)
        {
            titleContent += "结束日期：" + endDate.ToShortDateString() + "    ";
        }

        
            Response.Clear();
            Response.Buffer = true;
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName + ".xls");
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.ContentType = "application/vnd.ms-excel";

            Response.Write("<table border='1'>");
            Response.Write("<tr style='font-size:16px;font-weight:bold;height:35px;'><td align='center' valign='middle' colspan='4'>应收款汇总</td></tr>");
            Response.Write("<tr style='font-weight:bold;'><td align='left' colspan='4'>&nbsp;" + titleContent + "</td></tr>");
            Response.Write("<tr style='font-weight:bold;'><td align='left'>&nbsp;客户用户名</td><td align='left'>&nbsp;客户姓名</td><td align='right'>&nbsp;应收金额</td></tr>");

            decimal totalMoney = 0;
            foreach (ShouldReceive sr in result)
            {
                Response.Write("<tr>");
                Response.Write("<td align='left'>&nbsp;" + ClientOperation.GetClientById(sr.ClientId).Username + "</td>");
                Response.Write("<td align='left'>&nbsp;" + ClientOperation.GetClientById(sr.ClientId).RealName + "</td>");
                Response.Write("<td align='right'>" + sr.Money.ToString() + "</td>");
                Response.Write("</tr>");

                totalMoney += sr.Money;
            }

            Response.Write("<tr style='font-weight:bold;'><td align='left'>&nbsp;合计：</td><td>&nbsp;</td><td align='right'>" + totalMoney.ToString() + "</td></tr>");
            Response.Write("</table>");
            Response.Flush();
            Response.End();

    }

    protected void btnBillStatistic_Click(object sender, EventArgs e)
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
                lblMsg.Text = "指定的客户不存在！";
                return;
            }
        }
        else
        {
            clientId = -1;
            lblMsg.Text = "请指定一位客户！";
            return;
        }


        List<SearchOrderDetail> result = OrderOperation.GetReceiveOrderDetailStatistic(startDate, endDate, clientId, "");

        string fileName = StringHelper.GetEncodeNumber("DZ");
        string titleContent = "";
        
        if (clientId > 0)
        {
            titleContent += "客户姓名：" + clientName + "    ";
        }
        if (startDate > minTime)
        {
            titleContent += "开始日期：" + startDate.ToShortDateString() + "    ";
        }
        if (endDate > minTime)
        {
            titleContent += "结束日期：" + endDate.ToShortDateString() + "    ";
        }

            Response.Clear();
            Response.Buffer = true;
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName + ".xls");
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.ContentType = "application/vnd.ms-excel";

            Response.Write("<table border='1'>");
            Response.Write("<tr style='font-size:16px;font-weight:bold;height:35px;'><td align='center' valign='middle' colspan='10'>客户对账单</td></tr>");
            Response.Write("<tr style='font-weight:bold;'><td align='left' colspan='10'>&nbsp;" + titleContent + "</td></tr>");
            Response.Write("<tr style='font-weight:bold;'><td align='left'>&nbsp;日期</td><td align='left'>&nbsp;承运商</td><td align='left'>&nbsp;包裹单号</td><td align='left'>&nbsp;国家</td><td align='right'>&nbsp;重量</td><td align='right'>&nbsp;数量</td><td align='right'>&nbsp;运费</td><td align='right'>&nbsp;材料费</td><td align='right'>&nbsp;保价费</td><td align='right'>&nbsp;应收费用</td></tr>");

            decimal totalMoney = 0;
            foreach (SearchOrderDetail sod in result)
            {
                Response.Write("<tr>");
                Response.Write("<td align='left'>&nbsp;" + sod.CreateTime.ToShortDateString() + "</td>");
                Response.Write("<td align='left'>&nbsp;" + CarrierOperation.GetCarrierByEncode(sod.CarrierEncode).Name + "</td>");
                Response.Write("<td align='left'>" + sod.BarCode + "</td>");
                Response.Write("<td align='left'>" + sod.ToCountry + "</td>");
                Response.Write("<td align='right'>" + sod.Weight.ToString() + "</td>");
                Response.Write("<td align='right'>" + sod.Count.ToString() + "</td>");
                Response.Write("<td align='right'>" + sod.PostCosts.ToString() + "</td>");
                Response.Write("<td align='right'>" + sod.MaterialCosts.ToString() + "</td>");
                Response.Write("<td align='right'>" + sod.InsureCosts.ToString() + "</td>");
                Response.Write("<td align='right'>" + sod.TotalCosts.ToString() + "</td>");
                Response.Write("</tr>");

                totalMoney += sod.TotalCosts;
            }
            Response.Write("<tr style='font-weight:bold;'><td align='left'>&nbsp;合计：</td><td colspan='8'>&nbsp;</td><td align='right'>" + totalMoney.ToString() + "</td></tr>");
            Response.Write("</table>");
            Response.Flush();
            Response.End();
        
    }

    protected void btnEmailBillToClient_Click(object sender, EventArgs e)
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
               

        int clientId = 0;
        string clientName = Request.Form[txtClientName.ID].Trim();
        Client client=null;
        
        if (!string.IsNullOrEmpty(clientName))
        {
            client = ClientOperation.GetClientByRealName(clientName);
            if (client != null)
            {
                clientId = client.Id;
            }
            else
            {
                clientId = 0;
                lblMsg.Text = "指定的客户不存在！";
                return;
            }
        }
        else
        {
            clientId = -1;
            lblMsg.Text = "请指定一位客户！";
            return;
        }

        List<SearchOrderDetail> result = OrderOperation.GetReceiveOrderDetailStatistic(startDate, endDate, clientId, "");
        if (result.Count > 0)
        {
            string msg = "";
            EmailHelper.SendMailForBill(startDate, endDate, client, result, out msg);
            Response.Write("<script language='javascript' type='text/javascript'>alert('" + msg + "');location.href='ShouldReceiveReport.aspx';</script>");
        }
        else
        {
            Response.Write("<script language='javascript' type='text/javascript'>alert('此客户在此段时间无发货记录！');</script>");
            return;
        }
    }
}

