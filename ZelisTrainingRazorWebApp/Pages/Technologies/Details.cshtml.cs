using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Technologies
{
    public class DetailsModel : PageModel
    {
        public Technology Technology { get; set; }
        ITechnology techRepo = new ADOTechnology();
        public void OnGet(int tid)
        {
            Technology = techRepo.GetTechnology(tid);
        }
    }
}
