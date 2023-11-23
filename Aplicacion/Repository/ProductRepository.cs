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
    public class ProductRepository: GenericRepository2<Product>, IProduct
    {
        private readonly ApiJwtContext _context;
        public ProductRepository(ApiJwtContext context) : base(context)
        {
            _context= context;
        }

         public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
            .ToListAsync();
        }

        public override async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products
            .FirstOrDefaultAsync(p => p.Id.Equals(id));
        }

    }
}