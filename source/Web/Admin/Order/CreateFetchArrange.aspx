<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateFetchArrange.aspx.cs" Inherits="Admin_Order_CreateFetchArrange" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<link href="../Css/DivPopup.css" rel="stylesheet" type="text/css" />
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
        <td class="info2">业务管理 > 取件安排 > 添加取件安排</td>
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
                  <td width="9%" class="label"> 客户姓名: </td>
                  <td width="91%" class="content"><table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                    <td align="left" width="20%"><input id="txtClientName" type="text" style="width:96%;color:#555555;" runat="server" readonly="readonly" /></td>
                    <td align="left" width="80%"><input type="image" src="../Images/btn_bg1.gif" onclick="openClientWindow()" />
                    <input id="hdCompanyId" name="hdCompanyId" type="hidden" value="<%=companyId %>" /></td></tr></table>
                  </td>
                </tr>              
                <tr>
                  <td class="label"> 联系电话: </td>
                  <td class="content"><asp:TextBox ID="txtPhone" runat="server" Width="180"></asp:TextBox>
                  </td>
                </tr>
                <tr>
                  <td class="label"> 取件地址: </td>
                  <td class="content"><asp:TextBox ID="txtFetchAddress" runat="server" Width="280"></asp:TextBox>
                  </td>
                </tr> 
                <tr>
                  <td class="label"> 预约时间: </td>
                  <td class="content"><input type="text" onclick="WdatePicker({minDate:'%y-%M-{%d}'})" runat="server" id="txtFetchTime" name="txtDate" size="12" readonly="readonly" /> 
                      <select id="slHour" name="slHour" runat="server">
                            <option value="8" >8</option>
                            <option value="9">9</option>
                            <option value="10">10</option>
                            <option value="11">11</option>
                            <option value="12">12</option>
                            <option value="13">13</option>
                            <option value="14">14</option>
                            <option value="14">15</option>
                            <option value="14">16</option>
                            <option value="14">17</option>
                            <option value="14">18</option>                                            
                            </select>时 
                            <select id="slMinute" name="slHour" runat="server">
                            <option value="0">0</option>
                            <option value="5">5</option>
                            <option value="10">10</option>
                            <option value="15">15</option>
                            <option value="20">20</option>
                            <option value="25">25</option>
                            <option value="30">30</option>
                            <option value="35">35</option>
                            <option value="40">40</option>
                            <option value="45">45</option>
                            <option value="50">50</option>
                            <option value="55">55</option>                                            
                            </select>分                                           
                     </td>
                </tr>    
                <tr>
                  <td class="label"> 备&nbsp;&nbsp;&nbsp;&nbsp;注: </td>
                  <td class="content"><asp:TextBox ID="txtRemark" TextMode="MultiLine" Rows="2" runat="server" Width="100%"></asp:TextBox>                                               
                  </td>
                </tr>                            
                <tr><td colspan="2" align="center"><asp:Button ID="btnCreate" runat="server" CssClass="button" Text="提 交" OnClick="btnCreate_Click" />&nbsp;&nbsp;&nbsp;<input type="button" class="button" value="返 回" onclick="javascript:location.href='FetchArrangeList.aspx'"/></td></tr>
            </table>		
		</td>
    </tr>
  </table>
</form>
</body>
</html>
