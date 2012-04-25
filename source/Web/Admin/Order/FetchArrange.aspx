<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FetchArrange.aspx.cs" Inherits="Admin_Order_FetchArrange" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="/Admin/JS/Calendar/WdatePicker.js"></script>
</head>
<body>
<form id="form1" runat="server">   
  <wl:OrderNav ID="orderNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">业务管理 > 取件安排 > 取件安排详情</td>
    </tr>       
    <tr>
        <td class="seperator"></td>
    </tr>
    <tr>
        <td class="info"><asp:Button ID="btnUpdate" runat="server" Text="修 改" CssClass="button" OnClick="btnUpdate_Click" />&nbsp;&nbsp;<asp:Button ID="btnDelete" runat="server" Text="删 除" CssClass="button" OnClientClick="return confirm('您确认要删除？');" OnClick="btnDelete_Click" />&nbsp;&nbsp;<input type="button" class="button" value="返 回" onclick="javascript:location.href='FetchArrangeList.aspx';" /></td>
    </tr>
  </table>
  <table class="tablecontent">
    <tr><td align="center"><asp:Label ID="lblMsg" runat="server" ForeColor="red" Text=""></asp:Label></td></tr>
    <tr>
      <td><table class="grid">
              <tr>
                   <td class="label" width="9%">客户姓名:</td>
                   <td class="content" width="14%"><asp:Label ID="lblClientName" runat="server" Text=""></asp:Label></td>
                   <td class="label" width="9%">联系电话:</td>
                   <td class="content" width="24%"><asp:TextBox ID="txtPhone" runat="server" Width="180"></asp:TextBox></td>
                   <td class="label" width="9%">预约时间:</td>
                   <td class="content" width="25%"><input type="text" onclick="WdatePicker({minDate:'%y-%M-{%d}'})" runat="server" id="txtFetchTime" name="txtDate" size="12" readonly="readonly" /> 
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
                            </select>分</td>
                </tr>   
                <tr>
                   <td class="label">制单类型:</td>
                   <td class="content"><asp:Label ID="lblType" runat="server" Text=""></asp:Label></td>
                   <td class="label">制 单 人:</td>
                   <td class="content"><asp:Label ID="lblCreateUser" runat="server" Text=""></asp:Label></td>
                   <td class="label" >制单时间:</td>
                   <td class="content"><asp:Label ID="lblCreateTime" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                   <td class="label" >取件地址:</td>
                   <td class="content" colspan="5"><asp:TextBox ID="txtFetchAddress" runat="server" Width="100%"></asp:TextBox></td>
                </tr>      
                <tr>
                   <td class="label" >备&nbsp;&nbsp;&nbsp;&nbsp;注:</td>
                   <td class="content" colspan="5"><asp:TextBox ID="txtRemark" TextMode="MultiLine" Rows="2" runat="server" Width="100%"></asp:TextBox></td>
                </tr>                   
            </table>		
        </td>
    </tr>
  </table>
</form>
</body>
</html>
