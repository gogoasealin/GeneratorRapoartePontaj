using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorRaportPontaje.Utils
{
    class TimeSheetRecord
    {
        public string nrCrt { get; set; }
        public string nrMarca { get; set; }
        public string numeAngajat { get; set; }
        public string functie { get; set; }
        public string dataCurenta { get; set; }
        public string[] intrari { get; set; }
        public string[] iesiri { get; set; }
        public string diferenta { get; set; }

        public TimeSheetRecord(string[] data)
        {
            nrCrt = data[0];
            nrMarca = data[1];
            numeAngajat = data[2];
            functie = data[3];
            dataCurenta = data[4];

            var fieldsBeforeInAndOut = 4;
            var indexDiferenta = data.Length - 1;

            var numarIntrariSiIesiri = indexDiferenta - fieldsBeforeInAndOut;
            var numarIntrari = numarIntrariSiIesiri / 2;
            var numarIesiri = numarIntrariSiIesiri / 2;

            intrari = new string[numarIntrari];
            iesiri = new string[numarIesiri];

            if (data.Length > 6)
            {
                var intrareIndex = 0;
                var iesireIndex = 0;

                for (int i = 5; i < indexDiferenta; i++)
                {
                    if (i % 2 == 1)
                    {
                        intrari[intrareIndex] = data[i];
                        intrareIndex += 1;
                    }
                    else
                    {
                        iesiri[iesireIndex] = data[i];
                        iesireIndex += 1;
                    }
                }
            }

            diferenta = data[indexDiferenta];
        }
    }
}
