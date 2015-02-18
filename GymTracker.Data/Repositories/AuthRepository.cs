using System;
using System.Threading.Tasks;
using GymTracker.Core.Entities;
using GymTracker.Core.Interfaces;
using GymTracker.Core.Models;
using GymTracker.Data.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GymTracker.Data.Repositories
{
    public class AuthRepository : IAuthRepository, IDisposable
    {
        private AuthContext _ctx;
        private UserManager<User> _userManager;

        public AuthRepository()
        {
            _ctx = new AuthContext();
            _userManager = new UserManager<User>(new UserStore<User>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            var user = new User
            {
                UserName = userModel.UserName,
                UserDetails = new UserDetails
                {
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName
                }
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            _userManager.Dispose();
        }
    }
}
