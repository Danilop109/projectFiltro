using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Product : BaseEntity2
    {
        public string Name { get; set; }
        public string IdProductTypeFk { get; set; }
        public ProductType ProductType {get; set;}
        public string Dimensions { get; set; }
        public string Supplier { get; set; }
        public string Description { get; set; }
        public int QuantityStock { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal SupplierPrice { get; set; }
        public ICollection<OrderDetail> OrderDetails {get; set;}
        
    }
}