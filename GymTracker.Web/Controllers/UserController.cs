using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using AutoMapper;
using GymTracker.Core.DTO;
using GymTracker.Web.Attributes;
using GymTracker.Web.Factories;
using GymTracker.Web.Models;
using GymTracker.Web.Factories.Interfaces;

namespace GymTracker.Web.Controllers
{
    [CustomCookieAuthorize]
    public class UserController : Controller
    {
        private IWebApiFactory<EmployeeDTO> _employeeDataFactory;

        public UserController(IWebApiFactory<EmployeeDTO> apiFactory)
        {
            _employeeDataFactory = apiFactory;
            //_employeeDataFactory = new WebApiFactory<EmployeeDTO>("http://localhost:54435/api/", "Employee", WebApiRestService.ContentType.Xml);
        }

        private string GetToken()
        {
            return Request.Cookies["bearerToken"] != null ? Request.Cookies["bearerToken"].Value : null;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetAll()
        {
            try
            {
                using (var employeeApiFactory = _employeeDataFactory)
                {
                    employeeApiFactory.SetAuth(GetToken());
                    var model = await employeeApiFactory.GetAll();
                    return Json(model, JsonRequestBehavior.AllowGet);
                }
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
                using (var employeeApiFactory = _employeeDataFactory)
                {
                    employeeApiFactory.SetAuth(GetToken());
                    var model = await employeeApiFactory.GetOne(id);

                    Mapper.CreateMap<EmployeeDTO, EmployeeDetailsModel>();
                    var objMapped = Mapper.Map<EmployeeDTO, EmployeeDetailsModel>(model);

                    return View("Details", objMapped);
                }
            }
            catch (HttpResponseException ex)
            {
                return new HttpStatusCodeResult(ex.Response.StatusCode);
            }
        }
    }
}
