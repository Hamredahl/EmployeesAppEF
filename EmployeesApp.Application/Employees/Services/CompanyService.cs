using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp.Application.Employees.Services;

public class CompanyService(IUnitOfWork unitOfWork) : ICompanyService
{
    public async Task<Company[]> GetAll()
    {
        return (await unitOfWork.CompanyRepository
            .GetAllCompanies())
            .OrderBy(c => c.Name)
            .ToArray();
    }

    public async Task<Company> GetById(int id)
    {
        Company? company = await unitOfWork.CompanyRepository.GetCompanyById(id);

        return company is null ?
            throw new ArgumentException($"Invalid parameter value: {id}", nameof(id)) :
            company;
    }
    public async Task Delete(Company company)    
    {
        foreach(Employee e in company.Employees) await unitOfWork.EmployeeRepository.Delete(e);
        foreach (Office o in company.Offices) await unitOfWork.OfficeRepository.Delete(o);        
        await unitOfWork.CompanyRepository.Delete(company);

        await unitOfWork.Save();
    }
}
