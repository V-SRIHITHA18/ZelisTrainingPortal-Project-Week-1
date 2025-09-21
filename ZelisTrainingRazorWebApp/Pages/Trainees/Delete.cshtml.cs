using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainees
{
    public class DeleteModel : PageModel
    {
        public Trainee Trainee { get; set; }
        ITrainee traineeRepo = new ADOTrainee();
        static int Tid;
        public void OnGet(int tid)
        {
            Tid = tid;
            
            Trainee = traineeRepo.GetTrainee(tid);
        }
        public IActionResult OnPost()
        {
            traineeRepo.DeleteTrainee(Tid);
            return RedirectToPage("/Trainees/Index");
        }
    }
}

