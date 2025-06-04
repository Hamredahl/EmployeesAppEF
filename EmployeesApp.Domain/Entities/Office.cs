using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp.Domain.Entities
{
    public class Office
    {
        public int Id { get; set; }
        public string? City { get; set; }
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}
