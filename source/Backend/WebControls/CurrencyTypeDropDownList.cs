using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace Backend.WebControls
{
    public class CurrencyTypeDropDownList : DropDownList
    {
        public CurrencyTypeDropDownList()
        {
            Items.Add(new ListItem("人民币", "1"));
            Items.Add(new ListItem("美元", "2"));
        }
    }
}
