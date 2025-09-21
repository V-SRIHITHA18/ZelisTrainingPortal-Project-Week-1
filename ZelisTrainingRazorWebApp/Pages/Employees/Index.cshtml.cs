using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography.X509Certificates;
using ZelisTrainingLibrary;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;


namespace ZelisTrainingRazorWebApp.Pages.Employees
{
    public class IndexModel : PageModel
    {

        public List<Employee> Employees = new List<Employee>();
        IEmployee empRepo = new ADOEmployee();

        public void OnGet()
        {
            Employees = empRepo.GetAllEmployees();
        }



    }
    
}
