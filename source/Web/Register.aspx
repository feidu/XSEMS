<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<wl:Seo ID="seo" runat="server" Title=""/>
<link href="Css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript" src="Js/SelectCity.js"></script>
</head>
<body>
<center>
<form id="form1"  runat="server" >
  <div>
    <div id="wrapper">
      <div id="wrapper2">
        <!--头部-->
        <wl:Header ID="header" runat="server" />
        <!--内容-->
        <div class="margin_t" id="main">
              <table style="width: 100%;">
                <tr>
                  <td style="text-align: center; height: 16px; font-size: 16px; font-weight: bold;"><span id="labTitle" style="width: 500px;"> 客户注册 </span></td>
                </tr>
              </table>
              <hr style="width: 97%;" />
              <table class="grid" width="96%" style="width:96%">
                <tr>
                  <td colspan="2" align="center">
                      <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td>
                </tr>
                <tr>
                  <td align="left" class="label" width="20%"> 用 户 名: </td>
                  <td align="left" class="content" width="80%"><asp:TextBox ID="txtUsername" runat="server" Width="180"></asp:TextBox><span style="color:Red">* </span>
                  </td>
                </tr>
                <tr>
                  <td align="left" class="label"> 密&nbsp;&nbsp;&nbsp;&nbsp;码: </td>
                  <td align="left" class="content"><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="180"></asp:TextBox><span style="color:Red">* </span>
                  </td>
                </tr>
                <tr>
                  <td align="left" class="label"> 确认密码: </td>
                  <td align="left" class="content"><asp:TextBox ID="txtRePassword" runat="server" TextMode="Password" Width="180"></asp:TextBox><span style="color:Red">* </span>
                  </td>
                </tr>
                <tr>
                  <td align="left" class="label"> 真实姓名: </td>
                  <td align="left" class="content"><asp:TextBox ID="txtRealName" runat="server" Width="180"></asp:TextBox><span style="color:Red">* </span>
                  </td>
                </tr>
                <tr>
                  <td align="left" class="label"> 身份证号: </td>
                  <td align="left" class="content"><asp:TextBox ID="txtIdCard" runat="server" Width="180"></asp:TextBox><span style="color:Red">* </span>
                  </td>
                </tr>
                <tr>
                  <td align="left" class="label"> 联系电话: </td>
                  <td align="left" class="content"><asp:TextBox ID="txtPhone" runat="server" Width="180"></asp:TextBox>
                  </td>
                </tr>
                <tr>
                  <td align="left" class="label"> 手&nbsp;&nbsp;&nbsp;&nbsp;机: </td>
                  <td align="left" class="content"><asp:TextBox ID="txtMobile" runat="server" Width="180"></asp:TextBox><span style="color:Red">* </span>
                  </td>
                </tr>
                <tr>
                  <td align="left" class="label"> 电子邮箱: </td>
                  <td align="left" class="content"><asp:TextBox ID="txtEmail" runat="server" Width="180"></asp:TextBox><span style="color:Red">* </span>
                  </td>
                </tr>
                <tr>
                  <td align="left" class="label"> 联系地址: </td>
                  <td align="left" class="content"><asp:TextBox ID="txtAddress" runat="server" Width="280"></asp:TextBox><span style="color:Red">* </span>
                  </td>                  
                </tr>
                <tr>
                  <td align="left" class="label"> 是否使用邮件提醒服务: </td>
                  <td align="left" class="content"><asp:CheckBox ID="chkIsMessage" runat="server" />
                  </td>                  
                </tr>                                
                <tr>                  
                  <td colspan="2" class="label" style="padding-top:8px; text-align:center;"><asp:ImageButton ID="btnRegister" runat="server" OnClick="btnRegister_Click" ImageUrl="images/register.gif" />
                  </td>
                </tr>
              </table>          
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
