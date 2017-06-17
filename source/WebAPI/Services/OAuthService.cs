using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using System.Threading.Tasks;
using System.Web.Cors;
using System;
using Microsoft.Owin.Security.OAuth;

namespace WebAPI.Services
{
    public class OAuthService
    {
        public void ActiveAccessToken(IAppBuilder app)
        {
            var optionsConfigurationToken = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                //Configurando o endereço do fornecimento do token de acesso
                TokenEndpointPath = new PathString("/token"),
                //Configura por quanto tempo um token de acesso já forncedido valerá 
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(15),
                Provider = new OAuthProvider()
            };

            app.UseOAuthAuthorizationServer(optionsConfigurationToken);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        public void ConfigureCors(IAppBuilder app)
        {
            var policy = new CorsPolicy();

            policy.AllowAnyHeader = true;
            policy.AllowAnyMethod = true;
            policy.AllowAnyOrigin = true;

            var corsOptions = new CorsOptions
            {
                PolicyProvider = new CorsPolicyProvider
                {
                    PolicyResolver = context => Task.FromResult(policy)
                }
            };

            app.UseCors(corsOptions);
        }
    }
}