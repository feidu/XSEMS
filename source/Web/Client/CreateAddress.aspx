<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateAddress.aspx.cs" Inherits="Client_CreateAddress" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<wl:Seo ID="seo" runat="server" Title=""/>
<link href="../Css/style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="/Admin/JS/Calendar/WdatePicker.js"></script>
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
                 <tr><td align="left" class="top_content"><wl:ClientTop runat="server" id="clientTop" Title="添加发件人地址信息"></wl:ClientTop></td></tr> 
                 <tr><td align="center"><asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td></tr>
                 <tr>
                  <td><table class="grid">    
                        <tr>
                          <td class="label" width="13%"> 所在地区: </td>
                          <td class="content" width="87%"><select id="slProvince" name="slProvince" runat="server">
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
                                  <option value="其他省份">其他省份 </option>
                              </select> <span style="color:Red">*</span>                             
                          </td>
                        </tr> 
                        <tr>                          
                          <td class="label"> 发件人姓名: </td>
                          <td class="content"><asp:TextBox ID="txtSenderName" runat="server"></asp:TextBox> <span style="color:Red">*</span> 
                          </td>
                        </tr> 
                        <tr>
                          <td class="label"> 联系电话: </td>
                          <td class="content"><asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                          </td>
                        </tr>
                        <tr>
                          <td class="label"> 传&nbsp;&nbsp;&nbsp;&nbsp;真: </td>
                          <td class="content"><asp:TextBox ID="textFax" runat="server"></asp:TextBox>
                          </td>
                        </tr>                
                        <tr>                          
                          <td class="label"> 电子邮件: </td>
                          <td class="content"><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                          </td>
                        </tr> 
                        <tr>                          
                          <td class="label"> 邮&nbsp;&nbsp;&nbsp;&nbsp;编: </td>
                          <td class="content"><asp:TextBox ID="txtPostCode" runat="server"></asp:TextBox>
                          </td>
                        </tr> 
                        <tr>                          
                          <td class="label"> 联系地址: </td>
                          <td class="content"><asp:TextBox ID="txtAddress" runat="server" 
                                  Width="606px"></asp:TextBox> <span style="color:Red">*</span>
                          </td>
                        </tr>        
                        <tr>                          
                          <td class="label"> 备&nbsp;&nbsp;&nbsp;&nbsp;注: </td>
                          <td class="content"><asp:TextBox ID="txtRemark" runat="server" 
                                  Width="606px"></asp:TextBox>
                          </td>
                        </tr>            
                        <tr><td colspan="2" align="center"><asp:Button ID="btnUpdate" runat="server" Text="提 交" CssClass="button" OnClick="btnCreate_Click" /></td></tr>
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

