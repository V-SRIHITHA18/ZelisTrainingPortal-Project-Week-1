using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZelisTrainingLibrary.Models
{
    public class Training
    {
        public int TrainingId { get; set; }
        public int TrainerId { get; set; }
        public int TechnologyId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

    }
}
