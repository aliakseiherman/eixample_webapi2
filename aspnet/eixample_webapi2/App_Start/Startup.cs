using eixample_webapi2.Helpers;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Owin;

[assembly: OwinStartup(typeof(eixample_webapi2.App_Start.Startup))]

namespace eixample_webapi2.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidAudience = ConfigHelper.GetAudience(),
                        ValidIssuer = ConfigHelper.GetIssuer(),
                        IssuerSigningKey = ConfigHelper.GetSymmetricSecurityKey(),
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true
                    }
                });
        }
    }
}
