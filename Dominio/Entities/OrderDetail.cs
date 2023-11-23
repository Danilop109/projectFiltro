using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class OrderDetail : BaseEntity2
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int LineNumber { get; set; }
        public int IdOrderCodeFk { get; set; }
        public Order Order { get; set; }
        public string IdProductCodeFk { get; set; }
        public Product Product { get; set; }
    }
}