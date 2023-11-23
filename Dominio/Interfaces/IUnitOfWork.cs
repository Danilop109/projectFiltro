using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IUnitOfWork
    {
        ICustomer Customers { get; } 
        IEmployee Employees { get; } 
        IOffice Offices { get; } 
        IOrder Orders { get; } 
        IOrderDetail OrderDetails { get; } 
        IPayment Payments { get; } 
        IProduct Products { get; } 
        IProductType ProductTypes { get; } 
        Task<int> SaveAsync();
    }
}