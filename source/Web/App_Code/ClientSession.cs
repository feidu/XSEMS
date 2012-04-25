using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Backend.Models;
using Backend.Authorization;

/// <summary>
/// ClientSession 的摘要说明
/// </summary>
public class ClientSession:UserBase,ISessionable
{

}
