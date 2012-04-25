using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace Backend.WebControls
{
    public class ShouldPaidTypeDropDownList:DropDownList
    {
        public ShouldPaidTypeDropDownList()
        {
            Items.Add(new ListItem("期初应付", "1"));
            Items.Add(new ListItem("营业应付", "2"));
            Items.Add(new ListItem("退件应付", "3"));
            Items.Add(new ListItem("其它应付", "4"));
        }
    }
}
