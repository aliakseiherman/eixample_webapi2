using eixample_webapi2.Application;
using eixample_webapi2.Consts;
using eixample_webapi2.Entities;
using eixample_webapi2.Helpers;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Web.Http;

namespace eixample_webapi2.Controllers
{
    public class BaseAuthController : ApiController
    {
        protected Session Session;

        public BaseAuthController(
            Session session
            )
        {
            Session = session;
        }

        public string GetAuthToken(ApplicationUser user, DateTime expires)
        {
            string strTenantId = Session.TenantId.HasValue ? Session.TenantId.ToString() : string.Empty;

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = expires,
                Issuer = ConfigHelper.GetIssuer(),
                Audience = ConfigHelper.GetAudience(),
                SigningCredentials = ConfigHelper.GetSigningCredentials(),
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(CustomClaims.TenantId, strTenantId)
                })
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
