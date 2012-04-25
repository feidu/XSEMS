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

public partial class Admin_Statistic_Default : System.Web.UI.Page
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
        
    protected void btnSjOrderReport_Click(object sender, EventArgs e)
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
        if(!int.TryParse(strCompanyId, out companyId))
        {
            companyId = 0;
        }

        int userId = 0;
        if (!int.TryParse(strUserId, out userId))
        {
            userId = 0;
        }

        List<SearchOrder> result = OrderOperation.GetReceiveOrderStatistic(startDate, endDate, companyId, clientId, carrierEncode, userId);


        string fileName = StringHelper.GetEncodeNumber("SJ");
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

                Paragraph phTitle = new Paragraph(new Chunk("收件汇总表", PdfHelper.fontTitle));
                phTitle.Alignment = Element.ALIGN_CENTER;

                Paragraph phTitle2 = new Paragraph(new Chunk(titleContent, PdfHelper.fontHeader));
                phTitle2.Alignment = Element.ALIGN_LEFT;

                document.Add(phTitle);
                document.Add(phTitle2);

                iTextSharp.text.Table tblContent = new iTextSharp.text.Table(4);
                tblContent.setWidths(new int[] { 40, 20, 20, 20 });
                tblContent.WidthPercentage = 99;
                tblContent.Border = 0;
                tblContent.Cellpadding = 1;
                tblContent.Cellspacing = 1;

                tblContent.addCell(PdfHelper.GetTitleCellLeft("客户姓名"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("重量"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("数量"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("金额"));

                decimal totalWeight = 0;
                int totalCount = 0;
                decimal totalMoney = 0;
                foreach (SearchOrder so in result)
                {
                    tblContent.addCell(PdfHelper.GetCellLeft(so.Client.RealName));
                    tblContent.addCell(PdfHelper.GetCellRight(so.TotalWeight.ToString()));
                    tblContent.addCell(PdfHelper.GetCellRight(so.TotalCount.ToString()));
                    tblContent.addCell(PdfHelper.GetCellRight(so.TotalCost.ToString()));

                    totalWeight += so.TotalWeight;
                    totalCount += so.TotalCount;
                    totalMoney += so.TotalCost;
                }

                tblContent.addCell(PdfHelper.GetCellLeft(""));
                tblContent.addCell(PdfHelper.GetCellLeft(""));
                tblContent.addCell(PdfHelper.GetCellLeft(""));
                tblContent.addCell(PdfHelper.GetCellLeft(""));

                tblContent.addCell(PdfHelper.GetFooterCellLeft("总计："));
                tblContent.addCell(PdfHelper.GetFooterCellRight(totalWeight.ToString()));
                tblContent.addCell(PdfHelper.GetFooterCellRight(totalCount.ToString()));
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
            Response.Write("<tr style='font-size:16px;font-weight:bold;height:35px;'><td align='center' valign='middle' colspan='4'>收件汇总表</td></tr>");
            Response.Write("<tr style='font-weight:bold;'><td align='left' colspan='4'>&nbsp;" + titleContent + "</td></tr>");
            Response.Write("<tr style='font-weight:bold;'><td align='left'>&nbsp;客户姓名</td><td align='right'>&nbsp;重量</td><td align='right'>&nbsp;数量</td><td align='right'>&nbsp;金额</td></tr>");

            decimal totalWeight = 0;
            int totalCount = 0;
            decimal totalMoney = 0;
            foreach (SearchOrder so in result)
            {
                Response.Write("<tr>");
                Response.Write("<td align='left'>&nbsp;" + so.Client.RealName + "</td>");
                Response.Write("<td align='right'>" + so.TotalWeight.ToString() + "</td>");
                Response.Write("<td align='right'>" + so.TotalCount.ToString() + "</td>");
                Response.Write("<td align='right'>" + so.TotalCost.ToString() + "</td>");
                Response.Write("</tr>");

                totalWeight += so.TotalWeight;
                totalCount += so.TotalCount;
                totalMoney += so.TotalCost;
            }

            Response.Write("<tr style='font-weight:bold;'><td align='left'>&nbsp;合计：</td><td align='right'>" + totalWeight.ToString() + "</td><td align='right'>" + totalCount.ToString() + "</td><td align='right'>" + totalMoney.ToString() + "</td></tr>");
            Response.Write("</table>");
            Response.Flush();
            Response.End();
        }
    }
    protected void btnSjOrderDetail_Click(object sender, EventArgs e)
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

        string fileName = StringHelper.GetEncodeNumber("MX");
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

                Paragraph phTitle = new Paragraph(new Chunk("收件明细表", PdfHelper.fontTitle));
                phTitle.Alignment = Element.ALIGN_CENTER;

                Paragraph phTitle2 = new Paragraph(new Chunk(titleContent, PdfHelper.fontHeader));
                phTitle2.Alignment = Element.ALIGN_LEFT;

                document.Add(phTitle);
                document.Add(phTitle2);

                iTextSharp.text.Table tblContent = new iTextSharp.text.Table(9);
                tblContent.setWidths(new int[] { 16, 12, 10, 13, 13, 12, 8, 8, 8 });
                tblContent.WidthPercentage = 99;
                tblContent.Border = 0;
                tblContent.Cellpadding = 1;
                tblContent.Cellspacing = 1;

                tblContent.addCell(PdfHelper.GetTitleCellLeft("收件单号"));
                tblContent.addCell(PdfHelper.GetTitleCellLeft("收件日期"));
                tblContent.addCell(PdfHelper.GetTitleCellLeft("客户姓名"));
                tblContent.addCell(PdfHelper.GetTitleCellLeft("跟踪条码"));
                tblContent.addCell(PdfHelper.GetTitleCellLeft("国家"));
                tblContent.addCell(PdfHelper.GetTitleCellLeft("承运商"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("重量"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("数量"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("金额"));


                decimal totalWeight = 0;
                int totalCount = 0;
                decimal totalMoney = 0;
                foreach (SearchOrderDetail sod in result)
                {
                    tblContent.addCell(PdfHelper.GetCellLeft(sod.OrderEncode));
                    tblContent.addCell(PdfHelper.GetCellLeft(OrderOperation.GetOrderByEncode(sod.OrderEncode).ReceiveDate.ToShortDateString()));
                    tblContent.addCell(PdfHelper.GetCellLeft(sod.Client.RealName));
                    tblContent.addCell(PdfHelper.GetCellLeft(sod.BarCode));
                    tblContent.addCell(PdfHelper.GetCellLeft(sod.ToCountry));
                    tblContent.addCell(PdfHelper.GetCellLeft(sod.CarrierEncode));
                    tblContent.addCell(PdfHelper.GetCellRight(sod.Weight.ToString()));
                    tblContent.addCell(PdfHelper.GetCellRight(sod.Count.ToString()));
                    tblContent.addCell(PdfHelper.GetCellRight(sod.TotalCosts.ToString()));

                    totalWeight += sod.Weight;
                    totalCount += sod.Count;
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

                tblContent.addCell(PdfHelper.GetFooterCellLeft("总计："));
                tblContent.addCell(PdfHelper.GetFooterCellLeft(""));
                tblContent.addCell(PdfHelper.GetFooterCellLeft(""));
                tblContent.addCell(PdfHelper.GetFooterCellLeft(""));
                tblContent.addCell(PdfHelper.GetFooterCellLeft(""));
                tblContent.addCell(PdfHelper.GetFooterCellLeft(""));
                tblContent.addCell(PdfHelper.GetFooterCellRight(totalWeight.ToString()));
                tblContent.addCell(PdfHelper.GetFooterCellRight(totalCount.ToString()));
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
            Response.Write("<tr style='font-size:16px;font-weight:bold;height:35px;'><td align='center' valign='middle' colspan='11'>收件明细表</td></tr>");
            Response.Write("<tr style='font-weight:bold;;height:24px;'><td align='left' colspan='11'>&nbsp;" + titleContent + "</td></tr>");
            Response.Write("<tr style='font-weight:bold;;height:24px;'><td align='left' colspan='11'>&nbsp;付款账号：工行：3901140019200060153&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;支付宝：11960053@qq.com</td></tr>");
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

    protected void btnFetchCostsReport_Click(object sender, EventArgs e)
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

        List<SearchOrderDetail> result = OrderOperation.GetFetchCostsStatistic(startDate, endDate, companyId, clientId, carrierEncode, userId);

        string fileName = StringHelper.GetEncodeNumber("QJ");
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

                Paragraph phTitle = new Paragraph(new Chunk("取件费汇总表", PdfHelper.fontTitle));
                phTitle.Alignment = Element.ALIGN_CENTER;

                Paragraph phTitle2 = new Paragraph(new Chunk(titleContent, PdfHelper.fontHeader));
                phTitle2.Alignment = Element.ALIGN_LEFT;

                document.Add(phTitle);
                document.Add(phTitle2);

                iTextSharp.text.Table tblContent = new iTextSharp.text.Table(5);
                tblContent.setWidths(new int[] { 40, 15, 15, 15, 15 });
                tblContent.WidthPercentage = 99;
                tblContent.Border = 0;
                tblContent.Cellpadding = 1;
                tblContent.Cellspacing = 1;

                tblContent.addCell(PdfHelper.GetTitleCellLeft("客户姓名"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("取件费"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("处理费"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("材料费"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("其它费"));


                decimal totalFetchCosts = 0;
                decimal totalDisposalCosts = 0;
                decimal totalMaterialCosts = 0;
                decimal totalOtherCosts = 0;
                foreach (SearchOrderDetail sod in result)
                {
                    tblContent.addCell(PdfHelper.GetCellLeft(sod.Client.RealName));
                    tblContent.addCell(PdfHelper.GetCellRight(sod.TotalFetchCosts.ToString()));
                    tblContent.addCell(PdfHelper.GetCellRight(sod.TotalDisposalCosts.ToString()));
                    tblContent.addCell(PdfHelper.GetCellRight(sod.TotalMaterialCosts.ToString()));
                    tblContent.addCell(PdfHelper.GetCellRight(sod.TotalOtherCosts.ToString()));

                    totalFetchCosts += sod.TotalFetchCosts;
                    totalDisposalCosts += sod.TotalDisposalCosts;
                    totalMaterialCosts += sod.TotalMaterialCosts;
                    totalOtherCosts += sod.TotalOtherCosts;
                }

                tblContent.addCell(PdfHelper.GetCellLeft(""));
                tblContent.addCell(PdfHelper.GetCellLeft(""));
                tblContent.addCell(PdfHelper.GetCellLeft(""));
                tblContent.addCell(PdfHelper.GetCellLeft(""));
                tblContent.addCell(PdfHelper.GetCellLeft(""));

                tblContent.addCell(PdfHelper.GetFooterCellLeft("总计："));
                tblContent.addCell(PdfHelper.GetFooterCellRight(totalFetchCosts.ToString()));
                tblContent.addCell(PdfHelper.GetFooterCellRight(totalDisposalCosts.ToString()));
                tblContent.addCell(PdfHelper.GetFooterCellRight(totalMaterialCosts.ToString()));
                tblContent.addCell(PdfHelper.GetFooterCellRight(totalOtherCosts.ToString()));

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
            Response.Write("<tr style='font-size:16px;font-weight:bold;height:35px;'><td align='center' valign='middle' colspan='5'>取件费汇总表</td></tr>");
            Response.Write("<tr style='font-weight:bold;'><td align='left' colspan='5'>&nbsp;" + titleContent + "</td></tr>");
            Response.Write("<tr style='font-weight:bold;'><td align='left'>&nbsp;客户姓名</td><td align='right'>&nbsp;取件费</td><td align='right'>&nbsp;处理费</td><td align='right'>&nbsp;材料费</td><td align='right'>&nbsp;其它费</td></tr>");

            decimal totalFetchCosts = 0;
            decimal totalDisposalCosts = 0;
            decimal totalMaterialCosts = 0;
            decimal totalOtherCosts = 0;
            foreach (SearchOrderDetail sod in result)
            {
                Response.Write("<tr>");
                Response.Write("<td align='left'>&nbsp;" + sod.Client.RealName + "</td>");
                Response.Write("<td align='right'>" + sod.TotalFetchCosts.ToString() + "</td>");
                Response.Write("<td align='right'>" + sod.TotalDisposalCosts.ToString() + "</td>");
                Response.Write("<td align='right'>" + sod.TotalMaterialCosts.ToString() + "</td>");
                Response.Write("<td align='right'>" + sod.TotalOtherCosts.ToString() + "</td>");
                Response.Write("</tr>");

                totalFetchCosts += sod.TotalFetchCosts;
                totalDisposalCosts += sod.TotalDisposalCosts;
                totalMaterialCosts += sod.TotalMaterialCosts;
                totalOtherCosts += sod.TotalOtherCosts;
            }

            Response.Write("<tr style='font-weight:bold;'><td align='left'>&nbsp;合计：</td><td align='right'>" + totalFetchCosts.ToString() + "</td><td align='right'>" + totalDisposalCosts.ToString() + "</td><td align='right'>" + totalMaterialCosts.ToString() + "</td><td align='right'>" + totalOtherCosts.ToString() + "</td></tr>");
            Response.Write("</table>");
            Response.Flush();
            Response.End();
        }
    }
    
}
