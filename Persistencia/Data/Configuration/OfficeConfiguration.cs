using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.ToTable("Office"); 

            builder.HasKey(o => o.Id);

            builder.Property(o => o.City)
                .HasColumnName("City")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(o => o.Country)
                .HasColumnName("Country")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(o => o.Region)
                .HasColumnName("Region")
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder.Property(o => o.PostalCode)
                .HasColumnName("PostalCode")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(o => o.Phone)
                .HasColumnName("Phone")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(o => o.AddressLine1)
                .HasColumnName("AddressLine1")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(o => o.AddressLine2)
                .HasColumnName("AddressLine2")
                .HasColumnType("varchar")
                .HasMaxLength(255);
                
        }
    }
}