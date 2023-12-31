using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace Dominio.Interfaces
{
    public interface IPayment : IGenericRepository2<Payment>
    {
        Task<IEnumerable<object>> infoSalesRepreAndCustomer();
    }
}