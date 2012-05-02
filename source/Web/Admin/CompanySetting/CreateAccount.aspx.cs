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
using Backend.Authorization;

public partial class Admin_CompanySetting_CreateAccount : System.Web.UI.Page
{
    private static readonly int CONST_ACCOUNT_NAME_LENGTH = 50;
    private static readonly int CONST_ACCOUNT_NUMBER_LENGTH = 50;
    private static readonly int CONST_BANK_NAME_LENGTH = 50;
    private static readonly int CONST_REMARK_LENGTH = 1000;
    User user = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        user = UserOperation.GetUserByUsername(cookie.Username);
    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        string accounName = Request.Form[txtAccountName.ID].Trim();
        string accountNumber = Request.Form[txtAccountNumber.ID].Trim();
        string bankName = Request.Form[txtBankName.ID].Trim();
        string remark = Request.Form[txtRemark.ID].Trim();

        if (string.IsNullOrEmpty(accounName) || Validator.IsMatchLessThanChineseCharacter(accounName, CONST_ACCOUNT_NAME_LENGTH))
        {
            lblMsg.Text = "账户名不能为空，并且长度不能超过 " + CONST_ACCOUNT_NAME_LENGTH + " 个字符！";
            return;
        }
        if (string.IsNullOrEmpty(accountNumber) || Validator.IsMatchLessThanChineseCharacter(accountNumber, CONST_ACCOUNT_NUMBER_LENGTH))
        {
            lblMsg.Text = "账号不能为空，并且长度不能超过 " + CONST_ACCOUNT_NUMBER_LENGTH + " 个字符！";
            return;
        }
        if (string.IsNullOrEmpty(bankName) || Validator.IsMatchLessThanChineseCharacter(bankName, CONST_BANK_NAME_LENGTH))
        {
            lblMsg.Text = "开户银行名称不能为空，并且长度不能超过 " + CONST_BANK_NAME_LENGTH + " 个字符！";
            return;
        }
        if (!string.IsNullOrEmpty(remark) && Validator.IsMatchLessThanChineseCharacter(remark, CONST_REMARK_LENGTH))
        {
            lblMsg.Text = "备注长度不能超过 " + CONST_REMARK_LENGTH + " 个字符！";
            return;
        }
        ReceivableAccount ra = new ReceivableAccount();
        ra.AccountName = accounName;
        ra.AccountNumber = accountNumber;
        ra.BankName = bankName;
        ra.Remark = remark;
        if (ReceivableAccountOperation.CreateReceivableAccount(ra))
        {
            lblMsg.Text = "添加成功！";
        }
        else
        {
            lblMsg.Text = "该账号已经存在！";
            return;
        }
    }
}