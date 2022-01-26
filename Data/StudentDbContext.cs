using InfoTech.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InfoTech.Data
{
    public class StudentDbContext: IdentityDbContext<IdentityUser>
    {
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Teacher> Teachers { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<StudentCourse> StudentCourses { get; set; } = null!;

        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(j => new { j.StudentId, j.CourseId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
