﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistencia;

#nullable disable

namespace Persistencia.Data.Migrations
{
    [DbContext(typeof(ApiJwtContext))]
    [Migration("20231123205206_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Dominio.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("AddressLine1");

                    b.Property<string>("AddressLine2")
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("AddressLine2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("City");

                    b.Property<string>("ContactLastName")
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("ContactLastName");

                    b.Property<string>("ContactName")
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("ContactName");

                    b.Property<string>("Country")
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Country");

                    b.Property<decimal?>("CreditLimit")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("CreditLimit");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("CustomerName");

                    b.Property<string>("Fax")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar")
                        .HasColumnName("Fax");

                    b.Property<int?>("IdSalesRepEmployeeCodeFk")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar")
                        .HasColumnName("Phone");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(20)
                        .HasColumnType("varchar")
                        .HasColumnName("PostalCode");

                    b.Property<string>("Region")
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Region");

                    b.HasKey("Id");

                    b.HasIndex("IdSalesRepEmployeeCodeFk");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("Email");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar")
                        .HasColumnName("Extension");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("FirstName");

                    b.Property<string>("IdOfficeCodeFk")
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("IdSupervisorCodeFk")
                        .HasColumnType("int");

                    b.Property<string>("LastName1")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("LastName1");

                    b.Property<string>("LastName2")
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("LastName2");

                    b.Property<string>("Puesto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("puesto");

                    b.HasKey("Id");

                    b.HasIndex("IdOfficeCodeFk");

                    b.HasIndex("IdSupervisorCodeFk");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Office", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("AddressLine1");

                    b.Property<string>("AddressLine2")
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("AddressLine2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("City");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Country");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar")
                        .HasColumnName("Phone");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar")
                        .HasColumnName("PostalCode");

                    b.Property<string>("Region")
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Region");

                    b.HasKey("Id");

                    b.ToTable("Office", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("ActualDeliveryDate")
                        .HasColumnType("date")
                        .HasColumnName("ActualDeliveryDate");

                    b.Property<string>("Comments")
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("Comments");

                    b.Property<DateTime>("ExpectedDeliveryDate")
                        .HasColumnType("date")
                        .HasColumnName("ExpectedDeliveryDate");

                    b.Property<int>("IdCustomerCodeFk")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("date")
                        .HasColumnName("OrderDate");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.HasIndex("IdCustomerCodeFk");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.OrderDetail", b =>
                {
                    b.Property<int>("IdOrderCodeFk")
                        .HasColumnType("int");

                    b.Property<string>("IdProductCodeFk")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Id")
                        .HasColumnType("longtext");

                    b.Property<int>("LineNumber")
                        .HasColumnType("int")
                        .HasColumnName("LineNumber");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("Quantity");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("UnitPrice");

                    b.HasKey("IdOrderCodeFk", "IdProductCodeFk");

                    b.HasIndex("IdProductCodeFk");

                    b.ToTable("OrderDetail", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Payment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("IdCustomerCodeFk")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime")
                        .HasColumnName("PaymentDate");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("PaymentMethod");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("TotalAmount");

                    b.HasKey("Id");

                    b.HasIndex("IdCustomerCodeFk");

                    b.ToTable("Payment", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Product", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("varchar")
                        .HasColumnName("Description");

                    b.Property<string>("Dimensions")
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Dimensions");

                    b.Property<string>("IdProductTypeFk")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("Name");

                    b.Property<int>("QuantityStock")
                        .HasColumnType("int")
                        .HasColumnName("QuantityStock");

                    b.Property<decimal>("SellingPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("SellingPrice");

                    b.Property<string>("Supplier")
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("Supplier");

                    b.Property<decimal>("SupplierPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("SupplierPrice");

                    b.HasKey("Id");

                    b.HasIndex("IdProductTypeFk");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.ProductType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DescriptionHtml")
                        .HasMaxLength(1000)
                        .HasColumnType("varchar")
                        .HasColumnName("DescriptionHtml");

                    b.Property<string>("DescriptionText")
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("DescriptionText");

                    b.Property<string>("Image")
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("Image");

                    b.HasKey("Id");

                    b.ToTable("ProductType", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Customer", b =>
                {
                    b.HasOne("Dominio.Entities.Employee", "SalesRepEmployeeCode")
                        .WithMany("Customers")
                        .HasForeignKey("IdSalesRepEmployeeCodeFk");

                    b.Navigation("SalesRepEmployeeCode");
                });

            modelBuilder.Entity("Dominio.Entities.Employee", b =>
                {
                    b.HasOne("Dominio.Entities.Office", "Office")
                        .WithMany("Employees")
                        .HasForeignKey("IdOfficeCodeFk");

                    b.HasOne("Dominio.Entities.Employee", "SupervisorCode")
                        .WithMany("Employees")
                        .HasForeignKey("IdSupervisorCodeFk");

                    b.Navigation("Office");

                    b.Navigation("SupervisorCode");
                });

            modelBuilder.Entity("Dominio.Entities.Order", b =>
                {
                    b.HasOne("Dominio.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("IdCustomerCodeFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Dominio.Entities.OrderDetail", b =>
                {
                    b.HasOne("Dominio.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("IdOrderCodeFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("IdProductCodeFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Dominio.Entities.Payment", b =>
                {
                    b.HasOne("Dominio.Entities.Customer", "Customer")
                        .WithMany("Payments")
                        .HasForeignKey("IdCustomerCodeFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Dominio.Entities.Product", b =>
                {
                    b.HasOne("Dominio.Entities.ProductType", "ProductType")
                        .WithMany("Products")
                        .HasForeignKey("IdProductTypeFk");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("Dominio.Entities.Customer", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("Dominio.Entities.Employee", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Dominio.Entities.Office", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Dominio.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Dominio.Entities.Product", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Dominio.Entities.ProductType", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}