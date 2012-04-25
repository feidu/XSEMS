using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using Backend.Models;
using Backend.BAL;

namespace Backend.WebControls
{
    public class CostsTypeDropDownList:DropDownList
    {
        public CostsTypeDropDownList()
        {
            List<CostType> result = CostTypeOperation.GetCostType();
            foreach (CostType ct in result)
            {
                Items.Add(new ListItem(ct.Name, ct.Id.ToString()));
            }
        }
    }
}
