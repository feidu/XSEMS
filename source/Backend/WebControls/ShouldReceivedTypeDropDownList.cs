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
            Items.Add(new ListItem("�ڳ�Ӧ��", "1"));
            Items.Add(new ListItem("�������ۿ�", "2"));
            Items.Add(new ListItem("��ʧ���⳥", "3"));
            Items.Add(new ListItem("����Ӧ��", "4"));
        }
    }
}
