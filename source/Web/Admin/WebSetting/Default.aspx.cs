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

public partial class Admin_WebSetting_Default : System.Web.UI.Page
{
    private Setting setting = null;

    private static readonly int TITLE_LENGTH = 200;
    private static readonly int ADDRESS_LENGTH = 200;
    private static readonly int DESCRIPTION_LENGTH = 500;
    private static readonly int EMAIL_LENGTH = 50;
    private static readonly int MSN_ACCOUNT_LENGTH = 50;
    private static readonly int KEYWORD_LENGTH = 500;
    private static readonly int PHONE_NUMBER_LENGTH = 100;
    private static readonly int POSTALCODE_LENGTH = 10;
    private static readonly int COPYRIGHT_LENGTH = 200;
    private static readonly int RECORD_LENGTH = 100;
    //private static readonly int ANNOUNCEMENT_LENGTH = 1000;
    private static readonly int FAX_NUMBER_LENGTH = 100;

    protected void Page_Load(object sender, EventArgs e)
    {
        setting = SettingOperation.LoadSetting();
        if (!IsPostBack)
            FormBindData();
    }

    private void FormBindData()
    {
        if (setting == null) return;
        tbxAddress.Text = setting.Address;
        //tbxAnnouncement.Text = setting.Announcement;
        tbxEmail.Text = setting.Email;
        tbxMSNAccount.Text = setting.Msn;
        tbxFaxNumber.Text = setting.Fax;
        tbxPhoneNuber.Text = setting.Phone;
        tbxPostalcode.Text = setting.Postalcode;
        tbxTitle.Text = setting.Title;
        tbxKeyword.Text = setting.Keyword;
        tbxDescription.Text = setting.Description;
        tbxRecord.Text = setting.Record;
        tbxCopyright.Text = setting.Copyright;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string title = Request.Form[tbxTitle.ID].Trim();
        string keyword = Request.Form[tbxKeyword.ID].Trim();
        string phoneNuber = Request.Form[tbxPhoneNuber.ID].Trim();
        string description = Request.Form[tbxDescription.ID].Trim();
        string faxNumber = Request.Form[tbxFaxNumber.ID].Trim();
        string email = Request.Form[tbxEmail.ID].Trim();
        string msnAccount = Request.Form[tbxMSNAccount.ID].Trim();
        string postalcode = Request.Form[tbxPostalcode.ID].Trim();
        string address = Request.Form[tbxAddress.ID].Trim();
        string copyright = Request.Form[tbxCopyright.ID].Trim();
        string record = Request.Form[tbxRecord.ID].Trim();
        //string announcement = Request.Form[tbxAnnouncement.ID].Trim();


        if (!string.IsNullOrEmpty(title) && Validator.IsMatchLessThanChineseCharacter(title, TITLE_LENGTH))
        {
            lblMsg.Text = "标题不能超过" + TITLE_LENGTH + "字符";
            return;
        }
        if (!string.IsNullOrEmpty(phoneNuber) && Validator.IsMatchLessThanChineseCharacter(phoneNuber, PHONE_NUMBER_LENGTH))
        {
            lblMsg.Text = "电话不能超过" + PHONE_NUMBER_LENGTH + "字符";
            return;
        }
        if (!string.IsNullOrEmpty(faxNumber) && Validator.IsMatchLessThanChineseCharacter(faxNumber, FAX_NUMBER_LENGTH))
        {
            lblMsg.Text = "传真不能超过" + FAX_NUMBER_LENGTH + "字符";
            return;
        }
        if (!string.IsNullOrEmpty(email) && Validator.IsMatchLessThanChineseCharacter(email, EMAIL_LENGTH))
        {
            lblMsg.Text = "邮箱不能超过" + EMAIL_LENGTH + "字符";
            return;
        }
        if (!string.IsNullOrEmpty(msnAccount) && Validator.IsMatchLessThanChineseCharacter(msnAccount, MSN_ACCOUNT_LENGTH))
        {
            lblMsg.Text = "MSN帐号不能超过" + EMAIL_LENGTH + "字符";
            return;
        }
        if (!string.IsNullOrEmpty(postalcode) && Validator.IsMatchLessThanChineseCharacter(postalcode, POSTALCODE_LENGTH))
        {
            lblMsg.Text = "邮编不能超过" + POSTALCODE_LENGTH + "字符";
            return;
        }
        if (!string.IsNullOrEmpty(copyright) && Validator.IsMatchLessThanChineseCharacter(copyright, COPYRIGHT_LENGTH))
        {
            lblMsg.Text = "版权信息不能超过" + COPYRIGHT_LENGTH + "字符";
            return;
        }
        if (!string.IsNullOrEmpty(record) && Validator.IsMatchLessThanChineseCharacter(record, RECORD_LENGTH))
        {
            lblMsg.Text = "备案信息不能超过" + RECORD_LENGTH + "字符";
            return;
        }
        if (!string.IsNullOrEmpty(address) && Validator.IsMatchLessThanChineseCharacter(address, ADDRESS_LENGTH))
        {
            lblMsg.Text = "地址不能超过" + ADDRESS_LENGTH + "字符";
            return;
        }
        if (!string.IsNullOrEmpty(keyword) && Validator.IsMatchLessThanChineseCharacter(keyword, KEYWORD_LENGTH))
        {
            lblMsg.Text = "关键字不能超过" + KEYWORD_LENGTH + "字符";
            return;
        }
        if (!string.IsNullOrEmpty(description) && Validator.IsMatchLessThanChineseCharacter(description, DESCRIPTION_LENGTH))
        {
            lblMsg.Text = "描述不能超过" + DESCRIPTION_LENGTH + "字符";
            return;
        }
        //if (!string.IsNullOrEmpty(announcement) && Validator.IsMatchLessThanChineseCharacter(announcement, ANNOUNCEMENT_LENGTH))
        //{
        //    lblMsg.Text = "公告不能超过" + ANNOUNCEMENT_LENGTH + "字符";
        //    return;
        //}

        setting.Address = address;
        //setting.Announcement = announcement;
        setting.Copyright = copyright;
        setting.Description = description;
        setting.Email = email;
        setting.Msn = msnAccount;
        setting.Fax = faxNumber;
        setting.Keyword = keyword;
        setting.Phone = phoneNuber;
        setting.Postalcode = postalcode;
        setting.Record = record;
        setting.Title = title;

        if (setting.Id == 0)
        {
            SettingOperation.CreateSetting(setting);
        }
        else
        {
            SettingOperation.UpdateSetting(setting);
        }
        lblMsg.Text = "修改成功！";
        CacheHelper.ClearCache();
    }
}
