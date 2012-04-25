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

public partial class Admin_CompanySetting_CreatePosition : System.Web.UI.Page
{
    private static readonly int CONST_POST_NAME_LENGHT = 50;
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        string name = Request.Form[txtPositionName.ID].Trim();
        if (string.IsNullOrEmpty(name) || Validator.IsMatchLessThanChineseCharacter(name, CONST_POST_NAME_LENGHT))
        {
            lblMsg.Text = "职位名称不能为空，并且不能超过个" + CONST_POST_NAME_LENGHT + "字符！";
            return;
        }
        Position position = new Position();
        position.Name = name;

        if (PositionOperation.CreatePosition(position))
        {
            lblMsg.Text = "添加成功！";
        }
        else
        {
            lblMsg.Text = "职位名称已经存在！";
        }
    }
}
