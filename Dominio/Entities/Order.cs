using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Order: BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public int IdCustomerCodeFk { get; set; }
        public Customer Customer {get; set;}
        public ICollection<OrderDetail> OrderDetails {get; set;}
        
    }
}