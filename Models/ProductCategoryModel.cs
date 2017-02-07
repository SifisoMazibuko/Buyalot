using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Buyalot.Models
{
    [Table("ProductCategory")]
    public class ProductCategoryModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int prodCategoryID { get; set; }

        public int adminID { get; set; }

        [ForeignKey("adminID")]
        public virtual AdminModel admin { get; set; }
        public string categoryName { get; set; }

        

        public virtual ICollection<ProductModel> ProdCategorys { get; set; }
    }
}