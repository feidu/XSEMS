using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace Backend.WebControls
{
    public class ShouldReceivedTypeDropDownList:DropDownList
    {
        public ShouldReceivedTypeDropDownList()
        {
            Items.Add(new ListItem("期初应收", "1"));
            Items.Add(new ListItem("返利及折扣", "2"));
            Items.Add(new ListItem("损失与赔偿", "3"));
            Items.Add(new ListItem("其它应收", "4"));
        }
    }
}
