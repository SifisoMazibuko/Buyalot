using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Buyalot.Models
{
    [Table("OrderDetails")]
    public class OrderDetailsModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int orderDetailsID { get; set; }

        public int orderID { get; set; }

        [ForeignKey("orderID")]
        public virtual OrderModel order { get; set; }

        public int productID { get; set; }

        [ForeignKey("productID")]
        public virtual ProductModel product { get; set;} 
        public int quantityOrdered { get; set; }
        public decimal priceEach { get; set; }

    }
}