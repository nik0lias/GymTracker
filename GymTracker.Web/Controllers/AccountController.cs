using System.Threading.Tasks;
using System.Web.Mvc;
using GymTracker.Core.DTO;
using GymTracker.Web.Factories.Interfaces.Base;
using GymTracker.Web.Models.Signup;

namespace GymTracker.Web.Controllers
{
    public class AccountController : Controller
    {
        public IWebApiFactory<UserDto> _loginDataFactory { get; set; }

        public AccountController(IWebApiFactory<UserDto> client)
        {
            _loginDataFactory = client;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Login()
        {
            return View("Login");
        }

        public async Task<ActionResult> Register(RegisterModel model)
        {
            return View("Index");
        }
    }
}