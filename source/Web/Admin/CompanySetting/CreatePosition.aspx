<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreatePosition.aspx.cs" Inherits="Admin_CompanySetting_CreatePosition" %>

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
        <td class="info2">公司设置 > 公司设定 > 添加职位</td>
    </tr>
    <tr>
        <td class="info"><a href="CreateDepartment.aspx">添加部门</a> | <a href="DepartmentList.aspx">部门列表</a> | <a href="CreatePosition.aspx">添加职位</a> | <a href="PositionList.aspx">职位列表</a></td>
    </tr>
    <tr>
        <td class="seperator"></td>
    </tr>
  </table>
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
      <td colspan="2" class="line"></td>
    </tr>
    <tr>
      <td colspan="2" class="seperator"></td>
    </tr>
  </table>
  <table class="tablecontent">
    <tr><td align="center">
        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td></tr>
    <tr>
      <td><table class="grid">                        
                    <tr>
                      <td class="label" width="12%"> 职位名称: </td>
                      <td class="content" width="88%"><asp:TextBox ID="txtPositionName" runat="server" Width="180"></asp:TextBox>
                      </td>
                    </tr>                                       
                    <tr><td colspan="2" align="center"><asp:Button ID="btnCreate" runat="server" CssClass="button" Text="添 加" OnClick="btnCreate_Click" />&nbsp;&nbsp;&nbsp;<input type="button" class="button" value="返 回" onclick="javascript:location.href='DepartmentList.aspx';" /></td></tr>
                </table>		
        </td>
    </tr>
  </table>
</form>
</body>
</html>