using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZelisTrainingLibrary.Models
{
    public class TrainingException:Exception
    {
        public TrainingException() { }

        public TrainingException(string message)
            : base(message) { }


    }
}
