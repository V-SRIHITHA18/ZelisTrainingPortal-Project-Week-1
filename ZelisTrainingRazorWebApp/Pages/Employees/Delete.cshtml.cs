using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using ZelisTrainingLibrary;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Employees
{
    public class DeleteModel : PageModel
    {
        public required Employee Employee { get; set; }
        IEmployee empRepo = new ADOEmployee();
        static int empid;
        public void OnGet(int eid)
        {
            empid = eid;
            Employee = empRepo.GetEmployee(eid);
        }
        public IActionResult OnPost()
        {
            empRepo.DeleteEmployee(empid);
            return RedirectToPage("/Employees/Index");
        }
    }
}

