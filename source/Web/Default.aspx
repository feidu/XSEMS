<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <wl:Seo ID="seo" runat="server" Title="" />
    <link href="Css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Js/OrderSearch.js"></script>
    <script language="javascript" type="text/javascript">
        function checkLoginForm() {
            var username = document.getElementById("tbxUsername");
            var password = document.getElementById("tbxPassword");
            if (username.value.length <= 0) {
                alert("请输入用户名！");
                username.focus();
                return false;
            }

            if (password.value.length <= 0) {
                alert("请输入密码！");
                password.focus();
                return false;
            }
            return true;
        }

        function vali() {
            var trackNum = document.getElementById("txtTrackNum");
            if (trackNum.value.length <= 0) {
                alert("请输入追踪号！");
                trackNum.focus();
                return false;
            }
            return true;
        }
    </script>
    <style type="text/css">
        a:link
        {
            text-decoration: none;
        }
        a:visited
        {
            text-decoration: none;
        }
        a:hover
        {
            text-decoration: underline;
            color: #333;
        }
        a:active
        {
            text-decoration: none;
        }
        body, td, th
        {
            font-size: 12px;
            color: #333;
            font-family: "宋体";
        }
        
        .BlkBlackTab
        {
            font-family: 宋体;
            font-size: 14px;
            color: #1E1E1E;
            font-weight: bold;
            background-color: #9AB3F1;
        }
        .BlkBlackTabOff
        {
            font-family: 宋体;
            font-size: 14px;
            color: #1E1E1E;
            font-weight: bold;
        }
        .style1
        {
            width: 218px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table width="980" border="0" align="center" cellpadding="0" cellspacing="0">
        <wl:Header ID="header1" runat="server" />
        <tr>
            <td height="15">
            </td>
        </tr>
        <tr>
            <td height="110">
                <table width="980" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="223" height="110">
                            <table width="223" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="223" height="215" align="center" valign="middle">
                                        <div style="width: 221px; height: 233px; border: 1px #dddddd solid;">
                                            <table width="205" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="205" height="191" align="center" valign="middle">
                                                        <div style="width: 203px; height: 209px;">
                                                            <table width="173" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td height="35" align="left" valign="middle">
                                                                        <span style="font-family: 宋体; font-size: 14px; color: #0b6398; font-weight: bold;">用户登录</span>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="10" align="center" valign="middle">
                                                                        <hr style="border: 1px dashed #cccccc; height: 1px"/>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="38" align="center" valign="middle">
                                                                        <table width="173" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td width="54" height="38" align="left" valign="middle">
                                                                                    <span style="font-family: '宋体'; font-size: 12px; color: #0b6398;">用户名：</span>
                                                                                </td>
                                                                                <td width="119" align="left" valign="middle">
                                                                                    <input name="tbxUsername" type="text" id="tbxUsername" size="15" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="30" align="left" valign="middle">
                                                                        <table width="173" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td width="54" height="30" align="left" valign="middle">
                                                                                    <span style="font-family: '宋体'; font-size: 12px; color: #0b6398;">密 码 ：</span>
                                                                                </td>
                                                                                <td width="119" align="left" valign="middle">
                                                                                    <input name="tbxPassword" type="password" id="tbxPassword" size="15" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="10" align="left" valign="middle">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="25" align="left" valign="middle" bgcolor="#FDE2C6">
                                                                        <table width="173" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td width="28" height="25" align="center" valign="middle">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="87" align="left" valign="middle">
                                                                                    <a href="Register.aspx">免费注册</a>
                                                                                </td>
                                                                                <td width="58" align="center" valign="middle" bgcolor="#F67503" onmouseover="this.style.backgroundColor='#007ABB'"
                                                                                    onmouseout="this.style.backgroundColor='' ">
                                                                                    <asp:ImageButton ID="btnLogin" runat="server" ImageUrl="images/login2.png" OnClientClick="return checkLoginForm()"
                                                                                        OnClick="btnLogin_Click" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="20" align="center" valign="middle">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="20" align="left" valign="middle">
                                                                        >>&nbsp;选择萧山EMS，选择放心！
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="15">
                        </td>
                        <td width="305" height="215" align="center" valign="middle">
                            <table width="285" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="315" height="110" align="center" valign="middle">
                                        <div style="width: 313px; height: 233px; border: 1px #dddddd solid;">
                                            <table width="313" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td height="215" align="center" valign="top">
                                                        <table width="283" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td height="35" align="left" valign="middle">
                                                                    <span style="font-family: 宋体; font-size: 14px; color: #0b6398; font-weight: bold;">萧山EMS简介</span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    &nbsp;&nbsp;&nbsp;<a href="/AboutUs.aspx"><%=aboutFeidu %></a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="15">
                        </td>
                        <td width="412" height="215" align="center" valign="top">
                            <div style="width: 410px; height: 233px; border: 1px #dddddd solid;">
                                <table width="410" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="80" align="center" valign="top">
                                            <table width="380" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td height="35" align="left" valign="middle">
                                                        <span style="font-family: '宋体'; font-size: 14px; color: #0b6398; font-weight: bold;">
                                                            相关链接</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="24" align="left" valign="middle">
                                                        <a href="http://www.ems183.cn/" target="_blank">EMS快递单号查询</a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="24" align="left" valign="middle">
                                                        <a href="http://lit2.tnt.com.cn/tracker/trackandtraceInit.do" target="_blank">中速快递查询</a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="10" align="center" valign="middle">
                                            <table width="380" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td>
                                                        <hr style="border: 1px dashed #cccccc; height: 1px" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="83" align="center" valign="top">
                                            <table width="380" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td height="35" align="left" valign="middle">
                                                        <span style="font-family: '宋体'; font-size: 14px; color: #0b6398; font-weight: bold;">
                                                            货物跟踪</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="24" align="left" valign="middle">
                                                        <table width="380" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td height="24" align="center" valign="middle" class="style1">
                                                                    运单号码：<br />
                                                                    ( 最多5个,<br />
                                                                    每行输入一个单号 )
                                                                </td>
                                                                <td width="172" align="left" valign="middle">
                                                                    <textarea id="txtTrackNum" name="txtTrackNum" rows="5" style="overflow-x: hidden;
                                                                        overflow-y: hidden" title="最多只能输入5个跟踪号，以回车换行！" onKeyDown="if(event.keyCode==13){var s=value.match(/\n/g);if(s)if(s.length==4){alert('最多支持四个订单的查询');return false;}}" ></textarea>
                                                                </td>
                                                                <td width="145" align="left" valign="middle">
                                                                    <asp:Button runat="server" ID="btnSearch" Text="查 询" class="button" OnClientClick="return vali();"
                                                                        OnClick="btnSearch_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <wl:Footer ID="footer" runat="server" />
    </table>
    </form>
</body>
</html>
