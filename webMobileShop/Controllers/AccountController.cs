using System.Web.Mvc;
using webMobileShop.Dtos;
using webMobileShop.Interactors;

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
        public ActionResult Index()
        {
            return View();
        }
        // POST: Account/Create
        [HttpPost]
        public ActionResult Signup(UserDto collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    userinteractor.RegisterUser(collection);
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index","Home", null);
            }
            catch
            {
                return View();
            }
        }

    }
}