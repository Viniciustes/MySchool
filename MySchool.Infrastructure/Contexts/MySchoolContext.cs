using Microsoft.EntityFrameworkCore;
using MySchool.Domain.Entities;
using MySchool.Infrastructure.Mappings;

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

        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Para utilizar configuração em linha, usar conforme comentado abaixo:
            // modelBuilder.Entity<Course>().ToTable("Course");

            // Utilização por classe de configuração
            modelBuilder.ApplyConfiguration(new StudentMappingConfiguration());
            modelBuilder.ApplyConfiguration(new CourseMappingConfiguration());
            modelBuilder.ApplyConfiguration(new EnrollmentMappingConfiguration());
            modelBuilder.ApplyConfiguration(new OfficeAssignmentMappingConfiguration());
            modelBuilder.ApplyConfiguration(new CourseAssignmentMappingConfiguration());
            modelBuilder.ApplyConfiguration(new InstructorMappingConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentMappingConfiguration());
        }
    }
}