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
using Backend.Authorization;
using Backend.Models.Pagination;
using Backend.Utilities;

public partial class Client_ComplaintList : System.Web.UI.Page
{
    ClientSession clientSession = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        seo.Title = "投诉列表";
        clientSession = (ClientSession)AuthorizationManager.GetCurrentSessionObject(Context, false);
        RpComplaintDataBind(true);        
    }

    private void RpComplaintDataBind(bool isReply)
    {       
        PaginationQueryResult<Complaint> result = ComplaintOperation.GetComplaintByClientIdAndIsReply(PaginationHelper.GetCurrentPaginationQueryCondition(Request), clientSession.Id, isReply);
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
            PaginationQueryResult<Complaint> result = ComplaintOperation.GetComplaintByClientId(PaginationHelper.GetCurrentPaginationQueryCondition(Request), clientSession.Id);
            rpComplaint.DataSource = result.Results;
            rpComplaint.DataBind();

            pagi.TotalCount = result.TotalCount;
        }
    }
    protected void btnSerach_ServerClick(object sender, EventArgs e)
    {

    }
}
