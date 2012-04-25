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

public partial class Admin_PostSetting_CalculateTypeList : System.Web.UI.Page
{
    private static readonly int CONST_NAME_LENGTH = 50;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RpCalculateTypeDataBind();
        }
        tbCalculateTypeCreate.Visible = false;
        lbtnCreate.Visible = true;
        lblMsg.Text = "";
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rpCalculateType.Items.Count; i++)
        {
            RepeaterItem ri = rpCalculateType.Items[i];
            Label lblId = (Label)ri.FindControl("lblId");
            TextBox txtName = (TextBox)ri.FindControl("txtName");
            int id = int.Parse(lblId.Text);
            CalculateType ct = CalculateTypeOperation.GetCalculateTypeById(id);
            ct.Name = txtName.Text;
            CalculateTypeOperation.UpdateCalculateType(ct);
        }
        lblMsg.Text = "修改成功！";
    }

    private void RpCalculateTypeDataBind()
    {
        rpCalculateType.ItemDataBound += new RepeaterItemEventHandler(rpCalculateType_ItemDataBound);
        rpCalculateType.DataSource = CalculateTypeOperation.GetCalculateType();
        rpCalculateType.DataBind();
    }

    private void rpCalculateType_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        CalculateType ct = (CalculateType)e.Item.DataItem;
        Label lblId = (Label)e.Item.FindControl("lblId");
        TextBox txtName = (TextBox)e.Item.FindControl("txtName");
        lblId.Text = ct.Id.ToString();
        txtName.Text = ct.Name;
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string ids = Request.Form["chkId"];
        if (string.IsNullOrEmpty(ids))
        {
            lblMsg.Text = "请选择";
            return;
        }
        CalculateTypeOperation.DeleteCalculateTypeByIds(ids);
        lblMsg.Text = "删除成功！";
        RpCalculateTypeDataBind();
    }
    protected void lbtnCreate_Click(object sender, EventArgs e)
    {
        tbCalculateTypeCreate.Visible = true;
        lbtnCreate.Visible = false;
    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        string ctName = Request.Form[txtName.ID].Trim();

        if (string.IsNullOrEmpty(ctName) || Validator.IsMatchLessThanChineseCharacter(ctName, CONST_NAME_LENGTH))
        {
            lblMsg.Text = "结算方式名称不能为空，并且长度不能超过 " + CONST_NAME_LENGTH + " 个字符！";
            return;
        }

        CalculateType ct = new CalculateType();
        ct.Name = ctName;

        if (CalculateTypeOperation.CreateCalculateType(ct))
        {
            lblMsg.Text = "添加成功！";
        }
        else
        {
            lblMsg.Text = "此结算方式名称已经存在！";
            return;
        }
        RpCalculateTypeDataBind();
        tbCalculateTypeCreate.Visible = false;
        lbtnCreate.Visible = true;
    }
}
