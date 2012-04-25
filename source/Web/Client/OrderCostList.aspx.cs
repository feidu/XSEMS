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
using Backend.Models.Pagination;
using Backend.BAL;
using Backend.Models;
using Backend.Authorization;
using Backend.Utilities;
using System.Collections.Generic;

public partial class Client_OrderCostList : System.Web.UI.Page
{
    ClientSession clientSession = null;
    DateTime minTime = new DateTime(1999, 1, 1);
    protected void Page_Load(object sender, EventArgs e)
    {
        clientSession = (ClientSession)AuthorizationManager.GetCurrentSessionObject(Context, false);
        if (!IsPostBack)
        {
            string sDate = Request.QueryString["sd"];
            string eDate = Request.QueryString["ed"];

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

            string barCode = Request.QueryString["b"];
            string remark=Request.QueryString["r"];

            if (string.IsNullOrEmpty(remark))
            {
                remark = "";
            }
            if (string.IsNullOrEmpty(barCode))
            {
                barCode = "";
            }

            RpOrderDataBind(clientSession.Id, startDate, endDate, barCode, remark);
            txtStartDate.Value = sDate;
            txtEndDate.Value = eDate;
            txtBarCode.Value = barCode;
            txtRemark.Value = remark;
        }
    }

    private void RpOrderDataBind(int clientId, DateTime startDate, DateTime endDate, string barCode, string remark)
    {
        PaginationQueryResult<SearchOrderDetail> result = OrderOperation.GetOrderCostsPostInfoDetailsByParameters(PaginationHelper.GetCurrentPaginationQueryCondition(Request), clientId, startDate, endDate, barCode, remark);
        rpOrder.DataSource = result.Results;
        rpOrder.DataBind();

        pagi.TotalCount = result.TotalCount;
    }

    protected void btnSerach_ServerClick(object sender, EventArgs e)
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

        string remark = Request.Form[txtRemark.ID].Trim();
        string barCode = Request.Form[txtBarCode.ID].Trim();

        Response.Redirect("OrderCostList.aspx?sd=" + sDate + "&ed=" + eDate + "&b=" + barCode + "&r=" + remark);

    }
    protected void btnExport_Click(object sender, EventArgs e)
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

        string remark = Request.Form[txtRemark.ID].Trim();
        string barCode = Request.Form[txtBarCode.ID].Trim();

        List<SearchOrderDetail> result = OrderOperation.GetOrderCostsDetailByParameters(clientSession.Id, startDate, endDate, barCode, remark);
        string fileName = StringHelper.GetEncodeNumber("MX");
        string titleContent = "";
        if (startDate > minTime)
        {
            titleContent += "开始日期：" + startDate.ToShortDateString() + "      ";
        }
        if (endDate > minTime)
        {
            titleContent += "结束日期：" + endDate.ToShortDateString();
        }
        Response.Clear();
        Response.Buffer = true;
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName + ".xls");
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.ContentType = "application/vnd.ms-excel";

        Response.Write("<table border='1'>");
        Response.Write("<tr style='font-size:16px;font-weight:bold;height:35px;'><td align='center' valign='middle' colspan='11'>发货明细表</td></tr>");
        Response.Write("<tr style='font-weight:bold;;height:24px;'><td align='left' colspan='11'>&nbsp;" + titleContent + "</td></tr>");
        
        Response.Write("<tr style='font-weight:bold;'><td align='left'>&nbsp;收件单号</td><td align='left'>&nbsp;收件日期</td><td align='left'>&nbsp;客户姓名</td><td align='left'>&nbsp;跟踪条码</td><td align='left'>&nbsp;收件人</td><td align='left'>&nbsp;国家</td><td align='left'>&nbsp;承运商</td><td align='right'>&nbsp;重量</td><td align='right'>&nbsp;数量</td><td align='right'>&nbsp;金额</td><td align='left'>&nbsp;备注</td></tr>");

        decimal totalWeight = 0;
        int totalCount = 0;
        decimal totalMoney = 0;
        foreach (SearchOrderDetail sod in result)
        {
            Response.Write("<tr>");
            Response.Write("<td align='left'>&nbsp;" + sod.OrderEncode + "</td>");
            Response.Write("<td align='left'>&nbsp;" + OrderOperation.GetOrderByEncode(sod.OrderEncode).ReceiveDate.ToShortDateString() + "</td>");
            Response.Write("<td align='left'>&nbsp;" + sod.Client.RealName + "</td>");            
            Response.Write("<td align='left'>" + sod.BarCode + "</td>");            
            Response.Write("<td align='left'>&nbsp;" + sod.ToUsername + "</td>");
            Response.Write("<td align='left'>" + sod.ToCountry + "</td>");
            Response.Write("<td align='left'>&nbsp;" + sod.CarrierEncode + "</td>");
            Response.Write("<td align='right'>" + sod.Weight.ToString() + "</td>");
            Response.Write("<td align='right'>" + sod.Count.ToString() + "</td>");
            Response.Write("<td align='right'>" + sod.TotalCosts.ToString() + "</td>");
            Response.Write("<td align='left'>" + sod.Remark + "</td>");
            Response.Write("</tr>");

            totalWeight += sod.Weight;
            totalCount += sod.Count;
            totalMoney += sod.TotalCosts;
        }

        Response.Write("<tr style='font-weight:bold;'><td align='left'>&nbsp;合计：</td><td colspan='6'>&nbsp;</td><td align='right'>" + totalWeight.ToString() + "</td><td align='right'>" + totalCount.ToString() + "</td><td align='right'>" + totalMoney.ToString() + "</td><td align='left'>&nbsp;</td></tr>");
        Response.Write("</table>");
        Response.Flush();
        Response.End();

    }
}

