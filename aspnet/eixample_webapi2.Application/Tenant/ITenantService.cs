using eixample_webapi2.Entities;

namespace eixample_webapi2.Application
{
    public interface ITenantService
    {
        int? GetBySubdomain(string subdomain);

        Tenant GetById(long id);
    }
}
