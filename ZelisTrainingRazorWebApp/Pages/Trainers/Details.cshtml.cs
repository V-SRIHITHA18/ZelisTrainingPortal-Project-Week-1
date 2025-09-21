using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainers
{
    public class DetailsModel : PageModel
    {
        public Trainer Trainer { get; set; }
        ITrainer trainerRepo = new ADOTrainer();
        public void OnGet(int tid)
        {
            Trainer = trainerRepo.GetTrainer(tid);
        }
    }
}
