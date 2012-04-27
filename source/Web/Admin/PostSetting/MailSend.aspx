<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MailSend.aspx.cs" Inherits="Admin_PostSetting_MailSend" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../JS/Calendar/WdatePicker.js"></script>
</head>
<body>
<form id="form1" runat="server">   
  <wl:PostSettingNav ID="postSettingNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">物流设置 > 客户邮件群发</td>
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
                        <td class="label" width="12%">所属公司:</td>   
                        <%--<td class="content" width="88%"><asp:DropDownList ID="ddlCompany" runat="server"></asp:DropDownList>--%>
                        <td class ="content"  width = "88%" ><asp:Label ID="lblCompany" runat="server" Text="" ForeColor="maroon"></asp:Label></td>
                    </tr>     
                    <tr>
                      <td class="label"> 邮件标题: </td>
                      <td class="content"><asp:TextBox ID="txtTitle" runat="server" Width="80%"></asp:TextBox>
                      </td>
                    </tr>
                    <tr>
                      <td class="label"> 邮件内容: </td>
                      <td class="content"><asp:TextBox ID="txtContent" TextMode="multiLine" Rows="13" runat="server" Width="80%"></asp:TextBox>
                      </td>
                    </tr>                    
                    <tr><td colspan="2" align="center"><asp:Button ID="btnSend" runat="server" CssClass="button" Text="发 送" OnClick="btnSend_Click" /></td></tr>
                </table>		
        </td>
    </tr>
  </table>
</form>
</body>
</html>
