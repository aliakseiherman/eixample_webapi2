using System;

namespace eixample_webapi2.Entities
{
    public interface IHasCreationTime
    {
        DateTime CreationTime { get; set; }
    }
}
