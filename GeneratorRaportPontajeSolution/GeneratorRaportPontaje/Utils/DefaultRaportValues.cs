using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorRaportPontaje.Utils
{
    class DefaultRaportValues
    {
        public int employeesCount { get; set; }
        public int wrongClocking { get; set; }
        public double correctClocking { get; set; }
        public double lowerClocking { get; set; }
        public double correctness { get; set; }
        public DefaultRaportValues()
        {
            employeesCount = 0;
            wrongClocking = 0;
            correctClocking = 0;
            lowerClocking = 0;
            correctness = 0;
        }
    }
}
