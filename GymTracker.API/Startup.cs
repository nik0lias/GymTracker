using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;
using GymTracker.API;
using GymTracker.API.Providers;
using GymTracker.API.Windsor;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace GymTracker.API
{
    public class Startup
    {
        private IWindsorContainer _container;

        public void Configuration(IAppBuilder app)
        {
            SetCastleContainer();
            ConfigOAuth(app);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configuration.MapHttpAttributeRoutes();
            GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Never;
            GlobalConfiguration.Configuration.EnsureInitialized();
      
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // we can change this to specific IP's if needed
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(GlobalConfiguration.Configuration);
            
        }

        public void ConfigOAuth(IAppBuilder app)
        {
            var oAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
                Provider = new SimpleAuthorizationServerProvider(),
            };

            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        private void SetCastleContainer()
        {
            _container = new WindsorContainer().Install(new WindsorInstaller());

            // Configure WebApi to use a new CastleDependencyResolver as its dependency resolver
            GlobalConfiguration.Configuration.DependencyResolver = new CastleDependencyResolver(_container);
        }
    }
}