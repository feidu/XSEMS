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
using Backend.Models.Admin;
using System.Text;
using Backend.Authorization;
using Backend.BAL;


public partial class Admin_Main_Default : System.Web.UI.Page
{
    protected string phone = null;
    protected string copyright = null;
    protected string URL = null;
    string[] MENUS = new string[] { 
    "<td width=\"0\"></td>",   
    "<td width=\"60\" onClick=\"menuClickMe(this,'../Order/AuditOrderList.aspx?'+new Date());\" onMouseOver=\"menuOverMe(this)\" onmouseout=\"menuOutMe(this)\"> 业务管理</td>",
    "<td width=\"60\" onClick=\"menuClickMe(this,'../Order/CheckOrderList.aspx?'+new Date());\" onMouseOver=\"menuOverMe(this)\" onmouseout=\"menuOutMe(this)\"> 收件检验</td>",
    "<td width=\"60\" onClick=\"menuClickMe(this,'../Client/?'+new Date());\" onMouseOver=\"menuOverMe(this)\" onmouseout=\"menuOutMe(this)\"> 客户服务</td>",
    "<td width=\"60\" onClick=\"menuClickMe(this,'../Finance/?'+new Date());\" onMouseOver=\"menuOverMe(this)\" onmouseout=\"menuOutMe(this)\"> 财务管理</td>",
    "<td width=\"60\" onClick=\"menuClickMe(this,'../DataQuery/?'+new Date());\" onMouseOver=\"menuOverMe(this)\" onmouseout=\"menuOutMe(this)\"> 数据查询</td>",
    "<td width=\"60\" onClick=\"menuClickMe(this,'../Statistic/?'+new Date());\" onMouseOver=\"menuOverMe(this)\" onmouseout=\"menuOutMe(this)\"> 统计分析</td>",
    "<td width=\"60\" onClick=\"menuClickMe(this,'../User/?'+new Date());\" onMouseOver=\"menuOverMe(this)\" onmouseout=\"menuOutMe(this)\"> 员工管理</td>", 
    "<td width=\"60\" onClick=\"menuClickMe(this,'../CompanySetting/?'+new Date());\" onMouseOver=\"menuOverMe(this)\" onmouseout=\"menuOutMe(this)\"> 公司设置</td>",
    "<td width=\"60\" onClick=\"menuClickMe(this,'../PostSetting/CarrierList.aspx?'+new Date());\" onMouseOver=\"menuOverMe(this)\" onmouseout=\"menuOutMe(this)\"> 物流设置</td>",
    "<td width=\"60\" onClick=\"menuClickMe(this,'../WebSetting/?'+new Date());\" onMouseOver=\"menuOverMe(this)\" onmouseout=\"menuOutMe(this)\"> 网站管理</td>"
    };

    protected void Page_Load(object sender, EventArgs e)
    {
        Setting setting = SettingOperation.LoadSetting();

        phone = setting.Phone;
        copyright = setting.Copyright;

        AdminCookie session = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        StringBuilder sb = new StringBuilder("<table width=\"100%\" height=\"29\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" background=\"../Images/menu_2.gif\" class=\"menu\"><tr>");
        sb.Append("<td width=\"120\" valign='top'><a href='../Main'><img src=\"../Images/menu_1.gif\" width=\"120\" height=\"44\" border='0'/></a></td>");
        foreach (ModuleAuthorization ma in session.ModuleAuthorizations)
        {
            if (ma.Accessible)
            {
                sb.Append(MENUS[ma.ModuleId]);
                sb.Append("<td width=\"1\"><img src=\"../Images/menu_4.gif\" width=\"1\" height=\"29\"></td>");
            }

        }
        sb.Append("<td width=\"60\" onClick=\"menuClickMe(this,'../Personal/?'+new Date());\" onMouseOver=\"menuOverMe(this)\" onmouseout=\"menuOutMe(this)\">个人信息</td>");
        sb.Append("<td class=\"info\"><a href=\"../Logout.aspx\" class=\"logout\">退出</a></td>");
        sb.Append("</tr></table>");
        menu.InnerHtml = sb.ToString();

        if (Request.QueryString["ReturnUrl"] == null)
        {
            URL = "Welcome.aspx";
        }
        else
        {
            URL = Request.QueryString["ReturnUrl"];
        }
    }
}

