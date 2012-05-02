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
using Backend.Authorization;
using Backend.Models;
using Backend.Utilities;
using Backend.Models.Pagination;
using Backend.BAL;

public partial class Admin_Order_Default : System.Web.UI.Page
{
    User user = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        RpOrderDataBind();
    }

    private void RpOrderDataBind()
    {
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        user = UserOperation.GetUserByUsername(cookie.Username);
        PaginationQueryResult<Order> result = OrderOperation.GetOrderByStatus(PaginationHelper.GetCurrentPaginationQueryCondition(Request), OrderStatus.WAIT_AUDIT);
        rpOrder.DataSource = result.Results;
        rpOrder.DataBind();

        pagi.TotalCount = result.TotalCount;
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string ids = Request.Form["chkId"];
        if (string.IsNullOrEmpty(ids))
        {
            lblMsg.Text = "请选择！";
            return;
        }
        OrderOperation.DeleteOrderByIds(ids);
        lblMsg.Text = "删除成功！";

        RpOrderDataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string sDate = Request.Form[txtStartDate.ID].Trim();
        string eDate = Request.Form[txtEndDate.ID].Trim();
        string encode = Request.Form[txtEncode.ID].Trim();
        if (!string.IsNullOrEmpty(encode))
        {            
            PaginationQueryResult<Order> result = OrderOperation.GetOrderByStatusAndEncode(PaginationHelper.GetCurrentPaginationQueryCondition(Request),  OrderStatus.WAIT_AUDIT, encode);
            rpOrder.DataSource = result.Results;
            rpOrder.DataBind();            
        }
        else if (string.IsNullOrEmpty(sDate) && string.IsNullOrEmpty(eDate))
        {
            return;
        }
        else
        {
            DateTime startDate = new DateTime(1999, 1, 1);
            DateTime endDate = new DateTime(1999, 1, 1);
            if (!DateTime.TryParse(sDate, out startDate))
            {
                startDate = new DateTime(1999, 1, 1);
            }
            if (DateTime.TryParse(eDate, out endDate))
            {
                endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59);
            }
            else
            {
                endDate = new DateTime(1999, 1, 1);
            }
            PaginationQueryResult<Order> result = OrderOperation.GetOrderByStatusAndDate(PaginationHelper.GetCurrentPaginationQueryCondition(Request), OrderStatus.WAIT_AUDIT, startDate, endDate);
            rpOrder.DataSource = result.Results;
            rpOrder.DataBind();

            pagi.TotalCount = result.TotalCount;    
        } 
    }
}
