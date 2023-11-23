using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order"); 

            builder.HasKey(o => o.Id); 

            builder.Property(o => o.OrderDate)
                .HasColumnName("OrderDate")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(o => o.ExpectedDeliveryDate)
                .HasColumnName("ExpectedDeliveryDate")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(o => o.ActualDeliveryDate)
                .HasColumnName("ActualDeliveryDate")
                .HasColumnType("date");

            builder.Property(o => o.Status)
                .HasColumnName("Status")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(o => o.Comments)
                .HasColumnName("Comments")
                .HasColumnType("varchar")
                .HasMaxLength(255);

            builder.HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.IdCustomerCodeFk);

    }
}