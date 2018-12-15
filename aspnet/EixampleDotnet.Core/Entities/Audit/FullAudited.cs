using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EixampleDotnet.Entities
{
    public class FullAudited<TPrimaryKey> : Entity<TPrimaryKey>, IFullAudited, ISoftDelete
    {
        [Column(TypeName = "datetime2")]
        public DateTime CreationTime { get; set; }

        public string CreatorId { get; set; }

        public virtual ApplicationUser Creator { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ModificationTime { get; set; }

        public string ModifierId { get; set; }

        public virtual ApplicationUser Modifier { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DeletionTime { get; set; }

        public string DeleterId { get; set; }

        public virtual ApplicationUser Deleter { get; set; }

        public bool IsDeleted { get; set; }

        public int TenantId { get; set; }
    }
}
