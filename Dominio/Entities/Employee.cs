using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName1 { get; set; }
        public string LastName2 { get; set; }
        public string Extension { get; set; }
        public string Email { get; set; }
        public string IdOfficeCodeFk { get; set; }
        public Office Office {get; set;}
        public int? IdSupervisorCodeFk { get; set; }
        public Employee SupervisorCode {get; set;}
        public string Puesto { get; set; }
        public ICollection<Customer> Customers {get; set;}
        public ICollection<Employee> Employees {get; set;}
    }
}