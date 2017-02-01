using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Buyalot.Models
{
    public class OrderDetailsModel
    {
        public int orderDetailsID { get; set; }
        public int orderID { get; set; }
        public int productID { get; set; }
        public int quantityOrdered { get; set; }
        public decimal priceEach { get; set; }

    }
}