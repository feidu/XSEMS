<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateReceiveOrder.aspx.cs" Inherits="Admin_Order_CreateReceiveOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="/Admin/JS/ClientList.js"></script>
<script language="javascript" type="text/javascript" src="/Admin/JS/Calendar/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
function openClientWindow()
    {
        window.open("../../Config/ClientList.aspx?id="+document.getElementById('hdCompanyId').value+"","客户列表","toolbar=no,top=20,left=150,width=600,height=550,menubar=no,scrollbars=yes,resizable=yes,status=yes","");
    }  

</script>
</head>
<body>
<form id="form1" runat="server">   
  <wl:OrderNav ID="orderNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">业务管理 > 收件计划 > 添加收件计划</td>
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
                  <td width="10%" class="label"> 客户姓名: </td>
                  <td width="90%" class="content"><table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                    <td align="left" width="24%"><input id="txtClientName" type="text" style="width:97%;color:#555555;" runat="server" readonly="readonly" /></td>
                    <td align="left" width="76%"><input type="image" src="../Images/btn_bg1.gif" onclick="openClientWindow()" />
                    <input id="hdCompanyId" name="hdCompanyId" type="hidden" value="<%=companyId %>" /></td></tr></table>
                  </td>
                </tr>    
                <tr>
                <td class="label" >发货日期:</td>
                <td class="content"><input type="text" onclick="WdatePicker()" class="Wdate" style=" width:179px;" runat="server" id="txtCreateDate" readonly="readonly" /></td>
                </tr>  
                <tr>
                  <td class="label"> 收货方式: </td>
                  <td class="content"><asp:DropDownList ID="ddlReceiveType" runat="server">
                                <asp:ListItem Value="上门收件" Text="上门收件"></asp:ListItem>
                                <asp:ListItem Value="客户送货" Text="客户送货"></asp:ListItem>
                                <asp:ListItem Value="快递送货" Text="快递送货"></asp:ListItem>
                              </asp:DropDownList>

                  </td>
                </tr>                   
                <tr>
                  <td class="label"> 结算方式: </td>
                  <td class="content"><wl:CalculateTypeDropDownList ID="ddlCalculateType" runat="server"/>
                  </td>
                </tr>     
                <tr>
                  <td class="label"> 备&nbsp;&nbsp;&nbsp;&nbsp;注: </td>
                  <td class="content"><asp:TextBox ID="txtRemark" TextMode="MultiLine" Rows="2" runat="server" Width="100%"></asp:TextBox>                                               
                  </td>
                </tr>                            
                <tr><td colspan="2" align="center"><asp:Button ID="btnCreate" runat="server" CssClass="button" Text="提 交" OnClick="btnCreate_Click" />&nbsp;&nbsp;&nbsp;<input type="button" class="button" value="返 回" onclick="javascript:location.href='Default.aspx'"/></td></tr>
            </table>		
		</td>
    </tr>
  </table>
</form>
</body>
</html>

