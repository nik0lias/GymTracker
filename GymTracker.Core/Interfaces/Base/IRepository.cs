using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GymTracker.Core.Interfaces.Base
{
    public interface IRepository<I>
    {
        I GetOne(int id);
        IEnumerable<I> GetAll();
        IEnumerable<I> Query(Expression<Func<IUser, bool>> criteria);
    }
}
