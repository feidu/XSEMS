using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using Backend.Models;
using Backend.BAL;

namespace Backend.WebControls
{
    public class UserPositionDropDownList:DropDownList
    {
        public UserPositionDropDownList()
        {
            List<Position> result = PositionOperation.GetPosition();
            foreach (Position position in result)
            {
                Items.Add(new ListItem(position.Name, position.Id.ToString()));
            }
        }
    }
}
