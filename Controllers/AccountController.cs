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

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(CustomerModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return View(model);
        }
        
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(CustomerModel model)
        {

            try
            {
                if (!ModelState.IsValid)
                    return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Error details");

                if (ModelState.IsValid)
                {
                    var user = new CustomerModel
                    {
                        firstName = model.firstName,
                        lastName = model.lastName,
                        password = model.password,
                        confirmPassword = model.confirmPassword,
                        phone = model.phone,
                        email = model.email,
                        state = model.state
                    };
                    Context.CustomerModelSet.Add(user);
                    Context.SaveChanges();
                    //if (user.ToString() != null)
                    //{
                    //    return RedirectToAction("Index", "Home");
                    //}

                    FormsAuthentication.SetAuthCookie(model.email, false);

                    Context.SaveChangesAsync();
                }

            }
            catch (RegisterException e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, e.Message);
            }
           
            // If we got this far, something failed, redisplay form
            return View(model);
        }
    }
}