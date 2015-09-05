using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApiOwin.AuthenticationProvider;

[assembly: OwinStartup(typeof(WebApiOwin.Startup))]
namespace WebApiOwin
{
    public class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new AuthProvider(),

                AccessTokenExpireTimeSpan = TimeSpan.FromDays(7),
                AllowInsecureHttp = true
            };
            //AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);
        }

    }
}