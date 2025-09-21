using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using ZelisTrainingLibrary;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Employees
{
    public class TrainerDeatilsModel : PageModel
    {
        public Employee Employee { get; set; }
        IEmployee empRepo = new ADOEmployee();
        public void OnGet(int eid)
        {
            Employee = empRepo.GetEmployee(eid);
        }
    }
}

