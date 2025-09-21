using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainings
{
    public class DeleteModel : PageModel
    {
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
            trainingRepo.DeleteTraining(Tid);
            return RedirectToPage("/Trainings/Index");
        }
    }
}
