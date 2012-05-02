<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Left.ascx.cs" Inherits="Controls_Left" %>
<div id="contactus_client">
  <div class="top_c">欢迎您，<span style="color:Maroon"><%=username %></span> ！</div>
    <div class="contact_content_client" style="float:left; height:350px;">      
       <ul style="margin:0px; padding:0px;">
         <li><a href="PostCosts.aspx"> 邮件费用查询</a></li>
         <li><a href="CreateOrder.aspx"> 在线录单</a></li>
         <li><a href="Default.aspx"> 我的订单</a></li>
         <li><a href="WrongOrderList.aspx"> 问题订单</a></li>         
         <li><a href="CreateClientOrder.aspx"> 添加发货地址</a></li>
         <li><a href="OrderUpload.aspx"> 地址批量上传</a></li>
         <li><a href="ClientOrderList.aspx"> 地址标签打印</a></li>
         <!--<li><a href="Complain.aspx"> 我要投诉</a></li>
         <li><a href="ComplaintList.aspx">我的投诉</a></li>-->
         <li><a href="PersonalInfo.aspx"> 我的资料</a></li>
         <li><a href="Recharge.aspx"> 充值明细</a></li>
         <li><a href="OrderCostList.aspx"> 消费明细</a></li>
         <li><a href="ChangePwd.aspx"> 修改密码</a></li>
         <li><a href="../Logout.aspx"> 安全退出</a></li>
       </ul>               
    </div>
</div>