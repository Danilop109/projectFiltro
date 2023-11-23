using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace Api.Dtos
{
    public class OrderDto: BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public int IdCustomerCodeFk { get; set; }
        public CustomerDto Customer {get; set;}
        
    }
}