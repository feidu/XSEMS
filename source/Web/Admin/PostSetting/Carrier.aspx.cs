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
using System.Collections.Generic;

public partial class Admin_PostSetting_Carrier : System.Web.UI.Page
{
    private const int CONST_NAME_LENGTH = 50;
    private const int CONST_EMAIL_LENGTH = 50;
    private const int CONST_CONTACT_PERSON_LENGTH = 20;
    private const int CONST_PHONE_LENGTH = 20;
    private const int CONST_FAX_LENGTH = 20;
    private const int CONST_ADDRESS_LENGTH = 200;
    private const int CONST_TRANSPROT_TIME_LENGTH = 50;
    private const int CONST_REMARK_LENGTH = 1000;

    Carrier carrier = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            carrier = CarrierOperation.GetCarrierById(id);
        }
        if (!IsPostBack)
        {
            FormDataBind();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {        
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

        if (string.IsNullOrEmpty(name) || Validator.IsMatchLessThanChineseCharacter(name, CONST_NAME_LENGTH))
        {
            lblMsg.Text = "公司名称不能为空，并且长度不能超过 " + CONST_NAME_LENGTH + " 个字符！";
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
                lblMsg.Text = "代理折扣百分比数字只能 >0 且 <=1！";
                return;
            }
        }
        else
        {
            lblMsg.Text = "代理折扣百分比数字只能 >0 且 <=1！";
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
                lblMsg.Text = "燃油附加率百分比数字只能在0--1之间！";
                return;
            }
        }
        else
        {
            lblMsg.Text = "燃油附加率百分比数字只能在0--1之间！";
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

        CarrierOperation.UpdateCarrier(carrier);
        if (1 == 1)
        {
            List<ChargeStandard> result = ChargeStandardOperation.GetChargeStandardByCarrierId(carrier.Id);
            foreach (ChargeStandard cs in result)
            {
                cs.ClientBasePrice = cs.NormalBasePrice * carrier.ClientDiscount;
                cs.ClientContinuePrice = cs.NormalContinuePrice * carrier.ClientDiscount;
                cs.SelfBasePrice = cs.NormalBasePrice * carrier.AgencyDiscount;
                cs.SelfContinuePrice = cs.NormalContinuePrice * carrier.AgencyDiscount;
                ChargeStandardOperation.UpdateChargeStandard(cs);
            }
        }
        lblMsg.Text = "修改成功！";
        return;
    }

    private void FormDataBind()
    {
        txtEncode.Text = carrier.Encode;
        txtAddress.Text = carrier.Address;
        txtReturnAddress.Text = carrier.ReturnAddress;
        txtAgencyDiscount.Text = StringHelper.CurtNumber(carrier.AgencyDiscount.ToString());
        txtClientDiscount.Text = StringHelper.CurtNumber(carrier.ClientDiscount.ToString());
        txtContactPerson.Text = carrier.ContactPerson;
        txtEmail.Text = carrier.Email;
        txtFax.Text = carrier.Fax;
        txtFuelRate.Text = StringHelper.CurtNumber(carrier.FuelSgRate.ToString());
        chkInvoice.Checked = carrier.IsInvoice;
        txtName.Text = carrier.Name;
        txtPhone.Text = carrier.Phone;
        txtRemark.Text = carrier.Remark;
        txtTransportTime.Text = carrier.TransportTime;
        chkChargeWv.Checked = carrier.IsChargeByWV;
        chkClientShow.Checked = carrier.IsClientShow;
        chkUseable.Checked = carrier.IsUseable;
        chkFollow.Checked = carrier.IsFollow;
        chkLimitWeight.Checked = carrier.IsLimitWeight;
        chkOpenApi.Checked = carrier.IsOpenApi;
        txtMinWeight.Text = StringHelper.CurtNumber(carrier.MinWeight.ToString());
        slQuoteType.Value = carrier.QuoteType;
        if (carrier.MaxWeight > 0)
        {
            txtMaxWeight.Text = StringHelper.CurtNumber(carrier.MaxWeight.ToString());
        }
    }
}
