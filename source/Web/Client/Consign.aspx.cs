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

public partial class Client_Consign : System.Web.UI.Page
{
    protected Order order = null;
    protected List<OrderDetail> result = null;
    private static readonly int NOTE_ADDRESS_LENGTH = 200;
    private static readonly int CONTACT_WAY_LENGTH = 50;
    private static readonly int REMARK_LENGTH = 500;
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            order = OrderOperation.GetOrderById(id);
            result = OrderDetailOperation.GetOrderDetailByOrderId(id);
        }
        if (!IsPostBack)
        {
            FormDataBind();
        }
        lblMsg.Text = "";
    }

    private void FormDataBind()
    {
        txtCountry.Value = order.ToCountry;
        txtRemark.Text = order.Remark;
        txtToAddress.Value = order.ToAddress;
        txtToCity.Value = order.ToCity;
        txtToCountry.Value = order.ToCountry;
        hdCountry.Value = order.ToCountry;
        txtToEmail.Value = order.ToEmail;
        txtToPhone.Value = order.ToPhone;
        txtToPostcode.Value = order.ToPostcode;
        txtToUsername.Value = order.ToUsername;
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        OrderOperation.DeleteOrderById(order.Id);
        Response.Write("<script language='javascript' type='text/javascript'>alert('删除成功！');location.href='Default.aspx';</script>");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string countryName = Request.Form[hdCountry.ID].Trim();
        if (string.IsNullOrEmpty(countryName))
        {
            lblMsg.Text = "收件人国家不能为空！";
            return;
        }
        if (CountryOperation.GetCountryByEnglishName(countryName) == null)
        {
            lblMsg.Text = "国家名称不存在！";
            return;
        }
        string toUsername = Request.Form[txtToUsername.ID].Trim();
        if (string.IsNullOrEmpty(toUsername) || Validator.IsMatchLessThanChineseCharacter(toUsername, CONTACT_WAY_LENGTH))
        {
            lblMsg.Text = "收件人姓名不能为空，且不能超过" + CONTACT_WAY_LENGTH + "个字符！";
            return;
        }
        string toPhone = Request.Form[txtToPhone.ID].Trim();
        if (!string.IsNullOrEmpty(toPhone) && Validator.IsMatchLessThanChineseCharacter(toPhone, CONTACT_WAY_LENGTH))
        {
            lblMsg.Text = "收件人电话不能超过" + CONTACT_WAY_LENGTH + "个字符！";
            return;
        }
        string toEmail = Request.Form[txtToEmail.ID].Trim();
        if (!string.IsNullOrEmpty(toEmail) && Validator.IsMatchLessThanChineseCharacter(toEmail, CONTACT_WAY_LENGTH))
        {
            lblMsg.Text = "收件人邮箱不能超过" + CONTACT_WAY_LENGTH + "个字符！";
            return;
        }
        string toCity = Request.Form[txtToCity.ID].Trim();
        if (!string.IsNullOrEmpty(toCity) && Validator.IsMatchLessThanChineseCharacter(toCity, CONTACT_WAY_LENGTH))
        {
            lblMsg.Text = "收件人城市不能超过" + CONTACT_WAY_LENGTH + "个字符！";
            return;
        }

        string toPostcode = Request.Form[txtToPostcode.ID].Trim();
        if (!string.IsNullOrEmpty(toPostcode) && Validator.IsMatchLessThanChineseCharacter(toPostcode, CONTACT_WAY_LENGTH))
        {
            lblMsg.Text = "收件人邮编不能超过" + CONTACT_WAY_LENGTH + "个字符！";
            return;
        }
        string toAddress = Request.Form[txtToAddress.ID].Trim();
        if (!string.IsNullOrEmpty(toAddress) && Validator.IsMatchLessThanChineseCharacter(toAddress, NOTE_ADDRESS_LENGTH))
        {
            lblMsg.Text = "收件人详址不能超过" + NOTE_ADDRESS_LENGTH + "个字符！";
            return;
        }
        string remark = Request.Form[txtRemark.ID].Trim();
        if (!string.IsNullOrEmpty(remark) && Validator.IsMatchLessThanChineseCharacter(remark, REMARK_LENGTH))
        {
            lblMsg.Text = "备注长度不能超过" + REMARK_LENGTH + "个字符！";
            return;
        }

        order.Remark = remark;
        order.ToAddress = toAddress;
        order.ToCity = toCity;
        order.ToCountry = countryName;
        order.ToEmail = toEmail;
        order.ToPhone = toPhone;
        order.ToPostcode = toPostcode;
        order.ToUsername = toUsername;
        OrderOperation.UpdateClientOrder(order);
        lblMsg.Text = "修改成功！";
        FormDataBind();
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

        Response.Write("<script language='javascript'>location.href='Consign.aspx?id=" + order.Id + "';</script>");
    }
}
