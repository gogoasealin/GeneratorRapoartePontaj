using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using GeneratorRaportPontaje.Utils;
using Npoi.Mapper;

//http://www.zoeller.us/blog/2018/10/24/easiest-way-to-import-excel-files-in-c
namespace GeneratorRaportPontaje
{
    public partial class Main : Form
    {
        string raportTimesheetsPath;
        string raportEmployersPath;

        string currentName = "";
        CurrentEmployee currentEmployeeData;
        DefaultRaportValues raportCurrentValues;
        Dictionary<string, DefaultRaportValues> raportData;
        Dictionary<string, Employee> allEmployeesData;
        Dictionary<int, int> dailyHoursMinimClocking;
        Dictionary<string, string> perimetru;
        TimeSheetRecord oldRow;

        public Main()
        {
            InitializeComponent();

            InitializeVariables();
        }


        private void InitializeVariables()
        {
            raportTimesheetsPath = "";
            raportEmployersPath = "";

            raport_pontaje_nume_fisier.Text = "Nume Raport: ";
            raport_angajati_nume_fisier.Text = "Nume Raport: ";

            currentName = "";

            dailyHoursMinimClocking = new Dictionary<int, int>
            {
                {4,2},
                {5,2},
                {6,4},
                {7,4},
                {8,4},
            }; 

            raportData = new Dictionary<string, DefaultRaportValues>
            {
                {"Carmangerie + Pasare", new DefaultRaportValues()},
                {"Panificatie", new DefaultRaportValues()},
                {"Patiserie", new DefaultRaportValues()},
                {"Cofetarie", new DefaultRaportValues()},
                {"Gastro", new DefaultRaportValues()},
                {"Legume fructe", new DefaultRaportValues()},
                {"Pescarie", new DefaultRaportValues()},
                {"Mezeluri si Branzeturi", new DefaultRaportValues()},
                {"Congelate", new DefaultRaportValues()},
                {"Lactate", new DefaultRaportValues()},
                {"Dulciuri + Bebe", new DefaultRaportValues()},
                {"Sarate", new DefaultRaportValues()},
                {"Bauturi + Tabac", new DefaultRaportValues()},
                {"Detergenti", new DefaultRaportValues()},
                {"Parfumerie", new DefaultRaportValues()},
                {"Textile", new DefaultRaportValues()},
                {"Menaj", new DefaultRaportValues()},
                {"Cultura,jocuri,jucarii", new DefaultRaportValues()},
                {"Auto", new DefaultRaportValues()},
                {"Animalier", new DefaultRaportValues()},
                {"Activitati exterioare", new DefaultRaportValues()},
                {"Electronice / Electrocasnice", new DefaultRaportValues()},
                {"Securitate", new DefaultRaportValues()},
                {"Intretinere", new DefaultRaportValues()},
                {"Receptie Food si Non Food", new DefaultRaportValues()},
                {"CDG + Deco", new DefaultRaportValues()},
                {"E-commerce", new DefaultRaportValues()},
                {"Casa principala", new DefaultRaportValues()},
                {"Case in linie", new DefaultRaportValues()},
                {"RH", new DefaultRaportValues()},
                {"SSM", new DefaultRaportValues()},
            };

            perimetru = new Dictionary<string, string>
            {
                {"Carmangerie", "Carmangerie + Pasare"},
                {"Carne congelata", "Congelate"},
                {"Casa Principala", "Casa principala"},
                {"Case In Linie", "Case in linie"},
                {"Cdg Magazin", "CDG + Deco"},
                {"Cofetarie prod proprie", "Cofetarie"},
                {"Comun Activitati exterioare", "Activitati exterioare"},
                {"Comun Alimentatie Speciala", "Dulciuri + Bebe"},
                {"Comun Animalier", "Animalier"},
                {"Comun Auto Brico", "Auto"},
                {"Comun Bauturi cu alcool", "Bauturi + Tabac"},
                {"Comun Bauturi fara alcool", "Bauturi + Tabac"},
                {"Comun Bebe", "Dulciuri + Bebe"},
                {"Comun Branzeturi", "Mezeluri si Branzeturi"},
                {"Comun Congelate", "Congelate"},
                {"Comun Cultura jocuri jucarii", "Cultura,jocuri,jucarii"},
                {"Comun Deterg Igienizarea Casei", "Detergenti"},
                {"Comun Dulciuri", "Dulciuri + Bebe"},
                {"Comun Electrocasnice", "Electronice / Electrocasnice"},
                {"Comun Electronice, Multimedia", "Electronice / Electrocasnice"},
                {"Comun Fructe si Legume", "Legume fructe"},
                {"Comun Frumusete", "Parfumerie"},
                {"Comun Lactate", "Lactate"},
                {"Comun Menaj", "Menaj"},
                {"Comun Mezeluri", "Mezeluri si Branzeturi"},
                {"Comun Sarate", "Sarate"},
                {"Comun Tabac", "Bauturi + Tabac"},
                {"Comun Textile", "Textile"},
                {"Decorare", "CDG + Deco"},
                {"E-commerce", "E-commerce"},
                {"Gastro productie proprie", "Gastro"},
                {"Gastro semipreparate", "Gastro"},
                {"Intretinere", "Intretinere"},
                {"Panificatie prod proprie", "Panificatie"},
                {"Pasare", "Carmangerie + Pasare"},
                {"Patiserie prod proprie", "Patiserie"},
                {"Peste Proaspat", "Pescarie"},
                {"Peste procesat", "Pescarie"},
                {"Receptie marfa", "Receptie Food si Non Food"},
                {"Resurse Umane", "RH"},
                {"SSM SU", "SSM"},
                {"Securitate", "Securitate"},
            };

            allEmployeesData = new Dictionary<string, Employee>();

            raportCurrentValues = new DefaultRaportValues();
            currentEmployeeData = new CurrentEmployee();
            oldRow              = new TimeSheetRecord();
        }

