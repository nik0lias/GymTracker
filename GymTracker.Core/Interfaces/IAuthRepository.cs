using System.Threading.Tasks;
using GymTracker.Core.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GymTracker.Core.Interfaces
{
    public interface IAuthRepository 
       // : IRepository<UserModel>
    {
        Task<IdentityResult> RegisterUser(UserModel userModel);
        Task<IdentityUser> FindUser(string userName, string password);
    }
}
