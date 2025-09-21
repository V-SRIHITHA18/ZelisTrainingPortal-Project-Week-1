using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Technologies
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Technology Technology { get; set; }
        ITechnology techRepo = new ADOTechnology();
        public void OnGet()
        {

        }
        public IActionResult onPost()
        {

            techRepo.NewTechnology(Technology);
            return RedirectToPage("/Technologies/Index");

        }
    }
}
