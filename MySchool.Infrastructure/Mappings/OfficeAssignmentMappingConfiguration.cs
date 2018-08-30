using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySchool.Domain.Entities;

namespace MySchool.Infrastructure.Mappings
{
    class OfficeAssignmentMappingConfiguration : IEntityTypeConfiguration<OfficeAssignment>
    {
        public void Configure(EntityTypeBuilder<OfficeAssignment> builder)
        {
            builder.ToTable("OfficeAssignment");

            builder.HasKey(x => x.InstructorId);

            builder.Property(x => x.Location)
              .HasMaxLength(30);
        }
    }
}