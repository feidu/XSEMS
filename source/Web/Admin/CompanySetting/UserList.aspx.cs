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
using Backend.Models.Pagination;
using Backend.Utilities;
using Backend.Authorization;

public partial class Admin_CompanySetting_UserList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RpUserDataBind();
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string ids = Request.Form["chkId"];
        if (string.IsNullOrEmpty(ids))
        {
            lblMsg.Text = "请选择！";
            return;
        }
        UserOperation.DeleteUserByIds(ids);
        RpUserDataBind();
    }

    private void RpUserDataBind()
    {
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        User user = UserOperation.GetUserByUsername(cookie.Username);

        PaginationQueryResult<User> result = UserOperation.GetLightUserByCompanyId(PaginationHelper.GetCurrentPaginationQueryCondition(Request), user.CompanyId);
        rpUser.ItemDataBound += new RepeaterItemEventHandler(rpUser_ItemDataBound);
        rpUser.DataSource = result.Results;
        rpUser.DataBind();

        pagi.TotalCount = result.TotalCount;
    }

    private void rpUser_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        User user = (User)e.Item.DataItem;
        Label lblId = (Label)e.Item.FindControl("lblId");
        TextBox txtCommission = (TextBox)e.Item.FindControl("txtCommission");
        lblId.Text = user.Id.ToString();
        txtCommission.Text = StringHelper.CurtNumber(user.Commission.ToString());
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rpUser.Items.Count; i++)
        {
            RepeaterItem ri = rpUser.Items[i];
            Label lblId = (Label)ri.FindControl("lblId");
            TextBox txtCommission = (TextBox)ri.FindControl("txtCommission");
            int id = int.Parse(lblId.Text);
            User user = UserOperation.GetUserById(id);
            try
            {                
                user.Commission = decimal.Parse(txtCommission.Text);                
            }
            catch (Exception ex)
            {
                Response.Write("<script language='javascript' type='text/javascript'>alert('提成只能为数字！');</script>");
                return;
            }
            if (user.Commission < 0 || user.Commission > 1)
            {
                Response.Write("<script language='javascript' type='text/javascript'>alert('提成数字只能在0和1之间！');</script>");
                return;
            }
            UserOperation.UpdateUser(user);            
        }
        lblMsg.Text = "修改成功！";
        RpUserDataBind();
    }
}
