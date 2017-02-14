using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Buyalot.DbConnection;
using Buyalot.Models;

namespace Buyalot.Controllers
{
    public class ShoppingCartController : Controller
    {
        private DataContext Context { get; set; }
        private bool _DisposeContext = false;


        public ShoppingCartController()
        {
            Context = new DataContext();
            _DisposeContext = true;
        }


        protected override void Dispose(bool disposing)
        {
            if (_DisposeContext)
                Context.Dispose();

            base.Dispose(disposing);

        }

        // GET: ShoppingCart
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult AddToCart()
        {
            Item item = new Item();
            return View(item);
        }

        [HttpPost]
        public ActionResult AddToCart(int id)
        {
            var db = new DataContext();

            if(Session["Cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item(db.ProductModelSet.Find(id), 1));

                Session["Cart"] = cart;
            }
            else
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item(db.ProductModelSet.Find(id), 1));

                Session["Cart"] = cart;
            }

            return View("");
        }
    }
}