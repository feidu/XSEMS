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

public partial class Admin_User_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RpUserDataBind();
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
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context,true);
        User user = UserOperation.GetUserByUsername(cookie.Username);

        PaginationQueryResult<User> result = UserOperation.GetLightUserByCompanyId(PaginationHelper.GetCurrentPaginationQueryCondition(Request), user.CompanyId);
        rpUser.DataSource=result.Results;
        rpUser.DataBind();

        pagi.TotalCount = result.TotalCount;
    }
}
