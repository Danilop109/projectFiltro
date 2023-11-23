using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository
{
    public class OrderDetailRepository : GenericRepository2<OrderDetail>, IOrderDetail
    {
        private readonly ApiJwtContext _context;

        public OrderDetailRepository(ApiJwtContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<OrderDetail>> GetAllAsync()
        {
            return await _context.OrderDetails
            .ToListAsync();
        }

        public override async Task<OrderDetail> GetByIdAsync(string id)
        {
            return await _context.OrderDetails
            .FirstOrDefaultAsync(p => p.Id.Equals(id));
        }

        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        // //19. Devuelve un listado de las diferentes gamas de producto que ha comprado cada cliente:
        // public async Task<IEnumerable<object>> GetTypeProCustomer()
        // {
        //     var result = await (
        //         from detallePe in _context.OrderDetails
        //         join order in _context.Orders on detallePe.IdOrderCodeFk equals order.Id
        //         join produ in _context.Products on detallePe.IdProductCodeFk equals produ.Id
        //         join cus in _context.Customers on order.IdCustomerCodeFk equals cus.Id
        //         join tp in _context.ProductTypes on produ.IdProductTypeFk equals tp.Id
        //         select new
        //         {
        //             CustomerName = cus.CustomerName,
        //             NameType= produ.IdProductTypeFk,
        //             NameProdu = produ.Name
        //         }
        //     ).ToListAsync();
        //     return result;
        // }

    }
}