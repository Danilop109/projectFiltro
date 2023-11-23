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
    public class CustomerRepository : GenericRepository<Customer>, ICustomer
    {
        private readonly ApiJwtContext _context;
        public CustomerRepository(ApiJwtContext context) : base(context)
        {
            _context= context;
        }

        public override async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers
            .ToListAsync();
        }

        public override async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.Customers
            .FirstOrDefaultAsync(p => p.Id.Equals(id));
        }
        
    }
}