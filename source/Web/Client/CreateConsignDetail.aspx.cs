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

public partial class Client_CreateConsignDetail : System.Web.UI.Page
{
    protected Order order = null;
    private static readonly int GOODS_TITLE_LENGTH = 100;
    private static readonly int CONSIGN_PARAM_LENGTH = 200;
    protected void Page_Load(object sender, EventArgs e)
    {
        seo.Title = "添加地址明细";
        int id = 0;
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            order = OrderOperation.GetOrderById(id);
        }

    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        string title = Request.Form[txtGoodsTitle.ID].Trim();
        string strWeight = Request.Form[txtWeight.ID].Trim();
        string strCount = Request.Form[txtCount.ID].Trim();
        string strDeclareWorth=Request.Form[txtWorth.ID].Trim();
        string declareCnName = Request.Form[txtDeclareCnName.ID].Trim();
        string hsEncode = Request.Form[txtHsEncode.ID].Trim();

        if (string.IsNullOrEmpty(title) || Validator.IsMatchLessThanChineseCharacter(title, GOODS_TITLE_LENGTH))
        {
            lblMsg.Text = "物品名称不能为空，且不能超过" + GOODS_TITLE_LENGTH + "个字符！";
            return;
        }
        decimal weight = 0;
        if (string.IsNullOrEmpty(strWeight) || !decimal.TryParse(strWeight, out weight))
        {
            lblMsg.Text = "重量不能为空，且只能为大于0的数字！";
            return;
        }
        if(weight <= 0)
        {
            lblMsg.Text = "重量不能为空，且只能为大于0的数字！";
            return;
        }
        int count = 0;
        if (string.IsNullOrEmpty(strCount) || !int.TryParse(strCount, out count))
        {
            lblMsg.Text = "数量不能为空，且只能为大于0的整数！";
            return;
        }
        if (count <= 0)
        {
            lblMsg.Text = "数量不能为空，且只能为大于0的整数！";
            return;
        }
        decimal declareWorth = 0;
        if (string.IsNullOrEmpty(strDeclareWorth) || !decimal.TryParse(strDeclareWorth, out declareWorth))
        {
            lblMsg.Text = "申报价值不能为空，且只能为大于0的数字！";
            return;
        }
        if (declareWorth <= 0)
        {
            lblMsg.Text = "申报价值不能为空，且只能为大于0的数字！";
            return;
        }
        if (string.IsNullOrEmpty(declareCnName) || Validator.IsMatchLessThanChineseCharacter(declareCnName, CONSIGN_PARAM_LENGTH))
        {
            lblMsg.Text = "中文申报名称不能超过" + CONSIGN_PARAM_LENGTH + "个字符！";
            return;
        }
        if (string.IsNullOrEmpty(hsEncode) || Validator.IsMatchLessThanChineseCharacter(hsEncode, CONSIGN_PARAM_LENGTH))
        {
            lblMsg.Text = "HS编码不能超过" + CONSIGN_PARAM_LENGTH + "个字符！";
            return;
        }
        string encode =StringHelper.GetEncodeNumber("YD");
        OrderDetail od = new OrderDetail();
        od.HsEncode = hsEncode;
        od.Encode = encode;
        od.Title = title;
        od.DeclareWorth = declareWorth;
        od.ClientWeight = weight;
        od.ClientCount = count;
        od.DeclareCnName = declareCnName;
        od.OrderId = order.Id;
        od.ToAddress = order.ToAddress;
        od.ToCity = order.ToCity;
        od.ToCountry = order.ToCountry;
        od.ToEmail = order.ToEmail;
        od.ToPhone = order.ToPhone;
        od.ToPostcode = order.ToPostcode;
        od.ToUsername = order.ToUsername;
        od.CreateTime = DateTime.Now;
        OrderDetailOperation.CreateClientOrderDetail(od);
        Response.Write("<script language='javascript'>alert('添加成功！');location.href='Consign.aspx?id=" + order.Id + "';</script>");
    }
    

}
