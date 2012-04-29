<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PersonalNavigation.ascx.cs" Inherits="Admin_Controls_PersonalNavigation" %>
<table cellpadding="0" cellspacing="0" class="nav">
    <tr>
      <td class="img"><img src="../Images/icon_log.gif" width="32" height="32" alt="" /></td>
      <td class="title"><%=Title %></td>
    </tr>
    <tr>
      <td colspan="2" class="line"></td>
    </tr>
    <tr>
      <td colspan="2" class="info"><a href="../Personal/">我的信息</a> | <a href="../Personal/ChangePwd.aspx">修改密码</a></td>
    </tr>
    <tr>
      <td colspan="2" class="seperator"></td>
    </tr>
  </table>