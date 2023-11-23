using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository
{
    public class PaymentRepository: GenericRepository2<Payment>, IPayment
    {
        private readonly ApiJwtContext _context;
        public PaymentRepository(ApiJwtContext context) : base(context)
        {
            _context= context;
        }

         public override async Task<IEnumerable<Payment>> GetAllAsync()
        {
            return await _context.Payments
            .ToListAsync();
        }

        public override async Task<Payment> GetByIdAsync(int id)
        {
            return await _context.Payments
            .FirstOrDefaultAsync(p => p.Id.Equals(id));
        }

        //2. Devuelve el nombre de los clientes que no hayan hecho pagos y el nombre
        //de sus representantes de ventas con la ciudad de la oficinaa a la que pertenece
        //el representante.
        public async Task<IEnumerable<object>> infoSalesRepreAndCustomer()
        {
            return await _context.Customers
            .Where(c => !c.Payments.Any())
            .Select(c => new{
                    CustomerName= c.CustomerName,
                    RepreName= c.SalesRepEmployeeCode.FirstName,
                    OfficeName= c.SalesRepEmployeeCode.Office.City}
            ).ToListAsync();
        }
    }
}