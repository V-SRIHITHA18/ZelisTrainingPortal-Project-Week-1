using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainings
{
    public class IndexModel : PageModel
    {
        public List<Training> trainings = new List<Training>();
        ITraining trainingRepo = new ADOTraining();
        public void OnGet()
        {
            trainings = trainingRepo.GetAllTrainings();
        }
    }
}
