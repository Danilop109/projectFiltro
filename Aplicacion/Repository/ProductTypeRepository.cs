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
    public class ProductTypeRepository: GenericRepository2<ProductType>, IProductType
    {
        private readonly ApiJwtContext _context;
        public ProductTypeRepository(ApiJwtContext context) : base(context)
        {
            _context= context;
        }

         public override async Task<IEnumerable<ProductType>> GetAllAsync()
        {
            return await _context.ProductTypes
            .ToListAsync();
        }

        public override async Task<ProductType> GetByIdAsync(int id)
        {
            return await _context.ProductTypes
            .FirstOrDefaultAsync(p => p.Id.Equals(id));
        }
    }
}