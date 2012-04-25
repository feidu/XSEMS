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
using Backend.Models.Pagination;
using Backend.Authorization;

public partial class Admin_Client_ComplaintList : System.Web.UI.Page
{
    User user = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        user = UserOperation.GetUserByUsername(cookie.Username);
        RpComplaintDataBind(false);

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string ids = Request.Form["chkId"];
        if (string.IsNullOrEmpty(ids))
        {
            lblMsg.Text = "请选择！";
            return;
        }
        ComplaintOperation.DeleteComplaintByIds(ids);
        lblMsg.Text = "删除成功！";

        if (ddlReplyStatus.SelectedItem.Value != "0")
        {
            RpComplaintDataBind(bool.Parse(ddlReplyStatus.SelectedItem.Value));
        }
        else
        {
            PaginationQueryResult<Complaint> result = ComplaintOperation.GetComplaintByCompanyId(PaginationHelper.GetCurrentPaginationQueryCondition(Request), user.CompanyId);
            rpComplaint.DataSource = result.Results;
            rpComplaint.DataBind();

            pagi.TotalCount = result.TotalCount;
        }
    }

    private void RpComplaintDataBind(bool isReply)
    {
        PaginationQueryResult<Complaint> result = ComplaintOperation.GetComplaintByCompanyIdAndIsReply(PaginationHelper.GetCurrentPaginationQueryCondition(Request), user.CompanyId, isReply);
        rpComplaint.DataSource = result.Results;
        rpComplaint.DataBind();

        pagi.TotalCount = result.TotalCount;
    }

    protected void ddlReplyStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlReplyStatus.SelectedItem.Value != "0")
        {
            RpComplaintDataBind(bool.Parse(ddlReplyStatus.SelectedItem.Value));
        }
        else
        {
            PaginationQueryResult<Complaint> result = ComplaintOperation.GetComplaintByCompanyId(PaginationHelper.GetCurrentPaginationQueryCondition(Request), user.CompanyId);
            rpComplaint.DataSource = result.Results;
            rpComplaint.DataBind();

            pagi.TotalCount = result.TotalCount;
        }
    }
}
