<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePwd.aspx.cs" Inherits="Admin_PostSetting_ChangePwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../JS/Calendar/WdatePicker.js"></script>
</head>
<body>
<form id="form1" runat="server">   
  <wl:PostSettingNav ID="postSettingNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">物流设置 > 公司设定 > 修改员工密码</td>
    </tr>
    <tr>
        <td class="info"><a href="CreateCompany.aspx">添加公司</a> | <a href="Default.aspx">公司列表</a> | <a href="UserList.aspx">员工列表</a></td>
    </tr>
    <tr>
        <td class="seperator"></td>
    </tr>
  </table>
  <table class="tablecontent">
    <tr><td align="center">
        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td></tr>
    <tr>
      <td><table class="grid" >
            <tr>
              <td align="left" class="label" colspan="2" height="32px" valign="middle">员工姓名: <span style=" font-size:12px; color:Maroon;"><%=user.RealName %></span> </td>
            </tr>
            <tr>
              <td width="15%" align="left" class="label" >新 密 码: </td>
              <td width="85%" align="left" valign="middle" class="content" ><asp:TextBox ID="txtNewPwd" runat="server" Width="180" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
              <td align="left" class="label" >确认密码:</td>
              <td align="left" valign="middle" class="content" ><asp:TextBox ID="txtReNewPwd" runat="server" Width="180" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
              <td align="center" colspan="2"><asp:Button ID="btnUpdate" runat="server" CssClass="button" Text="修 改" OnClick="btnUpdate_Click" />&nbsp;&nbsp;&nbsp;<input type="button" class="button" value="返 回" onclick="javascript:location.href='UserList.aspx';" /></td>
            </tr>
          </table>		
        </td>
    </tr>
  </table>
</form>
</body>
</html>