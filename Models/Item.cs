using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buyalot.Models
{
    public class Item
    {
        private ProductModel prdcts = new ProductModel();

       
        private int quantity;

       

        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }

        public ProductModel Prdcts
        {
            get
            {
                return prdcts;
            }

            set
            {
                prdcts = value;
            }
        }

        public Item() { }

        public Item(ProductModel product, int quantity)
        {
            this.Prdcts = product;
            this.Quantity = quantity;
        }
    }
}