<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_CompanySetting_Default" %>

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
        <td class="info2">公司设置 > 公司设定 > 公司详情</td>
    </tr>
    <tr>
        <td class="info"><a href="CreateDepartment.aspx">添加部门</a> | <a href="DepartmentList.aspx">部门列表</a> | <a href="CreatePosition.aspx">添加职位</a> | <a href="PositionList.aspx">职位列表</a></td>
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
                      <td class="label" width="12%"> 公司名称: </td>
                      <td class="content" width="88%"><asp:TextBox ID="txtName" runat="server" Width="180"></asp:TextBox>
                      </td>
                    </tr>
                    <tr>
                      <td class="label"> 联 系 人: </td>
                      <td class="content"><asp:TextBox ID="txtContactPerson" runat="server" Width="180" ></asp:TextBox>
                      </td>
                    </tr>
                    <tr>
                      <td class="label"> 联系电话: </td>
                      <td class="content"><asp:TextBox ID="txtPhone" runat="server" Width="180" ></asp:TextBox>
                      </td>
                    </tr> 
                    <tr>
                      <td class="label"> 电子邮箱: </td>
                      <td class="content"><asp:TextBox ID="txtEmail" runat="server" Width="180" ></asp:TextBox>    
                      </td>
                    </tr> 
                    <tr>
                      <td class="label"> 邮箱密码: </td>
                      <td class="content"><asp:TextBox ID="txtPassword" TextMode="password" runat="server" Width="180"></asp:TextBox>
                      </td>
                    </tr> 
                    <tr>
                      <td class="label"> 邮箱SMTP: </td>
                      <td class="content"><asp:TextBox ID="txtSmtp" runat="server" Width="180" ></asp:TextBox>    
                      </td>
                    </tr>  
<%--                    <tr>
                      <td class="label"> 提&nbsp;&nbsp;&nbsp;&nbsp;成: </td>
                      <td class="content"><asp:TextBox ID="txtCommission" runat="server" Width="180" Enabled="false"></asp:TextBox>
                      </td>
                    </tr>          
                    <tr>
                      <td class="label"> 所属区域: </td>
                      <td class="content">
                          <asp:DropDownList ID="ddlAreaCode" runat="server" Enabled="false">
                          <asp:ListItem Value="1" Text="华中"></asp:ListItem>
                          <asp:ListItem Value="2" Text="华东"></asp:ListItem>
                          <asp:ListItem Value="3" Text="华南"></asp:ListItem>
                          <asp:ListItem Value="4" Text="华北"></asp:ListItem>
                          </asp:DropDownList>                     
                      </td>
                    </tr>--%>
                    <tr>
                      <td class="label"> QQ: </td>
                      <td class="content"><asp:TextBox ID="txtQQ" runat="server" Width="180"></asp:TextBox>
                      </td>
                    </tr> 
                    <tr>
                      <td class="label"> MSN: </td>
                      <td class="content"><asp:TextBox ID="txtMSN" runat="server" Width="180" ></asp:TextBox>
                      </td>
                    </tr> 
                    <tr>
                      <td class="label"> 公司地址: </td>
                      <td class="content"><asp:TextBox ID="txtAddress" runat="server" Width="280"></asp:TextBox>
                      </td>
                    </tr>
                     <tr><td colspan="2" align="center"><asp:Button ID="btnUpdate" runat="server" CssClass="button" Text="修 改" OnClick="btnUpdate_Click" /></td></tr>                    
                </table>		
        </td>
    </tr>
  </table>
</form>
</body>
</html>