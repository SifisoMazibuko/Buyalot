using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Buyalot.Models
{
    [Table("Payment")]
    public class PaymentModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int paymentID { get; set; }

        public int customerID { get; set; }
        [ForeignKey("customerID")]
        public virtual CustomerModel customer { get; set; }

        public int orderID { get; set; }
        [ForeignKey("orderID")]
        public virtual OrderModel order { get; set; }

        public DateTime paymentDate { get; set; }
        public string paymentType { get; set; }
        public decimal totalPrice { get; set; }

        
        
    }
}