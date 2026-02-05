using Form.helper.enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Form.Entities
{
    [Table("Student")]
    public class Student
    {

        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string DateOfBirth { get; set; } = string.Empty;

        public string PlaceOfBirth { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;

        public string CitizenshipNumber { get; set; } = string.Empty;

        public string CitizenshipIssueDate { get; set; } = string.Empty;

        public string CitizenshipIssueDistrict { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string AlternateEmail { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string SecondaryPhoneNumber { get; set; } = string.Empty;

        public string EmergencyContactName { get; set; } = string.Empty;


        public string EmergencyContactRelation { get; set; } = string.Empty;

        public string EmergencyContactNumber { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;

        public string BloodGroup { get; set; } = string.Empty;

        public string MaritalStatus { get; set; } = string.Empty;

        public string Religion { get; set; } = string.Empty;

        public string Ethinicity { get; set; } = string.Empty;

        public string Disability { get; set; } = string.Empty;

        public Address Address { get; set; } = new Address();

        public Parentdetails Parentdetails { get; set; } = new Parentdetails();
        public Academicdetails Academicdetail { get; set; } = new Academicdetails();
       // public int? academicdetailId { get; set; }

        public Financialdetails Financialdetails { get; set; } = new Financialdetails();
        public ExtraCurricular ExtraCurricular { get; set; } = new ExtraCurricular();
    }


    public class Address
    {

        public int StudentId { get; set; }

        [Key]
        public int AddressId { get; set; }
        public Student Student { get; set; } = null!;

        public string Province { get; set; } = string.Empty;

        public string Municipality { get; set; } = string.Empty;

        public string WardNumber { get; set; } = string.Empty;

        public string Tole { get; set; } = string.Empty;

        public AddressType AddressType { get; set; }




    }


    public class Parentdetails
    {


        public int StudentId { get; set; }
        [Key]
        public int ParentdetailsId { get; set; }
        public Student Student { get; set; } = null!;

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
        [Key]
        public int AcademicId { get; set; }
        public int StudentId { get; set; }

        public string PreviousSchool { get; set; } = string.Empty;

        public string PreviousGrade { get; set; } = string.Empty;

        public string YearOfCompletion { get; set; } = string.Empty;

        public string Percentage { get; set; } = string.Empty;

        public ProgrameType programeType { get; set; }
        public SubjectType subjectType { get; set; }

        //filepaths

        public string PhotoPath { get; set; } = string.Empty;               
        public string SignaturePath { get; set; } = string.Empty;           
        public string CitizenshipCopyPath { get; set; } = string.Empty;     
        public string CharacterCertificatePath { get; set; } = string.Empty;



    }

    public class Financialdetails
    {
        public int StudentId { get; set; }
        [Key]
        public int FinancialdetailsId { get; set; }
        public Student Student { get; set; } = null!;

        public ScholarshipType scholarshipType { get; set; }
        public feeCategory feeCategory { get; set; }




    }
    public class ExtraCurricular
    {
        public int StudentId { get; set; }
        [Key]
        public int ExtraCurricularId { get; set; }
        public Student Student { get; set; } = null!;
        public Interest Interest { get; set; }
        public TimeSlot timeSlot { get; set; }
        public TransportationMethod transportationMethod { get; set; }


    }


}
