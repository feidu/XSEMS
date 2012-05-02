<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CarrierList.aspx.cs" Inherits="Admin_PostSetting_CarrierList" %>

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
        <td class="info2">物流设置 > 承运商设定 > 承运商列表</td>
    </tr>
    <tr>
        <td class="info"><a href="CreateCarrier.aspx">添加承运商</a> | <a href="CarrierList.aspx">承运商列表</a></td>
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
            <th align="left" class="header">编号</th>
            <th align="left" class="header">名称</th>
            <th align="left" class="header">联系人</th>
            <th align="left" class="header">联系电话</th>
            <th align="left" class="header">联系地址</th>
            <th align="left" class="header">代理折扣</th>
            <th align="left" class="header">客户折扣</th>
            <th align="center" class="header">编辑</th>
            <th align="center" class="header">操作</th>
            <th align="center" class="header">选择</th>
          </tr>
          <asp:Repeater ID="rpCarrier" runat="server">
            <ItemTemplate>
              <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                <td align="left"><%# Eval("Encode") %></td>
                <td align="left"><%# Eval("Name") %></td>
                <td align="left"><%# Eval("ContactPerson") %></td>
                <td align="left"><%# Eval("Phone") %></td>
                <td align="left"><%# Eval("Address") %></td>
                <td align="left"><%# Backend.Utilities.StringHelper.CurtNumber(Convert.ToString(Eval("AgencyDiscount"))) %></td>
                <td align="left"><%# Backend.Utilities.StringHelper.CurtNumber(Convert.ToString(Eval("ClientDiscount"))) %></td>                
                <td align="center"><a href="Carrier.aspx?id=<%# Eval("Id") %>">编辑</a></td>
                <td align="center"><a href="CreateArea.aspx?id=<%# Eval("Id") %>">添加分区</a> | <a href="CarrierAreaList.aspx?id=<%# Eval("Id") %>">查看分区</a></td>
                <td align="center"><input id="chkId" name="chkId" type="checkbox" value="<%# Eval("Id")%>" /></td>
              </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
              <tr class="content" onmouseover="this.className = 'hover';" onmouseout="this.className = 'content';">
                <td align="left"><%# Eval("Encode") %></td>
                <td align="left"><%# Eval("Name") %></td>
                <td align="left"><%# Eval("ContactPerson") %></td>
                <td align="left"><%# Eval("Phone") %></td>
                <td align="left"><%# Eval("Address") %></td>
                <td align="left"><%# Backend.Utilities.StringHelper.CurtNumber(Convert.ToString(Eval("AgencyDiscount"))) %></td>
                <td align="left"><%# Backend.Utilities.StringHelper.CurtNumber(Convert.ToString(Eval("ClientDiscount"))) %></td>                
                <td align="center"><a href="Carrier.aspx?id=<%# Eval("Id") %>">编辑</a></td>
                <td align="center"><a href="CreateArea.aspx?id=<%# Eval("Id") %>">添加分区</a> | <a href="CarrierAreaList.aspx?id=<%# Eval("Id") %>">查看分区</a></td>
                <td align="center"><input id="chkId" name="chkId" type="checkbox" value="<%# Eval("Id")%>" /></td>
              </tr>
            </AlternatingItemTemplate>
          </asp:Repeater>
          <tr>
                <td align="right" colspan="10">
                    <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="删除选择项" OnClientClick="return confirm('您确认要删除吗？')" OnClick="btnDelete_Click" /></td>
              </tr>
        </table>		
        </td>
    </tr>
  </table>
</form>
</body>
</html>
