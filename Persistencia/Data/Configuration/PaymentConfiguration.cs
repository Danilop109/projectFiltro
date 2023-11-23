using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payment"); 

            builder.HasKey(p => p.Id); 

            builder.Property(p => p.PaymentMethod)
                .HasColumnName("PaymentMethod")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(50);


            builder.HasOne(p => p.Customer)
                .WithMany(c => c.Payments)
                .HasForeignKey(p => p.IdCustomerCodeFk);
                
            builder.Property(p => p.PaymentDate)
                .HasColumnName("PaymentDate")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(p => p.TotalAmount)
                .HasColumnName("TotalAmount")
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }
    }
}