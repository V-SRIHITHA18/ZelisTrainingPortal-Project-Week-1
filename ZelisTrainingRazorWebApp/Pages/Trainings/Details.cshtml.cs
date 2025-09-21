using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainings
{
    public class DetailsModel : PageModel
    {
        public Training Training { get; set; }
        ITraining trainingRepo = new ADOTraining();
        public void OnGet(int tid)
        {
            Training = trainingRepo.GetTraining(tid);
        }
    }
}
