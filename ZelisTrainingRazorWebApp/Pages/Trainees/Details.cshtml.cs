using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainees
{
    public class DetailsModel : PageModel
    {
        public Trainee Trainee { get; set; }
        ITrainee traineeRepo = new ADOTrainee();
        public void OnGet(int tid)
        {
            Trainee = traineeRepo.GetTrainee(tid);
        }
    }
}
