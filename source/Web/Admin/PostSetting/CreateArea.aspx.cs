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

public partial class Admin_PostSetting_CreateArea : System.Web.UI.Page
{
    private static readonly int NAME_LENGTH = 50;
    Carrier carrier = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            carrier = CarrierOperation.GetCarrierById(id);
            trLblCarrier.Visible = true;
            lblCarrier.Text = carrier.Name;
        }
        else 
        {
            trDdlCarrier.Visible = true;
        }
    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {        
        string name = Request.Form[txtName.ID].Trim();
        
        if (string.IsNullOrEmpty(name) || Validator.IsMatchLessThanChineseCharacter(name, NAME_LENGTH))
        {
            lblMsg.Text = "分区名称不能为空，并且长度不能超过 " + NAME_LENGTH + " 个字符！";
            return;
        }
        
        CarrierArea ca = new CarrierArea();
        ca.Name = name;

        if (carrier == null)        
        {
            carrier = CarrierOperation.GetCarrierById(int.Parse(ddlCarrier.SelectedItem.Value));
        }
        ca.Carrier = carrier;
        ca.Encode = CarrierAreaOperation.GetNextEncode();

        if (CarrierAreaOperation.CreateCarrierArea(ca))
        {
            lblMsg.Text = "添加成功！";
            return;
        }
        else
        {
            lblMsg.Text = "此分区名称已经存在！";
            return;
        }
    }
}
