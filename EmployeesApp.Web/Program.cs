using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Application.Employees.Services;
using EmployeesApp.Infrastructure;
using EmployeesApp.Infrastructure.Persistance.Contexts;
using EmployeesApp.Infrastructure.Persistance.Repositories;
using EmployeesApp.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace EmployeesApp.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var cultureInfo = new CultureInfo("en-US");
        CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
        CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

        builder.Services.AddControllersWithViews();

        builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        builder.Services.AddScoped<IEmployeeService, EmployeeService>();
        builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
        builder.Services.AddScoped<ICompanyService, CompanyService>();
        builder.Services.AddScoped<IOfficeRepository, OfficeRepository>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        builder.Services.AddScoped<MyLogServiceFilterAttribute>();
        builder.Services.AddScoped<ApplicationContext>();

        var connString = builder.Configuration
            .GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<ApplicationContext>( o => o.UseSqlServer(connString) );

        var app = builder.Build();
        app.MapControllers();
        app.Run();
    }
}