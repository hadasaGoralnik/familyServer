using Bl;
using Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace Ui
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IChatService, ChatService>(new ContainerControlledLifetimeManager());
            config.DependencyResolver = new UnityDependencyResolver(container);
            // Web API configuration and services
            EnableCrossSiteRequests(config);
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.EnableCors();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
        private static void EnableCrossSiteRequests(HttpConfiguration config)
        {
            //var cors = new EnableCorsAttribute(
            //    origins: "*",
            //    headers: "*",
            //    methods: "*");

          //  config.EnableCors(cors);
        }
    }
}
