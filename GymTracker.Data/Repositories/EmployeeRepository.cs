using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GymTracker.Core.Interfaces;
using GymTracker.Core.Interfaces.Base;
using GymTracker.Data.Entities.Employee;

namespace GymTracker.Data.Repositories
{
    public class EmployeeRepository : IUserRepository
    {
        EntityFrameworkUnitOfWork _unitOfWork;

        public EmployeeRepository(IUnitOfWork unitOfWork)
        {
            var entityFrameworkUnitOfWork = unitOfWork as EntityFrameworkUnitOfWork;

            if (entityFrameworkUnitOfWork == null)
            {
                throw new ArgumentOutOfRangeException("Must be of type EntityFrameworkUnitOfWork");
            }

            _unitOfWork = entityFrameworkUnitOfWork;
        }

        public IEnumerable<IUser> Query(Expression<Func<IUser, bool>> criteria)
        {
            return _unitOfWork.GetDbSet<Employee>().Where(criteria);
        }

        public IUser GetOne(int id)
        {
            return _unitOfWork.GetDbSet<Employee>().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<IUser> GetAll()
        {
            return _unitOfWork.GetDbSet<Employee>();
        }
    }
}
