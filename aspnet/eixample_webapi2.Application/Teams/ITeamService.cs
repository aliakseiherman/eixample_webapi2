using eixample_webapi2.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eixample_webapi2.Application
{
    public interface ITeamService
    {
        Task<bool> Add(TeamDto input);

        Task<bool> Update(TeamDto input);

        Task<bool> Delete(TeamDto input);

        Task<List<TeamDto>> GetAll();
    }
}