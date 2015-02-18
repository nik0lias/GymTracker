using System;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Cors;
using System.Web.Http.Cors;

namespace GymTracker.API.Plumbing
{   
    /// <summary>
    /// Custom origin policy implemented so allowed addresses can be added, so code doesnt need recompiling
    /// also aids CI releases.
    /// </summary>
    public class CorsPolicyAttribue : Attribute, ICorsPolicyProvider
    {
        private CorsPolicy _policy;

        public CorsPolicyAttribue()
        {
            _policy = new CorsPolicy
            {
                AllowAnyMethod = true,
                AllowAnyHeader = true
            };

            var origins = ConfigurationManager.AppSettings["AllowedCorsOrigins"];

            foreach (var item in origins.Split(';').ToList())
            {
                _policy.Origins.Add(item);
            }
        }

        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_policy);
        }
    }
}