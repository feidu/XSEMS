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

public partial class Admin_PostSetting_CostTypeList : System.Web.UI.Page
{
    private static readonly int CONST_NAME_LENGTH = 50;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RpCostTypeDataBind();
        }
        tbCostTypeCreate.Visible = false;
        lbtnCreate.Visible = true;
        lblMsg.Text = "";
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rpCostType.Items.Count; i++)
        {
            RepeaterItem ri = rpCostType.Items[i];
            Label lblId = (Label)ri.FindControl("lblId");
            TextBox txtName = (TextBox)ri.FindControl("txtName");
            CheckBox chkManageCosts = (CheckBox)ri.FindControl("chkManageCosts");
            CheckBox chkSalorCosts = (CheckBox)ri.FindControl("chkSalorCosts");
            int id = int.Parse(lblId.Text);
            CostType ct = CostTypeOperation.GetCostTypeById(id);
            ct.Name = txtName.Text;
            ct.IsManageCosts = chkManageCosts.Checked;
            ct.IsSalorCosts = chkSalorCosts.Checked;
            CostTypeOperation.UpdateCostType(ct);
        }
        lblMsg.Text = "修改成功！";
    }

    private void RpCostTypeDataBind()
    {
        rpCostType.ItemDataBound += new RepeaterItemEventHandler(rpCostType_ItemDataBound);
        rpCostType.DataSource = CostTypeOperation.GetCostType();
        rpCostType.DataBind();
    }

    private void rpCostType_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        CostType ct = (CostType)e.Item.DataItem;
        Label lblId = (Label)e.Item.FindControl("lblId");
        TextBox txtName = (TextBox)e.Item.FindControl("txtName");
        CheckBox chkManageCosts = (CheckBox)e.Item.FindControl("chkManageCosts");
        CheckBox chkSalorCosts = (CheckBox)e.Item.FindControl("chkSalorCosts");
        lblId.Text = ct.Id.ToString();
        txtName.Text = ct.Name;
        chkManageCosts.Checked = ct.IsManageCosts;
        chkSalorCosts.Checked = ct.IsSalorCosts;
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string ids = Request.Form["chkId"];
        if (string.IsNullOrEmpty(ids))
        {
            lblMsg.Text = "请选择";
            return;
        }
        CostTypeOperation.DeleteCostTypeByIds(ids);
        lblMsg.Text = "删除成功！";
        RpCostTypeDataBind();
    }
    protected void lbtnCreate_Click(object sender, EventArgs e)
    {
        tbCostTypeCreate.Visible = true;
        lbtnCreate.Visible = false;
    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        string costName = Request.Form[txtName.ID].Trim();

        if (string.IsNullOrEmpty(costName) || Validator.IsMatchLessThanChineseCharacter(costName, CONST_NAME_LENGTH))
        {
            lblMsg.Text = "费用名称不能为空，并且长度不能超过 " + CONST_NAME_LENGTH + " 个字符！";
            return;
        }

        CostType ct = new CostType();
        ct.Name = costName;
        ct.IsManageCosts = chkManageCosts.Checked;
        ct.IsSalorCosts = chkSalorCosts.Checked;

        if (CostTypeOperation.CreateCostType(ct))
        {
            lblMsg.Text = "添加成功！";
        }
        else
        {
            lblMsg.Text = "此费用名称已经存在！";
            return;
        }
        RpCostTypeDataBind();
        tbCostTypeCreate.Visible = false;
        lbtnCreate.Visible = true;
    }
}
