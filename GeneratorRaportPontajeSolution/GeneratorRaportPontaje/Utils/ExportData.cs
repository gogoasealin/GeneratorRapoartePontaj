using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npoi.Mapper.Attributes;

namespace GeneratorRaportPontaje.Utils
{
    class ExportData
    {
        [Column("Nr Crt")]
        public int nrCrt { get; set; }

        [Column("Perimetru")]
        public string perimetru { get; set; }

        [Column("Total angajati prezenti verificati")]
        public double employeesCount { get; set; }

        [Column("Ponteaza corect")]
        public double correctCount { get; set; }

        [Column("Ponteaza incorect")]
        public double mistakesCount { get; set; }

        [Column("Ponteaza fara pauza")]
        public double lowerClockingCount { get; set; }

        [Column("% Corect")]
        public double correctness { get; set; }
    }
}
