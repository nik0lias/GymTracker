using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using AutoMapper;
using GymTracker.Core.DTO;
using GymTracker.Web.Attributes;
using GymTracker.Web.Factories.Interfaces.Base;
using GymTracker.Web.Models;
using GymTracker.Web.Models.Signup;
using GymTracker.Web.Models.User;

namespace GymTracker.Web.Controllers
{
    [CustomCookieAuthorize]
    public class UserController : Controller
    {
        private readonly IWebApiFactory<UserDto> _accountApi;

        public UserController(IWebApiFactory<UserDto> client)
        {
            _accountApi = client;
        }

        public string GetToken()
        {
            //todo: mock this properly so we dont have to check for request
            if (Request == null) return string.Empty;

            return Request.Cookies["bearerToken"] != null ? Request.Cookies["bearerToken"].Value : null;
        }

        public ActionResult Index(int? id)
        {
            if (!id.HasValue) return new EmptyResult();

            return View();
        }

        public async Task<ActionResult> GetAll()
        {
            try
            {
                var model = await _accountApi.GetAll();
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (HttpResponseException ex)
            {
                return new HttpStatusCodeResult(ex.Response.StatusCode);
            }
        }

        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var model = await _accountApi.GetOne(id);

                Mapper.CreateMap<UserDto, UserDetailsModel>();
                var objMapped = Mapper.Map<UserDto, UserDetailsModel>(model);

                return View("Details", objMapped);
            }
            catch (HttpResponseException ex)
            {
                return new HttpStatusCodeResult(ex.Response.StatusCode);
            }
        }
    }
}
