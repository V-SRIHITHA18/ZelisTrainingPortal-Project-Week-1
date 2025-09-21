using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Employees
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Employee Employee { get; set; }
        IEmployee empRepo = new ADOEmployee();

        public void OnGet()
        {

        }
        public IActionResult onPost()
        {

            empRepo.NewEmployee(Employee);
            return RedirectToPage("/Employees/Index");

        }


    }
}
