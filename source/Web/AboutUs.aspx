<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AboutUs.aspx.cs" Inherits="AboutUs" %>

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
        <wl:Header ID="hc" runat="server" CurrentNav="1"/>
        <!--内容-->
        <tr>
            <td><table width="980" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td height="250" align="center" valign="top" bgcolor="#F3F3F3"><table width="950" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td height="40" align="left" valign="bottom"><span style="font-family:'宋体'; font-size:16px; color: #0b6398; font-weight: bold;">萧山EMS</span></td>
                  </tr>
                  <tr>
                    <td height="10" align="center" valign="middle"><hr style="border:1px dashed #cccccc; height:1px" /></td>
                  </tr>
                  <tr>
                    <td height="140" align="left" valign="middle"><span style="letter-spacing:1px; line-height:18px;"><span style="font-family:&quot;宋体&quot;; font-size:12px; color: #333;"><%=aboutFeidu%></span></span></td>
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
