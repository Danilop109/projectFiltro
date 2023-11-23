using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace Api.Dtos
{
    public class OrderDetailDto : BaseEntity2
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int LineNumber { get; set; }
        public int IdOrderCodeFk { get; set; }
        public OrderDto Order { get; set; }
        public string IdProductCodeFk { get; set; }
        public ProductDto Product { get; set; }
    }
}