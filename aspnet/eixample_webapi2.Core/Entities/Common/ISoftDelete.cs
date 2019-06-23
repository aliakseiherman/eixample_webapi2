using System;

namespace eixample_webapi2.Entities
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}
