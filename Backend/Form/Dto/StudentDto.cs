using Form.helper.enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Form.Dto
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string DateOfBirth { get; set; } = string.Empty;
        public string PlaceOfBirth { get; set; } = string.Empty;

        public string Nationality { get; set; } = string.Empty;

        public string CitizenshipNumber { get; set; } = string.Empty;
        public string CitizenshipIssueDate { get; set; } = string.Empty;
        [JsonPropertyName("citizenshipIssueDistrict")]
        public string CitizenshipIssueDistrict { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        [JsonPropertyName("alternativeEmail")]
        public string AlternateEmail { get; set; } = string.Empty;
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; } = string.Empty;
        public string SecondaryPhoneNumber { get; set; } = string.Empty;
        [JsonPropertyName("emergencyContactName")]
        public string EmergencyContactName { get; set; } = string.Empty;
        [JsonPropertyName("emergencyContactRelation")]
        public string EmergencyContactRelation { get; set; } = string.Empty;
        [JsonPropertyName("emergencyContactNumber")]
        public string EmergencyContactNumber { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;
        public string BloodGroup { get; set; } = string.Empty;
        public string MaritalStatus { get; set; } = string.Empty;

        public string Religion { get; set; } = string.Empty;
        public string Ethnicity { get; set; } = string.Empty;
        public string Disability { get; set; } = string.Empty;
        [JsonPropertyName("address")]
        public Address Address { get; set; } = new();
        [JsonPropertyName("parentdetails")]
        public Parentdetails Parentdetails { get; set; } = new();
        [JsonPropertyName("academicdetails")]
        public Academicdetails Academicdetails { get; set; } = new();
        [JsonPropertyName("financialdetails")]
        public Financialdetails Financialdetails { get; set; } = new();
        [JsonPropertyName("extraCurricular")]
        public ExtraCurricular ExtraCurricular { get; set; } = new();

    }
    public class Address
    {

        

        public string Province { get; set; } = string.Empty;

        public string Municipality { get; set; } = string.Empty;

        public string WardNumber { get; set; } = string.Empty;

        public string Tole { get; set; } = string.Empty;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AddressType AddressType { get; set; }

        



    }
    public class Parentdetails
    {

        public string FatherName { get; set; } = string.Empty;
        public string FatherOccupation { get; set; } = string.Empty;
        public string FatherPhoneNumber { get; set; } = string.Empty;
        public string MotherName { get; set; } = string.Empty;
        public string MotherOccupation { get; set; } = string.Empty;
        public string MotherPhoneNumber { get; set; } = string.Empty;
        public string GuardianName { get; set; } = string.Empty;
        public string GuardianOccupation { get; set; } = string.Empty;
        public string GuardianPhoneNumber { get; set; } = string.Empty;


    }

    public class Academicdetails
    {
        public string PreviousSchool { get; set; } = string.Empty;

        public string PreviousGrade { get; set; } = string.Empty;

        public string YearOfCompletion { get; set; } = string.Empty;

        public string Percentage { get; set; } = string.Empty;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ProgrameType programeType { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SubjectType subjectType { get; set; }

        // 📤 File uploads
        public IFormFile? Photo { get; set; }
        public IFormFile? Signature { get; set; }
        public IFormFile? CitizenshipCopy { get; set; }
        public IFormFile? CharacterCertificate { get; set; }

    }

    public class Financialdetails
    {
        public string SchoolarshipDetails { get; set; } = string.Empty;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ScholarshipType scholarshipType { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public feeCategory feeCategory { get; set; }




    }
    public class ExtraCurricular
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Interest Interest { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TimeSlot timeSlot { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TransportationMethod transportationMethod { get; set; }


    }


}
