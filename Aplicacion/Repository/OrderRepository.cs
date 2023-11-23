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
    public class OrderRepository : GenericRepository<Order>, IOrder
    {
        private readonly ApiJwtContext _context;
        public OrderRepository(ApiJwtContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders
            .ToListAsync();
        }

        public override async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Orders
            .FirstOrDefaultAsync(p => p.Id.Equals(id));
        }

        //1. Devuelve un listado con el código de pedido, codigo de cliente, fecha esperada, y fecha de entrega
        // de los pedidos que no han sido entregados a tiempo.

        public async Task<IEnumerable<object>> InfoCustomer()
        {
            var objeto = await
            (
                from p in _context.Orders
                join c in _context.Customers on p.IdCustomerCodeFk equals c.Id
                where p.ExpectedDeliveryDate < p.ActualDeliveryDate
                select new
                {
                    OrderCode = p.Id,
                    IdCustomer = p.IdCustomerCodeFk,
                    ExpectDate = p.ExpectedDeliveryDate,
                    ActualDate = p.ActualDeliveryDate
                }
            ).Distinct().ToListAsync();

            return objeto;
        }

    }
}