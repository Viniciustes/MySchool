using Microsoft.EntityFrameworkCore;
using MySchool.Domain.Entities;

namespace MySchool.Infrastructure.Contexts
{
    public class MySchoolContext : DbContext
    {
        public MySchoolContext(DbContextOptions<MySchoolContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }

        public DbSet<CourseAssignment> CourseAssignments { get; set; }

        public DbSet<Instructor> Instructors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<OfficeAssignment>().ToTable("OfficeAssignment");
            modelBuilder.Entity<CourseAssignment>().ToTable("CourseAssignment");
            modelBuilder.Entity<Instructor>().ToTable("Instructor");
        }
    }
}