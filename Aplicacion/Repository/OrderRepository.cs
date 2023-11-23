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
    public class OrderRepository: GenericRepository<Order>, IOrder
    {
        private readonly ApiJwtContext _context;
        public OrderRepository(ApiJwtContext context) : base(context)
        {
            _context= context;
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
    }
}