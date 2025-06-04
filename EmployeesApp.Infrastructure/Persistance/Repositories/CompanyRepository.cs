using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;
using EmployeesApp.Infrastructure.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp.Infrastructure.Persistance.Repositories;

public class CompanyRepository(ApplicationContext context) : ICompanyRepository
{
    public async Task<Company[]> GetAllCompanies() => await context.Companies
        .ToArrayAsync();

    public async Task<Company> GetCompanyById(int id)
    {
        var company = await context.Companies.FindAsync(id);
        await context.Entry(company).Collection(e => e.Employees).LoadAsync();
        await context.Entry(company).Collection(o => o.Offices).LoadAsync();
        return company;
    }
    public async Task Delete(Company company)
    {
        context.Companies.Remove(company);
    }
}
