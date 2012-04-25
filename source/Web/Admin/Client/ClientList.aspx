<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClientList.aspx.cs" Inherits="Admin_Client_ClientList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">   
  <wl:ClientNav ID="clientNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">客户服务 > 客户管理 > 客户列表</td>
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
      <td><table class="grid">
          <tr>
            <th align="center" class="header">编号</th>
            <th align="center" class="header">真实姓名</th>
            <th align="center" class="header">地区</th>
            <th align="center" class="header">手机</th>
            <th align="center" class="header">邮箱</th>
            <th align="center" class="header">余额</th>
            <th align="center" class="header">信用额度</th>
            <th align="center" class="header">查看</th>
            <th align="center" class="header">选择</th>
          </tr>
          <asp:Repeater ID="rpClient" runat="server">
            <ItemTemplate>
              <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                <td align="center"><%# Eval("Id") %></td>
                <td align="left"><%# Eval("RealName") %></td>
                <td align="left"><%# Eval("Province").ToString()+" "+Eval("City").ToString() %></td>
                <td align="left"><%# Eval("Mobile") %></td>
                <td align="left"><%# Eval("Email") %></td>
                <td align="left"><%# Eval("Balance") %> 元</td>
                <td align="left"><%# Backend.Utilities.StringHelper.CurtNumber(Convert.ToString(Eval("Credit")))%> 元</td>
                <td align="center"><a href="Client.aspx?id=<%# Eval("Id") %>">查看</a></td>
                <td align="center"><input id="chkId" name="chkId" type="checkbox" value="<%# Eval("Id")%>" /></td>
              </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
              <tr class="content" onmouseover="this.className = 'hover';" onmouseout="this.className = 'content';">
                <td align="center"><%# Eval("Id") %></td>
                <td align="left"><%# Eval("RealName") %></td>
                <td align="left"><%# Eval("Province").ToString()+" "+Eval("City").ToString() %></td>
                <td align="left"><%# Eval("Mobile") %></td>
                <td align="left"><%# Eval("Email") %></td>
                <td align="left"><%# Eval("Balance") %> 元</td>
                <td align="left"><%# Backend.Utilities.StringHelper.CurtNumber(Convert.ToString(Eval("Credit")))%> 元</td>
                <td align="center"><a href="Client.aspx?id=<%# Eval("Id") %>">查看</a></td>
                <td align="center"><input id="chkId" name="chkId" type="checkbox" value="<%# Eval("Id")%>" /></td>
              </tr>
            </AlternatingItemTemplate>
          </asp:Repeater>          
        </table>		
        </td>
    </tr>
  </table>
  <wl:Pagination ID="pagi" runat="server"/>  
</form>
</body>
</html>
