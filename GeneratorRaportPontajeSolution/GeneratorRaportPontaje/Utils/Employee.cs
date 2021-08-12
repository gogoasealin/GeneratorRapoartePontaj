using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorRaportPontaje.Utils
{
    class Employee
    {
        public string nrCrt { get; set; }
        public string nrMarca { get; set; }
        public string nume { get; set; }
        public string prenume { get; set; }
        public string functie { get; set; }
        public string centruCost { get; set; }
        public int oreZiLucru { get; set; }

        public Employee(string[] data)
        {
            nrCrt      = data[0];
            nrMarca    = data[1];
            nume       = data[2];
            prenume    = data[3];
            functie    = data[4];
            centruCost = data[5];
            oreZiLucru = Int32.Parse(data[6]);

        }
    }
}
