<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangeClientPwd.aspx.cs" Inherits="Admin_CompanySetting_ChangeClientPwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript" src="/Js/SelectCity.js"></script>
</head>
<body>
<form id="form1" runat="server">   
  <wl:CompanySettingNav ID="companySettingNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">公司设置 > 客户管理 > 修改客户密码</td>
    </tr>
    <tr>
        <td class="info"><a href="CreateClient.aspx">添加客户</a> | <a href="ClientList.aspx">客户列表</a></td>
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
              <td  width="20%"align="center" class="label" >新 密 码: </td>
              <td align="left" valign="middle" class="content" ><asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
              <td width="20%" align="center" class="label" >确认密码:</td>
              <td align="left" valign="middle" class="content" ><asp:TextBox ID="txtReNewPwd" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
              <td align="center" colspan="2"><asp:Button ID="btnUpdate" runat="server" CssClass="button" Text="修 改" OnClick="btnUpdate_Click" />&nbsp;&nbsp;&nbsp;<input type="button" class="button" value="返 回" onclick="javascript:location.href='ClientList.aspx';" /></td>
            </tr>
          </table>		
        </td>
    </tr>
  </table>
</form>
</body>
</html>

