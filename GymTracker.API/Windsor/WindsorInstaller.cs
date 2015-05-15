using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using GymTracker.API.Controllers;
using GymTracker.Core.Interfaces;
using GymTracker.Core.Interfaces.Base;
using GymTracker.Data;
using GymTracker.Data.Repositories;

namespace GymTracker.API.Windsor
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Register working dependencies
            container.Register(Component.For<IUserRepository>()
                .ImplementedBy<EmployeeRepository>().LifestyleTransient());

            container.Register(Component.For<IAuthRepository>()
               .ImplementedBy<AuthRepository>().LifestyleTransient());

            container.Register(Component.For<IUnitOfWork>()
              .ImplementedBy<EntityFrameworkUnitOfWork>().LifestyleTransient());

            // Register all the WebApi controllers within this assembly
            container.Register(Classes.FromAssembly(typeof(AdminController).Assembly)
                                      .BasedOn<ApiController>()
                                      .LifestyleScoped());

            container.Register(Classes.FromAssembly(typeof(AccountController).Assembly)
                                      .BasedOn<ApiController>()
                                      .LifestyleScoped());

        }
    }
}