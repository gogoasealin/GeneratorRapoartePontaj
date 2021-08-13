using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npoi.Mapper.Attributes;


namespace GeneratorRaportPontaje.Utils
{
    class Employee
    {
        [Column("CRT")]
        public string nrCrt { get; set; }
        
        [Column("NR MARCA")]
        public string nrMarca { get; set; }
        
        [Column("NUME ")]
        public string nume { get; set; }
        
        [Column("PRENUME")]
        public string prenume { get; set; }
        
        [Column("FUNCTIE")]
        public string functie { get; set; }
        
        [Column("CENTRU COST")]
        public string centruCost { get; set; }
        
        [Column("ORE ZI LUCRU")]
        public int oreZiLucru { get; set; }
    }
}
