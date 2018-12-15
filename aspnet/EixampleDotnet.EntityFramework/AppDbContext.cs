using EixampleDotnet.Entities;
using EixampleDotnet.Extensions;
using EntityFramework.DynamicFilters;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EixampleDotnet.EntityFramework
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public string UserId { get; set; }
        public int? TenantId { get; set; }

        public AppDbContext() : base("Default")
        {
        }

        public AppDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public AppDbContext(DbConnection connection) : base(connection, true)
        {
        }

        public DbSet<Tenant> Tenants { get; set; }

        public DbSet<Membership> Memberships { get; set; }

        public DbSet<Team> Teams { get; set; }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            AuditEntities();

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            ChangeTracker.DetectChanges();
            AuditEntities();

            return (await base.SaveChangesAsync(cancellationToken));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Filter("SoftDelete", (ISoftDelete d) => d.IsDeleted, false);

            base.OnModelCreating(modelBuilder);
        }

        private void AuditEntities()
        {
            var now = DateTime.Now;

            foreach (var entity in ChangeTracker.Entries<IHasCreationTime>().Where(p => p.State == EntityState.Added).Select(p => p.Entity))
            {
                entity.CreationTime = now;
            }

            foreach (var entity in ChangeTracker.Entries<IHasCreatorId>().Where(p => p.State == EntityState.Added).Select(p => p.Entity))
            {
                entity.CreatorId = UserId;
            }

            foreach (var entity in ChangeTracker.Entries<IHasTenant>().Where(p => p.State == EntityState.Added).Select(p => p.Entity))
            {
                entity.TenantId = TenantId.Value;
            }

            foreach (var entity in ChangeTracker.Entries<IHasModificationTime>().Where(p => p.State == EntityState.Modified).Select(p => p.Entity))
            {
                entity.ModificationTime = now;
            }

            foreach (var entity in ChangeTracker.Entries<IHasModifierId>().Where(p => p.State == EntityState.Modified).Select(p => p.Entity))
            {
                entity.ModifierId = UserId;
            }

            foreach (var entity in ChangeTracker.Entries<IFullAudited>().Where(p => p.State == EntityState.Deleted).Select(p => p.Entity))
            {
                Entry(entity).State = EntityState.Modified;
                Entry(entity).CurrentValues.SetValues(Entry(entity).GetDatabaseValues());
                entity.IsDeleted = true;
                entity.DeletionTime = now;
                entity.DeleterId = UserId;
            }
        }
    }
}
