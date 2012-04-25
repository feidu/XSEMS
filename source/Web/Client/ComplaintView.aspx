<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ComplaintView.aspx.cs" Inherits="Client_ComplaintView" %>

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
                 <tr><td align="left" class="top_content"><wl:ClientTop runat="server" id="clientTop" Title="投诉详情"></wl:ClientTop></td></tr> 
                 <tr><td align="center"><asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td></tr>
                 <tr>
                  <td><table class="grid">
                  <tr>
                    <td width="9%" class="label" >标&nbsp;&nbsp;&nbsp;&nbsp;题:</td>
                    <td width="91%" class="content"><asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></td>
                  </tr>
                  <tr>
                    <td class="label" >提交时间:</td>
                    <td class="content"><asp:Label ID="lblCreateTime" runat="server" Text=""></asp:Label></td>
                  </tr>
                  <tr>
                    <td class="label" >投诉内容:</td>
                    <td class="content"><asp:Label ID="lblContent" runat="server" Text=""></asp:Label></td>
                  </tr>
                  <tr>
                    <td colspan="2" height="10"></td>
                  </tr>
                  <div id="divReplyContent" runat="server" visible="false">
                  <tr>
                    <td class="label" colspan="2" align="left" style="font-weight:bold;"><asp:Label ID="lblReplyUser" runat="server" Text=""></asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="lblReplyTime"></asp:Label>&nbsp;回复</td>
                  </tr>
                  <tr>
                    <td class="label" >回复内容:</td>
                    <td class="content"><asp:Label ID="lblReplyContent" runat="server" Text=""></asp:Label></td>
                  </tr>
                  </div>               
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