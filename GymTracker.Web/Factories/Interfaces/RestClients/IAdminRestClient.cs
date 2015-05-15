using System.Collections.Generic;
using System.Threading.Tasks;
using GymTracker.Core.DTO;
using GymTracker.Web.Factories.Interfaces.Base;
using GymTracker.Web.Models;

namespace GymTracker.Web.Factories.Interfaces.RestClients
{
    public interface IAdminRestClient : IWebApiFactory<UserDto>
    {
        Task<IEnumerable<UserDto>> GetAllUsers();

    }
}
