using Microsoft.Owin.Security.OAuth;
using Robotics.Core.Entities;
using Robotics.Core.Interfaces;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TokenAuthenticationInWebAPI.Models
{
    public class AuthorizationProvider : OAuthAuthorizationServerProvider
    {

        protected IUserRepository _repository;

        public AuthorizationProvider(IUserRepository repository)
        {
            _repository = repository;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId = string.Empty;
            string clientSecret = string.Empty;
            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.SetError("invalid_client", "Client credentials could not be retrieved through the Authorization header.");
                context.Rejected();
                return;
            }
            var client = await _repository.ValidateUser(clientId, clientSecret);
            if (client != null)
            {
                context.OwinContext.Set<Users>("oauth:client", client);
                context.Validated(clientId);
            }
            else
            {
                context.SetError("invalid_client", "Client credentials are invalid.");
                context.Rejected();
            }
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var user = await _repository.ValidateUser(context.UserName, context.Password);
            if (user == null)
            {
                context.SetError("invalid_grant", "Provided username or password is incorrect");
                return;
            }
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Role, user.Username));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));

            context.Validated(identity);
        }
    }
}