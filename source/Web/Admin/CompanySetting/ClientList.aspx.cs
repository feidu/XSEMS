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
using Backend.Models.Pagination;
using Backend.Utilities;
using Backend.Authorization;

public partial class Admin_CompanySetting_ClientList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RpClientDataBind();
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string ids = Request.Form["chkId"];
        if (string.IsNullOrEmpty(ids))
        {
            lblMsg.Text = "请选择！";
            return;
        }
        ClientOperation.DeleteClientByIds(ids);
        RpClientDataBind();
    }

    private void RpClientDataBind()
    {
        string keyword = Request.QueryString["k"];
        txtKeyword.Text = keyword;

        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        User user = UserOperation.GetUserByUsername(cookie.Username);
        PaginationQueryResult<Client> result = ClientOperation.GetClientByParameters(PaginationHelper.GetCurrentPaginationQueryCondition(Request), user.CompanyId, keyword);
        rpClient.ItemDataBound += new RepeaterItemEventHandler(rpClient_ItemDataBound);
        rpClient.DataSource = result.Results;
        rpClient.DataBind();

        pagi.TotalCount = result.TotalCount;
    }

    private void rpClient_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Client client = (Client)e.Item.DataItem;
        Label lblId = (Label)e.Item.FindControl("lblId");
        TextBox txtCredit = (TextBox)e.Item.FindControl("txtCredit");
        lblId.Text = client.Id.ToString();
        txtCredit.Text = StringHelper.CurtNumber(client.Credit.ToString());
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rpClient.Items.Count; i++)
        {
            RepeaterItem ri = rpClient.Items[i];

            Label lblId = (Label)ri.FindControl("lblId");
            TextBox txtCredit = (TextBox)ri.FindControl("txtCredit");
            int id = int.Parse(lblId.Text);
            Client client = ClientOperation.GetClientById(id);
            try
            {                
                client.Credit = decimal.Parse(txtCredit.Text);                
            }
            catch (Exception ex)
            {
                Response.Write("<script language='javascript' type='text/javascript'>alert('信用额度只能为数字！');</script>");
                return;
            }
            if (client.Credit < 0)
            {
                Response.Write("<script language='javascript' type='text/javascript'>alert('信用额度不能小于0！');</script>");
            }
            ClientOperation.UpdateClientDiscount(client);
        }
        lblMsg.Text = "修改成功！";
        RpClientDataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string keyword = Request.Form[txtKeyword.ID].Trim();
        if (!string.IsNullOrEmpty(keyword))
        {
            Response.Redirect("ClientList.aspx?k=" + keyword + "");
        }
    }
}
