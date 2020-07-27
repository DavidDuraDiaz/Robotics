using Microsoft.Owin.Security.OAuth;
using Robotics.Core.Interfaces;
using Robotics.Persistence.Repository;
using Robotics.Persitence.Context;
using System.Data.Entity;
using TokenAuthenticationInWebAPI.Models;
using Unity;
using Unity.Lifetime;

namespace Robotics.WebAPI.DependencyInjection
{
    public class DIConfigurator
    {
        /// <summary>
        /// Configures the Dependency Injector
        /// </summary>
        /// <returns>The configuration Object</returns>
        public static UnityContainer ConfigureDI()
        {
            var container = new UnityContainer();
            container.RegisterType<OAuthAuthorizationServerProvider, AuthorizationProvider>(new HierarchicalLifetimeManager());
            container.RegisterType<DbContext, BooksEntities>(new HierarchicalLifetimeManager());
            container.RegisterType<IBookRepository, BookRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());

            return container;
        }
    }
}