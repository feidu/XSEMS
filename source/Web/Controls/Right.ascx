<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Right.ascx.cs" Inherits="Controls_Right" %>
<div class="right_bar1">            
            <div id="bar_r">
              <div class="top_b" style="margin-top:13px;"> <a target="_parent" href="/News/Default.aspx?cat=3"> <span style="cursor: hand; color: White;">相关链接</span></a></div>
              <div class="content_box2">
                
              </div>
            </div>
            <div class="margin_t" id="contactus2">
              <div class="top_b"> 联系我们</div>
              <div class="content_box2">
			  服务热线：<%=phoneNumber %><br />
                QQ: <br />               
                  <%=address %> <br />
                邮编：<%=postalcode %><br />
                电话：<%=phoneNumber %><br />
                传真：<%=faxNumber %>
              </div>
            </div>
          </div>