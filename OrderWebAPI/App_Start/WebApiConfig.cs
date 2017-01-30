using OrderWebAPI.ExceptionTracing;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace OrderWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Filters.Add(new CustomExceptionFilter());
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
            // Web API configuration and services
            config.SuppressDefaultHostAuthentication();
            // Configure Web API to use only bearer token authentication.
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}