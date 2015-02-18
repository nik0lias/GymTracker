using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using GymTracker.Web.Factories.Interfaces;
using WebApiRestService;
using WebApiRestService.Authentication;

namespace GymTracker.Web.Factories
{
    public class WebApiFactory<T> : IWebApiFactory<T>, IDisposable
        where T : class
    {
        private WebApiClientOptions _options;

        public WebApiFactory(string url, string controller, ContentType contentType)
        {
            _options = new WebApiClientOptions()
            {
                BaseAddress = url,
                ContentType = contentType,
                Timeout = 30000,
                Controller = controller,
            };
        }

        public void SetAuth(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }

            _options.Authentication = new BearerTokenAuthentication(token);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                using (var client = new WebApiClient<T>(_options))
                {
                    return await client.GetManyAsync("GetAll");
                }
            }
            catch (WebApiClientException ex)
            {
                throw new HttpResponseException(ex.StatusCode);
            }
        }

        public async Task<IEnumerable<T>> GetMany()
        {
            try
            {
                using (var client = new WebApiClient<T>(_options))
                {
                    return await client.GetManyAsync();
                }
            }
            catch (WebApiClientException ex)
            {
                throw new HttpResponseException(ex.StatusCode);
            }
        }

        public async Task<T> GetOne(int id)
        {
            try
            {
                using (var client = new WebApiClient<T>(_options))
                {
                    return await client.GetOneAsync(new { id = id }, "Get");
                }
            }
            catch (WebApiClientException ex)
            {
                throw new HttpResponseException(ex.StatusCode);
            }
        }

        public async Task<T> CreateOne(string action)
        {
            try
            {
                using (var client = new WebApiClient<T>(_options))
                {
                    var v = (T)Activator.CreateInstance(typeof(T));
                    return await client.CreateAsync(v, "Login");
                }
            }
            catch (WebApiClientException ex)
            {
                throw new HttpResponseException(ex.StatusCode);
            }
        }

        public void Dispose()
        {
            //log service call ended
        }
    }
}