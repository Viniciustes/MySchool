using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySchool.Domain.Entities;

namespace MySchool.Infrastructure.Mappings
{
    internal class CourseMappingConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course");

            builder.HasMany(x => x.CourseAssignments).WithOne(y => y.Course);

            builder.HasMany(x => x.Enrollments).WithOne(y => y.Course);

            builder.HasKey(x => x.Id);
        }
    }
}