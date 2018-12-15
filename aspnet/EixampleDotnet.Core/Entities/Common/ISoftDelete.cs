using System;

namespace EixampleDotnet.Entities
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}
