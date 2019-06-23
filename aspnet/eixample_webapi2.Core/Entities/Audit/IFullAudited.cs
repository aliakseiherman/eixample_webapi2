namespace eixample_webapi2.Entities
{
    public interface IFullAudited : IHasCreationTime, IHasCreator, IHasModificationTime, IHasModifier, IHasDeletionTime, IHasDeleter, ISoftDelete, IHasTenant
    {
    }
}
