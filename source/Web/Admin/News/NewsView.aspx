<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewsView.aspx.cs" Inherits="Admin_News_NewsView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>公告内容</title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />

</head>
<body>
<form id="form1" runat="server">
 <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
      <td class="img"><img src="../Images/icon_default.gif" width="32" height="32" alt="" /></td>
      <td class="title">公告内容</td>
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
      <td><table class="grid">
          <tr>
            <td width="85" align="left" valign="middle" class="label">标&nbsp;&nbsp;&nbsp;&nbsp;题: </td>
            <td align="left" valign="middle" class="content"><asp:Label ID="lblTitle" runat="server" ></asp:Label></td>
          </tr>
          <tr>
            <td width="85" align="left" valign="middle" class="label">添加时间: </td>
            <td align="left" valign="middle" class="content"><asp:Label ID="lblCreateTime" runat="server" ></asp:Label></td>
          </tr>
          <tr>
            <td align="left" valign="middle" class="label">内&nbsp;&nbsp;&nbsp;&nbsp;容:</td>
            <td align="left" valign="middle" class="content"><asp:Label ID="lblContent" runat="server" ></asp:Label></td>
          </tr>
       </table></td>
    </tr>
  </table>
    </form>
</body>
</html>
