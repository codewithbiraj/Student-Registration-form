using Form.Data;
using Form.Entities;
using Form.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Form.Repository.Implementation
{
    public class StudentRepository : IStudentRepository
    { 
    private readonly ApplicationDbContext _db;
        public StudentRepository(ApplicationDbContext db)
    {
        _db = db;

        }

        public async Task<Student> AddStudentsAsync(Student student)
        {
            await _db.Students.AddAsync(student);
            await _db.SaveChangesAsync();
            return student;
        }

        public async Task<Student> DeleteStudentByIdAsync(int id)
        {
            var student = await _db.Students.FindAsync(id);

            if (student == null)
                return null;

            _db.Students.Remove(student);
            await _db.SaveChangesAsync();

            return student;
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await _db.Students.ToListAsync();
        }

        public async Task<Student?> GetStudentWithDetailsAsync(int id)
        {
            return await _db.Students
        .Include(s => s.Address)
        .Include(s => s.Parentdetails)
        .Include(s => s.Academicdetail)
        .Include(s => s.Financialdetails)
        .Include(s => s.ExtraCurricular)
        .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }





       
        
       
        
    }
}
