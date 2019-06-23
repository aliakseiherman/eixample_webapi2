using eixample_webapi2.Entities;

namespace eixample_webapi2.Application
{
    public interface IMembershipService
    {
        bool IsMember(string userId);

        void CreateMembership(ApplicationUser user);
    }
}