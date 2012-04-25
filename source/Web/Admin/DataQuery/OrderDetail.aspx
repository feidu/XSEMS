<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderDetail.aspx.cs" Inherits="Admin_DataQuery_OrderDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />

</head>
<body>
<form id="form1" runat="server">   
  <wl:DataQueryNav ID="dataQueryNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">数据查询 > 跟踪单号查询 > 订单明细</td>
    </tr>
    <tr>
        <td class="seperator"></td>
    </tr>      
  </table>
  <table class="tablecontent">
     <tr><td align="center"><asp:Label ID="lblMsg" runat="server" ForeColor="red"></asp:Label></td></tr>
     <tr>
      <td><table class="grid">
          <tr>
            <td width="9%" class="label" >抵达国家:</td>
            <td width="25%" class="content"><asp:Label ID="lblCountry" runat="server"></asp:Label></td>
            <td width="11%" class="label" >物品类别:</td>
            <td width="22%" class="content"><asp:Label ID="lblGoodsType" runat="server" ></asp:Label></td>
            <td width="10%" class="label" >计费重量:</td>
            <td width="23%" class="content"><asp:Label ID="lblWeight" runat="server"></asp:Label> 千克</td>
          </tr>
          <tr>
            <td class="label">件&nbsp;&nbsp;&nbsp;&nbsp;数:</td>
            <td class="content"><asp:Label ID="lblCount" runat="server"></asp:Label> 件</td>
            <td class="label">承 运 商:</td>
            <td class="content" colspan="3"><asp:Label ID="lblCarrier" runat="server"></asp:Label></td>
          </tr>
          <tr>            
            <td class="label" >运费合计:</td>
            <td class="content"><asp:Label ID="lblPostCosts" runat="server" ForeColor="darkBlue"></asp:Label> 元</td>
            <td class="label" >挂 号 费:</td>
            <td class="content"><asp:Label ID="lblRegisterCosts" runat="server"></asp:Label> 元</td>     
            <td class="label">处 理 费:</td>
            <td class="content"><asp:Label ID="lblDisposalCosts" runat="server"></asp:Label> 元</td>          
          </tr>
          <tr>
            <td class="label">燃油附加费:</td>
            <td class="content"><asp:Label ID="lblFuelCosts" runat="server"></asp:Label> 元</td>
            <td class="label">偏远地区附加费:</td>
            <td class="content"><asp:Label ID="lblRemoteCosts" runat="server"></asp:Label> 元</td>
            <td class="label">取 件 费:</td>
            <td class="content"><asp:Label ID="lblFetchCosts" runat="server"></asp:Label> 元</td>                
          </tr>
          <tr>
            <td class="label">材 料 费:</td>
            <td class="content"><asp:Label ID="lblMaterialCosts" runat="server"></asp:Label> 元</td>
            <td class="label" >其它费用:</td>
            <td class="content" colspan="3"><asp:Label ID="lblOtherCosts" runat="server"></asp:Label> 元&nbsp;&nbsp;费用说明:<asp:Label ID="lblOtherCostsNote" runat="server"></asp:Label></td>          
          </tr>
          <tr>
            <td class="label">保 价 费:</td>
            <td class="content"><asp:Label ID="lblInsureCosts" runat="server"></asp:Label> 元</td>
            <td class="label">地址更改费:</td>
            <td class="content"><asp:Label ID="lblAddressChangeCosts" runat="server"></asp:Label> 元</td>
            <td class="label">退 件 费:</td>
            <td class="content"><asp:Label ID="lblReturnCosts" runat="server"></asp:Label> 元</td>                
          </tr>
          <tr>
            <td class="label">损失与赔偿:</td>
            <td class="content"><asp:Label ID="lblDamageMoney" runat="server"></asp:Label> 元</td>
            <td class="label">返&nbsp;&nbsp;&nbsp;&nbsp;利:</td>
            <td class="content"><asp:Label ID="lblReturnMoney" runat="server"></asp:Label> 元</td>
            <td class="label">应收费用:</td>
            <td class="content"><asp:Label ID="lblTotalCosts" runat="server" ForeColor="blue"></asp:Label> 元</td>                
          </tr>
          <tr><td colspan="6" height="18"></td></tr>
          <tr>
            <td class="label">包裹单号:</td>
            <td class="content"><asp:TextBox ID="txtBarCode" Width="98%" runat="server"></asp:TextBox></td>
            <td class="label">备&nbsp;&nbsp;&nbsp;&nbsp;注:</td>
            <td class="content"><asp:TextBox ID="txtRemark" Width="98%" runat="server"></asp:TextBox></td>
            <td class="label">亿度条码:</td>
            <td class="content"><asp:Label ID="lblEncode" runat="server"></asp:Label></td>                     
          </tr>  
          <tr>
            <td class="label">收件人姓名:</td>
            <td class="content"><asp:Label ID="lblToUsername" runat="server"></asp:Label></td>
            <td class="label">收件人电话:</td>
            <td class="content"><asp:Label ID="lblToPhone" runat="server"></asp:Label></td>
            <td class="label">收件人邮箱:</td>
            <td class="content"><asp:Label ID="lblToEmail" runat="server"></asp:Label></td>                
          </tr>
          <tr>
            <td class="label">收件人城市:</td>
            <td class="content"><asp:Label ID="lblToCity" runat="server"></asp:Label></td>
            <td class="label">收件人国家:</td>
            <td class="content"><asp:Label ID="lblToCountry" runat="server"></asp:Label></td>
            <td class="label">收件人邮编:</td>
            <td class="content"><asp:Label ID="lblToPostcode" runat="server"></asp:Label></td>                
          </tr>          
          <tr>
            <td class="label">收件人详址:</td>
            <td class="content" colspan="5"><asp:Label ID="lblToAddress" runat="server"></asp:Label></td>
          </tr>
         </table>
		</td>
    </tr>
    <tr>
        <td align="center"><asp:Button ID="btnUpdate" runat="server" Text="修 改" CssClass="button" OnClick="btnUpdate_Click" />&nbsp;&nbsp;&nbsp;<input type="button" class="button" value="返 回" onclick="javascript:location.href='OrderList.aspx'" /></td>
    </tr>  
  </table>
</form>
</body>
</html>