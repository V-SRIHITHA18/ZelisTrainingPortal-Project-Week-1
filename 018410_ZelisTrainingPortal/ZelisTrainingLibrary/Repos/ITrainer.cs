using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingLibrary.Models;

namespace ZelisTrainingLibrary.Repos
{
    public interface ITrainer
    {
        void NewTrainer(Trainer trainer);
        void UpdateTrainer(int id, Trainer trainer);
        void DeleteTrainer(int id);
        List<Trainer> GetAllTrainers();
        Trainer GetTrainer(int id);
        List<Trainer> GetTrainersByType(char type);
    }
}
