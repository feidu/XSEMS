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
public partial class Admin_News_Edit : System.Web.UI.Page
{
    private static readonly int TITLE_LENGTH = 100;
    private int id = 0;
    News news = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!int.TryParse(Request.QueryString["id"], out id))
        {
            return;
        }
        news = NewsOperation.GetNewsById(id);
        if (!IsPostBack)
        {
            DdlNewsCategoryDataBind(); 
            FormDataBind();           
        }        
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if(string.IsNullOrEmpty(tbxTitle.Text.Trim()) || Validator.IsMatchLessThanChineseCharacter(tbxTitle.Text.Trim(), TITLE_LENGTH))
        {
            lblMsg.Text="标题不能为空，并且不能超过 " + TITLE_LENGTH + "个字符！";
        }
        news.Title = tbxTitle.Text;
        news.Content = tbxContent.Value;
        news.Category = new NewsCategory();
        news.Category.Id = int.Parse(ddlNewsCategory.SelectedValue);
        news.IsDisplay = cbxDisplay.Checked;
        news.CreateTime = DateTime.Now;

        NewsOperation.UpdateNews(news);

        lblMsg.Text = "修改成功！";
    }

    private void DdlNewsCategoryDataBind()
    {
        List<NewsCategory> newscategory = NewsOperation.GetNewsCategory();
        foreach (NewsCategory cat in newscategory)
        {
            ddlNewsCategory.Items.Add(new ListItem(cat.Name,cat.Id.ToString()));
        }
    }

    private void FormDataBind()
    {        
        if (news != null)
        {
            tbxTitle.Text = news.Title;
            tbxContent.Value = news.Content;
            ddlNewsCategory.SelectedValue = news.Category.Id.ToString();
            cbxDisplay.Checked = news.IsDisplay;
        }
    }
}
