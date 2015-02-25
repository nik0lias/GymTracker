using System;

namespace GymTracker.Web.Models
{
    public class UserDetailsModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Forename { get; set; }
        public string HomePhone { get; set; }
        public string Middlename { get; set; }
        public string MobilePhone { get; set; }
        public string Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}