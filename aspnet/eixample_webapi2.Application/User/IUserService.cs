using eixample_webapi2.Dto;
using eixample_webapi2.Entities;
using System.Threading.Tasks;

namespace eixample_webapi2.Application
{
    public interface IUserService
    {
        Task<ApplicationUser> Authenticate(string username, string password);

        Task<ApplicationUser> Create(CreateUserInput input);
    }
}
