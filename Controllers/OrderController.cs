using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Buyalot.Models;
using Buyalot.DbConnection;

namespace Buyalot.Controllers
{
    public class OrderController : Controller
    {
        DataContext db = new DataContext();
        // GET: Order
        public ActionResult Index()
        {
            CheckOuts();
            //NB this userID session is gonna be taken after the user has logged on
            int uid = Convert.ToInt32(Session["userID"]);
            //if(Session["userID"] != null) { 
            //var getOrder = db.OrderModelSet.Select(x => x).Where(x => x.customerID == uid).ToList();
            //var query = db.OrderModelSet.Where(x => x.orderID == x.customerID).ToList();
            var query = (from o in db.OrderModelSet
                         where o.customerID == uid
                         join od in db.OrderDetailsModelSet
                         on o.orderID equals od.orderID
                         join p in db.ProductModelSet
                         on od.productID equals p.productID
                        // where o.customerID == uid
                         select new OrderList
                         {
                             customerID = o.customerID,
                             orderDate = o.orderDate,
                             shippingDate = o.shippingDate,
                             shippingAddress = o.shippingAddress,
                             status = o.status,
                             quantityOrdered = od.quantityOrdered,
                             priceEach = od.priceEach,
                             productName = p.productName
                         }).ToList();

                ViewBag.OrderList = query;
           // }
            //return RedirectToAction("Login", "Account");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckOuts()
        {
            /*
             * Check if the user has logged on and redirect the user to login if not so
             * Send the user to registration page if not registered
             * Proceed to checkout if all is well
             */
            int uid = Convert.ToInt32(Session["userID"]);

            //Gettting the cuurrent shopping cart
            var currentShoppingCart = Session["Cart"];
            decimal totalprice = 0;

            if (Session["userID"] != null)
            {



                OrderModel newOrder = new OrderModel();
                newOrder.customerID = uid;
                newOrder.orderDate = DateTime.Now;

                DateTime shippingDate = AddWorkdays(DateTime.Now, 5);
                newOrder.shippingDate = shippingDate;


                //get the customer address
                var getAddress = (from a in db.AddressModelSet
                                  where a.customerID == uid
                                  select a).ToList();


                foreach (var address in getAddress)
                {
                    string addr = address.address;
                    string city = address.city;
                    string postCode = address.postalCode;

                    newOrder.shippingAddress = addr + ", " + city + ", " + postCode;
                }
                //order.shippingAddress = 
                newOrder.status = "In Process";
                //get total price
                foreach (var item in (List<Item>)currentShoppingCart)
                {
                    totalprice = totalprice + (item.Prdcts.price + item.Quantity);
                    newOrder.totalPrice = totalprice;
                }
                db.OrderModelSet.Add(newOrder);
                db.SaveChanges();




                //get the orderId of the current user
                var getOrderID = (from o in db.OrderModelSet
                                  where o.customerID == uid
                                  select o).ToList();
                int orderID = 0;
                foreach (var o in getOrderID)
                {

                    orderID = o.orderID;
                }


                // var listOrderDetails = new List<OrderDetailsModel>();

                foreach (var item in (List<Item>)currentShoppingCart)
                {
                    var orderDetails = new OrderDetailsModel();
                    orderDetails.orderID = orderID;
                    orderDetails.productID = item.Prdcts.productID;
                    orderDetails.quantityOrdered = item.Quantity;
                    orderDetails.priceEach = item.Prdcts.price;

                    db.OrderDetailsModelSet.Add(orderDetails);
                    db.SaveChanges();
                }
               


            }
            
            
               //return RedirectToAction("Login", "Account" );
            

            //var getOrder = db.OrderModelSet.Select(x => x).Where(x => x.customerID == uid).ToList();
            return View("Index");


        }

        public static DateTime AddWorkdays(DateTime originalDate, int workDays)
        {
            DateTime tmpDate = originalDate;
            while (workDays > 0)
            {
                tmpDate = tmpDate.AddDays(1);
                if (tmpDate.DayOfWeek < DayOfWeek.Saturday ||
                    tmpDate.DayOfWeek > DayOfWeek.Sunday)
                    workDays--;
            }
            return tmpDate;
        }

    }
}