using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Buyalot.Models
{
    public class ProductModel
    {
        public int productID { get; set; }
        public int prodCategoryID { get; set; }

        [Required(ErrorMessage = "A Product Name is required")]
        [Display(Name = "Product Name:")]
        public string productName { get; set; }

        [Display(Name = "Vendor:")]
        [Required(ErrorMessage = "A Vendor Name is required")]
        public string vendor { get; set; }

        [Display(Name = "Product Price: ")]
        [Required(ErrorMessage = "A Product Price is required")]
        public decimal price { get; set; }

        [Display(Name = "Quantity In Stock:")]
        [Required(ErrorMessage = "A Quantity In Stock value is required")]
        public int quantityInStock { get; set; }

        [Display(Name = "Product Image")]
        [Required(ErrorMessage = "A Product Image file is required")]
        public byte[] productImage { get; set; }
    }
}