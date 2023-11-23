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
    public class OfficeRepository: GenericRepository2<Office>, IOffice
    {
        private readonly ApiJwtContext _context;
        public OfficeRepository(ApiJwtContext context) : base(context)
        {
            _context= context;
        }

         public override async Task<IEnumerable<Office>> GetAllAsync()
        {
            return await _context.Offices
            .ToListAsync();
        }

        public override async Task<Office> GetByIdAsync(string id)
        {
            return await _context.Offices
            .FirstOrDefaultAsync(p => p.Id.Equals(id));
        }
    }
}