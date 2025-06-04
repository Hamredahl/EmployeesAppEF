namespace EmployeesApp.Web.Views.Company
{
    public class CompanyVM
    {
        public CompaniesVM[] CompaniesVMs { get; set; } = null!;
        public class CompaniesVM()
        {
            public int Id { get; set; }
            public string? Name { get; set; }
        }
    }
}
