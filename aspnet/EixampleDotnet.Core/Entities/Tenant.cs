using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EixampleDotnet.Entities
{
    public class Tenant : Entity<int>, ISoftDelete, IHasCreationTime
    {
        public string Name { get; set; }

        public string HostName { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreationTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DeletionTime { get; set; }
    }
}
