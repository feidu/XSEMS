<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserNavigation.ascx.cs" Inherits="Admin_Controls_UserNavigation" %>
<table cellpadding="0" cellspacing="0" class="nav">
    <tr>
      <td class="img"><img src="../Images/icon_user.gif" width="32" height="32" alt="" /></td>
      <td class="title"><%=Title %></td>
    </tr>
    <tr>
      <td colspan="2" class="line"></td>
    </tr>
    <tr>
      <td colspan="2" class="info"><a href="/Admin/User/">员工列表</a> | <a href="/Admin/User/Create.aspx">添加员工</a></td>
    </tr>
    <tr>
      <td colspan="2" class="seperator"></td>
    </tr>
  </table>