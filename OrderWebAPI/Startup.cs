using Order.Business.Interface;
using Order.Ioc.App_Start;
using OrderWebAPI.Provider;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;

[assembly: OwinStartup(typeof(OrderWebAPI.Startup))]

namespace OrderWebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var configuration = UnityRegistration.RegisterComponents();

            var _loginBusiness = (ILoginBusiness)configuration.DependencyResolver.GetService(typeof(ILoginBusiness));
            var oAuthProvider = new ApplicationOAuthProvider(_loginBusiness);
            var options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = oAuthProvider
            };
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            WebApiConfig.Register(configuration);
            //enable cors origin requests
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(configuration);
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}