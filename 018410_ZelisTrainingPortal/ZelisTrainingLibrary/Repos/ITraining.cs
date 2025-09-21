using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingLibrary.Models;

namespace ZelisTrainingLibrary.Repos
{
    public interface ITraining
    {
        void NewTraining(Training training);
        void UpdateTraining(int tid, Training training);
        void DeleteTraining(int tid);
        Training GetTraining(int tid);
        List<Training> GetAllTrainings();
        List<Training> GetAllTechnologiesInTraining(int tid);
        List<Technology> GetAllTechnologiesByTrainer(int tid);
    }
}
