﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewsView.aspx.cs" Inherits="NewsView" %>

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
        <tr><td align="center" valign="top">
              <table style="width: 100%;">
                <tr>
                  <td style="text-align: center; height: 18px; font-size: 20px; font-weight: bold; padding-top:10px;"><span id="labTitle" style="display: inline-block; width: 500px;"> <%=newsTitle %> </span>&nbsp; </td>
                </tr>
              </table>
              <hr style="width: 97%;" />
              <br />
              <table style="width: 98%;">
                <tr>
                  <td align="left" style=" font-size:14px;"><%=newsContent %>
                    </td>
                </tr>
              </table>
         </td></tr>
        <!--尾部-->
        <wl:Footer ID="footer" runat="server" />
      </div>
    </div>
  </div>
</form>
</center>
</body>
</html>
