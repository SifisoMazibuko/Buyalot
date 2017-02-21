using Buyalot.DbConnection;
using Buyalot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Buyalot.Controllers
{
    public class ProductsWishlistController : Controller
    {
         private DataContext Context { get; set; }
        private bool _DisposeContext = false;


        public ProductsWishlistController()
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
        // GET: ProductsWishlist
        public ActionResult Index()
        {
            ViewBag.ProductList = Context.ProductModelSet.ToList();
            return View();
        }
        private int itemExist(int id)
        {
            List<Item> cart = (List<Item>)Session["Cart"];
            int counter = cart.Count;
            for (int i = 0; i < counter; i++)
            {
                if (cart[i].Prdcts.productID == id)
                {
                    return i;
                }
                ViewData["CartWishCount"] = cart.Count;
            }
            return -1;

        }
        public ActionResult AddToWishlist(int id)
        {            
            if (Session["Cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item(Context.ProductModelSet.Find(id), 1));

                Session["Cart"] = cart;
                Session["CartCounter"] = cart.Count;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["Cart"];

                int index = itemExist(id);

                if (index == -1)
                {
                    cart.Add(new Item(Context.ProductModelSet.Find(id), 1));
                    Session["CartCounter"] = cart.Count;
                }
                else
                {
                    cart[index].Quantity1++;

                    if (Session["cartcounter"] == null)
                    {
                        Session["CartCounter"] = cart.Count;
                    }
                    else
                    {

                        var session = Session["cartcounter"];
                        Session["cartcounter"] = Convert.ToInt32(session) + cart[index].Quantity1;
                    }

                }

                Session["Cart"] = cart;
                ViewData["CartWishCount"] = cart.Count;
            }

            return View("AddToWishlist");
        }
        public ActionResult DeleteCart(int id)
        {
            List<Item> cart = (List<Item>)Session["Cart"];
            int index = itemExist(id);


            cart.RemoveAt(index);

            Session["Cart"] = cart;

            return View("AddToWishlist");
        }
        public ActionResult UpdateQuantity1(FormCollection fc)
        {
            string[] quantities = fc.GetValues("txtQuantity1");
            List<Item> cart = (List<Item>)Session["Cart"];
            int counter = cart.Count;

            for (int i = 0; i < counter; i++)
            {
                cart[i].Quantity = Convert.ToInt32(quantities[i]);
                Session["Cart"] = cart;
                ViewData["CartCount"] = cart.Count;
            }



            return View("AddToWishlist");
        }

        public ActionResult UpdateCartCounter()
        {

            List<Item> cart = (List<Item>)Session["Cart"];
            int counter = cart.Count;

            for (int i = 0; i < counter; i++)
                cart[i].Quantity1++;
            Session["Cart"] = cart;
            ViewData["CartWishCount"] = cart.Count;

            return View("AddToWishlist");
        }
    }
}