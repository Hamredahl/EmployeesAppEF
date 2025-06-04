using EmployeesApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp.Application.Employees.Interfaces
{
    public interface ICompanyRepository
    {
        Task<Company[]> GetAllCompanies();
        Task<Company> GetCompanyById(int id);
        Task Delete(Company company);
    }
}
