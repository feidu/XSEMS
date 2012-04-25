using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using Backend.Models;
using Backend.BAL;

namespace Backend.WebControls
{
    public class PaymentMethodDropDownList : DropDownList
    {
        public PaymentMethodDropDownList()
        {
            List<PaymentMethod> result = PaymentMethodOperation.GetPaymentMethod();
            foreach (PaymentMethod pm in result)
            {
                Items.Add(new ListItem(pm.Name, pm.Id.ToString()));
            }
        }
    }
}
