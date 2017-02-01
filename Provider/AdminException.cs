using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buyalot.Provider
{
    public class AdminException: Exception 
    {
        public AdminException(string errMessage)
            : base(errMessage) { }
    }
}