<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateUser.aspx.cs" Inherits="Admin_PostSetting_CreateUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../JS/Calendar/WdatePicker.js"></script>
</head>
<body>
<form id="form1" runat="server">   
  <wl:CompanySettingNav ID="companySettingNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">物流设置 > 公司设定 > 添加员工</td>
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
                      <td align="left" class="label" colspan="2" height="32px" valign="middle">公司名称: <span style=" font-size:12px; color:Maroon;"><%=company.Name %></span> </td>
                    </tr>
                    <tr>
                      <td class="label" width="12%"> 用 户 名: </td>
                      <td class="content" width="88%"><asp:TextBox ID="txtUsername" runat="server" Width="180"></asp:TextBox>
                      </td>
                    </tr>
                    <tr>
                      <td class="label"> 密&nbsp;&nbsp;&nbsp;&nbsp;码: </td>
                      <td class="content"><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="180"></asp:TextBox>
                      </td>
                    </tr>
                    <tr>
                      <td class="label"> 确认密码: </td>
                      <td class="content"><asp:TextBox ID="txtRePassword" runat="server" TextMode="Password" Width="180"></asp:TextBox>
                      </td>
                    </tr>               
                    <tr>
                      <td class="label"> 真实姓名: </td>
                      <td class="content"><asp:TextBox ID="txtRealName" runat="server" Width="180"></asp:TextBox>
                      </td>
                    </tr>
                    <tr>
                      <td class="label"> 性&nbsp;&nbsp;&nbsp;&nbsp;别: </td>
                      <td class="content"><input type="radio" name="rdoSex" id="rdoSex1"  value="1" checked="checked" /><label for="rdoSex1" >男</label>  <input type="radio" name="rdoSex" id="rdoSex2" value="0" runat="server"/><label for="rdoSex2">女</label>
                      </td>
                    </tr>
                    <tr>
                      <td class="label"> 民&nbsp;&nbsp;&nbsp;&nbsp;族: </td>
                      <td class="content"><select id="slNation" name="slNation" runat="server">
                                            <option value="汉族">汉族</option>
                                            <option value="蒙古族">蒙古族</option>
                                            <option value="回族">回族</option>
                                            <option value="藏族">藏族</option>
                                            <option value="维吾尔族">维吾尔族</option>
                                            <option value="苗族">苗族</option>
                                            <option value="彝族">彝族</option>
                                            <option value="壮族">壮族</option>
                                            <option value="布依族">布依族</option>
                                            <option value="朝鲜族">朝鲜族</option>
                                            <option value="满族">满族</option>
                                            <option value="侗族">侗族</option>
                                            <option value="瑶族">瑶族</option>
                                            <option value="白族">白族</option>
                                            <option value="土家族">土家族</option>
                                            <option value="哈尼族">哈尼族</option>
                                            <option value="哈萨克族">哈萨克族</option>
                                            <option value="傣族">傣族</option>
                                            <option value="黎族">黎族</option>
                                            <option value="僳僳族">僳僳族</option>
                                            <option value="佤族">佤族</option>
                                            <option value="畲族">畲族</option>
                                            <option value="高山族">高山族</option>
                                            <option value="拉祜族">拉祜族</option>
                                            <option value="水族">水族</option>
                                            <option value="东乡族">东乡族</option>
                                            <option value="纳西族">纳西族</option>
                                            <option value="景颇族">景颇族</option>
                                            <option value="柯尔克孜族">柯尔克孜族</option>
                                            <option value="土族">土族</option>
                                            <option value="达斡尔族">达斡尔族</option>
                                            <option value="仫佬族">仫佬族</option>
                                            <option value="羌族">羌族</option>
                                            <option value="布朗族">布朗族</option>
                                            <option value="撒拉族">撒拉族</option>
                                            <option value="毛南族">毛南族</option>
                                            <option value="仡佬族">仡佬族</option>
                                            <option value="锡伯族">锡伯族</option>
                                            <option value="阿昌族">阿昌族</option>
                                            <option value="普米族">普米族</option>
                                            <option value="塔吉克族">塔吉克族</option>
                                            <option value="怒族">怒族</option>
                                            <option value="乌兹别克族">乌兹别克族</option>
                                            <option value="俄罗斯族">俄罗斯族</option>
                                            <option value="鄂温克族">鄂温克族</option>
                                            <option value="德昂族">德昂族</option>
                                            <option value="保安族">保安族</option>
                                            <option value="裕固族">裕固族</option>
                                            <option value="京族">京族</option>
                                            <option value="塔塔尔族">塔塔尔族</option>
                                            <option value="独龙族">独龙族</option>
                                            <option value="鄂伦春族">鄂伦春族</option>
                                            <option value="赫哲族">赫哲族</option>
                                            <option value="门巴族">门巴族</option>
                                            <option value="珞巴族">珞巴族</option>
                                            <option value="基诺族">基诺族</option>
                                          </select>
                      </td>
                    </tr>
                    
                    <tr>
                      <td class="label"> 学&nbsp;&nbsp;&nbsp;&nbsp;历: </td>
                      <td class="content"><select id="slEducation" name="slEducation" runat="server">
                                            <option value="初中" >初中</option>
                                            <option value="高中">高中</option>
                                            <option value="专科" selected="selected">专科</option>
                                            <option value="本科">本科</option>
                                            <option value="硕士">硕士</option>
                                            <option value="博士">博士</option>
                                            <option value="博士后">博士后</option>
                                            </select>
                      </td>
                    </tr>
                    <tr>
                      <td class="label"> 婚姻状况: </td>
                      <td class="content"><select id="slMaritalStatus" name="slMaritalStatus" runat="server">
                                            <option value="未婚">未婚</option>
                                            <option value="已婚">已婚</option>
                                            <option value="离异">离异</option>
                                            <option value="丧偶">丧偶</option>
                                            </select>
                      </td>
                    </tr>
                    <tr>
                      <td class="label"> 出生日期: </td>
                      <td class="content"><input type="text" onclick="WdatePicker()" runat="server" id="txtBirthday" name="txtBirthday" size="29" readonly="readonly" />
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
                      <td class="content"><asp:TextBox ID="txtEmail" runat="server" Width="130"></asp:TextBox>                        
                         
                      </td>
                    </tr>
                    <tr>
                      <td class="label"> 地&nbsp;&nbsp;&nbsp;&nbsp;址: </td>
                      <td class="content"><asp:TextBox ID="txtAddress" runat="server" Width="280"></asp:TextBox>                     
                         
                      </td>
                    </tr>
                    <tr>
                      <td class="label"> 部&nbsp;&nbsp;&nbsp;&nbsp;门: </td>
                      <td class="content">
                          <asp:DropDownList ID="ddlDepartment" runat="server">
                          </asp:DropDownList>
                      </td>
                    </tr>
                    <tr>
                      <td class="label"> 职&nbsp;&nbsp;&nbsp;&nbsp;位: </td>
                      <td class="content">
                          <wl:UserPositionDropDownList ID="ddlPosition" runat="server"></wl:UserPositionDropDownList>
                      </td>
                    </tr>
                    <tr>
                      <td class="label"> 入职时间: </td>
                      <td class="content"><input type="text" onclick="WdatePicker()" runat="server" id="txtJoinDate" size="29" readonly="readonly" />
                      </td>
                    </tr>
                    <tr>
                      <td class="label"> 合同有效期: </td>
                      <td class="content"><input type="text" onclick="WdatePicker()" runat="server" id="txtContractDate" size="29" readonly="readonly" />
                      </td>
                    </tr>
                    <tr>
                      <td class="label"> 提&nbsp;&nbsp;&nbsp;&nbsp;成: </td>
                      <td class="content"><asp:TextBox ID="txtCommission" runat="server" Width="180"></asp:TextBox>(0 - 1之间的数字)
                      </td>
                    </tr>
                    <tr><td colspan="2" align="center"><asp:Button ID="btnCreate" runat="server" CssClass="button" Text="添 加" OnClick="btnCreate_Click" />&nbsp;&nbsp;&nbsp;<input type="button" class="button" value="返 回" onclick="javascript:location.href='Default.aspx';" /></td></tr>
                </table>		
        </td>
    </tr>
  </table>
</form>
</body>
</html>
