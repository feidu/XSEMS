<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreatePostPlan.aspx.cs" Inherits="Admin_Order_CreatePostPlan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">   
  <wl:OrderNav ID="orderNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">业务管理 > 发件计划 > 添加发件计划</td>
    </tr>
    <tr>
        <td class="seperator"></td>
    </tr>
  </table>
  <table class="tablecontent">
     <tr>
      <td><table class="grid">
                <tr>
                  <td colspan="2" align="center" style="height: 21px">
                      <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td>
                </tr>     
                <tr>
                  <td width="16%" align="right" class="label"> 承 运 商: </td>
                  <td width="84%" align="left" class="content"><wl:CarrierDropDownList ID="ddlCarrier" runat="server"></wl:CarrierDropDownList>
                  </td>
                </tr>              
                <tr>
                  <td width="16%" align="right" class="label"> 发件包裹数量: </td>
                  <td width="84%" align="left" class="content"><asp:TextBox ID="txtPackageCount" Width="180" runat="server" ></asp:TextBox>                  
                  </td>
                </tr>
                <tr>
                  <td width="16%" align="right" class="label"> 总 重 量: </td>
                  <td width="84%" align="left" class="content"><asp:TextBox ID="txtWeight" runat="server" Width="180"></asp:TextBox> 千克
                  </td>
                </tr>
                <tr>
                  <td width="16%" align="right" class="label"> 装袋仓库: </td>
                  <td width="84%" align="left" class="content"><asp:DropDownList ID="ddlDepot" runat="server"></asp:DropDownList>
                  </td>
                </tr>                
                <tr><td colspan="2" align="center"><asp:Button ID="btnCreate" runat="server" CssClass="button" Text="提 交" OnClick="btnCreate_Click" />&nbsp;&nbsp;&nbsp;<input type="button" class="button" value="返 回" onclick="javascript:location.href='PostPlanList.aspx'"/></td></tr>
            </table>		
		</td>
    </tr>
  </table>
  <wl:Pagination ID="pagi" runat="server"/>  
</form>
</body>
</html>
