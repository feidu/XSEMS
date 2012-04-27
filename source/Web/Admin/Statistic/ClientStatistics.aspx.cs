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

public partial class Admin_Statistic_ClientStatistics : System.Web.UI.Page
{
    private string companyId = "0";
    DateTime minTime = new DateTime(1999, 1, 1);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DdlCompanyDataBind();
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
    }

    protected void btnClientStatistic_Click(object sender, EventArgs e)
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

        string strUserId = "0";
        if (ddlCompany.SelectedItem.Value != "0")
        {
            strUserId = ddlCompanyUsers.SelectedItem.Value;
        }

        int userId = 0;
        if (!int.TryParse(strUserId, out userId))
        {
            userId = 0;
        }

        List<Client> result = ClientOperation.GetClientStatistic(startDate, endDate);


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

                Paragraph phTitle = new Paragraph(new Chunk("客户统计表", PdfHelper.fontTitle));
                phTitle.Alignment = Element.ALIGN_CENTER;



                Paragraph phTitle2 = new Paragraph(new Chunk(titleContent, PdfHelper.fontHeader));
                phTitle2.Alignment = Element.ALIGN_LEFT;

                document.Add(phTitle);
                document.Add(phTitle2);

                iTextSharp.text.Table tblContent = new iTextSharp.text.Table(8);
                tblContent.setWidths(new int[] { 13, 8, 13, 15, 15, 16, 10, 10 });
                tblContent.WidthPercentage = 99;
                tblContent.Border = 0;
                tblContent.Cellpadding = 1;
                tblContent.Cellspacing = 1;

                tblContent.addCell(PdfHelper.GetTitleCellLeft("客户姓名"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("编号"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("用户名"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("地区"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("手机"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("邮箱"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("余额"));
                tblContent.addCell(PdfHelper.GetTitleCellRight("信用额度"));

                foreach (Client client in result)
                {
                    tblContent.addCell(PdfHelper.GetCellLeft(client.RealName));
                    tblContent.addCell(PdfHelper.GetCellRight(client.Id.ToString()));
                    tblContent.addCell(PdfHelper.GetCellRight(client.Username));
                    tblContent.addCell(PdfHelper.GetCellRight(client.Province + " " + client.City));
                    tblContent.addCell(PdfHelper.GetCellRight(client.Mobile));
                    tblContent.addCell(PdfHelper.GetCellRight(client.Email));
                    tblContent.addCell(PdfHelper.GetCellRight(client.Balance.ToString()));
                    tblContent.addCell(PdfHelper.GetCellRight(client.Credit.ToString()));
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
            Response.Write("<tr style='font-size:16px;font-weight:bold;height:35px;'><td align='center' valign='middle' colspan='8'>客户统计表</td></tr>");
            Response.Write("<tr style='font-weight:bold;'><td align='left' colspan='8'>&nbsp;" + titleContent + "</td></tr>");
            Response.Write("<tr style='font-weight:bold;'><td align='left'>&nbsp;客户姓名</td><td align='left'>&nbsp;编号</td><td align='left'>&nbsp;用户名</td><td align='left'>&nbsp;地区</td><td align='left'>&nbsp;手机</td><td align='left'>&nbsp;邮箱</td><td align='right'>&nbsp;余额</td><td align='right'>&nbsp;信用额度</td></tr>");
                        
            foreach (Client client in result)
            {
                Response.Write("<tr>");
                Response.Write("<td align='left'>&nbsp;" + client.RealName + "</td>");
                Response.Write("<td align='left'>&nbsp;" + client.Id.ToString() + "</td>");
                Response.Write("<td align='left'>&nbsp;" + client.Username + "</td>");
                Response.Write("<td align='left'>&nbsp;" + client.Province + " " + client.City + "</td>");
                Response.Write("<td align='left'>&nbsp;" + client.Mobile + "</td>");
                Response.Write("<td align='left'>&nbsp;" + client.Email + "</td>");
                Response.Write("<td align='right'>" + client.Balance.ToString() + "</td>");
                Response.Write("<td align='right'>" + client.Credit.ToString() + "</td>");
                Response.Write("</tr>");
            }

            Response.Write("</table>");
            Response.Flush();
            Response.End();
        }
    }
}
