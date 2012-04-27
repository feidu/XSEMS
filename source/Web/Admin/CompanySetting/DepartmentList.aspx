<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DepartmentList.aspx.cs" Inherits="Admin_CompanySetting_DepartmentList" %>

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
        <td class="info2">公司设置 > 公司设定 > 部门列表</td>
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
            <th align="center" class="header">编号</th>
            <th align="center" class="header">部门名称</th>
            <th align="center" class="header">操作</th>            
            <th align="center" class="header">选择</th>
          </tr>
          <asp:Repeater ID="rpDepartment" runat="server">
            <ItemTemplate>
              <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                <td align="center"><%# Eval("Id") %></td>
                <td align="left"><%# Eval("Name") %></td>
                <td align="center"><a href="DepartmentList.aspx?id=<%# Eval("Id") %>">修改</a></td>
                <td align="center"><input id="chkId" name="chkId" type="checkbox" value="<%# Eval("Id")%>" /></td>
              </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
              <tr class="content" onmouseover="this.className = 'hover';" onmouseout="this.className = 'content';">
                <td align="center"><%# Eval("Id") %></td>
                <td align="left"><%# Eval("Name")%></td>
                <td align="center"><a href="DepartmentList.aspx?id=<%# Eval("Id") %>">修改</a></td>
                <td align="center"><input id="chkId" name="chkId" type="checkbox" value="<%# Eval("Id")%>" /></td>
              </tr>
            </AlternatingItemTemplate>
          </asp:Repeater>
          <tr>
                <td align="right" colspan="10">
                    <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="删除选择项" OnClientClick="return confirm('您确认要删除吗？')" OnClick="btnDelete_Click" /></td>
              </tr>
        </table>		
        <table class="grid" id="tbDepartmentUpdate" runat="server">
		  <tr>
            <td colspan="2" style="height:30px;"></td>
          </tr>
		  <tr>
            <td width="150" align="left" valign="middle" class="header">修改当前部门名称: </td>
            <td align="left" valign="middle" class="header"></td>
          </tr>
          <tr>
            <td width="109" align="left" valign="middle" class="label">名称: </td>
            <td align="left" valign="middle" class="content"><asp:TextBox ID="txtName" runat="server" Text="" Width="398px"></asp:TextBox></td>
          </tr>
          <tr>
            <td width="109" align="left" valign="middle" class="label"></td>
            <td align="left" valign="middle" class="content"><asp:Button ID="btnUpdate" runat="server" CssClass="button" Text="修 改" OnClick="btnUpdate_Click" /></td>
          </tr>
        </table>		
        </td>
    </tr>
  </table>
</form>
</body>
</html>
