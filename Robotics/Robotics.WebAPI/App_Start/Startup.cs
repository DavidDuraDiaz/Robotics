using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Robotics.WebAPI.AutoMapper;
using Robotics.WebAPI.DependencyInjection;
using Robotics.WebAPI.DependencyResolver;
using Robotics.WebAPI.Logger;
using Serilog;
using System;
using System.Web.Http;
using Unity;

[assembly: OwinStartup(typeof(Robotics.WebAPI.Startup))]

namespace Robotics.WebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var container = DIConfigurator.ConfigureDI();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityResolver(container);

            container.RegisterInstance(MapperConfigurator.configureAutomapper());

            LoggerConfigurator.ConfigureLogger();
            container.RegisterInstance<ILogger>(Log.Logger);

            var OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = container.Resolve<OAuthAuthorizationServerProvider>()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }


    }
}