using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace Backend.WebControls
{
    public class OrderStatusDropDownList:DropDownList
    {
        public OrderStatusDropDownList()
        {
            Items.Add(new ListItem("全部", "0"));
            Items.Add(new ListItem("待提交", "1"));
            Items.Add(new ListItem("待审核", "2"));
            Items.Add(new ListItem("已扣货", "3"));
            Items.Add(new ListItem("待检验", "4"));
            Items.Add(new ListItem("已完毕", "5"));
            Items.Add(new ListItem("已取消", "6"));
        }
    }
}
