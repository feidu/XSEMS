<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Welcome.aspx.cs" Inherits="Admin_Main_Welcome" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>欢迎</title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
      <td class="img"><img src="../Images/icon_rule.gif" width="32" height="32" /></td>
      <td class="title"> 欢迎您，<%=username%> !</td>
    </tr>
    <tr>
      <td colspan="2" class="line"></td>
    </tr>
    <tr>
      <td colspan="2" class="seperator"></td>
    </tr>
  </table>
  <table class="tablecontent">
    <tr>
      <td class="part"><img src="../Images/icon_applist.gif" width="32" height="32" /> 系统公告</td>
    </tr>
    <tr>
      <td height="400px" align="left" valign="top">
          <div id="demo" style="overflow:hidden; height:400px; width:50%;">
              <div id="demo1" class="announcement">
                <table cellspacing="0" border="0" style="float:left;" cellpadding="0" width="100%" id="tbAnnouncement">
                  <asp:Repeater ID="rpAnnouncement" runat="server">
                    <ItemTemplate>
                      <tr>
                        <td><ul>
                            <li><a href="../News/NewsView.aspx?id=<%# Eval("Id") %>"> <%# Eval("Title") %> &nbsp;<%# Eval("CreateTime") %></a></li>
                          </ul></td>
                      </tr>
                    </ItemTemplate>
                  </asp:Repeater>
                </table>
              </div>
              <div id="demo2"></div>
            </div>
            <script language="javascript" type="text/ecmascript">  
			   window.onload= function(){
			    var speed=60; //数字越大速度越慢 
			    var demo=document.getElementById("demo"); 
			    var demo1=document.getElementById("demo1"); 
			    var demo2=document.getElementById("demo2"); 
			    
			    if(demo1.offsetHeight>400){
			    demo2.innerHTML=demo1.innerHTML;
			    }
			    function Marquee0(){
				    if(demo2.offsetTop-demo.scrollTop<=0){
					    demo.scrollTop-=demo1.offsetHeight;
				    }
				    else{
					    demo.scrollTop++;
				    }
			    }
			    var MyMar0=setInterval(Marquee0,speed);
			    demo.onmouseover=function() {clearInterval(MyMar0)};
			    demo.onmouseout=function() {MyMar0=setInterval(Marquee0,speed)};
			    }
			    
		    </script>
      </td>
    </tr>
  </table>
</form>
</body>
</html>
