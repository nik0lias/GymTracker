using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using GymTracker.Core.DTO;
using GymTracker.Web.Factories.Interfaces.RestClients;
using WebApiRestService;

namespace GymTracker.Web.RestClients
{
    /// <summary>
    /// Class to retrieve all user information in the database. 
    /// </summary>
    public class UserRestClient : WebApiClient<UserDto>, IUserRestClient
    {
        private static readonly WebApiClientOptions options = new WebApiClientOptions
        {
            BaseAddress = "http://localhost:54435/api/",
            ContentType = ContentType.Json,
            Timeout = 10000,
            Controller = "Employee"
        };

        public UserRestClient()
            : this(options)
        { }

        private UserRestClient(WebApiClientOptions options)
            : base(options)
        { }

        public virtual async Task<UserDto> GetOne(int id)
        {
            try
            {
                return await GetOneAsync(new { id = id }, "Get");
            }
            catch (WebApiClientException ex)
            {
                throw new HttpResponseException(ex.StatusCode);
            }
        }

        public virtual async Task<IEnumerable<UserDto>> GetAll()
        {
            try
            {
                return await GetManyAsync();
            }
            catch (WebApiClientException ex)
            {
                throw new HttpResponseException(ex.StatusCode);
            }
        }

        public async Task<IEnumerable<UserDto>> GetMany(Func<UserDto, bool> func)
        {
            try
            {
                var result = await GetManyAsync();
                return result.Where(func);
            }
            catch (WebApiClientException ex)
            {
                throw new HttpResponseException(ex.StatusCode);
            }
        }

        public Task<UserDto> CreateOne()
        {
            throw new NotImplementedException();
        }
    }
}