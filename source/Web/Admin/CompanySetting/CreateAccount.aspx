<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateAccount.aspx.cs" Inherits="Admin_CompanySetting_CreateAccount" %>

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
        <td class="info2">公司设置 > 添加收款账号</td>
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
                      <td class="label" width="14%"> 账 户 名： </td>
                      <td class="content" width="86%"><asp:TextBox ID="txtAccountName" runat="server" Width="180"></asp:TextBox>
                      </td>
                    </tr>            
                    <tr>
                      <td class="label"> 账&nbsp;&nbsp;&nbsp;&nbsp;号： </td>
                      <td class="content"><asp:TextBox ID="txtAccountNumber" runat="server" Width="180"></asp:TextBox>
                      </td>
                    </tr>                    
                    <tr>
                      <td class="label"> 开户银行/支付平台： </td>
                      <td class="content"><asp:TextBox ID="txtBankName" runat="server" Width="180"></asp:TextBox>
                      </td>
                    </tr>                              
                    <tr>
                      <td class="label"> 备&nbsp;&nbsp;&nbsp;&nbsp;注： </td>
                      <td class="content"><asp:TextBox ID="txtRemark" runat="server" Width="580" TextMode="MultiLine" Rows="2"></asp:TextBox>
                      </td>
                    </tr>
                    <tr><td colspan="2" align="center"><asp:Button ID="btnCreate" runat="server" CssClass="button" Text="添 加" OnClick="btnCreate_Click" />&nbsp;&nbsp;&nbsp;<input type="button" class="button" value="返 回" onclick="javascript:location.href='AccountList.aspx';" /></td></tr>
                </table>		
        </td>
    </tr>
  </table>
</form>
</body>
</html>
