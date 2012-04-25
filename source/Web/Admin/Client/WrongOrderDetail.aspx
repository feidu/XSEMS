<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WrongOrderDetail.aspx.cs" Inherits="Admin_Client_WrongOrderDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript" src="/Js/SelectCity.js"></script>
</head>
<body>
<form id="form1" runat="server">   
  <wl:ClientNav ID="clientNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">客户服务 > 问题件 > 问题件明细</td>
    </tr>
    <tr>
        <td class="info"><a href="CreateWrongOrder.aspx">添加问题件</a> | <a href="Default.aspx">问题件列表</a></td>
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
              <td class="label" width="12%"> 处理方式及过程: </td>
              <td class="content" width="88%"><asp:TextBox ID="txtDetail" runat="server" TextMode="MultiLine" Width="99%" Rows="3"></asp:TextBox>
              </td>
            </tr>
            <tr>
              <td class="label"> 处理结果: </td>
              <td class="content"><wl:WrongOrderStatusDropDownList ID="ddlStatus" runat="server"></wl:WrongOrderStatusDropDownList></td>
            </tr>
            <tr>
              <td class="label"> 是否发邮件: </td>
              <td class="content"><asp:CheckBox ID="chkIsMail" runat="server" Checked="true" /></td>
            </tr>
                 
            <tr><td colspan="2" align="center"><asp:Button ID="btnUpdate" runat="server" CssClass="button" Text="修 改" OnClick="btnUpdate_Click" />&nbsp;&nbsp;&nbsp;<input type="button" class="button" value="返 回" onclick="javascript:location.href='/Admin/Client/WrongOrder.aspx?id=<%=wod.WrongOrderId %>'"/></td></tr>
        </table>		
        </td>
    </tr>
  </table>
</form>
</body>
</html>