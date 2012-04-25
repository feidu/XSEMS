using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using Backend.Models;
using Backend.BAL;

namespace Backend.WebControls
{
    public class CarrierDropDownList:DropDownList
    {
        public CarrierDropDownList()
        {
            List<Carrier> result = CarrierOperation.GetCarrier();
            foreach (Carrier carrier in result)
            {
                Items.Add(new ListItem(carrier.Name, carrier.Id.ToString()));
            }
        }
    }
}
