using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace Backend.WebControls
{
    public class OrderStatusDropDownList:DropDownList
    {
        public OrderStatusDropDownList()
        {
            Items.Add(new ListItem("ȫ��", "0"));
            Items.Add(new ListItem("���ύ", "1"));
            Items.Add(new ListItem("�����", "2"));
            Items.Add(new ListItem("�ѿۻ�", "3"));
            Items.Add(new ListItem("������", "4"));
            Items.Add(new ListItem("�����", "5"));
            Items.Add(new ListItem("��ȡ��", "6"));
        }
    }
}
