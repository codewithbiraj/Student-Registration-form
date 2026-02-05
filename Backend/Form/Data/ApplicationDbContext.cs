using Form.Entities;
using Microsoft.EntityFrameworkCore;

namespace Form.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DbSet<Parentdetails> Parentdetails { get; set; }
         public DbSet<Financialdetails> Financialdetails { get; set; }
        public DbSet<Academicdetails> Academicdetails { get; set; }
        public DbSet<ExtraCurricular> ExtraCurricular { get; set; }
    }
}
