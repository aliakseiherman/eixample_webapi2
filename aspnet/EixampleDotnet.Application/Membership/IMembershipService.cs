using EixampleDotnet.Entities;

namespace EixampleDotnet.Application
{
    public interface IMembershipService
    {
        bool IsMember(string userId);

        void CreateMembership(ApplicationUser user);
    }
}