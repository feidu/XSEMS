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
            Items.Add(new ListItem("�����", "1"));
            Items.Add(new ListItem("��Ԫ", "2"));
        }
    }
}
