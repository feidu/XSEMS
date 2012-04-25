<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CountryList.aspx.cs" Inherits="Admin_PostSetting_CountryList" %>

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
        <td class="info2">物流设置 > 国家设定 > 国家列表</td>
    </tr>
    <tr>
        <td class="info"><a href="CreateCountry.aspx">添加国家</a> | <a href="CountryList.aspx">国家列表</a></td>
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
            <th align="center" class="header">英文名</th>
            <th align="center" class="header">中文名</th>
            <th align="center" class="header">国家代码</th>
            <th align="center" class="header">所属洲</th>  
            <th align="center" class="header">排在前面</th>  
            <th align="center" class="header">查看</th>
            <th align="center" class="header">选择</th>
          </tr>
          <asp:Repeater ID="rpCountry" runat="server">
            <ItemTemplate>
              <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                <td align="center"><%# Eval("Id") %></td>
                <td align="left"><%# Eval("EnglishName") %></td>
                <td align="left"><%# Eval("ChineseName") %></td>
                <td align="left"><%# Eval("Code") %></td>
                <td align="left"><%# Backend.Utilities.EnumConvertor.ContinentTypeConvertToString(Convert.ToByte(Eval("Continent")))%></td>                
                <td align="center"><%# Convert.ToBoolean(Eval("IsFront").ToString()) ? "<input id='chkIsFront' name='chkIsFront' type='checkbox' value=" + Eval("Id") + " checked='checked'/>" : "<input id='chkIsFront' name='chkIsFront' type='checkbox' value=" + Eval("Id") + " />"%></td>
                <td align="center"><a href="Country.aspx?id=<%# Eval("Id") %>">查看</a></td>
                <td align="center"><input id="chkId" name="chkId" type="checkbox" value="<%# Eval("Id")%>" /></td>
              </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
              <tr class="content" onmouseover="this.className = 'hover';" onmouseout="this.className = 'content';">
                <td align="center"><%# Eval("Id") %></td>
                <td align="left"><%# Eval("EnglishName") %></td>
                <td align="left"><%# Eval("ChineseName") %></td>
                <td align="left"><%# Eval("Code") %></td>
                <td align="left"><%# Backend.Utilities.EnumConvertor.ContinentTypeConvertToString(Convert.ToByte(Eval("Continent")))%></td>   
                <td align="center"><%# Convert.ToBoolean(Eval("IsFront").ToString()) ? "<input id='chkIsFront' name='chkIsFront' type='checkbox' value=" + Eval("Id") + " checked='checked'/>" : "<input id='chkIsFront' name='chkIsFront' type='checkbox' value=" + Eval("Id") + " />"%></td>
                <td align="center"><a href="Country.aspx?id=<%# Eval("Id") %>">查看</a></td>
                <td align="center"><input id="chkId" name="chkId" type="checkbox" value="<%# Eval("Id")%>" /></td>
              </tr>
            </AlternatingItemTemplate>
          </asp:Repeater>
          <tr>
                <td align="right" colspan="8">
                    <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="删除选择项" OnClientClick="return confirm('您确认要删除吗？')" OnClick="btnDelete_Click" /></td>
              </tr>
        </table>		
        </td>
    </tr>
  </table>
  <wl:Pagination ID="pagi" runat="server"/>
</form>
</body>
</html>
