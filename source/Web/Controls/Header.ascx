<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="Controls_Header" %>
<style type="text/css">
body {
	margin-bottom: 0px;
	background-image: url(Images/index_bg.gif);
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
        <td width="116" height="35" align="center" valign="middle" <% if (currentNav!=0){ %> bgcolor="#007ABB"<%}else {%> bgcolor="#E48221"<%} %> onmouseover="this.style.backgroundColor='#E48221'"  onmouseout="this.style.backgroundColor='' " ><a href="/Default.aspx"><span style="font-family:宋体; font-size:14px; color: #FFF; font-weight: bold;">首页</span></a></td>
        <td width="130" align="center" valign="middle" <% if (currentNav!=1){ %> bgcolor="#0089D2"<%}else {%> bgcolor="#E48221"<%} %> onmouseover="this.style.backgroundColor='#E48221'"  onmouseout="this.style.backgroundColor='' " ><a href="/AboutUs.aspx"><span style="font-family:宋体; font-size:14px; color: #FFF; font-weight: bold;">关于萧山EMS</span></a></td>
        <td width="130" align="center" valign="middle" <% if (currentNav!=2){ %> bgcolor="#007ABB"<%}else {%> bgcolor="#E48221"<%} %> onmouseover="this.style.backgroundColor='#E48221'"  onmouseout="this.style.backgroundColor='' "><a href="/NewsList.aspx?cat=1"><span style="font-family:宋体; font-size:14px; color: #FFF; font-weight: bold;">新闻公告</span></a></td>        
        <td width="604" bgcolor="#007ABB"></td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td height="15"></td>
  </tr>
  <tr>
    <td height="191"><table width="980" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="760" height="191" align="center" valign="middle"><div style=" width:978px; height: 289px; border: 1px #dddddd solid;">
        <img style="FILTER: revealTrans(duration=2,transition=20)" height="289" src="" width="978" border="0" id="bannerADrotator" name="bannerADrotator">
		<script language="JavaScript" type="text/javascript"> //js代码               
var bannerAD=new Array(); //用于存放图片路径（相对路径）
var adNum=0;        
var files='<%=files %>';
bannerAD=files.split('|');
var bannerADrotator=document.getElementById("bannerADrotator");
function setTransition(){
if (document.all){
bannerADrotator.filters.revealTrans.Transition=Math.floor(Math.random()*23);//设置图片切换
bannerADrotator.filters.revealTrans.apply(); //应用图片切换
}
}            
function playTransition(){
if (document.all)
bannerADrotator.filters.revealTrans.play() //播放图片
}            
function nextAd(){
if(adNum<bannerAD.length-1)adNum++;
else adNum=0;
setTransition();
bannerADrotator.src=bannerAD[adNum];
playTransition();
theTimer=setTimeout("nextAd()", 4000); //4秒钟切换一张图片
}                          
</script>
<script language="JavaScript" type="text/javascript">nextAd()</script>
</div>
    </td></tr></table></td>        
  </tr>