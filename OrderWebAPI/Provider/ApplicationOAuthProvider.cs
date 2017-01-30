using Order.Business.DataContract;
using Order.Business.Interface;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OrderWebAPI.Provider
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly ILoginBusiness _loginBusiness;

        public ApplicationOAuthProvider(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var loginBusinessModel = new LoginDataContract { Email = context.UserName, PasswordHash = context.Password };
            var user = await _loginBusiness.FindByUserNameorEmail(loginBusinessModel);

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }
            loginBusinessModel.UserId = user.UserId;
            var roles = await _loginBusiness.GetRolesByUserId(loginBusinessModel);
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            foreach (var item in roles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, item.Name));
            }

            context.Validated(identity);
        }
    }
}