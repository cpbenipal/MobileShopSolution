using System.Web.Mvc;
using webMobileShop.CommonUtilities;
using webMobileShop.Contracts;
using webMobileShop.Interactors;
using webMobileShop.Models;

namespace webMobileShop.Controllers
{
    [AuthorizeRoleAttribute(EnumRole.Admin)]
    public class AdminController : Controller
    {
        // GET: Admin
        private readonly UserInteractor userinteractor;
        private readonly IHashManager _hashManager;
        public AdminController(UserInteractor userinteractor, IHashManager hashManager)
        {
            this.userinteractor = userinteractor;
            _hashManager = hashManager;
        }     
        public ActionResult Index()
        {
            var response = userinteractor.GetAllUsers();
            return View(response);
        }         
    }
}
