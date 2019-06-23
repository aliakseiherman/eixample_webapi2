using eixample_webapi2.Dto;

namespace eixample_webapi2.Models.Sessions
{
    public class GetCurrentLoginDetailsOutput
    {
        public TenantDto Tenant { get; set; }

        public UserDto User { get; set; }
    }
}
