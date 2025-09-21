using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainers
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Trainer Trainer { get; set; }
        ITrainer trainerRepo = new ADOTrainer();
        public void OnGet()
        {
        }
        public IActionResult onPost()
        {

            trainerRepo.NewTrainer(Trainer);
            return RedirectToPage("/Trainers/Index");

        }
    }
}

