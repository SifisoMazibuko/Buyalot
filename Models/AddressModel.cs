using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Buyalot.Models
{
    public class AddressModel
    {
        public int addressID { get; set; }
        public int customerID { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string postalCode { get; set; }

    }
}