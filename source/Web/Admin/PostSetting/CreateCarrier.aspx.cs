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

public partial class Admin_PostSetting_CreateCarrier : System.Web.UI.Page
{
    private const int CONST_NAME_LENGTH = 50;
    private const int CONST_EMAIL_LENGTH = 50;
    private const int CONST_CONTACT_PERSON_LENGTH = 20;
    private const int CONST_PHONE_LENGTH = 20;
    private const int CONST_FAX_LENGTH = 20;
    private const int CONST_ADDRESS_LENGTH = 200;
    private const int CONST_TRANSPROT_TIME_LENGTH = 50;
    private const int CONST_REMARK_LENGTH = 1000;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        string encode = Request.Form[txtEncode.ID].Trim();
        string name = Request.Form[txtName.ID].Trim();
        string contactPerson = Request.Form[txtContactPerson.ID].Trim();
        string phone = Request.Form[txtPhone.ID].Trim();
        string email = Request.Form[txtEmail.ID].Trim();
        string address = Request.Form[txtAddress.ID].Trim();
        string returnAddress = Request.Form[txtReturnAddress.ID].Trim();
        string fax = Request.Form[txtFax.ID].Trim();
        string transportTime = Request.Form[txtTransportTime.ID].Trim();
        string remark = Request.Form[txtRemark.ID].Trim();
        string strMinWeight = Request.Form[txtMinWeight.ID].Trim();
        string strMaxWeight = Request.Form[txtMaxWeight.ID].Trim();

        decimal agencyDiscount = 100;
        decimal clientDiscount = 100;
        decimal fuelRate = 0;

        if (string.IsNullOrEmpty(encode) || Validator.IsMatchLessThanChineseCharacter(encode, CONST_NAME_LENGTH))
        {
            lblMsg.Text = "承运商编号不能为空，并且长度不能超过 " + CONST_NAME_LENGTH + " 个字符！";
            return;
        }
        if (string.IsNullOrEmpty(name) || Validator.IsMatchLessThanChineseCharacter(name, CONST_NAME_LENGTH))
        {
            lblMsg.Text = "名称不能为空，并且长度不能超过 " + CONST_NAME_LENGTH + " 个字符！";
            return;
        }
        if (string.IsNullOrEmpty(contactPerson) || Validator.IsMatchLessThanChineseCharacter(contactPerson, CONST_CONTACT_PERSON_LENGTH))
        {
            lblMsg.Text = "联系人不能为空，并且长度不能超过 " + CONST_CONTACT_PERSON_LENGTH + " 个字符！";
            return;
        }
        if (string.IsNullOrEmpty(phone) || Validator.IsMatchLessThanChineseCharacter(phone, CONST_PHONE_LENGTH))
        {
            lblMsg.Text = "联系电话不能为空，并且长度不能超过 " + CONST_PHONE_LENGTH + " 个字符！";
            return;
        }
        if (string.IsNullOrEmpty(fax) || Validator.IsMatchLessThanChineseCharacter(fax, CONST_FAX_LENGTH))
        {
            lblMsg.Text = "传真不能为空，并且长度不能超过 " + CONST_FAX_LENGTH + " 个字符！";
            return;
        }
        if (string.IsNullOrEmpty(email) || Validator.IsMatchLessThanChineseCharacter(email, CONST_EMAIL_LENGTH))
        {
            lblMsg.Text = "电子邮箱不能为空，并且长度不能超过 " + CONST_EMAIL_LENGTH + " 个字符！";
            return;
        }
        if (string.IsNullOrEmpty(address) || Validator.IsMatchLessThanChineseCharacter(address, CONST_ADDRESS_LENGTH))
        {
            lblMsg.Text = "公司地址不能为空，并且长度不能超过 " + CONST_ADDRESS_LENGTH + " 个字符！";
            return;
        }
        if (string.IsNullOrEmpty(returnAddress) || Validator.IsMatchLessThanChineseCharacter(returnAddress, CONST_ADDRESS_LENGTH))
        {
            lblMsg.Text = "回邮地址不能为空，并且长度不能超过 " + CONST_ADDRESS_LENGTH + " 个字符！";
            return;
        }        
        if (!string.IsNullOrEmpty(transportTime) && Validator.IsMatchLessThanChineseCharacter(transportTime, CONST_TRANSPROT_TIME_LENGTH))
        {
            lblMsg.Text = "递送时间长度不能超过 " + CONST_TRANSPROT_TIME_LENGTH + " 个字符！";
            return;
        }
        if (decimal.TryParse(Request.Form[txtAgencyDiscount.ID], out agencyDiscount))
        {
            if (agencyDiscount <= 0 || agencyDiscount > 1)
            {
                lblMsg.Text = "代理折扣数字只能 >0 且 <=1！";
                return;
            }
        }
        else
        {
            lblMsg.Text = "代理折扣数字只能在 >0 且 <=1！";
            return;
        }

