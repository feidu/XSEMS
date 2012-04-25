using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace Backend.WebControls
{
    public class PaymentTypeDropDownList : DropDownList
    {
        public PaymentTypeDropDownList()
        {
            Items.Add(new ListItem("正常付款", "1"));
            Items.Add(new ListItem("押金", "1"));
        }
    }
}
