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
    public class OfficeRepository : IOfficeRepository
    {
        public async Task RemoveOffice(int id)
        {

        }
    }
}
