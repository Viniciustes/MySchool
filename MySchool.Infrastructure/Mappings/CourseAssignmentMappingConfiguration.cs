using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySchool.Domain.Entities;

namespace MySchool.Infrastructure.Mappings
{
    class CourseAssignmentMappingConfiguration : IEntityTypeConfiguration<CourseAssignment>
    {
        public void Configure(EntityTypeBuilder<CourseAssignment> builder)
        {
            builder.ToTable("CourseAssignment");

            builder.HasKey(x => new { x.CourseId, x.InstructorId });
        }
    }
}
