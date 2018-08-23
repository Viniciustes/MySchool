using Microsoft.EntityFrameworkCore;
using MySchool.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MySchool.Infrastructure.Mappings
{
    class StudentMappingConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
               .IsRequired()
               .HasColumnType("varchar")
               .HasMaxLength(30);

            builder.Property(x => x.LastName)
               .IsRequired()
               .HasColumnType("varchar")
               .HasMaxLength(30);

            builder.Property(x => x.EnrollmentDate)
                .IsRequired()
                .HasColumnType("Date");
        }
    }
}
