using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainers
{
    public class DeleteModel : PageModel
    {
        public Trainer Trainer { get; set; }
        ITrainer trainerRepo = new ADOTrainer();
        static int Tid;
        public void OnGet(int tid)
        {

            Tid= tid;
            Trainer = trainerRepo.GetTrainer(Tid);
        }
        public IActionResult OnPost()
        {
            trainerRepo.DeleteTrainer(Tid);
            return RedirectToPage("/Trainers/Index");
        }
    }
}
