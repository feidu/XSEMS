<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Personal_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">   
  <wl:PersonalNav ID="personalNav" runat="server" Title="我的信息" />
  <table class="tablecontent">
    <tr><td align="center"><asp:Label ID="lblMsg" runat="server" ForeColor="red"></asp:Label></td></tr>
    <tr>
      <td><table class="grid">    
                    <tr>
                      <td class="label" width="12%"> 所属公司: </td>
                      <td class="content" width="88%"><asp:Label ID="lblCompany" runat="server" Text="" ForeColor="maroon"></asp:Label> </td>
                    </tr> 
                    <tr>
                      <td class="label"> 用 户 名: </td>
                      <td class="content"><asp:Label ID="lblUsername" runat="server" Text=""></asp:Label> </td>
                    </tr>                                
                    <tr>
                      <td class="label"> 真实姓名: </td>
                      <td class="content"><asp:Label ID="lblRealName" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                      <td class="label"> 性&nbsp;&nbsp;&nbsp;&nbsp;别: </td>
                      <td class="content"><asp:Label ID="lblSex" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                      <td class="label"> 民&nbsp;&nbsp;&nbsp;&nbsp;族: </td>
                      <td class="content"><asp:Label ID="lblNation" runat="server" Text=""></asp:Label></td>
                    </tr>                    
                    <tr>
                      <td class="label"> 学&nbsp;&nbsp;&nbsp;&nbsp;历: </td>
                      <td class="content"><asp:Label ID="lblEducation" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                      <td class="label"> 婚姻状况: </td>
                      <td class="content"><asp:Label ID="lblMaritalStatus" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                      <td class="label"> 出生日期: </td>
                      <td class="content"><asp:Label ID="lblBirthday" runat="server" Text=""></asp:Label></td>
                    </tr>                    
                    <tr>
                      <td class="label"> 身份证号: </td>
                      <td class="content"><asp:Label ID="lblIdCard" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                      <td class="label"> 联系电话: </td>
                      <td class="content"><asp:TextBox ID="txtPhone" runat="server" Width="180"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td class="label"> 手&nbsp;&nbsp;&nbsp;&nbsp;机: </td>
                      <td class="content"><asp:TextBox ID="txtMobile" runat="server" Width="180"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td class="label"> 电子邮箱: </td>
                      <td class="content"><asp:TextBox ID="txtEmail" runat="server" Width="180"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td class="label"> 地&nbsp;&nbsp;&nbsp;&nbsp;址: </td>
                      <td class="content"><asp:TextBox ID="txtAddress" runat="server" Width="180"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td class="label"> 部&nbsp;&nbsp;&nbsp;&nbsp;门: </td>
                      <td class="content"><asp:Label ID="lblDepartment" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                      <td class="label"> 职&nbsp;&nbsp;&nbsp;&nbsp;位: </td>
                      <td class="content"><asp:Label ID="lblPosition" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                      <td class="label"> 入职时间: </td>
                      <td class="content"><asp:Label ID="lblJoinDate" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                      <td class="label"> 合同有效期: </td>
                      <td class="content"><asp:Label ID="lblContractDate" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                      <td class="label"> 提&nbsp;&nbsp;&nbsp;&nbsp;成: </td>
                      <td class="content"><asp:Label ID="lblCommission" runat="server"></asp:Label></td>
                    </tr>            
                    <tr><td align="center" colspan="2"><asp:Button ID="btnUpdate" runat="server" CssClass="button" Text="修 改" OnClick="btnUpdate_Click" /></td></tr>        
                </table>		
        </td>
    </tr>
  </table>
</form>
</body>
</html>
