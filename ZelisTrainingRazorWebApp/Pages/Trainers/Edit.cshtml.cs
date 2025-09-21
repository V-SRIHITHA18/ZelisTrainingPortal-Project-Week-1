using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainers
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Trainer Trainer { get; set; }

        ITrainer trainerRepo = new ADOTrainer();
        static int Tid;
        public void OnGet(int tid)
        {
            Tid = tid;
            Trainer = trainerRepo.GetTrainer(tid);

        }
        public IActionResult OnPost()
        {
            trainerRepo.UpdateTrainer(Tid, Trainer);
            return RedirectToPage("/Trainers/Index");
        }
    }
}

