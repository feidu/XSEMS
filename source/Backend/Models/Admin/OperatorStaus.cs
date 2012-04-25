using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models.Admin
{
    public enum OperatorStaus
    {
        // common
        SUCCESS,
        // create user
        OPERATOR_USERNAME_EXISTED,
        // login 
        OPERATOR_USERNAME_INCORROECT,
        OPERATOR_PASSWORD_INCORROECT
    }
}
