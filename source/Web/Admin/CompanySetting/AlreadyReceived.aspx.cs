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
using Backend.Models.Pagination;
using Backend.Utilities;
using Backend.BAL;
using Backend.Authorization;
using System.Collections.Generic;

public partial class Admin_CompanySetting_AlreadyReceived : System.Web.UI.Page
{
    User user = null;
    int rechargeId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        user = UserOperation.GetUserByUsername(cookie.Username);
        
        if (int.TryParse(Request.QueryString["id"], out rechargeId))
        {
            CancelRecharge();
        }
        RpAlreadyReceivedDataBind();
    }

    private void RpAlreadyReceivedDataBind()
    {
        PaginationQueryResult<Recharge> result = RechargeOperation.GetRecharge(PaginationHelper.GetCurrentPaginationQueryCondition(Request));
        rpAlreadyReceived.DataSource = result.Results;
        rpAlreadyReceived.DataBind();

        pagi.TotalCount = result.TotalCount;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string sDate = Request.Form[txtStartDate.ID].Trim();
        string eDate = Request.Form[txtEndDate.ID].Trim();

        if (string.IsNullOrEmpty(sDate) && string.IsNullOrEmpty(eDate))
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
            PaginationQueryResult<Recharge> result = RechargeOperation.GetRechargeByDate(PaginationHelper.GetCurrentPaginationQueryCondition(Request), startDate, endDate);
            rpAlreadyReceived.DataSource = result.Results;
            rpAlreadyReceived.DataBind();

            pagi.TotalCount = result.TotalCount;
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
        RechargeOperation.DeleteRechargeByIds(ids);
        lblMsg.Text = "删除成功！";

        RpAlreadyReceivedDataBind();
    }

    private void CancelRecharge()
    {
        Recharge recharge = RechargeOperation.GetRechargeById(rechargeId);
        
        List<ReceivedDeducted> result = ShouldReceiveOperation.GetReceivedDeductedByRechargeEncode(recharge.Encode);
        foreach (ReceivedDeducted rd in result)
        {
            ShouldReceiveOperation.DeleteReceivedDeductedById(rd.Id);//删除此收款核销
            ShouldReceive sr = ShouldReceiveOperation.GetShouldReceiveByEncode(rd.SrEncode);//得到此核销对应的应收款
            ShouldReceive srd =ShouldReceiveOperation.GetShouldReceivedByEncode(rd.SrEncode);//得到此核销对应的已收款
            decimal srdMoney = 0;
            if (srd != null)
            {
                srdMoney = srd.Money;                
            }
            if (sr != null)
            {
                sr.Money = sr.Money + rd.Money;
                ShouldReceiveOperation.UpdateShouldReceive(sr);
                ShouldReceiveOperation.DeleteShouldReceiveById(srd.Id);
            }
            else
            {
                srd.Status = false;
                ShouldReceiveOperation.UpdateShouldReceive(srd);
            }
        }        
        RechargeOperation.DeleteRechargeById(rechargeId);//删除此次充值，更新客户余额
        Response.Write("<script language='javascript' type='text/javascript'>alert('操作成功！');location.href='AlreadyReceived.aspx';</script>");
    }
}