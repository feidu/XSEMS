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

public partial class Admin_Statistic_CommisionReport : System.Web.UI.Page
{
    DateTime minTime = new DateTime(1999, 1, 1);
    protected void Page_Load(object sender, EventArgs e)
    {     
        txtStartDate.Value = DateTime.Now.ToShortDateString();
        txtEndDate.Value = DateTime.Now.ToShortDateString();
    }
    

    protected void btnCompanyStatistic_Click(object sender, EventArgs e)
    {
        //string sDate = Request.Form[txtStartDate.ID].Trim();
        //string eDate = Request.Form[txtEndDate.ID].Trim();

        //DateTime startDate = new DateTime();
        //if (string.IsNullOrEmpty(sDate))
        //{
        //    startDate = minTime;
        //}
        //else
        //{
        //    startDate = DateTime.Parse(sDate);
        //}

        //DateTime endDate = new DateTime();
        //if (string.IsNullOrEmpty(eDate))
        //{
        //    endDate = minTime;
        //}
        //else
        //{
        //    endDate = DateTime.Parse(eDate);
        //    endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59);
        //}

        //string strCompanyId = ddlCompany.SelectedItem.Value;
        //string strCompanyName = ddlCompany.SelectedItem.Text;

        //int companyId = 0;
        //if (!int.TryParse(strCompanyId, out companyId))
        //{
        //    companyId = 0;
        //}

        //string strUserId = "0";
        //if (ddlCompany.SelectedItem.Value != "0")
        //{
        //    strUserId = ddlCompanyUsers.SelectedItem.Value;
        //}

        //int userId = 0;
        //if (!int.TryParse(strUserId, out userId))
        //{
        //    userId = 0;
        //}

        //List<CompanySales> result = StatisticOperation.GetCompanySalesStatistic(startDate, endDate, companyId, userId);

        //string fileName = StringHelper.GetEncodeNumber("TC");
        //string titleContent = "";
        //if (ddlCompany.SelectedItem.Value != "0")
        //{
        //    titleContent = "所属公司：" + strCompanyName + "      ";
        //}
        //if (startDate > minTime)
        //{
        //    titleContent += "开始日期：" + startDate.ToShortDateString() + "      ";
        //}

        //if (endDate > minTime)
        //{
        //    titleContent += "结束日期：" + endDate.ToShortDateString() + "      ";
        //}

       
        //    Response.Clear();
        //    Response.Buffer = true;
        //    Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName + ".xls");
        //    Response.ContentEncoding = System.Text.Encoding.UTF8;
        //    Response.ContentType = "application/vnd.ms-excel";

        //    Response.Write("<table border='1'>");
        //    Response.Write("<tr style='font-size:16px;font-weight:bold;height:35px;'><td align='center' valign='middle' colspan='5'>公司提成报表</td></tr>");
        //    Response.Write("<tr style='font-weight:bold;'><td align='left' colspan='5'>&nbsp;" + titleContent + "</td></tr>");
        //    Response.Write("<tr style='font-weight:bold;'><td align='left'>&nbsp;公司名称</td><td align='right'>&nbsp;销售额</td><td align='right'>&nbsp;利润</td><td align='right'>&nbsp;提成</td><td align='right'>&nbsp;提成金额</td></tr>");

        //    foreach (CompanySales cs in result)
        //    {
        //        Response.Write("<tr>");
        //        Response.Write("<td align='left'>&nbsp;" + cs.Company.Name + "</td>");
        //        Response.Write("<td align='right'>" + cs.Money.ToString() + "</td>");
        //        Response.Write("<td align='right'>" + cs.Profit.ToString() + "</td>");
        //        Response.Write("<td align='right'>" + StringHelper.CurtNumber(cs.Company.Commission.ToString()) + "</td>");
        //        Response.Write("<td align='right'>" + StringHelper.CurtNumber((cs.Profit * cs.Company.Commission).ToString()) + "</td>");
        //        Response.Write("</tr>");
        //    }
        //    Response.Write("</table>");
        //    Response.Flush();
        //    Response.End();
    }

    protected void btnUserStatistic_Click(object sender, EventArgs e)
    {
        //string sDate = Request.Form[txtStartDate.ID].Trim();
        //string eDate = Request.Form[txtEndDate.ID].Trim();

        //DateTime startDate = new DateTime();
        //if (string.IsNullOrEmpty(sDate))
        //{
        //    startDate = minTime;
        //}
        //else
        //{
        //    startDate = DateTime.Parse(sDate);
        //}

        //DateTime endDate = new DateTime();
        //if (string.IsNullOrEmpty(eDate))
        //{
        //    endDate = minTime;
        //}
        //else
        //{
        //    endDate = DateTime.Parse(eDate);
        //    endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59);
        //}

        //string strCompanyId = ddlCompany.SelectedItem.Value;
        //string strCompanyName = ddlCompany.SelectedItem.Text;

        //int companyId = 0;
        //if (!int.TryParse(strCompanyId, out companyId))
        //{
        //    companyId = 0;
        //}

        //string strUserId = "0";
        //if (ddlCompany.SelectedItem.Value != "0")
        //{
        //    strUserId = ddlCompanyUsers.SelectedItem.Value;
        //}

        //int userId = 0;
        //if (!int.TryParse(strUserId, out userId))
        //{
        //    userId = 0;
        //}

        //List<UserSales> result = StatisticOperation.GetUserSalesStatistic(startDate, endDate, companyId, userId);

        //string fileName = StringHelper.GetEncodeNumber("TC");
        //string titleContent = "";
        //if (ddlCompany.SelectedItem.Value != "0")
        //{
        //    titleContent = "所属公司：" + strCompanyName + "      ";
        //}
        //if (startDate > minTime)
        //{
        //    titleContent += "开始日期：" + startDate.ToShortDateString() + "      ";
        //}
        //if (endDate > minTime)
        //{
        //    titleContent += "结束日期：" + endDate.ToShortDateString() + "      ";
        //}

  
        //    Response.Clear();
        //    Response.Buffer = true;
        //    Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName + ".xls");
        //    Response.ContentEncoding = System.Text.Encoding.UTF8;
        //    Response.ContentType = "application/vnd.ms-excel";

        //    Response.Write("<table border='1'>");
        //    Response.Write("<tr style='font-size:16px;font-weight:bold;height:35px;'><td align='center' valign='middle' colspan='5'>业务员提成报表</td></tr>");
        //    Response.Write("<tr style='font-weight:bold;'><td align='left' colspan='5'>&nbsp;" + titleContent + "</td></tr>");
        //    Response.Write("<tr style='font-weight:bold;'><td align='left'>&nbsp;业务员</td><td align='right'>&nbsp;销售额</td><td align='right'>&nbsp;利润</td><td align='right'>&nbsp;提成</td><td align='right'>&nbsp;提成金额</td></tr>");

        //    foreach (UserSales us in result)
        //    {
        //        Response.Write("<tr>");
        //        Response.Write("<td align='left'>&nbsp;" + us.User.RealName + "</td>");
        //        Response.Write("<td align='right'>" + us.Money.ToString() + "</td>");
        //        Response.Write("<td align='right'>" + us.Profit.ToString() + "</td>");
        //        Response.Write("<td align='right'>" + StringHelper.CurtNumber(us.User.Commission.ToString()) + "</td>");
        //        Response.Write("<td align='right'>" + StringHelper.CurtNumber((us.Profit * us.User.Commission).ToString()) + "</td>");
        //        Response.Write("</tr>");
        //    }
        //    Response.Write("</table>");
        //    Response.Flush();
        //    Response.End();
        
    }
}
