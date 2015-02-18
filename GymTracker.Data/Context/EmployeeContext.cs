using System.Data.Entity;
using GymTracker.Data.Entities.Employee;

namespace GymTracker.Data.Context
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
            : base("name=EmployeePortalEntities")
        {
        }

        public virtual DbSet<UserDetail> UserDetails { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
    }
}
