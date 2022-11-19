using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using webMobileShop.Dtos;
using webMobileShop.Interactors;
using webMobileShop.CommonUtilities;

namespace webMobileShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserInteractor userinteractor;

        public AccountController(UserInteractor userinteractor)
        {
            this.userinteractor = userinteractor;
        }

        // GET: Account
        public ActionResult Signup()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        
        public ActionResult Login(LoginDto model, string returnUrl)
        {
            LoginResponseDto user = userinteractor.IsValidUser(model);
            if (user == null)
                ModelState.AddModelError("", "Invalid login attempt.");
            else if (user.IsActive == (int)EnumStatus.Pending)
                ModelState.AddModelError("", "Account status is pending!");
            else
            {
                FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
                FormsAuthentication.SetAuthCookie(Convert.ToString(user.Id), model.RememberMe);
                var authTicket = new FormsAuthenticationTicket(1, user.FullName , DateTime.Now, DateTime.Now.AddMinutes(20), false, user.RoleName);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
       
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        // POST: Account/Create
        [HttpPost]
        public ActionResult Signup(UserDto collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (userinteractor.CheckIfEmailExists(collection.Email))
                    {
                        ModelState.AddModelError("", "Email already exists!");
                        return View();
                    }
                    else
                    {
                        userinteractor.RegisterUser(collection, Request.Url);
                        return View("Activation");
                    }
                }
                return RedirectToAction("Index", "Home", null);
            }
            catch
            {
                return View();
            }
        }
         
        [HttpGet]
        public ActionResult Activation() 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (userinteractor.CheckIfValidActivationCode(RouteData.Values["id"].ToString()))
                    {
                        userinteractor.VerifyAccount(RouteData.Values["id"].ToString());

                        return RedirectToAction("Login");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Activation code.!");
                        return View("Login");
                    }
                }
                return RedirectToAction("Index", "Home", null);
            }
            catch
            {
                return View();
            }
        }
        [AllowAnonymous]
        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}