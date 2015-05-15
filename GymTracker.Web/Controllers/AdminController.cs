using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using GymTracker.Core.DTO;
using GymTracker.Web.Factories.Interfaces.Base;
using System.Threading.Tasks;
using GymTracker.Web.Factories.Interfaces.RestClients;
using GymTracker.Web.Models.User;

namespace GymTracker.Web.Controllers
{
    [Route("Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminRestClient _userApi;

        public AdminController(IWebApiFactory<UserDto> userApiClient)
        {
            _userApi = userApiClient as IAdminRestClient;
        }

        public ActionResult Index()
        {
            return View();
        }

        [Route("Users/GetAll")]
        public async Task<ActionResult> GetAllUsers()
        {
            var users = await _userApi.GetAllUsers();

            Mapper.CreateMap<UserDto, UserDetailsModel>();

            var usersMapped = Mapper.Map<IEnumerable<UserDto>, IEnumerable<UserDetailsModel>>(users);

            return View("Users", usersMapped);
        }
    }
}