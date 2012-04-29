<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default" %>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>萧山EMS</title>
<style type="text/css">
<!--

body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px; background-image:url(images/dl-bj.jpg); background-repeat:repeat-x;
}

-->
</style>
<script src="Js/Validator.js" language="javascript" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
function ClearAll()
{
	var txts=document.getElementsByTagName("input"); 
     for(var i=0;i <txts.length;i++) 
     { 
      if(txts[i].type=="text"||txts[i].type=="password") 
      { 
       txts[i].value =""; 
      } 
     }

}
    </script>
<link href="css/css.css" rel="stylesheet" type="text/css" />
</head>
<body onLoad="if(window.document.forms[0].tbUsername!=null)window.document.forms[0].tbUsername.focus();">
<form id="form1" runat="server" onSubmit="return Validator.Validate(this,3);">
  <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td align="center" valign="middle"><table id="divLogin" runat="server" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td width="333" height="300" valign="middle"><table width="100%" border="0" align="right" cellpadding="0" cellspacing="0">
                <tr>
                  <td align="left" valign="top"><img src="images/dl1.jpg" width="333" height="5" /></td>
                </tr>
                <tr>
                  <td align="left" valign="top" background="images/dl2.jpg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td width="4%" rowspan="3">&nbsp;</td>
                        <td width="92%" height="35" align="left" valign="middle" class="font-s4" style="border-bottom: 1px solid #e5e5e5;"> <span style=" color:Navy; font-family:'宋体'; font-size:16px;"> <em>萧山EMS管理系统</em></span> &nbsp; &nbsp; &nbsp;
                          <asp:Label ID="lbMsg" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                        <td width="4%" rowspan="3">&nbsp;</td>
                      </tr>
                      <tr>
                        <td align="left" valign="middle"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td colspan="2" align="left" valign="middle">&nbsp;</td>
                            </tr>
                            <tr>
                              <td width="33%" height="35" align="right" valign="middle" class="font-s3"> 用户名： &nbsp; </td>
                              <td width="67%" height="35" align="left" valign="middle"><asp:TextBox ID="tbUsername" name="tbUsername" Width="120" CssClass="input-dl" runat="server" datatype="LimitB" min="3" max="60" msg=""></asp:TextBox>
                              </td>
                            </tr>
                            <tr>
                              <td height="35" align="right" valign="middle" class="font-s3"> 密&nbsp;&nbsp;码： &nbsp; </td>
                              <td height="35" align="left" valign="middle"><asp:TextBox ID="tbPassword" Width="120" name="tbPassword" runat="server" TextMode="Password" CssClass="input-dl" datatype="LimitB" min="3" max="20" msg=""></asp:TextBox>
                              </td>
                            </tr>
                            <tr>
                              <td height="35" align="right" valign="middle" class="font-s3"> 验证码： &nbsp; </td>
                              <td height="35" align="left" valign="middle"><wl:VerifyCode ID="vc" runat="server" InputClass="input-vc" CssClass="verify-code" />
                              </td>
                            </tr>
                            <tr>
                              <td height="20" align="right" valign="middle" class="font-s3">&nbsp;</td>
                              <td height="20" align="left" valign="middle">&nbsp;</td>
                            </tr>
                            <tr>
                              <td height="35" colspan="2" align="left" valign="middle" class="font-s3"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                  <tr>
                                    <td width="55%" align="center" valign="middle"><asp:ImageButton ID="btnLogin"  runat="server" ImageUrl="images/bottom1.jpg" OnClick="btnLogin_Click" />
                                    </td>
                                    <td width="2%" align="center" valign="middle">&nbsp;</td>
                                    <td width="43%" align="left" valign="middle"><img style="cursor: pointer;" onClick="ClearAll();" src="images/bottom2.jpg" width="89" height="30" /></td>
                                  </tr>
                                </table></td>
                            </tr>
                          </table></td>
                      </tr>
                      <tr>
                        <td align="left" valign="middle">&nbsp;</td>
                      </tr>
                    </table></td>
                </tr>
                <tr>
                  <td align="left" valign="top"><img src="images/dl3.jpg" width="333" height="6" /></td>
                </tr>
              </table></td>
          </tr>
          <tr>
            <td height="50">&nbsp;</td>
          </tr>
        </table></td>
    </tr>
  </table>
</form>
</body>
</html>
