using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace GymTracker.API
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.MapHttpRoute(
                    name: "DefaultApiJson",
                    routeTemplate: "api/{controller}/{id}/{format}",
                    defaults: new { id = RouteParameter.Optional, format = RouteParameter.Optional }
                );

            routes.MapHttpRoute(name: "DefaultApiWithAction",
                routeTemplate: "api/{controller}/{action}");

            //routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}/{format}",
            //    defaults: new { id = RouteParameter.Optional, format = RouteParameter.Optional }
            //);
        }
    }
}