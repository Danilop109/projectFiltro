using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product"); 

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(255);
                
            builder.HasOne(p => p.ProductType)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.IdProductTypeFk);

            builder.Property(p => p.Dimensions)
                .HasColumnName("Dimensions")
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder.Property(p => p.Supplier)
                .HasColumnName("Supplier")
                .HasColumnType("varchar")
                .HasMaxLength(255);

            builder.Property(p => p.Description)
                .HasColumnName("Description")
                .HasColumnType("varchar")
                .HasMaxLength(500);

            builder.Property(p => p.QuantityStock)
                .HasColumnName("QuantityStock")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.SellingPrice)
                .HasColumnName("SellingPrice")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.SupplierPrice)
                .HasColumnName("SupplierPrice")
                .HasColumnType("decimal(18,2)");


        }
    }
}