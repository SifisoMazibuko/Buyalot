using Buyalot.DbConnection;
using Buyalot.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Buyalot.Controllers
{
    public class HomeController : Controller
    {

        private ICategoryRepository iCategoryRepository = new CategoryRepository();
        private DataContext Context { get; set; }
        private bool _DisposeContext = false;


        public HomeController()
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

        public ActionResult Index()
        {
            //ViewBag.ProductList = Context.ProductModelSet.ToList();
            return View();
        }

        //public ActionResult Index(string searchString)
        //{
        //    var db = new DataContext();

        //    var product = (from p in db.ProductModelSet
        //                   select p);


        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        product = product.Where(s => s.productName.StartsWith(searchString)
        //                               || s.productName.Contains(searchString)
        //                               || s.vendor.StartsWith(searchString)
        //                               || s.vendor.Contains(searchString));

        //    }
        //    return View(product);

        //}

        public ActionResult Category(int id)
        {
            var category = iCategoryRepository.find(id);
            ViewBag.category = category;
            ViewBag.products = category.ProdCategorys.ToList();

            return View("Category");
        }

    }
}