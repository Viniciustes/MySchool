using Microsoft.EntityFrameworkCore;
using MySchool.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MySchool.Infrastructure.Mappings
{
    internal class StudentMappingConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");

            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Enrollments).WithOne(s => s.Student);

            builder.Property(x => x.FirstName)
               .IsRequired()
               .HasMaxLength(30);

            builder.Property(x => x.LastName)
               .IsRequired()
               .HasMaxLength(30);

            builder.Property(x => x.EnrollmentDate)
                .IsRequired()
                .HasColumnType("Date");
        }
    }
}