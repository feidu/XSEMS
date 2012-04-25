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
            DdlCompanyDataBind();
            DdlCompanyUsersDataBind();
        }
        companyId = ddlCompany.SelectedItem.Value;
        txtStartDate.Value = DateTime.Now.AddMonths(-1).ToShortDateString();
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

        string strCompanyId = ddlCompany.SelectedItem.Value;
        string strCompanyName = ddlCompany.SelectedItem.Text;

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

        List<ShouldReceive> result = StatisticOperation.GetShouldReceiveStatistic(startDate, endDate, companyId, clientId, userId);
        
        string fileName = StringHelper.GetEncodeNumber("YS");
        string titleContent = "";
        if (ddlCompany.SelectedItem.Value != "0")
        {
            titleContent = "所属公司：" + strCompanyName + "    ";
        }
        if (startDate > minTime)
        {
            titleContent += "开始日期：" + startDate.ToShortDateString() + "    ";
        }
        if (endDate > minTime)
        {
            titleContent += "结束日期：" + endDate.ToShortDateString() + "    ";
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

                Paragraph phTitle = new Paragraph(new Chunk("应收款汇总", PdfHelper.fontTitle));
                phTitle.Alignment = Element.ALIGN_CENTER;

                Paragraph phTitle2 = new Paragraph(new Chunk(titleContent, PdfHelper.fontHeader));
                phTitle2.Alignment = Element.ALIGN_LEFT;

                document.Add(phTitle);
                document.Add(phTitle2);

                iTextSharp.text.Table tblContent = new iTextSharp.text.Table(4);
                tblContent.setWidths(new int[] { 35, 25, 20, 20 });
                tblContent.WidthPercentage = 99;
                tblContent.Border = 0;
                tblContent.Cellpadding = 1;
                tblContent.Cellspacing = 1;

                tblContent.addCell(PdfHelper.GetTitleCellLeft("所属公司"));
                tblContent.addCell(PdfHelper.GetTitleCellLeft("客户用户名"));
                tblContent.addCell(PdfHelper.GetTitleCellLeft("客户姓名"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("应收金额"));

                decimal totalMoney = 0;
                foreach (ShouldReceive sr in result)
                {
                    tblContent.addCell(PdfHelper.GetCellLeft(CompanyOperation.GetCompanyById(ClientOperation.GetClientById(sr.ClientId).CompanyId).Name));
                    tblContent.addCell(PdfHelper.GetCellLeft(ClientOperation.GetClientById(sr.ClientId).Username));
                    tblContent.addCell(PdfHelper.GetCellLeft(ClientOperation.GetClientById(sr.ClientId).RealName));
                    tblContent.addCell(PdfHelper.GetCellRight(sr.Money.ToString()));

                    totalMoney += sr.Money;
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
            Response.Write("<tr style='font-size:16px;font-weight:bold;height:35px;'><td align='center' valign='middle' colspan='4'>应收款汇总</td></tr>");
            Response.Write("<tr style='font-weight:bold;'><td align='left' colspan='4'>&nbsp;" + titleContent + "</td></tr>");
            Response.Write("<tr style='font-weight:bold;'><td align='left'>&nbsp;所属公司</td><td align='left'>&nbsp;客户用户名</td><td align='left'>&nbsp;客户姓名</td><td align='right'>&nbsp;应收金额</td></tr>");

            decimal totalMoney = 0;
            foreach (ShouldReceive sr in result)
            {
                Response.Write("<tr>");
                Response.Write("<td align='left'>&nbsp;" + CompanyOperation.GetCompanyById(ClientOperation.GetClientById(sr.ClientId).CompanyId).Name + "</td>");
                Response.Write("<td align='left'>&nbsp;" + ClientOperation.GetClientById(sr.ClientId).Username + "</td>");
                Response.Write("<td align='left'>&nbsp;" + ClientOperation.GetClientById(sr.ClientId).RealName + "</td>");
                Response.Write("<td align='right'>" + sr.Money.ToString() + "</td>");
                Response.Write("</tr>");

                totalMoney += sr.Money;
            }

            Response.Write("<tr style='font-weight:bold;'><td align='left'>&nbsp;合计：</td><td colspan='2'>&nbsp;</td><td align='right'>" + totalMoney.ToString() + "</td></tr>");
            Response.Write("</table>");
            Response.Flush();
            Response.End();
        }
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

        string strCompanyId = ddlCompany.SelectedItem.Value;
        string strCompanyName = ddlCompany.SelectedItem.Text;

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

        List<SearchOrderDetail> result = OrderOperation.GetReceiveOrderDetailStatistic(startDate, endDate, companyId, clientId, "", userId);

        string fileName = StringHelper.GetEncodeNumber("DZ");
        string titleContent = "";
        if (ddlCompany.SelectedItem.Value != "0")
        {
            titleContent = "所属公司：" + strCompanyName + "    ";
        }
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

                Paragraph phTitle = new Paragraph(new Chunk("客户对账单", PdfHelper.fontTitle));
                phTitle.Alignment = Element.ALIGN_CENTER;

                Paragraph phTitle2 = new Paragraph(new Chunk(titleContent, PdfHelper.fontHeader));
                phTitle2.Alignment = Element.ALIGN_LEFT;

                document.Add(phTitle);
                document.Add(phTitle2);

                iTextSharp.text.Table tblContent = new iTextSharp.text.Table(10);
                tblContent.setWidths(new int[] { 9, 24, 17, 15, 5, 5, 5, 6, 6, 8 });
                tblContent.WidthPercentage = 99;
                tblContent.Border = 0;
                tblContent.Cellpadding = 1;
                tblContent.Cellspacing = 1;

                tblContent.addCell(PdfHelper.GetTitleCellLeft("日期"));
                tblContent.addCell(PdfHelper.GetTitleCellLeft("承运商"));
                tblContent.addCell(PdfHelper.GetTitleCellLeft("包裹单号"));
                tblContent.addCell(PdfHelper.GetTitleCellLeft("国家"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("重量"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("数量"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("运费"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("材料费"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("保价费"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("应收费用"));

                decimal totalMoney = 0;
                foreach (SearchOrderDetail sod in result)
                {
                    tblContent.addCell(PdfHelper.GetCellLeft(sod.CreateTime.ToShortDateString()));
                    tblContent.addCell(PdfHelper.GetCellLeft(CarrierOperation.GetCarrierByEncode(sod.CarrierEncode).Name));
                    tblContent.addCell(PdfHelper.GetCellLeft(sod.BarCode));
                    tblContent.addCell(PdfHelper.GetCellLeft(sod.ToCountry));
                    tblContent.addCell(PdfHelper.GetCellRight(sod.Weight.ToString()));
                    tblContent.addCell(PdfHelper.GetCellRight(sod.Count.ToString()));
                    tblContent.addCell(PdfHelper.GetCellRight(sod.PostCosts.ToString()));
                    tblContent.addCell(PdfHelper.GetCellRight(sod.MaterialCosts.ToString()));
                    tblContent.addCell(PdfHelper.GetCellRight(sod.InsureCosts.ToString()));
                    tblContent.addCell(PdfHelper.GetCellRight(sod.TotalCosts.ToString()));

                    totalMoney += sod.TotalCosts;
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

                tblContent.addCell(PdfHelper.GetFooterCellLeft("合计："));
                tblContent.addCell(PdfHelper.GetFooterCellRight(""));
                tblContent.addCell(PdfHelper.GetFooterCellRight(""));
                tblContent.addCell(PdfHelper.GetFooterCellRight(""));
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

        string strCompanyId = ddlCompany.SelectedItem.Value;
        string strCompanyName = ddlCompany.SelectedItem.Text;

        string strUserId = "0";
        if (ddlCompany.SelectedItem.Value != "0")
        {
            strUserId = ddlCompanyUsers.SelectedItem.Value;
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

        Company company=CompanyOperation.GetCompanyById(client.CompanyId);

        List<SearchOrderDetail> result = OrderOperation.GetReceiveOrderDetailStatistic(startDate, endDate, companyId, clientId, "", userId);
        if (result.Count > 0)
        {
            string msg = "";
            EmailHelper.SendMailForBill(startDate, endDate, company, client, result, out msg);
            Response.Write("<script language='javascript' type='text/javascript'>alert('" + msg + "');location.href='ShouldReceiveReport.aspx';</script>");
        }
        else
        {
            Response.Write("<script language='javascript' type='text/javascript'>alert('此客户在此段时间无发货记录！');</script>");
            return;
        }
    }
}

