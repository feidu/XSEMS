<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Depot.aspx.cs" Inherits="Admin_CompanySetting_Depot" %>

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
        <td class="info2">公司设置 > 公司设定 > 仓库详情</td>
    </tr>
    <tr>
        <td class="info"><a href="CreateDepot.aspx">添加仓库</a> | <a href="DepotList.aspx">仓库列表</a></td>
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
                      <td class="label" width="14%"> 仓库名称：: </td>
                      <td class="content" width="86%"><asp:TextBox ID="txtName" runat="server" Width="180"></asp:TextBox>
                      </td>
                    </tr>            
                    <tr>
                      <td class="label"> 所属部门: </td>
                      <td class="content"><asp:DropDownList ID="ddlDepartment" runat="server"></asp:DropDownList>
                      </td>
                    </tr>                    
                    <tr>
                      <td class="label"> 联 系 人: </td>
                      <td class="content"><asp:TextBox ID="txtContactPerson" runat="server" Width="180"></asp:TextBox>
                      </td>
                    </tr>
                    <tr>
                      <td class="label"> 联系电话: </td>
                      <td class="content"><asp:TextBox ID="txtPhone" runat="server" Width="180"></asp:TextBox>
                      </td>
                    </tr>
                    <tr>
                      <td class="label"> 传&nbsp;&nbsp;&nbsp;&nbsp;真: </td>
                      <td class="content"><asp:TextBox ID="txtFax" runat="server" Width="180"></asp:TextBox>                          
                      </td>
                    </tr>                    
                    <tr>
                      <td class="label"> 联系地址: </td>
                      <td class="content"><asp:TextBox ID="txtAddress" runat="server" Width="180"></asp:TextBox>
                      </td>
                    </tr>
                    <tr>
                      <td class="label"> 状&nbsp;&nbsp;&nbsp;&nbsp;态: </td>
                      <td class="content"><select id="slStatus" name="slStatus" runat="server">
                        <option value="1">正常</option>
                        <option value="0">停止</option>
                      </select>
                      </td>
                    </tr>
                    <tr><td colspan="2" align="center"><asp:Button ID="btnUpdate" runat="server" CssClass="button" Text="修 改" OnClick="btnUpdate_Click" />&nbsp;&nbsp;&nbsp;<input type="button" class="button" value="返 回" onclick="javascript:location.href='DepotList.aspx';" /></td></tr>
                </table>		
        </td>
    </tr>
  </table>
</form>
</body>
</html>
