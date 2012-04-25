<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePwd.aspx.cs" Inherits="Admin_Personal_ChangePwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>修改密码</title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />

</head>
<body>
<form id="form1" runat="server">
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
      <td class="img"><img src="../Images/icon_log.gif" width="32" height="32" alt="" /></td>
      <td class="title">修改密码</td>
    </tr>
    <tr>
      <td colspan="2" class="line"></td>
    </tr>
    <tr>
      <td colspan="2" class="info"></td>
    </tr>
    <tr>
      <td colspan="2" class="seperator"></td>
    </tr>
  </table>
  <table class="tablecontent">
    <tr>
      <td>
          <table class="grid" >      
            <tr><td colspan="2" align="center"><asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red" /></td></tr>      
            <tr>
              <td  width="20%" align="center" class="label" >原 密 码: </td>
              <td align="left" valign="middle" class="content" ><asp:TextBox ID="txtCurrentPwd" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
              <td  width="20%"align="center" class="label" >新 密 码: </td>
              <td align="left" valign="middle" class="content" ><asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
              <td width="20%" align="center" class="label" >确认密码:</td>
              <td align="left" valign="middle" class="content" ><asp:TextBox ID="txtReNewPwd" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
              <td align="right"><asp:Button ID="btnUpdate" runat="server" CssClass="button" Text="确认修改" OnClick="btnUpdate_Click" /></td>
              <td align="center">&nbsp;</td>
            </tr>
          </table>
          </td>
    </tr>
  </table>
    </form>
</body>
</html>
