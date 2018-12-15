using System;

namespace EixampleDotnet.Entities
{
    public interface IHasModificationTime
    {
        DateTime? ModificationTime { get; set; }
    }
}
