using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorRaportPontaje.Utils
{
    class DefaultRaportValues
    {
        public int employerCount { get; set; }
        public int wrongClocking { get; set; }
        public int correctClocking { get; set; }
        public int lowerClocking{ get; set; }
        public int correctness { get; set; }
        public DefaultRaportValues()
        {
            employerCount = 0;
            wrongClocking = 0;
            correctClocking = 0;
            lowerClocking = 0;
            correctness = 0;
        }
    }
}
