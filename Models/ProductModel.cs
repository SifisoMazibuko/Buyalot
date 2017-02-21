using Buyalot.DbConnection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Buyalot.Models
{
    [Table("Product")]
    public class ProductModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productID { get; set; }

        
        //public int prodCategoryID { get; set; }
        //[ForeignKey("prodCategoryID")]
        //public virtual ProductCategoryModel prodCategory { get; set; }

        [Required]
        [Display(Name = "Product Name:")]
        public string productName { get; set; }

        [Required]
        [Display(Name = "Product Description:")]
        public string productDescription { get; set; }
        
        [Required]
        [Display(Name = "Vendor:")]
        public string vendor { get; set; }

        [Required]
        [Display(Name = "Product Price: ")]        
        public decimal price { get; set; }

        [Required]
        [Display(Name = "Quantity In Stock:")]
        public int quantityInStock { get; set; }
        
        public byte[] productImage { get; set; }

        public virtual ICollection<OrderDetailsModel> OrderDetails { get; set; }
        public virtual ProductCategoryModel ProductCategory { get; set; }
        public List<ProductCategoryModel> AllocatedCategory { get; set; }

    }
}