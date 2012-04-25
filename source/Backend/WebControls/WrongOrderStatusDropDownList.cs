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
            Items.Add(new ListItem("已开档查询", "1"));
            Items.Add(new ListItem("成功派送", "2"));
            Items.Add(new ListItem("收到确认函", "3"));
            Items.Add(new ListItem("已传真确认函、投寄证明书、投寄记录", "4"));
            Items.Add(new ListItem("收到索赔函", "5"));
            Items.Add(new ListItem("已递交索赔资料", "6"));
            Items.Add(new ListItem("收到赔款", "7"));
            Items.Add(new ListItem("写责任认定交财务赔偿给客户", "8"));
            Items.Add(new ListItem("处理完毕", "9"));
            Items.Add(new ListItem("其它", "10"));
        }
    }
}
