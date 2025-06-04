using EmployeesApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp.Application.Employees.Interfaces
{
    public interface ICompanyService
    {
        Task<Company[]> GetAllCompanies();
        Task<Company> GetCompanyById(int id);
        Task RemoveCompany(int id);
    }
}
