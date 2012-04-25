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
            Items.Add(new ListItem("��������", "1"));
            Items.Add(new ListItem("��ʧ���⳥", "2"));
            Items.Add(new ListItem("�˼�", "3"));
            Items.Add(new ListItem("ƫԶ�������ӷ�", "4"));
            Items.Add(new ListItem("����", "5"));
        }
    }
}
