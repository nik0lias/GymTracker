using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GymTracker.Core.Interfaces;
using GymTracker.Core.Interfaces.Base;
using GymTracker.Data.Entities.Employee;

namespace GymTracker.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
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

        public IEnumerable<IEmployee> Query(Expression<Func<IEmployee, bool>> criteria)
        {
            return _unitOfWork.GetDbSet<Employee>().Where(criteria);
        }

        public IEmployee GetOne(int id)
        {
            return _unitOfWork.GetDbSet<Employee>().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<IEmployee> GetAll()
        {
            return _unitOfWork.GetDbSet<Employee>();
        }
    }
}
