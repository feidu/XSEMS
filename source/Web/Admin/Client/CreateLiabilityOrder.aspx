<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateLiabilityOrder.aspx.cs" Inherits="Admin_Client_CreateLiabilityOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="/Admin/JS/Calendar/WdatePicker.js"></script>
</head>
<body>
<form id="form1" runat="server">   
  <wl:ClientNav ID="clientNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">客户服务 > 责任认定 > 添加责任认定</td>
    </tr>
    <tr>
        <td class="info"><a href="CreateLiabilityOrder.aspx">新增记录</a> | <a href="LiabilityList.aspx">责任认定列表</a></td>
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
            <td width="12%" class="label" >收件单号:</td>
            <td width="38%" class="content"><asp:TextBox ID="txtOrderEncode" Width="180" runat="server"></asp:TextBox></td>
            <td width="12%" class="label" >事件类型</td>
            <td width="38%" class="content"><wl:LiabilityEventTypeDropDownList ID="ddlEventType" runat="server"></wl:LiabilityEventTypeDropDownList></td>            
          </tr>
          <tr>            
            <td class="label" >填 表 人:</td>
            <td class="content"><asp:TextBox ID="txtFillUser" Width="180" runat="server"></asp:TextBox></td>           
            <td class="label" >填表日期:</td>
            <td class="content"><input type="text" onclick="WdatePicker()" class="Wdate" runat="server" id="txtFillTime" size="32" readonly="readonly" /></td>
          </tr>         
          <tr>
            <td class="label" >事情经过:</td>
            <td class="content" colspan="3"><asp:TextBox ID="txtDetail" TextMode="multiLine" Rows="4" Width="100%" runat="server"></asp:TextBox></td>          
          </tr>                          
         </table>		
        </td>
    </tr>
    <tr><td align="center"><asp:Button ID="btnCreate" runat="server" Text="添 加" CssClass="button" OnClick="btnCreate_Click" />&nbsp;&nbsp;&nbsp;<input type="button" class="button" value="返 回" onclick="javascript:location.href='LiabilityList.aspx';" /></td></tr>    
  </table>
</form>
</body>
</html>