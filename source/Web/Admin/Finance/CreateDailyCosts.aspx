<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateDailyCosts.aspx.cs" Inherits="Admin_Finance_CreateDailyCosts" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="/Admin/JS/Calendar/WdatePicker.js"></script>
</head>
<body>
<form id="form1" runat="server">   
  <wl:FinanceNav ID="financeNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">财务管理 > 日常费用 > 添加日常费用</td>
    </tr>
    <tr>
        <td class="info"></td>
    </tr>
    <tr>
        <td class="seperator"></td>
    </tr>
  </table>
  <table class="tablecontent">
    <tr><td align="center" style="height:21px">
        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td></tr>
    <tr>
      <td><table class="grid">  
              <tr>
                <td class="label" width="9%">产生日期:</td>
                <td class="content" width="91%"><input type="text" onclick="WdatePicker()" runat="server" id="txtOrderTime" /></td>
              </tr>              
              <tr>
                <td class="label" >员工姓名:</td>
                <td class="content"><asp:DropDownList ID="ddlCompanyUsers" runat="server"></asp:DropDownList></td>
              </tr>
              <tr>
                <td class="label" >费用类型:</td>   
                <td class="content"><wl:CostsTypeDropDownList ID="ddlCostsType" runat="server"></wl:CostsTypeDropDownList></td>
              </tr>   
              <tr>
                <td class="label" >摘&nbsp;&nbsp;&nbsp;&nbsp;要:</td>
                <td class="content"><asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Width="580" Columns="4"></asp:TextBox></td>
              </tr>            
              <tr>
                <td class="label" >金&nbsp;&nbsp;&nbsp;&nbsp;额:</td>
                <td class="content"><asp:TextBox ID="txtMoney" runat="server" Width="180"></asp:TextBox>元</td>
              </tr>  
              
                <tr><td colspan="2" align="center"><asp:Button ID="btnSubmit" runat="server" CssClass="button" Text="提 交" OnClick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;<input type="button" class="button" value="返 回" onclick="javascript:location.href='DailyCosts.aspx'"/></td></tr>
            </table>		
        </td>
    </tr>
  </table>
</form>
</body>
</html>

