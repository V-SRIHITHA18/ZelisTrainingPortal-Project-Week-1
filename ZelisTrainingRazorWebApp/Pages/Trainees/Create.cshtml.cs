using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainees
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Trainee Trainee { get; set; }
        ITrainee traineeRepo = new ADOTrainee();
        public void OnGet()
        {
        }
        public IActionResult onPost()
        {

            traineeRepo.NewTrainee(Trainee);
            return RedirectToPage("/Trainees/Index");

        }
    }
}
