namespace eixample_webapi2.Dto
{
    public class TenantDto : EntityDto<long>
    {
        public string Name { get; set; }

        public string HostName { get; set; }
    }
}
