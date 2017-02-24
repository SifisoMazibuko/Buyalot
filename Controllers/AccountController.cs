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
using WebMatrix.WebData;
using System.Net.Mail;

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
                    var cust = (from c in Context.CustomerModelSet
                               where c.email == model.email// && c.firstName == model.firstName
                               select c).ToList();
      
                    foreach (var item in cust)
                    {
                        Session["userID"] = item.customerID;
                        Session["cusName"] = item.firstName;
                    }
                    FormsAuthentication.SetAuthCookie(model.email, false);
                                                    
                    //Session["cusName"] = model.email;

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

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult ForgotPassword(CustomerModel model)
        {        

            string tmpPass = Membership.GeneratePassword(10, 4);
            var getPass = (from p in Context.CustomerModelSet
                           where p.email == model.email
                           select p).ToList();

            string tempPassword = "";
            foreach(var p in getPass)
            {
                tempPassword = Cipher.Decrypt(p.password);
            }
            MailMessage message = new MailMessage();
            message.From = new System.Net.Mail.MailAddress("mazibujo19@gmail.com");
            message.To.Add(new System.Net.Mail.MailAddress(model.email));
            message.Subject = "Password Recovery";
            message.Body = string.Format("Hi ,<br /><br />Your password is: {0} .<br /><br />Thank You. <br /> Regards, <br /> Buyalot DevTeam", tempPassword);
            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential();
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;

            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Send(message);

            return View(model);
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

        //[HttpGet]
        //public ActionResult GetProfile()
        //{
        //    return View();
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

            return View(cus);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetProfile([Bind(Include = "customerID,firstName,lastName,phone,email,password,confirmPassword,state")] CustomerModel cus)
        {
            if (ModelState.IsValid)
            {
                Context.Entry(cus).State = EntityState.Modified;
                Context.SaveChanges();
                return View(cus);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Logout(int? Id)
        {
            var response = new HttpStatusCodeResult(HttpStatusCode.Created);
            FormsAuthentication.SignOut();
            CustomerModel cus = Context.CustomerModelSet.Find(Id);
            Session.Abandon();
            Response.Redirect("Index");
            return response;
        }
    }
}