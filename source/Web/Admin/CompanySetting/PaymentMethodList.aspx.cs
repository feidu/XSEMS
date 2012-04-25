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

public partial class Admin_CompanySetting_PaymentMethodList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RpPaymentMethodDataBind();
        }
        tbPaymentMethodCreate.Visible = false;
        lbtnCreate.Visible = true;
        lblMsg.Text = "";
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rpPaymentMethod.Items.Count; i++)
        {
            RepeaterItem ri = rpPaymentMethod.Items[i];
            Label lblId = (Label)ri.FindControl("lblId");
            TextBox txtName = (TextBox)ri.FindControl("txtName");
            int id = int.Parse(lblId.Text);
            PaymentMethod pm = PaymentMethodOperation.GetPaymentMethodById(id);
            pm.Name = txtName.Text;
            PaymentMethodOperation.UpdatePaymentMethod(pm);
        }
        lblMsg.Text = "修改成功！";
    }

    private void RpPaymentMethodDataBind()
    {
        rpPaymentMethod.ItemDataBound += new RepeaterItemEventHandler(rpPaymentMethod_ItemDataBound);
        rpPaymentMethod.DataSource = PaymentMethodOperation.GetPaymentMethod();
        rpPaymentMethod.DataBind();
    }

    private void rpPaymentMethod_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        PaymentMethod pm = (PaymentMethod)e.Item.DataItem;
        Label lblId = (Label)e.Item.FindControl("lblId");
        TextBox txtName = (TextBox)e.Item.FindControl("txtName");
        lblId.Text = pm.Id.ToString();
        txtName.Text = pm.Name;
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string ids = Request.Form["chkId"];
        if (string.IsNullOrEmpty(ids))
        {
            lblMsg.Text = "请选择！";
            return;
        }
        PaymentMethodOperation.DeletePaymentMethodByIds(ids);
        lblMsg.Text = "删除成功！";
        RpPaymentMethodDataBind();
    }
    protected void lbtnCreate_Click(object sender, EventArgs e)
    {
        tbPaymentMethodCreate.Visible = true;
        lbtnCreate.Visible = false;
    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        string name = Request.Form[txtName.ID].Trim();
        if (string.IsNullOrEmpty(name) || Validator.IsMatchLessThanChineseCharacter(name, 50))
        {
            lblMsg.Text = "付款方式名称不能为空，且长度不能超过50个字符！";
            return;
        }
        PaymentMethod pm = new PaymentMethod();
        pm.Name = name;
        if (PaymentMethodOperation.CreatePaymentMethod(pm))
        {
            lblMsg.Text = "添加成功！";
        }
        else
        {
            lblMsg.Text = "此名称已经存在！";
            return;
        }
        RpPaymentMethodDataBind();
        tbPaymentMethodCreate.Visible = false;
        lbtnCreate.Visible = true;
    }
}
