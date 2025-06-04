using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp.Application.Employees.Interfaces
{
    public interface IOfficeRepository
    {
        Task RemoveOffice(int id);
    }
}
