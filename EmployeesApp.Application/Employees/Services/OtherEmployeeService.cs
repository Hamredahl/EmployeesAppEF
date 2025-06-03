using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;

namespace EmployeesApp.Application.Employees.Services;

public class OtherEmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
{
    public async Task Add(Employee employee)
    {
        await employeeRepository.Add(employee);
    }

    public Task<Employee[]> GetAll()
    {
        return employeeRepository.GetAll();
    }

    public Task<Employee?> GetById(int id) => employeeRepository.GetById(id);

    public bool CheckIsVIP(Employee employee) =>
        employee.Email.StartsWith("ADMIN", StringComparison.CurrentCultureIgnoreCase);
}