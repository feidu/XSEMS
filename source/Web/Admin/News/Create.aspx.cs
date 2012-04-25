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

public partial class Admin_News_Create : System.Web.UI.Page
{
    private static readonly int TITLE_LENGTH = 100;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DdlNewsCategoryDataBind();
        }
    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        News news = new News();

        string title=Request.Form[tbxTitle.ID].Trim();
        string content = Request.Form[tbxContent.ID].Trim();
        if(string.IsNullOrEmpty(title) || Validator.IsMatchLessThanChineseCharacter(title, TITLE_LENGTH))
        {
            lblMsg.Text="标题不能为空，并且不能超过 " + TITLE_LENGTH + "个字符！";
            return;
        }
        if (string.IsNullOrEmpty(content))
        {
            lblMsg.Text = "内容不能为空！";
            return;
        }
        news.Title = title;
        news.Content = content;
        news.Category = new NewsCategory();
        news.Category.Id = int.Parse(ddlNewsCategory.SelectedValue);
        news.IsDisplay = cbxDisplay.Checked;
        news.CreateTime = DateTime.Now;

        NewsOperation.CreateNews(news);

        lblMsg.Text = "添加成功！";
    }

    private void DdlNewsCategoryDataBind()
    {
        ddlNewsCategory.DataSource = NewsOperation.GetNewsCategory();
        ddlNewsCategory.DataTextField = "Name";
        ddlNewsCategory.DataValueField = "Id";
        ddlNewsCategory.DataBind();
    }
}
