<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Quote.aspx.cs" Inherits="Admin_DataQuery_Quote" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<link href="../Css/DivPopup.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="/Admin/JS/ClientList.js"></script>
<script language="javascript" type="text/javascript" src="/Admin/JS/Calendar/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
function checkDetailCount()
{
    var detailCount=document.getElementById("hdQuoteDetailCount");
    if(parseInt(detailCount.value)<=0)
    {
        alert("此报价单还未添加明细！");
        return false;
    }
    return true;
}
</script>
</head>
<body>
<form id="form1" runat="server">   
  <wl:DataQueryNav ID="dataQueryNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">数据查询 > 报价查询 > 报价详情</td>
    </tr>
    <tr>
        <td class="seperator"><input type="hidden" id="hdQuoteDetailCount" value="<%=quoteDetailCount %>"/></td>
    </tr>
    <tr>
        <td class="info"><input type="button" class="button" value="返 回" onclick="javascript:location.href='QuoteList.aspx';" /></td>
    </tr>    
  </table>
  <table class="tablecontent">
    <tr><td align="center" style="height: 21px">
        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td></tr>
    <tr>
      <td>
      	 <table class="grid">
          <tr>
            <td width="10%" class="label" >报价单号:</td>
            <td width="23%" class="content"><asp:Label ID="lblEncode" runat="server" Text=""></asp:Label></td>
            <td width="10%" class="label" >报价日期:</td>
            <td width="24%" class="content"><input type="text" onclick="WdatePicker()" class="Wdate" runat="server" id="txtQuoteTime" readonly="readonly" /></td>
            <td width="10%" class="label" >所属公司:</td>
            <td width="23%" class="content"><asp:Label ID="lblCompanyName" runat="server" Text=""></asp:Label></td>
          </tr>
          <tr>
            <td class="label" >客户姓名:</td>
            <td class="content"><asp:TextBox ID="txtClientName" onkeyup="findColors();"  Width="180" runat="server" Text="请输入客户姓名拼音的首字母" onfocus="clearText()" onblur="repalyText()" style="color:#555555;"></asp:TextBox><asp:Label ID="lblClientNameTip" runat="server"></asp:Label>
                  <div id="popup" style="width:183px; position:absolute; left:118px; top:175px;">  
                        <ul id="colors_ul" style="padding-left:2px; background-color:White;">  
                        </ul>  
                    </div><input type="hidden" id="txtClientId" name="txtClientId" value="<%=sCompid %>"/></td>            
            <td class="label" >制 单 人:</td>
            <td class="content"><asp:Label ID="lblCreateUser" runat="server" Text=""></asp:Label></td>     
            <td class="label" >制单时间:</td>
            <td class="content"><asp:Label ID="lblCreateTime" runat="server" Text=""></asp:Label></td>              
          </tr>
          <tr>
            <td class="label" >备&nbsp;&nbsp;&nbsp;&nbsp;注:</td>
            <td class="content" colspan="5"><asp:TextBox TextMode="multiLine" Rows="2" Width="100%" runat="server" ID="txtRemark"></asp:TextBox></td>          
          </tr>         
         </table>	         
	  </td>
    </tr>    
    <tr>
      <td>
      	 <table class="grid">
          <tr>
            <td align="center" class="headers">序号</td>
            <td align="left" class="headers">承运商编号</td>
            <td align="left" class="headers">承运商名称</td>
            <td align="left" class="headers">区域</td>           
            <td align="left" class="headers">折扣</td>             
            <td align="center" class="headers">操作</td>
          </tr>
          <%
              if (result != null)
              {
                  int i = 1;
                  foreach (Backend.Models.QuoteDetail qd in result)
                  {
                      
               %>
              <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                <td align="center"><%=i%></td>
                <td align="left"><%=qd.Carrier.Encode%></td>
                <td align="left"><%=qd.Carrier.Name%></td>
                <td align="left"><%=qd.CarrierArea.Name%></td>
                <td align="left"><%=Backend.Utilities.StringHelper.CurtNumber(qd.Discount.ToString())%></td>                
                <td align="center"><a href="QuoteDetail.aspx?id=<%=qd.Id %>">查看</a></td>
              </tr>
              <% i++;
             }
         }%>   
         </table>	         
	  </td>
    </tr>
  </table>
</form>
</body>
</html>
