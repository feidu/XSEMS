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
        if (!IsPostBack)
        {
            DdlCompanyDataBind();
            DdlCompanyUsersDataBind();
            DdlReceiveUsersDataBind();
        }
        companyId = ddlCompany.SelectedItem.Value;
        txtStartDate.Value = DateTime.Now.ToShortDateString();
        txtEndDate.Value = DateTime.Now.ToShortDateString();

        result = PaymentMethodOperation.GetPaymentMethod();
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

    private void DdlCompanyUsersDataBind()
    {
        ddlCompanyUsers.DataSource = UserOperation.GetLightUser();
        ddlCompanyUsers.DataTextField = "RealName";
        ddlCompanyUsers.DataValueField = "Id";
        ddlCompanyUsers.DataBind();
        ddlCompanyUsers.Items.Add(new System.Web.UI.WebControls.ListItem("", "0"));
        ddlCompanyUsers.SelectedValue = "0";
    }

    private void DdlReceiveUsersDataBind()
    {
        ddlReceiveUsers.DataSource = UserOperation.GetLightUser();
        ddlReceiveUsers.DataTextField = "RealName";
        ddlReceiveUsers.DataValueField = "Id";
        ddlReceiveUsers.DataBind();
        ddlReceiveUsers.Items.Add(new System.Web.UI.WebControls.ListItem("", "0"));
        ddlReceiveUsers.SelectedValue = "0";
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

            ddlReceiveUsers.DataSource = UserOperation.GetLightUserByCompanyId(int.Parse(companyId));
            ddlReceiveUsers.DataTextField = "RealName";
            ddlReceiveUsers.DataValueField = "Id";
            ddlReceiveUsers.DataBind();
            ddlReceiveUsers.Items.Add(new System.Web.UI.WebControls.ListItem("", "0"));
            ddlReceiveUsers.SelectedValue = "0";
        }
        else
        {
            DdlCompanyUsersDataBind();
            DdlReceiveUsersDataBind();
        }
        txtClientName.Value = "";
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

        string strCompanyId = ddlCompany.SelectedItem.Value;
        string strCompanyName = ddlCompany.SelectedItem.Text;
        string pmIds = Request.Form["chkPaymentMethod"];
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

        List<Recharge> result = StatisticOperation.GetRechargeStatistic(startDate, endDate, companyId, clientId, userId, userId, pmIds);

        string fileName = StringHelper.GetEncodeNumber("SK");
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

                Paragraph phTitle = new Paragraph(new Chunk("已收款汇总", PdfHelper.fontTitle));
                phTitle.Alignment = Element.ALIGN_CENTER;
                                
                Paragraph phTitle2 = new Paragraph(new Chunk(titleContent, PdfHelper.fontHeader));
                phTitle2.Alignment = Element.ALIGN_LEFT;

                document.Add(phTitle);
                document.Add(phTitle2);

                iTextSharp.text.Table tblContent = new iTextSharp.text.Table(7);
                tblContent.setWidths(new int[] { 18, 15, 10, 15, 14, 14, 14 });
                tblContent.WidthPercentage = 99;
                tblContent.Border = 0;
                tblContent.Cellpadding = 1;
                tblContent.Cellspacing = 1;

                tblContent.addCell(PdfHelper.GetTitleCellLeft("所属公司"));
                tblContent.addCell(PdfHelper.GetTitleCellLeft("收款单号"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("收款日期"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("发票号码"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("付款方式"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("经手人"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("收款金额"));

                decimal totalMoney = 0;
                foreach (Recharge recharge in result)
                {
                    tblContent.addCell(PdfHelper.GetCellLeft(CompanyOperation.GetCompanyById(recharge.CompanyId).Name));
                    tblContent.addCell(PdfHelper.GetCellLeft(recharge.Encode));
                    tblContent.addCell(PdfHelper.GetCellRight(recharge.ReceiveTime.ToShortDateString()));
                    tblContent.addCell(PdfHelper.GetCellRight(recharge.Invoice));
                    tblContent.addCell(PdfHelper.GetCellRight(recharge.PaymentMethodName));
                    tblContent.addCell(PdfHelper.GetCellRight(recharge.UserName));
                    tblContent.addCell(PdfHelper.GetCellRight(recharge.Money.ToString()));

                    totalMoney += recharge.Money;
                }

                tblContent.addCell(PdfHelper.GetCellLeft(""));
                tblContent.addCell(PdfHelper.GetCellLeft(""));
                tblContent.addCell(PdfHelper.GetCellLeft(""));
                tblContent.addCell(PdfHelper.GetCellLeft(""));
                tblContent.addCell(PdfHelper.GetCellLeft(""));
                tblContent.addCell(PdfHelper.GetCellLeft(""));
                tblContent.addCell(PdfHelper.GetCellLeft(""));

                tblContent.addCell(PdfHelper.GetFooterCellLeft("合计："));
                tblContent.addCell(PdfHelper.GetFooterCellRight(""));
                tblContent.addCell(PdfHelper.GetFooterCellRight(""));
                tblContent.addCell(PdfHelper.GetFooterCellRight(""));
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

        string strCompanyId = ddlCompany.SelectedItem.Value;
        string strCompanyName = ddlCompany.SelectedItem.Text;
        string pmIds = Request.Form["chkPaymentMethod"];

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

        List<ClientRecharge> result = StatisticOperation.GetRechargeDetailStatistic(startDate, endDate, companyId, clientId, userId, userId, pmIds);

        string fileName = StringHelper.GetEncodeNumber("SK");
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

                Paragraph phTitle = new Paragraph(new Chunk("已收款明细", PdfHelper.fontTitle));
                phTitle.Alignment = Element.ALIGN_CENTER;



                Paragraph phTitle2 = new Paragraph(new Chunk(titleContent, PdfHelper.fontHeader));
                phTitle2.Alignment = Element.ALIGN_LEFT;

                document.Add(phTitle);
                document.Add(phTitle2);

                iTextSharp.text.Table tblContent = new iTextSharp.text.Table(7);
                tblContent.setWidths(new int[] { 18, 15, 10, 15, 14, 14, 14 });
                tblContent.WidthPercentage = 99;
                tblContent.Border = 0;
                tblContent.Cellpadding = 1;
                tblContent.Cellspacing = 1;

                tblContent.addCell(PdfHelper.GetTitleCellLeft("所属公司"));
                tblContent.addCell(PdfHelper.GetTitleCellLeft("收款单号"));
                tblContent.addCell(PdfHelper.GetTitleCellLeft("收款日期"));
                tblContent.addCell(PdfHelper.GetTitleCellLeft("发票号码"));
                tblContent.addCell(PdfHelper.GetTitleCellLeft("付款方式"));
                tblContent.addCell(PdfHelper.GetTitleCellLeft("经手人"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("收款金额"));
                foreach (ClientRecharge cr in result)
                {
                    Cell cellClientName = new Cell(new Paragraph("客户姓名： " + cr.Client.RealName, PdfHelper.fontContent));
                    cellClientName.Colspan = 7;
                    cellClientName.HorizontalAlignment = Element.ALIGN_LEFT;
                    cellClientName.VerticalAlignment = Element.ALIGN_MIDDLE;
                    tblContent.addCell(cellClientName);

                    decimal totalMoney = 0;
                    foreach (Recharge recharge in cr.RechargeList)
                    {
                        tblContent.addCell(PdfHelper.GetCellLeft(CompanyOperation.GetCompanyById(recharge.CompanyId).Name));
                        tblContent.addCell(PdfHelper.GetCellLeft(recharge.Encode));
                        tblContent.addCell(PdfHelper.GetCellLeft(recharge.ReceiveTime.ToShortDateString()));
                        tblContent.addCell(PdfHelper.GetCellLeft(recharge.Invoice));
                        tblContent.addCell(PdfHelper.GetCellLeft(recharge.PaymentMethodName));
                        tblContent.addCell(PdfHelper.GetCellLeft(recharge.UserName));
                        tblContent.addCell(PdfHelper.GetCellRight(recharge.Money.ToString()));

                        totalMoney += recharge.Money;
                    }

                    tblContent.addCell(PdfHelper.GetFooterCellLeft("合计："));
                    tblContent.addCell(PdfHelper.GetFooterCellRight(""));
                    tblContent.addCell(PdfHelper.GetFooterCellRight(""));
                    tblContent.addCell(PdfHelper.GetFooterCellRight(""));
                    tblContent.addCell(PdfHelper.GetFooterCellRight(""));
                    tblContent.addCell(PdfHelper.GetFooterCellRight(""));
                    tblContent.addCell(PdfHelper.GetFooterCellRight(totalMoney.ToString()));
                }
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
}
