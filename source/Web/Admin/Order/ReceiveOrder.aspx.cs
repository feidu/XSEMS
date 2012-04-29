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
using Backend.Models;
using Backend.BAL;
using Backend.Utilities;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Backend.Authorization;

public partial class Admin_Order_ReceiveOrder : System.Web.UI.Page
{
    protected int id = 0;
    protected Order order = null;
    User user = null;
    protected List<OrderDetail> result = null;
    protected int orderDetailCount = 0;
    private static readonly int REMARK_LENGTH = 500;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            order = OrderOperation.GetOrderById(id);
            result = OrderDetailOperation.GetOrderDetailByOrderId(id);
            orderDetailCount = result.Count;
        }
        if (!IsPostBack)
        {
            FormDataBind();
        }
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        user = UserOperation.GetUserByUsername(cookie.Username);
    }

    private void FormDataBind()
    {      
        txtRemark.Text = order.Remark;
        txtCosts.Value = order.Costs.ToString();
        lblClientName.Text = order.Client.RealName;
        lblEncode.Text = order.Encode;
        lblCreateTime.Text = order.CreateTime.ToString();        
        if (order.Reason != null && order.Reason.Trim().Length > 0)
        {
            trReturnReason.Visible = true;
            lblReason.Text = order.Reason;
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        OrderOperation.DeleteOrderById(id);
        Response.Write("<script language='javascript' type='text/javascript'>alert('删除成功！');location.href='Default.aspx';</script>");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        DateTime receiveDate = new DateTime(1999, 1, 1);       
        string remark = Request.Form[txtRemark.ID].Trim();
        if (!string.IsNullOrEmpty(remark) && Validator.IsMatchLessThanChineseCharacter(remark, REMARK_LENGTH))
        {
            lblMsg.Text = "备注长度不能超过" + REMARK_LENGTH + "个字符！";
            return;
        }
        order.Remark = remark;
        if (order.CreateUser == null)
        {
            order.UserId = user.Id;
            order.CreateUser = user;
        }
        //order.ReceiveType = slReceiveType.Value;
        //order.ReceiveDate = receiveDate;
        //order.ReceiveUserId = int.Parse(ddlCompanyUsers.SelectedItem.Value);
        OrderOperation.UpdateOrder(order);
        lblMsg.Text = "修改成功！";
        FormDataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DateTime receiveDate = new DateTime(1999, 1, 1);
            
        OrderOperation.UpdateOrder(order);
        order.Status = OrderStatus.WAIT_AUDIT;
        order.Reason = "";
        OrderOperation.UpdateOrderReason(order);
        OrderOperation.UpdateOrderStatus(order);

        Response.Write("<script language='javascript' type='text/javascript'>alert('提交成功！');location.href='AuditOrderList.aspx';</script>");
    }
    protected void btnPrintPost_Click(object sender, EventArgs e)
    {
        DateTime receiveDate = new DateTime(1999, 1, 1);
        
             string fileName = StringHelper.GetEncodeNumber("HYD");
        string filePath = Server.MapPath("../../Config/");

        string[] fileArray = Directory.GetFiles(filePath, "*.pdf");
        foreach (string file in fileArray)
        {
            File.Delete(file);
        }
        Document document = new Document(PageSize.A4, 15, 15, 10, 10);

        try
        {
            Company company = CompanyOperation.GetCompanyById(user.CompanyId);

            PdfWriter.getInstance(document, new FileStream(filePath + fileName + ".pdf", FileMode.Create));
                      
            document.Header = PdfHelper.GetHeardFooter("亿度物流", company.Phone);

            document.Open();

            Paragraph phTitle = new Paragraph(new Chunk("货运单", PdfHelper.fontTitle));
            phTitle.Alignment = Element.ALIGN_CENTER;

            document.Add(phTitle);


            iTextSharp.text.Table tblTitle = new iTextSharp.text.Table(4);
            tblTitle.setWidths(new int[] { 15, 35, 15, 35 });
            tblTitle.WidthPercentage = 99;
            tblTitle.Border = 0;
            tblTitle.Cellpadding = 1;
            tblTitle.Cellspacing = 1;

            tblTitle.addCell(PdfHelper.GetCellRight("收件单号："));
            tblTitle.addCell(PdfHelper.GetCellLeft(" " + order.Encode));
            tblTitle.addCell(PdfHelper.GetCellRight("收件日期："));
            tblTitle.addCell(PdfHelper.GetCellLeft(" " + order.ReceiveDate.ToShortDateString()));
            tblTitle.addCell(PdfHelper.GetCellRight("收件方式："));
            tblTitle.addCell(PdfHelper.GetCellLeft(" " + order.ReceiveType));
            tblTitle.addCell(PdfHelper.GetCellRight("收件网点："));
            tblTitle.addCell(PdfHelper.GetCellLeft(" " + order.CompanyName));
            tblTitle.addCell(PdfHelper.GetCellRight("客户姓名："));
            tblTitle.addCell(PdfHelper.GetCellLeft(" " + order.Client.RealName));
            tblTitle.addCell(PdfHelper.GetCellRight("业 务 员："));
            tblTitle.addCell(PdfHelper.GetCellLeft(" " + UserOperation.GetUserById(order.UserId).RealName));
            tblTitle.addCell(PdfHelper.GetCellRight("备    注："));

            Cell bzCellValue = new Cell(new Paragraph(" " + order.Remark, PdfHelper.fontContent));
            bzCellValue.Colspan = 3;
            bzCellValue.HorizontalAlignment = Element.ALIGN_LEFT;
            bzCellValue.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblTitle.addCell(bzCellValue);

            document.Add(tblTitle);

            iTextSharp.text.Table tblDetail = new iTextSharp.text.Table(10);
            tblDetail.setWidths(new int[] { 9, 8, 11, 9, 9, 9, 9, 9, 15, 12 });
            tblDetail.WidthPercentage = 99;
            tblDetail.Border = 0;
            tblDetail.Cellpadding = 1;
            tblDetail.Cellspacing = 1;
            tblDetail.addCell(PdfHelper.GetCellLeft("承运商"));
            tblDetail.addCell(PdfHelper.GetCellLeft("数量"));
            tblDetail.addCell(PdfHelper.GetCellLeft("包裹重量"));
            tblDetail.addCell(PdfHelper.GetCellLeft("挂号费"));
            tblDetail.addCell(PdfHelper.GetCellLeft("取件费"));
            tblDetail.addCell(PdfHelper.GetCellLeft("材料费"));
            tblDetail.addCell(PdfHelper.GetCellLeft("保价费"));
            tblDetail.addCell(PdfHelper.GetCellLeft("其它费"));
            tblDetail.addCell(PdfHelper.GetCellLeft("条形码"));
            tblDetail.addCell(PdfHelper.GetCellRight("应收合计"));

            foreach (OrderDetail od in result)
            {
                tblDetail.addCell(PdfHelper.GetCellLeft(" " + od.CarrierEncode));
                tblDetail.addCell(PdfHelper.GetCellLeft(" " + od.Count.ToString()));
                tblDetail.addCell(PdfHelper.GetCellLeft(" " + StringHelper.CurtNumber(od.Weight.ToString())));
                tblDetail.addCell(PdfHelper.GetCellLeft(" " + StringHelper.CurtNumber(od.RegisterCosts.ToString())));
                tblDetail.addCell(PdfHelper.GetCellLeft(" " + StringHelper.CurtNumber(od.FetchCosts.ToString())));
                tblDetail.addCell(PdfHelper.GetCellLeft(" " + StringHelper.CurtNumber(od.MaterialCosts.ToString())));
                tblDetail.addCell(PdfHelper.GetCellLeft(" " + StringHelper.CurtNumber(od.InsureCosts.ToString())));
                tblDetail.addCell(PdfHelper.GetCellLeft(" " + StringHelper.CurtNumber(od.OtherCosts.ToString())));
                tblDetail.addCell(PdfHelper.GetCellLeft(" " + od.BarCode));
                tblDetail.addCell(PdfHelper.GetCellRight(" " + StringHelper.CurtNumber(od.TotalCosts.ToString())));
            }


            document.Add(tblDetail);

            Paragraph phTotal = new Paragraph(new Chunk("总计：", PdfHelper.fontHeader));
            phTotal.Add(new Chunk(" " + order.Costs.ToString() + "元", PdfHelper.fontHeader));
            phTotal.Alignment = Element.ALIGN_RIGHT;
            document.Add(phTotal);
            
            document.Add(PdfHelper.phMaxSpace);
            Paragraph phTip1 = new Paragraph(new Chunk(" 请仔细核对货运单的内容，如有疑问及时与我们联系。", PdfHelper.fontContent));
            phTip1.Alignment = Element.ALIGN_LEFT;
            document.Add(phTip1);
            Paragraph phTip2 = new Paragraph(new Chunk(" 您的签名意味着您认可了货运单的内容并理解接收了我们的货运条款。", PdfHelper.fontContent));
            phTip2.Alignment = Element.ALIGN_LEFT;
            document.Add(phTip2);

            int spaceCount = 25;
            for (int i = 0; i < (spaceCount - result.Count); i++)
            {
                document.Add(PdfHelper.phMaxSpace);
            }

            Paragraph phFooter1 = new Paragraph(new Chunk(" 开 单：", PdfHelper.fontContent));
            phFooter1.Add(new Chunk(" " + order.CreateUser.RealName + "  ", PdfHelper.fontFooter));
            phFooter1.Add(new Chunk("      取件人：", PdfHelper.fontContent));
            phFooter1.Add(new Chunk("         ", PdfHelper.fontFooter));
            phFooter1.Add(new Chunk("      客 户：", PdfHelper.fontContent));
            phFooter1.Add(new Chunk("         ", PdfHelper.fontFooter));
            phFooter1.Alignment = Element.ALIGN_LEFT;
            document.Add(phFooter1);
            Paragraph phFooter2 = new Paragraph(new Chunk(" 审 核：", PdfHelper.fontContent));
            if (order.AuditUserId != 0)
            {
                phFooter2.Add(new Chunk(" " + UserOperation.GetUserById(order.AuditUserId).RealName + "   ", PdfHelper.fontFooter));
            }
            else
            {
                phFooter2.Add(new Chunk("         ", PdfHelper.fontFooter));
            }
            phFooter2.Add(new Chunk("      检 验： ", PdfHelper.fontContent));
            if (order.CheckUserId != 0)
            {
                phFooter2.Add(new Chunk(" " + UserOperation.GetUserById(order.CheckUserId).RealName + "   ", PdfHelper.fontFooter));
            }
            else
            {
                phFooter2.Add(new Chunk("         ", PdfHelper.fontFooter));
            }
            phFooter2.Add(new Chunk("      财 务：", PdfHelper.fontContent));
            phFooter2.Add(new Chunk("         ", PdfHelper.fontFooter));
            phFooter2.Add(new Chunk("      归 档：", PdfHelper.fontContent));
            phFooter2.Add(new Chunk("         ", PdfHelper.fontFooter));
            phFooter2.Alignment = Element.ALIGN_LEFT;
            document.Add(phFooter2);

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

    protected void btnDeleteDetail_Click(object sender, EventArgs e)
    {
        string ids = Request.Form["chkId"];
        if (string.IsNullOrEmpty(ids))
        {
            lblMsg.Text = "请选择！";
            FormDataBind();
            return;
        }
        OrderDetailOperation.DeleteOrderDetailByIds(ids);

        Response.Write("<script language='javascript'>location.href='ReceiveOrder.aspx?id=" + id + "';</script>");
    }
}
