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
          <div class="left_bar1">            
            <div class="content_t margin_t">
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
                  <td align="left" class="label"> 用 户 名: </td>
                  <td align="left" class="content"><asp:TextBox ID="txtUsername" runat="server" Width="180"></asp:TextBox><span style="color:Red">* </span>
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
                  <td align="left" class="label"> 服务网点: </td>
                  <td align="left" class="content"><wl:CompanyDropDownList ID="ddlCompany" runat="server"></wl:CompanyDropDownList>
                  </td>
                </tr>
                <tr>
                  <td align="left" class="label"> 所在地区: </td>
                  <td align="left" class="content"><select id="slProvince" name="slProvince" onchange="SetCity()">
                          <option value="0">请选择 </option>
                          <option value="北京">北京 </option>
                          <option value="天津">天津 </option>
                          <option value="上海">上海 </option>
                          <option value="重庆">重庆 </option>
                          <option value="广东">广东 </option>
                          <option value="江苏">江苏 </option>
                          <option value="浙江">浙江 </option>
                          <option value="福建" >福建 </option>
                          <option value="湖南">湖南 </option>
                          <option value="湖北">湖北 </option>
                          <option value="山东">山东 </option>
                          <option value="辽宁">辽宁 </option>
                          <option value="吉林">吉林 </option>
                          <option value="云南">云南 </option>
                          <option value="四川">四川</option>
                          <option value="安徽">安徽</option>
                          <option value="江西">江西 </option>
                          <option value="黑龙江">黑龙江 </option>
                          <option value="河北">河北 </option>
                          <option value="陕西">陕西 </option>
                          <option value="海南">海南 </option>
                          <option value="河南">河南 </option>
                          <option value="山西">山西 </option>
                          <option value="内蒙古">内蒙古 </option>
                          <option value="广西">广西</option>
                          <option value="贵州">贵州 </option>
                          <option value="宁夏">宁夏 </option>
                          <option value="青海">青海</option>
                          <option value="新疆">新疆 </option>
                          <option value="西藏">西藏 </option>
                          <option value="甘肃">甘肃 </option>
                          <option value="台湾">台湾 </option>
                          <option value="香港">香港</option>
                          <option value="澳门">澳门 </option>
                      </select>
                      <select id="slCity" name="slCity">
                      <option value="0">——</option>
                      </select><span style="color:Red">* </span>
                  </td>
                </tr>
                <tr>
                  <td align="left" class="label"> 联系地址: </td>
                  <td align="left" class="content"><asp:TextBox ID="txtAddress" runat="server" Width="280"></asp:TextBox><span style="color:Red">* </span>
                  </td>                  
                </tr>
                <tr>
                  <td colspan="2" align="center">
				  	<table border="0" cellpadding="0" cellspacing="0" width="100%">
						<tr>
							  <td width="12%" align="left" class="label">是否取件: </td>
                              <td width="38%" align="left" class="content"><asp:CheckBox ID="chkIsFetchGoods" runat="server" />
                          </td>
							  <td width="27%" align="left" class="label">是否使用邮件服务: </td>
                              <td width="23%" align="left" class="content"><asp:CheckBox ID="chkIsMessage" runat="server" />
                          </td>
						</tr>
					</table>
				  </td>
                </tr>                
                <tr>                  
                  <td colspan="2" class="label" style="padding-top:8px; text-align:center;"><asp:ImageButton ID="btnRegister" runat="server" OnClick="btnRegister_Click" ImageUrl="images/register.gif" />
                  </td>
                </tr>
              </table>
            </div>
          </div>
          <!--中间右边部分-->
          <wl:Right runat="server" ID="right" />
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
