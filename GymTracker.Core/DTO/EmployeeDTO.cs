using System;
using System.Runtime.Serialization;
using GymTracker.Core.Interfaces;

namespace GymTracker.Core.DTO
{
    public class EmployeeDTO : IEmployee
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string EmployeeReference { get; set; }

        [DataMember]
        public string Forename { get; set; }

        [DataMember]
        public string HomePhone { get; set; }

        [DataMember]
        public string Middlename { get; set; }

        [DataMember]
        public string MobilePhone { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public DateTime? DateOfBirth { get; set; }

        [DataMember]
        public DateTime? EmploymentEndDate { get; set; }

        [DataMember]
        public DateTime? EmploymentStartDate { get; set; }

        [DataMember]
        public string NationalInsuranceNumber { get; set; }

        [DataMember]
        public string PlaceOfBirth { get; set; }
    }
}
