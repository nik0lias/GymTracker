using System.Web.Mvc;
using System.Web.Routing;

namespace GymTracker.Web.Attributes
{
    /// <summary>
    /// Simple authorization class that checks if the cookie exists.  Because the cookie is given an expiry time 
    /// when created there is no need to check if the users token has expired. THIS IS THE TEST BRANCH
    /// </summary>
    public class CustomCookieAuthorize : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.RequestContext.HttpContext.Request.Cookies["bearerToken"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                        RouteValueDictionary(new { controller = "Account", action = "Login" }));
            }
        }
    }
}