using System.Data.Entity;
using GymTracker.Core.Interfaces.Base;
using GymTracker.Data.Context;

namespace GymTracker.Data
{
   
    public class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        public DbContext _context;
 
        public EntityFrameworkUnitOfWork()
        {
            _context = new EmployeeContext();
        }

        internal DbSet<T> GetDbSet<T>()
          where T : class
        {
            return _context.Set<T>();
        }

        public void Commit()
        {
            // enter logging here if needed to map changes in the database
            _context.SaveChanges();
        }
    }
}
