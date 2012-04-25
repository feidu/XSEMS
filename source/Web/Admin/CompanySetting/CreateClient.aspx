<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateClient.aspx.cs" Inherits="Admin_CompanySetting_CreateClient" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript" src="/Js/SelectCity.js"></script>
</head>
<body>
<form id="form1" runat="server">   
  <wl:CompanySettingNav ID="companySettingNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">公司设置 > 公司设定 > 添加客户</td>
    </tr>
    <tr>
        <td class="info"><a href="CreateClient.aspx">添加客户</a> | <a href="ClientList.aspx">客户列表</a></td>
    </tr>
    <tr>
        <td class="seperator"></td>
    </tr>
  </table>
  <table class="tablecontent">
    <tr><td align="center">
        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td></tr>
    <tr>
      <td><table class="grid">  
                    <tr>
                      <td class="label" width="13%"> 用 户 名: </td>
                      <td class="content" width="87%"><asp:TextBox ID="txtUsername" runat="server" Width="180"></asp:TextBox><span style="color:Red">* </span>
                      </td>
                    </tr>
                    <tr>
                      <td class="label"> 密&nbsp;&nbsp;&nbsp;&nbsp;码: </td>
                      <td class="content"><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="180"></asp:TextBox><span style="color:Red">* </span>
                      </td>
                    </tr>
                    <tr>
                      <td class="label"> 确认密码: </td>
                      <td class="content"><asp:TextBox ID="txtRePassword" runat="server" TextMode="Password" Width="180"></asp:TextBox><span style="color:Red">* </span>
                      </td>
                    </tr>               
                    <tr>
                      <td class="label"> 真实姓名: </td>
                      <td class="content"><asp:TextBox ID="txtRealName" runat="server" Width="180"></asp:TextBox><span style="color:Red">* </span>
                      </td>
                    </tr>
                    <tr>
                      <td class="label"> 身份证号: </td>
                      <td class="content"><asp:TextBox ID="txtIdCard" runat="server" Width="180"></asp:TextBox>
                      </td>
                    </tr>
                    <tr>
                      <td class="label"> 联系电话: </td>
                      <td class="content"><asp:TextBox ID="txtPhone" runat="server" Width="180"></asp:TextBox>
                      </td>
                    </tr>
                    <tr>
                      <td class="label"> 手&nbsp;&nbsp;&nbsp;&nbsp;机: </td>
                      <td class="content"><asp:TextBox ID="txtMobile" runat="server" Width="180"></asp:TextBox>
                      </td>
                    </tr>
                    <tr>
                      <td class="label"> 电子邮箱: </td>
                      <td class="content"><asp:TextBox ID="txtEmail" runat="server" Width="180"></asp:TextBox><span style="color:Red">* </span>
                      </td>
                    </tr>                    
                    <tr>
                      <td class="label"> 所在地区: </td>
                      <td class="content"><select id="slProvince" name="slProvince" onchange="SetCity()" runat="server">
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
                            <option value="0">——</option>	              
                          </select><span style="color:Red">* </span>
                      </td>
                    </tr>
                    <tr>
                      <td class="label">联系地址: </td>
                      <td class="content"><asp:TextBox ID="txtAddress" runat="server" Width="280"></asp:TextBox>
                      </td>                  
                    </tr>
                    <tr>
			          <td class="label">是否取件: </td>
                      <td class="content"><asp:CheckBox ID="chkIsFetchGoods" runat="server" />
                      </td>
                    </tr>
                    <tr>
				      <td class="label">是否使用邮件服务: </td>
                      <td class="content"><asp:CheckBox ID="chkIsMessage" runat="server" />
                      </td>
				    </tr>        
				    <tr>
                      <td class="label"> 业 务 员: </td>
                      <td class="content"><asp:DropDownList ID="ddlCompanyUsers" runat="server"></asp:DropDownList>
                      </td>
                    </tr>
                    <tr>
                      <td class="label"> 信用额度: </td>
                      <td class="content"><asp:TextBox ID="txtCredit" runat="server" Width="180" Text="0"></asp:TextBox>元
                      </td>
                    </tr>
                    <tr><td colspan="2" align="center"><asp:Button ID="btnCreate" runat="server" CssClass="button" Text="添 加" OnClick="btnCreate_Click" />&nbsp;&nbsp;&nbsp;<input type="button" class="button" value="返 回" onclick="javascript:location.href='ClientList.aspx';" /></td></tr>
                </table>		
        </td>
    </tr>
  </table>
</form>
</body>
</html>
