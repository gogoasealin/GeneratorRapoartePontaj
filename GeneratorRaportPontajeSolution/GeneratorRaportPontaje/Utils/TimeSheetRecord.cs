using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npoi.Mapper.Attributes;

namespace GeneratorRaportPontaje.Utils
{
    class TimeSheetRecord
    {
        [Column("Nr.crt.")]
        public string nrCrt { get; set; }

        [Column("Marca")]
        public string nrMarca { get; set; }
        
        [Column("Angajat")]
        public string numeAngajat { get; set; }

        [Column("Functie")]
        public string functie { get; set; }

        [Column("Data")]
        public string dataCurenta { get; set; }

        [Column(CustomFormat = "hh.mm.ss")]
        public DateTime intrari { get; set; }

        [Column(CustomFormat = "hh.mm.ss")]
        public DateTime iesiri { get; set; }

        public string[] recordsIntrari { get; set; } = new string[14];

        public string[] recordsIesiri { get; set; } = new string[14];

        [Column("diferenta")]
        public string diferenta { get; set; }
    }
}
