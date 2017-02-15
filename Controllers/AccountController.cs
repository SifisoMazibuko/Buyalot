using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Buyalot.Models;
using Buyalot.DbConnection;
using System.Net;
using Buyalot.Provider;
using System.Web.Security;
using AftaScool.BL.Util;
using System.Data.Entity;

namespace Buyalot.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private DataContext Context { get; set; }
        private bool _DisposeContext = false;
        
       
        public AccountController()
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
        

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(CustomerModel model)
        {

            var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new { x.Key, x.Value.Errors })
                     .ToArray();
                        
            try
            {
                var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.email), }, 
                    DefaultAuthenticationTypes.ApplicationCookie, ClaimTypes.Name, ClaimTypes.Role);

                identity.AddClaim(new Claim(ClaimTypes.Role, "customer"));
                identity.AddClaim(new Claim(ClaimTypes.GivenName, "Person"));
                identity.AddClaim(new Claim(ClaimTypes.Sid, model.customerID.ToString()));

                if (model.isValid(model.email, Cipher.Encrypt(model.password)))
                {
                    FormsAuthentication.SetAuthCookie(model.email, false);
                    Session["cusName"] = model.email;
                    return RedirectToAction("Index", "Home");
                }
                else
                    return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Incorrect details");

            }
            catch (LoginException e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, e.Message); ;
            } 
           
        }

        //GET: /Account/Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(CustomerModel model, AddressModel addressModel)
        {

            
            var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new { x.Key, x.Value.Errors })
                     .ToArray();

            var user1 = new CustomerModel();
            var values = new AddressModel();
            try
            {
                if (!ModelState.IsValid)
                    return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Internal Error details");

                if (ModelState.IsValid)
                {
                    var user = new CustomerModel
                    {
                        firstName = model.firstName,
                        lastName = model.lastName,
                        phone = model.phone,
                        email = model.email,
                        password = Cipher.Encrypt(model.password),
                        confirmPassword = Cipher.Encrypt(model.confirmPassword),
                        state = model.state
                    };
                    
                    var addr = new AddressModel
                    {
                        address = addressModel.address,
                        city = addressModel.city,
                        postalCode = addressModel.postalCode
                    };

                    user1 = user;
                    values = addr;
                    FormsAuthentication.SetAuthCookie(model.email, false);

                    Context.CustomerModelSet.Add(user1);
                    Context.AddressModelSet.Add(values);
                    Context.SaveChanges();

                    return RedirectToAction("Index","Home");
                    
                }

            }
            catch (RegisterException e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, e.Message);
            }
            ModelState.Clear();
            return View(user1);
        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult AdminLogin(AdminModel model)
        {

            var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new { x.Key, x.Value.Errors })
                     .ToArray();

            try
            {
                if (model.isValid(model.adminName, model.email, model.password))
                {
                    FormsAuthentication.SetAuthCookie(model.email, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                    return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Incorrect details");

            }
            catch (LoginException e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, e.Message); ;
            }

        }

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        //GET: /Product/Products
        [HttpGet]
        public ActionResult ViewProducts()
        {
            var product = (from p in Context.ProductModelSet
                           select p).ToList();
            return View(product);
        }

        // GET: /StoreManager/Create
        public ActionResult AddProduct()
        {

            ProductModel prod = new ProductModel();
            return View(prod);
        }


        //POST /AddProduct
        [HttpPost]
        public ActionResult AddProduct(ProductModel product, HttpPostedFileBase upload)
        {

            var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new { x.Key, x.Value.Errors })
                     .ToArray();
            
                if (!ModelState.IsValid)
                    return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Internal Error details");

                if (ModelState.IsValid && upload != null)
                {
                    //product.productImage = new byte[upload.ContentLength];
                    //upload.InputStream.Read(product.productImage, 0, upload.ContentLength);
                    //var base64 = Convert.ToBase64String(product.productImage);
                    //var prodImage = string.Format("data:image/png;base64,{0}", base64);

                    var p = new ProductModel
                    {
                        productName = product.productName,
                        productDescription = product.productDescription,
                        price = product.price,
                        vendor = product.vendor,
                        quantityInStock = product.quantityInStock,
                      //  ImageSource = product.ImageSource
                    };


                    //Context.ProductModelSet.Add(product);
                    Context.ProductModelSet.Add(p);
                    Context.SaveChanges();
                    return RedirectToAction("Index", "Home");

                }
            return View(product);
        }



        //[HttpPost]
        //public ActionResult GetProfile(int? id)
        //{
        //    if (id == null)
        //        id = 0;
        //    try
        //    {
        //        var p = (from a in Context.CustomerModelSet.Where(a => a.customerID == id).Select(a => new CustomerModel())
        //                 select a).Single();
        //        p.customerID = p.customerID;
        //        p.firstName = p.firstName;
        //        p.lastName = p.lastName;
        //        p.phone = p.phone;
        //        p.email = p.email;
        //        p.password = p.password;
        //        p.state = p.state;
                
                
        //        return View(p);
        //    }
        //    catch (Exception e)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, e.Message);
        //    }
        //}

        [HttpGet]
        public ActionResult GetProfile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CustomerModel cus = Context.CustomerModelSet.Find(id);
            if (cus == null)
            {
                return HttpNotFound();
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetProfile([Bind(Include = "customerID,firstName,lastName,phone,email,password,confirmPassword,state")] CustomerModel cus)
        {
            if (ModelState.IsValid)
            {
                Context.Entry(cus).State = EntityState.Modified;
                Context.SaveChanges();
               // ViewBag.result = "Category " + productCategory.categoryName + " Updated Succesfully!";
                return View(cus);
            }

            return RedirectToAction("Index");
        }

    }
}