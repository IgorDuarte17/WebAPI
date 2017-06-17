using WebAPI.Services;
using Owin;
using System.Web.Http;

namespace WebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            OAuthService oAuthService = new OAuthService();

            //Ativa Cors
            oAuthService.ConfigureCors(app);

            //Ativa token de acesso
            oAuthService.ActiveAccessToken(app);

            //Ativa configuração da WebAPI
            app.UseWebApi(config);
        }
    }
}
