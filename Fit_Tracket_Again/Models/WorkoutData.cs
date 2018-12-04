using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fit_Tracket_Again.Models
{
    public class WorkoutData
    {
        public int ID { get; set; }
        public DateTime Date {get;set;}
        public String WorkoutName { get; set; }
        public int WorkoutWeight { get; set; }
        public int WorkoutReps { get; set; }
        public int WorkoutSets { get; set; }

    }
}
