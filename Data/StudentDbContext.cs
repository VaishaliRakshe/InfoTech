using InfoTech.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoTech.Data
{
    public class StudentDbContext
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }

        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(j => new { j.StudentId, j.CourseId });
        }
    }
}
