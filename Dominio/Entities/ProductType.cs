using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class ProductType : BaseEntity2
    {
        public string DescriptionText { get; set; }
        public string DescriptionHtml { get; set; }
        public string Image { get; set; }
        public ICollection<Product> Products {get; set;}
    }
}