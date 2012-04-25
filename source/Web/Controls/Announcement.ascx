<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Announcement.ascx.cs" Inherits="Controls_Announcement" %>
<div style="padding-top:3px;" class="announcement">
  <marquee scrollamount="3" onMouseOver="this.stop()" onMouseOut="this.start()" direction="left">
  <%=announcement %>
  </marquee>
</div>