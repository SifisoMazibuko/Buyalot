using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buyalot.Provider
{
    public class RegisterException:  Exception
    {
        public RegisterException(string errMessage)
            :base (errMessage)
        {
        }
    }
}