using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.Models;
using Backend.BAL;

public partial class Config_NotOnlineOrder : System.Web.UI.Page
{
    List<SearchOrderDetail> result = new List<SearchOrderDetail>();
    protected void Page_Load(object sender, EventArgs e)
    {
        List<SearchOrderDetail> resultSz = OrderOperation.GetNotOnlineOrderDetail(DateTime.Now, 3, 0, 70, "");
        List<SearchOrderDetail> resultMy = OrderOperation.GetNotOnlineOrderDetail(DateTime.Now, 3, 0, 138, "");

        foreach (SearchOrderDetail sod in resultSz)
        {
            result.Add(sod);
        }
        foreach (SearchOrderDetail sod in resultMy)
        {
            result.Add(sod);
        }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + DateTime.Now.ToString() + ".xls");
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.ContentType = "application/vnd.ms-excel";

        Response.Write("<table border='1'>");
        Response.Write("<tr style='font-size:16px;font-weight:bold;height:35px;'><td align='center' valign='middle' colspan='11'>未上线订单明细表</td></tr>");
        Response.Write("<tr style='font-weight:bold;'><td align='left'>&nbsp;收件单号</td><td align='left'>&nbsp;发货日期</td><td align='left'>&nbsp;客户姓名</td><td align='left'>&nbsp;跟踪条码</td><td align='left'>&nbsp;收件人</td><td align='left'>&nbsp;国家</td><td align='left'>&nbsp;承运商</td><td align='right'>&nbsp;重量</td><td align='right'>&nbsp;数量</td><td align='right'>&nbsp;金额</td><td align='left'>&nbsp;备注</td></tr>");

        int totalCount = 0;
        foreach (SearchOrderDetail sod in result)
        {
            Response.Write("<tr>");
            Response.Write("<td align='left'>&nbsp;" + sod.OrderEncode + "</td>");
            Response.Write("<td align='left'>&nbsp;" + OrderOperation.GetOrderByEncode(sod.OrderEncode).AuditTime.ToShortDateString() + "</td>");
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

            totalCount += sod.Count;
        }

        Response.Write("<tr style='font-weight:bold;'><td align='left'>&nbsp;合计：</td><td colspan='6'>&nbsp;</td><td align='right'></td><td align='right'>" + totalCount.ToString() + "</td><td align='right'></td><td align='left'>&nbsp;</td></tr>");
        Response.Write("</table>");
        Response.Flush();
        Response.End();
    }
}