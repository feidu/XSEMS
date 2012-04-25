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

public partial class Controls_Right : System.Web.UI.UserControl
{
    protected string address = "";
    protected string phoneNumber = "";
    protected string msnAccount = "";
    protected string faxNumber = "";
    protected string postalcode = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Setting setting = CacheHelper.GetSetting();
        phoneNumber = setting.Phone;
        address = setting.Address;
        msnAccount = setting.Msn;
        faxNumber = setting.Fax;
        postalcode = setting.Postalcode;
    }
}
