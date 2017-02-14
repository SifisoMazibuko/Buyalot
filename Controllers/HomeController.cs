using Buyalot.DbConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Buyalot.Controllers
{
    public class HomeController : Controller
    {
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
        // GET: Product
        public ActionResult Index()
        {
            var db = new DataContext();
            ViewBag.ProductList = db.ProductModelSet.ToList();
            return View();
        }

    }
}