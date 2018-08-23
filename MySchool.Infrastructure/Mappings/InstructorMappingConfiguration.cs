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

            builder.Property(x => x.FirstName)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(30);

            builder.Property(x => x.LastName)
               .IsRequired()
               .HasColumnType("varchar")
               .HasMaxLength(30);

            builder.Property(x => x.HireDate)
              .IsRequired()
              .HasColumnType("Date");
        }
    }
}
