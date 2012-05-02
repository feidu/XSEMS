<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewsList.aspx.cs" Inherits="NewsList" %>

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
        <wl:Header ID="hc" runat="server" />
        <!--内容-->
        <tr>
            <td><table width="980" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td height="250" align="center" valign="top" bgcolor="#F3F3F3"><table width="950" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td height="40" align="left" valign="bottom"><span style="font-family:'宋体'; font-size:16px; color: #0b6398; font-weight: bold;">新闻公告</span></td>
                  </tr>
                  <tr>
                    <td height="10" align="center" valign="middle"><hr style="border:1px dashed #cccccc; height:1px" /></td>
                  </tr>
                  <tr>
                    <td height="140" align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr><td align="left" valign="top">
                                <table cellspacing="0" border="0" style="background-color: White; width: 100%; border-collapse: collapse;">
                                <asp:Repeater ID="rpNews" runat="server">
                                 <ItemTemplate>
                                    <tr>
                                      <td align="left" valign="top"><ul style="margin: 0px; padding: 0px; float:left;">
                                          <li style="list-style-type: none; background-image: url(../images/icon_dot.gif); background-repeat: no-repeat;
                                                padding-left: 20px; font-size: 13px; background-position: 5px; float:left;">
                                            <table width="100%">
                                              <tr>
                                                <td width="80%"><div style="font-size: 14px;"> <a href="NewsView.aspx?Id=<%# Eval("Id") %>" target="_blank"> <%# Eval("Title") %></a></div></td>
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
                            </td>                            
                            </tr>               
                        </table>                        
                    </td>
                  </tr>
                </table></td>
                </tr>
            </table></td>
          </tr>        
        <!--尾部-->
        <wl:Footer ID="footer" runat="server" />
      </div>
    </div>
  </div>
</form>
</center>
</body>
</html>
