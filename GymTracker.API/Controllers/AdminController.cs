using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using GymTracker.API.Plumbing;
using GymTracker.Core.DTO;
using GymTracker.Core.Interfaces;

namespace GymTracker.API.Controllers
{
    [CorsPolicyAttribue]
    [Authorize]
    [RoutePrefix("api/admin")]
    public class AdminController : ApiController
    {
        public IUserRepository _repo { get; set; }
    
        public AdminController(IUserRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("users/getall")]
        public IEnumerable<UserDto> GetAllUsers()
        {
            Mapper.CreateMap<IUser, UserDto>();
            var employees = _repo.GetAll();
            return Mapper.Map<IEnumerable<IUser>, IEnumerable<UserDto>>(employees);
        }

        [HttpGet]
        [Route("users/get")]
        public UserDto GetUsers(int id)
        {
            Mapper.CreateMap<IUser, UserDto>();
            var employee = _repo.Query(x => x.Id == id).FirstOrDefault();
            return Mapper.Map<IUser, UserDto>(employee);
        }
    }
}