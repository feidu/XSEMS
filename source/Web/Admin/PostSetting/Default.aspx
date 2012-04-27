<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_PostSetting_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">   
  <wl:PostSettingNav ID="postSettingNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">物流设置 > 公司设定 > 公司列表</td>
    </tr>
   <%-- <tr>
        <td class="info"><a href="CreateCompany.aspx">添加公司</a> | <a href="Default.aspx">公司列表</a> | <a href="UserList.aspx">员工列表</a></td>
    </tr>--%>
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
            <th align="center" class="header">名称</th>
            <th align="center" class="header">联系人</th>
            <th align="center" class="header">联系电话</th>
            <th align="center" class="header">所属区域</th>
            <th align="center" class="header">提成</th>
            <th align="center" class="header">操作</th>
            <th align="center" class="header">选择</th>
          </tr>
          <asp:Repeater ID="rpCompany" runat="server">
            <ItemTemplate>
              <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                <td align="center"><%# Eval("Id") %></td>
                <td align="left"><%# Eval("Name") %></td>
                <td align="left"><%# Eval("ContactPerson") %></td>
                <td align="left"><%# Eval("Phone") %></td>
                <td align="left"><%# Backend.Utilities.EnumConvertor.AreaCodeConvertToString((byte)Eval("AreaCode"))%></td>
                <td align="left"><%# Backend.Utilities.StringHelper.CurtNumber(Convert.ToString(Eval("Commission"))) %></td>
                <td align="center"><a href="Company.aspx?id=<%# Eval("Id") %>">编辑</a>&nbsp;|&nbsp;<a href="CompanyOperator.aspx?id=<%# Eval("Id") %>">修改权限</a>&nbsp;|&nbsp;<a href="CreateUser.aspx?id=<%# Eval("Id") %>">添加员工</a>&nbsp;|&nbsp;<a href="UserList.aspx?id=<%# Eval("Id") %>">员工列表</a></td>
                <td align="center"><input id="chkId" name="chkId" type="checkbox" value="<%# Eval("Id")%>" /></td>
              </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
              <tr class="content" onmouseover="this.className = 'hover';" onmouseout="this.className = 'content';">
                <td align="center"><%# Eval("Id") %></td>
                <td align="left"><%# Eval("Name") %></td>
                <td align="left"><%# Eval("ContactPerson") %></td>
                <td align="left"><%# Eval("Phone") %></td>
                <td align="left"><%# Backend.Utilities.EnumConvertor.AreaCodeConvertToString((byte)Eval("AreaCode"))%></td>
                <td align="left"><%# Backend.Utilities.StringHelper.CurtNumber(Convert.ToString(Eval("Commission")))%></td>
                <td align="center"><a href="Company.aspx?id=<%# Eval("Id") %>">编辑</a>&nbsp;|&nbsp;<a href="CompanyOperator.aspx?id=<%# Eval("Id") %>">修改权限</a>&nbsp;|&nbsp;<a href="CreateUser.aspx?id=<%# Eval("Id") %>">添加员工</a>&nbsp;|&nbsp;<a href="UserList.aspx?id=<%# Eval("Id") %>">员工列表</a></td>
                <td align="center"><input id="chkId" name="chkId" type="checkbox" value="<%# Eval("Id")%>" /></td>
              </tr>
            </AlternatingItemTemplate>
          </asp:Repeater>
          <tr>
                <td align="right" colspan="10">
                    <asp:Button ID="btnDelete" Width="70" CssClass="button" runat="server" Text="删除选择项" OnClientClick="return confirm('您确认要删除吗？')" OnClick="btnDelete_Click" /></td>
              </tr>
        </table>		
        </td>
    </tr>
  </table>
</form>
</body>
</html>
