<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Main_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>萧山EMS管理系统</title>
<link href="Main.css" type="text/css" rel="stylesheet" />
<script language="JavaScript" type="text/javascript">
	function menuClickMe(obj, url){
		for(var i = 0; i < obj.parentNode.children.length; i++) {
			var c = obj.parentNode.children[i];
			if(c.active == "true"){	
				c.active = "false";
				c.style.color = '#FFFFFF';
				c.style.backgroundImage = '';
			}
		}
		obj.active = "true";
		obj.style.color = '#FFA900';
		obj.style.backgroundImage = 'url(../Images/menu_3.gif)';
		obj.style.backgroundPosition = 'center';
		if(url != undefined){
			document.getElementById("content").src = url;
		}
	}
	function menuOverMe(obj){
		if(obj.active!="true"){
			obj.style.color = '#FFA900';
		}
	}
	function menuOutMe(obj){
		if(obj.active!="true"){
			obj.style.color = '#FFFFFF';
		}
	}
    function reInitIframe(){	
        var iframe = document.getElementById("content");
        var bHeight = iframe.contentWindow.document.body.scrollHeight;
        var dHeight = iframe.contentWindow.document.documentElement.scrollHeight;
        var pageHeight = Math.max(bHeight, dHeight);
        var defaultHeight=490;
        var nowHeight=Math.max(pageHeight, defaultHeight);
        iframe.height=nowHeight;
        }
</script>
</head>
<noscript><iframe src="*.html"></iframe></noscript>
<body style="margin:0px 0px 0px 0px;">
<table  width="100%"  border="0" cellpadding="0" cellspacing="0">
<tr>
    <td align="left" valign="top">
    <table width="100%"  border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td height="32" valign="top">
            <div id="menu" runat="server"></div>
        </td>
      </tr>
      <tr>
        <td style="padding: 5px 5px 0px 5px;"><iframe width="100%" height="100%" id="content" name="content" src="<% =URL %>" frameborder="0" onload="reInitIframe()"></iframe></td>
      </tr>      
    </table>
    </td>
</tr>
<tr>
    <td align="left" valign="top">
        <table class="tb_footer_announcement">
	        <tr>
		        <td></td>
	        </tr>
        </table>
    </td>
</tr>
<tr>
    <td align="left" valign="top">
        <table class="tb_footer">
            <tr>
                <td style="font-family:Arial;"><%=copyright%>&nbsp;&nbsp;<a href="/">www.emsxs.com</a>&nbsp;&nbsp;Tel:<%=phone%></td>
            </tr>			
        </table>
    </td>
</tr>
</table>
</body>
</html>
