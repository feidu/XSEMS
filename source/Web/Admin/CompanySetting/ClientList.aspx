<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClientList.aspx.cs" Inherits="Admin_CompanySetting_ClientList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../JS/Calendar/WdatePicker.js"></script>
</head>
<body>
<form id="form1" runat="server">   
  <wl:CompanySettingNav ID="companySettingNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">公司设置 > 公司设定 > 客户列表</td>
    </tr>
    <tr>
        <td class="info"><a href="CreateClient.aspx">添加客户</a> | <a href="ClientList.aspx">客户列表</a>&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox 
                ID="txtKeyword" runat="server" Width="159px" class="textBox"></asp:TextBox>&nbsp;&nbsp;<asp:Button 
                ID="btnSearch" runat="server" Text="查 询" CssClass="button" 
                onclick="btnSearch_Click" /></td>
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
            <th align="center" class="header">用户名</th>
            <th align="center" class="header">真实姓名</th>
            <th align="center" class="header">手机</th>
            <th align="center" class="header">邮箱</th>
            <th align="center" class="header">余额</th>
            <th align="center" class="header">信用额度</th>
            <th align="center" class="header">操作</th>
            <th align="center" class="header">选择</th>
          </tr>
          <asp:Repeater ID="rpClient" runat="server">
            <ItemTemplate>
              <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                <td align="center"><asp:Label ID="lblId" runat="server"></asp:Label></td>
                <td align="left"><%# Eval("Username") %></td>
                <td align="left"><%# Eval("RealName") %></td>
                <td align="left"><%# Eval("Mobile") %></td>
                <td align="left"><%# Eval("Email") %></td>
                <td align="left"><%# Eval("Balance") %> 元</td>
                <td align="left"><asp:TextBox ID="txtCredit" runat="server" Width="70"></asp:TextBox>元</td>
                <td align="center"><a href="Client.aspx?id=<%# Eval("Id") %>">编辑</a>&nbsp;|&nbsp;<a href="changeClientPwd.aspx?id=<%#Eval("Id") %>">修改密码</a></td>
                <td align="center"><input id="chkId" name="chkId" type="checkbox" value="<%# Eval("Id")%>" /></td>
              </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
              <tr class="content" onmouseover="this.className = 'hover';" onmouseout="this.className = 'content';">
                <td align="center"><asp:Label ID="lblId" runat="server"></asp:Label></td>
                <td align="left"><%# Eval("Username") %></td>
                <td align="left"><%# Eval("RealName") %></td>
                <td align="left"><%# Eval("Mobile") %></td>
                <td align="left"><%# Eval("Email") %></td>
                <td align="left"><%# Eval("Balance") %> 元</td>
                <td align="left"><asp:TextBox ID="txtCredit" runat="server" Width="70"></asp:TextBox>元</td>
                <td align="center"><a href="Client.aspx?id=<%# Eval("Id") %>">编辑</a>&nbsp;|&nbsp;<a href="changeClientPwd.aspx?id=<%#Eval("Id") %>">修改密码</a></td>
                <td align="center"><input id="chkId" name="chkId" type="checkbox" value="<%# Eval("Id")%>" /></td>
              </tr>
            </AlternatingItemTemplate>
          </asp:Repeater>
          <tr>
                <td align="right" colspan="10">
                    <asp:Button ID="btnUpdate" runat="server" CssClass="button" Text="修 改" OnClick="btnUpdate_Click" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnDelete" runat="server" CssClass="button" Text="删除选择项" OnClientClick="return confirm('您确认要删除吗？')" OnClick="btnDelete_Click" /></td>
              </tr>
        </table>		
        </td>
    </tr>
  </table>
  <wl:Pagination ID="pagi" runat="server"/> 
</form>
</body>
</html>
