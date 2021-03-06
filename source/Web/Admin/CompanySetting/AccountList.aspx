﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AccountList.aspx.cs" Inherits="Admin_CompanySetting_AccountList" %>

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
        <td class="info2">公司设置 > 公司设定 > 收款账号列表</td>
    </tr>
    <tr>
        <td class="info"><a href="CreateAccount.aspx">添加收款账号</a> | <a href="AccountList.aspx">收款账号列表</a></td>
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
            <th align="left" class="header">开户银行/支付平台</th>
            <th align="left" class="header">账户名</th>
            <th align="left" class="header">账号</th>
            <th align="left" class="header">备注</th>            
            <th align="center" class="header">查看</th>
            <th align="center" class="header">选择</th>
          </tr>
          <asp:Repeater ID="rpReceivableAccount" runat="server">
            <ItemTemplate>
              <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                <td align="center"><%# Eval("Id") %></td>
                <td align="left"><%# Eval("BankName") %></td>
                <td align="left"><%# Eval("AccountName") %></td>
                <td align="left"><%# Eval("AccountNumber") %></td>
                <td align="left"><%# Eval("Remark")%></td>
                <td align="center"><a href="Account.aspx?id=<%# Eval("Id") %>">查看</a></td>
                <td align="center"><input id="chkId" name="chkId" type="checkbox" value="<%# Eval("Id")%>" /></td>
              </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
              <tr class="content" onmouseover="this.className = 'hover';" onmouseout="this.className = 'content';">
                <td align="center"><%# Eval("Id") %></td>
                <td align="left"><%# Eval("CompanyName") %></td>
                <td align="left"><%# Eval("BankName") %></td>
                <td align="left"><%# Eval("AccountName") %></td>
                <td align="left"><%# Eval("AccountNumber") %></td>
                <td align="left"><%# Eval("Remark")%></td>
                <td align="center"><a href="Account.aspx?id=<%# Eval("Id") %>">查看</a></td>
                <td align="center"><input id="chkId" name="chkId" type="checkbox" value="<%# Eval("Id")%>" /></td>
              </tr>
            </AlternatingItemTemplate>
          </asp:Repeater>
          <tr>
                <td align="right" colspan="8">
                    <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="删除选择项" OnClientClick="return confirm('您确认要删除吗？')" OnClick="btnDelete_Click" /></td>
              </tr>
        </table>		
        </td>
    </tr>
  </table>
</form>
</body>
</html>
