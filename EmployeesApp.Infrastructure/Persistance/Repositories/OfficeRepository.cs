using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;
using EmployeesApp.Infrastructure.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApp.Infrastructure.Persistance.Repositories
{
    public class OfficeRepository(ApplicationContext context) : IOfficeRepository
    {
        public async Task Delete(Office office)
        {
            context.Offices.Remove(office);
        }
    }
}
