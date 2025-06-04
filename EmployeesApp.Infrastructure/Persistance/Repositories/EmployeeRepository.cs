using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;
using EmployeesApp.Infrastructure.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApp.Infrastructure.Persistance.Repositories;
public class EmployeeRepository(ApplicationContext context) : IEmployeeRepository
{
    public async Task Add(Employee employee)
    {
        context.Employees.Add(employee);
        await context.SaveChangesAsync();
    }
    public async Task<Employee[]> GetAll() => await context.Employees
        .Include(e => e.Company)            
        .AsNoTracking()
        .ToArrayAsync();

    public async Task<Employee?> GetById(int id)
    {
        var employee = await context.Employees.FindAsync(id);
        await context.Entry(employee).Reference(c => c.Company).LoadAsync();
        return employee;
    }
    public async Task Delete(Employee employee)
    {
        context.Employees.Remove(employee);
    }
}