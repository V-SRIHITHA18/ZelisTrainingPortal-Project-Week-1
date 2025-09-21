using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Technologies
{
    public class DeleteModel : PageModel
    {
        public Technology Technology { get; set; }
        ITechnology techRepo = new ADOTechnology();
        static int empid;
        public void OnGet(int eid)
        {
            empid = eid;
            Technology = techRepo.GetTechnology(eid);
        }
        public IActionResult OnPost()
        {
            techRepo.DeleteTechnology(empid);
            return RedirectToPage("/Technologies/Index");
        }
    }
}

