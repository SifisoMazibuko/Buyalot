using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Buyalot.Models
{
    [Table("Order")]
    public class OrderModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int orderID { get; set; }
        public int customerID { get; set; }

        [ForeignKey("customerID")]
        public virtual CustomerModel Customer { get; set; }

        public DateTime orderDate { get; set; }
        public DateTime shippingDate { get; set; }
        public string shippingAddress { get; set; }
        public string status { get; set; }
        public decimal totalPrice { get; set; }

       

        public virtual ICollection<OrderDetailsModel> OrderDetails { get; set; }
        //public virtual ICollection<PaymentModel> Payments { get; set; }
    }
}