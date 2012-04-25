using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace Backend.WebControls
{
    public class GoodsTypeDropDownList:DropDownList
    {
        public GoodsTypeDropDownList()
        {
            Items.Add(new ListItem("°ü¹ü","1"));
            Items.Add(new ListItem("ÎÄ¼þ","2"));
        }
    }
}
