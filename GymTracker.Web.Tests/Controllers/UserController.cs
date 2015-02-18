using GymTracker.Core.DTO;
using GymTracker.Web.Controllers;
using GymTracker.Web.Factories.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTracker.Web.Tests.Controllers
{
    [TestClass]
    public class UserControllerTests
    {
        [TestMethod]
        public async void TestGetAllUsers()
        {
            var factory = Substitute.For<IWebApiFactory<EmployeeDTO>>();
            UserController controller = new UserController(factory);
            
            
            var listEmployeeDto = new List<EmployeeDTO>()
            {
                new EmployeeDTO(),
                new EmployeeDTO()
            };

            var v = await Task.FromResult(listEmployeeDto);

            await factory.GetAll().Returns(v);

            //controller.GetAll();
        }
    }
}
