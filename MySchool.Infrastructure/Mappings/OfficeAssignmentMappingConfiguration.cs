using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySchool.Domain.Entities;
using System;

namespace MySchool.Infrastructure.Mappings
{
    class OfficeAssignmentMappingConfiguration : IEntityTypeConfiguration<OfficeAssignment>
    {
        public void Configure(EntityTypeBuilder<OfficeAssignment> builder)
        {
            builder.ToTable("OfficeAssignment");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Location)
              .HasColumnType("varchar")
              .HasMaxLength(30);
        }
    }
}
