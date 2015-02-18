using Microsoft.AspNet.Identity.EntityFramework;

namespace GymTracker.Core.Entities
{
    public class User : IdentityUser
    {
        public virtual UserDetails UserDetails { get; set; }
    }
}
