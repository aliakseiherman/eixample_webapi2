using EixampleDotnet.Application;
using EixampleDotnet.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace EixampleDotnet.Controllers
{
    [RoutePrefix("api/[controller]/[action]")]
    [Authorize]
    public class TeamController : ApiController
    {
        private ITeamService _teamService;

        public TeamController(
            ITeamService teamService
            )
        {
            _teamService = teamService;
        }
        
        [HttpPost]
        public async Task<bool> Add([FromBody] TeamDto input)
        {
            var result = await _teamService.Add(input);
            return result;
        }

        [HttpPost]
        public async Task<bool> Update([FromBody] TeamDto input)
        {
            var result = await _teamService.Update(input);
            return result;
        }

        [HttpPost]
        public async Task<bool> Delete([FromBody] TeamDto input)
        {
            var result = await _teamService.Delete(input);
            return result;
        }

        [HttpGet]
        public async Task<List<TeamDto>> GetAll()
        {
            var result = await _teamService.GetAll();
            return result;
        }
    }
}
