using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace Backend.WebControls
{
    public class WrongOrderStatusDropDownList:DropDownList
    {
        public WrongOrderStatusDropDownList()
        {
            Items.Add(new ListItem("�ѿ�����ѯ", "1"));
            Items.Add(new ListItem("�ɹ�����", "2"));
            Items.Add(new ListItem("�յ�ȷ�Ϻ�", "3"));
            Items.Add(new ListItem("�Ѵ���ȷ�Ϻ���Ͷ��֤���顢Ͷ�ļ�¼", "4"));
            Items.Add(new ListItem("�յ����⺯", "5"));
            Items.Add(new ListItem("�ѵݽ���������", "6"));
            Items.Add(new ListItem("�յ����", "7"));
            Items.Add(new ListItem("д�����϶��������⳥���ͻ�", "8"));
            Items.Add(new ListItem("�������", "9"));
            Items.Add(new ListItem("����", "10"));
        }
    }
}
