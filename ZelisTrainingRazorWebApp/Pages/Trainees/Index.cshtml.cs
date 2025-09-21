using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainees
{
    public class IndexModel : PageModel
    {
        public List<Trainee> trainees = new List<Trainee>();
        ITrainee traineeRepo = new ADOTrainee();
        public void OnGet()
        {
            trainees = traineeRepo.GetAllTrainees();
        }
    }
}
