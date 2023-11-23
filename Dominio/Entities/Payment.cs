using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Payment: BaseEntity2
    {
        public string PaymentMethod { get; set; }
        public int IdCustomerCodeFk { get; set; }
        public Customer Customer {get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}