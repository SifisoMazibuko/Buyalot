using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Buyalot.Models
{
    public class ProductCategoryModel
    {
        public int prodCategoryID { get; set; }
        public int adminID { get; set; }
        public string categoryName { get; set; }
    }
}