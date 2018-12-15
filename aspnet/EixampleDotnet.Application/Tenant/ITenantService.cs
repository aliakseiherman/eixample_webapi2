using EixampleDotnet.Entities;

namespace EixampleDotnet.Application
{
    public interface ITenantService
    {
        int? GetBySubdomain(string subdomain);

        Tenant GetById(long id);
    }
}
