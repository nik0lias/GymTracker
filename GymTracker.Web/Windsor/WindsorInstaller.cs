using System.Web.Http;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using GymTracker.Core.DTO;
using GymTracker.Web.Factories.Interfaces.Base;
using GymTracker.Web.RestClients;

namespace GymTracker.Web.Windsor
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                             .BasedOn<IController>()
                             .LifestyleTransient());

            container.Register(Component.For<IWebApiFactory<LoggedInUserDTO>>()
                .ImplementedBy<AccountRestClient>().LifestyleTransient());

            container.Register(Component.For<IWebApiFactory<UserDto>>()
               .ImplementedBy<UserRestClient>().LifestyleTransient());
        }
    }
}