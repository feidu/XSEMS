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

public partial class Admin_PostSetting_ChargeStandard : System.Web.UI.Page
{
    protected Carrier carrier = null;
    CarrierArea ca = null;
    protected decimal clientDiscount = 100;
    protected decimal angencyDiscount = 100;
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            ca = CarrierAreaOperation.GetCarrierAreaById(id);
            carrier = CarrierOperation.GetCarrierById(ca.Carrier.Id);

            lblCarrier.Text = carrier.Name;
            lblCarrierArea.Text = ca.Name;            
        }
        if (!decimal.TryParse(Request.QueryString["cd"], out clientDiscount) || !decimal.TryParse(Request.QueryString["ad"], out angencyDiscount))
        {
            return;
        }
        if (!IsPostBack)
        {
            RpChargeStandardDataBind();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rpChargeStandard.Items.Count; i++)
        {
            RepeaterItem ri = rpChargeStandard.Items[i];
            Label lblEncode = (Label)ri.FindControl("lblEncode");
            TextBox txtStartWeight = (TextBox)ri.FindControl("txtStartWeight");
            TextBox txtEndWeight = (TextBox)ri.FindControl("txtEndWeight");
            TextBox txtBaseWeight = (TextBox)ri.FindControl("txtBaseWeight");
            TextBox txtIncreaseWeight = (TextBox)ri.FindControl("txtIncreaseWeight");
            TextBox txtNormalBasePrice = (TextBox)ri.FindControl("txtNormalBasePrice");
            TextBox txtNormalContinuePrice = (TextBox)ri.FindControl("txtNormalContinuePrice");
            TextBox txtNormalKgPrice = (TextBox)ri.FindControl("txtNormalKgPrice");
            TextBox txtNormalDisposalCost = (TextBox)ri.FindControl("txtNormalDisposalCost");
            TextBox txtNormalRegisterCost = (TextBox)ri.FindControl("txtNormalRegisterCost");
            TextBox txtClientBasePrice = (TextBox)ri.FindControl("txtClientBasePrice");
            TextBox txtClientContinuePrice = (TextBox)ri.FindControl("txtClientContinuePrice");
            TextBox txtClientKgPrice = (TextBox)ri.FindControl("txtClientKgPrice");
            TextBox txtClientDisposalCost = (TextBox)ri.FindControl("txtClientDisposalCost");
            TextBox txtClientRegisterCost = (TextBox)ri.FindControl("txtClientRegisterCost");
            TextBox txtSelfBasePrice = (TextBox)ri.FindControl("txtSelfBasePrice");
            TextBox txtSelfContinuePrice = (TextBox)ri.FindControl("txtSelfContinuePrice");
            TextBox txtSelfKgPrice = (TextBox)ri.FindControl("txtSelfKgPrice");
            TextBox txtSelfDisposalCost = (TextBox)ri.FindControl("txtSelfDisposalCost");
            TextBox txtSelfRegisterCost = (TextBox)ri.FindControl("txtSelfRegisterCost");
            TextBox txtPreferentialGram = (TextBox)ri.FindControl("txtPreferentialGram");
            DropDownList ddlGoodsType = (DropDownList)ri.FindControl("ddlGoodsType");

            ChargeStandard cs = ChargeStandardOperation.GetChargeStandardByEncode(ca.Id, lblEncode.Text);
            try
            {
                cs.StartWeight = decimal.Parse(txtStartWeight.Text);
                cs.EndWeight = decimal.Parse(txtEndWeight.Text);
                cs.BaseWeight = decimal.Parse(txtBaseWeight.Text);
                cs.IncreaseWeight = decimal.Parse(txtIncreaseWeight.Text);
                cs.NormalBasePrice = decimal.Parse(txtNormalBasePrice.Text);
                cs.NormalContinuePrice = decimal.Parse(txtNormalContinuePrice.Text);
                cs.NormalDisposalCost = decimal.Parse(txtNormalDisposalCost.Text);
                cs.NormalKgPrice = decimal.Parse(txtNormalKgPrice.Text);
                cs.NormalRegisterCost = decimal.Parse(txtNormalRegisterCost.Text);
                cs.ClientBasePrice = decimal.Parse(txtClientBasePrice.Text);
                cs.ClientContinuePrice = decimal.Parse(txtClientContinuePrice.Text);
                cs.ClientDisposalCost = decimal.Parse(txtClientDisposalCost.Text);
                cs.ClientKgPrice = decimal.Parse(txtClientKgPrice.Text);
                cs.ClientRegisterCost = decimal.Parse(txtClientRegisterCost.Text);
                cs.SelfBasePrice = decimal.Parse(txtSelfBasePrice.Text);
                cs.SelfContinuePrice = decimal.Parse(txtSelfContinuePrice.Text);
                cs.SelfDisposalCost = decimal.Parse(txtSelfDisposalCost.Text);
                cs.SelfKgPrice = decimal.Parse(txtSelfKgPrice.Text);
                cs.SelfRegisterCost = decimal.Parse(txtSelfRegisterCost.Text);
                cs.PreferentialGram = decimal.Parse(txtPreferentialGram.Text);
                cs.GoodsType = byte.Parse(ddlGoodsType.SelectedItem.Value);
            }
            catch (Exception ex)
            {
                Response.Write("<script language='javascript' type='text/javascript'>alert('重量、价格、费用和让利克数都只能为数字！');</script>");
                return;
            }
            if ((cs.NormalBasePrice > 0 || cs.NormalContinuePrice > 0) && cs.NormalKgPrice > 0)
            {
                Response.Write("<script language='javascript' type='text/javascript'>alert('同一重量范围内只能按首、续重价 或 每KG价其中一种方式计算！');</script>");
                return;
            }
            if ((cs.ClientBasePrice > 0 || cs.ClientContinuePrice > 0) && cs.ClientKgPrice > 0)
            {
                Response.Write("<script language='javascript' type='text/javascript'>alert('同一重量范围内只能按首、续重价 或 每KG价其中一种方式计算！');</script>");
                return;
            }
            if ((cs.SelfBasePrice > 0 || cs.SelfContinuePrice > 0) && cs.SelfKgPrice > 0)
            {
                Response.Write("<script language='javascript' type='text/javascript'>alert('同一重量范围内只能按首、续重价 或 每KG价其中一种方式计算！');</script>");
                return;
            }

            ChargeStandardOperation.UpdateChargeStandard(cs);
        }
        lblMsg.Text = "修改成功！";
        RpChargeStandardDataBind();
    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        ChargeStandard cs = new ChargeStandard();
        cs.CarrierAreaId = ca.Id;
        cs.CarrierId = carrier.Id;
        cs.Encode = ChargeStandardOperation.GetNextEncode(ca.Id);
        cs.GoodsType = byte.Parse(ddlGoodsType.SelectedItem.Value);
        try
        {
            cs.StartWeight = decimal.Parse(txtStartWeight.Text);
            cs.EndWeight = decimal.Parse(txtEndWeight.Text);
            cs.BaseWeight = decimal.Parse(txtBaseWeight.Text);
            cs.IncreaseWeight = decimal.Parse(txtIncreaseWeight.Text);
            cs.NormalBasePrice = decimal.Parse(txtNormalBasePrice.Text);
            cs.NormalContinuePrice = decimal.Parse(txtNormalContinuePrice.Text);
            cs.NormalDisposalCost = decimal.Parse(txtNormalDisposalCost.Text);
            cs.NormalKgPrice = decimal.Parse(txtNormalKgPrice.Text);
            cs.NormalRegisterCost = decimal.Parse(txtNormalRegisterCost.Text);
            cs.ClientBasePrice = decimal.Parse(txtClientBasePrice.Text);
            cs.ClientContinuePrice = decimal.Parse(txtClientContinuePrice.Text);
            cs.ClientDisposalCost = decimal.Parse(txtClientDisposalCost.Text);
            cs.ClientKgPrice = decimal.Parse(txtClientKgPrice.Text);
            cs.ClientRegisterCost = decimal.Parse(txtClientRegisterCost.Text);
            cs.SelfBasePrice = decimal.Parse(txtSelfBasePrice.Text);
            cs.SelfContinuePrice = decimal.Parse(txtSelfContinuePrice.Text);
            cs.SelfDisposalCost = decimal.Parse(txtSelfDisposalCost.Text);
            cs.SelfKgPrice = decimal.Parse(txtSelfKgPrice.Text);
            cs.SelfRegisterCost = decimal.Parse(txtSelfRegisterCost.Text);
            cs.PreferentialGram = decimal.Parse(txtPreferentialGram.Text);
        }
        catch (Exception ex)
        {
            Response.Write("<script language='javascript' type='text/javascript'>alert('重量、价格、费用和让利克数都只能为数字！');</script>");
            return;
        }
        if ((cs.NormalBasePrice > 0 || cs.NormalContinuePrice > 0) && cs.NormalKgPrice > 0)
        {
            Response.Write("<script language='javascript' type='text/javascript'>alert('同一重量范围内只能按首、续重价 或 每KG价其中一种方式计算！');</script>");
            return;
        }
        if ((cs.ClientBasePrice > 0 || cs.ClientContinuePrice > 0) && cs.ClientKgPrice > 0)
        {
            Response.Write("<script language='javascript' type='text/javascript'>alert('同一重量范围内只能按首、续重价 或 每KG价其中一种方式计算！');</script>");
            return;
        }
        if ((cs.SelfBasePrice > 0 || cs.SelfContinuePrice > 0) && cs.SelfKgPrice > 0)
        {
            Response.Write("<script language='javascript' type='text/javascript'>alert('同一重量范围内只能按首、续重价 或 每KG价其中一种方式计算！');</script>");
            return;
        }
        ChargeStandardOperation.CreateChargeStandard(cs);
        lblMsg.Text = "添加成功！";
        RpChargeStandardDataBind();
    }

    private void RpChargeStandardDataBind()
    {
        rpChargeStandard.ItemDataBound+=new RepeaterItemEventHandler(rpChargeStandard_ItemDataBound);
        rpChargeStandard.DataSource = ChargeStandardOperation.GetChargeStandardByCarrierAreaId(ca.Id);
        rpChargeStandard.DataBind();
    }

    private void rpChargeStandard_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        ChargeStandard cs = (ChargeStandard)e.Item.DataItem;

        Label lblEncode = (Label)e.Item.FindControl("lblEncode");
        TextBox txtStartWeight = (TextBox)e.Item.FindControl("txtStartWeight");
        TextBox txtEndWeight = (TextBox)e.Item.FindControl("txtEndWeight");
        TextBox txtBaseWeight = (TextBox)e.Item.FindControl("txtBaseWeight");
        TextBox txtIncreaseWeight = (TextBox)e.Item.FindControl("txtIncreaseWeight");
        TextBox txtNormalBasePrice = (TextBox)e.Item.FindControl("txtNormalBasePrice");
        TextBox txtNormalContinuePrice = (TextBox)e.Item.FindControl("txtNormalContinuePrice");
        TextBox txtNormalKgPrice = (TextBox)e.Item.FindControl("txtNormalKgPrice");
        TextBox txtNormalDisposalCost = (TextBox)e.Item.FindControl("txtNormalDisposalCost");
        TextBox txtNormalRegisterCost = (TextBox)e.Item.FindControl("txtNormalRegisterCost");
        TextBox txtClientBasePrice = (TextBox)e.Item.FindControl("txtClientBasePrice");
        TextBox txtClientContinuePrice = (TextBox)e.Item.FindControl("txtClientContinuePrice");
        TextBox txtClientKgPrice = (TextBox)e.Item.FindControl("txtClientKgPrice");
        TextBox txtClientDisposalCost = (TextBox)e.Item.FindControl("txtClientDisposalCost");
        TextBox txtClientRegisterCost = (TextBox)e.Item.FindControl("txtClientRegisterCost");
        TextBox txtSelfBasePrice = (TextBox)e.Item.FindControl("txtSelfBasePrice");
        TextBox txtSelfContinuePrice = (TextBox)e.Item.FindControl("txtSelfContinuePrice");
        TextBox txtSelfKgPrice = (TextBox)e.Item.FindControl("txtSelfKgPrice");
        TextBox txtSelfDisposalCost = (TextBox)e.Item.FindControl("txtSelfDisposalCost");
        TextBox txtSelfRegisterCost = (TextBox)e.Item.FindControl("txtSelfRegisterCost");
        TextBox txtPreferentialGram = (TextBox)e.Item.FindControl("txtPreferentialGram");
        DropDownList ddlGoodsType = (DropDownList)e.Item.FindControl("ddlGoodsType");

        lblEncode.Text = cs.Encode;
        txtStartWeight.Text = StringHelper.CurtNumber(cs.StartWeight.ToString());
        txtEndWeight.Text = StringHelper.CurtNumber(cs.EndWeight.ToString());
        txtBaseWeight.Text = StringHelper.CurtNumber(cs.BaseWeight.ToString());
        txtIncreaseWeight.Text = StringHelper.CurtNumber(cs.IncreaseWeight.ToString());
        txtNormalBasePrice.Text =  StringHelper.CurtNumber(cs.NormalBasePrice.ToString());
        txtNormalContinuePrice.Text = StringHelper.CurtNumber(cs.NormalContinuePrice.ToString());
        txtNormalDisposalCost.Text = StringHelper.CurtNumber(cs.NormalDisposalCost.ToString());
        txtNormalKgPrice.Text = StringHelper.CurtNumber(cs.NormalKgPrice.ToString());
        txtNormalRegisterCost.Text = StringHelper.CurtNumber(cs.NormalRegisterCost.ToString());
        txtClientBasePrice.Text = StringHelper.CurtNumber(cs.ClientBasePrice.ToString());
        txtClientContinuePrice.Text = StringHelper.CurtNumber(cs.ClientContinuePrice.ToString());
        txtClientDisposalCost.Text = StringHelper.CurtNumber(cs.ClientDisposalCost.ToString());
        txtClientKgPrice.Text = StringHelper.CurtNumber(cs.ClientKgPrice.ToString());
        txtClientRegisterCost.Text = StringHelper.CurtNumber(cs.ClientRegisterCost.ToString());
        txtSelfBasePrice.Text = StringHelper.CurtNumber(cs.SelfBasePrice.ToString());
        txtSelfContinuePrice.Text = StringHelper.CurtNumber(cs.SelfContinuePrice.ToString());
        txtSelfDisposalCost.Text = StringHelper.CurtNumber(cs.SelfDisposalCost.ToString());
        txtSelfKgPrice.Text = StringHelper.CurtNumber(cs.SelfKgPrice.ToString());
        txtSelfRegisterCost.Text = StringHelper.CurtNumber(cs.SelfRegisterCost.ToString());
        txtPreferentialGram.Text = StringHelper.CurtNumber(cs.PreferentialGram.ToString());
        ddlGoodsType.SelectedValue = cs.GoodsType.ToString();        
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string ids = Request.Form["chkId"];
        if (ids == null)
        {
            lblMsg.Text = "请选择！";
            return;            
        }
        ChargeStandardOperation.DeleteChargeStandardByIds(ids);
        lblMsg.Text = "删除成功！";
        RpChargeStandardDataBind();
    }
}
