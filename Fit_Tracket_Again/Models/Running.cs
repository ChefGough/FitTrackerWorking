using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fit_Tracket_Again.Models
{
    public class Running
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public decimal Distance { get; set; }
        public TimeSpan Time { get; set; }
        public string RunType { get; set; }
    }
}
