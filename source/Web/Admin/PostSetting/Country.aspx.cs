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

public partial class Admin_PostSetting_Country : System.Web.UI.Page
{
    private const int CONST_EN_NAME_LENGTH = 50;
    private const int CONST_CN_NAME_LENGTH = 50;
    private const int CONST_CODE_LENGTH = 50;

    Country country = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            country = CountryOperation.GetCountryById(id);
        }
        if (!IsPostBack)
        {
            FormDataBind();
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string englishName = Request.Form[txtEnglishName.ID].Trim();
        string chineseName = Request.Form[txtChineseName.ID].Trim();
        string code = Request.Form[txtCode.ID].Trim();
        byte continent = byte.Parse(slContinent.Value);

        if (string.IsNullOrEmpty(englishName) || Validator.IsMatchLessThanChineseCharacter(englishName, CONST_EN_NAME_LENGTH))
        {
            lblMsg.Text = "英文名不能为空，并且长度不能超过 " + CONST_EN_NAME_LENGTH + " 个字符！";
            return;
        }
        if (string.IsNullOrEmpty(chineseName) || Validator.IsMatchLessThanChineseCharacter(chineseName, CONST_CN_NAME_LENGTH))
        {
            lblMsg.Text = "中文名不能为空，并且长度不能超过 " + CONST_CN_NAME_LENGTH + " 个字符！";
            return;
        }
        if (string.IsNullOrEmpty(code) || Validator.IsMatchLessThanChineseCharacter(code, CONST_CODE_LENGTH))
        {
            lblMsg.Text = "国家代码不能为空，并且长度不能超过 " + CONST_CODE_LENGTH + " 个字符！";
            return;
        }

        country.EnglishName = englishName;
        country.ChineseName = chineseName;
        country.Code = code;
        country.Continent = continent;
        country.IsFront = chkIsFront.Checked;

        CountryOperation.UpdateCountry(country);

        lblMsg.Text = "修改成功！";
    }

    private void FormDataBind()
    {
        txtChineseName.Text = country.ChineseName;
        txtCode.Text = country.Code;
        txtEnglishName.Text = country.EnglishName;
        slContinent.Value = country.Continent.ToString();
        chkIsFront.Checked = country.IsFront;
    }
}
