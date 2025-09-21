using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainings
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Training Training { get; set; }
        ITraining trainingRepo = new ADOTraining();
        public void OnGet()
        {
        }
        public IActionResult onPost()
        {

            trainingRepo.NewTraining(Training);
            return RedirectToPage("/Trainings/Index");

        }
    }
}
