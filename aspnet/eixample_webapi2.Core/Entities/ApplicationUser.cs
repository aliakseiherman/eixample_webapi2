using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace eixample_webapi2.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Membership> Memberships { get; set; }
    }
}
