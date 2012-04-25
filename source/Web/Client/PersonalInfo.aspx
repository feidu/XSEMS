<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonalInfo.aspx.cs" Inherits="Client_PersonalInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<wl:Seo ID="seo" runat="server" Title=""/>
<link href="../Css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript" src="/Js/SelectCity.js"></script>
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
                 <tr><td align="left" class="top_content"><wl:ClientTop runat="server" id="clientTop" Title="我的资料"></wl:ClientTop></td></tr> 
                 <tr><td align="center"><asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td></tr>
                 <tr>
                  <td><table class="grid">     
                    <tr>
                      <td width="10%" class="label"> 登陆帐号: </td>
                      <td width="23%" class="content"><asp:Label ID="lblUsername" runat="server"></asp:Label>
                      </td>
                      <td width="10%" class="label"> 真实姓名: </td>
                      <td width="24%" class="content"><asp:Label ID="lblRealName" runat="server"></asp:Label>
                      </td>
                      <td width="10%" class="label"> 身份证号: </td>
                      <td width="23%" class="content"><asp:Label ID="lblIdCard" runat="server"></asp:Label>
                      </td>
                    </tr>          
                    <!--
                    <tr>
                      <td class="label"> 真实姓名: </td>
                      <td class="content"><asp:TextBox ID="txtRealName" runat="server" Width="180"></asp:TextBox>
                      </td>
                    </tr>
                    <tr>
                      <td class="label"> 身份证号: </td>
                      <td class="content"><asp:TextBox ID="txtIdCard" runat="server" Width="180"></asp:TextBox>
                      </td>
                    </tr>
                    -->
                    <tr>
                      <td class="label"> 联系电话: </td>
                      <td class="content"><asp:TextBox ID="txtPhone" runat="server" Width="95%"></asp:TextBox>
                      </td>
                      <td class="label"> 手&nbsp;&nbsp;&nbsp;&nbsp;机: </td>
                      <td class="content"><asp:TextBox ID="txtMobile" runat="server" Width="95%"></asp:TextBox>
                      </td>
                      <td class="label"> 电子邮箱: </td>
                      <td class="content"><asp:TextBox ID="txtEmail" runat="server" Width="95%"></asp:TextBox>
                      </td>
                    </tr>   
                    <!--             
                    <tr>
                      <td class="label"> 所在地区: </td>
                      <td class="content" colspan="5"><select id="slProvince" name="slProvince" onchange="SetCity()" runat="server">
                              <option value="0" selected="selected">请选择</option>
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
                          <select id="slCity" name="slCity" runat="server">
                          </select>
                      </td>
                    </tr>
                    -->
                    <tr>
                      <!--
                      <td align="right" class="label">是否取件: </td>
                      <td align="left" class="content"><asp:CheckBox ID="chkIsFetchGoods" runat="server" />
                      </td>
                      -->
                      <td class="label"> 联系地址: </td>
                      <td class="content" colspan="5"><asp:TextBox ID="txtAddress" runat="server" Width="98%"></asp:TextBox>
                      </td>                  
                    </tr>
                    <tr>
				      <td class="label">邮件服务: </td>
                      <td class="content"><asp:CheckBox ID="chkIsMessage" runat="server" />
                      </td>
                      <td class="label"> 帐户余额: </td>
                      <td class="content"><span style="text-decoration:underline">
                        <asp:Label ID="lblBalance" runat="server" Text=""></asp:Label></span>
                      </td>
                      <td class="label"> 信用额度: </td>
                      <td class="content"><span style="text-decoration:underline">
                        <asp:Label ID="lblCredit" runat="server" Text=""></asp:Label></span>
                      </td>
				    </tr>  
                    <!--       
                    <tr><td colspan="6" class="label" style="font-weight:bold;"> 服务网点信息：</td></tr>
                    <tr>
                      <td class="label"> 网点名称: </td>
                      <td class="content"><asp:Label ID="lblCompCompany" runat="server" Text=""></asp:Label>
                      </td>
                      <td class="label"> 联 系 人: </td>
                      <td class="content"><asp:Label ID="lblCompContactPerson" runat="server" Text=""></asp:Label>
                      </td>
                      <td class="label"> 联系电话: </td>
                      <td class="content"><asp:Label ID="lblCompPhone" runat="server" Text=""></asp:Label>
                      </td>
                    </tr>
                    <tr>                      
                      <td class="label"> QQ: </td>
                      <td class="content"><asp:Label ID="lblQQ" runat="server" Text=""></asp:Label>
                      </td>
                      <td class="label"> MSN: </td>
                      <td class="content"><asp:Label ID="lblMSN" runat="server" Text=""></asp:Label>
                      </td>
                      <td class="label"> 电子邮箱: </td>
                      <td class="content"><asp:Label ID="lblCompEmail" runat="server" Text=""></asp:Label>    
                      </td>
                    </tr> 
                    <tr>
                      <td class="label"> 网点地址: </td>
                      <td class="content" colspan="5"><asp:Label ID="lblCompAddress" runat="server" Text=""></asp:Label>
                      </td>
                    </tr>
                    -->
                    <tr><td colspan="6" align="center"><asp:Button ID="btnUpdate" runat="server" Text="修 改" CssClass="button" OnClick="btnUpdate_Click" /></td></tr>
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
