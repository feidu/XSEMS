<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HeaderClient.ascx.cs" Inherits="Controls_HeaderClient" %>
<style type="text/css">
body {
	margin-bottom: 0px;
	background-image: url(../Images/index_bg.gif);
	background-repeat: repeat-x;
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
}
</style>
<tr>
    <td height="20" align="left" valign="middle"><table width="980" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="175" height="20" align="left" valign="middle">您好! 欢迎您来到萧山EMS!~</td>
        <td width="805" align="left" valign="middle" class="announcement" style=" font-family:宋体;font-size:12px ; color: #E41616;"><marquee scrollamount="3" onMouseOver="this.stop()" onMouseOut="this.start()" direction="left">
        <%=announcement %>
        </marquee></td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td height="100" align="left" valign="middle"><table width="980" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="222" height="100" align="left" valign="middle"></td>
        <td width="758" align="right" valign="bottom">&nbsp;</td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td height="35"><table width="980" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="116" height="35" align="center" valign="middle" <% if (currentNav!=0){ %> bgcolor="#007ABB"<%}else {%> bgcolor="#E48221"<%} %> onmouseover="this.style.backgroundColor='#E48221'"  onmouseout="this.style.backgroundColor='' " ><a href="../"><span style="font-family:宋体; font-size:14px; color: #FFF; font-weight: bold;">首页</span></a></td>
        <td width="130" align="center" valign="middle" <% if (currentNav!=1){ %> bgcolor="#0089D2"<%}else {%> bgcolor="#E48221"<%} %> onmouseover="this.style.backgroundColor='#E48221'"  onmouseout="this.style.backgroundColor='' " ><a href="../AboutUs.aspx"><span style="font-family:宋体; font-size:14px; color: #FFF; font-weight: bold;">关于萧山EMS</span></a></td>
        <td width="130" align="center" valign="middle" <% if (currentNav!=2){ %> bgcolor="#007ABB"<%}else {%> bgcolor="#E48221"<%} %> onmouseover="this.style.backgroundColor='#E48221'"  onmouseout="this.style.backgroundColor='' "><a href="../NewsList.aspx?cat=1"><span style="font-family:宋体; font-size:14px; color: #FFF; font-weight: bold;">新闻公告</span></a></td>        
        <td width="604" bgcolor="#007ABB"></td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td height="15">&nbsp;</td>
  </tr>