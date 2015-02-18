using System;
using GymTracker.Core.Interfaces;

namespace GymTracker.Core.Entities
{
    public class Employee : IEmployee
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string EmployeeReference { get; set; }
        public string Forename { get; set; }
        public string HomePhone { get; set; }
        public string Middlename { get; set; }
        public string MobilePhone { get; set; }
        public string Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? EmploymentEndDate { get; set; }
        public DateTime? EmploymentStartDate { get; set; }
        public string NationalInsuranceNumber { get; set; }
        public string PlaceOfBirth { get; set; }
    }
}

