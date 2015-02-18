using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GymTracker.Core.Interfaces.Base;

namespace GymTracker.Core.Interfaces
{
    public interface IEmployeeRepository 
        : IRepository<IEmployee>
    {
        IEmployee GetOne(int id);
        IEnumerable<IEmployee> GetAll();
        IEnumerable<IEmployee> Query(Expression<Func<IEmployee, bool>> criteria);
    }
}
