using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Order.Business.Interface;
using OrderWebAPI.Provider;
using Owin;
using System;

namespace OrderWebAPI.Tests
{
    public class Startup
    {
        public virtual ILoginBusiness LoginBusiness { get; }

        public void Configuration(IAppBuilder app)
        {
            var oAuthProvider = new ApplicationOAuthProvider(LoginBusiness);
            var options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = oAuthProvider
            };
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}