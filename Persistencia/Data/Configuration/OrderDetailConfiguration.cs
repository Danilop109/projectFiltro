using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetail");

            builder.HasKey(d => new { d.IdOrderCodeFk, d.IdProductCodeFk }); // Definir clave primaria compuesta

            builder.Property(od => od.Quantity)
                .HasColumnName("Quantity")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(od => od.UnitPrice)
                .HasColumnName("UnitPrice")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(od => od.LineNumber)
                .HasColumnName("LineNumber")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.IdOrderCodeFk);

             builder.HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.IdProductCodeFk);

        }
    }
}