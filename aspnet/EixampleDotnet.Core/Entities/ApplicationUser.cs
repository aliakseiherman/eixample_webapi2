using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace EixampleDotnet.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Membership> Memberships { get; set; }
    }
}
