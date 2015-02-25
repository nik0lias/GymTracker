using System;
using System.Runtime.Serialization;

namespace GymTracker.Core.Interfaces
{
    public interface IUser
    {
        [DataMember]
        int Id { get; set; }
        [DataMember]
        string Email { get; set; }
        [DataMember]
        string EmployeeReference { get; set; }
        [DataMember]
        string Forename { get; set; }
        [DataMember]
        string HomePhone { get; set; }
        [DataMember]
        string Middlename { get; set; }
        [DataMember]
        string MobilePhone { get; set; }
        [DataMember]
        string Surname { get; set; }
        [DataMember]
        DateTime? DateOfBirth { get; set; }
        [DataMember]
        DateTime? EmploymentEndDate { get; set; }
        [DataMember]
        DateTime? EmploymentStartDate { get; set; }
        [DataMember]
        string NationalInsuranceNumber { get; set; }
        [DataMember]
        string PlaceOfBirth { get; set; }
    }
}
