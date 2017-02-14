using Buyalot.DbConnection;
using Buyalot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Buyalot.Controllers
{
    public class ProductController : Controller
    {
        private DataContext Context { get; set; }
        private bool _DisposeContext = false;


        public ProductController()
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
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        //GET: /Product/Products
        public ActionResult ViewProducts()
        {
            var product = (from p in Context.ProductModelSet
                           select p).ToList();
            return View(product);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {

            ProductModel prod = new ProductModel();
            return View(prod);
        }


        [HttpPost]
        public ActionResult AddProduct(ProductModel model, HttpPostedFileBase productImage)
        {

            var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new { x.Key, x.Value.Errors })
                     .ToArray();


            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Internal Error details");

            if (ModelState.IsValid)
                {
                    var product = new ProductModel();
                    product.productID = model.productID;
                    product.productName = model.productName;
                    product.productDescription = model.productDescription;
                    product.vendor = model.vendor;
                    product.price = model.price;
                
                  if (productImage != null)
                    {
                    //   product.ImageMimeType = productImage.ContentType;
                        product.productImage = new byte[productImage.ContentLength];
                        productImage.InputStream.Read(product.productImage, 0, productImage.ContentLength);
                    }


                    Context.ProductModelSet.Add(product);
                    Context.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }
               Context.SaveChanges();

            return View(model);
        }

        [HttpGet]
        public ActionResult CategoryList(ProductCategoryModel prodCatId)
        {
            var list =  (from c in Context.ProductCategoryModelSet
                        select c).ToList();
            return View(list);
        }

        string productCartId { get; set; }

        public static ProductController GetCart(DataContext context)
        {
            var cart = new ProductController();
            cart.productCartId = cart.productCartId;
                return cart;
        }

        // GET:  /Cart/CartSummary/
        public ActionResult CartSummary()
       {
            var cart =  ProductController.GetCart(this.Context);
            ViewBag["CartCount"] = cart.productCartId;
            return PartialView("CartSummary");
        }
    }
}