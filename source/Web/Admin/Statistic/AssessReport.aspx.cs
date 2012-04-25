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
        if (!IsPostBack)
        {
            DdlCompanyDataBind();
            DdlCarrierDataBind();
            DdlCompanyUsersDataBind();
        }
        companyId = ddlCompany.SelectedItem.Value;
        txtStartDate.Value = DateTime.Now.ToShortDateString();
        txtEndDate.Value = DateTime.Now.ToShortDateString();
    }

    private void DdlCompanyDataBind()
    {
        List<Company> companyResult = CompanyOperation.GetCompany();
        foreach (Company company in companyResult)
        {
            ddlCompany.Items.Add(new System.Web.UI.WebControls.ListItem(company.Name, company.Id.ToString()));
        }
        ddlCompany.Items.Add(new System.Web.UI.WebControls.ListItem("", "0"));
        ddlCompany.SelectedValue = "0";
    }

    private void DdlCarrierDataBind()
    {
        List<Carrier> result = CarrierOperation.GetCarrier();
        ddlCarrier.DataSource = result;
        ddlCarrier.DataTextField = "Name";
        ddlCarrier.DataValueField = "Encode";
        ddlCarrier.DataBind();

        ddlCarrier.Items.Add(new System.Web.UI.WebControls.ListItem("", ""));
        ddlCarrier.SelectedValue = "";
    }

    private void DdlCompanyUsersDataBind()
    {
        ddlCompanyUsers.DataSource = UserOperation.GetLightUser();
        ddlCompanyUsers.DataTextField = "RealName";
        ddlCompanyUsers.DataValueField = "Id";
        ddlCompanyUsers.DataBind();
        ddlCompanyUsers.Items.Add(new System.Web.UI.WebControls.ListItem("", "0"));
        ddlCompanyUsers.SelectedValue = "0";
    }

    protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        companyId = ddlCompany.SelectedItem.Value;
        if (int.Parse(companyId) != 0)
        {
            ddlCompanyUsers.DataSource = UserOperation.GetLightUserByCompanyId(int.Parse(companyId));
            ddlCompanyUsers.DataTextField = "RealName";
            ddlCompanyUsers.DataValueField = "Id";
            ddlCompanyUsers.DataBind();
            ddlCompanyUsers.Items.Add(new System.Web.UI.WebControls.ListItem("", "0"));
            ddlCompanyUsers.SelectedValue = "0";
        }
        else
        {
            DdlCompanyUsersDataBind();
        }
        txtClientName.Value = "";
    }
    protected void btnUserReport_Click(object sender, EventArgs e)
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

        string carrierEncode = ddlCarrier.SelectedItem.Value;
        string strCompanyId = ddlCompany.SelectedItem.Value;
        string strCompanyName = ddlCompany.SelectedItem.Text;
        string strCarrierEncode = ddlCarrier.SelectedItem.Value;

        string strUserId = "0";
        if (ddlCompany.SelectedItem.Value != "0")
        {
            strUserId = ddlCompanyUsers.SelectedItem.Value;
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

        int companyId = 0;
        if (!int.TryParse(strCompanyId, out companyId))
        {
            companyId = 0;
        }

        int userId = 0;
        if (!int.TryParse(strUserId, out userId))
        {
            userId = 0;
        }

        List<UserSales> result = StatisticOperation.GetUserAssessStatistic(startDate, endDate, companyId, clientId, carrierEncode, userId);


        string fileName = StringHelper.GetEncodeNumber("KH");
        string titleContent = "";
        if (ddlCompany.SelectedItem.Value != "0")
        {
            titleContent = "所属公司：" + strCompanyName + "      ";
        }
        if (startDate > minTime)
        {
            titleContent += "开始日期：" + startDate.ToShortDateString() + "      ";
        }

        if (endDate > minTime)
        {
            titleContent += "结束日期：" + endDate.ToShortDateString() + "      ";
        }

        if (ddlReportType.SelectedItem.Value == "1")
        {
            string filePath = Server.MapPath("../../Config/");

            string[] fileArray = Directory.GetFiles(filePath, "*.pdf");
            foreach (string file in fileArray)
            {
                File.Delete(file);
            }
            Document document = new Document(PageSize.A4, 15, 15, 10, 10);

            try
            {
                PdfWriter.getInstance(document, new FileStream(filePath + fileName + ".pdf", FileMode.Create));

                document.Header = PdfHelper.GetHeardFooter("亿度物流", SettingOperation.LoadSetting().Phone);

                document.Open();

                Paragraph phTitle = new Paragraph(new Chunk("业务员考核表", PdfHelper.fontTitle));
                phTitle.Alignment = Element.ALIGN_CENTER;

                Paragraph phTitle2 = new Paragraph(new Chunk(titleContent, PdfHelper.fontHeader));
                phTitle2.Alignment = Element.ALIGN_LEFT;

                document.Add(phTitle);
                document.Add(phTitle2);

                iTextSharp.text.Table tblContent = new iTextSharp.text.Table(4);
                tblContent.setWidths(new int[] { 30, 30, 20, 20 });
                tblContent.WidthPercentage = 99;
                tblContent.Border = 0;
                tblContent.Cellpadding = 1;
                tblContent.Cellspacing = 1;

                tblContent.addCell(PdfHelper.GetTitleCellLeft("所属公司"));
                tblContent.addCell(PdfHelper.GetTitleCellLeft("所属部门"));
                tblContent.addCell(PdfHelper.GetTitleCellLeft("业务员"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("金额"));

                decimal totalMoney = 0;
                foreach (UserSales us in result)
                {
                    tblContent.addCell(PdfHelper.GetCellLeft(CompanyOperation.GetCompanyById(us.User.CompanyId).Name));
                    tblContent.addCell(PdfHelper.GetCellLeft(DepartmentOperation.GetDepartmentById(us.User.DepartmentId).Name));
                    tblContent.addCell(PdfHelper.GetCellLeft(us.User.RealName));
                    tblContent.addCell(PdfHelper.GetCellRight(us.Money.ToString()));

                    totalMoney += us.Money;
                }

                tblContent.addCell(PdfHelper.GetCellLeft(""));
                tblContent.addCell(PdfHelper.GetCellLeft(""));
                tblContent.addCell(PdfHelper.GetCellLeft(""));
                tblContent.addCell(PdfHelper.GetCellLeft(""));

                tblContent.addCell(PdfHelper.GetFooterCellLeft("合计："));
                tblContent.addCell(PdfHelper.GetFooterCellRight(""));
                tblContent.addCell(PdfHelper.GetFooterCellRight(""));
                tblContent.addCell(PdfHelper.GetFooterCellRight(totalMoney.ToString()));

                document.Add(tblContent);


                document.resetHeader();
            }
            catch (Exception ex)
            {
                lblMsg.Text = "生成PDF文件出错，" + ex.ToString();
            }
            finally
            {
                document.Close();
            }
            Response.Redirect("/Config/" + fileName + ".pdf");
        }
        else
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName + ".xls");
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.ContentType = "application/vnd.ms-excel";

            Response.Write("<table border='1'>");
            Response.Write("<tr style='font-size:16px;font-weight:bold;height:35px;'><td align='center' valign='middle' colspan='4'>业务员考核表</td></tr>");
            Response.Write("<tr style='font-weight:bold;'><td align='left' colspan='4'>&nbsp;" + titleContent + "</td></tr>");
            Response.Write("<tr style='font-weight:bold;'><td align='left'>&nbsp;所属公司</td><td align='left'>&nbsp;所属部门</td><td align='left'>&nbsp;业务员</td><td align='right'>&nbsp;金额</td></tr>");

            decimal totalMoney = 0;
            foreach (UserSales us in result)
            {
                Response.Write("<tr>");
                Response.Write("<td align='left'>&nbsp;" + CompanyOperation.GetCompanyById(us.User.CompanyId).Name + "</td>");
                Response.Write("<td align='left'>&nbsp;" + DepartmentOperation.GetDepartmentById(us.User.DepartmentId).Name + "</td>");
                Response.Write("<td align='left'>&nbsp;" + us.User.RealName + "</td>");
                Response.Write("<td align='right'>" + us.Money.ToString() + "</td>");
                Response.Write("</tr>");

                totalMoney += us.Money;
            }

            Response.Write("<tr style='font-weight:bold;'><td align='left'>&nbsp;合计：</td><td colspan='2'>&nbsp;</td><td align='right'>&nbsp;" + totalMoney.ToString() + "</td></tr>");
            Response.Write("</table>");
            Response.Flush();
            Response.End();
        }
    }
    protected void btnProfitReport_Click(object sender, EventArgs e)
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

        string carrierEncode = ddlCarrier.SelectedItem.Value;
        string strCompanyId = ddlCompany.SelectedItem.Value;
        string strCompanyName = ddlCompany.SelectedItem.Text;
        string strCarrierEncode = ddlCarrier.SelectedItem.Value;
        string strUserId = "0";
        if (ddlCompany.SelectedItem.Value != "0")
        {
            strUserId = ddlCompanyUsers.SelectedItem.Value;
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

        int companyId = 0;
        if (!int.TryParse(strCompanyId, out companyId))
        {
            companyId = 0;
        }

        int userId = 0;
        if (!int.TryParse(strUserId, out userId))
        {
            userId = 0;
        }

        List<SearchOrderDetail> result = OrderOperation.GetReceiveOrderDetailStatistic(startDate, endDate, companyId, clientId, carrierEncode, userId);

        string fileName = StringHelper.GetEncodeNumber("LR");
        string titleContent = "";
        if (ddlCompany.SelectedItem.Value != "0")
        {
            titleContent = "所属公司：" + strCompanyName + "      ";
        }
        if (startDate > minTime)
        {
            titleContent += "开始日期：" + startDate.ToShortDateString() + "      ";
        }

        if (endDate > minTime)
        {
            titleContent += "结束日期：" + endDate.ToShortDateString() + "      ";
        }

        if (ddlReportType.SelectedItem.Value == "1")
        {

            string filePath = Server.MapPath("../../Config/");

            string[] fileArray = Directory.GetFiles(filePath, "*.pdf");
            foreach (string file in fileArray)
            {
                File.Delete(file);
            }
            Document document = new Document(PageSize.A4, 15, 15, 10, 10);

            try
            {
                PdfWriter.getInstance(document, new FileStream(filePath + fileName + ".pdf", FileMode.Create));

                document.Header = PdfHelper.GetHeardFooter("亿度物流", SettingOperation.LoadSetting().Phone);

                document.Open();

                Paragraph phTitle = new Paragraph(new Chunk("利润分析表", PdfHelper.fontTitle));
                phTitle.Alignment = Element.ALIGN_CENTER;

                Paragraph phTitle2 = new Paragraph(new Chunk(titleContent, PdfHelper.fontHeader));
                phTitle2.Alignment = Element.ALIGN_LEFT;

                document.Add(phTitle);
                document.Add(phTitle2);

                iTextSharp.text.Table tblContent = new iTextSharp.text.Table(12);
                tblContent.setWidths(new int[] { 15, 10, 8, 8, 8 , 8, 9, 7, 7, 7, 7, 11 });
                tblContent.WidthPercentage = 99;
                tblContent.Border = 0;
                tblContent.Cellpadding = 1;
                tblContent.Cellspacing = 1;

                tblContent.addCell(PdfHelper.GetTitleCellLeft("收件单号"));
                tblContent.addCell(PdfHelper.GetTitleCellLeft("收件日期"));
                tblContent.addCell(PdfHelper.GetTitleCellLeft("客户姓名"));
                tblContent.addCell(PdfHelper.GetTitleCellLeft("业务员"));
                tblContent.addCell(PdfHelper.GetTitleCellLeft("承运商"));
                tblContent.addCell(PdfHelper.GetTitleCellLeft("单号"));
                tblContent.addCell(PdfHelper.GetTitleCellLeft("国家"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("重量"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("数量"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("收入"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("成本"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("利润金额"));

                int totalCount = 0;
                decimal totalIncome = 0;
                decimal totalCost = 0;
                decimal totalProfit = 0;

                foreach (SearchOrderDetail sod in result)
                {
                    tblContent.addCell(PdfHelper.GetCellLeft(sod.OrderEncode));
                    tblContent.addCell(PdfHelper.GetCellLeft(OrderOperation.GetOrderByEncode(sod.OrderEncode).ReceiveDate.ToShortDateString()));
                    tblContent.addCell(PdfHelper.GetCellLeft(sod.Client.RealName));
                    tblContent.addCell(PdfHelper.GetCellLeft(UserOperation.GetUserById(OrderOperation.GetOrderByEncode(sod.OrderEncode).UserId).RealName));
                    tblContent.addCell(PdfHelper.GetCellLeft(sod.CarrierEncode));
                    tblContent.addCell(PdfHelper.GetCellLeft(sod.BarCode));
                    tblContent.addCell(PdfHelper.GetCellLeft(sod.ToCountry));
                    tblContent.addCell(PdfHelper.GetCellRight(sod.Weight.ToString()));
                    tblContent.addCell(PdfHelper.GetCellRight(sod.Count.ToString()));
                    tblContent.addCell(PdfHelper.GetCellRight(sod.TotalCosts.ToString()));
                    tblContent.addCell(PdfHelper.GetCellRight(sod.SelfTotalCosts.ToString()));
                    tblContent.addCell(PdfHelper.GetCellRight((sod.TotalCosts - sod.SelfTotalCosts).ToString()));

                    totalCount += sod.Count;
                    totalIncome += sod.TotalCosts;
                    totalCost += sod.SelfTotalCosts;
                    totalProfit += (sod.TotalCosts - sod.SelfTotalCosts);
                }

                tblContent.addCell(PdfHelper.GetCellLeft(""));
                tblContent.addCell(PdfHelper.GetCellLeft(""));
                tblContent.addCell(PdfHelper.GetCellLeft(""));
                tblContent.addCell(PdfHelper.GetCellLeft(""));
                tblContent.addCell(PdfHelper.GetCellLeft(""));
                tblContent.addCell(PdfHelper.GetCellLeft(""));
                tblContent.addCell(PdfHelper.GetCellLeft(""));
                tblContent.addCell(PdfHelper.GetCellLeft(""));
                tblContent.addCell(PdfHelper.GetCellLeft(""));
                tblContent.addCell(PdfHelper.GetCellLeft(""));
                tblContent.addCell(PdfHelper.GetCellLeft(""));
                tblContent.addCell(PdfHelper.GetCellLeft(""));

                tblContent.addCell(PdfHelper.GetFooterCellLeft("总计："));
                tblContent.addCell(PdfHelper.GetFooterCellLeft(""));
                tblContent.addCell(PdfHelper.GetFooterCellLeft(""));
                tblContent.addCell(PdfHelper.GetFooterCellLeft(""));
                tblContent.addCell(PdfHelper.GetFooterCellLeft(""));
                tblContent.addCell(PdfHelper.GetFooterCellLeft(""));
                tblContent.addCell(PdfHelper.GetFooterCellLeft(""));
                tblContent.addCell(PdfHelper.GetFooterCellLeft(""));
                tblContent.addCell(PdfHelper.GetFooterCellRight(totalCount.ToString()));
                tblContent.addCell(PdfHelper.GetFooterCellRight(totalIncome.ToString()));
                tblContent.addCell(PdfHelper.GetFooterCellRight(totalCost.ToString()));
                tblContent.addCell(PdfHelper.GetFooterCellRight(totalProfit.ToString()));

                document.Add(tblContent);

                document.resetHeader();
            }
            catch (Exception ex)
            {
                lblMsg.Text = "生成PDF文件出错，" + ex.ToString();
            }
            finally
            {
                document.Close();
            }
            Response.Redirect("/Config/" + fileName + ".pdf");
        }        
        else
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName + ".xls");
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.ContentType = "application/vnd.ms-excel";

            Response.Write("<table border='1'>");
            Response.Write("<tr style='font-size:16px;font-weight:bold;height:35px;'><td align='center' valign='middle' colspan='12'>利润分析表</td></tr>");
            Response.Write("<tr style='font-weight:bold;'><td align='left' colspan='12'>&nbsp;"+titleContent+"</td></tr>");
            Response.Write("<tr style='font-weight:bold;'><td align='left'>&nbsp;收件单号</td><td align='left'>&nbsp;收件日期</td><td align='left'>&nbsp;客户姓名</td><td align='left'>&nbsp;业务员</td><td align='left'>&nbsp;承运商</td><td align='left'>&nbsp;单号</td><td align='left'>&nbsp;国家</td><td align='right'>&nbsp;重量</td><td align='right'>&nbsp;数量</td><td align='right'>&nbsp;收入</td><td align='right'>&nbsp;成本</td><td align='right'>&nbsp;利润金额</td></tr>");

            int totalCount = 0;
            decimal totalIncome = 0;
            decimal totalCost = 0;
            decimal totalProfit = 0;
            foreach (SearchOrderDetail sod in result)
            {
                Response.Write("<tr>");
                Response.Write("<td align='left'>&nbsp;" + sod.OrderEncode + "</td>");
                Response.Write("<td align='left'>&nbsp;" + OrderOperation.GetOrderByEncode(sod.OrderEncode).ReceiveDate.ToShortDateString() + "</td>");
                Response.Write("<td align='left'>&nbsp;" + sod.Client.RealName + "</td>");
                Response.Write("<td align='left'>&nbsp;" + UserOperation.GetUserById(OrderOperation.GetOrderByEncode(sod.OrderEncode).UserId).RealName + "</td>");
                Response.Write("<td align='left'>&nbsp;" + sod.CarrierEncode + "</td>");
                Response.Write("<td align='left'>" + sod.BarCode + "</td>");
                Response.Write("<td align='left'>" + sod.ToCountry + "</td>");
                Response.Write("<td align='right'>" + sod.Weight.ToString() + "</td>");
                Response.Write("<td align='right'>" + sod.Count.ToString() + "</td>");
                Response.Write("<td align='right'>" + sod.TotalCosts.ToString() + "</td>");
                Response.Write("<td align='right'>" + sod.SelfTotalCosts.ToString() + "</td>");
                Response.Write("<td align='right'>" + (sod.TotalCosts - sod.SelfTotalCosts).ToString() + "</td>");
                Response.Write("</tr>");

                totalCount += sod.Count;
                totalIncome += sod.TotalCosts;
                totalCost += sod.SelfTotalCosts;
                totalProfit += (sod.TotalCosts - sod.SelfTotalCosts);
            }

            Response.Write("<tr style='font-weight:bold;'><td align='left'>&nbsp;合计：</td><td colspan='7'>&nbsp;</td><td align='right'>" + totalCount.ToString() + "</td><td align='right'>" + totalIncome.ToString() + "</td><td align='right'>" + totalCost.ToString() + "</td><td align='right'>" + totalProfit.ToString() + "</td></tr>");
            Response.Write("</table>");
            Response.Flush();
            Response.End();
        }
    }
}
