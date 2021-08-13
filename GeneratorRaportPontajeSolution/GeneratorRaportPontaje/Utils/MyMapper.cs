using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npoi.Mapper;

namespace GeneratorRaportPontaje.Utils
{
    class MyMapper
    {
        Mapper instace;
        public MyMapper(string raportTimesheetsPath)
        {
            Mapper mapper = new Mapper(raportTimesheetsPath);

            int indexIntrari = 0;
            int indexIesiri = 0;

            mapper.Map<TimeSheetRecord>("In", o => o.intrari, (column, target) =>
            {
                string value = "";

                if (column.CurrentValue != null)
                {
                    DateTime dateValue = (DateTime)column.CurrentValue;

                    value = dateValue.TimeOfDay.ToString();
                }

                ((TimeSheetRecord)target).recordsIntrari[indexIntrari] = value;
                indexIntrari = (indexIntrari + 1) % 14;

                return true;
            })
            .Map<TimeSheetRecord>("Out", o => o.iesiri, (column, target) =>
            {
                string value = "";

                if (column.CurrentValue != null)
                {
                    DateTime dateValue = (DateTime)column.CurrentValue;

                    value = dateValue.TimeOfDay.ToString();
                }

                ((TimeSheetRecord)target).recordsIesiri[indexIesiri] = value;
                indexIesiri = (indexIesiri + 1) % 14;

                return true;
            })
            .Map<TimeSheetRecord>("Diferenta", o => o.diferenta, (column, target) =>
            {
                if (column.CurrentValue == null)
                {
                    return false;
                }

                DateTime dateValue = (DateTime)column.CurrentValue;

                string value = dateValue.TimeOfDay.ToString();

                ((TimeSheetRecord)target).diferenta = value;

                return true;
            });

            instace = mapper;
        }

        public Mapper getMapper()
        {
            return instace;
        }
    }
}
