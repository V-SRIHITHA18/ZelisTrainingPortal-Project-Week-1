using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Employees
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Employee Employee { get; set; }

        IEmployee empRepo = new ADOEmployee();
        static int empid;
        public void OnGet(int eid)
        {


            empid = eid;
            Employee = empRepo.GetEmployee(eid);

        }
        public IActionResult OnPost()
        {
            empRepo.UpdateEmployee(empid, Employee);
            return RedirectToPage("/Employees/Index");
        }
    }
}
