using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using GymTracker.Core.DTO;
using GymTracker.Web.Factories.Interfaces.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GymTracker.Web.Controllers;
using NSubstitute;
using GymTracker.Web.Models.User;

namespace GymTracker.Web.Tests.Controllers
{
    [TestClass]
    public class AdminControllerTests
    {
        [TestMethod]
        public void Test_Admin_Controller_Initialize()
        {
            // arrange
            var factory = Substitute.For<IWebApiFactory<UserDto>>();
            var controller = new AdminController(factory);

            // act
            var result = controller.Index();

            // assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Test_Admin_Controller_Get_All_Users_Initialise()
        {
            var factory = Substitute.For<IWebApiFactory<UserDto>>();
            var controller = new AdminController(factory);

            var result = controller.GetAllUsers();

            Assert.IsInstanceOfType(result, typeof(Task<ActionResult>));
        }

        [TestMethod]
        public void Test_Admin_Controller_Get_All_Users_Return_Data()
        {
            // arrange

            // the results of the API are a dto before mapping
            IEnumerable<UserDto> users = new List<UserDto>()
            {
                new UserDto
                {
                    Id = 1,
                    Forename = "Nick",
                    Surname = "Naylor"
                },
                new UserDto
                {
                    Id = 2,
                    Forename = "John",
                    Surname = "Doe"
                },
            };

            var factory = Substitute.For<IWebApiFactory<UserDto>>();
            factory.GetAll().Returns(Task.FromResult(users));

            var controller = new AdminController(factory);

            //act
            var result = controller.GetAllUsers().Result as ViewResult;

            //assert
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(List<UserDetailsModel>));
        }
    }
}
