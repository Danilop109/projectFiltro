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
    public class OfficeRepository : GenericRepository2<Office>, IOffice
    {
        private readonly ApiJwtContext _context;
        public OfficeRepository(ApiJwtContext context) : base(context)
        {
            _context = context;
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

        //3. Devuelve las oficinas donde no trabajan ninguno de los empleados que
        //hayan sido los representantes de ventas de algún cliente que haya realizado
        //la compra de algún producto de la gama Frutales.
        public async Task<IEnumerable<Office>> GetOfficeAnyALotOfThings()
        {
            var officesFru = await (
                from office in _context.Offices
                where !_context.Employees.Any(employee =>
                    _context.Customers.Any(customer =>
                        _context.Orders.Any(order =>
                            _context.OrderDetails.Any(orderDetail =>
                                orderDetail.IdOrderCodeFk == order.Id &&
                                order.IdCustomerCodeFk == customer.Id &&
                                customer.IdSalesRepEmployeeCodeFk == employee.Id &&
                                _context.Products.Any(product =>
                                    product.Id == orderDetail.IdProductCodeFk &&
                                    product.IdProductTypeFk == "Frutales"
                                )
                            )
                        )
                    )
                )
                select office
            ).ToListAsync();

            return officesFru;
        }

    }
}