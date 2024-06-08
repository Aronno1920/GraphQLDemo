using GraphQLDemo.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.API.ApplicationContext
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options):base(options) { }

        public DbSet<CourseDTO> Courses { get; set; }
        public DbSet<InstructorDTO> Instructors { get; set; }
        public DbSet<StudentDTO> Students { get; set; }
    }
}
