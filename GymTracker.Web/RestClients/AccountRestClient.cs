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
    public class AccountRestClient : WebApiClient<UserDto>, IAccountRestClient
    {
        private static readonly WebApiClientOptions options = new WebApiClientOptions
        {
            BaseAddress = "http://localhost:54435/api/",
            ContentType = ContentType.Json,
            Timeout = 10000,
            Controller = "Account"
        };

        public AccountRestClient()
            : this(options)
        { }

        private AccountRestClient(WebApiClientOptions options)
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
    }
}