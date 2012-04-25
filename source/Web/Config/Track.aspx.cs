using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.Models;
using Backend.BAL;


public partial class Config_Track : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        if(string.IsNullOrEmpty(txtStartDate.Value))
        {
            txtStartDate.Value = "请选择日期！";
            return;
        }
        DateTime startTime = DateTime.Parse(txtStartDate.Value);
        DateTime endTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 23, 59, 59, 999);
        List<SearchOrderDetail> result = OrderOperation.GetEaduOrderDetailStatistic(startTime, endTime, 1, -1, "", 0);
        Response.Clear();
        Response.Buffer = true;
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + DateTime.Now.ToString() + ".xls");
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.ContentType = "application/vnd.ms-excel";

        Response.Write("<table border='1'>");
        Response.Write("<tr style='font-size:16px;font-weight:bold;height:35px;'><td align='center' valign='middle' colspan='11'>" + startTime.ToShortDateString()+ " 订单明细表</td></tr>");
        Response.Write("<tr style='font-weight:bold;'><td align='left'>&nbsp;平台单号</td><td align='left'>&nbsp;客户姓名</td><td align='left'>&nbsp;跟踪条码</td><td align='left'>&nbsp;国家</td><td align='left'>&nbsp;承运商</td><td align='right'>&nbsp;重量</td><td align='right'>&nbsp;数量</td><td align='right'>&nbsp;金额</td><td align='left'>&nbsp;最后处理时间</td><td align='left'>&nbsp;当前物流状态</td><td align='left'>&nbsp;追踪时间</td></tr>");

        int totalCount = 0;
        DateTime minTime = new DateTime(1999, 1, 1);
        foreach (SearchOrderDetail sod in result)
        {
            Response.Write("<tr>");
            Response.Write("<td align='left'>&nbsp;" + sod.Remark + "</td>");
            Response.Write("<td align='left'>&nbsp;" + sod.Client.RealName + "</td>");
            Response.Write("<td align='left'>" + sod.BarCode.ToUpper() + "</td>");
            Response.Write("<td align='left'>" + sod.ToCountry + "</td>");
            Response.Write("<td align='left'>&nbsp;" + sod.CarrierEncode + "</td>");
            Response.Write("<td align='right'>" + sod.Weight.ToString() + "</td>");
            Response.Write("<td align='right'>" + sod.Count.ToString() + "</td>");
            Response.Write("<td align='right'>" + sod.TotalCosts.ToString() + "</td>");
            if (sod.LastDisposalTime <= minTime)
            {
                Response.Write("<td align='left'></td>");
            }
            else
            {
                Response.Write("<td align='left'>" + sod.LastDisposalTime.ToShortDateString() + "</td>");
            }
            Response.Write("<td align='left'>" + sod.PostStatus + "</td>");
            if (sod.TrackingTime <= minTime)
            {
                Response.Write("<td align='left'></td>");
            }
            else
            {
                Response.Write("<td align='left'>" + sod.TrackingTime.ToShortDateString() + "</td>");
            }
            Response.Write("</tr>");

            totalCount += sod.Count;
        }

        Response.Write("<tr style='font-weight:bold;'><td align='left'>&nbsp;合计：</td><td colspan='5'>&nbsp;</td><td align='right'></td><td align='right'>" + totalCount.ToString() + "</td><td align='right'></td><td align='left' colspan='2'>&nbsp;</td></tr>");
        Response.Write("</table>");
        Response.Flush();
        Response.End();
    }

    protected void btnExportDetail_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtStartDate.Value))
        {
            txtStartDate.Value = "请选择日期!";
            return;
        }
        DateTime startTime = DateTime.Parse(txtStartDate.Value);
        DateTime endTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 23, 59, 59, 999);
        List<SearchOrderDetail> result = OrderOperation.GetEaduOrderDetailStatistic(startTime, endTime, 1, -1, "", 0);
        Response.Clear();
        Response.Buffer = true;
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + DateTime.Now.ToString() + ".xls");
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.ContentType = "application/vnd.ms-excel";

        Response.Write("<table border='1'>");
        Response.Write("<tr style='font-size:16px;font-weight:bold;height:35px;'><td align='center' valign='middle' colspan='11'>" + startTime.ToShortDateString() + " 订单明细表</td></tr>");
        Response.Write("<tr style='font-weight:bold;'><td align='left'>&nbsp;平台单号</td><td align='left'>&nbsp;客户姓名</td><td align='left'>&nbsp;跟踪条码</td><td align='left'>&nbsp;国家</td><td align='left'>&nbsp;承运商</td><td align='right'>&nbsp;重量</td><td align='right'>&nbsp;数量</td><td align='right'>&nbsp;金额</td><td align='left'>&nbsp;最后处理时间</td><td align='left'>&nbsp;当前物流状态</td><td align='left'>&nbsp;追踪时间</td></tr>");

        int totalCount = 0;
        DateTime minTime = new DateTime(1999, 1, 1);
        foreach (SearchOrderDetail sod in result)
        {
            Response.Write("<tr>");
            Response.Write("<td align='left'>&nbsp;" + sod.Remark + "</td>");
            Response.Write("<td align='left'>&nbsp;" + sod.Client.RealName + "</td>");
            Response.Write("<td align='left'>" + sod.BarCode.ToUpper() + "</td>");
            Response.Write("<td align='left'>" + sod.ToCountry + "</td>");
            Response.Write("<td align='left'>&nbsp;" + sod.CarrierEncode + "</td>");
            Response.Write("<td align='right'>" + sod.Weight.ToString() + "</td>");
            Response.Write("<td align='right'>" + sod.Count.ToString() + "</td>");
            Response.Write("<td align='right'>" + sod.TotalCosts.ToString() + "</td>");
            if (sod.LastDisposalTime <= minTime)
            {
                Response.Write("<td align='left'></td>");
            }
            else
            {
                Response.Write("<td align='left'>" + sod.LastDisposalTime.ToShortDateString() + "</td>");
            }
            Response.Write("<td align='left'>" + sod.PostStatus + "</td>");
            if (sod.TrackingTime <= minTime)
            {
                Response.Write("<td align='left'></td>");
            }
            else
            {
                Response.Write("<td align='left'>" + sod.TrackingTime.ToShortDateString() + "</td>");
            }
            Response.Write("</tr>");

            totalCount += sod.Count;
            List<PostStatus> psList = PostStatusOperation.GetPostStatusByBarcode(sod.BarCode);
            foreach (PostStatus ps in psList)
            {
                Response.Write("<tr>");
                Response.Write("<td align='left' colspan='8'></td>");
                Response.Write("<td align='left'>" + ps.DisposalTime.ToShortDateString() + "</td>");
                Response.Write("<td align='left'>" + ps.Location + " / " + ps.Status + "</td>");
                Response.Write("<td></td>");
                Response.Write("</tr>");                
            }
        }

        Response.Write("<tr style='font-weight:bold;'><td align='left'>&nbsp;合计：</td><td colspan='5'>&nbsp;</td><td align='right'></td><td align='right'>" + totalCount.ToString() + "</td><td align='right'></td><td align='left' colspan='2'>&nbsp;</td></tr>");
        Response.Write("</table>");
        Response.Flush();
        Response.End();
    }
}