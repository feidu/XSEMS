<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Complain.aspx.cs" Inherits="Client_Complain" %>

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
                 <tr><td align="left" class="top_content"><wl:ClientTop runat="server" id="clientTop" Title="新建投诉信息"></wl:ClientTop></td></tr> 
                 <tr><td align="center"><asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td></tr>
                 <tr>
                  <td><table class="grid">
                <tr>
                  <td width="10%" class="label"> 标&nbsp;&nbsp;&nbsp;&nbsp;题: </td>
                  <td width="90%" class="content"><asp:TextBox ID="txtTitle" runat="server" Width="98%"></asp:TextBox></td>
                </tr>
                <tr>
                  <td height="35px" class="label"> 投诉内容: </td>
                  <td class="content"><asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Width="98%" Height="100"></asp:TextBox></td>
                </tr>           
                <tr>                  
                  <td colspan="2" align="center" height="35px" ><asp:Button ID="btnSubmit" runat="server" Text="提 交" CssClass="button" OnClick="btnSubmit_Click" />                  </td>
                </tr>
              </table>
              </td></tr></table>              
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
