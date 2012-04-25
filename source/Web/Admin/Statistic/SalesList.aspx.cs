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

public partial class Admin_Statistic_SalesList : System.Web.UI.Page
{
    private string companyId = "0";
    DateTime minTime = new DateTime(1999, 1, 1);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DdlCompanyDataBind();
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

    protected void btnSalesReport_Click(object sender, EventArgs e)
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

        int companyId = 0;
        if (!int.TryParse(strCompanyId, out companyId))
        {
            companyId = 0;
        }

        List<UserSales> result = StatisticOperation.GetUserSalesStatistic(startDate, endDate, companyId, 0);


        string fileName = StringHelper.GetEncodeNumber("XS");
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

                Paragraph phTitle = new Paragraph(new Chunk("销售排行榜", PdfHelper.fontTitle));
                phTitle.Alignment = Element.ALIGN_CENTER;

                Paragraph phTitle2 = new Paragraph(new Chunk(titleContent, PdfHelper.fontHeader));
                phTitle2.Alignment = Element.ALIGN_LEFT;

                document.Add(phTitle);
                document.Add(phTitle2);

                iTextSharp.text.Table tblContent = new iTextSharp.text.Table(2);
                tblContent.setWidths(new int[] { 50, 50 });
                tblContent.WidthPercentage = 99;
                tblContent.Border = 0;
                tblContent.Cellpadding = 1;
                tblContent.Cellspacing = 1;

                tblContent.addCell(PdfHelper.GetTitleCellLeft("员工姓名"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("销售金额"));

                foreach (UserSales us in result)
                {
                    tblContent.addCell(PdfHelper.GetCellLeft(us.User.RealName));
                    tblContent.addCell(PdfHelper.GetCellRight(us.Money.ToString()));
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
            Response.ContentEncoding = System.Text.Encoding.Default;
            Response.ContentType = "application/vnd.ms-excel";

            Response.Write("<table border='1' style='font-size:14px;'>");
            Response.Write("<tr style='font-size:16px;font-weight:bold;height:35px;'><td align='center' valign='middle' colspan='2'>销售排行榜</td></tr>");
            Response.Write("<tr style='font-weight:bold;'><td align='left' colspan='2'>&nbsp;" + titleContent + "</td></tr>");
            Response.Write("<tr style='font-weight:bold;'><td align='left'>&nbsp;员工姓名</td><td align='right'>&nbsp;销售金额</td></tr>");

            foreach (UserSales us in result)
            {
                Response.Write("<tr>");
                Response.Write("<td align='left'>&nbsp;" + us.User.RealName + "</td>");
                Response.Write("<td align='right'>" + us.Money.ToString() + "</td>");
                Response.Write("</tr>");
            }

            Response.Write("</table>");
            Response.Flush();
            Response.End();
        }
    }
}
