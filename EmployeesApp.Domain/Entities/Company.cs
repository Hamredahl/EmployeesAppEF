﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp.Domain.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Employee>? Employees { get; set; }
        public List<Office>? Offices { get; set; }
    }
}
