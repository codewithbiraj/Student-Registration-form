using Form.Entities;
using System.Runtime.CompilerServices;

namespace Form.Repository.Interface
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task<Student> AddStudentsAsync(Student student);
        Task<Student?> GetStudentWithDetailsAsync(int id);
        Task SaveChangesAsync();

        Task<Student> DeleteStudentByIdAsync(int id);
        
    }
}
