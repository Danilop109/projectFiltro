using System.Reflection;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia
{
    public class ApiJwtContext : DbContext
    {
        public ApiJwtContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Customer> Customers {get; set;}
        public DbSet<Employee> Employees {get; set;}
        public DbSet<Office> Offices {get; set;}
        public DbSet<Order> Orders {get; set;}
        public DbSet<OrderDetail> OrderDetails {get; set;}
        public DbSet<Payment> Payments {get; set;}
        public DbSet<Product> Products {get; set;}
        public DbSet<ProductType> ProductTypes {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    }
}