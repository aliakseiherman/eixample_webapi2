using EixampleDotnet.Dto;

namespace EixampleDotnet.Models.Sessions
{
    public class GetCurrentLoginDetailsOutput
    {
        public TenantDto Tenant { get; set; }

        public UserDto User { get; set; }
    }
}
