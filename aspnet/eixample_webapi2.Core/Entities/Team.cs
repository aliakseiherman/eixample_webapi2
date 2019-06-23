namespace eixample_webapi2.Entities
{
    public class Team : FullAudited<long>, IHasTenant
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
