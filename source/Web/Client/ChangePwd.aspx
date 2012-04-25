<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePwd.aspx.cs" Inherits="Client_ChangePwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<wl:Seo ID="seo" runat="server" Title=""/>
<link href="../Css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<center>
<form id="form1" runat="server">
  <div>
    <div id="wrapper">
      <div id="wrapper2">
        <!--头部-->
        <wl:HeaderClient ID="hc" runat="server" />  
        <!--内容-->
        <div id="content">
          <div id="main_client">
            <div class="left_bar_client">
              <!--中间左边导航部分-->
              <wl:Left ID="left" runat="server" />
            </div>
            <div class="right_bar_client">
              <table class="tablecontent">
                 <tr><td align="left" class="top_content"><wl:ClientTop runat="server" id="clientTop" Title="修改密码"></wl:ClientTop></td></tr> 
                 <tr><td align="center"><asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td></tr>
                 <tr>
                  <td><table class="grid">                
                <tr>
                  <td height="35px" class="label" style="width: 109px"> 原&nbsp;&nbsp;密&nbsp;&nbsp;码: </td>
                  <td class="content"><asp:TextBox ID="txtCurrentPwd" runat="server" TextMode="Password" Width="180"></asp:TextBox>
                  </td>
                </tr>
                <tr>
                  <td height="35px" class="label" style="width: 109px"> 新&nbsp;&nbsp;密&nbsp;&nbsp;码: </td>
                  <td class="content"><asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password" Width="180"></asp:TextBox>
                  </td>
                </tr>
                <tr>
                  <td height="35px" class="label" style="width: 109px"> 确认新密码: </td>
                  <td class="content"><asp:TextBox ID="txtReNewPwd" runat="server" TextMode="Password" Width="180"></asp:TextBox>
                  </td>
                </tr>                
                <tr>                  
                  <td colspan="2" align="center" height="35px"><asp:Button ID="btnUpdate" runat="server" Text="修 改" CssClass="button" OnClick="btnUpdate_Click"  />
                  </td>
                </tr>
              </table>
              </td>
              </tr>
              </table>
            </div>
          </div>
        </div>
        <!--尾部-->
        <wl:Footer ID="footer" runat="server" />
      </div>
    </div>
  </div>
</form>
</center>
</body>
</html>
