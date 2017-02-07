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

        //[HiddenInput(DisplayValue = false)]
       //public string ImageMimeType { get; set; }
        //DataContext db = new DataContext();
        //public string ImageSource
        //{

        //    get
        //    {
        //        string mimeType = "image/png"; /* Get mime type somehow (e.g. "image/png") */
        //        string base64 = Convert.ToBase64String(productImage);
        //        return string.Format("data:{0};base64,{1}", mimeType, base64);
        //    }

        //    set
        //    {
        //        ImageSource = Convert.ToBase64String(productImage);
        //    }
        //}
        public virtual ICollection<OrderDetailsModel> OrderDetails { get; set; }


    }
}