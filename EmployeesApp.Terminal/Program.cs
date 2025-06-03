using EmployeesApp.Application.Employees.Services;
using EmployeesApp.Domain.Entities;
using EmployeesApp.Infrastructure.Persistance.Contexts;
using EmployeesApp.Infrastructure.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data.Common;

namespace EmployeesApp.Terminal;
public class Program
{

    static EmployeeService employeeService;

    static void Main(string[] args)
    {
        DbContextOptionsBuilder<ApplicationContext> builder = new DbContextOptionsBuilder<ApplicationContext>();
        builder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EmployeesAppDB;Trusted_Connection=True;");
        employeeService = new(new EmployeeRepository(new ApplicationContext(builder.Options)));

        ListAllEmployees();

        while (true)
        {
            Console.Write("ID to look up: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine();
            ListEmployee(id);            
        }
    }

    private static void ListAllEmployees()
    {
        foreach (var item in employeeService.GetAll().Result)
            Console.WriteLine(item.Name);

        Console.WriteLine("------------------------------");
    }

    private static void ListEmployee(int employeeID)
    {
        Employee? employee;

        try
        {
            employee = employeeService.GetById(employeeID).Result;
            Console.WriteLine($"{employee?.Name}: {employee?.Email}");
            Console.WriteLine("------------------------------");
        }
        catch (Exception e)
        {
            Console.WriteLine($"EXCEPTION: {e.Message}");
            Console.WriteLine();
        }
    }
}