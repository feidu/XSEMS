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
using Backend.Utilities;
using System.Collections.Generic;
using Backend.BAL;

public partial class Controls_Header : System.Web.UI.UserControl
{
    protected string announcement = "";
    protected string files = "";
    protected string links = "";

    private int _currentNav;
    public int CurrentNav
    {
        get { return _currentNav; }
        set { _currentNav = value; }
    }

    protected int currentNav = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        List<News> result = NewsOperation.GetNewsByCategoryId(3);
        foreach (News news in result)
        {
            announcement += "<a href='/NewsView.aspx?id=" + news.Id + "' targit='_blank'>" + news.Title + "</a>&nbsp;";
        }        
        currentNav = CurrentNav;

        List<Ad> adList = SettingOperation.GetAdSortByNum();
        for (int i = 0; i < adList.Count; i++)
        {
            if (i == adList.Count - 1)
            {
                files = files + Backend.Utilities.FilePath.FilePathGenerator.GeneratePhotoHttpUrl(adList[i].Path);
            }
            else
            {
                files = files + Backend.Utilities.FilePath.FilePathGenerator.GeneratePhotoHttpUrl(adList[i].Path) + "|";
            }
        }
    }
}
