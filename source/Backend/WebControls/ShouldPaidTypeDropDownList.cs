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
            Items.Add(new ListItem("�ڳ�Ӧ��", "1"));
            Items.Add(new ListItem("ӪҵӦ��", "2"));
            Items.Add(new ListItem("�˼�Ӧ��", "3"));
            Items.Add(new ListItem("����Ӧ��", "4"));
        }
    }
}
