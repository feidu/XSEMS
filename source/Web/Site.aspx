<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Site.aspx.cs" Inherits="Site" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<wl:Seo ID="seo" runat="server" Title=""/>
<link href="Css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<center>
<form id="form1" runat="server">
  <div>
    <div id="wrapper">
      <div id="wrapper2">
        <!--头部-->
        <wl:Header ID="hc" runat="server" CurrentNav="5"/>
        <!--内容-->
        <div class="margin_t" id="main">
          <div class="left_bar1">
            <div class="content_t margin_t" style="text-align:left;">
              <table  border="0" width="97%" class="grid">            
                <asp:Repeater ID="rpSites" runat="server">
                <ItemTemplate>
                <tr><td width="15%" class="label">网点名称：</td><td width="85%" class="content" style="font-weight:bold;"><%# Eval("Name")%></td></tr>
                <tr><td class="label">联 系 人：</td><td class="content"><%# Eval("ContactPerson")%></td></tr>
                <tr><td class="label">联系电话：</td><td class="content"><%# Eval("Phone")%></td></tr>
                <tr><td class="label">电子邮箱：</td><td class="content"><%# Eval("Email") %></td></tr>
                <tr><td class="label">QQ：</td><td class="content"><%# Eval("QQ") %></td></tr>
                <tr><td class="label">MSN：</td><td class="content"><%# Eval("MSN") %></td></tr>
                <tr><td class="label">网点地址：</td><td class="content"><%# Eval("Address") %></td></tr>   
                <tr><td colspan="2"><hr /></td></tr>          
                </ItemTemplate>
                </asp:Repeater> 
               </table>
            </div>
          </div>
          
          <!--中间右边部分-->
            <wl:Right runat="server" ID="right" />
        </div>
        <!--尾部-->
        <wl:Footer ID="footer" runat="server" />
      </div>
    </div>
  </div>
</form>
</center>
</body>
</html>
