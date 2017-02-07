using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Buyalot.Models
{
    [Table("Billing")]
    public class BillingModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int billingID { get; set; }
        public int customerID { get; set; }

        [ForeignKey("customerID")]
        public virtual CustomerModel Customer { get; set; }
        public string cardNumber { get; set; }
        public string cardType { get; set; }
        public DateTime expDate { get; set; }
        public string cardHolderName { get; set; }

       
    }
}