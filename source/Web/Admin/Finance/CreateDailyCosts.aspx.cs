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
using Backend.BAL;
using Backend.Authorization;
using Backend.Models;
using Backend.Utilities;

public partial class Admin_Finance_CreateDailyCosts : System.Web.UI.Page
{
    private static readonly int REMARK_LENGTH = 500;
    User user = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        user = UserOperation.GetUserByUsername(cookie.Username);
        if (!IsPostBack)
        {
            ddlCompanyUsers.DataSource = UserOperation.GetLightUserByCompanyId(user.CompanyId);
            ddlCompanyUsers.DataTextField = "RealName";
            ddlCompanyUsers.DataValueField = "Id";
            ddlCompanyUsers.DataBind();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string strOrderTime = Request.Form[txtOrderTime.ID];
        string remark = Request.Form[txtRemark.ID].Trim();
        string strMoney = Request.Form[txtMoney.ID].Trim();

        DateTime orderTime=new DateTime(1999,1,1);
        if (string.IsNullOrEmpty(strOrderTime) || !DateTime.TryParse(strOrderTime, out orderTime))
        {
            lblMsg.Text = "费用产生时间不能为空，且只能为时间格式！";
            return;
        }
        if (string.IsNullOrEmpty(remark) || Validator.IsMatchLessThanChineseCharacter(remark, REMARK_LENGTH))
        {
            lblMsg.Text = "摘要不能为空，且长度不能超过" + REMARK_LENGTH + "个字符！";
            return;
        }
        decimal money = 0;
        if (string.IsNullOrEmpty(strMoney) || !decimal.TryParse(strMoney, out money))
        {
            lblMsg.Text = "金额不能为空，且只能为数字！";
            return;
        }
        DailyCost dc = new DailyCost();
        dc.CostTypeId = int.Parse(ddlCostsType.SelectedItem.Value);
        dc.CompanyId = user.CompanyId;
        dc.CreateTime = DateTime.Now;
        dc.OrderTime = orderTime;
        dc.Encode = StringHelper.GetEncodeNumber("FY");
        dc.OrderUserId = int.Parse(ddlCompanyUsers.SelectedItem.Value);
        dc.Remark = remark;
        dc.Status = DailyCostStatus.WAIT_AUDIT;
        dc.UserId = user.Id;
        dc.Money = money;
        DailyCostOperation.CreateDailyCost(dc);
        lblMsg.Text = "添加成功！";

    }
}
