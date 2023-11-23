using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.ToTable("ProductType");

            builder.HasKey(pt => pt.Id);

            builder.Property(pt => pt.DescriptionText)
                .HasColumnName("DescriptionText")
                .HasColumnType("varchar")
                .HasMaxLength(255);

            builder.Property(pt => pt.DescriptionHtml)
                .HasColumnName("DescriptionHtml")
                .HasColumnType("varchar")
                .HasMaxLength(1000);

            builder.Property(pt => pt.Image)
                .HasColumnName("Image")
                .HasColumnType("varchar")
                .HasMaxLength(255);

        }
    }
}