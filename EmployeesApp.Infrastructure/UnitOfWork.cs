using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Infrastructure.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp.Infrastructure
{
    public class UnitOfWork(ApplicationContext context, ICompanyRepository companyRepository, IEmployeeRepository employeeRepository, IOfficeRepository officeRepository) : IUnitOfWork
    {
        public IOfficeRepository OfficeRepository => officeRepository;
        public IEmployeeRepository EmployeeRepository => employeeRepository;
        public ICompanyRepository CompanyRepository => companyRepository;

        public async Task Save() => await context.SaveChangesAsync();
    }
}
