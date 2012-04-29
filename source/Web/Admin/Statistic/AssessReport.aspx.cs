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

public partial class Admin_Statistic_AssessReport : System.Web.UI.Page
{
    protected string companyId = "0";
    DateTime minTime = new DateTime(1999, 1, 1);
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    DdlCompanyDataBind();
        //    DdlCarrierDataBind();
        //    DdlCompanyUsersDataBind();
        //}
        //companyId = ddlCompany.SelectedItem.Value;
        //txtStartDate.Value = DateTime.Now.ToShortDateString();
        //txtEndDate.Value = DateTime.Now.ToShortDateString();
    }

    private void DdlCompanyDataBind()
    {
        //List<Company> companyResult = CompanyOperation.GetCompany();
        //foreach (Company company in companyResult)
        //{
        //    ddlCompany.Items.Add(new System.Web.UI.WebControls.ListItem(company.Name, company.Id.ToString()));
        //}
        //ddlCompany.Items.Add(new System.Web.UI.WebControls.ListItem("", "0"));
        //ddlCompany.SelectedValue = "0";
    }

    private void DdlCarrierDataBind()
    {
        //List<Carrier> result = CarrierOperation.GetCarrier();
        //ddlCarrier.DataSource = result;
        //ddlCarrier.DataTextField = "Name";
        //ddlCarrier.DataValueField = "Encode";
        //ddlCarrier.DataBind();

        //ddlCarrier.Items.Add(new System.Web.UI.WebControls.ListItem("", ""));
        //ddlCarrier.SelectedValue = "";
    }

    private void DdlCompanyUsersDataBind()
    {
        //ddlCompanyUsers.DataSource = UserOperation.GetLightUser();
        //ddlCompanyUsers.DataTextField = "RealName";
        //ddlCompanyUsers.DataValueField = "Id";
        //ddlCompanyUsers.DataBind();
        //ddlCompanyUsers.Items.Add(new System.Web.UI.WebControls.ListItem("", "0"));
        //ddlCompanyUsers.SelectedValue = "0";
    }

    protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        //companyId = ddlCompany.SelectedItem.Value;
        //if (int.Parse(companyId) != 0)
        //{
        //    ddlCompanyUsers.DataSource = UserOperation.GetLightUserByCompanyId(int.Parse(companyId));
        //    ddlCompanyUsers.DataTextField = "RealName";
        //    ddlCompanyUsers.DataValueField = "Id";
        //    ddlCompanyUsers.DataBind();
        //    ddlCompanyUsers.Items.Add(new System.Web.UI.WebControls.ListItem("", "0"));
        //    ddlCompanyUsers.SelectedValue = "0";
        //}
        //else
        //{
        //    DdlCompanyUsersDataBind();
        //}
        //txtClientName.Value = "";
    }
    protected void btnUserReport_Click(object sender, EventArgs e)
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

        //string carrierEncode = ddlCarrier.SelectedItem.Value;
        //string strCompanyId = ddlCompany.SelectedItem.Value;
        //string strCompanyName = ddlCompany.SelectedItem.Text;
        //string strCarrierEncode = ddlCarrier.SelectedItem.Value;

        //string strUserId = "0";
        //if (ddlCompany.SelectedItem.Value != "0")
        //{
        //    strUserId = ddlCompanyUsers.SelectedItem.Value;
        //}

        //int clientId = 0;
        //string clientName = Request.Form[txtClientName.ID].Trim();
        //if (!string.IsNullOrEmpty(clientName))
        //{
        //    Client client = ClientOperation.GetClientByRealName(clientName);
        //    if (client != null)
        //    {
        //        clientId = client.Id;
        //    }
        //    else
        //    {
        //        clientId = 0;
        //    }
        //}
        //else
        //{
        //    clientId = -1;
        //}

        //int companyId = 0;
        //if (!int.TryParse(strCompanyId, out companyId))
        //{
        //    companyId = 0;
        //}

        //int userId = 0;
        //if (!int.TryParse(strUserId, out userId))
        //{
        //    userId = 0;
        //}

        //List<UserSales> result = StatisticOperation.GetUserAssessStatistic(startDate, endDate, companyId, clientId, carrierEncode, userId);


        //string fileName = StringHelper.GetEncodeNumber("KH");
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
        //    Response.Write("<tr style='font-size:16px;font-weight:bold;height:35px;'><td align='center' valign='middle' colspan='4'>业务员考核表</td></tr>");
        //    Response.Write("<tr style='font-weight:bold;'><td align='left' colspan='4'>&nbsp;" + titleContent + "</td></tr>");
        //    Response.Write("<tr style='font-weight:bold;'><td align='left'>&nbsp;所属公司</td><td align='left'>&nbsp;所属部门</td><td align='left'>&nbsp;业务员</td><td align='right'>&nbsp;金额</td></tr>");

        //    decimal totalMoney = 0;
        //    foreach (UserSales us in result)
        //    {
        //        Response.Write("<tr>");
        //        Response.Write("<td align='left'>&nbsp;" + CompanyOperation.GetCompanyById(us.User.CompanyId).Name + "</td>");
        //        Response.Write("<td align='left'>&nbsp;" + DepartmentOperation.GetDepartmentById(us.User.DepartmentId).Name + "</td>");
        //        Response.Write("<td align='left'>&nbsp;" + us.User.RealName + "</td>");
        //        Response.Write("<td align='right'>" + us.Money.ToString() + "</td>");
        //        Response.Write("</tr>");

        //        totalMoney += us.Money;
        //    }

        //    Response.Write("<tr style='font-weight:bold;'><td align='left'>&nbsp;合计：</td><td colspan='2'>&nbsp;</td><td align='right'>&nbsp;" + totalMoney.ToString() + "</td></tr>");
        //    Response.Write("</table>");
        //    Response.Flush();
        //    Response.End();
    }
        
    protected void btnProfitReport_Click(object sender, EventArgs e)
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

        //string carrierEncode = ddlCarrier.SelectedItem.Value;
        //string strCompanyId = ddlCompany.SelectedItem.Value;
        //string strCompanyName = ddlCompany.SelectedItem.Text;
        //string strCarrierEncode = ddlCarrier.SelectedItem.Value;
        //string strUserId = "0";
        //if (ddlCompany.SelectedItem.Value != "0")
        //{
        //    strUserId = ddlCompanyUsers.SelectedItem.Value;
        //}

        //int clientId = 0;
        //string clientName = Request.Form[txtClientName.ID].Trim();
        //if (!string.IsNullOrEmpty(clientName))
        //{
        //    Client client = ClientOperation.GetClientByRealName(clientName);
        //    if (client != null)
        //    {
        //        clientId = client.Id;
        //    }
        //    else
        //    {
        //        clientId = 0;
        //    }
        //}
        //else
        //{
        //    clientId = -1;
        //}

        //int companyId = 0;
        //if (!int.TryParse(strCompanyId, out companyId))
        //{
        //    companyId = 0;
        //}

        //int userId = 0;
        //if (!int.TryParse(strUserId, out userId))
        //{
        //    userId = 0;
        //}

        //List<SearchOrderDetail> result = OrderOperation.GetReceiveOrderDetailStatistic(startDate, endDate, companyId, clientId, carrierEncode, userId);

        //string fileName = StringHelper.GetEncodeNumber("LR");
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
        //    Response.Write("<tr style='font-size:16px;font-weight:bold;height:35px;'><td align='center' valign='middle' colspan='12'>利润分析表</td></tr>");
        //    Response.Write("<tr style='font-weight:bold;'><td align='left' colspan='12'>&nbsp;"+titleContent+"</td></tr>");
        //    Response.Write("<tr style='font-weight:bold;'><td align='left'>&nbsp;收件单号</td><td align='left'>&nbsp;收件日期</td><td align='left'>&nbsp;客户姓名</td><td align='left'>&nbsp;业务员</td><td align='left'>&nbsp;承运商</td><td align='left'>&nbsp;单号</td><td align='left'>&nbsp;国家</td><td align='right'>&nbsp;重量</td><td align='right'>&nbsp;数量</td><td align='right'>&nbsp;收入</td><td align='right'>&nbsp;成本</td><td align='right'>&nbsp;利润金额</td></tr>");

        //    int totalCount = 0;
        //    decimal totalIncome = 0;
        //    decimal totalCost = 0;
        //    decimal totalProfit = 0;
        //    foreach (SearchOrderDetail sod in result)
        //    {
        //        Response.Write("<tr>");
        //        Response.Write("<td align='left'>&nbsp;" + sod.OrderEncode + "</td>");
        //        Response.Write("<td align='left'>&nbsp;" + OrderOperation.GetOrderByEncode(sod.OrderEncode).ReceiveDate.ToShortDateString() + "</td>");
        //        Response.Write("<td align='left'>&nbsp;" + sod.Client.RealName + "</td>");
        //        Response.Write("<td align='left'>&nbsp;" + UserOperation.GetUserById(OrderOperation.GetOrderByEncode(sod.OrderEncode).UserId).RealName + "</td>");
        //        Response.Write("<td align='left'>&nbsp;" + sod.CarrierEncode + "</td>");
        //        Response.Write("<td align='left'>" + sod.BarCode + "</td>");
        //        Response.Write("<td align='left'>" + sod.ToCountry + "</td>");
        //        Response.Write("<td align='right'>" + sod.Weight.ToString() + "</td>");
        //        Response.Write("<td align='right'>" + sod.Count.ToString() + "</td>");
        //        Response.Write("<td align='right'>" + sod.TotalCosts.ToString() + "</td>");
        //        Response.Write("<td align='right'>" + sod.SelfTotalCosts.ToString() + "</td>");
        //        Response.Write("<td align='right'>" + (sod.TotalCosts - sod.SelfTotalCosts).ToString() + "</td>");
        //        Response.Write("</tr>");

        //        totalCount += sod.Count;
        //        totalIncome += sod.TotalCosts;
        //        totalCost += sod.SelfTotalCosts;
        //        totalProfit += (sod.TotalCosts - sod.SelfTotalCosts);
        //    }

        //    Response.Write("<tr style='font-weight:bold;'><td align='left'>&nbsp;合计：</td><td colspan='7'>&nbsp;</td><td align='right'>" + totalCount.ToString() + "</td><td align='right'>" + totalIncome.ToString() + "</td><td align='right'>" + totalCost.ToString() + "</td><td align='right'>" + totalProfit.ToString() + "</td></tr>");
        //    Response.Write("</table>");
        //    Response.Flush();
        //    Response.End();
        
    }
}
