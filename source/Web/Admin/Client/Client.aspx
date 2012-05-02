<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Client.aspx.cs" Inherits="Admin_Client_Client" %>

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
        <td class="info2">客户服务 > 客户管理 > 客户详情</td>
    </tr>
    <tr>
        <td class="info"><a href="CreateClient.aspx">添加客户</a> | <a href="ClientList.aspx">客户列表</a></td>
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
                      <td class="label" width="13%"> 真实姓名: </td>
                      <td class="content" width="87%"><asp:TextBox ID="txtRealName" runat="server" Width="180"></asp:TextBox>
                      </td>
                    </tr>
                    <tr>
                      <td class="label"> 身份证号: </td>
                      <td class="content"><asp:TextBox ID="txtIdCard" runat="server" Width="180"></asp:TextBox>
                      </td>
                    </tr>
                    <tr>
                      <td class="label"> 联系电话: </td>
                      <td class="content"><asp:TextBox ID="txtPhone" runat="server" Width="180"></asp:TextBox>
                      </td>
                    </tr>
                    <tr>
                      <td class="label"> 手&nbsp;&nbsp;&nbsp;&nbsp;机: </td>
                      <td class="content"><asp:TextBox ID="txtMobile" runat="server" Width="180"></asp:TextBox>
                      </td>
                    </tr>
                    <tr>
                      <td class="label"> 电子邮箱: </td>
                      <td class="content"><asp:TextBox ID="txtEmail" runat="server" Width="180"></asp:TextBox>
                      </td>
                    </tr>                    
                    <tr>
                      <td class="label"> 联系地址: </td>
                      <td class="content"><asp:TextBox ID="txtAddress" runat="server" Width="280"></asp:TextBox>
                      </td>                  
                    </tr>                        
                    <tr>
				      <td class="label">是否使用邮件服务: </td>
                      <td class="content"><asp:CheckBox ID="chkIsMessage" runat="server" />
                      </td>
				    </tr>  				      
				    <tr>
                      <td class="label"> 帐户余额: </td>
                      <td class="content"><span style="text-decoration:underline">
                        <asp:Label ID="lblBalance" runat="server" Text=""></asp:Label></span>
                      </td>
                    </tr>  
                    <tr>
                      <td class="label"> 信用额度: </td>
                      <td class="content"><asp:Label ID="lblCredit" runat="server"></asp:Label>
                      </td>
                    </tr>
                    <tr><td colspan="2" align="center"><asp:Button ID="btnUpdate" runat="server" CssClass="button" Text="修 改" OnClick="btnUpdate_Click" />&nbsp;&nbsp;&nbsp;<input type="button" class="button" value="返 回" onclick="javascript:location.href='ClientList.aspx';" /></td></tr>
                </table>		
        </td>
    </tr>
  </table>
</form>
</body>
</html>
