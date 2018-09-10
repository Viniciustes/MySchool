using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySchool.Domain.Entities;

namespace MySchool.Infrastructure.Mappings
{
    internal class DepartmentMappingConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");

            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Courses).WithOne(y => y.Department);

            builder.Property(x => x.Name)
              .IsRequired()
              .HasMaxLength(30);

            builder.Property(x => x.StartDate)
                .IsRequired()
                .HasColumnType("Date");

            builder.Property(x => x.Budget)
               .HasColumnType("money");

            builder.Property(x => x.RowVersion)
                .IsConcurrencyToken();
        }
    }
}