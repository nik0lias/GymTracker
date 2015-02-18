using System.Web.Mvc;
using GymTracker.Core.DTO;
using GymTracker.Web.Factories;
using GymTracker.Web.Models;

namespace GymTracker.Web.Controllers
{
    public class UserController : Controller
    {
        public WebApiFactory<LoggedInUserDTO> _loginDataFactory { get; set; }

        public UserController()
        {
            _loginDataFactory = new WebApiFactory<LoggedInUserDTO>("http://localhost:54435/api/", "Account", WebApiRestService.ContentType.Xml);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            var v = _loginDataFactory.CreateOne("Login");

            return View("Login");
        }

        public ActionResult Register()
        {
            return View("Index");
        }
    }
}