<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewsList.aspx.cs" Inherits="Admin_News_NewsList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">   
  <wl:WebSettingNav ID="webSettingNav" Title="信息列表" runat="server" />
  <table class="tablecontent">
    <tr><td align="center">
        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td></tr>
    <tr>
      <td><table class="grid">
          <tr>
            <th width="10%" align="center" class="header">编号</th>
            <th width="20%" align="center" class="header">分类名称</th>
            <th width="30%" align="center" class="header">标题</th>
            <th width="20%" align="center" class="header">添加时间</th>
            <th width="10%" align="center" class="header">修改</th>
            <th width="10%" align="center" class="header">选择</th>
          </tr>
          <asp:Repeater ID="rpNews" runat="server">
            <ItemTemplate>
              <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                <td align="center"><%# Eval("Id") %></td>
                <td align="center"><%# Eval("Category.Name")%></td>
                <td align="center"><%# Eval("Title")%></td>
                <td align="center"><%# Eval("CreateTime")%></td>
                <td align="center"><a href="Edit.aspx?id=<%# Eval("Id") %>">修改</a></td>
                <td align="center"><input id="cbxId" name="cbxId" type="checkbox" value="<%# Eval("Id")%>" /></td>
              </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
              <tr class="content" onmouseover="this.className = 'hover';" onmouseout="this.className = 'content';">
                <td align="center"><%# Eval("Id") %></td>
                <td align="center"><%# Eval("Category.Name")%></td>
                <td align="center"><%# Eval("Title")%></td>
                <td align="center"><%# Eval("CreateTime")%></td>
                <td align="center"><a href="Edit.aspx?id=<%# Eval("Id") %>">修改</a></td>
                <td align="center"><input id="cbxId" name="cbxId" type="checkbox" value="<%# Eval("Id")%>" /></td>
              </tr>
            </AlternatingItemTemplate>
          </asp:Repeater>
          <tr>
                <td align="right" colspan="6">
                    <asp:Button ID="btnDelete" runat="server"  CssClass="button" Text="删除选择项" OnClientClick="return confirm('您确认要删除吗？')" OnClick="btnDelete_Click" /></td>
              </tr>
        </table>		
		</td>
    </tr>
  </table>
  <wl:Pagination ID="pagi" runat="server"/>  
</form>
</body>
</html>
