using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace GymTracker.API.Exception
{
    public class HandleExceptionAttribute : ExceptionFilterAttribute
    {
        public Type Type { get; set; }
        public HttpStatusCode Status { get; set; }

        public override void OnException(HttpActionExecutedContext context)
        {
            var ex = context.Exception;
            if (ex.GetType() is Type)
            {
                var response = context.Request.CreateResponse<string>(Status, ex.Message);
                throw new HttpResponseException(response);
            }
        }
    }
}