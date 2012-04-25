<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CarrierAreaList.aspx.cs" Inherits="Admin_PostSetting_CarrierAreaList" %>

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
        <td class="info2">物流设置 > 承运商设定 > 承运商分区</td>
    </tr>
    <tr>
        <td class="info">承运商：<asp:Label ID="lblCarrier" runat="server" Text="" ForeColor="maroon"></asp:Label></td>
    </tr>
  </table>
  <table class="tablecontent">
    <tr><td align="center">
        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td></tr>
    <tr>
      <td><table class="grid">
          <tr>
            <th align="center" class="header">分区名称</th>
            <th align="center" class="header">操作</th>
          </tr>
          <asp:Repeater ID="rpCarrierArea" runat="server">
            <ItemTemplate>
              <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                <td align="left"><%# Eval("Name") %></td>                               
                <td align="center"><a href="Area.aspx?id=<%# Eval("id") %>">编辑</a> | <a href="AreaCountryList.aspx?id=<%# Eval("Id") %>">查看国家</a> | <a href="AreaCountry.aspx?id=<%# Eval("Id") %>">修改国家</a> | <a href="ChargeStandard.aspx?id=<%# Eval("Id") %>&cd=<%# Eval("Carrier.ClientDiscount") %>&ad=<%# Eval("Carrier.AgencyDiscount") %>">查看收费标准</a></td>                
              </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
              <tr class="content" onmouseover="this.className = 'hover';" onmouseout="this.className = 'content';">
                <td align="left"><%# Eval("Name") %></td>                               
                <td align="center"><a href="Area.aspx?id=<%# Eval("id") %>">编辑</a> | <a href="AreaCountryList.aspx?id=<%# Eval("Id") %>">查看国家</a> | <a href="AreaCountry.aspx?id=<%# Eval("Id") %>">修改国家</a> | <a href="ChargeStandard.aspx?id=<%# Eval("Id") %>&cd=<%# Eval("Carrier.ClientDiscount") %>&ad=<%# Eval("Carrier.AgencyDiscount") %>">查看收费标准</a></td>                
              </tr>
            </AlternatingItemTemplate>            
          </asp:Repeater>          
          <tr>
                <td colspan="2" align="center"><input type="button" class="button" value="返 回" onclick="javascript:location.href='CarrierList.aspx';" /></td>
            </tr>
        </table>		
        </td>
    </tr>
  </table>
</form>
</body>
</html>
