using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using Backend.Models;
using Backend.BAL;

namespace Backend.WebControls
{
    public class CompanyDropDownList : DropDownList
    {
        public CompanyDropDownList()
        {
            List<Company> result= CompanyOperation.GetCompany();
            foreach (Company comp in result)
            {
                Items.Add(new ListItem(comp.Name, comp.Id.ToString()));
            }
        }
    }
}
