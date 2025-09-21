using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingLibrary.Models;

namespace ZelisTrainingLibrary.Repos
{
    public interface ITechnology
    {
        void NewTechnology(Technology technology);
        void UpdateTechnology(int id, Technology technology);
        void DeleteTechnology(int id);
        Technology GetTechnology(int id);
        List<Technology> GetAllTechnologies();
        List<Technology> GetTechnologiesByLevel(Char level);
    }
}
