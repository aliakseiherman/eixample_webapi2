namespace eixample_webapi2.Entities
{
    public class Type<TPrimaryKey> : Entity<TPrimaryKey>, IType
    {
        public string Name { get; set; }
    }
}
