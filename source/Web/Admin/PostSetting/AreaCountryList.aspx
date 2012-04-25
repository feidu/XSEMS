<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AreaCountryList.aspx.cs" Inherits="Admin_PostSetting_AreaCountryList" %>

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
        <td class="info2">物流设置 > 分区设定 > 分区国家列表</td>
    </tr>
    <tr>
        <td class="info">承运商：<asp:Label ID="lblCarrier" runat="server" Text="" ForeColor="maroon"></asp:Label>&nbsp;&nbsp;&nbsp;分区名称：<asp:Label ID="lblCarrierArea" runat="server" ForeColor="maroon"></asp:Label></td>
    </tr>
  </table>
  <table class="tablecontent">
    <tr><td align="center">
        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td></tr>
    <tr>
      <td><table class="grid">
          <tr>
            <th align="center" class="header">英文名称</th>
            <th align="center" class="header">中文名称</th>
          </tr>
          <asp:Repeater ID="rpAreaCountry" runat="server">
            <ItemTemplate>
              <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                <td align="left"><%# Eval("Country.EnglishName") %></td>
                <td align="left"><%# Eval("Country.ChineseName") %></td>
              </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
              <tr class="content" onmouseover="this.className = 'hover';" onmouseout="this.className = 'content';">
                <td align="left"><%# Eval("Country.EnglishName") %></td>
                <td align="left"><%# Eval("Country.ChineseName") %></td>
              </tr>
            </AlternatingItemTemplate>
          </asp:Repeater>
          <tr>
                <td align="center" colspan="2"><input type="button" class="button" id="btnBack" onclick="javascript:javascript:history.go(-1);" value="返 回" />
                    </td>
              </tr>
        </table>		
        </td>
    </tr>
  </table>
  <wl:Pagination ID="pagi" runat="server"/>
</form>
</body>
</html>

