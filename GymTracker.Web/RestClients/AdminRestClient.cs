using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using GymTracker.Core.DTO;
using GymTracker.Web.Factories.Interfaces.RestClients;
using WebApiRestService;
using WebApiRestService.Authentication;

namespace GymTracker.Web.RestClients
{
    /// <summary>
    /// Class to retrieve all user information in the database. 
    /// </summary>
    public class AdminRestClient : WebApiClient<UserDto>, IAdminRestClient
    {
        private static readonly WebApiClientOptions options = new WebApiClientOptions
        {
            BaseAddress = "http://localhost:54435/api/",
            ContentType = ContentType.Json,
            Timeout = 10000,
            Controller = "Admin",
            Authentication = new BearerTokenAuthentication("Nick.Naylor", "password", "http://localhost:54435/token")
        };

        public AdminRestClient()
            : this(options)
        { }

        private AdminRestClient(WebApiClientOptions options)
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

        public virtual async Task<IEnumerable<UserDto>> GetMany(Func<UserDto, bool> func)
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

        public virtual async Task<UserDto> CreateOne()
        {
            try
            {
                var result = await CreateAsync(new UserDto());
                return result;
            }
            catch (WebApiClientException ex)
            {
                throw new HttpResponseException(ex.StatusCode);
            }
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            try
            {
                var result = await GetManyAsync("/Users/GetAll");
                return result;
            }
            catch (WebApiClientException ex)
            {
                throw new HttpResponseException(ex.StatusCode);
            }
        }
    }
}