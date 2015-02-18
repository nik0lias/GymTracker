using System.Data.Entity;
using GymTracker.Core.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GymTracker.Data.Context
{
    public class AuthContext : IdentityDbContext<User>
    {
        public AuthContext()
            : base("EmployeePortalEntities", false)
        {

        }

        public DbSet<UserDetails> UserDetails { get; set; }
    }

}
