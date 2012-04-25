<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_User_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">   
  <wl:UserNav ID="userNav" runat="server" Title="员工列表" />
  <table class="tablecontent">
    <tr><td align="center">
        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td></tr>
    <tr>
      <td><table class="grid">
          <tr>
            <th align="center" class="header">编号</th>
            <th align="center" class="header">用户名</th>
            <th align="center" class="header">真实姓名</th>
            <th align="center" class="header">性别</th>
            <th align="center" class="header">学历</th>
            <th align="center" class="header">手机</th>
            <th align="center" class="header">邮箱</th>
            <th align="center" class="header">入职时间</th>
            <th align="center" class="header">合同有效期</th>
            <th align="center" class="header">提成</th>
            <th align="center" class="header">操作</th>
            <th align="center" class="header">选择</th>
          </tr>
          <asp:Repeater ID="rpUser" runat="server">
            <ItemTemplate>
              <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                <td align="center"><%# Eval("Id") %></td>
                <td align="left"><%# Eval("Username") %></td>
                <td align="left"><%# Eval("RealName") %></td>
                <td align="left"><%# Convert.ToBoolean(Eval("Sex")) ? "男" : "女"%></td>
                <td align="left"><%# Eval("Education") %></td>
                <td align="left"><%# Eval("Mobile") %></td>
                <td align="left"><%# Eval("Email") %></td>
                <td align="left"><%# Convert.IsDBNull(Eval("JoinDate")) ? "" : Convert.ToDateTime(Eval("JoinDate")).ToShortDateString()%></td>
                <td align="left"><%# Convert.IsDBNull(Eval("ContractDate")) ? "" : Convert.ToDateTime(Eval("ContractDate")).ToShortDateString()%></td>
                <td align="left"><%# Backend.Utilities.StringHelper.CurtNumber(Convert.ToString(Eval("Commission"))) %></td>
                <td align="center"><a href="User.aspx?id=<%# Eval("Id") %>">编辑</a></td>
                <td align="center"><input id="chkId" name="chkId" type="checkbox" value="<%# Eval("Id")%>" /></td>
              </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
              <tr class="content" onmouseover="this.className = 'hover';" onmouseout="this.className = 'content';">
                <td align="center"><%# Eval("Id") %></td>
                <td align="left"><%# Eval("Username") %></td>
                <td align="left"><%# Eval("RealName") %></td>
                <td align="left"><%# Convert.ToBoolean(Eval("Sex")) ? "男" : "女"%></td>
                <td align="left"><%# Eval("Education") %></td>
                <td align="left"><%# Eval("Mobile") %></td>
                <td align="left"><%# Eval("Email") %></td>
                <td align="left"><%# Convert.IsDBNull(Eval("JoinDate")) ? "" : Convert.ToDateTime(Eval("JoinDate")).ToShortDateString()%></td>
                <td align="left"><%# Convert.IsDBNull(Eval("ContractDate")) ? "" : Convert.ToDateTime(Eval("ContractDate")).ToShortDateString()%></td>
                <td align="left"><%# Backend.Utilities.StringHelper.CurtNumber(Convert.ToString(Eval("Commission"))) %></td>
                <td align="center"><a href="User.aspx?id=<%# Eval("Id") %>">编辑</a></td>
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
