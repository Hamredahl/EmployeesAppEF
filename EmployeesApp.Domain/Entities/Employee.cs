﻿namespace EmployeesApp.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public double Salary { get; set; }
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}
