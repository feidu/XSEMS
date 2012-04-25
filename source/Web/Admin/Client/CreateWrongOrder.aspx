<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateWrongOrder.aspx.cs" Inherits="Admin_Client_CreateWrongOrder" %>

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
        <td class="info2">客户服务 > 问题件 > 添加问题件</td>
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
                      <td class="label" width="12%"> 收件单号: </td>
                      <td class="content" width="88%"><asp:TextBox ID="txtOrderEncode" runat="server" Width="180"></asp:TextBox>
                      </td>
                    </tr>
                    <tr>
                      <td class="label"> 问题类型: </td>
                      <td class="content"><select id="slWrongType" runat="server">
                              <option value="未收到">未收到 </option>                             
                              <option value="损坏">损坏 </option>
                              <option value="差错">差错</option>
                              <option value="海关因素">海关因素 </option>                              
                          </select> 
                      </td>
                    </tr>
                    <tr>
                      <td class="label"> 问题内容: </td>
                      <td class="content"><asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine" Width="99%" Rows="3"></asp:TextBox></td>
                    </tr>
                         
                    <tr><td colspan="2" align="center"><asp:Button ID="btnCreate" runat="server" CssClass="button" Text="添 加" OnClick="btnCreate_Click" />&nbsp;&nbsp;&nbsp;<input type="button" class="button" value="返 回" onclick="javascript:location.href='Default.aspx';" /></td></tr>
                </table>		
        </td>
    </tr>
  </table>
</form>
</body>
</html>

