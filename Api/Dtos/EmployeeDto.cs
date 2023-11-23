using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace Api.Dtos
{
    public class EmployeeDto: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName1 { get; set; }
        public string LastName2 { get; set; }
        public string Extension { get; set; }
        public string Email { get; set; }
        public string IdOfficeCodeFk { get; set; }
        public OfficeDto Office {get; set;}
        public int? IdSupervisorCodeFk { get; set; }
        public EmployeeDto SupervisorCode {get; set;}
        public string Puesto { get; set; }
    
    }
}