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
            Items.Add(new ListItem("��������", "1"));
            Items.Add(new ListItem("Ѻ��", "1"));
        }
    }
}
