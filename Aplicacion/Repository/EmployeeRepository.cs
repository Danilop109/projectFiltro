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

        // 9.  Devuelve un listado con los datos de los empleados que no tienen clientes asociados y el nombre de su jefe asociado:
        public async Task<IEnumerable<object>> GetNoCustEmployAndBoss()
        {
            var employes = await (
                from emp in _context.Employees
                join supervisor in _context.Employees on emp.IdSupervisorCodeFk equals supervisor.Id
                where !_context.Customers.Any(customer => customer.IdSalesRepEmployeeCodeFk == emp.Id)
                select new
                {
                    EmployeeName = emp.FirstName,
                    EmployeeLastName = emp.LastName1,
                    BossName = supervisor.FirstName
                }
            ).ToListAsync();

            return employes;
        }
    }
}