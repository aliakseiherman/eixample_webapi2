using AutoMapper;
using eixample_webapi2.Application;
using eixample_webapi2.Dto;
using eixample_webapi2.Entities;
using eixample_webapi2.EntityFramework;
using eixample_webapi2.Models.Sessions;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace eixample_webapi2.Controllers
{
    [RoutePrefix("api/[controller]/[action]")]
    public class SessionController : ApiController
    {
        private AppDbContext _dbContext;
        private IMapper _mapper;
        private Session _session;

        public SessionController(
            AppDbContext dbContext,
            IMapper mapper,
            Session session
            )
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _session = session;
        }

        [HttpGet]
        public async Task<GetCurrentLoginDetailsOutput> GetCurrentLoginDetails()
        {
            var output = new GetCurrentLoginDetailsOutput();
            output.User = GetUser();

            if (_session.TenantId.HasValue)
            {
                var tenant = _dbContext.Tenants.SingleOrDefault(x => x.Id == _session.TenantId);
                if (tenant != null)
                {
                    output.Tenant = _mapper.Map<Tenant, TenantDto>(tenant);
                }
            }

            return await Task.FromResult(output);
        }

        [HttpGet]
        public async Task<GetCurrentUserDataOutput> GetCurrentUserData()
        {
            var output = new GetCurrentUserDataOutput();
            output.User = GetUser();
            return await Task.FromResult(output);
        }

        private UserDto GetUser()
        {
            if (_session.UserId != null)
            {
                var user = _dbContext.Users.SingleOrDefault(x => x.Id == _session.UserId);
                if (user != null)
                {
                    var userDto = _mapper.Map<ApplicationUser, UserDto>(user);
                    return userDto;
                }
            }

            return null;
        }
    }
}
