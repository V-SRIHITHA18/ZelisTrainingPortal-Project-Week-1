using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingLibrary.Models;

namespace ZelisTrainingLibrary.Repos
{
    public interface ITrainee
    {
        void NewTrainee(Trainee trainee);
        void UpdateTrainee(int id, Trainee trainee);
        void DeleteTrainee(int id);
        Trainee GetTrainee(int id);
        List<Trainee> GetAllTrainees();
        List<Trainee> GetTraineesByStatus(char status);
        List<Training> GetAllTrainingsByTrainee(int id);
        Employee GetTrainerDetails(int id);
    }
}
