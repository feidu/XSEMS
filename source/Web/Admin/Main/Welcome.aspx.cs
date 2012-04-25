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
using System.Text;
using Backend.Models;
using Backend.Models.Pagination;
using Backend.BAL;
using Backend.Authorization;
using Backend.Models.Admin;
using Backend.Utilities;

public partial class Admin_Main_Welcome : System.Web.UI.Page
{
    protected string username = null;    

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        User user = UserOperation.GetUserByUsername(cookie.Username);
        username = user.RealName;
        if (!IsPostBack)
        {
            PaginationQueryResult<News> result = NewsOperation.GetNewsByCategoryId(PaginationHelper.GetCurrentPaginationQueryCondition(Request), 8);
            rpAnnouncement.DataSource = result.Results;
            rpAnnouncement.DataBind();
        }
    }
}