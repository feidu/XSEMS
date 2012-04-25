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

public partial class Admin_CompanySetting_Account : System.Web.UI.Page
{
    private static readonly int CONST_ACCOUNT_NAME_LENGTH = 50;
    private static readonly int CONST_ACCOUNT_NUMBER_LENGTH = 50;
    private static readonly int CONST_BANK_NAME_LENGTH = 50;
    private static readonly int CONST_REMARK_LENGTH = 1000;
    ReceivableAccount ra = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            ra = ReceivableAccountOperation.GetReceivableAccountById(id);
        }
        if (!IsPostBack)
        {
            FormDataBind();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
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

        ra.AccountName = accounName;
        ra.AccountNumber = accountNumber;
        ra.BankName = bankName;
        ra.Remark = remark;
        ra.PaymentMethod = new PaymentMethod();
        ra.PaymentMethod.Id = int.Parse(ddlPaymentMethod.SelectedItem.Value);

        ReceivableAccountOperation.UpdateReceivableAccount(ra);
        lblMsg.Text = "修改成功！";

    }
    private void FormDataBind()
    {
        txtAccountName.Text = ra.AccountName;
        txtAccountNumber.Text = ra.AccountNumber;
        txtBankName.Text = ra.BankName;
        txtRemark.Text = ra.Remark;
        ddlPaymentMethod.SelectedValue = ra.PaymentMethod.Id.ToString();
    }
}
