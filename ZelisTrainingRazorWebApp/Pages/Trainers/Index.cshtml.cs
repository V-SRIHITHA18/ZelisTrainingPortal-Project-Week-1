using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainers
{
    public class IndexModel : PageModel
    {
        public List<Trainer> trainers = new List<Trainer>();
        ITrainer trainerRepo = new ADOTrainer();
        public void OnGet()
        {
            trainers = trainerRepo.GetAllTrainers();
        }
    }
}
