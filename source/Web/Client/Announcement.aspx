<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Announcement.aspx.cs" Inherits="Client_Announcement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<wl:Seo ID="seo" runat="server" Title=""/>
<link href="../Css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<center>
<form id="form1" runat="server">
  <div>
    <div id="wrapper">
      <div id="wrapper2">
        <!--头部-->
        <wl:HeaderClient ID="hc" runat="server" />  
        <!--内容-->
        <div id="content">
          <div id="main_client">
            <div class="left_bar_client">
              <!--中间左边导航部分-->
              <wl:Left ID="left" runat="server" />
            </div>
            <div class="right_bar_client">
             <table class="tablecontent">
                 <tr><td align="left" class="top_content"><wl:ClientTop runat="server" id="clientTop" Title="公告详情"></wl:ClientTop></td></tr> 
                 <tr><td align="center"><asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td></tr>
                 <tr>
                  <td><table class="grid">
                  <tr>
                    <td align="center" style="font-weight:bold;"><%=newsTitle %></td>
                  </tr>
                  <tr>
                    <td align="center"><hr style="width: 99%;" /></td>
                  </tr>
                  <tr>
                    <td align="left"><%=newsContent %></td>
                  </tr>                  
                </table>
                </td>
                </tr>
                </table>
            </div>
          </div>
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
