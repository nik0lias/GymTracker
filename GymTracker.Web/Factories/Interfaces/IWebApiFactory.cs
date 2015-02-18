using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymTracker.Web.Factories.Interfaces
{
    public interface IWebApiFactory<T>
    {
        Task<T> GetOne(int id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetMany();
    }
}
