using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer"); 

            builder.HasKey(c => c.Id); 

            builder.Property(c => c.CustomerName)
                .HasColumnName("CustomerName")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(c => c.ContactName)
                .HasColumnName("ContactName")
                .HasColumnType("varchar")
                .HasMaxLength(255);

            builder.Property(c => c.ContactLastName)
                .HasColumnName("ContactLastName")
                .HasColumnType("varchar")
                .HasMaxLength(255);

            builder.Property(c => c.Phone)
                .HasColumnName("Phone")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(c => c.Fax)
                .HasColumnName("Fax")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.AddressLine1)
                .HasColumnName("AddressLine1")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(c => c.AddressLine2)
                .HasColumnName("AddressLine2")
                .HasColumnType("varchar")
                .HasMaxLength(255);

            builder.Property(c => c.City)
                .HasColumnName("City")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Region)
                .HasColumnName("Region")
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder.Property(c => c.Country)
                .HasColumnName("Country")
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder.Property(c => c.PostalCode)
                .HasColumnName("PostalCode")
                .HasColumnType("varchar")
                .HasMaxLength(20);


            builder.HasOne(t => t.SalesRepEmployeeCode)
            .WithMany(t => t.Customers)
            .HasForeignKey(t => t.IdSalesRepEmployeeCodeFk);
                
            builder.Property(c => c.CreditLimit)
                .HasColumnName("CreditLimit")
                .HasColumnType("decimal(18,2)");
        }
    }
}