        private void about_MenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made By Alin Gogoase in 2021", "Despre Generator!");
        }

        private void exit_MenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void upload_raport_access_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                raportTimesheetsPath = openFileDialog1.FileName;

                raport_pontaje_nume_fisier.Text = "Nume Raport: " + Path.GetFileName(raportTimesheetsPath);
            }
        }

        private void upload_raport_angajati_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.raportEmployersPath = openFileDialog1.FileName;

                raport_angajati_nume_fisier.Text = "Nume Raport: " + Path.GetFileName(this.raportEmployersPath);
            }
        }

        private void generator_raport_Click(object sender, EventArgs e)
        {
            if(raportTimesheetsPath == "")
            {
                MessageBox.Show("Raportul cu Pontajele Angajatilor nu a fost incarcat", "Eroare!");
                return;
            }

            if (raportEmployersPath == "")
            {
                MessageBox.Show("Raportul cu Datele Angajatilor nu a fost incarcat", "Eroare!");
                return;
            }

            allEmployeesData = new Dictionary<string, Employee>();

            try {

                getEmployeesData(raportEmployersPath);

                generateRaportData(raportTimesheetsPath);

                generateRaport();

                MessageBox.Show("Raportul a fost generat cu success", "Success!");
            } catch (Exception error) {
                if (error.Message == "The given key was not present in the dictionary.") {
                    MessageBox.Show("Raportul NU a fost generat!!! \n Centru Cost: " + currentEmployeeData.perimetru + " nu exista!", "Error!"); ;
                } else
                {
                    MessageBox.Show("Raportul NU a fost generat!!! \n " + error.Message, "Error!");
                }
            }
        }

        private void getEmployeesData(string raportEmployersPath)
        {
            var mapper = new Mapper(raportEmployersPath);
            var rows = mapper.Take<Employee>("Sheet1");

            foreach (var row in rows)
            {
                var rowValue = row.Value;

                if (string.IsNullOrEmpty(rowValue.nrCrt))
                {
                    continue;
                }

                processEmployeeData(rowValue);
            }
        }

        private void processEmployeeData(Employee currentEmployeeData)
        {
            allEmployeesData.Add(currentEmployeeData.nrMarca, currentEmployeeData);
        }

        private void generateRaportData(string raportTimesheetsPath)
        {
            Mapper mapper = getMapper(raportTimesheetsPath);

            var rows = mapper.Take<TimeSheetRecord>("Sheet1");

            foreach (var row in rows)
            {
                var rowValues = row.Value;

                if (string.IsNullOrEmpty(rowValues.nrCrt))
                {
                    continue;
                }

                calculateEmployeeData(rowValues);

                oldRow = rowValues;
            }

            //process the last employee
            updateRaportData();
        }

        private Mapper getMapper(string raportTimesheetsPath)
        {
            MyMapper myMapper = new MyMapper(raportTimesheetsPath);
            Mapper mapper = myMapper.getMapper();

            return mapper;
        }

        private void calculateEmployeeData(TimeSheetRecord row)
        {
            bool mistakeMade = false;

            if (allEmployeesData.ContainsKey(row.nrMarca) == false
                || row.functie.Contains("Manager") == true) 
            {
                return;
            }

            if (currentName != row.numeAngajat)
            {
                if (currentName != "")
                {
                    updateRaportData();
                }

                currentName = row.numeAngajat;
                currentEmployeeData.employerID = row.nrMarca;
                currentEmployeeData.mistakesCount = 0;
                currentEmployeeData.lowerClockingCount = 0;
                currentEmployeeData.perimetru = allEmployeesData[row.nrMarca].centruCost;
            }

            int intrariSize = row.recordsIntrari.Length;
            bool nightShift = false;
            for (int index = 0; index < intrariSize; index++)
            {
                if(index == 0)
                {
                    if (string.IsNullOrEmpty(row.recordsIntrari[index]) == true && string.IsNullOrEmpty(row.recordsIesiri[index]) == false)
                    {
                        int lastRecordsIntrariCount = count_array_values_after_index(oldRow.recordsIntrari, 1);
                        int lastRecordsIesiriCount = count_array_values_after_index(oldRow.recordsIesiri, 0);
                        if (lastRecordsIntrariCount + lastRecordsIesiriCount == 0)
                        {
                            currentEmployeeData.mistakesCount--;
                            nightShift = true;
                            break;
                        }
                    }
                }

                if (string.IsNullOrEmpty(row.recordsIntrari[index]) == true)
                {
                    if (string.IsNullOrEmpty(row.recordsIesiri[index]) == false)
                    {
                        mistakeMade = true;
                        currentEmployeeData.mistakesCount++;
                        break;
                    }
                }
                else if (string.IsNullOrEmpty(row.recordsIntrari[index]) == false)
                {
                    if (string.IsNullOrEmpty(row.recordsIesiri[index]) == true)
                    {
                        mistakeMade = true;
                        currentEmployeeData.mistakesCount++;
                        break;
                    }
                }

                if (string.IsNullOrEmpty(row.recordsIntrari[index]) == true
                    && string.IsNullOrEmpty(row.recordsIesiri[index]) == true)
                {
                    break;
                }
            }

            if (mistakeMade == true)
            {
                return;
            }

            int employeeHoursPerDay = allEmployeesData[row.nrMarca].oreZiLucru;
            int minHoursPerDay = dailyHoursMinimClocking[employeeHoursPerDay];

            int intrariCount = count_array_values(row.recordsIntrari);
            int iesirCount = count_array_values(row.recordsIesiri);

            if (nightShift)
            {
                intrariCount += 1;
            }

            int employeeClocking = intrariCount + iesirCount;

            if (employeeClocking < minHoursPerDay)
            {
                mistakeMade = true;
                currentEmployeeData.lowerClockingCount++;
            }
        }

        private int count_array_values(string[] array)
        {
            int size = 0;

            foreach(string value in array)
            {
                if(string.IsNullOrEmpty(value) == false)
                {
                    size++;
                }
            }
            return size;
        }

        private int count_array_values_after_index(string[] array, int index)
        {
            int size = 0;
            int arrayLength = array.Length;

            for(int i = index; i < arrayLength; i++)
            {
                if (string.IsNullOrEmpty(array[i]) == false)
                {
                    size++;
                }
            }
            return size;
        }

        private void updateRaportData()
        {
            string currentPerimetru = perimetru[currentEmployeeData.perimetru];

            if(string.IsNullOrEmpty(currentPerimetru))
            {
                throw new InvalidOperationException("CurrentPerimetru nu exista: " + currentEmployeeData.perimetru);
            }

            raportData[currentPerimetru].employeesCount++;

            if (currentEmployeeData.mistakesCount > 3 && currentEmployeeData.mistakesCount > currentEmployeeData.lowerClockingCount)
            {
                raportData[currentPerimetru].wrongClocking++;
            }
            else if (currentEmployeeData.lowerClockingCount > 3)
            {
                raportData[currentPerimetru].lowerClocking++;
            }
            else if (currentEmployeeData.mistakesCount + currentEmployeeData.lowerClockingCount > 3)
            {
                if (currentEmployeeData.mistakesCount >= currentEmployeeData.lowerClockingCount)
                {
                    raportData[currentPerimetru].wrongClocking++;
                } else
                {
                    raportData[currentPerimetru].lowerClocking++;
                }
            }
            else 
            {
                raportData[currentPerimetru].correctClocking++;
            }
            
            raportData[currentPerimetru].correctness = raportData[currentPerimetru].correctClocking / raportData[currentPerimetru].employeesCount;
        }

        private void generateRaport()
        {
            //string raportName = DateTime.Now.ToString() + ".xlsx";
            string raportName = "RaportPontaje.xlsx";
            var mapper = new Mapper();
         
            mapper.Save(raportName);

            int index = 1;

            List<ExportData> rows = new List<ExportData>();

            ExportData storeData = new ExportData();

            foreach (var raport in raportData)
            {
                ExportData row = new ExportData();
                    
                row.nrCrt              = index;
                row.perimetru          = raport.Key;
                row.employeesCount     = raport.Value.employeesCount;
                row.correctCount       = raport.Value.correctClocking;
                row.mistakesCount      = raport.Value.wrongClocking;
                row.lowerClockingCount = raport.Value.lowerClocking;
                row.correctness        = raport.Value.correctness;

                rows.Add(row);

                index += 1;

                storeData.perimetru          = "Magazin";
                storeData.employeesCount     += row.employeesCount;
                storeData.correctCount       += row.correctCount;
                storeData.mistakesCount      += row.mistakesCount;
                storeData.lowerClockingCount += row.lowerClockingCount;
                storeData.correctness        = storeData.correctCount / storeData.employeesCount;
            }
            storeData.nrCrt = index;
            rows.Add(storeData);

            mapper.Put(rows, "sheet1");
            //mapper.Save("E:\\GitRepository\\GeneratorRapoartePontaj\\GeneratorRaportPontajeSolution\\GeneratorRaportPontaje\\bin\\Debug\\test.xlsx");
            mapper.Save(raportName);
        }

        private void generareRaportNouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeVariables();
        }
    }

}
