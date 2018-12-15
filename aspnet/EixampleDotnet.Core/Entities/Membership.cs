using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EixampleDotnet.Entities
{
    public class Membership : Entity<long>, IHasCreationTime
    {
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int TenantId { get; set; }

        public virtual Tenant Tenant { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreationTime { get; set; }
    }
}
