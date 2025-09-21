using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Technologies
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Technology Technology { get; set; }

        ITechnology techRepo = new ADOTechnology();
        static int techid;
        public void OnGet(int tid)
        {
            techid = tid;
            Technology = techRepo.GetTechnology(tid);

        }
        public IActionResult OnPost()
        {
            techRepo.UpdateTechnology(techid, Technology);
            return RedirectToPage("/Technologies/Index");
        }
    }
}

