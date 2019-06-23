using System;

namespace eixample_webapi2.Entities
{
    public interface IHasModificationTime
    {
        DateTime? ModificationTime { get; set; }
    }
}
