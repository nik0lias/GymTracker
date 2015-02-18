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
    [RoutePrefix("api/Employee")]
    public class EmployeeController : ApiController
    {
        public IEmployeeRepository _repo { get; set; }
    
        public EmployeeController(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [ActionName("GetAll")]
        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            Mapper.CreateMap<IEmployee, EmployeeDTO>();
            var employees = _repo.GetAll();
            return Mapper.Map<IEnumerable<IEmployee>, IEnumerable<EmployeeDTO>>(employees);
        }

        [HttpGet]
        [ActionName("Get")]
        public EmployeeDTO GetEmployees(int id)
        {
            Mapper.CreateMap<IEmployee, EmployeeDTO>();
            var employee = _repo.Query(x => x.Id == id).FirstOrDefault();
            return Mapper.Map<IEmployee, EmployeeDTO>(employee);
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