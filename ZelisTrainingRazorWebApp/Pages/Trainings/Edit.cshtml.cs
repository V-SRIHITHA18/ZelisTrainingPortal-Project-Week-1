using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainings
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Training Training { get; set; }

        ITraining trainingRepo = new ADOTraining();
        static int Tid;
        public void OnGet(int tid)
        {
            Tid = tid;
            Training = trainingRepo.GetTraining(tid);

        }
        public IActionResult OnPost()
        {
            trainingRepo.UpdateTraining(Tid, Training);
            return RedirectToPage("/Trainings/Index");
        }
    }
}
