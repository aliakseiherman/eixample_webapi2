using eixample_webapi2.Application;
using eixample_webapi2.Host.Models.Auth;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace eixample_webapi2.Controllers
{
    [RoutePrefix("api/[controller]/[action]")]
    public class AuthController : BaseAuthController
    {
        private IUserService _userService;

        public AuthController(
            IUserService userService,
            Session session
            ) : base(
                session
                )
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<AuthenticateOutput> Authenticate([FromBody] AuthenticateInput input)
        {
            var expires = input.RememberMe ? DateTime.UtcNow.AddDays(30) : DateTime.UtcNow.AddMinutes(30);

            var user = await _userService.Authenticate(input.UserName, input.Password);

            if (user == null)
            {
                throw new Exception("Unauthorised");
            }

            return new AuthenticateOutput() { Token = GetAuthToken(user, expires) };
        }
    }
}
