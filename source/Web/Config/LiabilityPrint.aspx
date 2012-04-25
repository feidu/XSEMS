<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LiabilityPrint.aspx.cs" Inherits="Config_LiabilityPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>责任认定书</title>
    <style type="text/css">
    .title{ font-size:24px; color:#222222; padding-top:13px; padding-bottom:10px;}
    .label{ font-size:12px; font-weight:bold; background-color:#E2E2E2; height:42px;}
    </style>    
</head>
<body>
<center>
    <form id="form1" runat="server">
    <div>    
        <table border="0" cellpadding="0" cellspacing="0" width="80%" style="font-size:12px;">
        <tr>
          <td>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr><td colspan="2" style="height:18px;"></td></tr>
                <tr>
                    <td align="left">亿度物流</td>
                    <td align="right">宁波亿度物流有限公司</td>
                </tr>
                <tr><td align="center" colspan="2"><hr style="width:100%;" /></td></tr>
                <tr><td align="center" colspan="2" class="title">责任认定书</td></tr>
            </table>
          </td>
        </tr>
        <tr>
          <td><table width="100%" border="1" cellpadding="0" cellspacing="0" style="border-color:#CCCCCC; border-bottom:0px; line-height:24px;">
              <tr>
                <td width="13%" align="left" valign="middle"class="label">认定书编号:</td>
                <td width="21%" align="left" valign="middle">&nbsp;<asp:Label ID="lblEncode" runat="server"></asp:Label>&nbsp;</td>
                <td width="13%" align="left" valign="middle" class="label" >收件单号:</td>
                <td width="21%" align="left" valign="middle">&nbsp;<asp:Label ID="lblOrderEncode" runat="server"></asp:Label>&nbsp;</td>
                <td width="12%" align="left" valign="middle" class="label" >收件日期:</td>
                <td width="20%" align="left" valign="middle">&nbsp;<asp:Label ID="lblReceiveDate" runat="server"></asp:Label>&nbsp;</td>
              </tr>          
              <tr>            
                <td align="left" valign="middle"class="label">跟踪单号:</td>
                <td align="left" valign="middle">&nbsp;<asp:Label ID="lblBarCode" runat="server"></asp:Label>&nbsp;</td>           
                <td align="left" valign="middle" class="label">跟进业务员:</td>
                <td align="left" valign="middle">&nbsp;<asp:Label ID="lblOrderUser" runat="server"></asp:Label>&nbsp;</td>        
                <td align="left" valign="middle" class="label">制 单 人:</td>
                <td align="left" valign="middle">&nbsp;<asp:Label ID="lblCreateUser" runat="server"></asp:Label>&nbsp;</td>
              </tr>        
              <tr>            
                <td align="left" valign="middle"class="label">事件类型:</td>
                <td align="left" valign="middle">&nbsp;<asp:Label ID="lblEventType" runat="server"></asp:Label>&nbsp;</td>           
                <td align="left" valign="middle" class="label">更正状态:</td>
                <td align="left" valign="middle">&nbsp;<asp:Label ID="lblCorrectStatus" runat="server"></asp:Label>&nbsp;</td>        
                <td align="left" valign="middle" class="label">货&nbsp;&nbsp;&nbsp;&nbsp;币:</td>
                <td align="left" valign="middle">&nbsp;<asp:Label ID="lblCurrencyType" runat="server"></asp:Label>&nbsp;</td>
              </tr>        
              <tr>            
                <td align="left" valign="middle"class="label">填 表 人:</td>
                <td align="left" valign="middle">&nbsp;<asp:Label ID="lblFillUser" runat="server"></asp:Label>&nbsp;</td>           
                <td align="left" valign="middle" class="label">填表日期:</td>
                <td colspan="3" align="left" valign="middle">&nbsp;<asp:Label ID="lblFillTime" runat="server"></asp:Label>&nbsp;</td>        
              </tr>    
              <tr>
                <td align="left" valign="middle"class="label" style="height:80px;">事情经过:</td>
                <td colspan="5" align="left" valign="middle">&nbsp;<asp:Label ID="lblDetail" runat="server"></asp:Label>&nbsp;</td>          
              </tr>    
              <tr>
                <td align="left" valign="middle"class="label" style="height:65px;">处理结果:</td>
                <td colspan="5" align="left" valign="middle">&nbsp;<asp:Label ID="lblResult" runat="server"></asp:Label>&nbsp;</td>          
              </tr>                
             </table>		
          </td>
        </tr>    
        <tr>
            <td><table width="100%" border="1" cellpadding="0" cellspacing="0" style="border-color:#CCCCCC; border-top:0px; line-height:14px;">
              <tr>
                <td align="left" valign="middle"class="label">责任<br />总金额:</td>
                <td colspan="7" align="left" valign="middle">&nbsp;<asp:Label ID="lblTotalMoney" runat="server" ></asp:Label>&nbsp;</td>
              </tr>
              <tr>
                <td width="9%" align="left" valign="middle"class="label">责任<br />部门:</td>
                <td width="22%" align="left" valign="middle">&nbsp;<asp:Label ID="lblZrDepartment" runat="server"></asp:Label>&nbsp;</td>
                <td width="13%" align="left" valign="middle"class="label">承担<br />金额:</td>
                <td width="12%" align="left" valign="middle">&nbsp;<asp:Label ID="lblZrDtMoney" runat="server"></asp:Label>&nbsp;</td>
                <td width="13%" align="left" valign="middle"class="label">责任人:</td>
                <td width="12%" align="left" valign="middle">&nbsp;<asp:Label ID="lblZrUser" runat="server"></asp:Label>&nbsp;</td>
                <td width="7%" align="left" valign="middle"class="label">承担<br />金额:</td>
                <td width="12%" align="left" valign="middle">&nbsp;<asp:Label ID="lblZrUrMoney" runat="server"></asp:Label>&nbsp;</td>
              </tr>          
              <tr>            
                <td align="left" valign="middle"class="label">客户<br />姓名:</td>
                <td align="left" valign="middle">&nbsp;<asp:Label ID="lblClientName" runat="server"></asp:Label>&nbsp;</td>           
                <td align="left" valign="middle"class="label">客户付<br />给亿度:</td>
                <td align="left" valign="middle">&nbsp;<asp:Label ID="lblClientPtEadu" runat="server"></asp:Label>&nbsp;</td>        
                <td align="left" valign="middle"class="label">亿度付<br />给客户:</td>
                <td colspan="3" align="left" valign="middle">&nbsp;<asp:Label ID="lblEaduPtClient" runat="server"></asp:Label>&nbsp;</td>
              </tr>      
              <tr>            
                <td align="left" valign="middle"class="label">承运商:</td>
                <td align="left" valign="middle">&nbsp;<asp:Label ID="lblCarrier" runat="server"></asp:Label>&nbsp;</td>           
                <td align="left" valign="middle"class="label">承运商<br />付给亿度:</td>
                <td align="left" valign="middle">&nbsp;<asp:Label ID="lblCarrierPtEadu" runat="server"></asp:Label>&nbsp;</td>        
                <td align="left" valign="middle"class="label">亿度付给<br />承运商:</td>
                <td colspan="3" align="left" valign="middle">&nbsp;<asp:Label ID="lblEaduPtCarrier" runat="server"></asp:Label>&nbsp;</td>
              </tr>      
              <tr>
                <td align="left" valign="middle"class="label">负责人:</td>
                <td align="left" valign="middle">&nbsp;<asp:Label ID="lblLiabilityUser" runat="server"></asp:Label>&nbsp;</td>
                <td align="left" valign="middle"class="label">更正:</td>
                <td align="left" valign="middle">&nbsp;<asp:Label ID="lblCorrectUser" runat="server"></asp:Label>&nbsp;</td>
                <td align="left" valign="middle"class="label">财务:</td>
                <td align="left" valign="middle">&nbsp;<asp:Label ID="lblFinanceUser" runat="server"></asp:Label>&nbsp;</td>
                <td align="left" valign="middle"class="label">出纳:</td>
                <td align="left" valign="middle">&nbsp;<asp:Label ID="lblCashierUser"  runat="server"></asp:Label>&nbsp;</td>
              </tr>         
             </table>
            </td>
        </tr>         
      </table>
    </div>
    </form>
    </center>
</body>
</html>
