using EixampleDotnet.Dto;
using EixampleDotnet.Entities;
using EixampleDotnet.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EixampleDotnet.Application
{
    public class UserService : IUserService
    {
        private AppDbContext _dbContext;
        private UserManager<ApplicationUser> _userManager;
        private IMembershipService _membershipService;

        public UserService(
            AppDbContext dbContext,
            UserManager<ApplicationUser> userManager,
            IMembershipService membershipService
            )
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _membershipService = membershipService;
        }

        public async Task<ApplicationUser> Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            var user = _dbContext.Users.SingleOrDefault(x => x.UserName == username);

            if (user == null)
            {
                throw new Exception("No such user.");
            }

            if (!_membershipService.IsMember(user.Id))
            {
                throw new Exception("Not a member of current tenant. Registration required.");
            }

            bool correctPassword = await _userManager.CheckPasswordAsync(user, password);

            if (!correctPassword)
            {
                throw new Exception("Incorrect password.");
            }

            return user;
        }

        public async Task<ApplicationUser> Create(CreateUserInput input)
        {
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new AppDbContext()));

            var user = await _userManager.FindByEmailAsync(input.Email);

            if (user == null)
            {
                user = new ApplicationUser()
                {
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    UserName = input.UserName,
                    Email = input.Email
                };

                var identityResult = _userManager.CreateAsync(user, input.Password);

                if (identityResult.Result.Succeeded)
                {
                    user = await _userManager.FindByNameAsync(input.UserName);
                    _membershipService.CreateMembership(user);
                }
                else
                {
                    throw new Exception($"{string.Join("\n", identityResult.Result.Errors.Select(x => x))}");
                }
            }
            else
            {
                bool correctPassword = await _userManager.CheckPasswordAsync(user, input.Password);

                if (correctPassword)
                {
                    _membershipService.CreateMembership(user);
                }
            }

            return user;
        }
    }
}
