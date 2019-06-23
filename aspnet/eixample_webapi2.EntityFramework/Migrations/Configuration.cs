namespace eixample_webapi2.EntityFramework.Migrations
{
    using eixample_webapi2.Consts;
    using eixample_webapi2.Entities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<eixample_webapi2.EntityFramework.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(eixample_webapi2.EntityFramework.AppDbContext context)
        {
            CreateTenants(context);
            CreateUsers(context);
            CreateMemberships(context);
        }

        private void CreateTenants(AppDbContext context)
        {
            CreateTenant(SetupConsts.Tenants.GaleriaSenda.Name, SetupConsts.Tenants.GaleriaSenda.HostName, context);
            CreateTenant(SetupConsts.Tenants.Restaura.Name, SetupConsts.Tenants.Restaura.HostName, context);
        }

        private void CreateTenant(string name, string hostName, AppDbContext context)
        {
            Tenant tenant = context.Tenants.FirstOrDefault(x => x.HostName.Equals(hostName));

            if (tenant == null)
            {
                context.Tenants.Add(new Tenant() { Name = name, HostName = hostName });
                context.SaveChanges();
            }
        }

        private void CreateUsers(AppDbContext context)
        {
            var store = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(store);
            var passwordHasher = new PasswordHasher();

            ApplicationUser hostAdminUser = context.Users.FirstOrDefault(x => x.UserName.Equals(SetupConsts.Users.AdminJoe.UserName));

            if (hostAdminUser == null)
            {
                hostAdminUser = new ApplicationUser()
                {
                    FirstName = SetupConsts.Users.AdminJoe.FirstName,
                    LastName = SetupConsts.Users.AdminJoe.LastName,
                    UserName = SetupConsts.Users.AdminJoe.UserName,
                    Email = SetupConsts.Users.AdminJoe.Email,
                    EmailConfirmed = true,
                    PasswordHash = passwordHasher.HashPassword(SetupConsts.Users.Passwords.Default)
                };

                userManager.Create(hostAdminUser);
            }

            ApplicationUser secondaryUser = context.Users.FirstOrDefault(x => x.UserName.Equals(SetupConsts.Users.JohnRoe.UserName));

            if (secondaryUser == null)
            {
                secondaryUser = new ApplicationUser()
                {
                    FirstName = SetupConsts.Users.JohnRoe.FirstName,
                    LastName = SetupConsts.Users.JohnRoe.LastName,
                    UserName = SetupConsts.Users.JohnRoe.UserName,
                    Email = SetupConsts.Users.JohnRoe.Email,
                    EmailConfirmed = true,
                    PasswordHash = passwordHasher.HashPassword(SetupConsts.Users.Passwords.Default)
                };

                userManager.Create(secondaryUser);
            }
        }

        private void CreateMemberships(AppDbContext context)
        {
            var store = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(store);

            var hostAdminUser = userManager.FindByName(SetupConsts.Users.AdminJoe.UserName);

            var tenants = context.Tenants.ToList();

            foreach (var tenant in tenants)
            {
                if (!context.Memberships.Any(x => x.TenantId == tenant.Id && x.UserId == hostAdminUser.Id))
                {
                    context.Memberships.Add(new Membership() { TenantId = tenant.Id, UserId = hostAdminUser.Id });
                }

                context.SaveChanges();
            }

            // restricting John Roe from logging in to tenants other than 'galeriasenda'
            var johnRoe = userManager.FindByName(SetupConsts.Users.JohnRoe.UserName);
            var firstTenant = context.Tenants.Single(x => x.HostName == SetupConsts.Tenants.GaleriaSenda.HostName);

            if (!context.Memberships.Any(x => x.TenantId == firstTenant.Id && x.UserId == johnRoe.Id))
            {
                context.Memberships.Add(new Membership() { TenantId = firstTenant.Id, UserId = johnRoe.Id });
            }

            context.SaveChanges();
        }
    }
}
