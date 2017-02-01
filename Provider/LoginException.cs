using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buyalot.Provider
{
    public class LoginException:  Exception
    {
        public LoginException(string errMessage)
            : base(errMessage)
        {
        }
    }
}