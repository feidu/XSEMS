<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClientOrderList.aspx.cs" Inherits="Client_ClientOrderList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<wl:Seo ID="seo" runat="server" Title=""/>
<link href="../Css/style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../Admin/JS/Calendar/WdatePicker.js"></script>
<script src="../Admin/JS/jquery-1.7.1.min.js" type="text/javascript"></script>
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
              
              <!--中间右边内容部分--> 
              <table class="tablecontent">
                <tr><td align="left" class="top_content"><wl:ClientTop runat="server" id="clientTop" Title="订单收件人标签打印"></wl:ClientTop></td></tr>  
                <tr><td align="left" valign="bottom" style="padding-left:5px;">日期范围：<input class="Wdate" type="text" onclick="WdatePicker()" runat="server" id="txtStartDate" readonly="readonly"/> 至 <input class="Wdate" type="text" onclick="WdatePicker()" runat="server" id="txtEndDate" readonly="readonly"/>&nbsp;&nbsp;<input type="button" id="btnSerach" runat="server" value="查 询" class="button" onserverclick="btnSerach_ServerClick"/>&nbsp;&nbsp;<asp:Button ID="btnPrint" runat="server" CssClass="button" Text="打 印" OnClick="btnPrint_Click" /></td></tr>  
                <tr>
                  <td><table class="grid" id="dg1">
                          <tr>
                            <th align="left" class="header_client">订单编码</th>
                            <th align="left" class="header_client">收件人姓名</th>
                            <th align="left" class="header_client">国家</th>
                            <th align="left" class="header_client">城市</th> 
                            <th align="left" class="header_client">邮编</th>           
                            <th align="left" class="header_client">地址</th>
                            <th align="left" class="header_client">录入时间</th>  
                            <th align="left" class="header_client"><input type="checkbox" id='chkAll'/></th>                                                          
                          </tr>
                          <tbody>
                          <asp:Repeater ID="rpOrder" runat="server">
                            <ItemTemplate>
                              <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                                <td align="left"><%# Eval("Encode")%></td>
                                <td align="left"><%# Eval("RealName")%></td>
                                <td align="left"><%# Eval("Country")%></td>    
                                <td align="left"><%# Eval("City")%></td>  
                                <td align="left"><%# Eval("Postcode")%></td>      
                                <td align="left"><%# Eval("Address")%></td>                                     
                                <td align="left"><%# Convert.ToDateTime(Eval("tracking_time")) > new DateTime(1999, 1, 1) ? "" + Eval("tracking_time") + "" : ""%></td>  
                                <td align="left"><input type="checkbox" name="chkItem" class="inputCheckbox" code='<%#Eval("Id") %>' /></td>
                              </tr>
                            </ItemTemplate>                           
                          </asp:Repeater>     
                          </tbody>                                           
                        </table>		
		            </td>
                </tr>      
                <tr><td align="right"><asp:Button ID="btnDeleteAll" Text="删除全部" runat="server" OnClientClick="confirm('确认删除全部？');"
                        onclick="btnDeleteAll_Click" />&nbsp;&nbsp;<asp:Button ID="btnDelete" Text="删除选择项" runat="server" OnClientClick="return vali();"
                        onclick="btnDelete_Click" /></td></tr>          
              </table>              
              <wl:Pagination ID="pagi" runat="server"/>
            </div>
          </div>
        </div>
        <!--尾部-->
        <wl:Footer ID="footer" runat="server" />
      </div>
    </div>
  </div>
  <script type="text/javascript">
      //全选/反选
      $("#chkAll").click(function () {
          $('#dg1 > tbody > tr > td > input:checkbox').attr("checked", this.checked);
      });

      //若所有tbody中的项都选中了,自动将表头中的chkAll选中.
      $("#dg1 > tbody > tr > td > input:checkbox").click(function () {
          //获取所有选中的checkbox元素
          var expression1 = $("#dg1 > tbody > tr > td > input:checkbox:checked");
          //获取所有checkbox元素
          var expression2 = $("#dg1 > tbody > tr > td > input:checkbox");
          var hasChecked = $(expression1).length == $(expression2).length;
          $("#chkAll").attr("checked", hasChecked);
      });

      //获取表格中选中的值
      function vali() {
          var selectedCodes = new Array();
          var checkedItems = $("#dg1 > tbody > tr > td > input:checkbox:checked[@name$='chkItem']");
          $.each(checkedItems, function () {
              selectedCodes.push($(this).attr("code"));
          });
          if (0 == selectedCodes.length) {
              alert("没有选中任何项..");
              return false;
          }
          if (confirm("确认删除选择的项吗?")) {

              $("#hids").val(selectedCodes.join(","));
              return true;
          } else {
              return false;
          }
      }
    </script>
    <asp:HiddenField ID="hids" runat="server" />
</form>
</center>
</body>
</html>
