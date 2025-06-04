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
            var model = await service.GetAll();
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

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await service.GetById(id);
            await service.Delete(model);
            return RedirectToAction(nameof(Company));
        }
    }
}
