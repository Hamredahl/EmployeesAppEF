using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp.Application.Employees.Services;

public class CompanyService(ICompanyRepository companyRepository) : ICompanyService
{
    public async Task<Company[]> GetAll()
    {
        return (await companyRepository.
            GetAllCompanies())
            .OrderBy(c => c.Name)
            .ToArray();
    }

    public async Task<Company> GetById(int id)
    {
        Company? company = await companyRepository.GetCompanyById(id);

        return company is null ?
            throw new ArgumentException($"Invalid parameter value: {id}", nameof(id)) :
            company;
    }
    public async Task Delete(int id)
    {

    }
}
