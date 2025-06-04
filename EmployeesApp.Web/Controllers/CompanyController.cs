using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;
using EmployeesApp.Web.Views.Company;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesApp.Web.Controllers
{
    public class CompanyController(ICompanyService service) : Controller
    {
        [HttpGet("company")]
        public async Task<IActionResult> Company()
        {
            var model = await service.GetAllCompanies();
            var viewModel = new CompanyVM()
            {
                CompaniesVMs = model
                .Select(c => new CompanyVM.CompaniesVM
                {
                    Name = c.Name,
                    Id = c.Id,
                })
                .ToArray()
            };
            return View(viewModel);
        }

        [HttpGet("remove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var model = await service.GetCompanyById(id);



            return RedirectToAction(nameof(Company));
        }
    }
}
