using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymTracker.Web.Models.Signup
{
    public class RegisterModel
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
    }
}