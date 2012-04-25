<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Content.aspx.cs" Inherits="News_Content" %>

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
              <table style="width: 100%;">
                <tr>
                  <td style="text-align: center; height: 18px; font-size: 20px; font-weight: bold;"><span id="labTitle" style="display: inline-block; width: 500px;"> <%=newsTitle %> </span>&nbsp; </td>
                </tr>
              </table>
              <hr style="width: 97%;" />
              <br />
              <table>
                <tr>
                  <td><div style="font-size: 14px; text-align:left;">
                      <%=newsContent %>
                    </div></td>
                </tr>
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
