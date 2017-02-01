using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Buyalot.Models
{
    public class OrderModel
    {
       
        public int orderID { get; set; }
       
        public int customerID { get; set; }
        public DateTime orderDate { get; set; }
        public string shippingDate { get; set; }
        public DateTime shippingAddress { get; set; }
        public string status { get; set; }
        public decimal totalPrice { get; set; }
        
    }
}