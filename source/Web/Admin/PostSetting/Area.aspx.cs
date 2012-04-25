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

public partial class Admin_PostSetting_Area : System.Web.UI.Page
{
    private static readonly int NAME_LENGTH = 50;
    CarrierArea ca = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            ca = CarrierAreaOperation.GetCarrierAreaById(id);           
        }
        FormDataBind();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string name = Request.Form[txtName.ID].Trim();

        if (string.IsNullOrEmpty(name) || Validator.IsMatchLessThanChineseCharacter(name, NAME_LENGTH))
        {
            lblMsg.Text = "分区名称不能为空，并且长度不能超过 " + NAME_LENGTH + " 个字符！";
            return;
        }
        ca.Name = name;        
        

        CarrierAreaOperation.UpdateCarrierArea(ca);
        Response.Write("<script language='javascript'>alert('修改成功！');location.href='CarrierAreaList.aspx?id=" + ca.Carrier.Id + "';</script>");
    }

    private void FormDataBind()
    {
        lblCarrierName.Text = ca.Carrier.Name;
        txtName.Text = ca.Name;
    }
}
