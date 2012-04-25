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

public partial class Admin_CompanySetting_PositionList : System.Web.UI.Page
{
    Position position = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        trHeader.Visible = true;
        rpPosition.Visible = true;
        trFooter.Visible = true;
        RpPositionDataBind();
        int pId = 0;
        if (int.TryParse(Request.QueryString["pId"], out pId))
        {
            position = PositionOperation.GetPositionById(pId);
            if (!IsPostBack)
            {
                tbPositionUpdate.Visible = true;
                txtName.Text = position.Name;
            }
        }
        else
        {
            tbPositionUpdate.Visible = false;
        }
    }

    private void RpPositionDataBind()
    {        
        rpPosition.DataSource = PositionOperation.GetPosition();
        rpPosition.DataBind();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string ids = Request.Form["chkId"];
        if (string.IsNullOrEmpty(ids))
        {
            lblMsg.Text = "请选择！";
            return;
        }
        PositionOperation.DeletePositionByIds(ids);
        lblMsg.Text = "删除成功！";
        RpPositionDataBind();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtName.Text.Trim()))
        {
            lblMsg.Text = "职位名称不能为空！";
            return;
        }
        position.Name = Request.Form[txtName.ID].Trim();

        PositionOperation.UpdatePosition(position);
        lblMsg.Text = "修改成功！";

        RpPositionDataBind();
        tbPositionUpdate.Visible = false;
    }
}

