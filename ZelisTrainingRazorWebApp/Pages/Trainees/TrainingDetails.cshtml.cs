using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainees
{
    public class TrainingDetailsModel : PageModel
    {
        public Training Training { get; set; }
        ITraining tRepo = new ADOTraining();
        public void OnGet(int tid)
        {
            Training = tRepo.GetTraining(tid);
        }
    }
}

