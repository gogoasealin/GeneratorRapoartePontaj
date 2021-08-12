using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorRaportPontaje.Utils
{
    class CurrentEmployee
    {
        public string employerID { get; set; }
        public string perimetru { get; set; }
        public int mistakesCount { get; set; }
        public int lowerClockingCount { get; set; }
        public CurrentEmployee()
        {
            employerID = "";
            perimetru = "";
            mistakesCount = 0;
            lowerClockingCount = 0;
        }
    }
}
