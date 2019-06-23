using System;

namespace eixample_webapi2.Entities
{
    public interface IHasDeletionTime
    {
        DateTime? DeletionTime { get; set; }
    }
}
