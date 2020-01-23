using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace WebAPITokenbasesAuth
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            if (context.UserName == "vinuth" && context.Password == "password")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                identity.AddClaim(new Claim("username", "vinuth"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "vinuth"));
                context.Validated(identity);
            }
            else if (context.UserName == "vinay" && context.Password == "password")

            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                identity.AddClaim(new Claim("username", "vinay"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "vinay"));
                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "Provided username and password doesn't match");
            }
        }
    }
}