using Form.Dto;
using Form.Entities;

namespace Form.Service.Interface
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetStudentsAsync();
        Task<StudentDto> AddStudentAsync(StudentDto StudentDto);
        Task<StudentDto> UpdateStudentsByIdAsync(int id, StudentDto StudentDto);
        Task<bool> DeleteStudentByIdAsync(int id);
    }
}
