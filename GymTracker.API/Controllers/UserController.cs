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
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        public IUserRepository _repo { get; set; }
    
        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [ActionName("GetAll")]
        public IEnumerable<UserDto> GetAllUsers()
        {
            Mapper.CreateMap<IUser, UserDto>();
            var employees = _repo.GetAll();
            return Mapper.Map<IEnumerable<IUser>, IEnumerable<UserDto>>(employees);
        }

        [HttpGet]
        [ActionName("Get")]
        public UserDto GetUsers(int id)
        {
            Mapper.CreateMap<IUser, UserDto>();
            var employee = _repo.Query(x => x.Id == id).FirstOrDefault();
            return Mapper.Map<IUser, UserDto>(employee);
        }
       
        public void Post([FromBody]string value)
        {

        }

        public void Put(int id, [FromBody]string value)
        {

        }

        public void Delete(int id)
        {

        }
    }
}