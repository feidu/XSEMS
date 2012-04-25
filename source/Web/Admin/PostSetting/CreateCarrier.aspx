<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateCarrier.aspx.cs" Inherits="Admin_PostSetting_CreateCarrier" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../JS/Calendar/WdatePicker.js"></script>
</head>
<body>
<form id="form1" runat="server">   
  <wl:PostSettingNav ID="postSettingNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">物流设置 > 承运商设定 > 添加承运商</td>
    </tr>
    <tr>
        <td class="info"><a href="CreateCarrier.aspx">添加承运商</a> | <a href="CarrierList.aspx">承运商列表</a></td>
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
                      <td class="label" width="14%"> 编&nbsp;&nbsp;&nbsp;&nbsp;号: </td>
                      <td class="content" width="36%"><asp:TextBox ID="txtEncode" runat="server" Width="180"></asp:TextBox>
                      </td>
                      <td class="label" width="14%"> 名&nbsp;&nbsp;&nbsp;&nbsp;称: </td>
                      <td class="content" width="36%"><asp:TextBox ID="txtName" runat="server" Width="180"></asp:TextBox>
                      </td>
                    </tr>            
                    <tr>
                      <td class="label"> 联 系 人: </td>
                      <td class="content"><asp:TextBox ID="txtContactPerson" runat="server" Width="180"></asp:TextBox>
                      </td>
                      <td class="label"> 联系电话: </td>
                      <td class="content"><asp:TextBox ID="txtPhone" runat="server" Width="180"></asp:TextBox>
                      </td>
                    </tr>                    
                    <tr>
                      <td class="label"> 联系地址: </td>
                      <td class="content"><asp:TextBox ID="txtAddress" runat="server" Width="100%"></asp:TextBox>
                      </td>
                      <td class="label"> 传&nbsp;&nbsp;&nbsp;&nbsp;真: </td>
                      <td class="content"><asp:TextBox ID="txtFax" runat="server" Width="180"></asp:TextBox>
                      </td>
                    </tr>
                    <tr>
                      <td class="label"> 电子邮箱: </td>
                      <td class="content"><asp:TextBox ID="txtEmail" runat="server" Width="180"></asp:TextBox>  
                      </td>
                      <td class="label"> 递送时间: </td>
                      <td class="content"><asp:TextBox ID="txtTransportTime" runat="server" Width="180"></asp:TextBox>（工作日）
                      </td>
                    </tr>                            
                    <tr>
                      <td class="label"> 回邮地址: </td>
                      <td class="content" colspan="3"><asp:TextBox ID="txtReturnAddress" runat="server" Width="100%"></asp:TextBox>
                      </td>                      
                    </tr>                       
                    <tr>
                      <td class="label"> 代理折扣: </td>
                      <td class="content"><asp:TextBox ID="txtAgencyDiscount" runat="server" Width="180"></asp:TextBox> (0 - 1之间的数字)
                      </td>
                      <td class="label"> 客户折扣: </td>
                      <td class="content"><asp:TextBox ID="txtClientDiscount" runat="server" Width="180"></asp:TextBox> (0 - 2之间的数字)
                      </td>
                    </tr> 
                    <tr>
                      <td class="label"> 燃油附加率: </td>
                      <td class="content"><asp:TextBox ID="txtFuelRate" runat="server" Width="180" Text="0"></asp:TextBox> (0 - 1之间的数字)
                      </td>
                      <td class="label"> 是否可追踪: </td>
                      <td class="content"><asp:CheckBox ID="chkFollow" runat="server" />
                      </td>
                    </tr>                     
                    <tr>
                      <td class="label"> 是否限重: </td>
                      <td class="content"><asp:CheckBox ID="chkLimitWeight" runat="server" />
                      </td>
                      <td class="label"> 重量范围: </td>
                      <td class="content">大于：<asp:TextBox ID="txtMinWeight" Width="50" Text="0" runat="server"></asp:TextBox>千克&nbsp;&nbsp;小于<asp:TextBox ID="txtMaxWeight" Text=""  Width="50" runat="server"></asp:TextBox>千克</td>
                    </tr>                     
                    <tr>
                      <td class="label"> 是否开放接口: </td>
                      <td class="content"><asp:CheckBox ID="chkOpenApi" runat="server" />
                      </td>
                      <td class="label"> 是否有商业发票: </td>
                      <td class="content"><asp:CheckBox ID="chkInvoice" runat="server" />
                      </td>
                    </tr> 
                    <tr>
                      <td class="label"> 报价方式: </td>
                      <td class="content"><select id="slQuoteType" runat="server">
                        <option value="按折扣">按折扣</option>
                        <option value="按价格">按价格</option>
                      </select>
                      </td>
                      <td class="label"> 是否按体积重量计费: </td>
                      <td class="content"><asp:CheckBox ID="chkChargeWv" runat="server" />
                      </td>
                    </tr> 
                    <tr>
                      <td class="label"> 是否有效: </td>
                      <td class="content"><asp:CheckBox ID="chkUseable" runat="server" Checked="true" />
                      </td>
                      <td class="label"> 是否客户端显示: </td>
                      <td class="content"><asp:CheckBox ID="chkClientShow" runat="server" Checked="true" />
                      </td>
                    </tr> 
                    <tr>
                      <td class="label"> 备&nbsp;&nbsp;&nbsp;&nbsp;注: </td>
                      <td class="content" colspan="3"><asp:TextBox ID="txtRemark" runat="server" Width="100%" TextMode="MultiLine" Rows="2"></asp:TextBox>
                      </td>
                    </tr>
                    <tr><td colspan="4" align="center"><asp:Button ID="btnCreate" CssClass="button" runat="server" Text="添 加" OnClick="btnCreate_Click" /> &nbsp;&nbsp;&nbsp;<input type="button" class="button" value="返 回" onclick="javascript:location.href='CarrierList.aspx';" /></td></tr>
                </table>		
        </td>
    </tr>
  </table>
</form>
</body>
</html>
