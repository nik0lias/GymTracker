using System.Web.Mvc;
using System.Web.Script.Serialization;
using GymTracker.Core.DTO;
using GymTracker.Web.Controllers;
using GymTracker.Web.Factories.Interfaces;
using GymTracker.Web.Factories.Interfaces.Base;
using GymTracker.Web.Models.Signup;
using GymTracker.Web.RestClients;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymTracker.Web.Tests.Controllers
{
    [TestClass]
    public class UserControllerTests
    {
        /// <summary>
        /// Test that the we get a ViewResult when we search for a user, regardless of if they exist or not
        /// </summary>
        [TestMethod]
        public async Task Get_Single_User_As_View_Result()
        {
            // Arrange
            var factory = Substitute.For<IWebApiFactory<UserDto>>();
            
            factory.GetOne(Arg.Any<int>()).Returns(Task.FromResult(new UserDto()));
            var controller = new UserController(factory);
          
            // Act
            var getAllResults = await controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(getAllResults, typeof(ViewResult));
        }

        /// <summary>
        /// Test that the controller returns a JSON result, regardless of what it contains
        /// for multiple customers
        /// </summary>
        [TestMethod]
        public async Task Test_Mutliple_Clients_Is_Json_Result()
        {
            // Arrange
            IEnumerable<UserDto> employees = new List<UserDto>()
            {
                new UserDto { Id = 1, Forename = "Nick", Surname = "Naylor" },
                new UserDto { Id = 2, Forename = "James", Surname = "Jones" }
            };

            var factory = Substitute.For<IWebApiFactory<UserDto>>();
            factory.GetAll().Returns(Task.FromResult(employees));
            var userController = new UserController(factory);

            // Act
            var getAllUsers = await userController.GetAll();

            // Assert
            Assert.IsInstanceOfType(getAllUsers, typeof(JsonResult));
        }

        /// <summary>
        /// Call the controller and check the JSON is valid by deserializing and reserializing it and checking
        /// the type.
        /// </summary>
        [TestMethod]
        public async Task Check_All_Clients_Returns_Valid_Json()
        {
            // Arrange
            IEnumerable<UserDto> employees = new List<UserDto>()
            {
                new UserDto { Id = 1, Forename = "Nick", Surname = "Naylor" },
                new UserDto { Id = 2, Forename = "James", Surname = "Jones" }
            };

            var factory = Substitute.For<IWebApiFactory<UserDto>>();
            factory.GetAll().Returns(Task.FromResult(employees));
            var userController = new UserController(factory);
            var jsSerializer = new JavaScriptSerializer();

            // Act
            var result = await userController.GetAll() as JsonResult;
            var serialized = jsSerializer.Serialize(result.Data);
            var deSerialize = jsSerializer.Deserialize<List<UserDto>>(serialized);
            
            // Assert
            Assert.IsInstanceOfType(deSerialize, typeof(List<UserDto>));
        }

        [TestMethod]
        public async Task Check_CreateOne_Initialise()
        {
            // Arrange
            var factory = Substitute.For<IWebApiFactory<UserDto>>();
            var controller = new UserController(factory);

            var user = new UserDto
            {
                Id = 1,
                Forename = "Nick",
                Surname = "Naylor"
            };

            var createUser = new RegisterModel
            {
                Forename = "Nick",
                Surname = "Naylor",
                EmailAddress = "nick.naylor@test.com",
            };

            factory.CreateOne().Returns(Task.FromResult(user));

            // Act
            var result = await controller.CreateUser(createUser);

            // Assert
            Assert.AreSame(typeof(ViewResult), result);
        }
    }
}
