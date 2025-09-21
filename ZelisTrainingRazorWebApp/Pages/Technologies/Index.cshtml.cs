using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;
using ZelisTrainingLibrary;

namespace ZelisTrainingRazorWebApp.Pages.Technologies
{
    public class IndexModel : PageModel
    {
        public List<Technology> technologies = new List<Technology>();
        ITechnology techRepo = new ADOTechnology();
        public void OnGet()
        {
            technologies = techRepo.GetAllTechnologies();
        }

    }
}
