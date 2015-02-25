using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymTracker.Web.Factories.Interfaces.Base
{
    /// <summary>
    /// Interface responsible for basic webapi functions, any additonal to be placed in other
    /// interfaces needed by the relevant services.
    /// </summary>
    /// <typeparam name="T">Return and create type for this API</typeparam>
    public interface IWebApiFactory<T> : IDisposable
    {
        Task<T> GetOne(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> CreateOne();
        Task<IEnumerable<T>> GetMany(Func<T, bool> func);
    }
}
