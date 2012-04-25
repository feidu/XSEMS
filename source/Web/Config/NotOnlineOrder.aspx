<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NotOnlineOrder.aspx.cs" Inherits="Config_NotOnlineOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<wl:Seo ID="seo" runat="server" Title=""/>
<link href="../Css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table class="tablecontent">
                <tr><td align="left" valign="bottom" style="padding-left:5px;">
                    </td></tr>                   
                <tr>
                  <td>&nbsp;今天是<%=DateTime.Now.ToString() %>, 2天内未上线的订单<asp:Button ID="btnExport" runat="server" CssClass="button" Text="导出" 
                        onclick="btnExport_Click" /></td>
                </tr>                
              </table>              
    </div>
    </form>
</body>
</html>
