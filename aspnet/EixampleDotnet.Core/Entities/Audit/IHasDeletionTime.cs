using System;

namespace EixampleDotnet.Entities
{
    public interface IHasDeletionTime
    {
        DateTime? DeletionTime { get; set; }
    }
}
