<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShouldReceiveView.aspx.cs" Inherits="Admin_Finance_ShouldReceiveView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">   
  <wl:FinanceNav ID="financeNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">财务管理 > 应收账款 > 应收账款详情</td>
    </tr>
    <tr>
        <td class="seperator"></td>
    </tr>
  </table>
  <table class="tablecontent">
    <tr><td align="center"><asp:Label ID="lblMsg" runat="server" ForeColor="red" ></asp:Label></td></tr>
    <tr>
      <td><table class="grid">  
              <tr>
                <td width="9%" class="label" >应收款号:</td>
                <td width="91%" class="content"><asp:Label ID="lblEncode" runat="server" Text=""></asp:Label></td>
              </tr> 
              <tr>
                <td class="label" >应收类型:</td>
                <td class="content"><asp:Label ID="lblType" runat="server" Text=""></asp:Label></td>
              </tr>
              <tr>
                <td class="label" >应收日期:</td>
                <td class="content"><asp:Label ID="lblReceivedTime" runat="server" Text=""></asp:Label></td>
              </tr>
              <tr>
                <td class="label" >客户姓名:</td>   
                <td class="content"><asp:Label ID="lblClientName" runat="server" Text=""></asp:Label></td>
              </tr>                   
              <tr>
                <td class="label" >应收金额:</td>
                <td class="content"><asp:TextBox ID="txtMoney" runat="server" Width="80"></asp:TextBox> 元</td>
              </tr>         
              <tr>
                <td class="label" >收件单号:</td>
                <td class="content"><asp:Label ID="lblOrderEncode" runat="server" Text=""></asp:Label></td>
              </tr>
              <tr>
                <td class="label" >收件日期:</td>   
                <td class="content"><asp:Label ID="lblOrderReceiveDate" runat="server" Text=""></asp:Label></td>
              </tr>  
              <tr style="display:none;">
                <td class="label" >备&nbsp;&nbsp;&nbsp;&nbsp;注:</td>
                <td class="content"><asp:Label ID="lblRemark" runat="server" Text=""></asp:Label></td>
              </tr>
              <tr>
                <td class="label" >制 单 人:</td>
                <td class="content"><asp:Label ID="lblUsername" runat="server" Text=""></asp:Label></td>
              </tr>  
              <tr>
                <td class="label" >制单时间:</td>
                <td class="content"><asp:Label ID="lblCreateTime" runat="server" Text=""></asp:Label></td>
              </tr>     
              <tr><td align="center" colspan="2"><span style="display:none;"><asp:Button ID="btnUpdate" CssClass="button" runat="server" Text="修 改" OnClick="btnUpdate_Click" />&nbsp;&nbsp;&nbsp;</span><input type="button" class="button" value="返 回" onclick="javascript:history.go(-1);" /></td></tr>            
            </table>
        </td>
    </tr>
  </table>
</form>
</body>
</html>
