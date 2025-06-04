using EmployeesApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp.Infrastructure.Persistance.Contexts;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Company> Companies { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Employee>()
            .Property(o => o.Salary)
            .HasColumnType(SqlDbType.Money.ToString());

        modelBuilder.Entity<Employee>().HasData(
            new Employee { Id = 1, Name = "Benke Benk", Email = "benk@bsons.com", Salary = 20000.00, CompanyId = 2 },
            new Employee { Id = 2, Name = "Banke Bank", Email = "bank@bsons.com", Salary = 23000.00, CompanyId = 2 },
            new Employee { Id = 3, Name = "Bonke Bonk", Email = "bonk@bsons.com", Salary = 19500.00, CompanyId = 2 },
            new Employee { Id = 4, Name = "Alfons Alfa", Email = "alfons@alfakrull.no", Salary = 43000.00, CompanyId = 1 },
            new Employee { Id = 5, Name = "Albert Albort", Email = "albert@alfakrull.no", Salary = 49000.00, CompanyId = 1 });

        modelBuilder.Entity<Company>().HasData(
            new Company { Id = 1, Name = "Alfakrull AB"},
            new Company { Id = 2, Name = "BSons & Sons"});
    }
}