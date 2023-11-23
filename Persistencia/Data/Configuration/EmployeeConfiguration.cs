using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                .HasColumnName("FirstName")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.LastName1)
                .HasColumnName("LastName1")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.LastName2)
                .HasColumnName("LastName2")
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder.Property(e => e.Extension)
                .HasColumnName("Extension")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(e => e.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar")
                .HasMaxLength(255);

            builder.HasOne(t => t.Office)
            .WithMany(t => t.Employees)
            .HasForeignKey(t => t.IdOfficeCodeFk);

            builder.HasOne(d => d.SupervisorCode)
            .WithMany(d => d.Employees)
            .HasForeignKey(d => d.IdSupervisorCodeFk)
            .IsRequired(false);

            builder.Property(e => e.Puesto)
                .HasColumnName("puesto")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(100);

        }
    }
}