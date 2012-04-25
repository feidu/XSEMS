<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_News_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">   
  <wl:WebSettingNav ID="webSettingNav" Title="信息分类" runat="server" />
  <table class="tablecontent">
    <tr><td align="center">
        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td></tr>
    <tr>
      <td><table class="grid">
          <tr>
            <th width="10%" align="center" class="header">编号</th>
            <th width="30%" align="center" class="header">分类名称</th>
            <th width="40%" align="center" class="header">备注</th>
            <th width="10%" align="center" class="header">修改</th>
            <th width="10%" align="center" class="header">选择</th>
          </tr>
          <asp:Repeater ID="rpNewsCategory" runat="server">
            <ItemTemplate>
              <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                <td align="center"><%# Eval("Id") %></td>
                <td align="center"><%# Eval("Name")%></td>
                <td align="center"><%# Eval("Remark")%></td>
                <td align="center"><a href="Default.aspx?id=<%# Eval("Id") %>">修改</a></td>
                <td align="center"><input id="cbxId" name="cbxId" type="checkbox" value="<%# Eval("Id")%>" /></td>
              </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
              <tr class="content" onmouseover="this.className = 'hover';" onmouseout="this.className = 'content';">
                <td align="center"><%# Eval("Id") %></td>
                <td align="center"><%# Eval("Name")%></td>
                <td align="center"><%# Eval("Remark")%></td>
                <td align="center"><a href="Default.aspx?id=<%# Eval("Id") %>">修改</a></td>
                <td align="center"><input id="cbxId" name="cbxId" type="checkbox" value="<%# Eval("Id")%>" /></td>
              </tr>
            </AlternatingItemTemplate>
          </asp:Repeater>
          <tr>              
              <td align="right" colspan="5">
                    <asp:Button ID="btnDelete" runat="server"  CssClass="button"  Text="删除选择项" OnClientClick="return confirm('您确认要删除吗？')" OnClick="btnDelete_Click" /></td>
          </tr>
        </table>
		<table class="grid" id="tbCategoryUpdate" runat="server">
		  <tr>
            <td colspan="2" style="height:30px;"></td>
          </tr>
		  <tr>
            <td width="150" align="left" valign="middle" class="header">修改当前分类名称: </td>
            <td align="left" valign="middle" class="header"></td>
          </tr>
          <tr>
            <td width="109" align="left" valign="middle" class="label">名称: </td>
            <td width="1022" align="left" valign="middle" class="content"><asp:TextBox ID="tbxName" runat="server" Text="" Width="398px"></asp:TextBox></td>
          </tr>
          <tr>
            <td width="109" align="left" valign="middle" class="label">备注: </td>
            <td width="1022" align="left" valign="middle" class="content"><asp:TextBox ID="tbxNote" runat="server" Text="" Width="398px"></asp:TextBox></td>
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
