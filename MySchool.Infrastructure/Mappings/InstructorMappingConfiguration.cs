using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySchool.Domain.Entities;

namespace MySchool.Infrastructure.Mappings
{
    class InstructorMappingConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.ToTable("Instructor");

            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.CourseAssignments).WithOne(y => y.Instructor);

            builder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(30);

            builder.Property(x => x.LastName)
               .IsRequired()
               .HasMaxLength(30);

            builder.Property(x => x.HireDate)
              .IsRequired()
              .HasColumnType("Date");
        }
    }
}