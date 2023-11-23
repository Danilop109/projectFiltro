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
    public class EmployeeRepository: GenericRepository<Employee>, IEmployee
    {
        private readonly ApiJwtContext _context;
        public EmployeeRepository(ApiJwtContext context) : base(context)
        {
            _context= context;
        }

         public override async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees
            .ToListAsync();
        }

        public override async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Employees
            .FirstOrDefaultAsync(p => p.Id.Equals(id));
        }
    }
}