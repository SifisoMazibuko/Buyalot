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
    public class CheckoutController : Controller
    {
        private DataContext Context { get; set; }
        private bool _DisposeContext = false;


        public CheckoutController()
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
        // GET: Checkout
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Payment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Payment(BillingModel values, PaymentModel values1)
        {
            var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new { x.Key, x.Value.Errors })
                     .ToArray();
            try
            {
                if (ModelState.IsValid)
                {
                    var bill = new BillingModel
                    {
                        customerID = values.customerID,
                        cardNumber = values.cardNumber,
                        cardType = values.cardType,
                        expDate = DateTime.Today,
                        cardHolderName = values.cardHolderName

                    };

                    var pay = new PaymentModel
                    {
                        //orderID = values1.orderID,
                        //paymentID = values1.paymentID,
                        //customerID = values1.customerID,
                        //paymentType = values1.paymentType,
                        paymentDate = DateTime.Now
                    };

                    var order = new OrderModel {
                        orderDate = DateTime.Now
                    };

                    Context.BillingModelSet.Add(values);
                    Context.PaymentModelSet.Add(values1);
                    Context.OrderModelSet.Add(order);
                    Context.SaveChanges();

                    return RedirectToAction("Index");
                    //return RedirectToAction("CheckoutComplete", new { id = order.orderID });
                }
                
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, e.Message);
            }
            Context.SaveChanges();
            return View(values);
        }

        public ActionResult CheckoutComplete(int id)
        {
            bool isValid = Context.OrderModelSet.Any(
                o => o.orderID == id 
                );

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
    }
}