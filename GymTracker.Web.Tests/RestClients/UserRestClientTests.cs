using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymTracker.Core.DTO;
using GymTracker.Web.RestClients;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace GymTracker.Web.Tests.RestClients
{
    [TestClass]
    public class UserRestClientTests
    {
        /// <summary>
        /// Call the user rest client and test the return type is as expected.
        /// </summary>
        [TestMethod]
        public async Task Test_UserApiClient_Intiailisation()
        {
            // Arrange
            var webClient = Substitute.For<UserRestClient>();
            webClient.GetOne(Arg.Any<int>()).Returns(Task.FromResult(new UserDto()));

            // Act
            var result = await webClient.GetOne(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(UserDto));
        }

        /// <summary>
        /// Call the user rest client and test the result to see if its the user expected.
        /// </summary>
        [TestMethod]
        public async Task Test_UserApiClient_GetOne()
        {
            // Arrange
            var webClient = Substitute.For<UserRestClient>();
            webClient.GetOne(1).Returns(Task.FromResult(new UserDto { Id = 1, Forename = "Nick", Surname = "Naylor" }));

            // Act
            var result = await webClient.GetOne(1);

            // Assert
            Assert.AreEqual("Nick", result.Forename);
            Assert.AreEqual("Naylor", result.Surname);
        }

        /// <summary>
        /// Test the ability to get all users and count these.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Test_UserApiClient_GetAll()
        {
            // Arrange
            var webClient = Substitute.For<UserRestClient>();

            IEnumerable<UserDto> users = new List<UserDto>
            {
                new UserDto { Id = 1, Forename = "Nick", Surname = "Naylor" },
                new UserDto { Id = 2, Forename = "Joe", Surname = "Bloggs" }
            };

            webClient.GetAll().Returns(Task.FromResult(users));

            // Act
            var result = await webClient.GetAll();

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        /// <summary>
        /// Test the ability to call the rest client and test the specific data returned
        /// </summary>
        [TestMethod]
        public async Task Test_UserApiClient_GetAll_Test_Specific_User()
        {
            // Arrange
            var webClient = Substitute.For<UserRestClient>();

            IEnumerable<UserDto> users = new List<UserDto>
            {
                new UserDto { Id = 1, Forename = "Nick", Surname = "Naylor" },
                new UserDto { Id = 2, Forename = "Joe", Surname = "Bloggs" }
            };

            webClient.GetAll().Returns(Task.FromResult(users));

            // Act
            var result = await webClient.GetAll();

            // Assert
            Assert.AreEqual(result.First().Forename, "Nick");
            Assert.AreEqual(result.First().Surname, "Naylor");
        }

        /// <summary>
        /// Test the ability to call the rest client for specific data via a linq function
        /// </summary>
        [TestMethod]
        public async Task Test_UserApiClient_GetMany_By_Func()
        {
            // Arrange
            var webClient = Substitute.For<UserRestClient>();

            IEnumerable<UserDto> users = new List<UserDto>
            {
                new UserDto { Id = 1, Forename = "Nick", Surname = "Naylor" },
                new UserDto { Id = 2, Forename = "Joe", Surname = "Bloggs" }
            };

            webClient.GetMany(Arg.Any<Func<UserDto, bool>>()).Returns(Task.FromResult(users));

            // Act
            var result = await webClient.GetMany(x => x.Surname == "Naylor");

            // Assert
            Assert.AreEqual(result.First().Forename, "Nick");
            Assert.AreEqual(result.First().Surname, "Naylor");
        }
    }
}
