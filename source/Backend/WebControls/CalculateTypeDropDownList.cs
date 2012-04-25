using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using Backend.Models;
using Backend.BAL;

namespace Backend.WebControls
{
    public class CalculateTypeDropDownList : DropDownList
    {
        public CalculateTypeDropDownList()
        {
            List<CalculateType> result = CalculateTypeOperation.GetCalculateType();
            foreach (CalculateType ct in result)
            {
                Items.Add(new ListItem(ct.Name, ct.Id.ToString()));
            }
        }
    }
}
