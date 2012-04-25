<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserOpreator.aspx.cs" Inherits="Admin_PostSetting_UserOpreator" %>

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
        <td class="info2">物流设置 > 公司设定 > 修改员工权限</td>
    </tr>
    <tr>
        <td class="info"><a href="CreateCompany.aspx">添加公司</a> | <a href="Default.aspx">公司列表</a> | <a href="UserList.aspx">员工列表</a></td>
    </tr>
    <tr>
        <td class="seperator"></td>
    </tr>
  </table>
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
      <td colspan="2" style=" padding:5px 0px 1px 0px;">【 <span style="color:Maroon;"><%=username %> </span>】的权限：
      </td>
    </tr>
    <tr>
      <td colspan="2" class="seperator"></td>
    </tr>
  </table>
  <table class="tablecontent">
    <tr><td align="center">
        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td></tr>
    <tr>
      <td><table class="grid">
          <tr>
            <th align="center" class="header">编号</th>
            <th align="center" class="header">名称</th>
            <th align="center" class="header">访问</th>
          </tr>
          <asp:Repeater ID="rpModule" runat="server">
            <ItemTemplate>
              <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                <td align="center"><asp:Label ID="lblId" runat="server"></asp:Label></td>
                <td align="left">&nbsp;<%# Eval("Name") %></td>
                <td align="center"><asp:CheckBox ID="chkAccess" runat="server"/></td>
              </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
              <tr class="content" onmouseover="this.className = 'hover';" onmouseout="this.className = 'content';">
                <td align="center"><asp:Label ID="lblId" runat="server"></asp:Label></td>
                <td align="left">&nbsp;<%# Eval("Name") %></td>
                <td align="center"><asp:CheckBox ID="chkAccess" runat="server"/></td>
              </tr>
            </AlternatingItemTemplate>
          </asp:Repeater>
          <tr>
                <td align="center" colspan="12">
                    <asp:Button ID="btnUpdate" runat="server" CssClass="button" Text="修 改" OnClick="btnUpdate_Click" />&nbsp;&nbsp;&nbsp;<input type="button" class="button" value="返 回" onclick="javascript:location.href='UserList.aspx';" /></td>
              </tr>
        </table>		
        </td>
    </tr>
  </table>
</form>
</body>
</html>
