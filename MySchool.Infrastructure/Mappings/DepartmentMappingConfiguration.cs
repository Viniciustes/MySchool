using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySchool.Domain.Entities;

namespace MySchool.Infrastructure.Mappings
{
    class DepartmentMappingConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
              .IsRequired()
              .HasColumnType("varchar")
              .HasMaxLength(30);

            builder.Property(x => x.StartDate)
                .IsRequired()
                .HasColumnType("Date");

            builder.Property(x => x.Budget)
               .IsRequired()
               .HasColumnType("money");
        }
    }
}
