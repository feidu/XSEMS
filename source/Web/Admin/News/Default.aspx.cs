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
using Backend.BAL;
using Backend.Models;

public partial class Admin_News_Default : System.Web.UI.Page
{
    private int id = 0;
    NewsCategory nc = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        RpNewsCategoryDataBind();
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            nc = NewsOperation.GetNewsCategoryById(id);
            if (!IsPostBack)
            {
                tbCategoryUpdate.Visible = true;
                tbxName.Text = nc.Name;
                tbxNote.Text = nc.Remark;
            }
        }
        else
        {
            tbCategoryUpdate.Visible = false;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(tbxName.Text.Trim()))
        {
            lblMsg.Text = "分类名称不能为空！";
            return;
        }
        nc.Name = Request.Form[tbxName.ID].Trim();
        nc.Remark=Request.Form[tbxNote.ID].Trim();

        NewsOperation.UpdateNewCategory(nc);
        lblMsg.Text = "修改成功！";

        RpNewsCategoryDataBind();

        tbCategoryUpdate.Visible = false;
    }

    private void RpNewsCategoryDataBind()
    {
        rpNewsCategory.DataSource = NewsOperation.GetNewsCategory();
        rpNewsCategory.DataBind();
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string ids = Request.Form["cboxId"];
        if (string.IsNullOrEmpty(ids))
        {
            lblMsg.Text = "请选择！";
            return;
        }
        NewsOperation.DeleteNewsCategoryByIds(ids);
        lblMsg.Text = "删除成功！";

        RpNewsCategoryDataBind();
    }
}
