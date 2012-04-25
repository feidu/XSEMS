<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="News_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<wl:Seo ID="seo" runat="server" Title=""/>
<link href="/Css/style.css" rel="stylesheet" type="text/css" />

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
        <div class="margin_t" id="main">
          <div class="left_bar1">
            <div class="content_t margin_t">
              <table cellspacing="0" border="0" style="background-color: White; width: 90%; border-collapse: collapse;">
                <asp:Repeater ID="rpNews" runat="server">
                 <ItemTemplate>
                    <tr>
                      <td align="left"><ul style="margin: 0px; padding: 0px; float:left;">
                          <li style="list-style-type: none; background-image: url(../images/icon_dot.gif); background-repeat: no-repeat;
                                padding-left: 20px; font-size: 13px; background-position: 5px; float:left;">
                            <table width="100%">
                              <tr>
                                <td width="80%"><div style="font-size: 14px;"> <a href="Content.aspx?Id=<%# Eval("Id") %>" target="_blank"> <%# Eval("Title") %></a></div></td>
                                <td width="20%"> <%# Convert.ToDateTime(Eval("CreateTime")).ToShortDateString() %> </td>
                              </tr>
                            </table>
                          </li>
                        </ul></td>
                    </tr>
                </ItemTemplate>
               </asp:Repeater>
               <tr><td align="center"><wl:Pagination ID="pagi" runat="server"/></td></tr>
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
