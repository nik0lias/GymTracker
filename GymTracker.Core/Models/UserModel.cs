using Microsoft.AspNet.Identity.EntityFramework;

namespace GymTracker.Core.Models
{
    public class UserModel : IdentityUser
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string Name 
        { 
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            } 
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
