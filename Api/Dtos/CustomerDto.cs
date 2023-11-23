using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace Api.Dtos
{
    public class CustomerDto : BaseEntity
    {
        public string CustomerName { get; set; }
        public string ContactName { get; set; }
        public string ContactLastName { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public decimal? CreditLimit { get; set; }
        public int? IdSalesRepEmployeeCodeFk { get; set; }
        public EmployeeDto SalesRepEmployeeCode { get; set; }
    }
}