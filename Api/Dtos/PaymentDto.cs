using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace Api.Dtos
{
    public class PaymentDto: BaseEntity2
    {
        public string PaymentMethod { get; set; }
        public int IdCustomerCodeFk { get; set; }
        public CustomerDto Customer {get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}