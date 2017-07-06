using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public class OAuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            
            //TODO: Aqui Lógica para validar usuário e senha
            //TODO: Verificar no if se usuário não está valido
            if ()
            {
                context.SetError("invalid_grant", "Usuário não encontrado ou senha incorreta.");
                return;
            }

            //emiti o token
            var userIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
            context.Validated(userIdentity);
        }
    }
}