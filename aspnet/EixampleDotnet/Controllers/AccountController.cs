using AutoMapper;
using EixampleDotnet.Application;
using EixampleDotnet.Dto;
using EixampleDotnet.Models.Account;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace EixampleDotnet.Controllers
{
    [RoutePrefix("api/[controller]/[action]")]
    public class AccountController : BaseAuthController
    {
        private IUserService _userService;
        private IMapper _mapper;

        public AccountController(
            IUserService userService,
            IMapper mapper,
            Session session
            ) : base(
                session
                )
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<RegisterOutput> Register([FromBody] RegisterInput input)
        {
            var output = new RegisterOutput();

            var createUserInput = _mapper.Map<CreateUserInput>(input);

            var user = await _userService.Create(createUserInput);

            if (user != null)
            {
                output.Token = GetAuthToken(user, DateTime.UtcNow.AddDays(30));
            }

            return output;
        }
    }
}
