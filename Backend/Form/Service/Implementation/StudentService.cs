using Form.Dto;
using Form.Entities;
using Form.helper.upload;
using Form.Repository.Implementation;
using Form.Repository.Interface;
using Form.Service.Interface;
using Parentdetails = Form.Dto.Parentdetails;

namespace Form.Service.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly Uploadhelper _uploadhelper;
        public StudentService(IStudentRepository studentRepository, Uploadhelper uploadhelper)
        {
            _studentRepository = studentRepository;
            _uploadhelper = uploadhelper;

        }

        public async Task<StudentDto> AddStudentAsync(StudentDto StudentDto)
        {
            var student = new Student
            {
                FirstName = StudentDto.FirstName,
                LastName = StudentDto.LastName,
                DateOfBirth = StudentDto.DateOfBirth,
                PlaceOfBirth = StudentDto.PlaceOfBirth,
                Nationality = StudentDto.Nationality,
                CitizenshipNumber = StudentDto.CitizenshipNumber,
                CitizenshipIssueDate = StudentDto.CitizenshipIssueDate,
                CitizenshipIssueDistrict = StudentDto.CitizenshipIssueDistrict,
                Email = StudentDto.Email,
                AlternateEmail = StudentDto.AlternateEmail,
                PhoneNumber = StudentDto.PhoneNumber,
                SecondaryPhoneNumber = StudentDto.SecondaryPhoneNumber,
                EmergencyContactName = StudentDto.EmergencyContactName,
                EmergencyContactRelation = StudentDto.EmergencyContactRelation,
                EmergencyContactNumber = StudentDto.EmergencyContactNumber,
                Gender = StudentDto.Gender,
                BloodGroup = StudentDto.BloodGroup,
                MaritalStatus = StudentDto.MaritalStatus,
                Religion = StudentDto.Religion,
                Ethinicity = StudentDto.Ethnicity,
                Disability = StudentDto.Disability,
                Address = new Form.Entities.Address
                {
                    Province = StudentDto.Address.Province,
                    Municipality = StudentDto.Address.Municipality,
                    WardNumber = StudentDto.Address.WardNumber,
                    Tole = StudentDto.Address.Tole,
                    AddressType = StudentDto.Address.AddressType

                },
                Parentdetails = new Form.Entities.Parentdetails
                {
                    FatherName = StudentDto.Parentdetails.FatherName,
                    MotherName = StudentDto.Parentdetails.MotherName,
                    GuardianName = StudentDto.Parentdetails.GuardianName,
                    FatherOccupation = StudentDto.Parentdetails.FatherOccupation,
                    MotherOccupation = StudentDto.Parentdetails.MotherOccupation,
                    GuardianOccupation = StudentDto.Parentdetails.GuardianOccupation,
                    FatherPhoneNumber = StudentDto.Parentdetails.FatherPhoneNumber,
                    MotherPhoneNumber = StudentDto.Parentdetails.MotherPhoneNumber,
                    GuardianPhoneNumber = StudentDto.Parentdetails.GuardianPhoneNumber

                },
                Academicdetail = new Form.Entities.Academicdetails
                {
                    PreviousSchool = StudentDto.Academicdetails.PreviousSchool,
                    PreviousGrade = StudentDto.Academicdetails.PreviousGrade,
                    YearOfCompletion = StudentDto.Academicdetails.YearOfCompletion,
                    Percentage = StudentDto.Academicdetails.Percentage,
                    programeType = StudentDto.Academicdetails.programeType,
                    subjectType = StudentDto.Academicdetails.subjectType,


                    PhotoPath = StudentDto.Academicdetails.Photo != null
        ? await _uploadhelper.SaveFileAsync(
            StudentDto.Academicdetails.Photo,
            "academic/photos",
            2 * 1024 * 1024,
            new[] { ".jpg", ".png", ".jpeg" })
        : "",

                    SignaturePath = StudentDto.Academicdetails.Signature != null
        ? await _uploadhelper.SaveFileAsync(
            StudentDto.Academicdetails.Signature,
            "academic/signatures",
            1 * 1024 * 1024,
            new[] { ".jpg", ".png", ".jpeg" })
        : "",

                    CitizenshipCopyPath = StudentDto.Academicdetails.CitizenshipCopy != null
        ? await _uploadhelper.SaveFileAsync(
            StudentDto.Academicdetails.CitizenshipCopy,
            "academic/citizenship",
            5 * 1024 * 1024,
            new[] { ".jpg", ".pdf", ".jpeg" })
        : "",

                    CharacterCertificatePath = StudentDto.Academicdetails.CharacterCertificate != null
        ? await _uploadhelper.SaveFileAsync(
            StudentDto.Academicdetails.CharacterCertificate,
            "academic/character",
            2 * 1024 * 1024,
            new[] { ".pdf", ".jpeg" })
        : ""
                },
                Financialdetails = new Form.Entities.Financialdetails
                {
                    scholarshipType = StudentDto.Financialdetails.scholarshipType,
                    feeCategory = StudentDto.Financialdetails.feeCategory
                },
                ExtraCurricular = new Form.Entities.ExtraCurricular
                {
                    Interest = StudentDto.ExtraCurricular.Interest,
                    timeSlot = StudentDto.ExtraCurricular.timeSlot,
                    transportationMethod = StudentDto.ExtraCurricular.transportationMethod
                }



            };

            await _studentRepository.AddStudentsAsync(student);

            return StudentDto;

        }

        public async Task<bool> DeleteStudentByIdAsync(int id)
        {
            var student = await _studentRepository.DeleteStudentByIdAsync(id);
            return student != null;


        }

        public async Task<IEnumerable<StudentDto>> GetStudentsAsync()
        {
            var students = await _studentRepository.GetStudentsAsync();

            return students.Select(s => new StudentDto
            {

                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                DateOfBirth = s.DateOfBirth,
                PlaceOfBirth = s.PlaceOfBirth,
                Nationality = s.Nationality,
                CitizenshipNumber = s.CitizenshipNumber,
                CitizenshipIssueDate = s.CitizenshipIssueDate,
                CitizenshipIssueDistrict = s.CitizenshipIssueDistrict,
                Email = s.Email,
                AlternateEmail = s.AlternateEmail,
                PhoneNumber = s.PhoneNumber,
                SecondaryPhoneNumber = s.SecondaryPhoneNumber,
                EmergencyContactName = s.EmergencyContactName,
                EmergencyContactRelation = s.EmergencyContactRelation,
                EmergencyContactNumber = s.EmergencyContactNumber,
                Gender = s.Gender,
                BloodGroup = s.BloodGroup,
                MaritalStatus = s.MaritalStatus,
                Religion = s.Religion,
                Ethnicity = s.Ethinicity,
                Disability = s.Disability,
                Address = new Form.Dto.Address
                {
                    Province = s.Address.Province,
                    Municipality = s.Address.Municipality,
                    WardNumber = s.Address.WardNumber,
                    Tole = s.Address.Tole,
                    AddressType = s.Address.AddressType

                },
                Parentdetails = new Form.Dto.Parentdetails
                {
                    FatherName = s.Parentdetails.FatherName,
                    MotherName = s.Parentdetails.MotherName,
                    GuardianName = s.Parentdetails.GuardianName,
                    FatherOccupation = s.Parentdetails.FatherOccupation,
                    MotherOccupation = s.Parentdetails.MotherOccupation,
                    GuardianOccupation = s.Parentdetails.GuardianOccupation,
                    FatherPhoneNumber = s.Parentdetails.FatherPhoneNumber,
                    MotherPhoneNumber = s.Parentdetails.MotherPhoneNumber,
                    GuardianPhoneNumber = s.Parentdetails.GuardianPhoneNumber
                },
                Academicdetails = new Form.Dto.Academicdetails
                {
                    PreviousSchool = s.Academicdetail.PreviousSchool,
                    PreviousGrade = s.Academicdetail.PreviousGrade,
                    YearOfCompletion = s.Academicdetail.YearOfCompletion,
                    Percentage = s.Academicdetail.Percentage,
                    programeType = s.Academicdetail.programeType,
                    subjectType = s.Academicdetail.subjectType
                },
                Financialdetails = new Form.Dto.Financialdetails
                {
                    scholarshipType = s.Financialdetails.scholarshipType,
                    feeCategory = s.Financialdetails.feeCategory
                },
                ExtraCurricular = new Form.Dto.ExtraCurricular
                {
                    Interest = s.ExtraCurricular.Interest,
                    timeSlot = s.ExtraCurricular.timeSlot,
                    transportationMethod = s.ExtraCurricular.transportationMethod
                }

            });
        }



        public async Task<StudentDto> UpdateStudentsByIdAsync(int id, StudentDto StudentDto)
        {
            var existingStudent = await _studentRepository.GetStudentWithDetailsAsync(id);

            if (existingStudent == null)
                throw new Exception("Student not found");

            // ================= BASIC DETAILS =================
            existingStudent.FirstName = StudentDto.FirstName;
            existingStudent.LastName = StudentDto.LastName;
            existingStudent.DateOfBirth = StudentDto.DateOfBirth;
            existingStudent.PlaceOfBirth = StudentDto.PlaceOfBirth;
            existingStudent.Nationality = StudentDto.Nationality;
            existingStudent.CitizenshipNumber = StudentDto.CitizenshipNumber;
            existingStudent.CitizenshipIssueDate = StudentDto.CitizenshipIssueDate;
            existingStudent.CitizenshipIssueDistrict = StudentDto.CitizenshipIssueDistrict;
            existingStudent.Email = StudentDto.Email;
            existingStudent.AlternateEmail = StudentDto.AlternateEmail;
            existingStudent.PhoneNumber = StudentDto.PhoneNumber;
            existingStudent.SecondaryPhoneNumber = StudentDto.SecondaryPhoneNumber;
            existingStudent.Gender = StudentDto.Gender;
            existingStudent.BloodGroup = StudentDto.BloodGroup;
            existingStudent.MaritalStatus = StudentDto.MaritalStatus;
            existingStudent.Religion = StudentDto.Religion;
            existingStudent.Ethinicity = StudentDto.Ethnicity;
            existingStudent.Disability = StudentDto.Disability;

            // ================= ADDRESS =================
            existingStudent.Address.Province = StudentDto.Address.Province;
            existingStudent.Address.Municipality = StudentDto.Address.Municipality;
            existingStudent.Address.WardNumber = StudentDto.Address.WardNumber;
            existingStudent.Address.Tole = StudentDto.Address.Tole;
            existingStudent.Address.AddressType = StudentDto.Address.AddressType;

            // ================= ACADEMIC =================
            existingStudent.Academicdetail.PreviousSchool = StudentDto.Academicdetails.PreviousSchool;
            existingStudent.Academicdetail.PreviousGrade = StudentDto.Academicdetails.PreviousGrade;
            existingStudent.Academicdetail.YearOfCompletion = StudentDto.Academicdetails.YearOfCompletion;
            existingStudent.Academicdetail.Percentage = StudentDto.Academicdetails.Percentage;
            existingStudent.Academicdetail.programeType = StudentDto.Academicdetails.programeType;
            existingStudent.Academicdetail.subjectType = StudentDto.Academicdetails.subjectType;

            // ================= FILE UPDATES =================
            if (StudentDto.Academicdetails.Photo != null)
                existingStudent.Academicdetail.PhotoPath =
                    await _uploadhelper.SaveFileAsync(StudentDto.Academicdetails.Photo,
                        "academic/photos", 2 * 1024 * 1024, new[] { ".jpg", ".png", ".jpeg" });

            if (StudentDto.Academicdetails.Signature != null)
                existingStudent.Academicdetail.SignaturePath =
                    await _uploadhelper.SaveFileAsync(StudentDto.Academicdetails.Signature,
                        "academic/signatures", 1 * 1024 * 1024, new[] { ".jpg", ".png", ".jpeg" });

            if (StudentDto.Academicdetails.CitizenshipCopy != null)
                existingStudent.Academicdetail.CitizenshipCopyPath =
                    await _uploadhelper.SaveFileAsync(StudentDto.Academicdetails.CitizenshipCopy,
                        "academic/citizenship", 5 * 1024 * 1024, new[] { ".jpg", ".pdf", ".jpeg" });

            if (StudentDto.Academicdetails.CharacterCertificate != null)
                existingStudent.Academicdetail.CharacterCertificatePath =
                    await _uploadhelper.SaveFileAsync(StudentDto.Academicdetails.CharacterCertificate,
                        "academic/character", 2 * 1024 * 1024, new[] { ".pdf", ".jpeg" });

            // ================= SAVE =================
            await _studentRepository.SaveChangesAsync();

            return StudentDto;
        }
    }
        }
