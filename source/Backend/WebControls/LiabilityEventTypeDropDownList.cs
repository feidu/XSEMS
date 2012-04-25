using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace Backend.WebControls
{
    public class LiabilityEventTypeDropDownList : DropDownList
    {
        public LiabilityEventTypeDropDownList()
        {
            Items.Add(new ListItem("开单错误", "1"));
            Items.Add(new ListItem("损失与赔偿", "2"));
            Items.Add(new ListItem("退件", "3"));
            Items.Add(new ListItem("偏远地区附加费", "4"));
            Items.Add(new ListItem("其它", "5"));
        }
    }
}
