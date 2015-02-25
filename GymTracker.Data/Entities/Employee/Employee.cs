using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GymTracker.Core.Interfaces;

namespace GymTracker.Data.Entities.Employee
{
    [Table("HR.Employee")]
    public partial class Employee : IUser
    {
        public int Id { get; set; }

        public string Email { get; set; }

        [Required]
        public string EmployeeReference { get; set; }

        [Required]
        public string Forename { get; set; }

        public string HomePhone { get; set; }

        public string Middlename { get; set; }

        public string MobilePhone { get; set; }

        [Required]
        public string Surname { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateOfBirth { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? EmploymentEndDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? EmploymentStartDate { get; set; }

        public string NationalInsuranceNumber { get; set; }

        public string PlaceOfBirth { get; set; }
    }
}