        if (decimal.TryParse(Request.Form[txtClientDiscount.ID], out clientDiscount))
        {
            if (clientDiscount <= 0 || clientDiscount > 2)
            {
                lblMsg.Text = "客户折扣数字只能 >0 且 <=2！";
                return;
            }
        }
        else
        {
            lblMsg.Text = "客户折扣数字只能 >0 且 <=2！";
            return;
        }

        if (decimal.TryParse(Request.Form[txtFuelRate.ID], out fuelRate))
        {
            if (fuelRate < 0 || fuelRate > 1)
            {
                lblMsg.Text = "燃油附加率数字只能在0--1之间！";
                return;
            }
        }
        else
        {
            lblMsg.Text = "燃油附加率数字只能在0--1之间！";
            return;
        }

        decimal minWeight=0;
        if (!string.IsNullOrEmpty(strMinWeight) && !decimal.TryParse(strMinWeight, out minWeight))
        {
            lblMsg.Text = "限重最小值只能为数字！";
            return;
        }

        decimal maxWeight = 0;
        if (!string.IsNullOrEmpty(strMaxWeight) && !decimal.TryParse(strMaxWeight, out maxWeight))
        {
            lblMsg.Text = "限重最大值只能为数字！";
            return;
        }

        if (!string.IsNullOrEmpty(remark) && Validator.IsMatchLessThanChineseCharacter(remark, CONST_REMARK_LENGTH))
        {
            lblMsg.Text = "备注长度不能超过 " + CONST_REMARK_LENGTH + " 个字符！";
            return;
        }
        Carrier carrier = new Carrier();
        carrier.Encode = encode;
        carrier.Address = address;
        carrier.ReturnAddress = returnAddress;
        carrier.AgencyDiscount = agencyDiscount;
        carrier.ClientDiscount = clientDiscount;
        carrier.ContactPerson = contactPerson;
        carrier.Email = email;
        carrier.Fax = fax;
        carrier.FuelSgRate = fuelRate;
        carrier.IsInvoice = chkInvoice.Checked;
        carrier.IsChargeByWV = chkChargeWv.Checked;
        carrier.IsClientShow = chkClientShow.Checked;
        carrier.IsUseable = chkUseable.Checked;
        carrier.IsFollow = chkFollow.Checked;
        carrier.IsLimitWeight = chkLimitWeight.Checked;
        carrier.IsOpenApi = chkOpenApi.Checked;
        carrier.Name = name;
        carrier.Phone = phone;
        carrier.Remark = remark;
        carrier.TransportTime = transportTime;
        carrier.MinWeight = minWeight;
        carrier.MaxWeight = maxWeight;
        carrier.QuoteType = slQuoteType.Value;

        if (CarrierOperation.CreateCarrier(carrier))
        {
            lblMsg.Text = "添加成功！";
        }
        else
        {
            lblMsg.Text = "该编号已经存在！";
            return;
        }
    }
}
